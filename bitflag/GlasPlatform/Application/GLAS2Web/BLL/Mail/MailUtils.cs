using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Utils;
using DAL;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;

namespace BLL.Mail
{
    public class MailUtils
    {
        private readonly UserManager<DAL.Identity.User> userManager;
        private readonly BLL.User.UserFunctions userFunctions;
        private readonly BLL.Company.CompanyLawActionFunctions companyLawActionFunctions;
        private readonly BLL.Permission.CompanyUserRoleFunctions companyUserRoleFunctions;
        private readonly BLL.Company.CompanyLawCommentFunctions companyLawCommentFunctions;
        private readonly BLL.Company.CompanyLawActionCommentFunctions companyLawActionCommentFunctions;
        private readonly BLL.Company.CompanyUserFunctions companyUserFunctions;
        private readonly BLL.Law.LawConclusionStatusFunctions lawConclusionStatusFunctions;
        private readonly BLL.Law.LawApplicationTypeFunctions lawApplicationTypeFunctions;
        private readonly BLL.Company.CompanyLawActionStatusFunctions companyLawActionStatusFunctions;
        private readonly BLL.Law.LawFunctions lawFunctions;
        private readonly BLL.Law.LawChangeFunctions lawChangeFunctions;

        public MailUtils(DAL.GLAS2Context context, UserManager<DAL.Identity.User> userManager)
        {
            this.userFunctions = new BLL.User.UserFunctions(context, userManager);
            this.companyLawActionFunctions = new BLL.Company.CompanyLawActionFunctions(context);
            this.companyUserRoleFunctions = new BLL.Permission.CompanyUserRoleFunctions(context);
            this.companyLawCommentFunctions = new BLL.Company.CompanyLawCommentFunctions(context, userManager);
            this.companyLawActionCommentFunctions = new BLL.Company.CompanyLawActionCommentFunctions(context);
            this.companyUserFunctions = new BLL.Company.CompanyUserFunctions(context);
            this.companyLawActionStatusFunctions = new BLL.Company.CompanyLawActionStatusFunctions(context);
            this.lawFunctions = new BLL.Law.LawFunctions(context);
            this.lawConclusionStatusFunctions = new BLL.Law.LawConclusionStatusFunctions(context);
            this.lawApplicationTypeFunctions = new BLL.Law.LawApplicationTypeFunctions(context);
            this.userManager = userManager;
            this.lawChangeFunctions = new Law.LawChangeFunctions(context);
        }

        public DTO.User.UserModel GetSupervisorInCompanyLawAction(int companyLawActionId)
        {
            var companyLawAction = companyLawActionFunctions.GetDataByID(companyLawActionId);
            if (companyLawAction == null) return null;
            if (!companyLawAction.SupervisorId.HasValue) return null;

            var user = userFunctions.GetDataByID(companyLawAction.SupervisorId);
            if (user == null) return null;
            if (user.IsActive == false || user.IsDeleted == true) return null;

            return userFunctions.GetDataViewModel(user);
        }

        public DTO.User.UserModel GetResponsibleInCompanyLawAction(int companyLawActionId)
        {
            var companyLawAction = companyLawActionFunctions.GetDataByID(companyLawActionId);
            if (companyLawAction == null) return null;
            if (!companyLawAction.ResponsibleId.HasValue) return null;

            var user = userFunctions.GetDataByID(companyLawAction.ResponsibleId);
            if (user == null) return null;
            if (user.IsActive == false || user.IsDeleted == true) return null;

            return userFunctions.GetDataViewModel(user);
        }

        public List<DTO.User.UserModel> GetCompanyAdministrators(int companyId)
        {
            var companyUsers = companyUserRoleFunctions.UsersInCompanyByRole(companyId, new List<string>() { BLL.User.ProfileNames.ClienteAdministrador });
            if (companyUsers.Count == 0) return new List<DTO.User.UserModel>();

            var userModels = new List<DTO.User.UserModel>();
            foreach (var companyUser in companyUsers)
            {
                var user = userFunctions.GetDataByID(companyUser.UserId);
                if (user == null) continue;
                if (user.IsActive == false || user.IsDeleted == true) continue;
                userModels.Add(userFunctions.GetDataViewModel(user));
            }

            return userModels;
        }

