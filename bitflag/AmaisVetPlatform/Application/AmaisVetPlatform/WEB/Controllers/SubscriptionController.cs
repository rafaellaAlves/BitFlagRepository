using DTO.Account;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO.Subscription;
using System.Threading;
using Services.Subscription;
using Microsoft.Extensions.Caching.Memory;
using WEB.Models.Subscription.Plan;
using Services.Plan;
using Services.PlanCoverageType;
using DTO.PlanCoverageType;
using DTO.Plan;
using System.Transactions;
using Services.HealthQuestionnaire;
using WEB.Models.Subscription.Questionnaire;
using DTO.HealthQuestionnaire;
using WEB.Filters;
using Services.Mail;
using WEB.Helpers;
using DTO.Certificate;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace WEB.Controllers
{
    [Route("assinatura/")]
    public class SubscriptionController : Controller
    {
        private readonly IMemoryCache memoryCache;
        private readonly SubscriptionService subscriptionService;
        private readonly PlanService planService;
        private readonly PlanCoverageTypeService planCoverageTypeService;
        private readonly HealthQuestionnaireService healthQuestionnaireService;
        private readonly MailService mailService;
        private readonly MailLogService mailLogService;
        private readonly ViewEngineHelper viewEngineHelper;
        private readonly IWebHostEnvironment webHostingEnvironment;
        public SubscriptionController(IMemoryCache memoryCache, SubscriptionService subscriptionService, PlanService planService, PlanCoverageTypeService planCoverageTypeService, HealthQuestionnaireService healthQuestionnaireService, MailService mailService, MailLogService mailLogService, ViewEngineHelper viewEngineHelper, IWebHostEnvironment webHostingEnvironment)
        {
            this.memoryCache = memoryCache;
            this.subscriptionService = subscriptionService;
            this.planService = planService;
            this.planCoverageTypeService = planCoverageTypeService;
            this.healthQuestionnaireService = healthQuestionnaireService;
            this.mailService = mailService;
            this.mailLogService = mailLogService;
            this.viewEngineHelper = viewEngineHelper;
            this.webHostingEnvironment = webHostingEnvironment;
        }
        private async Task<List<PlanCoverageTypeViewModel>> GetActivePlanCoverageTypesCacheAsync()
        {
            if (!memoryCache.TryGetValue("ActivePlanCoverageTypes", out List<PlanCoverageTypeViewModel> o))
            {
                o = await planCoverageTypeService.GetActivePlanCoverageTypesAsync();
                memoryCache.Set("ActivePlanCoverageTypes", o, TimeSpan.FromMinutes(5));
            }

            return o;
        }
        private async Task<List<PlanInfoViewModel>> GetActivePlansInfoCacheAsync(int planPriceTableId)
        {
            if (!memoryCache.TryGetValue(string.Format("ActivePlansInfo-{0}", planPriceTableId), out List<PlanInfoViewModel> o))
            {
                o = await planService.GetActivePlansInfoAsync(planPriceTableId);
                memoryCache.Set(string.Format("ActivePlansInfo-{0}", planPriceTableId), o, TimeSpan.FromMinutes(5));
            }

            return o;
        }

        #region [Control]
        [HttpGet]
        [Route("ir/{reference?}")]
        public async Task<IActionResult> GoTo(string reference)
        {
            try
            {
                if (!await subscriptionService.ReferenceExistsAsync(reference))
                    return RedirectToAction(nameof(SubscriptionNotFound));


                var subscriptionStep = await subscriptionService.GetCertificateSubscriptionStepAsync(reference);
                switch (subscriptionStep)
                {
                    case SubscriptionSteps.Plans:
                        return RedirectToAction(nameof(Plans), new { reference });
                    case SubscriptionSteps.HealthQuestionnaire:
                        return RedirectToAction(nameof(Questionnaire), new { reference });
                    case SubscriptionSteps.HealthQuestionnaireBlock:
                        return RedirectToAction(nameof(HealthBlock), new { reference });
                    case SubscriptionSteps.Payment:
                        return RedirectToAction(nameof(Payment), new { reference });
                    case SubscriptionSteps.Certificate:
                        return RedirectToAction(nameof(Certificate), new { reference });
                }


                return RedirectToAction(nameof(SubscriptionStepError), new { b = true });
            }
            catch (Exception exception)
            {
                return RedirectToAction(nameof(SubscriptionStepError), new { e = true });
            }
        }

        [HttpGet]
        [Route("nao-encontrada")]
        public async Task<IActionResult> SubscriptionNotFound()
        {
            return await Task.Run(() => View());
        }
        [HttpGet]
        [Route("acesso-negado")]
        public async Task<IActionResult> SubscriptionStepError()
        {
            return await Task.Run(() => View());
        }
        #endregion

        #region [Start]
        [HttpPost]
        [Route("aderir")]
        public async Task<IActionResult> Start(SubscriptionViewModel model)
        {
            string reference = null;
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    reference = await subscriptionService.StartSubscriptionAsync(model);
                    var planPriceTableId = await planService.GetPlanPriceTable(model);
                    await subscriptionService.ChoosePlanPriceTableAsync(reference, planPriceTableId);

                    // enviar e-mail de boas vindas
                    var subscriptionViewModel = await subscriptionService.GetSubscriptionAsync(reference);
                    await Task.Run(async () => await mailService.SendAsync("Contato", "Cotação – Acesso aos planos da AmaisVet Seguros Veterinários", await GetHtmlFromView("~/Views/Mail/Subscription/Start.cshtml", subscriptionViewModel), subscriptionViewModel.Email));

                    transaction.Complete();

                    return RedirectToAction(nameof(Plans), new { reference });
                }
            }
            catch (Exception exception)
            {
                return RedirectToAction(nameof(Plans), new { reference });
            }
        }
        #endregion

        #region [Plans]
        [HttpGet]
        [Route("planos/{reference?}")]
        [ReferenceValidation(SubscriptionSteps.Plans)]
        public async Task<IActionResult> Plans(string reference)
        {
            var subscriptionViewModel = await subscriptionService.GetSubscriptionAsync(reference);

            return View(new ChoosePlanViewModel()
            {
                Subscription = subscriptionViewModel,
                PlanCoverageTypes = await GetActivePlanCoverageTypesCacheAsync(),
                Plans = await GetActivePlansInfoCacheAsync(subscriptionViewModel.PlanPriceTableId.Value)
            });
        }

        [HttpPost]
        [Route("escolher-plano/{reference?}")]
        [ReferenceValidation(SubscriptionSteps.Plans)]
        public async Task<IActionResult> SelectPlan(string reference, SubscriptionViewModel model)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    await subscriptionService.AddPersonalInfoAsync(model.Reference, model);
                    await subscriptionService.ChoosePlanAsync(model.Reference, model.PlanId.Value);
                    transaction.Complete();

                    return RedirectToAction(nameof(Questionnaire), new { reference = model.Reference });
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
        }
        #endregion

        #region [Health Questionnaire]
        [HttpGet]
        [Route("questionario-de-saude/{reference?}")]
        [ReferenceValidation(SubscriptionSteps.HealthQuestionnaire)]
        public async Task<IActionResult> Questionnaire(string reference)
        {
            var healthQuestionnaireId = await healthQuestionnaireService.GetLastestHealthQuestionnaireIdAysnc();
            var healthQuestionnaireResponses = await subscriptionService.GetHealthQuestionnaireQuestionResponseAsync(reference, healthQuestionnaireId);
            var questionnaireViewModel = new QuestionnaireViewModel()
            {
                Subscription = await subscriptionService.GetSubscriptionAsync(reference),
                HealthQuestionnaire = await healthQuestionnaireService.GetLatestHealthQuestionnaireAsync(healthQuestionnaireId),
                HealthQuestionnaireResponses = healthQuestionnaireResponses
            };

            return View(questionnaireViewModel);
        }
        [HttpPost]
        [Route("responder-questionario/{reference?}")]
        [ReferenceValidation(SubscriptionSteps.HealthQuestionnaire)]
        public async Task<IActionResult> SubmitQuestionnaire(string reference, List<QuestionResponseViewModel> questionResponses)
        {

            try
            {
                if (await subscriptionService.IsBlockedByHealthQuestionnaireAsync(reference))
                {
                    return RedirectToAction(nameof(HealthBlock), new { reference = reference });
                }
                else
                {
                    var healthQuestionnaireId = await healthQuestionnaireService.GetLastestHealthQuestionnaireIdAysnc();
                    if (questionResponses.Count < await healthQuestionnaireService.GetLatestHealthQuestionnaireQuestionCountAsync(healthQuestionnaireId)) return RedirectToAction(nameof(SubscriptionStepError));

                    using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        await subscriptionService.ClearHealthQuestionnaireAsync(reference, healthQuestionnaireId);
                        await subscriptionService.SaveHealthQuestionnaireAsync(reference, healthQuestionnaireId, questionResponses);

                        if (await subscriptionService.HasHealthQuestionnaireNegativeReponseAsync(reference))
                        {
                            var subscriptionViewModel = await subscriptionService.GetSubscriptionAsync(reference);
                            var planInfoViewModel = await planService.GetPlanInfoAsync(subscriptionViewModel.PlanId.Value, subscriptionViewModel.PlanPriceTableId.Value);

                            if (!await subscriptionService.HealthQuestionnaireIsUnblockedAsync(reference))
                            {
                                Guid token = await subscriptionService.BlockSubscriptionByHealthQuestionnaireAsync(reference);
                                await mailService.SendAsync("Contato", "Declaração Pessoal de Saúde - AmaisVet!", await GetHtmlFromView("~/Views/Mail/Subscription/HealthBlock.cshtml", subscriptionViewModel), subscriptionViewModel.Email, new List<System.Net.Mail.Attachment>() { new System.Net.Mail.Attachment(Path.Combine(webHostingEnvironment.ContentRootPath, "SystemFiles", "Declaração Pessoal de Saúde - AmaisVet.pdf")) });
                                await mailService.SendToResponsiblesAsync("Contato", $"Proposta {subscriptionViewModel.Reference} Indeferida - AmaisVet!", await GetHtmlFromView("~/Views/Mail/Subscription/HealthUnblockAdmin.cshtml", new HealthQuestionnaireUnblockViewModel(subscriptionViewModel, planInfoViewModel, token)));
                            }
                        }
                        transaction.Complete();
                    }
                }

                return RedirectToAction(nameof(Payment), new { reference = reference });
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        [HttpGet]
        [Route("bloqueio-questionario-de-saude/{reference?}")]
        [ReferenceValidation(SubscriptionSteps.HealthQuestionnaireBlock)]
        public async Task<IActionResult> HealthBlock(string reference)
        {
            var subscriptionViewModel = await subscriptionService.GetSubscriptionAsync(reference);

            return await Task.Run(() => View(subscriptionViewModel));
        }
        [HttpGet]
        [Route("desbloqueio-questionario-de-saude/{reference}/{token}")]
        [ReferenceValidation(SubscriptionSteps.HealthQuestionnaireUnblock)]
        public async Task<IActionResult> HealthUnblockAdmin(string reference, Guid token)
        {
            try
            {
                if (token == null || !await subscriptionService.ValidateHealthUnblockTokenAsync(reference, token)) throw new Exception("Token inválido.");
                using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    if (await subscriptionService.IsBlockedByHealthQuestionnaireAsync(reference))
                    {
                        await subscriptionService.HealthUnblockSubscriptionAsync(reference);
                        var subscriptionViewModel = await subscriptionService.GetSubscriptionAsync(reference);
                        await mailService.SendAsync("Contato", "Desbloqueio de Proposta para contratação dos Seguros AmaisVet", await GetHtmlFromView("~/Views/Mail/Subscription/HealthUnblock.cshtml", subscriptionViewModel), subscriptionViewModel.Email);
                    }
                    transactionScope.Complete();
                }
            }
            catch (Exception exception)
            {
                ViewData["Error"] = true;
            }
            return await Task.Run(() => View(nameof(HealthUnblockAdmin)));
        }
        #endregion

        #region [Payment]
        [HttpGet]
        [Route("pagamento/{reference?}")]
        [ReferenceValidation(SubscriptionSteps.Payment)]
        public async Task<IActionResult> Payment(string reference)
        {
            var subscriptionViewModel = await subscriptionService.GetSubscriptionAsync(reference);

            return View(subscriptionViewModel);
        }
        // POST: Payment/Pay
        #endregion

        #region [Certificate]
        [HttpGet]
        [Route("confirmacao/{reference?}")]
        [ReferenceValidation(SubscriptionSteps.Certificate)]
        public async Task<IActionResult> Confirmation(string reference)
        {
            try
            {
                using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    if (await subscriptionService.CertificateSentAsync(reference)) return RedirectToAction(nameof(Certificate), new { reference });

                    var subscriptionViewModel = await subscriptionService.GetSubscriptionAsync(reference);
                    var planInfoViewModel = await planService.GetPlanInfoAsync(subscriptionViewModel.PlanId.Value, subscriptionViewModel.PlanPriceTableId.Value);
                    await mailService.SendAsync("Certificado", "Bem vindo a AmaisVet! Certificado Individual de Seguro Profissional e Renda Protegida", await GetHtmlFromView("~/Views/Mail/Subscription/CertificateKit.cshtml", new CertificateViewModel(subscriptionViewModel, planInfoViewModel)), subscriptionViewModel.Email);
                    await subscriptionService.AddCertificateSentAsync(reference, false, null);

                    transactionScope.Complete();
                }
            }
            catch (Exception exception)
            {
                await subscriptionService.AddCertificateSentAsync(reference, true, exception.Message);
            }

            return View(await subscriptionService.GetSubscriptionAsync(reference));
        }
        [HttpGet]
        [Route("certificado/{reference?}")]
        [ReferenceValidation(SubscriptionSteps.Certificate)]
        public async Task<IActionResult> Certificate(string reference)
        {
            var subscriptionViewModel = await subscriptionService.GetSubscriptionAsync(reference);
            var planInfoViewModel = await planService.GetPlanInfoAsync(subscriptionViewModel.PlanId.Value, subscriptionViewModel.PlanPriceTableId.Value);

            return View(new CertificateViewModel()
            {
                Subscription = subscriptionViewModel,
                Plan = planInfoViewModel
            });
        }
        #endregion


        [HttpPost]
        public IActionResult Validate([FromBody] ValidateSubscriptionViewModel model)
        {
            try
            {
                if (model.Reference == "XPTO1234")
                    return Json(true);
                else
                    return Json(false);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        [HttpGet]
        public IActionResult PlansUpgradeChoose(int planId)
        {
            var model = new DTO.Subscription.SubscriptionDetailViewModel()
            {
                PlanId = planId
            };

            if (model.PlanId > 0)
            {
                return RedirectToAction(nameof(PlansUpgrade), new { model.PlanId });
            }
            else
            {
                return RedirectToAction("UpgradeSubscription", "Home");
            }

        }
        [HttpGet]
        public IActionResult PlansUpgrade(SubscriptionDetailViewModel model)
        {
            return View(model);
        }
        public IActionResult Unsubscribe()
        {
            return View();
        }

        private async Task<string> GetHtmlFromView(string viewName, object model)
        {
            return await viewEngineHelper.RenderPartialViewToString(ControllerContext, ViewData, TempData, viewName, model);
        }
    }
}
