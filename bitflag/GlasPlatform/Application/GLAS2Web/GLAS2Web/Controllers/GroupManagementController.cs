using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DTO.Company;
using Microsoft.AspNetCore.Authorization;
using GLAS2Web.Security;
using Microsoft.AspNetCore.Identity;

namespace GLAS2Web.Controllers
{
    [AuthorizeRoles(BLL.User.ProfileNames.Administrator, BLL.User.ProfileNames.Master)]
    public class GroupManagementController : Controller
    {
        private readonly DAL.GLAS2Context context;
        private readonly BLL.Company.GroupFunctions groupFunctions;
        private readonly BLL.Company.CompanyGroupFunctions companyGroupFunctions;
        private readonly BLL.Company.CompanyFunctions companyFunctions;
        private readonly BLL.Company.CompanyLawFunctions companyLawFunctions;
        private readonly BLL.Law.LawApplicationTypeFunctions lawApplicationTypeFunctions;
        private readonly BLL.Law.LawConclusionStatusFunctions lawConclusionStatusFunctions;
        private readonly BLL.Mail.MailUtils mailUtils;
        private readonly BLL.Law.LawFunctions lawFunctions;
        private readonly UserManager<DAL.Identity.User> userManager;
        private readonly BLL.Mail.MailFunctions mailFunctions;

        public GroupManagementController(DAL.GLAS2Context context, UserManager<DAL.Identity.User> userManager, BLL.Mail.MailFunctions mailFunctions)
        {
            this.context = context;
            this.groupFunctions = new BLL.Company.GroupFunctions(context);
            this.companyGroupFunctions = new BLL.Company.CompanyGroupFunctions(context);
            this.companyFunctions = new BLL.Company.CompanyFunctions(context);
            this.companyLawFunctions = new BLL.Company.CompanyLawFunctions(context);
            this.lawApplicationTypeFunctions = new BLL.Law.LawApplicationTypeFunctions(context);
            this.lawConclusionStatusFunctions = new BLL.Law.LawConclusionStatusFunctions(context);
            this.mailUtils = new BLL.Mail.MailUtils(context, userManager);
            this.lawFunctions = new BLL.Law.LawFunctions(context);
            this.userManager = userManager;
            this.mailFunctions = mailFunctions;
        }

        public IActionResult Index()
        {
            ViewData["LawApplicableType"] = lawApplicationTypeFunctions.GetData();
            return View();
        }

        public IActionResult GetCompanies(int? parentId)
        {
            return Json(groupFunctions.GetCompanyViewModelInGroupRecursive(parentId));
        }

        [HttpPost]
        public IActionResult GetCompanyModelHierarchized(int? parentId)
        {
            return Json(new[] { this.groupFunctions.GetGroupModelHierarchized(parentId, true) });
        }

        [HttpPost]
        public IActionResult Manage(DTO.Company.GroupModel model)
        {
            int groupId = groupFunctions.CreateOrUpdate(model);
            model.GroupId = groupId;
            model.Company = null;

            return Json(model);
        }

        [HttpPost]
        public IActionResult Remove(DTO.Company.GroupModel model)
        {
            groupFunctions.Delete(model.GroupId);

            return Json(true);
        }

        [HttpPost]
        public IActionResult AddCompanyToGroup(int? companyId, int? groupId)
        {
            if (!companyId.HasValue) return Json(false);
            var company = companyFunctions.GetDataByID(companyId.Value);
            if (company == null) return Json(false);

            var companyGroupId = companyGroupFunctions.Create(new DTO.Company.CompanyGroupModel() { CompanyId = companyId.Value, GroupId = groupId });
            var groupModel = new GroupModel()
            {
                Name = company.RazaoSocial,
                GroupId = null,
                Company = companyFunctions.GetDataViewModel(company),
                CompanyGroupId = companyGroupId,
                Description = company.NomeFantasia,
                ParentId = groupId
            };

            return Json(groupModel);
        }

        [HttpPost]
        public IActionResult RemoveCompanyFromGroup(int companyGroupId)
        {
            companyGroupFunctions.Delete(companyGroupId);

            return Json(true);
        }

        [HttpPost]
        public async Task<IActionResult> AddLawToGroup(int? lawId, int? groupId, int? lawApplicableId)
        {
            if (!lawId.HasValue) return Json(-1);

            var notCompleted = lawConclusionStatusFunctions.GetDataFiltered(x => x.ExternalCode == "NOTCOMPLETED").First();
            var notApplicable = lawConclusionStatusFunctions.GetDataFiltered(x => x.ExternalCode == "NOTAPPLICABLE").First();
            var lawApplicable = lawApplicationTypeFunctions.GetDataByID(lawApplicableId);
            int count = 0;
            var lawViewModel = lawFunctions.GetDataViewModel(lawFunctions.GetDataByID(lawId.Value));

            foreach (var item in groupFunctions.GetCompanyViewModelInGroupRecursive(groupId))
            {
                if (companyLawFunctions.LawIsInCompany(lawId.Value, item.CompanyId.Value)) continue;

                int companyLawId = -1;
                if (lawApplicable.ExternalCode.ToUpper().Equals("KNOWLEDGE"))
                    companyLawFunctions.Create(new CompanyLawViewModel() { CompanyId = item.CompanyId.Value, LawId = lawId.Value, LawConclusionStatusId = notApplicable.LawConclusionStatusId, LawApplicationTypeId = lawApplicableId });
                else if (lawApplicable.ExternalCode.ToUpper().Equals("APPLICABLE"))
                    companyLawId = companyLawFunctions.Create(new CompanyLawViewModel() { CompanyId = item.CompanyId.Value, LawId = lawId.Value, LawConclusionStatusId = notCompleted.LawConclusionStatusId, LawApplicationTypeId = lawApplicableId });
                count++;

                var userModels = new List<DTO.User.UserModel>();
                userModels = mailUtils.GetCompanyAdministrators(item.CompanyId.Value);
                var mailAddress = new List<string>();
                if (userModels != null && userModels.Count > 0) mailAddress = mailUtils.UserModelsToMailAddress(userModels);

                var user = await this.userManager.GetUserAsync(User);
                var companyLawModel = companyLawFunctions.GetDataViewModel(companyLawFunctions.GetDataByID(companyLawId));
                if (companyLawModel.IsActive && !companyLawModel.IsDeleted)
                {
                    string htmlTable = mailUtils.MountHtmlLawTable(lawViewModel.LawInfoForEmail, companyLawModel, user.FullName);
                    await mailFunctions.SendAsync("REQUISITO LEGAL ADICIONADO: " + item.NomeFantasia + " - " + lawViewModel.LawInfoForEmail, htmlTable, mailAddress, companyLawModel.CompanyId);
                }
            }
            return Json(count);
        }
    }
}