        public List<DTO.User.UserModel> GetCompanyAdminisAndSupervisors(int companyId)
        {
            var companyUsers = companyUserRoleFunctions.UsersInCompanyByRole(companyId, new List<string>() { BLL.User.ProfileNames.ClienteAdministrador, BLL.User.ProfileNames.ClienteSupervisor });
            if (companyUsers.Count == 0) return new List<DTO.User.UserModel>();

            var userModels = new List<DTO.User.UserModel>();
            foreach (var companyUser in companyUsers)

            {
                var user = userFunctions.GetDataByID(companyUser.UserId);
                if (user == null) continue;
                if (user.IsActive == false || user.IsDeleted == true) continue;
                userModels.Add(userFunctions.GetDataViewModel(user));
            }

            return userModels;
        }

        public List<DTO.User.UserModel> GetCompaniesAdminisAndSupers(List<DTO.Company.CompanyLawViewModel> companiesModel)
        {
            var companyUsers = new List<DTO.Company.CompanyUser>();

            foreach (var company in companiesModel)
            {
                if (company.IsActive == false) continue;
                companyUsers.AddRange(companyUserRoleFunctions.UsersInCompanyByRole(company.CompanyId, new List<string>() { BLL.User.ProfileNames.ClienteAdministrador, BLL.User.ProfileNames.ClienteSupervisor }));
            }

            if (companyUsers.Count == 0) return new List<DTO.User.UserModel>();

            var userModels = new List<DTO.User.UserModel>();
            foreach (var companyUser in companyUsers)
            {
                var user = userFunctions.GetDataByID(companyUser.UserId);
                if (user == null) continue;
                if (user.IsActive == false || user.IsDeleted == true) continue;
                userModels.Add(userFunctions.GetDataViewModel(user));
            }

            return userModels;
        }

        public List<string> UserModelsToMailAddress(List<DTO.User.UserModel> userModels)
        {
            var mailAddress = new List<string>();
            foreach (var userModel in userModels)
            {
                if (userModel == null) continue;
                if (userModel.IsActive == false) continue;

                if (mailAddress.Contains(userModel.Email)) continue;

                mailAddress.Add(userModel.Email);
            }

            return mailAddress;
        }

        public string MountHtmlLawTable(string law, DTO.Company.CompanyLawViewModel model, string userName)
        {
            string application, status;
            if (model.LawConclusionStatusId == lawConclusionStatusFunctions.GetData().FirstOrDefault(x => x.ExternalCode == "COMPLETED").LawConclusionStatusId) status = "<p style='color:green;'>Concluído</p>";
            else if (model.LawConclusionStatusId == lawConclusionStatusFunctions.GetData().FirstOrDefault(x => x.ExternalCode == "NOTCOMPLETED").LawConclusionStatusId) status = "<p style='color:red;'>Não Concluído</p>";
            else status = "-";

            if (model.LawApplicationTypeId == lawApplicationTypeFunctions.GetData().FirstOrDefault(x => x.ExternalCode == "KNOWLEDGE").LawApplicationTypeId)
            {
                application = "<p style='color:blue;'>Conhecimento</p>";
                status = "-";
            }
            else if (model.LawApplicationTypeId == lawApplicationTypeFunctions.GetData().FirstOrDefault(x => x.ExternalCode == "APPLICABLE").LawApplicationTypeId) application = "<p style='color:green;'>Aplicável</p>";
            else application = "-";
            if (model.Law.RevokedDate != null) status = "<p style='color:red;'>Revogada</p>";

            var htmlTable =
                    "<br><br>" +
                    "<table class='table-rounded' align='center' style='width:60%;'>" +
                    "<tbody>" +
                    "<tr>" +
                    "<th colspan = '4' style = 'vertical-align:middle;' ><b>" + law + "</b></th>" +
                    "</tr>" +
                    "</tbody>" +
                    "</table>" +
                    "<br>" +
                    "<table class='table-rounded' align='center' style='width:60%;'>" +
                    "<tbody>" +
                    "<tr>" +
                    "<th style = 'vertical-align:middle;' colspan = '4' >" + model.Law.Title + "</th>" +
                    "</tr>" +
                    "<tbody>" +
                    "</table>" +
                    "<br>" +
                    "<table align='center' style ='width:60%; border-collapse: separate; border-spacing: 0; empty-cells: show;'>" +
                    "<tr>";
            if (model.Law.EsferaName == null)
                htmlTable += "<th class='table-square' style = 'vertical-align:bottom; width:25%;' ><small style='float:left;'>Esfera Legislativa</small><p>-</p></th>";
            else htmlTable += "<th class='table-square' style = 'vertical-align:bottom; width:25%;' ><small style='float:left;'>Esfera Legislativa</small><p>" + model.Law.EsferaName + "</p></th>";
            if (model.Law.Keywords == null)
                htmlTable += "<th class='table-square' style = 'vertical-align:bottom; width:25%;' ><small style='float:left;'>Palavra Chave</small><p>-</p></th>";
            else htmlTable += "<th class='table-square' style = 'vertical-align:bottom; width:25%;' ><small style='float:left;'>Palavra Chave</small><p>" + model.Law.Keywords + "</p></th>";
            if (model.Law.ForceDate == null)
                htmlTable += "<th class='table-square' style = 'vertical-align:bottom; width:25%;' ><small style='float:left;'>Data Vigor</small><p>-</p></th>";
            else htmlTable += "<th class='table-square' style = 'vertical-align:bottom; width:25%;' ><small style='float:left;'>Data Vigor</small><p>" + model.Law.ForceDate + "</p></th>";
            htmlTable += "<th class='table-square' style = 'vertical-align:bottom; width:25%;' ><small style='float:left;'>Aplicabilidade</small>" + application + "</th>" +
                    "</tr>" +
                    "</table>" +
                    "<br>" +
                    "<table class='table-rounded' align='center' style='width:60%;'>" +
                    "<tbody>" +
                    "<tr>" +
                    "<td colspan = '4' style='text-align:center;'>" + model.Law.Summary + "</td>" +
                    "</tr>" +
                    "<tbody>" +
                    "</table>";

            if (!string.IsNullOrWhiteSpace(model.Law.Comments))
            {
                htmlTable += "<table class='table-rounded' align='center' style='width:60%; margin-top: 5px;'>" +
                    "<tbody>" +
                    "<tr>" +
                   "<th colspan='4' style='vertical-align:middle;'><small style='float:left;'>Comentários</small><br/><p>" + model.Law.Comments.Replace("\n", "<br />") + "</p></th>" +
                   "</tr>" +
                   "<tbody>" +
                   "</table>";
            }

            htmlTable +=
                    "<table class='table-rounded' align='center' style='border-collapse: separate; border-spacing: 0; margin-top: 5px; width:60%;'>" +
                    "<tbody>" +
                    "<tr>" +
                    "<th style='vertical-align:middle; width:50%;'><small style='float: left;'>Status</small>" + status + "</th>" +
                    "<th style = 'vertical-align:middle; width:50%; border-left:1px solid;'><small style='float:left;'>Modificado Por</small><p>" + userName + "</p></th>" +
                    "</tr>" +
                    "<tbody>" +
                    "</table>";
            return htmlTable;

        }

