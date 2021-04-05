using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using GLAS2Web.Security;
using Microsoft.AspNetCore.Identity;
using Utils;
using System.Globalization;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using DTO.Law;
using DAL;
using Microsoft.EntityFrameworkCore;
using DAL.Identity;
using System.Data.SqlClient;
using DTO.Company;
using System.Runtime.CompilerServices;

namespace GLAS2Web.Controllers
{

    [AuthorizeRoles(BLL.User.ProfileNames.Administrator, BLL.User.ProfileNames.Master, BLL.User.ProfileNames.Biotera, BLL.User.ProfileNames.Cliente)]
    public class LawManagementController : Shared.BaseController
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly DAL.GLAS2Context context;
        private readonly BLL.Law.LawFunctions bll;
        private readonly BLL.Law.LawViewFunctions lawViewFunctions;
        private readonly BLL.Company.CompanyLawFunctions companyLawFunctions;
        private readonly BLL.Company.CompanyFunctions companyFunctions;
        private readonly BLL.Utils.CountryFunctions countryFunctions;
        private readonly BLL.Utils.StateFunctions stateFunctions;
        private readonly BLL.Utils.CityFunctions cityFunctions;
        private readonly BLL.Mail.MailUtils mailUtils;
        private readonly BLL.Law.LawApplicationTypeFunctions lawApplicationTypeFunctions;
        private readonly UserManager<DAL.Identity.User> userManager;
        private readonly BLL.User.UserFunctions userFunctions;
        private readonly BLL.Law.LawChangeFunctions lawChangeFunctions;
        private readonly BLL.Mail.MailFunctions mailFunctions;

        private BLL.Law.LawTypeFunctions lawTypeFunctions;
        private BLL.Law.LawAttachmentFunctions lawAttachmentFunctions;
        private BLL.Utils.EsferaFunctions esferaFunctions;
        private BLL.Utils.OrgaoFunctions orgaoFunctions;
        private BLL.Utils.SegmentoFunctions segmentoFunctions;
        private BLL.Company.CompanyLawAttachmentFunctions companyLawAttachmentFunctions;

        public LawManagementController(IHostingEnvironment hostingEnvironment, DAL.GLAS2Context context, UserManager<DAL.Identity.User> userManager, BLL.Company.CompanyLawAttachmentFunctions companyLawAttachmentFunctions, BLL.Law.LawChangeFunctions lawChangeFunctions, BLL.Mail.MailFunctions mailFunctions)
        {
            this._hostingEnvironment = hostingEnvironment;
            this.context = context;
            this.bll = new BLL.Law.LawFunctions(this.context);
            this.lawViewFunctions = new BLL.Law.LawViewFunctions(context);
            this.mailUtils = new BLL.Mail.MailUtils(context, userManager);
            this.companyLawFunctions = new BLL.Company.CompanyLawFunctions(context);
            this.companyFunctions = new BLL.Company.CompanyFunctions(context);

            this.lawTypeFunctions = new BLL.Law.LawTypeFunctions(this.context);
            this.lawAttachmentFunctions = new BLL.Law.LawAttachmentFunctions(this.context);
            this.esferaFunctions = new BLL.Utils.EsferaFunctions(this.context);
            this.orgaoFunctions = new BLL.Utils.OrgaoFunctions(this.context);
            this.segmentoFunctions = new BLL.Utils.SegmentoFunctions(this.context);
            this.countryFunctions = new BLL.Utils.CountryFunctions(context);
            this.stateFunctions = new BLL.Utils.StateFunctions(context);
            this.cityFunctions = new BLL.Utils.CityFunctions(context);
            this.lawApplicationTypeFunctions = new BLL.Law.LawApplicationTypeFunctions(context);
            this.userManager = userManager;
            this.userFunctions = new BLL.User.UserFunctions(context, userManager);
            this.companyLawAttachmentFunctions = companyLawAttachmentFunctions;
            this.lawChangeFunctions = lawChangeFunctions;
            this.mailFunctions = mailFunctions;
        }

        [AuthorizeRoles(BLL.User.ProfileNames.Administrator, BLL.User.ProfileNames.Master)]
        public IActionResult Index()
        {
            //var y1 = (from x in this.context.Law select x).AsQueryable<DAL.Law>().Count(); // SELECT COUNT(*) FROM LAW
            //var y2 = (from x in this.context.Law select x).AsQueryable().Count();
            //var y3 = (from x in this.context.Law where x.IsActive == true select x).AsQueryable<DAL.Law>().Count();
            //var y4 = (from x in this.context.Law where x.IsActive == true select x).AsQueryable().Count();
            //var y5 = (from x in this.context.Law.Where(x2 => x2.IsActive.Equals(true)) select x).AsQueryable().Count();
            //var y6 = (from x in this.context.Law.Where(x2 => x2.IsActive.Equals(true)) select x).AsQueryable<DAL.Law>().Count();
            //var y7 = (from x in this.context.Law select x).Where(x2 => x2.IsActive.Equals(true)).AsQueryable().Count();
            //var y8 = (from x in this.context.Law select x).Where(x2 => x2.IsActive.Equals(true)).AsQueryable<DAL.Law>().Count();

            //var y9 = (from x in this.context.Law select x).Where(x2 => x2.IsActive.Equals(true)).Count();

            return View();
        }

