using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Identity;

namespace GLAS2Web.Controllers
{
    public class CompanyLawActionCommentManagementController : Controller
    {
        private readonly BLL.Company.CompanyLawActionCommentFunctions companyLawActionCommentFunctions;
        private readonly BLL.Company.CompanyLawActionFunctions companyLawActionFunctions;
        private readonly BLL.Company.CompanyLawFunctions companyLawFunctions;
        private readonly BLL.Company.CompanyFunctions companyFunctions;
        private readonly BLL.Law.LawFunctions lawFunctions;
        private readonly BLL.User.UserFunctions userFunctions;
        private readonly BLL.Mail.MailUtils mailUtils;
        private readonly UserManager<DAL.Identity.User> userManager;
        private readonly BLL.Mail.MailFunctions mailFunctions;

        public CompanyLawActionCommentManagementController(DAL.GLAS2Context context, UserManager<DAL.Identity.User> userManager, BLL.Mail.MailFunctions mailFunctions)
        {
            this.companyLawActionCommentFunctions = new BLL.Company.CompanyLawActionCommentFunctions(context);
            this.companyLawActionFunctions = new BLL.Company.CompanyLawActionFunctions(context);
            this.companyLawFunctions = new BLL.Company.CompanyLawFunctions(context);
            this.companyFunctions = new BLL.Company.CompanyFunctions(context);
            this.lawFunctions = new BLL.Law.LawFunctions(context);
            this.mailUtils = new BLL.Mail.MailUtils(context, userManager);
            this.userFunctions = new BLL.User.UserFunctions(context, userManager);
            this.userManager = userManager;
            this.mailFunctions = mailFunctions;
        }

        [HttpPost]
        [ActionName("List")]
        public IActionResult _List(DTO.Shared.DataTablesAjaxPostModel filter, int? CompanyLawActionId)
        {
            if (!CompanyLawActionId.HasValue)
                return Json(null);

            filter.columns.Add(new DTO.Shared.Column() { name = "CreatedDate", data = "CreatedDate" });
            filter.order.Add(new DTO.Shared.Order() { column = filter.columns.IndexOf(filter.columns.Single(x => x.name == "CreatedDate")), dir = "DESC" });

            int recordsTotal = 0;
            int recordsFiltered = 0;
            var d = this.companyLawActionCommentFunctions.GetDataViewModel(this.companyLawActionCommentFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, "CompanyLawActionId = @CompanyLawActionId AND IsDeleted = 0", new SqlParameter("@CompanyLawActionId", CompanyLawActionId)));// x => x.CompanyLawActionId == CompanyLawActionId && !x.IsDeleted));

            return Json(new
            {
                draw = filter.draw,
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            });
        }

        [HttpPost]
        [ActionName("Manage")]
        public async Task<IActionResult> _Manage([FromForm] DTO.Company.CompanyLawActionCommentViewModel model)
        {
            var user = await userManager.GetUserAsync(User);
            model.AuthorId = user.Id;

            int companyLawCommentId = companyLawActionCommentFunctions.CreateOrUpdate(model);

            var companyLawAction = companyLawActionFunctions.GetDataByID(model.CompanyLawActionId);
            var companyLawModel = companyLawFunctions.GetDataByID(companyLawAction.CompanyLawId);
            var lawViewModel = lawFunctions.GetDataViewModel(lawFunctions.GetDataByID(companyLawModel.LawId));
            var companyModel = companyFunctions.GetDataByID(companyLawModel.CompanyId);
            DAL.Identity.User compayLawResponsible = null;
            if (companyLawModel.ResponsibleId.HasValue) compayLawResponsible = userFunctions.GetDataByID(companyLawModel.ResponsibleId);

            var mailAddress = new List<string>();
            var userModels = new List<DTO.User.UserModel>();
            userModels = mailUtils.GetCompanyAdministrators(companyModel.CompanyId);
            var Responsible = new DTO.User.UserModel();
            Responsible = mailUtils.GetResponsibleInCompanyLawAction(model.CompanyLawActionId);
            if(Responsible != null) userModels.Add(Responsible);
            var Supervisor = new DTO.User.UserModel();
            Supervisor = mailUtils.GetSupervisorInCompanyLawAction(model.CompanyLawActionId);
            if (Supervisor != null) userModels.Add(Supervisor);
            if (userModels != null && userModels.Count > 0) mailAddress = mailUtils.UserModelsToMailAddress(userModels);
            if (compayLawResponsible != null && !string.IsNullOrWhiteSpace(compayLawResponsible.Email)) mailAddress.Add(compayLawResponsible.Email);

            if (mailAddress.Count > 0)
            {
                string htmlTable = "<table class='table-top-rounded' style='width:60%;' align='center'><tbody><tr><td style='text-align:center;'>" + lawViewModel.LawInfoForEmail + "</td></tr></tbody></table><table class='table-bottom-rounded' style='width:60%; margin-top: 5px;' align='center'><tbody><tr><td style='text-align:center;'>" + lawViewModel.Title + "</td></tr></tbody></table>";
                htmlTable += mailUtils.CompanyLawActionTable(model.CompanyLawActionId);
                htmlTable += mailUtils.CompanyLawActionCommentTable(model.CompanyLawActionId, companyLawCommentId);
                await mailFunctions.SendAsync("AÇÃO COMENTADA: " + companyModel.NomeFantasia + " - " + lawViewModel.LawInfoForEmail, htmlTable, mailAddress, companyLawModel.CompanyId, null);
            }

            return Json(companyLawCommentId);
        }

        [HttpPost]
        [ActionName("RemoveCompanyLawActionComment")]
        public IActionResult RemoveCompanyLawActionComment(int? companyLawActionCommentId)
        {
            if (!companyLawActionCommentId.HasValue) return Json(false);
            this.companyLawActionCommentFunctions.Delete(companyLawActionCommentId.Value);

            //var companyLawActionCommnetModel = companyLawActionCommentFunctions.GetDataByID(companyLawActionCommentId);
            //var companyLawActionModel = companyLawActionFunctions.GetDataByID(companyLawActionCommnetModel.CompanyLawActionId);
            //var companyLawModel = companyLawFunctions.GetDataByID(companyLawActionModel.CompanyLawId);
            //var lawViewModel = lawFunctions.GetDataViewModel(lawFunctions.GetDataByID(companyLawModel.LawId));
            //var companyModel = companyFunctions.GetDataByID(companyLawModel.CompanyId);

            //var userModels = new List<DTO.User.UserModel>();
            //userModels = mailUtils.GetCompanyAdminisAndSupervisors(companyLawModel.CompanyId);
            //var mailAddress = new List<string>();
            //if (userModels != null && userModels.Count > 0) mailAddress = mailUtils.UserModelsToMailAddress(userModels);

            //string htmlTable = "<table align='center' class='table-top-rounded' style='width:60%;'><tbody><tr><td style='text-align:center;'>" + lawViewModel.LawInfoForEmail + "</td></tr></table><table align='center' class='table-bottom-rounded' style='width:60%;'><tr><td style='text-align:center;'>" + lawViewModel.Title + "</td></tr></tbody></table>";
            //htmlTable += mailUtils.CompanyLawActionTable(companyLawActionModel.CompanyLawActionId);
            //htmlTable += mailUtils.CompanyLawActionCommentTable(companyLawActionModel.CompanyLawActionId, companyLawActionCommentId.Value);

            //await BLL.Mail.MailFunctions.SendAsync("AÇÃO EXCLUÍDA: " + companyModel.NomeFantasia + " - " + lawViewModel.LawInfoForEmail, htmlTable, mailAddress);

            return Json(true);
        }

    }
}