        public string MountHtmlLawTable(string law, DTO.Company.CompanyLawViewModel model)
        {
            string application, status;
            if (model.LawConclusionStatusId == lawConclusionStatusFunctions.GetData().FirstOrDefault(x => x.ExternalCode == "COMPLETED").LawConclusionStatusId) status = "<p style='color:green;'>Concluído</p>";
            else if (model.LawConclusionStatusId == lawConclusionStatusFunctions.GetData().FirstOrDefault(x => x.ExternalCode == "NOTCOMPLETED").LawConclusionStatusId) status = "<p style='color:red;'>Não Concluído</p>";
            else status = "-";

            if (model.LawApplicationTypeId == lawApplicationTypeFunctions.GetData().FirstOrDefault(x => x.ExternalCode == "KNOWLEDGE").LawApplicationTypeId)
            {
                application = "<p style='color:blue;'>Conhecimento</p>";
                status = "-";
            }
            else if (model.LawApplicationTypeId == lawApplicationTypeFunctions.GetData().FirstOrDefault(x => x.ExternalCode == "APPLICABLE").LawApplicationTypeId) application = "<p style='color:green;'>Aplicável</p>";
            else application = "-";
            if (model.Law.RevokedDate != null) status = "<p style='color:red;'>Revogada</p>";

            var htmlTable =
                    "<br><br>" +
                    "<table class='table-rounded' align='center' style='width:60%;'>" +
                    "<tbody>" +
                    "<tr>" +
                    "<th colspan = '4' style = 'vertical-align:middle;' ><b>" + law + "</b></th>" +
                    "</tr>" +
                    "</tbody>" +
                    "</table>" +
                    "<br>" +
                    "<table class='table-rounded' align='center' style='width:60%;'>" +
                    "<tbody>" +
                    "<tr>" +
                    "<th style = 'vertical-align:middle;' colspan = '4' >" + model.Law.Title + "</th>" +
                    "</tr>" +
                    "<tbody>" +
                    "</table>" +
                    "<br>" +
                    "<table align='center' style ='width:60%; border-collapse: separate; border-spacing: 0; empty-cells: show;'>" +
                    "<tr>";
            if (model.Law.EsferaName == null)
                htmlTable += "<th class='table-square' style = 'vertical-align:bottom; width:25%;' ><small style='float:left;'>Esfera Legislativa</small><p>-</p></th>";
            else htmlTable += "<th class='table-square' style = 'vertical-align:bottom; width:25%;' ><small style='float:left;'>Esfera Legislativa</small><p>" + model.Law.EsferaName + "</p></th>";
            if (model.Law.Keywords == null)
                htmlTable += "<th class='table-square' style = 'vertical-align:bottom; width:25%;' ><small style='float:left;'>Palavra Chave</small><p>-</p></th>";
            else htmlTable += "<th class='table-square' style = 'vertical-align:bottom; width:25%;' ><small style='float:left;'>Palavra Chave</small><p>" + model.Law.Keywords + "</p></th>";
            if (model.Law.ForceDate == null)
                htmlTable += "<th class='table-square' style = 'vertical-align:bottom; width:25%;' ><small style='float:left;'>Data Vigor</small><p>-</p></th>";
            else htmlTable += "<th class='table-square' style = 'vertical-align:bottom; width:25%;' ><small style='float:left;'>Data Vigor</small><p>" + model.Law.ForceDate + "</p></th>";
            htmlTable += "<th class='table-square' style = 'vertical-align:bottom; width:25%;' ><small style='float:left;'>Aplicabilidade</small>" + application + "</th>" +
                    "</tr>" +
                    "</table>" +
                    "<br>" +
                    "<table class='table-rounded' align='center' style='width:60%;'>" +
                    "<tbody>" +
                    "<tr>" +
                    "<td colspan = '4' style='text-align:center;'>" + model.Law.Summary + "</td>" +
                    "</tr>" +
                    "<tbody>" +
                    "</table>";
            return htmlTable;

        }