        [AuthorizeRoles(BLL.User.ProfileNames.Administrator, BLL.User.ProfileNames.Master)]
        public IActionResult Manage(int? id, int? page)
        {
            //ViewData["LawTypes"] = lawTypeFunctions.GetDataViewModel(lawTypeFunctions.GetData().OrderBy(x => x.Name));
            //ViewData["Esfera"] = esferaFunctions.GetData().OrderBy(x => x.Name).ToList();
            //ViewData["Orgao"] = orgaoFunctions.GetData().OrderBy(x => x.Name).ToList();
            //ViewData["Segmento"] = segmentoFunctions.GetData().OrderBy(x => x.Name).ToList();
            //ViewData["Countries"] = countryFunctions.GetData().ToList();
            //ViewData["State"] = stateFunctions.GetData().ToList();

            if (!bll.Exists(id))
                return View(new DTO.Law.LawViewModel());
            else
            {
                if (id.HasValue && bll.GetDataByID(id).IsDeleted == false)
                    return View(this.bll.GetDataViewModel(this.bll.GetDataByID(id)));
                else
                    return NotFound();
            }
        }
        [HttpPost]
        [ActionName("Manage")]
        [AuthorizeRoles(BLL.User.ProfileNames.Administrator, BLL.User.ProfileNames.Master)]
        public async Task<IActionResult> _Manage([FromForm] DTO.Law.LawViewModel model, List<LawChange> lawChangesBy, List<LawChange> lawChangesFrom, List<int> lawRevokedFrom, bool associateLaw)
        //associateLaw: Associar esta lei as unidades de negocio já associadas as leis alteradas ou revogadas;
        {
            var user = await this.userManager.GetUserAsync(User);

            bool isNewLaw = !model.LawId.HasValue;
            bool lawWasRevoked = false;
            if (model.LawId.HasValue)
            {
                var oldLaw = bll.GetDataByID(model.LawId);
                lawWasRevoked = oldLaw.RevokedDate.HasValue || !string.IsNullOrWhiteSpace(oldLaw.RevokedBy);
            }
            else
            {
                model.CreatedBy = user.Id;

                if (bll.ExistLaw(model, out DAL.Law law))
                {
                    ViewData["DuplicateLaw"] = law;
                    return await Task.Run(() => View(model));
                }
            }

            //pega a data de revogação
            if (model.RevokedById.HasValue)
            {
                var revokedByLaw = bll.GetDataByID(model.RevokedById);
                model.RevokedDate = revokedByLaw.ForceDate?.ToBrazilianDateFormat();
                model.RevokedBy = $"{revokedByLaw.Number} - {(revokedByLaw.Title.Length > 50 ? revokedByLaw.Title.Substring(0, 50) + "..." : revokedByLaw.Title)}";
            }
            else if (string.IsNullOrWhiteSpace(model.RevokedBy))
            {
                model.RevokedDate = null;
            }

            if (lawChangesBy.Count > 0)
            {
                var alteredLawsIds = lawChangesBy.Select(x => x.ChangedLawId);
                var alteredLaws = bll.GetDataAsNoTracking(x => alteredLawsIds.Contains(x.LawId));

                var lastAlteredLawDate = alteredLaws.Max(x => x.ForceDate);
                var lastAlteredLaw = alteredLaws.FirstOrDefault(x => x.ForceDate == lastAlteredLawDate);

                model.AlteredDate = lastAlteredLawDate?.ToBrazilianDateFormat();
                model.AlteredBy = $"{lastAlteredLaw.Number} - {(lastAlteredLaw.Title.Length > 50 ? lastAlteredLaw.Title.Substring(0, 50) + "..." : lastAlteredLaw.Title)}";
            }
            else if (string.IsNullOrWhiteSpace(model.AlteredBy))
            {
                model.AlteredDate = null;
            }

            int lawId = bll.CreateOrUpdate(model);

            var newLawRevokedFromIds = lawRevokedFrom.Except(bll.GetDataAsNoTracking(x => x.RevokedById == lawId).Select(x => x.LawId)).ToList();
            var newLawChangesBy = lawChangesBy.Select(x => x.ChangedLawId).Except(lawChangeFunctions.GetDataAsNoTracking(x => x.LawId == lawId).Select(x => x.ChangedLawId)).ToList();

            await InsertLawRevokedBy(lawId, lawRevokedFrom);
            await UpdateLawChangesBy(lawId, lawChangesBy);
            var newLawChangesFrom = await UpdateLawChangesFrom(lawId, lawChangesFrom);

            var lawViewModel = bll.GetDataViewModel(bll.GetDataByID(lawId));

            if (!model.NotSendEmail)
            {
                await SendManageEmails(lawChangesBy, lawRevokedFrom, newLawChangesFrom, lawViewModel, user, isNewLaw, lawWasRevoked);

                await SendRevokeEmailForNewLawRevokedFromId(newLawRevokedFromIds, user);

                await SendRevokeEmailForNewLawChangesFrom(newLawChangesFrom, user);
            }

            if (associateLaw)//Associar a lei criada as unidades legais das leis atribuidas como revogas/alteradas
                await CopyCompanyLawFromRevokedAndAlteredLaws(lawRevokedFrom.Union(lawChangesFrom.Select(x => x.LawId)), lawId, model.NotSendEmail, user);

            return RedirectToAction("Manage", new { id = lawId, saved = true, associateLaw });
        }

