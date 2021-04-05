using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using DTO.Company;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using GLAS2Web.Security;
using DAL;
using System.Data.SqlClient;
using GLAS2Web.Models.Shared;
using GLAS2Web.Utils;

namespace GLAS2Web.Controllers
{
    [AuthorizeRoles(BLL.User.ProfileNames.Administrator, BLL.User.ProfileNames.Master, BLL.User.ProfileNames.Biotera, BLL.User.ProfileNames.Cliente)]
    public class CompanyManagementController : Shared.BaseController
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly DAL.GLAS2Context context;
        private readonly BLL.Company.CompanyFunctions companyFunctions;
        private readonly BLL.Company.CompanyLogoFunctions companyLogoFunctions;
        private readonly BLL.Company.CompanyUserFunctions companyUser;
        private readonly BLL.Company.CompanyLawFunctions companyLaw;
        private readonly BLL.Company.GroupFunctions groupFunctions;
        private readonly BLL.Law.LawFunctions lawFunctions;
        private readonly BLL.Utils.CountryFunctions countryFunctions;
        private readonly BLL.Utils.StateFunctions stateFunctions;
        private readonly BLL.Utils.CityFunctions cityFunctions;
        private readonly BLL.Permission.CompanyUserRoleFunctions companyUserRoleFunctions;
        private readonly UserManager<DAL.Identity.User> userManager;
        private readonly BLL.Mail.MailUtils mailUtils;
        private readonly BLL.User.UserFunctions userFunctions;
        private readonly BLL.Law.LawApplicationTypeFunctions lawApplicationTypeFunctions;
        private readonly BLL.Law.LawConclusionStatusFunctions lawConclusionStatusFunctions;
        private readonly BLL.Law.LawPotentialityTypeFunctions lawPotentialityTypeFunctions;
        private readonly BLL.Company.CompanyViewFunctions companyViewFunctions;
        private readonly BLL.Mail.MailFunctions mailFunctions;
        private readonly ControllerUtils controllerUtils;

        public CompanyManagementController(IHostingEnvironment hostingEnvironment, DAL.GLAS2Context context, UserManager<DAL.Identity.User> userManager, BLL.Mail.MailFunctions mailFunctions, ControllerUtils controllerUtils)
        {
            this._hostingEnvironment = hostingEnvironment;
            this.context = context;
            this.companyFunctions = new BLL.Company.CompanyFunctions(context);
            this.companyLogoFunctions = new BLL.Company.CompanyLogoFunctions(context);
            this.companyUser = new BLL.Company.CompanyUserFunctions(context);
            this.companyLaw = new BLL.Company.CompanyLawFunctions(context);
            this.groupFunctions = new BLL.Company.GroupFunctions(context);
            this.countryFunctions = new BLL.Utils.CountryFunctions(context);
            this.stateFunctions = new BLL.Utils.StateFunctions(context);
            this.cityFunctions = new BLL.Utils.CityFunctions(context);
            this.companyUserRoleFunctions = new BLL.Permission.CompanyUserRoleFunctions(context);
            this.lawFunctions = new BLL.Law.LawFunctions(context);
            this.mailUtils = new BLL.Mail.MailUtils(context, userManager);
            this.userFunctions = new BLL.User.UserFunctions(context, userManager);
            this.lawPotentialityTypeFunctions = new BLL.Law.LawPotentialityTypeFunctions(context);
            this.lawApplicationTypeFunctions = new BLL.Law.LawApplicationTypeFunctions(context);
            this.lawConclusionStatusFunctions = new BLL.Law.LawConclusionStatusFunctions(context);
            this.companyViewFunctions = new BLL.Company.CompanyViewFunctions(context);
            this.mailFunctions = mailFunctions;

            this.controllerUtils = controllerUtils;
            this.userManager = userManager;
        }

        private async Task<bool> CanManageCompany(int companyId, bool allowCliente = false)
        {
            if (User.IsInRole(BLL.User.ProfileNames.Administrator) || User.IsInRole(BLL.User.ProfileNames.Master))
                return true;

            var user = await this.userManager.GetUserAsync(User);
            if (User.IsInRole(BLL.User.ProfileNames.Biotera))
                return this.companyUserRoleFunctions.UserCompanyHasRole(user.Id, companyId, BLL.User.ProfileNames.BioteraConsultor);

            if (allowCliente)
                if (User.IsInRole(BLL.User.ProfileNames.Cliente))
                    return this.companyUserRoleFunctions.UserCompanyHasRole(user.Id, companyId, BLL.User.ProfileNames.ClienteAdministrador);

            return false;
        }

