using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using FUNCTIONS.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Utils;

namespace Web.Controllers
{
    [Authorize(Roles = "Administrator, Administrative, Administrative Assistant, Contact Manager")]
    public class IndicationController : Controller
    {
        private readonly FUNCTIONS.Indication.IndicationFunctions indicationFunctions;
        private readonly FUNCTIONS.ServiceType.ServiceTypeFunctions serviceTypeFunctions;
        private readonly FUNCTIONS.AuditLog.AuditLogFunctions auditLogFunctions;
        private readonly FUNCTIONS.User.UserFunctions userFunctions;
        private readonly FUNCTIONS.Client.ClientFunctions clientFunctions;
        private readonly FUNCTIONS.Client.ClientTypeFunctions clientTypeFunctions;
        private readonly UserManager<TerraNostraIdentityDbContext.User> userManager;
        private readonly FUNCTIONS.Mail.MailFunctions mailFunctions;

        public IndicationController(FUNCTIONS.Indication.IndicationFunctions indicationFunctions, FUNCTIONS.ServiceType.ServiceTypeFunctions serviceTypeFunctions, FUNCTIONS.AuditLog.AuditLogFunctions auditLogFunctions, FUNCTIONS.User.UserFunctions userFunctions, FUNCTIONS.Client.ClientFunctions clientFunctions, FUNCTIONS.Client.ClientTypeFunctions clientTypeFunctions, UserManager<TerraNostraIdentityDbContext.User> userManager, FUNCTIONS.Mail.MailFunctions mailFunctions)
        {
            this.indicationFunctions = indicationFunctions;
            this.serviceTypeFunctions = serviceTypeFunctions;
            this.auditLogFunctions = auditLogFunctions;
            this.userFunctions = userFunctions;
            this.clientFunctions = clientFunctions;
            this.clientTypeFunctions = clientTypeFunctions;
            this.userManager = userManager;
            this.mailFunctions = mailFunctions;
        }

        #region [SHARED]
        public string CreateUserFromClientMailMessage(DTO.User.UserViewModel user, string password)
        {
            return "Olá <b>" + user.FirstName + (string.IsNullOrWhiteSpace(user.LastName) ? "</b>," : " " + user.LastName + "</b>,") +
                "<br /><br />" +
                "Foi criado um usuário para este e-mail, e a senha atribuída foi: <b>" + password + "</b>." +
                "<br /><br />" +
                "Atenciosamente," +
                "<br /><br />" +
                "Equipe Terra Nostra Assessoria";
        }
        #endregion

        #region [PAGE]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Manage(int? id)
        {
            if (User.IsInRole("Salesman") && id.HasValue)
            {
                var indication = indicationFunctions.GetDataByID(id);
                var user = await userManager.GetUserAsync(User);
                if (indication.UserId != user.Id) return Forbid();
            }

            return View(id);
        }

        #region [New]
        [AllowAnonymous]
        public async Task<IActionResult> New(int? id)
        {
            if (!id.HasValue) return NotFound();

            ViewData["Services"] = serviceTypeFunctions.GetDataViewModel(serviceTypeFunctions.GetData(x => !x.IsDeleted));
            ViewData["UserName"] = userFunctions.GetFullName(id.Value);

            var model = new DTO.Indication.NewIndicationViewModel();
            model.UserId = id.Value;

            return View(model);
        }
        [AllowAnonymous]
        [ActionName("New")]
        [HttpPost]
        public async Task<IActionResult> _New(DTO.Indication.NewIndicationViewModel model)
        {
            ViewData["Services"] = serviceTypeFunctions.GetDataViewModel(serviceTypeFunctions.GetData(x => !x.IsDeleted));
            ViewData["UserName"] = userFunctions.GetFullName(model.UserId);

            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(model.FullName))
                errors.Add("Por favor, preencha seu nome completo.");

            if (string.IsNullOrWhiteSpace(model.Email))
                errors.Add("Por favor, preencha seu e-mail.");
            else if (!IsValidEmail(model.Email))
                errors.Add("E-mail inválido.");
            else if (await indicationFunctions.CheckIfExists(model.Email, model.ServiceTypeId))
                errors.Add("Os dados cadastrados já foram informados anteriormente.");

            if (string.IsNullOrWhiteSpace(model.Phone))
                errors.Add("Por favor, preencha seu telefone.");