        public string MountHtmlDeleteLawTable(string law, DTO.Law.LawViewModel model, string userName)
        {
            var htmlTable =
                    "<br><br>" +
                    "<table class='table-rounded' align='center' style='width:60%;'>" +
                    "<tbody>" +
                    "<tr>" +
                    "<th colspan = '4' style = 'vertical-align:middle;' ><b>" + law + "</b></th>" +
                    "</tr>" +
                    "</tbody>" +
                    "</table>" +
                    "<br>" +
                    "<table class='table-rounded' align='center' style='width:60%;'>" +
                    "<tbody>" +
                    "<tr>" +
                    "<th style = 'vertical-align:middle;' colspan = '4' >" + model.Title + "</th>" +
                    "</tr>" +
                    "<tbody>" +
                    "</table>" +
                    "<br>" +
                    "<table align='center' style ='width:60%; border-collapse: separate; border-spacing: 0; empty-cells: show;'>" +
                    "<tr>";
            if (model.EsferaName == null)
                htmlTable += "<th class='table-square' style = 'vertical-align:bottom; width:25%;' ><small style='float:left;'>Esfera Legislativa</small><p>-</p></th>";
            else htmlTable += "<th class='table-square' style = 'vertical-align:bottom; width:25%;' ><small style='float:left;'>Esfera Legislativa</small><p>" + model.EsferaName + "</p></th>";
            if (model.Keywords == null)
                htmlTable += "<th class='table-square' style = 'vertical-align:bottom; width:25%;' ><small style='float:left;'>Palavra Chave</small><p>-</p></th>";
            else htmlTable += "<th class='table-square' style = 'vertical-align:bottom; width:25%;' ><small style='float:left;'>Palavra Chave</small><p>" + model.Keywords + "</p></th>";
            if (model.ForceDate == null)
                htmlTable += "<th class='table-square' style = 'vertical-align:bottom; width:25%;' ><small style='float:left;'>Data Vigor</small><p>-</p></th>";
            else htmlTable += "<th class='table-square' style = 'vertical-align:bottom; width:25%;' ><small style='float:left;'>Data Vigor</small><p>" + model.ForceDate + "</p></th>";
            htmlTable += "</tr>" +
                    "</table>" +
                    "<br>" +
                    "<table class='table-rounded' align='center' style='width:60%;'>" +
                    "<tbody>" +
                    "<tr>" +
                    "<td colspan = '4' style='text-align:center;'>" + model.Summary + "</td>" +
                    "</tr>" +
                    "<tbody>" +
                    "</table>";

            if (!string.IsNullOrWhiteSpace(model.Comments))
            {
                htmlTable += "<table class='table-rounded' align='center' style='width:60%; margin-top: 5px;'>" +
                    "<tbody>" +
                    "<tr>" +
                   "<th colspan='4' style='vertical-align:middle;'><small style='float:left;'>Comentários</small><br/><p>" + model.Comments.Replace("\n", "<br />") + "</p></th>" +
                   "</tr>" +
                   "<tbody>" +
                   "</table>";
            }

            htmlTable +=
                    "<table class='table-rounded' align='center' style='border-collapse: separate; border-spacing: 0; margin-top: 5px; width:60%;'>" +
                    "<tbody>" +
                    "<tr>" +
                    "<th style = 'vertical-align:middle; width:50%; border-left:1px solid;'><small style='float:left;'>Removido Por</small><p>" + userName + "</p></th>" +
                    "</tr>" +
                    "<tbody>" +
                    "</table>";
            return htmlTable;

        }


