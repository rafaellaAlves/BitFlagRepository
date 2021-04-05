using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DTO;
using Web.Utils;
using System.Data.SqlClient;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        private readonly FUNCTIONS.User.UserFunctions userFunctions;
        private readonly FUNCTIONS.User.UserListViewFunctions userListViewFunctions;
        private readonly FUNCTIONS.Role.RoleFunctions roleFunctions;
        private readonly FUNCTIONS.AuditLog.AuditLogFunctions auditLogFunctions;
        private readonly FUNCTIONS.Client.ClientFunctions clientFunctions;
        private readonly UserManager<TerraNostraIdentityDbContext.User> userManager;
        private readonly SignInManager<TerraNostraIdentityDbContext.User> signInManager;

        public UserController(FUNCTIONS.User.UserFunctions userFunctions, FUNCTIONS.User.UserListViewFunctions userListViewFunctions, FUNCTIONS.Role.RoleFunctions roleFunctions, FUNCTIONS.AuditLog.AuditLogFunctions auditLogFunctions, FUNCTIONS.Client.ClientFunctions clientFunctions, UserManager<TerraNostraIdentityDbContext.User> userManager, SignInManager<TerraNostraIdentityDbContext.User> signInManager)
        {
            this.userFunctions = userFunctions;
            this.userListViewFunctions = userListViewFunctions;
            this.roleFunctions = roleFunctions;
            this.auditLogFunctions = auditLogFunctions;
            this.clientFunctions = clientFunctions;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        #region [SHARED]
        public static string CreateUserFromClientMailMessage(DTO.User.UserViewModel user, string password)
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

        #region [PAGES]
        [Authorize(Roles = "Administrator")]
        public IActionResult Index(string userType = "")
        {
            var userTypes = new List<UserType>();
            foreach (var item in userType.Split(";"))
            {
                if (int.TryParse(item, out int val))
                    userTypes.Add((UserType)val);
            }

            return View(userTypes);
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Manage(int? id)
        {
            return View(id);
        }
        #endregion

        #region [ViewComponents]
        [Authorize(Roles = "Administrator")]
        public IActionResult UserIndexComponent(string userType = "")
        {
            var userTypes = new List<UserType>();

            if (userType != null)
                foreach (var item in userType.Split(";"))
                    if (int.TryParse(item, out int val))
                        userTypes.Add((UserType)val);

            return ViewComponent(typeof(ViewComponents.User.UserIndexViewComponent), new { userTypes });
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult UserSelectedComponent(string userTypes = "")
        {
            var userType = new List<UserType>();

            foreach (var item in userTypes.Split(";"))
                if (int.TryParse(item, out int val))
                    userType.Add((UserType)val);

            return ViewComponent(typeof(ViewComponents.User.UserSelectedViewComponent), new { userTypes = userType });
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult UserManageComponent(int? id)
        {
            DTO.User.UserViewModel model = new DTO.User.UserViewModel();

            if (id.HasValue)
                model = userFunctions.GetDataViewModel(userFunctions.GetDataByID(id));

            ViewData["Roles"] = roleFunctions.GetData().ToList();
            return ViewComponent(typeof(ViewComponents.User.UserManageViewComponent), new { model = model });
        }

        [Authorize(Roles = "Administrator, Contact Manager, Administrative, Financial, Administrative Assistant, Salesman")]
        public IActionResult UserCalendarViewComponent(DateTime? startDate, DateTime? endDate)
        {
            return ViewComponent(typeof(ViewComponents.User.UserCalendarViewComponent), new { startDate, endDate });
        }
        #endregion

        #region [XHR]
        [HttpPost]
        [ActionName("Manage")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> _Manage(DTO.User.UserViewModel model)
        {
            if (userFunctions.ExistEmail(model.Email, model.UserId))
            {
                return Json(new { hasError = true, message = "Já existe um cadastro com esse email", selector = "_UserManageEmail" });

            }

            if (model.Password != null && model.Password.Length < 6 )
            {
                return Json(new { hasError = true, message = "A senha deve conter pelo menos 6 caracteres", selector = "_UserManagePassword" });
            }



            var _user = await userManager.GetUserAsync(User);
            model.LastHandler = _user.Id;
            FUNCTIONS.AuditLog.DBActionType actionType;
            if (model.UserId.HasValue) actionType = FUNCTIONS.AuditLog.DBActionType.UPDATE;
            else actionType = FUNCTIONS.AuditLog.DBActionType.CREATE;

            var userId = userFunctions.CreateOrUpdate(model);

            if (userId != 0)
            {
                userFunctions.ClearUserRoles(userId);
                userFunctions.AddUserToRole(userId, model.RoleNormalizedName);
                auditLogFunctions.Log("UserViewModel", userId, "UserId", actionType, userFunctions.GetDataViewModel(userFunctions.GetDataByID(userId)), _user.Id);
            }


            return Json(new { hasError = userId == 0, message = "Houve um problema ao salvar o cadastro, verifique seus dados", id = userId });
        }
        [HttpPost]
        [ActionName("List")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> List(DTO.Shared.DataTablesAjaxPostModel filter, [FromForm] string userType)
        {
            int recordsTotal = 0;
            int recordsFiltered = 0;
            var representanteId = roleFunctions.GetData(x => x.NormalizedName == "AGENT").Single().Id;
            var salesmanId = roleFunctions.GetData(x => x.NormalizedName == "SALESMAN").Single().Id;
            var AdministratorId = roleFunctions.GetData(x => x.NormalizedName == "ADMINISTRATOR").Single().Id;
            var clientId = roleFunctions.GetData(x => x.NormalizedName == "CLIENT").Single().Id;

            string query = "IsDeleted = 0";
            List<SqlParameter> param = new List<SqlParameter>();

            var userTypes = new List<UserType>();
            if (userType != null)
            {
                foreach (var item in userType.Split(";"))
                {
                    if (int.TryParse(item, out int val))
                        userTypes.Add((UserType)val);
                }
            }

            if (userTypes.Contains(UserType.NoAgent))
            {
                SqlParameterUtils.SetNewParameter(ref param, ref query, "RoleId", representanteId,"<>");
                SqlParameterUtils.SetNewParameter(ref param, ref query, "RoleId", clientId,"<>");
            }
            else if (userTypes.Contains(UserType.Agent))
            {
                SqlParameterUtils.SetNewParameter(ref param, ref query, "RoleId", representanteId, "=");
            }
            else if (userTypes.Contains(UserType.Client))
            {
                SqlParameterUtils.SetNewParameter(ref param, ref query, "RoleId", clientId, "=");
            }
            if (userTypes.Contains(UserType.Salesman) && userTypes.Contains(UserType.Administrator))
            {
                query += "AND (RoleId = @RoleId3 OR RoleId = @RoleId4)";
                param.Add(new SqlParameter("@RoleId3", salesmanId));
                param.Add(new SqlParameter("@RoleId4", AdministratorId));
            }
            else
            {
                if (userTypes.Contains(UserType.Salesman))
                {
                    SqlParameterUtils.SetNewParameter(ref param, ref query, "RoleId", salesmanId, "=");
                }

                if (userTypes.Contains(UserType.Administrator))
                {
                    SqlParameterUtils.SetNewParameter(ref param, ref query, "RoleId", AdministratorId);
                }
            }


            var d = this.userListViewFunctions.GetDataViewModel(this.userListViewFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, query, param.ToArray()).ToList());
            //if (agentOnly)
            //    d = d.Where(x => x.Role == "Representante").ToList();
            //else
            //    d = d.Where(x => x.Role != "Representante").ToList();

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            }));
        }

        [HttpPost]
        [ActionName("RemoveUser")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> RemoveUser(int id)
        {
            if (!userFunctions.Exists(id)) return Json(null);

            var _user = await userManager.GetUserAsync(User);

            userFunctions.Delete(id);
            auditLogFunctions.Log("UserViewModel", id, "UserId", FUNCTIONS.AuditLog.DBActionType.DELETE, userFunctions.GetDataViewModel(userFunctions.GetDataByID(id)), _user.Id, "Exclusão");
            return Json(true);
        }

        [HttpPost]
        [ActionName("CreateFromClient")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateFromClient(int clientId)
        {
            if (!clientFunctions.Exists(clientId)) return Json(new FUNCTIONS.Shared.ReturnResult(0, "Não foi possível encontrar o cliente.", true));

            var _user = await userManager.GetUserAsync(User);

            var user = userFunctions.CreateFromClient(clientId).Result;
            if (user == null) return Json(new FUNCTIONS.Shared.ReturnResult(0, "Houve um erro ao criar o usuário.", true));

            userFunctions.ClearUserRoles(user.UserId.Value);
            user.RoleNormalizedName = "CLIENT";
            userFunctions.AddUserToRole(user.UserId.Value, user.RoleNormalizedName);

            auditLogFunctions.Log("UserViewModel", user.UserId.Value, "UserId", FUNCTIONS.AuditLog.DBActionType.CREATE, userFunctions.GetDataViewModel(userFunctions.GetDataByID(user.UserId)), _user.Id);

            //await FUNCTIONS.Mail.MailFunctions.SendAsync("Criação de conta em Terra Nostra", CreateUserFromClientMailMessage(user, user.Password), "", new List<string> { user.Email }, null);
            return Json(new FUNCTIONS.Shared.ReturnResult(user.UserId.Value, "Usuário criado com sucesso!", false));
        }
        #endregion
    }
}