        #region [Views]
        [Authorize(Policy = "BioteraManagesAnyCompany")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "UserManagesAnyCompany")]
        public async Task<IActionResult> Users(int? id)
        {
            if (id.HasValue)
                if (!(await CanManageCompany(id.Value, true)))
                    return Forbid();

            if (!companyFunctions.Exists(id))
                return NotFound();

            //var user = await userManager.GetUserAsync(User);
            //if (User.IsInRole(BLL.User.ProfileNames.Administrator) || User.IsInRole(BLL.User.ProfileNames.Master) || companyUserRoleFunctions.UserCompanyHasRole(id.Value, user.Id, new List<string>() { BLL.User.ProfileNames.BioteraConsultor, BLL.User.ProfileNames.ClienteAdministrador }))
            return View(this.companyFunctions.GetDataViewModel(this.companyFunctions.GetDataByID(id)));

            //return Forbid();
        }

        [AuthorizeRoles(BLL.User.ProfileNames.Administrator, BLL.User.ProfileNames.Master, BLL.User.ProfileNames.Biotera)]
        public async Task<IActionResult> Laws(int? id)
        {
            if (id.HasValue)
                if (!(await CanManageCompany(id.Value)))
                    return Forbid();

            if (!companyFunctions.Exists(id))
                return NotFound();

            return View(this.companyFunctions.GetDataViewModel(this.companyFunctions.GetDataByID(id)));
        }

        [AuthorizeRoles(BLL.User.ProfileNames.Administrator, BLL.User.ProfileNames.Master, BLL.User.ProfileNames.Biotera)]
        public async Task<IActionResult> Manage(int? id)
        {
            if (id.HasValue)
                if (!(await CanManageCompany(id.Value)))
                    return Forbid();

            ViewData["Countries"] = countryFunctions.GetData().ToList();

            if (!companyFunctions.Exists(id))
                return View(new DTO.Company.CompanyViewModel());
            else
            {
                var model = this.companyFunctions.GetDataViewModel(this.companyFunctions.GetDataByID(id));
                return View(model);
            }

        }
        [HttpPost]
        [ActionName("Manage")]
        [AuthorizeRoles(BLL.User.ProfileNames.Administrator, BLL.User.ProfileNames.Master, BLL.User.ProfileNames.Biotera)]
        public async Task<IActionResult> _Manage([FromForm] DTO.Company.CompanyViewModel model, [FromForm] bool removeLogo)
        {
            if (model.CompanyId.HasValue)
                if (!(await CanManageCompany(model.CompanyId.Value)))
                    return Forbid();

            var logo = Request.Form.Files.SingleOrDefault(x => x.Name.Equals("Logo"));

            bool validSize = logo.Length <= 2097152 && logo.Length > 0;
            bool validArchive = logo.ContentType == "image/jpeg" || logo.ContentType == "image/png";
            bool validLogo = (logo != null && validSize && validArchive); // VALIDACOES

            if (!validLogo && logo.FileName != "")
            {
                ViewData["Countries"] = countryFunctions.GetData().ToList();
                if (!validSize) ViewData["ErroDoArquivo"] = "Tamanho do arquivo maior que o máximo aceito.";
                if (!validArchive) ViewData["ErroDoArquivo"] = "Arquivo com extensão diferente do aceito.";
                return View(model);
            }

            if (!string.IsNullOrWhiteSpace(logo.FileName)) model.HasLogo = validLogo;
            if (removeLogo) model.HasLogo = false;

            int companyId = companyFunctions.CreateOrUpdate(model);

            var pathToDelete = "";
            if (companyLogoFunctions.GetCompanyLogoByCompanyId(companyId) != null)
                pathToDelete = System.IO.Path.Combine(this._hostingEnvironment.ContentRootPath, companyLogoFunctions.GetCompanyLogoByCompanyId(companyId).FilePath);

            if (validLogo)
            {
                companyLogoFunctions.DeleteByCompanyId(companyId, pathToDelete);
                var companyLogoDirectory = System.IO.Path.Combine("Assets", "System", "CompanyLogo");
                var companyLogoFilePath = System.IO.Path.Combine(companyLogoDirectory, string.Format("{0}{1}", Guid.NewGuid().ToString(), System.IO.Path.GetExtension(logo.FileName)));
                if (!Directory.Exists(System.IO.Path.Combine(this._hostingEnvironment.ContentRootPath, companyLogoDirectory)))
                {
                    Directory.CreateDirectory(System.IO.Path.Combine(this._hostingEnvironment.ContentRootPath, companyLogoDirectory));
                }
                var companyLogo = companyLogoFunctions.GetCompanyLogoFromIFormFile(companyId, logo, companyLogoFilePath);
                companyLogoFunctions.Create(companyLogo, logo.OpenReadStream(), System.IO.Path.Combine(this._hostingEnvironment.ContentRootPath, companyLogoFilePath));
            }
            else if (removeLogo)
            {
                companyLogoFunctions.DeleteByCompanyId(companyId, pathToDelete);
            }

            if (model.CompanyId == null)
            {
                var user = await this.userManager.GetUserAsync(User);
                var htmlTable = mailUtils.CompanyHtmlTable(model.NomeFantasia, user.FullName);
                await mailFunctions.SendAsync("NOVA UNIDADE DE NEGÓCIO: " + model.NomeFantasia, htmlTable, null, model.CompanyId);
            }

            return RedirectToAction("Manage", new { id = companyId, saved = true });
        }

        public IActionResult GetCompanyLogo(int companyId)
        {
            var companyLogo = companyLogoFunctions.GetCompanyLogoByCompanyId(companyId);

            if (companyLogo != null)
                if (!System.IO.File.Exists(System.IO.Path.Combine(this._hostingEnvironment.ContentRootPath, companyLogo.FilePath)))
                    return File(System.IO.File.ReadAllBytes(System.IO.Path.Combine(this._hostingEnvironment.ContentRootPath, "Assets", "System", "CompanyLogo", "default.png")), "image/png", "default.png");

            if (companyLogo == null)
                return File(System.IO.File.ReadAllBytes(System.IO.Path.Combine(this._hostingEnvironment.ContentRootPath, "Assets", "System", "CompanyLogo", "default.png")), "image/png", "default.png");

            var fullPath = System.IO.Path.Combine(this._hostingEnvironment.ContentRootPath, companyLogo.FilePath);

            return File(System.IO.File.ReadAllBytes(fullPath), companyLogo.ContentType, companyLogo.FileName);
        }

        public IActionResult LawSearch(int? id)
        {
            if (!companyFunctions.Exists(id))
                return RedirectToAction("Index");

            var company = companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(id));
            return View(company);
        }

        #endregion

        #region [AJAX]
        [HttpPost]
        public async Task<IActionResult> QuickList([FromBody] string q)
        {
            return await _List(new DTO.Shared.DataTablesAjaxPostModel() { search = new DTO.Shared.Search() { value = q }, columns = new List<DTO.Shared.Column>() { new DTO.Shared.Column() { data = "Cnpj" }, new DTO.Shared.Column() { data = "RazaoSocial" }, new DTO.Shared.Column() { data = "NomeFantasia" } } }, null, null);
        }

        [HttpPost]
        [ActionName("List")]
        public async Task<IActionResult> _List(DTO.Shared.DataTablesAjaxPostModel filter, int? id, int? companyQuestionStatusId)
        {
            var paramenters = new SqlParameterList();
            paramenters.AddParameter("IsDeleted", false);
            if(id.HasValue) paramenters.AddParameter("CompanyId", id);
            if(companyQuestionStatusId.HasValue) paramenters.AddParameter("CompanyQuestionStatusId", companyQuestionStatusId);

            var d = this.companyViewFunctions.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, paramenters.GetQuery(), paramenters.GetParameters());

            if (!User.IsInRole(BLL.User.ProfileNames.Administrator) && !User.IsInRole(BLL.User.ProfileNames.Master))
            {
                if (User.IsInRole(BLL.User.ProfileNames.Biotera))
                {
                    var user = await this.userManager.GetUserAsync(User);
                    var companiesId = this.companyUserRoleFunctions.UserCompaniesIdByRole(user.Id, new List<string> { BLL.User.ProfileNames.BioteraConsultor });
                    d = d.Where(x => companiesId.Any(y => y.Equals(x.CompanyId)));

                    recordsTotal = companiesId.Count;
                    recordsFiltered = d.Count();
                }
            }

            return Json(new
            {
                draw = filter.draw,
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            });
        }

        [HttpPost]
        [ActionName("RemoveCompany")]
        public async Task<IActionResult> RemoveCompany(int? companyId)
        {
            if (!companyId.HasValue) return Json(false);
            this.companyFunctions.Delete(companyId.Value);
            //this.userFunctions.DeleteByCompanyId(companyId.Value);
            this.companyUserRoleFunctions.DeleteByCompanyId(companyId.Value);
            await this.companyLaw.DeleteByCompanyId(companyId.Value, this._hostingEnvironment.ContentRootPath);

            var model = companyFunctions.GetDataByID(companyId);

            if (model.HasLogo)
            {
                var pathToDelete = "";
                if (companyLogoFunctions.GetCompanyLogoByCompanyId(companyId.Value) != null)
                    pathToDelete = System.IO.Path.Combine(this._hostingEnvironment.ContentRootPath, companyLogoFunctions.GetCompanyLogoByCompanyId(companyId.Value).FilePath);

                this.companyLogoFunctions.DeleteByCompanyId(companyId.Value, pathToDelete);
            }

            //var user = await this.userManager.GetUserAsync(User);
            //var htmlTable = mailUtils.CompanyHtmlTable(model.NomeFantasia, user.FullName);
            //await mailFunctions.SendAsync("UNIDADE DE NEGÓCIO: " + model.NomeFantasia + " EXCLUÍDA", htmlTable, null, companyId);

            return Json(true);
        }

        [HttpPost]
        [ActionName("CountryList")]
        public IActionResult CountryList()
        {
            return Json(countryFunctions.GetData().ToList());
        }

        [HttpPost]
        [ActionName("StateList")]
        public IActionResult StateList()
        {
            return Json(stateFunctions.GetData().ToList());
        }

        [HttpPost]
        [ActionName("CityListInState")]
        public IActionResult CityListInState(string uf)
        {
            //return Json(cityFunctions.GetData().ToList().Where(x => x.Uf == uf).OrderBy(x => x.Name));
            return Json(null);
        }

        [AuthorizeRoles(BLL.User.ProfileNames.Administrator, BLL.User.ProfileNames.Master)]
        public async Task<IActionResult> SendQuestionEmail(int companyId, string to, string replyTo, string bcc)
        {
            var entity = companyFunctions.GetDataByID(companyId);

            try
            {
                if (!entity.QuestionEmailSended)
                    await companyFunctions.CreateCompanyQuestion(companyId);

                await _SendQuestionEmail(companyId, to, replyTo, bcc);

                await companyFunctions.UpdateSendedQuestionEmail(companyId);

                return await Task.Run(() => Json(new { success = true, message = "O e-mail foi enviado com sucesso!" }));
            }
            catch
            {
                return await Task.Run(() => Json(new { success = false, message = "Houve um erro ao enviar o e-mail." }));
            }
        }

        //public IActionResult CompanyQuestionEmail(int companyId) => View(companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(companyId)));

        private async Task _SendQuestionEmail(int companyId, string to, string replyTo, string bcc)
        {
            var _to = new List<string>();
            if (to != null) _to = to.Split(";").Select(x => x.Trim()).ToList();
            while (_to.Contains("")) _to.Remove(""); //caso o usuário insira ";" desnecessário

            var _replyTo = new List<string>();
            if (replyTo != null) _replyTo = replyTo.Split(";").Select(x => x.Trim()).ToList();
            while (_replyTo.Contains("")) _replyTo.Remove("");//caso o usuário insira ";" desnecessário

            var _bcc = new List<string>();
            if (bcc != null) _bcc = bcc.Split(";").Select(x => x.Trim()).ToList();
            while (_bcc.Contains("")) _bcc.Remove(""); //caso o usuário insira ";" desnecessário

            await companyFunctions.SetCompanyQuestionToken(companyId);

            var entity = companyFunctions.GetDataByID(companyId);

            var html = await controllerUtils.RenderPartialViewToString(ControllerContext, ViewData, TempData, "CompanyQuestionEmail", companyFunctions.GetDataViewModel(entity));

            await mailFunctions.SendAsync($"Questionário - {entity.RazaoSocial}", html, _to, companyId, null, true, _replyTo, _bcc, false);
        }

        #region [CompanyUser]

        [HttpPost]
        public async Task<IActionResult> UsersInCompany(int? companyId)
        {
            if (companyId.HasValue)
                if (!(await CanManageCompany(companyId.Value, true)))
                    return Forbid();

            if (!companyId.HasValue) return Json(null);

            var user = await userManager.GetUserAsync(User);
            if (User.IsInRole(BLL.User.ProfileNames.Administrator) || User.IsInRole(BLL.User.ProfileNames.Master))
                return Json(this.companyUserRoleFunctions.UsersInCompany(companyId.Value));

            if (User.IsInRole(BLL.User.ProfileNames.Biotera))
                return Json(this.companyUserRoleFunctions.UsersInCompanyByRole(companyId.Value, new List<string>() { BLL.User.ProfileNames.BioteraConsultor, BLL.User.ProfileNames.BioteraAuditor, BLL.User.ProfileNames.ClienteAdministrador, BLL.User.ProfileNames.ClienteSupervisor, BLL.User.ProfileNames.ClienteOperador }));

            if (User.IsInRole(BLL.User.ProfileNames.Cliente))
                return Json(this.companyUserRoleFunctions.UsersInCompanyByRole(companyId.Value, new List<string>() { BLL.User.ProfileNames.ClienteAdministrador, BLL.User.ProfileNames.ClienteSupervisor, BLL.User.ProfileNames.ClienteOperador }));

            return Forbid();
        }

        [HttpPost]
        public async Task<IActionResult> UserIsInCompany(int? userId, int? companyId)
        {
            if (companyId.HasValue)
                if (!(await CanManageCompany(companyId.Value, true)))
                    return Forbid();

            if (!userId.HasValue || !companyId.HasValue) return Json(false);

            return Json(this.companyUserRoleFunctions.UserIsInCompany(companyId.Value, userId.Value));
        }

        [HttpPost]
        public async Task<IActionResult> AddUserToCompany(int? userId, int? companyId, string role)
        {
            if (!userId.HasValue || !companyId.HasValue) return Json(false);

            int companyUserRoleId = this.companyUserRoleFunctions.AddCompanyUserRole(companyId.Value, userId.Value, role);

            var mailAddress = new List<string>();
            var user = userFunctions.GetDataByID(userId.Value);
            if (user != null) mailAddress.Add(user.Email);

            if (companyUserRoleId > 0)
            {
                var company = this.companyFunctions.GetDataViewModel(this.companyFunctions.GetDataByID(companyId.Value));
                await mailFunctions.SendAsync("Você possui uma nova atribuição em " + company.NomeFantasia, "Você irá atuar como <b>" + role + "</b>.", mailAddress, companyId, userId);
            }

            return Json(companyUserRoleId);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveUserFromCompany(int? companyUserRoleId)
        {
            if (!companyUserRoleId.HasValue) return Json(false);

            int userId = companyUserRoleFunctions.GetUserId(companyUserRoleId.Value);
            int companyId = companyUserRoleFunctions.GetCompanyId(companyUserRoleId.Value);

            var userModel = userFunctions.GetDataByID(userId);
            var companyModel = companyFunctions.GetDataByID(companyId);

            await mailFunctions.SendAsync("O usuário " + userModel.FirstName + " " + userModel.LastName + " foi desassociado", "O usuário " + userModel.FirstName + " " + userModel.LastName + " de email: " + userModel.Email + " foi desassociado da empresa " + companyModel.NomeFantasia, null, companyId, userId);

            this.companyUserRoleFunctions.Delete(companyUserRoleId.Value); //.Delete(companyUserId.Value);

            return Json(true);
        }
        #endregion

        #region [CompanyLaw]
        [HttpPost]
        [Authorize(Policy = "BioteraManagesAnyCompany")]
        public async Task<IActionResult> LawsInCompany(int? companyId)
        {
            if (companyId.HasValue)
                if (!(await CanManageCompany(companyId.Value)))
                    return Forbid();

            if (!companyId.HasValue) return Json(null);

            return Json(this.companyLaw.LawsInCompany(companyId.Value));
        }

        [HttpPost]
        [Authorize(Policy = "BioteraManagesAnyCompany")]
        public async Task<IActionResult> LawIsInCompany(int? lawId, int? companyId)
        {
            if (companyId.HasValue)
                if (!(await CanManageCompany(companyId.Value)))
                    return Forbid();

            if (!lawId.HasValue || !companyId.HasValue) return Json(false);

            return Json(this.companyLaw.LawIsInCompany(lawId.Value, companyId.Value));
        }

        [HttpPost]
        [Authorize(Policy = "BioteraManagesAnyCompany")]
        public async Task<IActionResult> AddLawToCompany(int? lawId, int? companyId)
        {
            if (companyId.HasValue)
                if (!(await CanManageCompany(companyId.Value)))
                    return Forbid();

            if (!lawId.HasValue || !companyId.HasValue) return Json(false);
            var companyLawId = this.companyLaw.Create(new DTO.Company.CompanyLawViewModel()
            {
                LawId = lawId.Value,
                CompanyId = companyId.Value,
                LawApplicationTypeId = lawApplicationTypeFunctions.GetData().FirstOrDefault(x => x.ExternalCode == "KNOWLEDGE").LawApplicationTypeId,
                LawPotentialityTypeId = lawPotentialityTypeFunctions.GetData().FirstOrDefault(x => x.ExternalCode == "NOTAPPLICABLE").LawPotentialityTypeId,
                LawConclusionStatusId = lawConclusionStatusFunctions.GetData().FirstOrDefault(x => x.ExternalCode == "NOTAPPLICABLE").LawConclusionStatusId
            });

            var companyLawView = companyLaw.GetDataViewModel(companyLaw.GetDataByID(companyLawId));
            var lawModel = lawFunctions.GetDataByID(lawId);
            var companyModel = companyFunctions.GetDataByID(companyId);
            var lawViewModel = lawFunctions.GetDataViewModel(lawModel);
            var userModel = await this.userManager.GetUserAsync(User);

            var userModels = new List<DTO.User.UserModel>();
            userModels = mailUtils.GetCompanyAdministrators(companyId.Value);
            var mailAddress = new List<string>();
            if (userModels != null && userModels.Count > 0) mailAddress = mailUtils.UserModelsToMailAddress(userModels);


            var user = await userManager.GetUserAsync(User);
            string htmlTable = mailUtils.MountHtmlLawTable(lawViewModel.LawInfoForEmail, companyLawView, user.FullName);
            await mailFunctions.SendAsync("REQUISITO LEGAL ADICIONADO: " + companyModel.NomeFantasia + " - " + lawViewModel.LawInfoForEmail, htmlTable, mailAddress, companyId);

            return Json(companyLawId);
        }

        [HttpPost]
        [Authorize(Policy = "BioteraManagesAnyCompany")]
        public async Task<IActionResult> AddLawsToCompany(List<int> knowledgeLaws, List<int> applicableLaws, int? companyId)
        {
            if (companyId.HasValue)
                if (!(await CanManageCompany(companyId.Value)))
                    return Forbid();

            if ((knowledgeLaws.Count == 0 && applicableLaws.Count == 0) || !companyId.HasValue) return Json(false);

            int knowledgeCount = 0, applicableCount = 0;

            var lawApplicationTypeId = lawApplicationTypeFunctions.GetData().FirstOrDefault(x => x.ExternalCode == "KNOWLEDGE").LawApplicationTypeId;
            var lawConclusionStatusId = lawConclusionStatusFunctions.GetData().FirstOrDefault(x => x.ExternalCode == "NOTAPPLICABLE").LawConclusionStatusId;
            var lawPotentialityTypeId = lawPotentialityTypeFunctions.GetDataFiltered(x => x.ExternalCode.ToUpper().Equals("NOTAPPLICABLE")).First().LawPotentialityTypeId;

            foreach (var knowledgeLawId in knowledgeLaws)
            {
                if (companyLaw.GetData().Any(x => x.LawId == knowledgeLawId && x.CompanyId == companyId && x.IsDeleted == false))
                    continue;

                var law = lawFunctions.GetDataByID(knowledgeLawId);

                var companyLawId = this.companyLaw.Create(new DTO.Company.CompanyLawViewModel()
                {
                    LawId = knowledgeLawId,
                    CompanyId = companyId.Value,
                    LawApplicationTypeId = lawApplicationTypeId,
                    LawPotentialityTypeId = law.LawPotentialityTypeId ?? lawPotentialityTypeId,
                    LawConclusionStatusId = lawConclusionStatusId
                });

                //var law = lawFunctions.GetDataByID(knowledgeLawId);
                //var lawViewModel = lawFunctions.GetDataViewModel(law);
                //var userModel = await this.userManager.GetUserAsync(User);
                //var companyLawData = companyLaw.GetDataByID(companyLawId);
                //var companyLawView = companyLaw.GetDataViewModel(companyLawData);

                //var userModels = new List<DTO.User.UserModel>();
                //userModels = mailUtils.GetCompanyAdministrators(companyId.Value);
                //var mailAddress = new List<string>();
                //if (userModels != null && userModels.Count > 0) mailAddress = mailUtils.UserModelsToMailAddress(userModels);


                //string htmlTable = mailUtils.MountHtmlLawTable(lawViewModel.LawInfoForEmail, companyLawView);
                //await BLL.Mail.MailFunctions.SendAsync("REQUISITO LEGAL ADICIONADO: " + companyLawView.Company.NomeFantasia + " - " + lawViewModel.LawInfoForEmail, htmlTable, mailAddress);

                knowledgeCount++;
            }
            foreach (var applicableLawId in applicableLaws)
            {
                if (companyLaw.GetData().Any(x => x.LawId == applicableLawId && x.CompanyId == companyId && x.IsDeleted == false))
                    continue;

                var law = lawFunctions.GetDataByID(applicableLawId);

                var companyLawId = this.companyLaw.Create(new DTO.Company.CompanyLawViewModel()
                {
                    LawId = applicableLawId,
                    CompanyId = companyId.Value,
                    LawApplicationTypeId = lawApplicationTypeId,
                    LawPotentialityTypeId = law.LawPotentialityTypeId ?? lawPotentialityTypeId,
                    LawConclusionStatusId = lawConclusionStatusId
                });

                //var law = lawFunctions.GetDataByID(applicableLawId);
                //var lawViewModel = lawFunctions.GetDataViewModel(law);
                //var userModel = await this.userManager.GetUserAsync(User);
                //var companyLawData = companyLaw.GetDataByID(companyLawId);
                //var companyLawView = companyLaw.GetDataViewModel(companyLawData);

                //var userModels = new List<DTO.User.UserModel>();
                //userModels = mailUtils.GetCompanyAdministrators(companyId.Value);
                //var mailAddress = new List<string>();
                //if (userModels != null && userModels.Count > 0) mailAddress = mailUtils.UserModelsToMailAddress(userModels);


                //string htmlTable = mailUtils.MountHtmlLawTable(lawViewModel.LawInfoForEmail, companyLawView);
                //await BLL.Mail.MailFunctions.SendAsync("REQUISITO LEGAL ADICIONADO: " + companyLawView.Company.NomeFantasia + " - " + lawViewModel.LawInfoForEmail, htmlTable, mailAddress);

                applicableCount++;
            }
            return Json(new { knowledgeCount = knowledgeCount, applicableCount = applicableCount });
        }

        [HttpPost]
        [Authorize(Policy = "BioteraManagesAnyCompany")]
        public async Task<IActionResult> RemoveLawFromCompany(int? companyLawId)
        {
            if (!companyLawId.HasValue) return Json(false);
            this.companyLaw.Delete(companyLawId.Value);

            var companyLawModel = companyLaw.GetDataByID(companyLawId);
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

            string htmlTable = mailUtils.MountHtmlLawTable(lawViewModel.LawInfoForEmail, companyLaw.GetDataViewModel(companyLawModel), (await userManager.GetUserAsync(User)).FullName);

            await mailFunctions.SendAsync($"REQUISITO LEGAL DESASSOCIADO: {companyModel.NomeFantasia} - {lawViewModel.LawInfoForEmail}", htmlTable, mailAddress, companyModel.CompanyId);

            return Json(true);
        }

        //[HttpPost]
        //public IActionResult AddLaw(int? lawId, int? groupId)
        //{
        //}

        #endregion

        #endregion
    }
}