        public string CompanyLawCommentTable(int companyLawId, int companyLawCommentId)
        {
            DateTime commentDate;
            int recordsTotal;
            int recordsFiltered;
            var d = this.companyLawCommentFunctions.GetDataViewModel(this.companyLawCommentFunctions.GetDataFiltered(new DTO.Shared.DataTablesAjaxPostModel(), out recordsTotal, out recordsFiltered, "CompanyLawId = @CompanyLawId AND IsDeleted = 0", new System.Data.SqlClient.SqlParameter("@CompanyLawId", companyLawId)));

            string htmlTable = "<br>" +
                "COMENTÁRIOS: ";
            foreach (var comment in d.OrderByDescending(x => x.CreatedDate))
            {
                DateTime.TryParse(comment.CreatedDate, out commentDate);
                htmlTable +=
                "<br>" +
                "<table align='center' style='width:60%;'>" +
                "<thead>" +
                "<tr>" +
                "<th class='table-top-rounded' style = 'vertical-align:middle;' >" + userFunctions.GetDataByID(comment.AuthorId).FullName + "</th>" +
                "</tr>" +
                "</thead>" +
                "<tbody>" +
                "<tr>" +
                "<td class='table-bottom-rounded' style='text-align:center;'><p style='float:left;'>" + comment.Text + "</p><p style='float:right;'>" + commentDate.ToBrazilianDateTimeFormat() + "</p></td>" +
                "</tr>" +
                "</tbody>" +
                "</table>";
            }
            return htmlTable;

        }

        public string CompanyLawActionCommentTable(int companyLawActionId, int companyLawActionCommentId)
        {
            DateTime commentDate;
            int recordsTotal;
            int recordsFiltered;
            var d = this.companyLawActionCommentFunctions.GetDataViewModel(this.companyLawActionCommentFunctions.GetDataFiltered(new DTO.Shared.DataTablesAjaxPostModel(), out recordsTotal, out recordsFiltered, "CompanyLawActionId = @CompanyLawActionId AND IsDeleted = 0", new System.Data.SqlClient.SqlParameter("@CompanyLawActionId", companyLawActionId)));

            string htmlTable = "<br>" +
                "COMENTÁRIOS: ";
            foreach (var comment in d.OrderByDescending(x => x.CreatedDate))
            {
                DateTime.TryParse(comment.CreatedDate, out commentDate);
                htmlTable +=
                "<br>" +
                "<table align='center' style='width:60%;'>" +
                "<thead>" +
                "<tr>" +
                "<th class='table-top-rounded style = 'vertical-align:middle;' >" + userFunctions.GetDataByID(comment.AuthorId).FullName + "</th>" +
                "</tr>" +
                "</thead>" +
                "<tbody>" +
                "<tr>" +
                "<td class='table-bottom-rounded' style='text-align:center;'><p style='float:left;'>" + comment.Text + "</p><p style='float:right;'>" + commentDate.ToBrazilianDateTimeFormat() + "</p></td>" +
                "</tr>" +
                "</tbody>" +
                "</table>";
            }
            return htmlTable;
        }