        private async Task SendManageEmails(List<LawChange> lawChangesBy, List<int> lawRevokedFrom, List<int> newLawChangesFrom, LawViewModel lawViewModel, User loggedUser, bool isNewLaw, bool lawWasRevoked)
        {
            string htmlNewLawTable = null;

            var newLawRevokedFromIds = lawRevokedFrom.Except(bll.GetDataAsNoTracking(x => x.RevokedById == lawViewModel.LawId).Select(x => x.LawId)).ToList();
            var newLawChangesBy = lawChangesBy.Select(x => x.ChangedLawId).Except(lawChangeFunctions.GetDataAsNoTracking(x => x.LawId == lawViewModel.LawId).Select(x => x.ChangedLawId)).ToList();

            if (isNewLaw)
            {
                htmlNewLawTable = mailUtils.NewLawHtmlTable(lawViewModel.LawInfoForEmail, lawViewModel, loggedUser.FullName);

                htmlNewLawTable += mailUtils.AlteratedByHtmlTable(lawViewModel.LawId.Value, newLawChangesBy);
                htmlNewLawTable += mailUtils.RevokedByHtmlTable(lawViewModel.LawId.Value);
                htmlNewLawTable += mailUtils.AlteratedFromHtmlTable(lawViewModel.LawId.Value, newLawChangesFrom);
                htmlNewLawTable += mailUtils.RevokedFromHtmlTable(lawViewModel.LawId.Value, newLawRevokedFromIds);

                await mailFunctions.SendAsync("REQUISITO INCLUÍDO " + lawViewModel.LawInfoForEmail + ", criado em: " + DateTime.Now.ToBrazilianDateFormat() + " e por: " + loggedUser.FullName, htmlNewLawTable, null);
            }
            else
            {
                var companyLawViewModelUserModelsDictionary = new Dictionary<DTO.Company.CompanyLawViewModel, List<DTO.User.UserModel>>();
                var companyLaws = companyLawFunctions.GetCompanyLawByLawId(lawViewModel.LawId.Value);
                if (companyLaws != null)
                {
                    foreach (var item in companyLaws)
                    {
                        if (!item.Company.IsActive || item.Company.IsDeleted)
                            continue;

                        if (!companyLawViewModelUserModelsDictionary.ContainsKey(item))
                        {
                            DAL.Identity.User compayLawResponsible = null;
                            if (item.ResponsibleId.HasValue) compayLawResponsible = userFunctions.GetDataByID(item.ResponsibleId);

                            var mails = mailUtils.GetCompanyAdministrators(item.CompanyId);
                            if (compayLawResponsible != null && !string.IsNullOrWhiteSpace(compayLawResponsible.Email)) mails.Add(userFunctions.GetDataViewModel(compayLawResponsible));

                            companyLawViewModelUserModelsDictionary.Add(item, mails);
                        }
                    }
                }

                //envio de e-mail POR empresa
                foreach (var kvp in companyLawViewModelUserModelsDictionary)
                {
                    var mailAddress = new List<string>();
                    if (kvp.Value != null && companyLawViewModelUserModelsDictionary.Count > 0) mailAddress = mailUtils.UserModelsToMailAddress(kvp.Value);

                    //if (mailAddress.Count == 0) continue;

                    // LEI FOI REVOGADA AGORA?
                    if ((!string.IsNullOrWhiteSpace(lawViewModel.RevokedDate) || !string.IsNullOrWhiteSpace(lawViewModel.RevokedBy)) && !lawWasRevoked)
                    {
                        var html = mailUtils.MountHtmlLawTable(lawViewModel.LawInfoForEmail, kvp.Key, loggedUser.FullName);
                        html += mailUtils.RevokedByHtmlTable(lawViewModel.LawId.Value);
                        html += mailUtils.RevokedFromHtmlTable(lawViewModel.LawId.Value, newLawRevokedFromIds);
                        await mailFunctions.SendAsync("REQUISITO LEGAL REVOGADO: " + kvp.Key.Company.NomeFantasia + " - " + lawViewModel.LawInfoForEmail, html, mailAddress, kvp.Key.Company.CompanyId);
                    }
                    else if (!isNewLaw)
                    {
                        var html = mailUtils.NewLawHtmlTable(lawViewModel.LawInfoForEmail, lawViewModel, loggedUser.FullName);

                        html += mailUtils.AlteratedByHtmlTable(lawViewModel.LawId.Value, newLawChangesBy);
                        html += mailUtils.RevokedByHtmlTable(lawViewModel.LawId.Value);
                        html += mailUtils.AlteratedFromHtmlTable(lawViewModel.LawId.Value, newLawChangesFrom);
                        html += mailUtils.RevokedFromHtmlTable(lawViewModel.LawId.Value, newLawRevokedFromIds);

                        await mailFunctions.SendAsync("REQUISITO LEGAL ALTERADO: " + kvp.Key.Company.NomeFantasia + " - " + lawViewModel.LawInfoForEmail, html, mailAddress, kvp.Key.Company.CompanyId);
                    }
                }
            }
        }

        private async Task SendRevokeEmailForNewLawChangesFrom(List<int> newLawRevokedFromIds, User user)
        {
            foreach (var newlawRevokedId in newLawRevokedFromIds)
            {
                var lawViewModel = bll.GetDataViewModel(bll.GetDataByID(newlawRevokedId));

                var companyLawViewModelUserModelsDictionary = new Dictionary<DTO.Company.CompanyLawViewModel, List<DTO.User.UserModel>>();
                var companyLaws = companyLawFunctions.GetCompanyLawByLawId(newlawRevokedId);
                if (companyLaws != null)
                {
                    foreach (var item in companyLaws)
                    {
                        if (!item.Company.IsActive || item.Company.IsDeleted)
                            continue;

                        if (!companyLawViewModelUserModelsDictionary.ContainsKey(item))
                        {
                            DAL.Identity.User compayLawResponsible = null;
                            if (item.ResponsibleId.HasValue) compayLawResponsible = userFunctions.GetDataByID(item.ResponsibleId);

                            var mails = mailUtils.GetCompanyAdministrators(item.CompanyId);
                            if (compayLawResponsible != null && !string.IsNullOrWhiteSpace(compayLawResponsible.Email)) mails.Add(userFunctions.GetDataViewModel(compayLawResponsible));

                            companyLawViewModelUserModelsDictionary.Add(item, mails);
                        }
                    }
                }

                foreach (var kvp in companyLawViewModelUserModelsDictionary)
                {
                    var mailAddress = new List<string>();
                    if (kvp.Value != null && companyLawViewModelUserModelsDictionary.Count > 0) mailAddress = mailUtils.UserModelsToMailAddress(kvp.Value);

                    if (mailAddress.Count == 0) continue;

                    var html = mailUtils.NewLawHtmlTable(lawViewModel.LawInfoForEmail, lawViewModel, user.FullName);
                    html += mailUtils.AlteratedByHtmlTable(newlawRevokedId);
                    html += mailUtils.RevokedByHtmlTable(newlawRevokedId);
                    html += mailUtils.AlteratedFromHtmlTable(newlawRevokedId);
                    html += mailUtils.RevokedFromHtmlTable(newlawRevokedId);

                    await mailFunctions.SendAsync("REQUISITO LEGAL ALTERADO: " + kvp.Key.Company.NomeFantasia + " - " + lawViewModel.LawInfoForEmail, html, mailAddress, kvp.Key.Company.CompanyId);
                }
            }
        }

