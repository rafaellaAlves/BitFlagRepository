using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DB;
using DTO.Client;
using DTO.Utils;
using FUNCTIONS.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Web.Extensions;
using Web.Utils;

namespace Web.Controllers
{
    [Authorize(Roles = "Administrator, Contact Manager, Salesman, Administrative, Administrative Assistant, Financial")]
    public class ClientController : Controller
    {
        private readonly FUNCTIONS.Client.ClientLogFunctions clientLogFunctions;
        private readonly FUNCTIONS.Client.ClientCalendarFunctions clientCalendarFunctions;
        private readonly FUNCTIONS.Client.ClientFunctions clientFunctions;
        private readonly FUNCTIONS.User.UserFunctions userFunctions;
        private readonly FUNCTIONS.AuditLog.AuditLogFunctions auditLogFunctions;
        private readonly FUNCTIONS.Client.FamilyTreeFunctions familyTreeFunctions;
        private readonly FUNCTIONS.Client.ClientArchiveFunctions clientArchiveFunctions;
        private readonly FUNCTIONS.Client.ClientStatusFunctions clientStatusFunctions;
        private readonly FUNCTIONS.Client.ClientStatusHistoryFunctions clientStatusHistoryFunctions;
        private readonly FUNCTIONS.Family.ClientApplicantFunctions clientApplicantFunctions;
        private readonly FUNCTIONS.Client.ClientDependentFunctions clientDependentFunctions;
        private readonly FUNCTIONS.Client.ClientListFunctions clientListFunctions;
        private readonly FUNCTIONS.Client.ClientTaskNotificationFunctions clientTaskNotificationFunctions;
        private readonly DB.TerraNostraContext context;


        private readonly string folderDrive; // = "1MqpBUJXq7M6jVhLNGbF1zNaP6EV7XA4o";
        private readonly GoogleDriveAPI.GoogleDriveAPI googleDriveAPI;

        private readonly UserManager<TerraNostraIdentityDbContext.User> userManager;

        public ClientController(FUNCTIONS.Client.ClientLogFunctions clientLogFunctions,
            FUNCTIONS.Client.ClientFunctions clientFunctions,
            FUNCTIONS.Client.ClientCalendarFunctions calendarFunctions,
            FUNCTIONS.User.UserFunctions userFunctions,
            FUNCTIONS.AuditLog.AuditLogFunctions auditLogFunctions,
            FUNCTIONS.Client.FamilyTreeFunctions familyTreeFunctions,
            FUNCTIONS.Client.ClientArchiveFunctions clientArchiveFunctions,
            UserManager<TerraNostraIdentityDbContext.User> userManager,
            FUNCTIONS.Client.ClientStatusFunctions clientStatusFunctions,
            FUNCTIONS.Client.ClientStatusHistoryFunctions clientStatusHistoryFunctions,
            FUNCTIONS.Family.ClientApplicantFunctions clientApplicantFunctions,
            FUNCTIONS.Client.ClientDependentFunctions clientDependentFunctions,
            FUNCTIONS.Client.ClientListFunctions clientListFunctions,
            FUNCTIONS.Client.ClientTaskNotificationFunctions clientTaskNotificationFunctions,
            DB.TerraNostraContext context,
            IConfiguration Configuration)

        {
            this.clientLogFunctions = clientLogFunctions;
            this.clientCalendarFunctions = calendarFunctions;
            this.clientFunctions = clientFunctions;
            this.userFunctions = userFunctions;
            this.auditLogFunctions = auditLogFunctions;
            this.familyTreeFunctions = familyTreeFunctions;
            this.clientArchiveFunctions = clientArchiveFunctions;
            this.userManager = userManager;
            this.clientStatusFunctions = clientStatusFunctions;
            this.clientStatusHistoryFunctions = clientStatusHistoryFunctions;
            this.clientApplicantFunctions = clientApplicantFunctions;
            this.clientDependentFunctions = clientDependentFunctions;
            this.clientListFunctions = clientListFunctions;
            this.clientTaskNotificationFunctions = clientTaskNotificationFunctions;
            this.context = context;
            this.folderDrive = Configuration.GetValue<string>("GoogleDriveFolder");
            this.googleDriveAPI = new GoogleDriveAPI.GoogleDriveAPI("MyProject-66223163b12b.json");
        }