        public string CompanyLawActionTable(int companyLawActionId)
        {
            var companyLawActionModel = companyLawActionFunctions.GetDataByID(companyLawActionId);
            var companyLawActionViewModel = companyLawActionFunctions.GetDataViewModel(companyLawActionModel);

            string stats;
            if (companyLawActionViewModel.CompanyLawActionStatusId == companyLawActionStatusFunctions.GetData().FirstOrDefault(x => x.ExternalCode == "NOTCOMPLETED").CompanyLawActionStatusId) stats = "<p style='color:orange;'>Pendente</p>";
            else if (companyLawActionViewModel.CompanyLawActionStatusId == companyLawActionStatusFunctions.GetData().FirstOrDefault(x => x.ExternalCode == "COMPLETED").CompanyLawActionStatusId) stats = "<p style='color:green;'>Concluída</p>";
            else stats = "<p style='color:black;'>-</p>";
            if (companyLawActionModel.IsDeleted) stats = "<p style='color:red;'>EXCLUÍDA</p>";

            string htmlTable = "<br>" +
                    "DADOS DA AÇÃO: " +
                    "<br><br>" +
                    "<table  style='width:60%;'  align='center' class='table-top-rounded'>" +
                    "<thead>" +
                    "<tr>" +
                    "<th colspan='3' style = 'vertical-align:middle; ' >" + companyLawActionViewModel.Name + "</th>" +
                    "</tr>" +
                    "</thead>" +
                    "</table>" +
                    "<table  style='width:60%;'  align='center'>" +
                    "<tbody>" +
                    "<tr>" +
                    "<th colspan='1' class='table-square' style = 'vertical-align:middle; width:33%;' ><small style='float:left;'>Data de criação</small><p>" + companyLawActionViewModel.RegistrationDate + "</p></th>" +
                    "<th colspan='1' class='table-square' style = 'vertical-align:middle; width:34%;' ><small style='float:left;'>Data de conclusão</small><p>" + companyLawActionViewModel.TargetDate + "</p></th>" +
                    "<th colspan='1' class='table-square' style = 'vertical-align:middle; width:33%;' ><small style='float:left;'>Tipo</small><p>" + companyLawActionViewModel.CompanyLawActionTypeName + "</p></th>" +
                    "</tr>" +
                    "<tr>" +
                    "<th colspan='1' class='table-square' style = 'vertical-align:middle; width:33%;' ><small style='float:left;'>Status</small><p>" + stats + "</p></th>";
            if (companyLawActionViewModel.SupervisorName == null)
                htmlTable += "<th colspan='1' class='table-square' style = 'vertical-align:middle; width:34%;' ><small style='float:left;'>Operador</small><p>-</p></th>";
            else
                htmlTable += "<th colspan='1' class='table-square' style = 'vertical-align:middle; width:34%;' ><small style='float:left;'>Operador</small><p>" + companyLawActionViewModel.SupervisorName + "</p></th>";
            if (companyLawActionViewModel.ResponsibleName == null)
                htmlTable += "<th colspan='1' class='table-square' style = 'vertical-align:middle; width:33%;' ><small style='float:left;'>Responsável</small><p>-</p></th>";
            else
                htmlTable += "<th colspan='1' class='table-square' style = 'vertical-align:middle; width:33%;' ><small style='float:left;'>Responsável</small><p>" + companyLawActionViewModel.ResponsibleName + "</p></th>";

            htmlTable += "</tr>" +
                    "</tbody>" +
                    "</table>";
            return htmlTable;
        }

        public string UserTable(int userId)
        {

            var userModel = userFunctions.GetDataByID(userId);
            var userCompanies = companyUserRoleFunctions.UserCompanies(userId);

            var companyNames = new List<string>();
            if (userCompanies != null)
            {
                foreach (var companyModel in userCompanies)
                {
                    if (companyModel == null) continue;
                    if (companyNames.Contains(userModel.Email)) continue;

                    companyNames.Add(companyModel.NomeFantasia);
                }
            }
            string htmlTable =
                    "<br><br>" +
                    "<table style='width:60%;'  align='center' class='table-rounded'>" +
                    "<thead>" +
                    "<tr>";
            if (companyNames.Count > 0)
            {
                htmlTable += "<th colspan='2' style = 'vertical-align:middle; ' >" + string.Join(", ", companyNames) + "</th>";
            }
            else
            {
                htmlTable += "<th colspan='2' style = 'vertical-align:middle; ' >Sem associação com unidades de negócios</th>";
            }
            htmlTable += "</tr>" +
                    "</thead>" +
                    "</table>" +
                    "<br>" +
                    "<table style='width:60%;'  align='center'>" +
                    "<thead>" +
                    "<tr>" +
                    "<th colspan='2' style = 'vertical-align:middle; ' class='table-top-rounded'>" + userModel.FullName + "</th>" +
                    "</tr>" +
                    "<tr>" +
                    "<th colspan='1' style = 'vertical-align:middle; width:30%;' class='table-square'>" + userModel.Email + "</th>" +
                    "<th colspan='1' style = 'vertical-align:middle; width:30%;' class='table-square'>" + companyUserRoleFunctions.GetUserRole(userId).Name + "</th>" +
                    "</tr>" +
                    "</tbody>" +
                    "</table>";

            return htmlTable;
        }