        private async Task SendRevokeEmailForNewLawRevokedFromId(IEnumerable<int> newLawRevokedFromIds, User user)
        {
            foreach (var newlawRevokedId in newLawRevokedFromIds)
            {
                var lawViewModel = bll.GetDataViewModel(bll.GetDataByID(newlawRevokedId));

                var companyLawViewModelUserModelsDictionary = new Dictionary<DTO.Company.CompanyLawViewModel, List<DTO.User.UserModel>>();
                var companyLaws = companyLawFunctions.GetCompanyLawByLawId(newlawRevokedId);
                if (companyLaws != null)
                {
                    foreach (var item in companyLaws)
                    {
                        if (!item.Company.IsActive || item.Company.IsDeleted)
                            continue;

                        if (!companyLawViewModelUserModelsDictionary.ContainsKey(item))
                        {
                            DAL.Identity.User compayLawResponsible = null;
                            if (item.ResponsibleId.HasValue) compayLawResponsible = userFunctions.GetDataByID(item.ResponsibleId);

                            var mails = mailUtils.GetCompanyAdministrators(item.CompanyId);
                            if (compayLawResponsible != null && !string.IsNullOrWhiteSpace(compayLawResponsible.Email)) mails.Add(userFunctions.GetDataViewModel(compayLawResponsible));

                            companyLawViewModelUserModelsDictionary.Add(item, mails);
                        }
                    }
                }

                foreach (var kvp in companyLawViewModelUserModelsDictionary)
                {
                    var mailAddress = new List<string>();
                    if (kvp.Value != null && companyLawViewModelUserModelsDictionary.Count > 0) mailAddress = mailUtils.UserModelsToMailAddress(kvp.Value);

                    if (mailAddress.Count == 0) continue;

                    var html = mailUtils.MountHtmlLawTable(lawViewModel.LawInfoForEmail, kvp.Key, user.FullName);
                    html += mailUtils.RevokedByHtmlTable(newlawRevokedId);
                    html += mailUtils.RevokedFromHtmlTable(newlawRevokedId);

                    await mailFunctions.SendAsync("REQUISITO LEGAL REVOGADO: " + kvp.Key.Company.NomeFantasia + " - " + lawViewModel.LawInfoForEmail, html, mailAddress, kvp.Key.Company.CompanyId);
                }
            }
        }

        private async Task CopyCompanyLawFromRevokedAndAlteredLaws(IEnumerable<int> revokedAndAlteredLawIds, int newLawId, bool NotSendEmail, User loggedUser)
        {
            var newLawViewModel = bll.GetDataViewModel(bll.GetDataByID(newLawId));
            List<int> companyIdsWithNewLaw = new List<int>();

            foreach (var lawId in revokedAndAlteredLawIds)
            {
                var companyLaws = companyLawFunctions.GetCompanyLawByLawId(lawId);

                foreach (var companyLaw in companyLaws)
                {
                    if (companyIdsWithNewLaw.Contains(companyLaw.CompanyId)) continue;

                    companyLaw.CompanyLawId = null;
                    companyLaw.LawId = newLawId;
                    companyLaw.RenewDate = null;
                    companyLaw.WarningDate = null;

                    companyLaw.CompanyLawId = companyLawFunctions.Create(companyLaw);
                    companyLaw.Law = newLawViewModel;

                    companyIdsWithNewLaw.Add(companyLaw.CompanyId);

                    if (NotSendEmail) continue;

                    await SendCompanyLawEmail(companyLaw, newLawViewModel, loggedUser);
                }
            }
        }

        private async Task SendCompanyLawEmail(CompanyLawViewModel companyLaw, LawViewModel lawViewModel, User loggedUser)
        {
            var userModels = new List<DTO.User.UserModel>();
            userModels = mailUtils.GetCompanyAdministrators(companyLaw.CompanyId);
            var mailAddress = new List<string>();
            if (userModels != null && userModels.Count > 0) mailAddress = mailUtils.UserModelsToMailAddress(userModels);

            var companyModel = companyFunctions.GetDataByID(companyLaw.CompanyId);

            string htmlTable = mailUtils.MountHtmlLawTable(lawViewModel.LawInfoForEmail, companyLaw, loggedUser.FullName);

            await mailFunctions.SendAsync("REQUISITO LEGAL ADICIONADO: " + companyModel.NomeFantasia + " - " + lawViewModel.LawInfoForEmail, htmlTable, mailAddress, companyModel.CompanyId);
        }

        private async Task InsertLawRevokedBy(int lawId, List<int> lawRevokedFrom)
        {
            await bll.RemoveLawRevokedBy(lawId);
            await bll.InsertLawRevokedBy(lawId, lawRevokedFrom);
        }
        private async Task UpdateLawChangesBy(int lawId, List<LawChange> lawChanges)
        {
            lawChanges.ForEach(x => x.LawId = lawId);

            await lawChangeFunctions.DeleteByLawId(lawId);
            await lawChangeFunctions.CreateRange(lawChanges);
        }
        private async Task<List<int>> UpdateLawChangesFrom(int lawId, List<LawChange> lawChanges)
        {
            var r = await lawChangeFunctions.TryCreateRange(lawId, lawChanges);

            await lawChangeFunctions.DeleteRangeFromLawIdExcept(lawId, lawChanges.Select(x => x.LawId));

            return r;
        }

        public IActionResult GetLawAttachment(int lawId)
        {
            var lawAttachment = lawAttachmentFunctions.GetLawAttachmentByLawId(lawId);

            if (lawAttachment != null)
                if (!System.IO.File.Exists(System.IO.Path.Combine(this._hostingEnvironment.ContentRootPath, lawAttachment.FilePath)))
                    return NotFound();

            if (lawAttachment == null)
                return NotFound();

            var fullPath = System.IO.Path.Combine(this._hostingEnvironment.ContentRootPath, lawAttachment.FilePath);

            return File(System.IO.File.ReadAllBytes(fullPath), lawAttachment.ContentType, lawAttachment.FileName);
        }

        [HttpPost]
        public IActionResult QuickList([FromBody] string q)
        {
            return _List(new DTO.Shared.DataTablesAjaxPostModel() { search = new DTO.Shared.Search() { value = q }, length = 10, columns = new List<DTO.Shared.Column>() { new DTO.Shared.Column() { data = "LawNumber" }, new DTO.Shared.Column() { data = "LawTitle" } } }, new LawListFilterViewModel());
        }

        [HttpPost]
        [ActionName("List")]
        public IActionResult _List(DTO.Shared.DataTablesAjaxPostModel filter, LawListFilterViewModel filterViewModel)
        {
            int recordsTotal = 0;
            int recordsFiltered = 0;

            SetListFilter(filterViewModel, out string query, out List<SqlParameter> sqlParameters);

            //var d = this.lawViewFunctions.GetDataViewModel(this.lawViewFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered));
            var d = this.lawViewFunctions.GetDataViewModel(this.lawViewFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, query, sqlParameters.ToArray()));

