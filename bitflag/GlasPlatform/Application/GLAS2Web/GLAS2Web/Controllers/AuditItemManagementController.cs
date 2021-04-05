using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GLAS2Web.Controllers
{
    public class AuditItemManagementController : Controller
    {
        private readonly DAL.GLAS2Context _context;
        private readonly BLL.Audit.AuditFunctions _auditFunctions;
        private readonly BLL.Audit.AuditItemFunctions _auditItemFunctions;
        private readonly BLL.Audit.AuditItemStatusFunctions _auditItemStatusFunctions;
        private readonly BLL.Company.CompanyLawFunctions companyLawFunctions;
        private readonly BLL.Company.CompanyFunctions companyFunctions;
        private readonly BLL.Law.LawFunctions lawFunctions;
        private readonly BLL.Mail.MailUtils mailUtils;
        private readonly BLL.User.UserFunctions userFunctions;
        private readonly UserManager<DAL.Identity.User> userManager;
        private readonly BLL.Mail.MailFunctions mailFunctions;

        public AuditItemManagementController(DAL.GLAS2Context context, UserManager<DAL.Identity.User> userManager, BLL.Mail.MailFunctions mailFunctions)
        {
            this._context = context;
            this._auditFunctions = new BLL.Audit.AuditFunctions(context);
            this._auditItemFunctions = new BLL.Audit.AuditItemFunctions(context);
            this._auditItemStatusFunctions = new BLL.Audit.AuditItemStatusFunctions(context);
            this.companyLawFunctions = new BLL.Company.CompanyLawFunctions(context);
            this.companyFunctions = new BLL.Company.CompanyFunctions(context);
            this.lawFunctions = new BLL.Law.LawFunctions(context);
            this.mailUtils = new BLL.Mail.MailUtils(context, userManager);
            this.userManager = userManager;
            this.userFunctions = new BLL.User.UserFunctions(context, userManager);
            this.mailFunctions = mailFunctions;
        }

        #region [ViewComponent]
        public IActionResult AuditItemListViewComponent(int? auditId)
        {
            if (!this._auditFunctions.Exists(auditId)) NotFound();

            return ViewComponent(typeof(ViewComponents.AuditItemManagement.AuditItemListViewComponent), new { auditId = auditId });
        }
        #endregion

        public async Task<IActionResult> ManageAjax(IEnumerable<DTO.Audit.AuditItemUpdateViewModel> model)
        {
            var company = companyFunctions.GetDataByID(model.First().CompanyId);

            foreach (var item in model)
            {
                var auditItem = this._auditItemFunctions.GetDataViewModel(this._auditItemFunctions.GetDataByID(item.AuditItemId));
                auditItem.Comments = item.Comments;
                auditItem.AuditItemStatusId = item.AuditItemStatusId;

                this._auditItemFunctions.CreateOrUpdate(auditItem);

                //salvamento da companyLaw
                var companyLaw = companyLawFunctions.GetDataByID(item.CompanyLawId);
                var companyLawViewModel = companyLawFunctions.GetDataViewModel(companyLaw);
                var lawViewModel = lawFunctions.GetDataViewModel(companyLawFunctions.GetLawByCompanyLawId(item.CompanyLawId));
                DAL.Identity.User responsible = null;
                if (companyLawViewModel.ResponsibleId.HasValue) responsible = userFunctions.GetDataByID(companyLawViewModel.ResponsibleId);

                var user = await userManager.GetUserAsync(User);
                string htmlTable = "";
                var userModels = new List<DTO.User.UserModel>();
                userModels = mailUtils.GetCompanyAdminisAndSupervisors(item.CompanyId);
                var mailAddress = new List<string>();
                if (userModels != null && userModels.Count > 0) mailAddress = mailUtils.UserModelsToMailAddress(userModels);
                if (responsible != null && !string.IsNullOrWhiteSpace(responsible.Email)) mailAddress.Add(responsible.Email);


                if (companyLaw.RenewDate != item.CompanyLawRenewDate)
                {
                    if (mailAddress.Count > 0)
                    {
                        htmlTable = mailUtils.MountHtmlLawTable(lawViewModel.LawInfoForEmail, companyLawViewModel, user.FullName);
                        htmlTable += "<br><table class='table-rounded' align='center' style='width:60%;'><tbody><tr><td style='text-align:center;'>DATA DE RENOVAÇÃO: " + item.CompanyLawRenewDate + "</td></tr></tbody></table>";
                        await mailFunctions.SendAsync("DATA DE RENOVAÇÃO ALTERADA: " + company.NomeFantasia + " - " + lawViewModel.LawInfoForEmail,
                            htmlTable, mailAddress, company.CompanyId, null);
                    }

                }
                if (companyLaw.WarningDate != item.CompanyLawWarningDate)
                {
                    if (mailAddress.Count > 0)
                    {
                        htmlTable = mailUtils.MountHtmlLawTable(lawViewModel.LawInfoForEmail, companyLawViewModel, user.FullName);
                        htmlTable += "<br><table class='table-rounded' align='center' style='width:60%;'><tbody><tr><td style='text-align:center;'>DATA DE AVISO: " + item.CompanyLawWarningDate + "</td></tr></tbody></table>";
                        await mailFunctions.SendAsync("DATA AVISO ALTERADA: " + company.NomeFantasia + " " + lawViewModel.LawInfoForEmail,
                            htmlTable, mailAddress, company.CompanyId, null);
                    }
                }

                if (companyLaw.RenewDate != item.CompanyLawRenewDate || companyLaw.WarningDate != item.CompanyLawWarningDate)
                {
                    companyLaw.RenewDate = item.CompanyLawRenewDate;
                    companyLaw.WarningDate = item.CompanyLawWarningDate;

                    companyLawFunctions.Update(companyLawFunctions.GetDataViewModel(companyLaw));
                }
            }

            return Json(true);
        }
    }
}