        public string NewLawHtmlTable(string law, DTO.Law.LawViewModel lawViewModel, string userName)
        {

            string htmlTable =
                    "<br><br>" +
                    "<table  style='width:60%;' align='center' class='table-rounded'>" +
                    "<thead>" +
                    "<tr>" +
                    "<th style = 'vertical-align:middle;' colspan = '2' >" + law + "</th>" +
                    "</tr>" +
                    "</thead>" +
                    "</table>" +
                    "<table  style='width:60%; margin-top: 5px;' align='center' class='table-top-rounded'>" +
                    "<thead>" +
                    "<tr>" +
                    "<th style = 'vertical-align:middle;' colspan = '2' >" + lawViewModel.Title + "</th>" +
                    "</tr>" +
                    "</thead>" +
                    "</table>" +
                    "<table  style='width:60%;' align='center'>" +
                    "<tbody>" +
                    "<tr>";

            if (lawViewModel.EsferaName == null) htmlTable += "<th style = 'vertical-align:middle; width:50%;' class='table-square'><small style='float:left;'>Esfera legislativa</small><p>-</p></th>";
            else htmlTable += "<th style = 'vertical-align:middle; width:50%;' class='table-square'><small style='float:left;'>Esfera legislativa</small><p>" + lawViewModel.EsferaName + "</p></th>";

            if (lawViewModel.Keywords == null) htmlTable += "<th style = 'vertical-align:middle; width:50%;' class='table-square'><small style='float:left;'>Palavra chave</small><p>-</p></th>";
            else htmlTable += "<th style = 'vertical-align:middle; width:50%;' class='table-square'><small style='float:left;'>Palavra chave</small><p>" + lawViewModel.Keywords + "</p></th>";

            htmlTable += "</tr>" +
                    "<tr>" +
                    "<th style='vertical-align:middle; width:50%;' class='table-square'><small style='float:left;'>Modificado Por</small><p>" + userName + "</p></th>" +
                    "<th style='vertical-align:middle; width:50%;' class='table-square'><small style='float:left;'>Data</small><p>" + DateTime.Now.ToBrazilianDateFormat() + "</p></th>" +
                    "</tr>";
            if (!string.IsNullOrWhiteSpace(lawViewModel.Comments))
            {
                htmlTable += "<tr>" +
               "<th colspan='2' style='vertical-align:middle;' class='table-square'><small style='float:left;'>Comentários</small><br/><p>" + lawViewModel.Comments.Replace("\n", "<br />") + "</p></th>" +
               "</tr>";
            }
            htmlTable += "</tbody>" +
            "</table>";
            return htmlTable;
        }

        public string AlteratedByHtmlTable(int lawId, List<int> newLaws = null)
        {
            var lawChanges = lawChangeFunctions.GetData(x => x.LawId == lawId).AsNoTracking().ToList();
            if (lawChanges.Count == 0) return string.Empty;

            string htmlTable =
                    "<br>" +
                    "<table  style='width:60%;' align='center' class='table-top-rounded'>" +
                    "<tbody>" +
                    "<tr>" +
                    "<th style = 'vertical-align:middle;'>Este requisito legal foi alterado por:</th>" +
                    "</tr>" +
                    "</tbody>" +
                    "</table>" +
                    "<table  style='width:60%; margin-top: .1em;' align='center' class='table-square'>" +
                    "<tbody>";
            for (int i = 0; i < lawChanges.Count; i++)
            {
                var item = lawChanges[i];
                var law = lawFunctions.GetDataByID(item.ChangedLawId);

                htmlTable += "<tr>" +
                $"<th style = 'vertical-align:middle; {(i == 0 ? "" : "border-top: 1px solid #333;")} font-weight: normal;'><b>{law.Number}</b> - {(law.Title.Length > 70 ? law.Title.Substring(0, 70) + "..." : law.Title)}{(newLaws != null && newLaws.Contains(law.LawId) ? " - <b>NOVO</b>" : "")}</th>" +
                "</tr>";
            }

            htmlTable += "</tbody>" +
            "</table>";
            return htmlTable;
        }