            return Json(new
            {
                draw = filter.draw,
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            });
        }

        public void SetListFilter(LawListFilterViewModel filterViewModel, out string query, out List<SqlParameter> sqlParameters)
        {
            query = "LawIsDeleted = 0";
            sqlParameters = new List<SqlParameter>();

            if (filterViewModel.NotIncludeRevokedLaws.HasValue && filterViewModel.NotIncludeRevokedLaws.Value)
                query += $" AND LawRevokedBy IS NULL";

            if (!string.IsNullOrWhiteSpace(filterViewModel.NotGetThisLaws))
            {
                query += $" AND LawId NOT IN ({filterViewModel.NotGetThisLaws})";
            }

            if (filterViewModel.ForceDate.HasValue)
            {
                query += " AND LawForceDate < @ForceDate";
                sqlParameters.Add(new SqlParameter("@ForceDate", filterViewModel.ForceDate));
            }

            if (filterViewModel.SegmentoId.HasValue)
            {
                query += " AND LawSegmentoId = @SegmentoId";
                sqlParameters.Add(new SqlParameter("@SegmentoId", filterViewModel.SegmentoId));
            }

            if (filterViewModel.EsferaId.HasValue)
            {
                query += " AND LawEsferaId = @EsferaId";
                sqlParameters.Add(new SqlParameter("@EsferaId", filterViewModel.EsferaId));
            }

            if (filterViewModel.CountryId.HasValue)
            {
                query += " AND LawCountryId = @CountryId";
                sqlParameters.Add(new SqlParameter("@CountryId", filterViewModel.CountryId));
            }

            if (filterViewModel.StateId.HasValue)
            {
                query += " AND LawStateId = @StateId";
                sqlParameters.Add(new SqlParameter("@StateId", filterViewModel.StateId));
            }

            if (filterViewModel.CityId.HasValue)
            {
                query += " AND LawCityId = @CityId";
                sqlParameters.Add(new SqlParameter("@CityId", filterViewModel.CityId));
            }
        }

        [HttpPost]
        [ActionName("ListSelect")]
        public IActionResult ListSelect(DTO.Shared.DataTablesAjaxPostModel filter, int? companyId, int? segmentoId, int? esferaId, int? lawTypeId, int? orgaoId, bool? getAll)
        {
            int recordsTotal = 0;
            int recordsFiltered = 0;
            if (getAll.HasValue && getAll.Value)
                filter.length = null;

            List<int> lawIds = new List<int>();

            string sqlText = "";

            if (companyId.HasValue)
            {
                lawIds = companyLawFunctions.GetData().Where(c => c.CompanyId == companyId && !c.IsDeleted).Select(x => x.LawId).ToList();
                if (lawIds.Count > 0)
                    foreach (var lawId in lawIds)
                        sqlText += " AND LawId != " + lawId;
            }
            if (segmentoId.HasValue)
                sqlText += " AND LawSegmentoId = " + segmentoId;
            if (esferaId.HasValue)
                sqlText += " AND LawEsferaId = " + esferaId;
            if (lawTypeId.HasValue)
                sqlText += " AND LawTypeId = " + lawTypeId;
            if (orgaoId.HasValue)
                sqlText += " AND LawOrgaoId = " + orgaoId;

            var d = this.lawViewFunctions.GetDataViewModel(this.lawViewFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, "LawIsDeleted = 0 AND LawRevokedDate IS NULL" + sqlText, whereParameter: null));

            return Json(new
            {
                draw = filter.draw,
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            });
        }

        [HttpPost]
        [ActionName("RemoveLaw")]
        public async Task<IActionResult> RemoveLaw(int? lawId)
        {
            if (!lawId.HasValue) 
                return Json(new { success = false, message = "Houve um erro ao excluir o requisito legal." });

            if (await companyLawFunctions.LawIsInUse(lawId.Value))
                return Json(new { success = false, message = "Não é possível excluir este requisito legal pois ele esta sendo utilizado em uma Unidade de Negócio." });

            var model = bll.GetDataViewModel(bll.GetDataByID(lawId));

            if(await lawChangeFunctions.GetDataAsNoTracking(x => x.ChangedLawId == lawId).AnyAsync())
                return Json(new { success = false, message = "Não é possível excluir este requisito legal pois ele altera outro requisito legal." });

            if (await bll.GetDataAsNoTracking(x => x.RevokedById == lawId).AnyAsync())
                return Json(new { success = false, message = "Não é possível excluir este requisito legal pois ele revoga outro requisito legal." });

            if (await lawChangeFunctions.GetDataAsNoTracking(x => x.LawId == lawId).AnyAsync())
                return Json(new { success = false, message = "Não é possível excluir este requisito legal pois ele foi alterado por outro requisito legal." });

            if (!string.IsNullOrWhiteSpace(model.RevokedBy))
                return Json(new { success = false, message = "Não é possível excluir este requisito legal pois ele foi revogado por outro requisito legal." });

            var user = await userManager.GetUserAsync(User);
            this.bll.Delete(lawId.Value, user.Id);

            await mailFunctions.SendAsync($"Requisito legal de número: { model.Number} foi excluído por {user.FirstName} {user.LastName}", mailUtils.MountHtmlDeleteLawTable(model.LawInfoForEmail, model, $"{user.FirstName} {user.LastName}"), null);

            return Json(new { success = true, message = "Requisito legal excluído com sucesso." });
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
        [ActionName("CityList")]
        public IActionResult CityList()
        {
            return Json(cityFunctions.GetData().ToList().OrderBy(x => x.Name));
        }

        [HttpPost]
        [ActionName("CityListInState")]
        public IActionResult CityListInState(string uf)
        {
            //return Json(cityFunctions.GetData().ToList().Where(x => x.Uf == uf).OrderBy(x => x.Name));
            return Json(null);
        }

        [ActionName("Associate")]
        public IActionResult Associate(int? lawId)
        {

            if (!lawId.HasValue) return NotFound();

            //var companyWithLaw = this.companyLawFunctions.GetCompanyLawByLawId(lawId.Value);

            var knowlodgeCompanyIds = companyLawFunctions.GetCompanyIdByKnowlodgeLawId(lawId.Value);
            var applicableCompanyIds = companyLawFunctions.GetCompanyIdByApplicableLawId(lawId.Value);

            ViewData["KnowledgeCompany"] = companyLawFunctions.GetCompanyNameByCompanyIds(knowlodgeCompanyIds);

            ViewData["ApplicableCompany"] = companyLawFunctions.GetCompanyNameByCompanyIds(applicableCompanyIds);

            var lawModel = bll.GetDataViewModel(bll.GetDataByID(lawId));
            ViewData["City"] = lawModel.CityId.HasValue ? cityFunctions.GetDataByID(lawModel.CityId).Name : "-";
            ViewData["State"] = lawModel.StateId.HasValue ? stateFunctions.GetDataByID(lawModel.StateId).Name : "-";
            return View(lawModel);
        }

        public async Task<IActionResult> CompanyAttachments(int lawId) => await Task.Run(() => View(bll.GetDataByID(lawId)));

        [HttpPost]
        public async Task<IActionResult> ListCompanyAttachments(int lawId)
        {
            var d = companyLawAttachmentFunctions.GetCompanyLawAttachmentList(lawId);

            return await Task.Run(() => Json(new
            {
                recordsTotal = d.Count,
                recordsFiltered = d.Count,
                data = d
            }));
        }

        public async Task<IActionResult> GetLawViewById(int id) => await Task.Run(async () => Json(await context.LawView.SingleOrDefaultAsync(x => x.LawId == id)));

        public async Task<IActionResult> LoadAssociateCompanyListViewComponent(int lawId, bool valideByEsfera) => await Task.Run(() => ViewComponent(typeof(ViewComponents.LawManagement.AssociateCompanyListViewComponent), new { lawId, valideByEsfera }));

        public async Task<IActionResult> LoadLawChangeQuickView(int lawId) => await Task.Run(() => ViewComponent(typeof(ViewComponents.LawManagement.LawChangeQuickViewViewComponent), new { lawId }));

        #region [EXPORT]
        public async Task<IActionResult> Export(string startCreatedDate, string endCreatedDate, int? orgao, int? esfera, int? segmento, int? lawType, int? aplicabilidade, int? CountryId, int? StateId, int? CityId, int? questionThemeId, int? questionSubThemeId)
        {
            DateTime? _startCreatedDate = null, _endCreatedDate = null;

            if (DateTime.TryParseExact(startCreatedDate, new string[] { "dd/MM/yyyy", "dd/MM/yy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime o)) _startCreatedDate = o;
            if (DateTime.TryParseExact(endCreatedDate, new string[] { "dd/MM/yyyy", "dd/MM/yy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime _o)) _endCreatedDate = _o;

            var laws = lawViewFunctions.GetDataExport(_startCreatedDate, _endCreatedDate, orgao, segmento, esfera, lawType, aplicabilidade, CountryId, StateId, CityId, questionThemeId, questionSubThemeId);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var file = new FileInfo(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "Templates_Excel", "EmBranco.xlsx"));
            using (var excelPackage = new ExcelPackage(file))
            {
                using (var worksheet1 = excelPackage.Workbook.Worksheets.First())
                {
                    int i = 1;
                    foreach (var law in laws)
                    {
                        SetExportLawHeader(ref i, worksheet1);
                        int startIndex = i;
                        SetExportLawInfo(ref i, worksheet1, law);

                        SetExportCompanyLawHeader(ref i, worksheet1, law.CompanyName.Count);
                        SetExportCompanyLawInfo(ref i, worksheet1, law);

                        var tabela = worksheet1.Cells[$"A{startIndex}:S{(i - 1)}"];
                        var ultimaLinha = worksheet1.Cells[$"A{(i - 1)}:S{(i - 1)}"];

                        tabela.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        tabela.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        ultimaLinha.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    }

                    if (worksheet1.Dimension != null)
                    {
                        worksheet1.Cells[worksheet1.Dimension.Address].AutoFitColumns();

                        worksheet1.Column(1).Width = 15;
                        worksheet1.Column(2).Width = 15;
                        worksheet1.Column(1).Style.WrapText = true;
                        worksheet1.Column(2).Style.WrapText = true;

                        for (int j = 3; j <= 8; j++)
                        {
                            worksheet1.Column(j).Width = 100;
                            worksheet1.Column(j).Style.WrapText = true;
                        }

                        worksheet1.Column(18).Width = 100;
                        worksheet1.Column(18).Style.WrapText = true;
                    }

                    return await Task.Run<IActionResult>(() => File(excelPackage.GetAsByteArray(), "application/octet-stream", "Requisitos Legais.xlsx"));
                }
            }
        }

        private void SetExportLawHeader(ref int i, ExcelWorksheet worksheet1)
        {
            if (i != 1) i += 2;

            Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#8e8e8e");
            for (int j = 1; j <= 19; j++)
            {
                worksheet1.Cells[i, j].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet1.Cells[i, j].Style.Fill.BackgroundColor.SetColor(colFromHex);
                worksheet1.Cells[i, j].Style.Font.Color.SetColor(Color.White);
            }

            int c = 1;

            worksheet1.Cells[i, c++].Value = "Tipo";
            worksheet1.Cells[i, c++].Value = "Número";
            worksheet1.Cells[i, c++].Value = "Título";
            worksheet1.Cells[i, c++].Value = "Alterado pelo RLs";
            worksheet1.Cells[i, c++].Value = "Revogado pelo RL";
            worksheet1.Cells[i, c++].Value = "Altera os RLs";
            worksheet1.Cells[i, c++].Value = "Revoga os RLs";
            worksheet1.Cells[i, c++].Value = "Sumário";
            worksheet1.Cells[i, c++].Value = "País";
            worksheet1.Cells[i, c++].Value = "Estado";
            worksheet1.Cells[i, c++].Value = "Cidade";
            worksheet1.Cells[i, c++].Value = "Data de Publicação";
            worksheet1.Cells[i, c++].Value = "Data de Vigor";
            worksheet1.Cells[i, c++].Value = "Esfera";
            worksheet1.Cells[i, c++].Value = "Orgao";
            worksheet1.Cells[i, c++].Value = "Segmento";
            worksheet1.Cells[i, c++].Value = "Palavras-chaves";
            worksheet1.Cells[i, c++].Value = "Comentários";
            worksheet1.Cells[i, c++].Value = "Qtd. de Obrigações";
        }

        private void SetExportLawInfo(ref int i, ExcelWorksheet worksheet1, LawExportViewModel law)
        {
            i++;

            Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#d3d3d3");
            worksheet1.Cells[i, 1, i, 19].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet1.Cells[i, 1, i, 19].Style.Fill.BackgroundColor.SetColor(colFromHex);
            worksheet1.Cells[i, 1, i, 19].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            int c = 0;

            worksheet1.Cells[i, ++c].Value = law.LawTypeName;
            worksheet1.Cells[i, ++c].Value = law._Number;
            worksheet1.Cells[i, ++c].Value = law.Title;
            if (!string.IsNullOrWhiteSpace(law.RevokedBy)) worksheet1.Cells[i, c].Style.Font.Color.SetColor(Color.Red);

            worksheet1.Cells[i, ++c].Value = law.LawChangesBy;
            worksheet1.Cells[i, ++c].Value = string.IsNullOrWhiteSpace(law.RevokedBy) ? "" : $"Revogada em {(law._RevokedDate ?? "-")} por {(law.RevokedBy ?? "-")}";
            worksheet1.Cells[i, ++c].Value = law.LawChangesFrom;
            worksheet1.Cells[i, ++c].Value = law.RevokedFrom;
            worksheet1.Cells[i, ++c].Value = law.Summary;
            worksheet1.Cells[i, ++c].Value = law.CountryName;
            worksheet1.Cells[i, ++c].Value = law.StateName;
            worksheet1.Cells[i, ++c].Value = law.CityName;
            worksheet1.Cells[i, c].Style.Numberformat.Format = "dd/mm/yyyy";
            worksheet1.Cells[i, ++c].Value = law.PublishDate;
            worksheet1.Cells[i, c].Style.Numberformat.Format = "dd/mm/yyyy";
            worksheet1.Cells[i, ++c].Value = law.ForceDate;
            worksheet1.Cells[i, ++c].Value = law.EsferaName;
            worksheet1.Cells[i, ++c].Value = law.OrgaoName;
            worksheet1.Cells[i, ++c].Value = law.SegmentoName;
            worksheet1.Cells[i, ++c].Value = law.Keywords;
            worksheet1.Cells[i, ++c].Value = law.Comments;
            worksheet1.Cells[i, ++c].Value = law.LawVerificationCount;

            worksheet1.Row(i).Height = 70;
        }

        private void SetExportCompanyLawHeader(ref int i, ExcelWorksheet worksheet1, int companyCount)
        {
            i++;

            Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#8e8e8e");

            if (companyCount < 6) companyCount = 6;

            worksheet1.Cells[i, 1, i + companyCount, 1].Merge = true;
            worksheet1.Cells[i, 1, i + companyCount, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet1.Cells[i, 1, i + companyCount, 1].Style.Fill.BackgroundColor.SetColor(colFromHex);
            worksheet1.Cells[i, 1, i + companyCount, 1].Style.Font.Color.SetColor(Color.White);
            worksheet1.Cells[i, 1, i + companyCount, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            worksheet1.Cells[i, 1, i + companyCount, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            worksheet1.Cells[i, 1].Value = "Unidades Legais Associadas";
            worksheet1.Cells[i, 1].Style.TextRotation = 180;

            for (int j = 2; j <= 19; j++)
            {
                worksheet1.Cells[i, j].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet1.Cells[i, j].Style.Fill.BackgroundColor.SetColor(colFromHex);
                worksheet1.Cells[i, j].Style.Font.Color.SetColor(Color.White);
            }

            worksheet1.Cells[i, 2].Value = "CNPJ";
            worksheet1.Cells[i, 3].Value = "Razão Social";
            worksheet1.Cells[i, 4].Value = "Aplicabilidade";
        }

        private void SetExportCompanyLawInfo(ref int i, ExcelWorksheet worksheet1, LawExportViewModel law)
        {
            i++;
            for (int j = 0; j < law.CompanyName.Count; j++)
            {
                worksheet1.Row(i).Height = 20;

                worksheet1.Cells[i, 2].Value = law.CompanyCNPJ[j];
                worksheet1.Cells[i, 3].Value = law.CompanyName[j];
                worksheet1.Cells[i, 4].Value = law.LawApplicationTypeName[j];
                i++;
            }

            if (law.CompanyName.Count < 6) i = i + 6 - law.CompanyName.Count;
        }

        public async Task<IActionResult> ExportAlteredAndRevoked(int? orgao, int? esfera, int? segmento, int? lawType, int? countryId, int? stateId, int? cityId)
        {
            var laws = lawViewFunctions.GetData(x =>
                (!orgao.HasValue || x.LawOrgaoId == orgao) &&
                (!segmento.HasValue || x.LawSegmentoId == segmento) &&
                (!esfera.HasValue || x.LawEsferaId == esfera) &&
                (!lawType.HasValue || x.LawTypeId == lawType) &&
                (!countryId.HasValue || x.LawCountryId == countryId) &&
                (!stateId.HasValue || x.LawStateId == stateId) &&
                (!cityId.HasValue || x.LawCityId == cityId)
            );

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var file = new FileInfo(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "Templates_Excel", "EmBranco.xlsx"));
            using (var excelPackage = new ExcelPackage(file))
            {
                using (var worksheet1 = excelPackage.Workbook.Worksheets.First())
                {
                    int i = 1;
                    foreach (var law in laws)
                    {
                        SetExportLawAlteredAndRevokedHeader(ref i, worksheet1);
                        int startIndex = i;
                        SetExportLawAlteredAndRevokedInfo(ref i, worksheet1, law);

                        var alteredByIds = context.LawChange.Where(x => x.ChangedLawId == law.LawId).AsNoTracking().Select(x => x.LawId);
                        var alteredBy = await context.LawView.Where(x => alteredByIds.Contains(x.LawId)).AsNoTracking().ToListAsync();
                        SetExportCompanyLawAlteredAndRevokedHeader(ref i, worksheet1, alteredBy.Count, "Requisitos legais alterados por");
                        SetExportCompanyLawAlteredAndRevokedInfo(ref i, worksheet1, alteredBy);

                        var tabela = worksheet1.Cells[$"A{startIndex}:S{(i - 1)}"];
                        var ultimaLinha = worksheet1.Cells[$"A{(i - 1)}:S{(i - 1)}"];

                        tabela.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        tabela.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        ultimaLinha.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    }

                    if (worksheet1.Dimension != null)
                    {
                        worksheet1.Cells[worksheet1.Dimension.Address].AutoFitColumns();

                        worksheet1.Column(1).Width = 15;
                        worksheet1.Column(2).Width = 15;
                        worksheet1.Column(1).Style.WrapText = true;
                        worksheet1.Column(2).Style.WrapText = true;

                        worksheet1.Column(3).Width = 100;
                        worksheet1.Column(3).Style.WrapText = true;
                        worksheet1.Column(4).Width = 100;
                        worksheet1.Column(4).Style.WrapText = true;
                    }

                    return await Task.Run<IActionResult>(() => File(excelPackage.GetAsByteArray(), "application/octet-stream", "Requisitos Legais.xlsx"));
                }
            }
        }

        private void SetExportLawAlteredAndRevokedHeader(ref int i, ExcelWorksheet worksheet1)
        {
            if (i != 1) i += 2;

            Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#8e8e8e");
            for (int j = 1; j <= 7; j++)
            {
                worksheet1.Cells[i, j].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet1.Cells[i, j].Style.Fill.BackgroundColor.SetColor(colFromHex);
                worksheet1.Cells[i, j].Style.Font.Color.SetColor(Color.White);
            }

            int c = 1;

            worksheet1.Cells[i, c, i + 1, c].Merge = true;
            worksheet1.Cells[i, c, i + 1, c].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet1.Cells[i, c, i + 1, c].Style.Fill.BackgroundColor.SetColor(colFromHex);
            worksheet1.Cells[i, c, i + 1, c].Style.Font.Color.SetColor(Color.White);
            worksheet1.Cells[i, c, i + 1, c].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            worksheet1.Cells[i, c, i + 1, c].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            worksheet1.Cells[i, 1].Value = "Requisito Legal";
            worksheet1.Cells[i, 1].Style.TextRotation = 180;

            worksheet1.Cells[i, ++c].Value = "Tipo";
            worksheet1.Cells[i, ++c].Value = "Número";
            worksheet1.Cells[i, ++c].Value = "Título";
            worksheet1.Cells[i, ++c].Value = "Orgão";
            worksheet1.Cells[i, ++c].Value = "Data de Vigor";
            worksheet1.Cells[i, ++c].Value = "Esfera";
        }

        private void SetExportLawAlteredAndRevokedInfo(ref int i, ExcelWorksheet worksheet1, LawView law)
        {
            i++;

            Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#d3d3d3");
            worksheet1.Cells[i, 1, i, 19].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet1.Cells[i, 1, i, 19].Style.Fill.BackgroundColor.SetColor(colFromHex);
            worksheet1.Cells[i, 1, i, 19].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            int c = 1;
            worksheet1.Cells[i, ++c].Value = law.LawTypeName;
            worksheet1.Cells[i, ++c].Value = law._LawNumber;
            worksheet1.Cells[i, ++c].Value = law.LawTitle;
            worksheet1.Cells[i, ++c].Value = law.LawOrgaoName;
            worksheet1.Cells[i, c].Style.Numberformat.Format = "dd/mm/yyyy";
            worksheet1.Cells[i, ++c].Value = law._LawForceDate;
            worksheet1.Cells[i, ++c].Value = law.LawEsferaName;

            worksheet1.Row(i).Height = 70;
        }

        private void SetExportCompanyLawAlteredAndRevokedHeader(ref int i, ExcelWorksheet worksheet1, int rowLength, string title)
        {
            i++;

            Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#8e8e8e");

            if (rowLength < 6) rowLength = 6;

            worksheet1.Cells[i, 1, i + rowLength, 1].Merge = true;
            worksheet1.Cells[i, 1, i + rowLength, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet1.Cells[i, 1, i + rowLength, 1].Style.Fill.BackgroundColor.SetColor(colFromHex);
            worksheet1.Cells[i, 1, i + rowLength, 1].Style.Font.Color.SetColor(Color.White);
            worksheet1.Cells[i, 1, i + rowLength, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            worksheet1.Cells[i, 1, i + rowLength, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            worksheet1.Cells[i, 1].Value = title;
            worksheet1.Cells[i, 1].Style.TextRotation = 180;

            for (int j = 2; j <= 7; j++)
            {
                worksheet1.Cells[i, j].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet1.Cells[i, j].Style.Fill.BackgroundColor.SetColor(colFromHex);
                worksheet1.Cells[i, j].Style.Font.Color.SetColor(Color.White);
            }

            int c = 1;
            worksheet1.Cells[i, ++c].Value = "Tipo";
            worksheet1.Cells[i, ++c].Value = "Número";
            worksheet1.Cells[i, ++c].Value = "Título";
            worksheet1.Cells[i, ++c].Value = "Orgão";
            worksheet1.Cells[i, ++c].Value = "Data de Vigor";
            worksheet1.Cells[i, ++c].Value = "Esfera";
        }

        private void SetExportCompanyLawAlteredAndRevokedInfo(ref int i, ExcelWorksheet worksheet1, List<LawView> law)
        {
            i++;
            for (int j = 0; j < law.Count; j++)
            {
                worksheet1.Row(i).Height = 20;

                var c = 1;

                worksheet1.Cells[i, ++c].Value = law[j].LawTypeName;
                worksheet1.Cells[i, ++c].Value = law[j]._LawNumber;
                worksheet1.Cells[i, ++c].Value = law[j].LawTitle;
                worksheet1.Cells[i, ++c].Value = law[j].LawOrgaoName;
                worksheet1.Cells[i, ++c].Value = law[j]._LawForceDate;
                worksheet1.Cells[i, ++c].Value = law[j].LawEsferaName;
                i++;
            }

            if (law.Count < 6) i = i + 6 - law.Count;
        }
        #endregion
    }
}