            if (errors.Count == 0)
                if (await indicationFunctions.Add(model))
                {
                    await FUNCTIONS.Mail.MailFunctions.SendAsync("Recebemos seu contato!", await indicationFunctions.IndicadoEmailMessage(model), null, new List<string>() { model.Email }, null);

#if !DEBUG
                    await FUNCTIONS.Mail.MailFunctions.SendAsync("Nova indicação!", await indicationFunctions.TerraNostraEmailMessage(model), null, new List<string>() { "vagner@terranostracidadania.com.br" }, null);
#else
                    await FUNCTIONS.Mail.MailFunctions.SendAsync("Nova indicação!", await indicationFunctions.TerraNostraEmailMessage(model), null, new List<string>() { "yuriasa@gmail.com" }, null);
#endif

                    ViewData["Success"] = "Parabéns, seus dados foram enviados com sucesso!";
                }
                else
                    errors.Add("Houve um erro ao criar seu cadastro, tente novamente mais tarde.");


            ViewData["Error"] = errors;

            return View(model);
        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #endregion

        #region [ViewComponent]
        public IActionResult IndicationIndexComponent()
        {
            return ViewComponent(typeof(ViewComponents.Indication.IndicationIndexViewComponent));
        }

        public IActionResult IndicationManageComponent(int? id)
        {
            var indication = new DTO.Indication.IndicationViewModel();
            if (id.HasValue) indication = indicationFunctions.GetDataViewModel(indicationFunctions.GetDataByID(id));

            if (User.IsInRole("Administrator")) ViewData["Users"] = userFunctions.GetData(x => !x.IsDeleted).ToList();

            return ViewComponent(typeof(ViewComponents.Indication.IndicationManageViewComponent), new { model = indication });
        }
        #endregion