        public string AlteratedFromHtmlTable(int lawId, List<int> newLaws = null)
        {
            var lawChanges = lawChangeFunctions.GetData(x => x.ChangedLawId == lawId).AsNoTracking().ToList();
            if (lawChanges.Count == 0) return string.Empty;

            string htmlTable =
                    "<br>" +
                    "<table  style='width:60%;' align='center' class='table-top-rounded'>" +
                    "<tbody>" +
                    "<tr>" +
                    "<th style = 'vertical-align:middle;'>Este requisito legal alterou os seguintes itens:</th>" +
                    "</tr>" +
                    "</tbody>" +
                    "</table>" +
                    "<table  style='width:60%; margin-top: .1em;' align='center' class='table-square'>" +
                    "<tbody>";

            for (int i = 0; i < lawChanges.Count; i++)
            {
                var item = lawChanges[i];
                var law = lawFunctions.GetDataByID(item.LawId);

                htmlTable += "<tr>" +
                $"<th style = 'vertical-align:middle; {(i == 0 ? "" : "border-top: 1px solid #333;")} font-weight: normal;'><b>{law.Number}</b> - {(law.Title.Length > 70 ? law.Title.Substring(0, 70) + "..." : law.Title)}{(newLaws != null && newLaws.Contains(law.LawId) ? " - <b>NOVO</b>" : "")}</th>" +
                "</tr>";
            }

            htmlTable += "</tbody>" +
            "</table>";

            return htmlTable;
        }
        public string RevokedFromHtmlTable(int lawId, List<int> newLaws = null)
        {
            var lawRevokes = lawFunctions.GetData(x => x.RevokedById == lawId).AsNoTracking().ToList();
            if (lawRevokes.Count == 0) return string.Empty;

            string htmlTable =
                    "<br>" +
                    "<table  style='width:60%;' align='center' class='table-top-rounded'>" +
                    "<tbody>" +
                    "<tr>" +
                    "<th style = 'vertical-align:middle;'>Este requisito legal revogou os seguintes itens:</th>" +
                    "</tr>" +
                    "</tbody>" +
                    "</table>" +
                    "<table  style='width:60%; margin-top: .1em;' align='center' class='table-square'>" +
                    "<tbody>";

            for (int i = 0; i < lawRevokes.Count; i++)
            {
                var item = lawRevokes[i];
                var law = lawFunctions.GetDataByID(item.LawId);

                htmlTable += "<tr>" +
                $"<th style = 'vertical-align:middle; {(i == 0 ? "" : "border-top: 1px solid #333;")} font-weight: normal;'><b>{law.Number}</b> - {(law.Title.Length > 70 ? law.Title.Substring(0, 70) + "..." : law.Title)}{(newLaws != null && newLaws.Contains(law.LawId) ? " - <b>NOVO</b>" : "")}</th>" +
                "</tr>";
            }

            htmlTable += "</tbody>" +
            "</table>";

            return htmlTable;
        }


        public string RevokedByHtmlTable(int lawId)
        {
            var law = lawFunctions.GetDataByID(lawId);

            if (!law.RevokedById.HasValue && string.IsNullOrWhiteSpace(law.RevokedBy)) return string.Empty;

            string revokedInfo = law.RevokedBy;

            if (law.RevokedById.HasValue)
            {
                var revoked = lawFunctions.GetDataByID(law.RevokedById);
                revokedInfo = $"<b>{revoked.Number}</b> - {(revoked.Title.Length > 70 ? revoked.Title.Substring(0, 70) + "..." : revoked.Title)}";
            }

            string htmlTable =
                    "<br>" +
                    "<table  style='width:60%;' align='center' class='table-top-rounded'>" +
                    "<tbody>" +
                    "<tr>" +
                    "<th style = 'vertical-align:middle;'>Este requisito legal foi revogado por:</th>" +
                    "</tr>" +
                    "</tbody>" +
                    "</table>" +
                    "<table  style='width:60%; margin-top: .1em;' align='center' class='table-square'>" +
                    "<tbody>" +
                    "<tr>" +
                    $"<th style = 'vertical-align:middle; font-weight: normal;'>{revokedInfo}</th>" +
                    "</tr>" +
                    "</tbody>" +
                    "</table>";

            return htmlTable;
        }

        public string CompanyHtmlTable(string companyName, string userName)
        {

            string htmlTable =
                    "<br><br>" +
                    "<table  style='width:60%;' align='center' class='table-rounded'>" +
                    "<thead>" +
                    "<tr>" +
                    "<th style = 'vertical-align:middle;' colspan = '2' >" + companyName + "</th>" +
                    "</tr>" +
                    "</thead>" +
                    "</table>" +
                    "<table  style='width:60%; margin-top: 5px;' align='center' class='table-top-rounded'>" +
                    "<thead>" +
                    "<tr>" +
                    "<th style = 'vertical-align:middle;' colspan = '2' >" + userName + "</th>" +
                    "</tr>" +
                    "</thead>" +
                    "</table>" +
                    "<table  style='width:60%; margin-top: 5px;' align='center' class='table-bottom-rounded'>" +
                    "<tbody>" +
                    "<tr>" +
                    "<th style = 'vertical-align:middle;'><small style='float:left;'>Data</small><p>" + DateTime.Now.ToBrazilianDateFormat() + "</p></th>" +
                    "</tr>" +
                    "</tbody>" +
                    "</table>";
            return htmlTable;
        }

    }
}
