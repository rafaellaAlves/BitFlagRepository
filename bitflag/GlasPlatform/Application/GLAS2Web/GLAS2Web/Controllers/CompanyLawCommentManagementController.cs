using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace GLAS2Web.Controllers
{
    public class CompanyLawCommentManagement : Controller
    {
        private readonly BLL.Company.CompanyLawCommentFunctions companyLawCommentFunctions;
        private readonly BLL.Company.CompanyLawFunctions companyLawFunctions;
        private readonly BLL.Company.CompanyFunctions companyFunctions;
        private readonly BLL.Permission.CompanyUserRoleFunctions companyUserRoleFunctions;
        private readonly BLL.Law.LawFunctions lawFunctions;
        private readonly BLL.Mail.MailUtils mailUtils;
        private readonly BLL.User.UserFunctions userFunctions;
        private readonly UserManager<DAL.Identity.User> userManager;
        private readonly BLL.Mail.MailFunctions mailFunctions;

        public CompanyLawCommentManagement(DAL.GLAS2Context context, UserManager<DAL.Identity.User> userManager, RoleManager<DAL.Identity.Role> roleManager, BLL.Mail.MailFunctions mailFunctions)
        {
            this.companyLawCommentFunctions = new BLL.Company.CompanyLawCommentFunctions(context, userManager);
            this.companyLawFunctions = new BLL.Company.CompanyLawFunctions(context);
            this.companyFunctions = new BLL.Company.CompanyFunctions(context);
            this.lawFunctions = new BLL.Law.LawFunctions(context);
            this.mailUtils = new BLL.Mail.MailUtils(context, userManager);
            this.userFunctions = new BLL.User.UserFunctions(context, userManager);
            this.userManager = userManager;
            this.companyUserRoleFunctions = new BLL.Permission.CompanyUserRoleFunctions(context);
            this.mailFunctions = mailFunctions;
        }

        [HttpPost]
        [ActionName("List")]
        public IActionResult _List(DTO.Shared.DataTablesAjaxPostModel filter, int? companyLawId)
        {
            if (!companyLawId.HasValue)
                return Json(null);

            filter.columns.Add(new DTO.Shared.Column() { name = "CreatedDate", data = "CreatedDate" });
            filter.order.Add(new DTO.Shared.Order() { column = filter.columns.IndexOf(filter.columns.Single(x => x.name == "CreatedDate")), dir = "DESC" });

            int recordsTotal = 0;
            int recordsFiltered = 0;
            var d = this.companyLawCommentFunctions.GetDataViewModel(this.companyLawCommentFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, "CompanyLawId = @CompanyLawId AND IsDeleted = 0", new System.Data.SqlClient.SqlParameter("@CompanyLawId", companyLawId)));//x => x.CompanyLawId == companyLawId && !x.IsDeleted));

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
        public async Task<IActionResult> _Manage([FromForm] DTO.Company.CompanyLawCommentViewModel model)
        {
            //cliente: adm e pra si proprio
            //biotera: adm e user do cliente que esta copiado na ultima mensagem
            //mudou status: adm e user do cliente que esta copiado na ultima mensagem 

            var user = await userManager.GetUserAsync(User);
            model.AuthorId = user.Id;

            var comments = companyLawCommentFunctions.GetData().Where(x => x.CompanyLawId == model.CompanyLawId && (companyUserRoleFunctions.GetUserRole(x.AuthorId).Id == 7 || companyUserRoleFunctions.GetUserRole(x.AuthorId).Id == 8 || companyUserRoleFunctions.GetUserRole(x.AuthorId).Id == 9));
            int companyLawCommentId = companyLawCommentFunctions.CreateOrUpdate(model);

            var companyLawModel = companyLawFunctions.GetDataViewModel(companyLawFunctions.GetDataByID(model.CompanyLawId));
            var lawViewModel = lawFunctions.GetDataViewModel(lawFunctions.GetDataByID(companyLawModel.LawId));
            var companyModel = companyFunctions.GetDataByID(companyLawModel.CompanyId);
            DAL.Identity.User compayLawResponsible = null;
            if (companyLawModel.ResponsibleId.HasValue) compayLawResponsible = userFunctions.GetDataByID(companyLawModel.ResponsibleId);

            var userModels = new List<DTO.User.UserModel>();
            //userModels = mailUtils.GetCompanyAdminisAndSupervisors(companyLawModel.CompanyId);
            userModels = mailUtils.GetCompanyAdministrators(companyLawModel.CompanyId);
            var mailAddress = new List<string>();
            if (userModels != null && userModels.Count > 0) mailAddress = mailUtils.UserModelsToMailAddress(userModels);
            if (compayLawResponsible != null && !string.IsNullOrWhiteSpace(compayLawResponsible.Email)) mailAddress.Add(compayLawResponsible.Email);

            if (User.IsInRole(BLL.User.ProfileNames.Cliente))
                mailAddress.Add(user.Email);
            else if (User.IsInRole(BLL.User.ProfileNames.Biotera) && comments.Count() > 0)
            {
                var _user = userFunctions.GetDataByID(comments.Last().AuthorId);
                mailAddress.Add(_user.Email);
            }

            string htmlTable = mailUtils.MountHtmlLawTable(lawViewModel.LawInfoForEmail, companyLawModel, user.FullName);

            htmlTable += mailUtils.CompanyLawCommentTable(model.CompanyLawId, companyLawCommentId);

            await mailFunctions.SendAsync("NOVO COMENTÁRIO: " + companyModel.NomeFantasia + " - " + lawViewModel.LawInfoForEmail, htmlTable, mailAddress, companyModel.CompanyId);

            return Json(companyLawCommentId);
            //return RedirectToAction("Manage", new { id = companyID, saved = true });
        }

        [HttpPost]
        [ActionName("RemoveCompanyLawComment")]
        public IActionResult RemoveCompanyLawComment(int? companyLawCommentId)
        {
            if (!companyLawCommentId.HasValue) return Json(false);
            this.companyLawCommentFunctions.Delete(companyLawCommentId.Value);

            //var companyLawCommnetModel = companyLawCommentFunctions.GetDataByID(companyLawCommentId);
            //var companyLawModel = companyLawFunctions.GetDataByID(companyLawCommnetModel.CompanyLawId);
            //var lawViewModel = lawFunctions.GetDataViewModel(lawFunctions.GetDataByID(companyLawModel.LawId));
            //var companyModel = companyFunctions.GetDataByID(companyLawModel.CompanyId);

            //var userModels = new List<DTO.User.UserModel>();
            //userModels = mailUtils.GetCompanyAdminisAndSupervisors(companyLawModel.CompanyId);
            //var mailAddress = new List<string>();
            //if (userModels != null && userModels.Count > 0) mailAddress = mailUtils.UserModelsToMailAddress(userModels);

            //await BLL.Mail.MailFunctions.SendAsync("Um comentário foi removido de uma lei da unidade de negócio " + companyModel.NomeFantasia, lawViewModel.LawInfoForEmail + " associada a unidade de negócio: <b>" + companyModel.NomeFantasia + "</b> teve um comentário removido.", mailAddress);

            return Json(true);
        }
    }
}