        #region [XHR]
        [HttpPost]
        [ActionName("List")]
        public async Task<IActionResult> List(DTO.Shared.DataTablesAjaxPostModel filter, string indicationFilter)
        {
            string query = "";
            List<SqlParameter> param = new List<SqlParameter>();

            if (User.IsInRole("Salesman"))
            {
                var user = await userManager.GetUserAsync(User);
                Utils.SqlParameterUtils.SetNewParameter(ref param, ref query, "UserId", user.Id);
            }


            if (!string.IsNullOrEmpty(indicationFilter))
            {
                switch (indicationFilter)
                {
                    case "PENDING":
                        Utils.SqlParameterUtils.SetNewParameter(ref param, ref query, "Accepted", false);
                        Utils.SqlParameterUtils.SetNewParameter(ref param, ref query, "IsDeleted", false);
                        //d = d.Where(x => !x.AcceptedBy.HasValue && !x.DeletedBy.HasValue);
                        break;
                    case "ACCEPTED":
                        Utils.SqlParameterUtils.SetNewParameter(ref param, ref query, "Accepted", true);
                        Utils.SqlParameterUtils.SetNewParameter(ref param, ref query, "IsDeleted", false);
                        //d = d.Where(x => x.AcceptedBy.HasValue && !x.DeletedBy.HasValue);
                        break;
                    case "DELETED":
                        Utils.SqlParameterUtils.SetNewParameter(ref param, ref query, "Accepted", false);
                        Utils.SqlParameterUtils.SetNewParameter(ref param, ref query, "IsDeleted", true);
                        //d = d.Where(x => !x.AcceptedBy.HasValue && x.DeletedBy.HasValue);
                        break;
                }
                //recordsFiltered = d.Count();
            }

            IEnumerable<DTO.Indication.IndicationListViewModel> d = indicationFunctions.GetDataListViewModel(indicationFunctions.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, query, param.ToArray()));


            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            }));
        }

        [HttpPost]
        [ActionName("Manage")]
        public async Task<IActionResult> _Manage(DTO.Indication.IndicationViewModel model)
        {
            var user = await userManager.GetUserAsync(User);

            FUNCTIONS.AuditLog.DBActionType dbActionType;
            if (model.IndicationId.HasValue)
            {
                var indication = indicationFunctions.GetDataByID(model.IndicationId);
                if (indication.Accepted) return Json(new FUNCTIONS.Shared.ReturnResult(indication.IndicationId, "", true));

                dbActionType = FUNCTIONS.AuditLog.DBActionType.UPDATE;
            }
            else dbActionType = FUNCTIONS.AuditLog.DBActionType.CREATE;

            if (!string.IsNullOrWhiteSpace(model.Email))
            {
                if (clientFunctions.ExistEmail(model.Email))
                    return Json(new FUNCTIONS.Shared.ReturnResult(0, "Cliente com e-mail já existente", true, "Email"));

                if (!indicationFunctions.ValidateManage(model.Email, model.IndicationId, model.ServiceTypeId.Value))
                    return Json(new FUNCTIONS.Shared.ReturnResult(0, "E-mail ja foi indicado duas vezes ou já foi indicado com este serviço", true, "Email"));

            }

            model.IndicationId = indicationFunctions.CreateOrUpdate(model);

            auditLogFunctions.Log("IndicationViewModel", model.IndicationId.Value, "IndicationId", dbActionType, indicationFunctions.GetDataViewModel(indicationFunctions.GetDataByID(model.IndicationId)), user.Id);

            return Json(new FUNCTIONS.Shared.ReturnResult(model.IndicationId.Value, "", false));
        }

        [HttpPost]
        [ActionName("RemoveIndication")]
        public async Task<IActionResult> RemoveIndication(int id)
        {
            if (!indicationFunctions.Exists(id)) return Json(new FUNCTIONS.Shared.ReturnResult(0, "Indicação não encontrada para excluir.", true));

            var user = await userManager.GetUserAsync(User);

            indicationFunctions.Delete(id, user.Id);

            auditLogFunctions.Log("IndicationViewModel", id, "IndicationId", FUNCTIONS.AuditLog.DBActionType.DELETE, indicationFunctions.GetDataViewModel(indicationFunctions.GetDataByID(id)), user.Id, "Exclusão");

            return Json(new FUNCTIONS.Shared.ReturnResult(0, "Indicação excluída com sucesso!", false));
        }

        [HttpPost]
        [ActionName("Accept")]
        public async Task<IActionResult> Accept(int indicationId)
        {
            if (!indicationFunctions.Exists(indicationId))
                return Json(new FUNCTIONS.Shared.ReturnResult(0, "Indicação não encontrada.", true));

            var indication = indicationFunctions.GetDataByID(indicationId);
            var user = await userManager.GetUserAsync(User);

            if (clientFunctions.ExistEmail(indication.Email))
            {
                indicationFunctions.Accept(indicationId, null, user.Id);
                return Json(new FUNCTIONS.Shared.ReturnResult(0, "Cliente com o mesmo e-mail existente.", true));
            }


            StringUtils.GetName(indication.Name, out string firstName, out string lastName);
            var personId = clientTypeFunctions.GetDataByExternalCode("PERSON").ClientTypeId;
            var clientId = clientFunctions.Create(new DTO.Client.ClientViewModel
            {
                FirstName = firstName,
                LastName = lastName,
                Telefone = indication.Phone,
                Email = indication.Email,
                ClientTypeId = personId,
                ContactMediumId = 10
            });

            if (!userFunctions.ExistEmail(indication.Email))
            {
                var newUser = await userFunctions.CreateFromClient(clientId);

                userFunctions.ClearUserRoles(newUser.UserId.Value);
                newUser.Role = "CLIENT";
                userFunctions.AddUserToRole(newUser.UserId.Value, newUser.Role);

                //await FUNCTIONS.Mail.MailFunctions.SendAsync("Criação de conta em Terra Nostra", CreateUserFromClientMailMessage(newUser, newUser.Password), "", new List<string> { newUser.Email }, null);

                auditLogFunctions.Log("UserViewModel", newUser.UserId.Value, "UserId", FUNCTIONS.AuditLog.DBActionType.CREATE, userFunctions.GetDataViewModel(userFunctions.GetDataByID(newUser.UserId)), user.Id);
            }

            indicationFunctions.Accept(indicationId, clientId, user.Id);

            auditLogFunctions.Log("ClientViewModel", clientId, "ClientId", FUNCTIONS.AuditLog.DBActionType.CREATE, clientFunctions.GetDataViewModel(clientFunctions.GetDataByID(clientId)), user.Id);
            auditLogFunctions.Log("IndicationViewModel", indicationId, "IndicationId", FUNCTIONS.AuditLog.DBActionType.UPDATE, indicationFunctions.GetDataViewModel(indicationFunctions.GetDataByID(indicationId)), user.Id, "Indicação Aceita");

            return Json(new FUNCTIONS.Shared.ReturnResult(clientId, "Cliente e usuário criados com sucesso a partir da indicação!", false));
        }
        #endregion
    }
}