        #region [PAGE]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Manage(int? id)
        {
            if (!ValidateUserClient(id)) return await Task.Run<IActionResult>(() => Forbid());

            return await Task.Run<IActionResult>(() => View(id));
        }
        public async Task<IActionResult> Log(int? id)
        {
            if (!ValidateUserClient(id)) return await Task.Run<IActionResult>(() => Forbid());

            return await Task.Run<IActionResult>(() => View(clientFunctions.GetDataViewModel(clientFunctions.GetDataByID(id))));
        }
        public IActionResult FamilyTree(int? id)
        {
            if (!id.HasValue) return Forbid();

            return View(id);
        }
        public IActionResult FamilyTree2(int? id)
        {
            if (!id.HasValue) return Forbid();

            return View(id);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Archives(int? id)
        {
            if (!id.HasValue) return Forbid();
            if (!ValidateUserClient(id)) return await Task.Run<IActionResult>(() => Forbid());

            return await Task.Run<IActionResult>(() => View(clientFunctions.GetDataViewModel(clientFunctions.GetDataByID(id))));
        }
        public async Task<IActionResult> ClientCalendar(int? clientId)
        {
            if (clientId.HasValue)
            {
                if (!ValidateUserClient(clientId)) return await Task.Run<IActionResult>(() => Forbid());

                return await Task.Run<IActionResult>(() => View(clientFunctions.GetDataViewModel(clientFunctions.GetDataByID(clientId))));
            }

            return await Task.Run<IActionResult>(() => View(null));
        }

        #endregion

        #region [ViewComponent]

        public IActionResult ClientIndexComponent(ViewComponentType type = ViewComponentType.List)
        {
            ViewBag.Responsibles = userFunctions.GetDataByRole("Administrator", "Salesman");
            ViewBag.Status = clientStatusFunctions.GetData().ToList();

            return ViewComponent(typeof(ViewComponents.Client.ClientIndexViewComponent), new { type });
        }

        public async Task<IActionResult> ClientManageComponent(int? id)
        {
            var client = new DTO.Client.ClientViewModel();
            if (id.HasValue) client = clientFunctions.GetDataViewModel(clientFunctions.GetDataByID(id));

            ViewBag.Responsibles = userFunctions.GetDataByRole("Administrator", "Salesman");
            ViewBag.Status = clientStatusFunctions.GetData().ToList();


            ViewData["CivilStatus"] = context.CivilStatus.ToList();

            return ViewComponent(typeof(ViewComponents.Client.ClientManageViewComponent), new { model = client });
        }

        public IActionResult ClientQuickManageComponent(int? id)
        {
            var client = new DTO.Client.ClientViewModel();
            if (id.HasValue) client = clientFunctions.GetDataViewModel(clientFunctions.GetDataByID(id));

            return ViewComponent(typeof(ViewComponents.Client.ClientQuickManageViewComponent), new { model = client });
        }

        public IActionResult ClientLogManageComponent(int? id, int? clientId)
        {
            var clientLog = new DTO.Client.ClientLogViewModel();
            if (id.HasValue) clientLog = clientLogFunctions.GetDataViewModel(clientLogFunctions.GetDataByID(id));
            if (clientId.HasValue) clientLog.ClientId = clientId.Value;

            return ViewComponent(typeof(ViewComponents.Client.ClientLogManageViewComponent), new { model = clientLog });
        }

        public IActionResult ClientLogComponent(int? clientId)
        {
            var clientLogs = new DTO.Client.ClientLogDetalhadoViewModel();
            if (clientId.HasValue) clientLogs = clientLogFunctions.GetDataDetalhada(clientId.Value, true);

            return ViewComponent(typeof(ViewComponents.Client.ClientLogViewComponent), new { model = clientLogs });
        }

        public IActionResult ClientFamilyTreeComponent(int? clientId)
        {
            if (!clientId.HasValue) return Forbid();

            return ViewComponent(typeof(ViewComponents.Client.FamilyTreeViewComponent), new { clientId });
        }

        [AllowAnonymous]
        public IActionResult ClientArchiveComponent(int? clientId, int? clientApplicantId)
        {
            if (!clientId.HasValue) return Forbid();

            ViewBag.ClientApplicantId = clientApplicantId;

            return ViewComponent(typeof(ViewComponents.Client.ClientArchivesViewComponent), new { clientId });
        }

        [AllowAnonymous]
        public IActionResult ClientArchiveManageComponent(int? clientId, int? clientApplicantId)
        {
            if (!clientId.HasValue) return Forbid();

            ViewBag.ClientApplicantId = clientApplicantId;

            return ViewComponent(typeof(ViewComponents.Client.ClientArchiveManageViewComponent), new { clientId });
        }

        public IActionResult ClientQuickViewViewComponent(int? clientId)
        {
            var client = new DTO.Client.ClientViewModel();
            if (clientId.HasValue) client = clientFunctions.GetDataViewModel(clientFunctions.GetDataByID(clientId));

            return ViewComponent(typeof(ViewComponents.Client.ClientQuickViewViewComponent), new { model = client });
        }

        public IActionResult ClientCalendarViewComponent(int? clientId, int? clientTaskId)
        {
            return ViewComponent(typeof(ViewComponents.Client.ClientCalendarViewComponent), new { clientId, clientTaskId });
        }

        public IActionResult ClientDependentsViewComponent(int clientId)
        {
            return ViewComponent(typeof(ViewComponents.Client.ClientDependentsViewComponent), new { clientId });
        }

        public IActionResult ClientDependentsManageViewComponent(int? clientDependentId, int clientId)
        {
            return ViewComponent(typeof(ViewComponents.Client.ClientDependentsManageViewComponent), new { clientDependentId, clientId });
        }
        #endregion

        #region [XHR]

        #region [Client]
        [HttpPost]
        [ActionName("List")]
        public async Task<IActionResult> List(DTO.Shared.DataTablesAjaxPostModel filter, int? responsibleId, int? clientStatusFilter)
        {
            string query = "IsDeleted = 0";
            List<SqlParameter> param = new List<SqlParameter>();

            if (User.IsInRole("Salesman"))
            {
                var userId = User.GetUserId();
                query += " AND ResponsibleId = @ResponsibleId";
                param.Add(new SqlParameter("@ResponsibleId", userId.Value));
            }
            //if (User.IsInRole("Client"))
            //{
            //    var userId = User.GetUserId();
            //    var client = clientFunctions.GetByUserId(userId.Value);
            //    if (client != null) {
            //        query += " AND ClientId = @ClientId";
            //        param.Add(new SqlParameter("@ClientId", client.ClientId));
            //    }
            //}

            else
            {
                if (responsibleId.HasValue)
                {
                    query += " AND ResponsibleId = @ResponsibleId";
                    param.Add(new SqlParameter("@ResponsibleId", responsibleId.Value));
                }
            }

            if (clientStatusFilter.HasValue)
            {
                if (clientStatusFilter.Value == -1) // Enviar Boas Vindas
                {
                    query += " AND FirstContacted = 0";
                }
                else
                {
                    query += " AND ClientStatusId = @ClientStatusId AND FirstContacted = 1";
                    param.Add(new SqlParameter("@ClientStatusId", clientStatusFilter.Value));
                }
            }

            IEnumerable<DTO.Client.ClientListViewModel> r = clientListFunctions.GetDataViewModel(this.clientListFunctions.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, query, param.ToArray()));

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = r
            }));
        }

        private JsonResult ValidateClientViewModel(DTO.Client.ClientViewModel oldModel, DTO.Client.ClientViewModel newModel)
        {
            if (!string.IsNullOrWhiteSpace(newModel.Cnpj) && clientFunctions.ExistCNPJ(newModel.Cnpj, newModel.ClientId))
                return Json(new FUNCTIONS.Shared.ReturnResult(0, "CNPJ já utilizado", true, "Cnpj"));

            if (!string.IsNullOrWhiteSpace(newModel.Cpf) && (clientFunctions.ExistCPF(newModel.Cpf, newModel.ClientId)))
                return Json(new FUNCTIONS.Shared.ReturnResult(0, "CPF já utilizado", true, "CPF"));

            if (!string.IsNullOrWhiteSpace(newModel.Telefone) && (clientFunctions.ExistPhone(newModel.Telefone, newModel.ClientId)))
                return Json(new FUNCTIONS.Shared.ReturnResult(0, "Telefone já utilizado", true, "Telefone"));

            if (!string.IsNullOrWhiteSpace(newModel.Celular) && (clientFunctions.ExistMobile(newModel.Celular, newModel.ClientId)))
                return Json(new FUNCTIONS.Shared.ReturnResult(0, "Celular já utilizado", true, "Celular"));

            if (oldModel == null && userFunctions.GetUserIdByEmail(newModel.Email).HasValue)
                return Json(new FUNCTIONS.Shared.ReturnResult(0, "E-mail já utilizado.", true, "Email"));

            if (oldModel != null && oldModel.Email != newModel.Email && userFunctions.GetUserIdByEmail(newModel.Email).HasValue)
                return Json(new FUNCTIONS.Shared.ReturnResult(0, "E-mail já utilizado.", true, "Email"));

            return null;
        }

        private async Task CreateOrUpdateClientUser(DTO.Client.ClientViewModel oldModel, DTO.Client.ClientViewModel newModel, TerraNostraIdentityDbContext.User user)
        {
            var clientUserId = userFunctions.GetUserIdByEmail(oldModel != null ? oldModel.Email : newModel.Email);
            if (clientUserId.HasValue)
            {
                if (userFunctions.IsInRole(clientUserId.Value, "Client"))
                {
                    userFunctions.UpdateBasicData(new DTO.User.UserViewModel
                    {
                        Email = newModel.Email,
                        FirstName = newModel.FirstName,
                        LastName = newModel.LastName,
                        PhoneNumber = newModel.Telefone,
                        UserId = clientUserId,

                    });

                    auditLogFunctions.Log("UserViewModel", clientUserId.Value, "UserId", FUNCTIONS.AuditLog.DBActionType.UPDATE, userFunctions.GetDataViewModel(userFunctions.GetDataByID(clientUserId)), user.Id);
                }
            }
            else
            {
                var clientUser = await userFunctions.CreateFromClient(newModel.ClientId.Value);
                userFunctions.ClearUserRoles(clientUser.UserId.Value);
                clientUser.Role = "CLIENT";
                userFunctions.AddUserToRole(clientUser.UserId.Value, clientUser.Role);

                auditLogFunctions.Log("UserViewModel", clientUser.UserId.Value, "UserId", FUNCTIONS.AuditLog.DBActionType.CREATE, clientUser, user.Id);
            }
        }

        public async Task SetStatusLog(int? oldClienteStatusId, int? newClienteStatusId, int clientId, int ownerId)
        {
            if (oldClienteStatusId != newClienteStatusId)
            {
                DB.ClientStatus oldClienteStatus = oldClienteStatusId.HasValue ? clientStatusFunctions.GetDataByID(oldClienteStatusId.Value) : null;
                DB.ClientStatus newClienteStatus = newClienteStatusId.HasValue ? clientStatusFunctions.GetDataByID(newClienteStatusId.Value) : null;

                var oldStatusName = oldClienteStatus == null ? "-" : oldClienteStatus.Name;
                var newStatusName = newClienteStatus == null ? "-" : newClienteStatus.Name;

                var clientLog = new ClientLogViewModel
                {
                    ClientId = clientId,
                    Message = $"Status foi alterado de \"{oldStatusName}\" para \"{newStatusName}\".",
                    Title = "Status alterado",
                    PlainText = $"Status foi alterado de \"{oldStatusName}\" para \"{newStatusName}\".",
                    UserId = ownerId
                };

                clientLog.ClientLogId = clientLogFunctions.Create(clientLog);

                if (oldClienteStatus.ClientStatusId != newClienteStatus.ClientStatusId)
                    clientStatusHistoryFunctions.Create(clientId, newClienteStatus.ClientStatusId);
            }
        }

        public async Task SetResponsibleLog(int? oldResponsibleId, int? newResponsibleId, int clientId, int ownerId)
        {
            if (oldResponsibleId != newResponsibleId)
            {
                if (newResponsibleId.HasValue)
                {
                    var responsible = userFunctions.GetDataByID(newResponsibleId.Value);
                    clientLogFunctions.Create(new ClientLogViewModel
                    {
                        ClientId = clientId,
                        Message = $"Usuário \"{responsible.FirstName} {responsible.LastName}\" foi definido como responsável.",
                        Title = "Novo responsável adicionado",
                        PlainText = $"Usuário \"{responsible.FirstName} {responsible.LastName}\" foi definido como responsável.",
                        UserId = ownerId,
                    });
                }
                else
                {
                    var responsible = userFunctions.GetDataByID(oldResponsibleId.Value);
                    clientLogFunctions.Create(new ClientLogViewModel
                    {
                        ClientId = clientId,
                        Message = $"Usuário \"{responsible.FirstName} {responsible.LastName}\" foi removido como responsável e nenhum outro usuário foi inserido no lugar.",
                        Title = "Responsável removido",
                        PlainText = $"Usuário \"{responsible.FirstName} {responsible.LastName}\" foi removido como responsável e nenhum outro usuário foi inserido no lugar.",
                        UserId = ownerId
                    });
                }
            }
        }

        [HttpPost]
        [ActionName("Manage")]
        public async Task<IActionResult> _Manage(DTO.Client.ClientViewModel model)
        {
            if (!User.ClientCanAccessEdition()) return Forbid();

            // VARIAVEIS DE APOIO
            var user = await userManager.GetUserAsync(User);
            ClientViewModel oldModel = model.ClientId.HasValue ? clientFunctions.GetDataViewModel(clientFunctions.GetDataByID(model.ClientId)) : null;

            // 1. VALIDAR O MODEL QUE VEM DA VIEW
            var validateClientViewModel = clientFunctions.ValidateClientViewModel(model);
            if (validateClientViewModel.HasError) return Json(validateClientViewModel);

            // 2. REGRAS DE NEGOCIO
            if (User.IsInRole("Salesman")) model.ResponsibleId = user.Id;
            userFunctions.UpdateLastSaleDate(model.ClientId, model.ResponsibleId);

            // 3. SALVAR CLIENTE E AUDITLOG
            model.CreatorUserId = user.Id;
            model.ClientId = clientFunctions.CreateOrUpdate(model);
            auditLogFunctions.Log("ClientViewModel", model.ClientId.Value, "ClientId", oldModel != null ? FUNCTIONS.AuditLog.DBActionType.CREATE : FUNCTIONS.AuditLog.DBActionType.UPDATE, clientFunctions.GetDataViewModel(clientFunctions.GetDataByID(model.ClientId)), user.Id);

            // 4. SALVAR INFORMACOES DO USUARIO/CLIENTE
            await CreateOrUpdateClientUser(oldModel, model, user);

            // 5. SALVAR NO HISTORICO DO CLIENTE
            await SetStatusLog(oldModel?.ClientStatusId, model.ClientStatusId, model.ClientId.Value, user.Id);
            await SetResponsibleLog(oldModel?.ResponsibleId, model.ResponsibleId, model.ClientId.Value, user.Id);

            return Json(new FUNCTIONS.Shared.ReturnResult(model.ClientId.Value, string.Empty, false));
        }
        [HttpPost]
        [ActionName("QuickManage")]
        public async Task<IActionResult> QuickManage(DTO.Client.ClientViewModel model)
        {
            if (!User.ClientCanAccessEdition()) return Forbid();

            var oldEmail = model.Email;

            FUNCTIONS.AuditLog.DBActionType dbActionType;
            if (model.ClientId.HasValue)
            {
                dbActionType = FUNCTIONS.AuditLog.DBActionType.UPDATE;
                var oldModel = clientFunctions.GetDataByID(model.ClientId);
                oldEmail = oldModel.Email;
            }
            else dbActionType = FUNCTIONS.AuditLog.DBActionType.CREATE;

            if ((dbActionType == FUNCTIONS.AuditLog.DBActionType.UPDATE && oldEmail != model.Email && userFunctions.GetUserIdByEmail(model.Email).HasValue) ||
                dbActionType == FUNCTIONS.AuditLog.DBActionType.CREATE && userFunctions.GetUserIdByEmail(model.Email).HasValue)//verifica se o novo email ja é usado
            {
                return Json(new FUNCTIONS.Shared.ReturnResult(0, "E-mail já utilizado.", true, "Email"));
            }
            model.ClientId = clientFunctions.CreateOrUpdate(model);

            var user = await userManager.GetUserAsync(User);

            var clientUserId = userFunctions.GetUserIdByEmail(oldEmail);
            var newUser = new DTO.User.UserViewModel();
            if (clientUserId.HasValue)
            {
                if (userFunctions.IsInRole(clientUserId.Value, "Client"))
                {
                    //FUNCTIONS.Utils.StringUtils.GetName(model.Contact, out string firstName, out string lastName);

                    newUser = new DTO.User.UserViewModel
                    {
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        PhoneNumber = model.Telefone,
                        UserId = clientUserId
                    };

                    userFunctions.UpdateBasicData(newUser);
                    auditLogFunctions.Log("UserViewModel", clientUserId.Value, "UserId", FUNCTIONS.AuditLog.DBActionType.UPDATE, userFunctions.GetDataViewModel(userFunctions.GetDataByID(clientUserId)), user.Id);
                }
            }
            else
            {
                newUser = userFunctions.CreateFromClient(model.ClientId.Value).Result;

                userFunctions.ClearUserRoles(newUser.UserId.Value);
                newUser.Role = "CLIENT";
                userFunctions.AddUserToRole(newUser.UserId.Value, newUser.Role);

                auditLogFunctions.Log("UserViewModel", newUser.UserId.Value, "UserId", FUNCTIONS.AuditLog.DBActionType.CREATE, newUser, user.Id);
            }

            var clientViewModel = clientFunctions.GetDataViewModel(clientFunctions.GetDataByID(model.ClientId));

            auditLogFunctions.Log("ClientViewModel", model.ClientId.Value, "ClientId", dbActionType, clientViewModel, user.Id);

            return Json(new FUNCTIONS.Shared.ReturnResult(model.ClientId.Value, "", false, new { firstName = newUser.FirstName, lastName = newUser.LastName, userId = newUser.UserId }));
        }
        [HttpPost]
        [ActionName("RemoveClient")]
        public async Task<IActionResult> RemoveClient(int id)
        {
            if (!User.ClientCanAccessEdition()) return Forbid();

            if (!clientFunctions.Exists(id)) return Json(new FUNCTIONS.Shared.ReturnResult(0, "Cliente não encontrada para excluir.", true));

            var user = await userManager.GetUserAsync(User);

            var client = clientFunctions.GetDataByID(id);
            int? clientUserId = null;

            if (userFunctions.ExistEmail(client.Email))
                clientUserId = userFunctions.GetUserIdByEmail(client.Email);

            clientFunctions.Delete(id, user.Id);

            if (clientUserId.HasValue && userFunctions.IsInRole(clientUserId.Value, "Client"))
            {
                userFunctions.Delete(clientUserId);
                auditLogFunctions.Log("UserViewModel", clientUserId.Value, "UserId", FUNCTIONS.AuditLog.DBActionType.DELETE, userFunctions.GetDataViewModel(userFunctions.GetDataByID(clientUserId)), user.Id, "Exclusão");
            }

            auditLogFunctions.Log("ClientViewModel", id, "ClientId", FUNCTIONS.AuditLog.DBActionType.DELETE, clientFunctions.GetDataViewModel(clientFunctions.GetDataByID(id)), user.Id, "Exclusão");

            return Json(new FUNCTIONS.Shared.ReturnResult(0, "Cliente excluido com sucesso!", false));
        }
        [HttpPost]
        [ActionName("SendFirstContact")]
        public async Task<IActionResult> SendFirstContact(int? responsibleId, int clientId, string message, string subject, string plainText)
        {
            if (!User.ClientCanAccessEdition()) return Forbid();

            if (!clientFunctions.Exists(clientId)) return Json(new FUNCTIONS.Shared.ReturnResult(0, "Cliente não encontrado para enviar 'Boas Vindas'.", true));
            var client = clientFunctions.GetDataByID(clientId);

            if (client.FirstContacted.HasValue && client.FirstContacted.Value) return Json(new FUNCTIONS.Shared.ReturnResult(0, "Já foi enviado 'Boas Vindas' para este cliente.", true));

            TerraNostraIdentityDbContext.User user = null;
            if (User.IsInRole("Administrator") || User.IsInRole("Contact Manager"))
            {
                user = await userManager.FindByIdAsync(responsibleId.ToString());
            }
            else
                user = await userManager.GetUserAsync(User);

            //var user = await userManager.FindByIdAsync(responsibleId.ToString());

            await FUNCTIONS.Mail.MailFunctions.SendAsync(subject, message, "", new List<string> { client.Email }, null);

            clientFunctions.SendFirstContact(clientId, user.Id);
            auditLogFunctions.Log("ClientViewModel", clientId, "ClientId", FUNCTIONS.AuditLog.DBActionType.UPDATE, clientFunctions.GetDataViewModel(clientFunctions.GetDataByID(clientId)), user.Id, "Mensagem de boas vindas.");
            clientFunctions.SetResponsible(clientId, user.Id);
            auditLogFunctions.Log("ClientViewModel", clientId, "ClientId", FUNCTIONS.AuditLog.DBActionType.UPDATE, clientFunctions.GetDataViewModel(clientFunctions.GetDataByID(clientId)), user.Id, "Responsável atribuído.");

            var clientLogModel = new DTO.Client.ClientLogViewModel
            {
                ClientId = clientId,
                Message = message,
                Title = subject,
                UserId = user.Id,
                PlainText = plainText
            };

            clientLogModel.ClientLogId = clientLogFunctions.Create(clientLogModel);

            return Json(new FUNCTIONS.Shared.ReturnResult(0, "Mensagem enviada com sucesso!", false));
        }
        public IActionResult SaveResponsible(int clientId, int? responsibleId)
        {
            if (!User.ClientCanAccessEdition()) return Forbid();

            clientFunctions.SetResponsible(clientId, responsibleId);

            return Json(new { hasError = false, message = "Novo responsável atribuído." });
        }

        public async Task<IActionResult> SaveStatus(int clientId, int? statusId)
        {
            if (!User.ClientCanAccessEdition()) return Forbid();

            var user = await userManager.GetUserAsync(User);
            var client = clientFunctions.GetDataByID(clientId);

            DB.ClientStatus oldStatus = (client.ClientStatusId.HasValue) ? clientStatusFunctions.GetDataByID(client.ClientStatusId) : null;
            DB.ClientStatus status = (statusId.HasValue) ? clientStatusFunctions.GetDataByID(statusId) : null;

            clientFunctions.SetStatus(clientId, statusId);
            await SetStatusLog(client.ClientStatusId, statusId, clientId, user.Id);

            return Json(new { hasError = false, message = "Um novo status foi atríbuido para o cliente." });
        }


        #endregion

        #region [ClientLog]
        [HttpPost]
        public async Task<IActionResult> SaveClientLog(DTO.Client.ClientLogViewModel model)
        {
            if (!User.ClientCanAccessEdition()) return Forbid();

            if (model.ClientLogId.HasValue) return Json(new { hasError = true, message = "Não é possível atualizar os dados" });

            var user = await userManager.GetUserAsync(User);

            model.UserId = user.Id;

            model.ClientLogId = clientLogFunctions.Create(model);

            auditLogFunctions.Log("ClientLogViewModel", model.ClientLogId.Value, "ClientLogId", FUNCTIONS.AuditLog.DBActionType.CREATE, clientLogFunctions.GetDataViewModel(clientLogFunctions.GetDataByID(model.ClientLogId)), user.Id);

            return Json(new { hasError = false, message = "Item inserido com sucesso!" });
        }

        [HttpPost]
        public IActionResult DeleteClientLog(List<int> clientLogIds)
        {
            if (!User.ClientCanAccessEdition()) return Forbid();

            try
            {
                foreach (var item in clientLogIds)
                {
                    clientLogFunctions.Delete(item);
                }
                return Json(new { hasError = false, message = "Itens excluídos com sucesso!" });
            }
            catch
            {
                return Json(new { hasError = true, message = "Houve um erro ao excluir os itens." });
            }

        }
        #endregion

        #region [FamilyTree]

        [HttpPost]
        public IActionResult GetProductTypeModelHierarchized(int clientId)
        {
            var itens = familyTreeFunctions.GetProductTypeModelHierarchized(clientId);

            return Json(itens);
        }


        [HttpPost]
        public IActionResult GetFamilyTree(int clientId)
        {
            List<FamilyTreeViewModel> itens = familyTreeFunctions.GetDataViewModel(familyTreeFunctions.GetDataByClientId(clientId, true));

            if (itens.Count == 0)
            {
                familyTreeFunctions.Create(familyTreeFunctions.GetDataViewModel(familyTreeFunctions.GetClientAsFamilyTreeItem(clientId)));
                itens = familyTreeFunctions.GetDataViewModel(familyTreeFunctions.GetDataByClientId(clientId, true));
            }
            else
            {
                var i = itens.FindIndex(x => x.IsClient);
                itens[i].Name = familyTreeFunctions.GetClientAsFamilyTreeItem(itens[i].ClientId).Name; //obtem os dados do cliente para mostrar atualizado o seu nome na árvore
            }

            //familyTreeFunctions.Setspids(ref itens);

            return Json(new { nodes = itens, tags = familyTreeFunctions.GetTags(itens) });
        }

        [HttpPost]
        public async Task<IActionResult> SaveFamilyTree(DTO.Client.FamilyTreeViewModel model, int position, int selectedNode)
        {
            if (!User.ClientCanAccessEdition()) return Forbid();

            FUNCTIONS.AuditLog.DBActionType dbAction;
            var user = await userManager.GetUserAsync(User);

            if (model.FamilyTreeId.HasValue) dbAction = FUNCTIONS.AuditLog.DBActionType.UPDATE;
            else dbAction = FUNCTIONS.AuditLog.DBActionType.CREATE;

            if (position == 2)
            {
                model.MarriedWith = selectedNode;
            }

            model.LastHandler = user.Id;

            model.FamilyTreeId = familyTreeFunctions.CreateOrUpdate(model);


            if (dbAction == FUNCTIONS.AuditLog.DBActionType.CREATE)
            {
                switch (position)
                {
                    case 0: // pai/mãe
                        var child = familyTreeFunctions.GetDataByID(selectedNode);
                        if (child.ParentId.HasValue) // se o filho ja tem um pai/mãe
                        {
                            //familyTreeFunctions.UpdateSecondParent(selectedNode, model.FamilyTreeId);
                            familyTreeFunctions.UpdatemarriedWith(model.FamilyTreeId.Value, child.ParentId);
                        }
                        else
                        {
                            familyTreeFunctions.UpdateParent(selectedNode, model.FamilyTreeId);
                        }
                        break;
                    case 1: // filhos
                        familyTreeFunctions.UpdateParent(model.FamilyTreeId.Value, selectedNode);
                        break;
                }
            }

            var data = familyTreeFunctions.GetDataViewModel(familyTreeFunctions.GetDataByID(model.FamilyTreeId));
            auditLogFunctions.Log("FamilyTreeViewModel", model.FamilyTreeId.Value, "FamilyTreeId", dbAction, data, user.Id);

            return Json(new { hasError = false, message = dbAction == FUNCTIONS.AuditLog.DBActionType.CREATE ? "Item inserido com sucesso!" : "Item atualizado com sucesso!", data });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFamilyTree(int familyTreeId)
        {
            if (!User.ClientCanAccessEdition()) return Forbid();

            var user = await userManager.GetUserAsync(User);
            var item = familyTreeFunctions.GetDataByID(familyTreeId);
            if (item.IsClient) return Json(new { hasError = true, message = "Não é possível excluir o próprio cliente." });

            familyTreeFunctions.Delete(familyTreeId, user.Id);

            return Json(new { hasError = false, message = "Item excluído com sucesso!" });
        }
        #endregion

        #region [Archives]

        [HttpPost]
        [ActionName("ListArchives")]
        [AllowAnonymous]
        public async Task<IActionResult> ListArchives(DTO.Shared.DataTablesAjaxPostModel filter, int? ownerId, int? clientApplicantId)
        {
            int recordsTotal = 0;
            int recordsFiltered = 0;
            IEnumerable<DTO.Client.ClientArchiveViewModel> d;

            string query = "IsDeleted = 0";
            List<SqlParameter> param = new List<SqlParameter>();

            if (ownerId.HasValue)
            {
                query += " AND ClientId = @ClientId";
                param.Add(new SqlParameter("@ClientId", ownerId));
            }

            if (clientApplicantId.HasValue)
            {
                query += " AND ClientApplicantId = @ClientApplicantId";
                param.Add(new SqlParameter("@ClientApplicantId", clientApplicantId));
            }

            if (ownerId.HasValue)
                d = clientArchiveFunctions.GetDataViewModel(clientArchiveFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, query, param.ToArray())).ToList();
            else
                d = clientArchiveFunctions.GetDataViewModel(clientArchiveFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered)).ToList();

            foreach (var _d in d)
                _d.IsImage = IsImage(_d.ContentType);

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            }));

        }

        public bool IsImage(string contentType)
        {
            if (GetImageTypes().Contains(contentType))
                return true;

            return false;
        }

        public List<string> GetImageTypes()
        {
            var l = new List<string>();

            l.Add("image/jpeg");
            l.Add("image/jpg");
            l.Add("image/png");
            l.Add("image/bmp");
            l.Add("image/gif");
            l.Add("image/x-icon");
            l.Add("image/svg+xml");
            l.Add("image/tiff");

            return l;
        }

        [AllowAnonymous]
        public IActionResult GetAttachment(int id)
        {
            var clientArchive = clientArchiveFunctions.GetDataByID(id);

            if (clientArchive == null)
                return NotFound();

            var file = this.googleDriveAPI.GetFile(clientArchive.FilePath);

            return File(file, clientArchive.ContentType, clientArchive.FileName);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ManageArchive([FromForm] DTO.Client.ClientArchiveViewModel model)
        {
            try
            {
                if (!User.ClientCanAccessEdition()) return Forbid();

                var anexo = Request.Form.Files.SingleOrDefault(x => x.Name.Equals("file"));

                bool validSize = anexo.Length <= 2097152 && anexo.Length > 0;
                bool validAttachment = (anexo != null && validSize);

                if (!validAttachment && anexo.FileName != "")
                {
                    if (!validSize)
                    {
                        return Json(-1);
                    }
                    if (anexo.FileName != "")
                    {
                        return Json(-2);
                    }
                }

                var client = clientFunctions.GetDataViewModel(clientFunctions.GetDataByID(model.ClientId));

                var cnpj = client.ClientDocument.CNPJOrCPFmask();

            var folder = client.ClientId?.ToString();//client.ClientName + (string.IsNullOrWhiteSpace(cnpj) ? "" : $"({cnpj})");

                var folderId = this.googleDriveAPI.GetFolderIdByName(folder, this.folderDrive);
                if (folderId == null)
                    folderId = this.googleDriveAPI.CreateFolder(folder, this.folderDrive);

                var fileId = this.googleDriveAPI.CreateFile(anexo.FileName, folderId, anexo.OpenReadStream(), anexo.ContentType);
                var associatedAttachment = clientArchiveFunctions.GetClientArchiveFromIFormFile(model.ClientId, anexo, fileId);

                associatedAttachment.Name = model.Name;
                associatedAttachment.ClientApplicantId = model.ClientApplicantId;

                int associatedAttachmentId = clientArchiveFunctions.Create(associatedAttachment);

                var user = await userManager.GetUserAsync(User);
                var clientLog = new ClientLogViewModel
                {
                    ClientId = model.ClientId,
                    Message = $"Arquivo \"{model.Name}\" ({model.Length / 1000000} MB) foi adicionado" + (model.ClientApplicantId.HasValue ? $" para o requerente { clientApplicantFunctions.GetDataByID(model.ClientApplicantId).FullName }." : "."),
                    Title = "Novo arquivo " + (model.ClientApplicantId.HasValue ? "para requerente" : "") + " adicionado",
                    PlainText = $"Arquivo \"{model.Name}\" ({model.Length / 1000000} MB) foi adicionado" + (model.ClientApplicantId.HasValue ? $" para o requerente { clientApplicantFunctions.GetDataByID(model.ClientApplicantId).FullName }." : "."),
                    UserId = user.Id,
                };

                clientLogFunctions.Create(clientLog);

                return Json(model.ClientArchiveId);
            }
            catch (Exception exception)
            {
                throw new Exception("Erro ao fazer upload do arquivo.");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RemoveAttachment(int? id)
        {
            if (!User.ClientCanAccessEdition()) return Forbid();

            if (!id.HasValue) return Json(false);

            var item = this.clientArchiveFunctions.GetDataByID(id.Value);

            this.googleDriveAPI.RemoveFile(item.FilePath);

            var user = await userManager.GetUserAsync(User);
            var clientArchive = this.clientArchiveFunctions.GetDataByID(id.Value);

            var clientLog = new ClientLogViewModel
            {
                ClientId = clientArchive.ClientId,
                Message = $"Arquivo \"{clientArchive.Name}\" ({clientArchive.Length / 1000000} MB) foi removido" + (clientArchive.ClientApplicantId.HasValue ? $" do requerente { clientApplicantFunctions.GetDataByID(clientArchive.ClientApplicantId).FullName }." : "."),
                Title = "Arquivo " + (clientArchive.ClientApplicantId.HasValue ? "de requerente" : "") + " removido",
                PlainText = $"Arquivo \"{clientArchive.Name}\" ({clientArchive.Length / 1000000} MB) foi removido" + (clientArchive.ClientApplicantId.HasValue ? $" do requerente { clientApplicantFunctions.GetDataByID(clientArchive.ClientApplicantId).FullName }." : "."),
                UserId = user.Id,
            };

            clientLogFunctions.Create(clientLog);

            this.clientArchiveFunctions.Delete(id.Value);

            return Json(true);
        }
        #endregion

        #region [Calendar]
        public async Task<IActionResult> CreateEventCalendar(ClientCalendarViewModel model, bool getAllClients)
        {
            if (!User.ClientCanAccessEdition()) return Forbid();

            var user = await userManager.GetUserAsync(User);
            model.UserId = user.Id;

            clientCalendarFunctions.CheckNoticeDate(model); //se trocar a data de notificação a variavel Notified volta para falso

            var clientTaskId = clientCalendarFunctions.CreateOrUpdate(model);

            if (model.ClientTaskId.HasValue)
            {
                var r = await _GetCalendarData(model.ClientId, null, getAllClients);
                return await Task.Run(() => Json(r));
            }
            else
            {
                model.ClientTaskId = clientTaskId;
                return Json(clientCalendarFunctions.GetFullCallendarViewModel(model, null, null, getAllClients));
            }

        }

        public async Task<IActionResult> GetCalendarData(int? clientId, int? clientTaskId, bool showAll)
        {
            var r = await _GetCalendarData(clientId, clientTaskId, showAll);
            return await Task.Run(() => Json(r));
        }

        public async Task<List<FullCallendarViewModel>> _GetCalendarData(int? clientId, int? clientTaskId = null, bool showAll = false)
        {
            var user = await userManager.GetUserAsync(User);

            return clientCalendarFunctions.GetFullCallendarViewModel(
                    !showAll ? clientCalendarFunctions.GetDataViewModel(clientCalendarFunctions.GetDataByClientId(clientId.Value)) :
                    User.IsInRole("Salesman") ? clientCalendarFunctions.GetDataByClientResponsibleId(user.Id) :
                    clientCalendarFunctions.GetDataViewModel(clientCalendarFunctions.GetData(x => !x.IsDeleted)),
                    "", clientTaskId, showAll);
        }

        public async Task<IActionResult> RemoveCalendarItem(int clientTaskId, int clientId, bool getAllClients)
        {
            if (!User.ClientCanAccessEdition()) return Forbid();

            var user = await userManager.GetUserAsync(User);

            clientCalendarFunctions.Delete(clientTaskId, user.Id);

            var r = await _GetCalendarData(clientId, null, getAllClients);
            return Json(r);
        }
        #endregion

        #region [Dependent]

        [HttpPost]
        public async Task<IActionResult> ManageDependent(DTO.Client.ClientDependentViewModel model)
        {
            if (!User.ClientCanAccessEdition()) return Forbid();

            // VARIAVEIS DE APOIO
            var user = await userManager.GetUserAsync(User);
            ClientDependentViewModel oldModel = model.ClientDependentId.HasValue ? clientDependentFunctions.GetDataViewModel(clientDependentFunctions.GetDataByID(model.ClientDependentId)) : null;

            // 1. VALIDAR O MODEL QUE VEM DA VIEW
            //var validateClientDependentViewModelJson = ValidateClientDependentViewModel(oldModel, model);
            //if (validateClientDependentViewModelJson != null) return validateClientDependentViewModelJson;

            // 2. SALVAR DEPENDENTE E AUDITLOG
            model.LastHandler = user.Id;
            model.ClientDependentId = clientDependentFunctions.CreateOrUpdate(model);
            auditLogFunctions.Log("ClientDependentViewModel", model.ClientDependentId.Value, "ClientDependentId", oldModel == null ? FUNCTIONS.AuditLog.DBActionType.CREATE : FUNCTIONS.AuditLog.DBActionType.UPDATE, clientDependentFunctions.GetDataViewModel(clientDependentFunctions.GetDataByID(model.ClientDependentId)), user.Id);

            // 4. SALVAR NO HISTORICO DO CLIENTE
            SetDependentLog(oldModel == null, model.ClientDependentId.Value, model.ClientId, user.Id);

            return await Task.Run<IActionResult>(() => Json(new FUNCTIONS.Shared.ReturnResult(model.ClientDependentId.Value, string.Empty, false)));
        }

        private JsonResult ValidateClientDependentViewModel(DTO.Client.ClientDependentViewModel oldModel, DTO.Client.ClientDependentViewModel newModel)
        {
            if (!string.IsNullOrWhiteSpace(newModel.Cpf) && (clientFunctions.ExistCPF(newModel.Cpf, null) || clientDependentFunctions.ExistCPF(newModel.Cpf, newModel.ClientDependentId)))
                return Json(new FUNCTIONS.Shared.ReturnResult(0, "CPF já utilizado", true, "CPF"));
            if (oldModel == null && userFunctions.GetUserIdByEmail(newModel.Email).HasValue)
                return Json(new FUNCTIONS.Shared.ReturnResult(0, "E-mail já utilizado.", true, "Email"));
            if (oldModel != null && oldModel.Email != newModel.Email && userFunctions.GetUserIdByEmail(newModel.Email).HasValue)
                return Json(new FUNCTIONS.Shared.ReturnResult(0, "E-mail já utilizado.", true, "Email"));

            return null;
        }

        public void SetDependentLog(bool creation, int clientDependentId, int clientId, int ownerId, bool deleted = false)
        {
            var clientDependent = clientDependentFunctions.GetDataByID(clientDependentId);

            if (deleted)
            {
                clientLogFunctions.Create(new ClientLogViewModel
                {
                    ClientId = clientId,
                    Message = $"Dependente <b>{clientDependent.FirstName} {clientDependent.LastName}</b> foi removido.",
                    Title = "Dependente Removido",
                    PlainText = $"Dependente {clientDependent.FirstName} {clientDependent.LastName} foi removido.",
                    UserId = ownerId,
                });
            }
            else if (creation)
            {
                clientLogFunctions.Create(new ClientLogViewModel
                {
                    ClientId = clientId,
                    Message = $"Dependente <b>{clientDependent.FirstName} {clientDependent.LastName}</b> foi incluído.",
                    Title = "Novo Dependente",
                    PlainText = $"Dependente {clientDependent.FirstName} {clientDependent.LastName} foi incluído.",
                    UserId = ownerId,
                });
            }
            else
            {
                clientLogFunctions.Create(new ClientLogViewModel
                {
                    ClientId = clientId,
                    Message = $"Dependente <b>{clientDependent.FirstName} {clientDependent.LastName}</b> teve seus dados atualizados.",
                    Title = "Dependente Atualizado",
                    PlainText = $"Dependente {clientDependent.FirstName} {clientDependent.LastName} teve seus dados atualizados.",
                    UserId = ownerId,
                });
            }
        }


        public async Task<IActionResult> RemoveClientDependent(int clientDependentId)
        {
            if (!User.ClientCanAccessEdition()) return Forbid();

            // 1. VARIAVEIS DE APOIO
            var user = await userManager.GetUserAsync(User);

            // 2. REMOVER DEPENDENTE
            clientDependentFunctions.Delete(clientDependentId, user.Id);

            //3. SALVAR LOG
            var dependent = clientDependentFunctions.GetDataViewModel(clientDependentFunctions.GetDataByID(clientDependentId));
            auditLogFunctions.Log("ClientDependentViewModel", clientDependentId, "ClientDependentId", FUNCTIONS.AuditLog.DBActionType.DELETE, dependent, user.Id);

            // 3. SALVAR NO HISTORICO DO CLIENTE
            SetDependentLog(false, clientDependentId, dependent.ClientId, user.Id, true);

            return Json(new FUNCTIONS.Shared.ReturnResult(0, "Dependente removido com sucesso!", false));
        }
        #endregion

        #region [ClientTaskNotification]
        public async Task<IActionResult> GetNotifications()
        {
            if (!User.Identity.IsAuthenticated) return await Task.Run<IActionResult>(() => Json(null));

            int? responsibleId = null;
            if (User.IsInRole("Salesman"))
            {
                responsibleId = User.GetUserId().Value;
            }

            var calendarNoticeEvents = clientTaskNotificationFunctions.GetNotifications(User.GetUserId().Value);
            var calendarTaskEvents = clientCalendarFunctions.GetTodayTask(responsibleId);

            return await Task.Run<IActionResult>(() => Json(new
            {
                calendarNoticeEvents,
                calendarTaskEvents,
                totalEvents = calendarNoticeEvents.Count() + calendarTaskEvents.Count()
            }));
        }

        public async Task<IActionResult> GetClientTask(int clientTaskId, int? clientTaskNotificationId)
        {
            if (!User.Identity.IsAuthenticated) return await Task.Run<IActionResult>(() => Json(null));
            var clientTask = clientCalendarFunctions.GetDataByID(clientTaskId);

            if (User.IsInRole("Salesman"))
            {
                var userId = User.GetUserId().Value;
                var client = clientFunctions.GetDataByID(clientTask.ClientId);
                if (userId != client.ResponsibleId) return await Task.Run<IActionResult>(() => Forbid());
            }

            if (clientTaskNotificationId.HasValue) clientTaskNotificationFunctions.Readed(clientTaskNotificationId.Value);


            return await Task.Run<IActionResult>(() => Json(clientCalendarFunctions.GetDataViewModel(clientTask)));
        }

        public async Task<IActionResult> ReadClientTask(int clientId, int? clientTaskNotificationId)
        {
            if (!ValidateUserClient(clientId)) return await Task.Run<IActionResult>(() => Forbid());

            if (clientTaskNotificationId.HasValue) clientTaskNotificationFunctions.Readed(clientTaskNotificationId.Value);

            return await Task.Run<IActionResult>(() => RedirectToAction("ClientCalendar", new { clientId }));
        }
        #endregion

        #endregion

        #region [Shared]
        public bool ValidateUserClient(int? clientId)
        {
            if (User.IsInRole("Salesman") && clientId.HasValue)
            {
                var client = clientFunctions.GetDataByID(clientId);
                if (client.ResponsibleId != User.GetUserId().Value)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion
    }
}