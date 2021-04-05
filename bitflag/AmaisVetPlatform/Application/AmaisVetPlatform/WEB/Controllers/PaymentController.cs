using DTO.Payment;
using DTO.Payment.Integration.Iugu;
using DTO.Shared;
using DTO.Subscription;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using WEB.Filters;

namespace WEB.Controllers
{
    [Route("pagamento/")]
    public class PaymentController : Controller
    {
        private readonly Services.Subscription.SubscriptionService subscriptionService;
        private readonly Services.Plan.PlanService planService;
        private readonly Services.Payment.Integration.IuguService iuguService;
        public PaymentController(Services.Subscription.SubscriptionService subscriptionService, Services.Plan.PlanService planService, Services.Payment.Integration.IuguService iuguService)
        {
            this.subscriptionService = subscriptionService;
            this.planService = planService;
            this.iuguService = iuguService;
        }

        [HttpGet]
        [Route("token-cartao-de-credito/{reference?}")]
        //[ReferenceValidation(SubscriptionSteps.Payment)]
        public async Task<IActionResult> CreditCardToken(string reference, PaymentMethods paymentMethodId, string number, string firstName, string lastName, string month, string year, string verificationValue)
        {
            switch (paymentMethodId)
            {
                case PaymentMethods.CreditCard:
                    var message = iuguService.HandleIuguPaymentTokenReponseData(await iuguService.PaymentToken(number, firstName, lastName, month, year, verificationValue), out bool hasError, out string token);
                    return Json(new XHRBaseResponse(token, message, hasError));
                default:
                    return Json(new XHRBaseResponse());

            }
        }
        [HttpPost]
        [Route("pagar/{reference?}")]
        [ReferenceValidation(SubscriptionSteps.Payment)]
        public async Task<IActionResult> Pay(string reference, PaymentMethods paymentMethodId, string token, string fallbackUrl, string redirectUrl)
        {
            try
            {
                using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var subscriptionViewModel = await subscriptionService.GetSubscriptionAsync(reference);

                    #region [IUGU]
                    var planCode = await planService.GetPlainPaymentGatewayExternalCodeAsync(subscriptionViewModel.PlanId.Value, subscriptionViewModel.PlanPriceTableId.Value);
                    var accountCode = await iuguService.AddCustomer(subscriptionViewModel);
                    if (paymentMethodId == PaymentMethods.CreditCard) await iuguService.AddCustomerPaymentMethod(accountCode, "Cartão de Crédito - Padrão", token, true);
                    var subscriptionCode = await iuguService.AddSubscription(planCode, accountCode, iuguService.GetPayableWith(paymentMethodId), iuguService.GetExpirationDate(paymentMethodId));
                    #endregion

                    await subscriptionService.AddPaymentInfoAsync(reference, paymentMethodId, DTO.Payment.Integration.PaymentGatewayProviders.Iugu, accountCode, planCode, subscriptionCode);
                    await subscriptionService.ClearPaymentErrorAsync(reference);
                    await subscriptionService.FlagCertificateAsync(reference);

                    transactionScope.Complete();

                    return Redirect(redirectUrl);
                }
            }
            catch (PaymentException exception)
            {
                TempData["Error"] = exception.Message;
                await subscriptionService.AddPaymentErrorAsync(reference, exception.Message);

                return Redirect(fallbackUrl);
            }
            catch (Exception exception)
            {
                TempData["Error"] = "Houve um erro ao processar seu pagamento.";
                await subscriptionService.AddPaymentErrorAsync(reference, exception.Message);

                return Redirect(fallbackUrl);
            }
        }
    }
}
