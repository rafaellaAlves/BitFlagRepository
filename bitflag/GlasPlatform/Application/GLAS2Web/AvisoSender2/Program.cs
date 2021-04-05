using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;

namespace AvisoSender2
{
    class Program
    {
        static DAL.GLAS2Context glas2Context;
        static int Main(string[] args)
        {
            return _Main();
        }

        public static int _Main()
        {
            try
            {
                var currentDateTime = DateTime.Now;
                var configurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
                var configuration = configurationBuilder.Build();

                glas2Context = new DAL.GLAS2Context(new Microsoft.EntityFrameworkCore.DbContextOptionsBuilder<DAL.GLAS2Context>().UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

                var companyLawFunctions = new BLL.Company.CompanyLawFunctions(glas2Context);
                var companyLawActionFunctions = new BLL.Company.CompanyLawActionFunctions(glas2Context);
                var companyLawActionStatusFunctions = new BLL.Company.CompanyLawActionStatusFunctions(glas2Context);
                var lawFunctions = new BLL.Law.LawFunctions(glas2Context);
                var companyFunctions = new BLL.Company.CompanyFunctions(glas2Context);

                foreach (var companyLaw in glas2Context.CompanyLaw.Where(x => !x.IsDeleted && ((x.WarningDate.HasValue && (x.WarningDate.Value.Day == currentDateTime.Day && x.WarningDate.Value.Month == currentDateTime.Month && x.WarningDate.Value.Year == currentDateTime.Year)) || (x.RenewDate.HasValue && (x.RenewDate.Value.Day == currentDateTime.Day && x.RenewDate.Value.Month == currentDateTime.Month && x.RenewDate.Value.Year == currentDateTime.Year)))).ToList())
                {
                    var companyLawModel = companyLawFunctions.GetDataViewModel(companyLawFunctions.GetDataByID(companyLaw.CompanyLawId));
                    var lawViewModel = lawFunctions.GetDataViewModel(lawFunctions.GetDataByID(companyLawModel.LawId));
                    var companyModel = companyFunctions.GetDataByID(companyLawModel.CompanyId);

                    if (!companyModel.IsActive || companyModel.IsDeleted)
                        continue;

                    if (!string.IsNullOrWhiteSpace(lawViewModel.RevokedDate) || !string.IsNullOrWhiteSpace(lawViewModel.RevokedBy))
                        continue;

                    var emails = GetCompanyAdminisAndSupervisors(companyLaw.CompanyId);

                    var htmlTable = MountHtmlLawTable(lawViewModel.LawInfoForEmail, companyLawModel);
                    htmlTable += "<table class='table-rounded' align='center' style='margin-top: 5px; width:20%;'>" +
                    "<tbody>" +
                    "<tr>" +
                    "<th style='vertical-align:middle;'><small style='float: left;'>Data de Renovação</small><p>" + companyLawModel.RenewDate + "</p></th>" +
                    "</tr>" +
                    "<tbody>" +
                    "</table>";

                    var subject = "ALERTA DE RENOVAÇÃO: REQUISITO LEGAL -  " + companyModel.NomeFantasia + " - " + lawViewModel.LawInfoForEmail;

                    MailFunctions.Send(subject, htmlTable, emails.Distinct().ToList());
                    CreateEmailLog(emails.Distinct().ToList(), subject, htmlTable, companyLawModel.CompanyId);

                    Console.WriteLine("Enviando CompanyLawID = {0}: {1}", companyLaw.CompanyLawId, companyLaw.RenewDate.Value.ToString("dd/MM/yyyy"));
                }

                foreach (var companyLawAction in glas2Context.CompanyLawAction.Where(x => !x.IsDeleted && ((x.WarningDate.HasValue && (x.WarningDate.Value.Day == currentDateTime.Day && x.WarningDate.Value.Month == currentDateTime.Month && x.WarningDate.Value.Year == currentDateTime.Year)) || (x.RenewDate.HasValue && (x.RenewDate.Value.Day == currentDateTime.Day && x.RenewDate.Value.Month == currentDateTime.Month && x.RenewDate.Value.Year == currentDateTime.Year)))).ToList())
                {
                    var companyLawActionModel = companyLawActionFunctions.GetDataViewModel(companyLawActionFunctions.GetDataByID(companyLawAction.CompanyLawActionId));
                    var companyLawModel = companyLawFunctions.GetDataViewModel(companyLawFunctions.GetDataByID(companyLawAction.CompanyLawId));
                    var lawViewModel = lawFunctions.GetDataViewModel(lawFunctions.GetDataByID(companyLawModel.LawId));
                    var companyModel = companyFunctions.GetDataByID(companyLawModel.CompanyId);

                    if (companyLawModel.IsDeleted || (!companyModel.IsActive) || (companyModel.IsDeleted))
                        continue;

                    if (!string.IsNullOrWhiteSpace(lawViewModel.RevokedDate) || !string.IsNullOrWhiteSpace(lawViewModel.RevokedBy))
                        continue;

                    var emails = GetCompanyAdminisAndSupervisors(companyModel.CompanyId);
                    var responsible = companyLawAction.ResponsibleId.HasValue ? glas2Context.User.SingleOrDefault(x => x.Id == companyLawAction.ResponsibleId.Value) : null;
                    if (responsible != null) emails.Add(responsible.Email);

                    var supervisor = companyLawAction.SupervisorId.HasValue ? glas2Context.User.SingleOrDefault(x => x.Id == companyLawAction.SupervisorId.Value) : null;
                    if (supervisor != null) emails.Add(supervisor.Email);

                    var htmlTable = MountHtmlLawTable(lawViewModel.LawInfoForEmail, companyLawModel);
                    htmlTable += CompanyLawActionTable(companyLawAction.CompanyLawActionId, companyLawActionFunctions, companyLawActionStatusFunctions);
                    htmlTable += "<table class='table-rounded' align='center' style='margin-top: 5px; width:20%;'>" +
                    "<tbody>" +
                    "<tr>" +
                    "<th style='vertical-align:middle;'><small style='float: left;'>Data de Renovação</small><p>" + companyLawActionModel.RenewDate + "</p></th>" +
                    "</tr>" +
                    "<tbody>" +
                    "</table>";

                    var subject = "ALERTA DE RENOVAÇÃO - AÇÃO: " + companyModel.NomeFantasia + " - " + lawViewModel.LawInfoForEmail;

                    MailFunctions.Send(subject, htmlTable, emails.Distinct().ToList());
                    CreateEmailLog(emails.Distinct().ToList(), subject, htmlTable, companyLawModel.CompanyId);

                    Console.WriteLine("Enviando CompanyLawActionID = {0}: {1}", companyLawAction.CompanyLawActionId, companyLawAction.RenewDate.Value.ToString("dd/MM/yyyy"));
                }

                return 0;
            }
            catch (Exception ex)
            {
                return 8;
            }
        }

        static string MountHtmlLawTable(string law, DTO.Company.CompanyLawViewModel model)
        {

            var lawConclusionStatusFunctions = new BLL.Law.LawConclusionStatusFunctions(glas2Context);
            var lawApplicationTypeFunctions = new BLL.Law.LawApplicationTypeFunctions(glas2Context);

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

        static string CompanyLawActionTable(int companyLawActionId, BLL.Company.CompanyLawActionFunctions companyLawActionFunctions, BLL.Company.CompanyLawActionStatusFunctions companyLawActionStatusFunctions)
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
                    "<th colspan='1' class='table-square' style = 'vertical-align:middle; width:33%;' ><small style='float:left;'>Data de Criação</small><p>" + companyLawActionViewModel.RegistrationDate + "</p></th>" +
                    "<th colspan='1' class='table-square' style = 'vertical-align:middle; width:34%;' ><small style='float:left;'>Data de Conclusão</small><p>" + companyLawActionViewModel.TargetDate + "</p></th>" +
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

        static List<string> GetCompanyAdminisAndSupervisors(int companyId)
        {
            var companyUserRoleFunctions = new BLL.Permission.CompanyUserRoleFunctions(glas2Context);

            var companyUsers = companyUserRoleFunctions.UsersInCompanyByRole(companyId, new List<string>() { BLL.User.ProfileNames.ClienteAdministrador, BLL.User.ProfileNames.ClienteSupervisor });
            if (companyUsers.Count == 0) return new List<string>();

            var userModels = new List<string>();
            foreach (var companyUser in companyUsers)
            {
                var user = glas2Context.User.SingleOrDefault(x => x.Id == companyUser.UserId);
                if (user == null) continue;
                userModels.Add(user.Email);
            }

            return userModels;
        }

        public static void CreateEmailLog(List<string> emails, string subject, string message, int? companyId)
        {
            var entity = new DAL.EmailLog
            {
                CompanyId = companyId,
                Emails = emails == null ? "" : string.Join("; ", emails),
                Message = message,
                Subject = subject,
                UserId = null,
                CreatedDate = DateTime.Now,
                Sended = false
            };

            glas2Context.EmailLog.Add(entity);
            glas2Context.SaveChanges();
        }
    }

    public class MailFunctions
    {
        public static string BioteraLogoImagePath
        {
            get
            {
                return System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Assets", "Images", "biotera_logo.jpg");
            }
        }

        public static void Send(string title, string htmlTable, List<string> mailAddress)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient()
                {
                    Host = "smtp.biotera.com.br",
                    UseDefaultCredentials = false,
                    Port = 587,
                    Credentials = new NetworkCredential("sistema@biotera.com.br", "5!9C8@sr")
                };

                MailMessage mailMessage = new MailMessage
                {
                    IsBodyHtml = true,
                    From = new MailAddress("sistema@biotera.com.br", "GLAS2")
                };

                mailMessage.Subject = "GLAS2 - " + title;
                foreach (var mail in mailAddress)
                {
                    mailMessage.To.Add(mail);
                }
                mailMessage.Bcc.Add("glas@biotera.com.br");
                mailMessage.Bcc.Add("yuri.santana@chokosys.com.br");
                //mailMessage.To.Add("lucas1999araujo@gmail.com");
                //mailMessage.To.Add("alexandre.meza@biotera.com.br");
                //mailMessage.To.Add("priscila.leal@biotera.com.br");

                //mailMessage.Subject = "GLAS2HOMOLOG - " + title;

                string _htmlTable =
                        "<html>" +
                        "<head>" +
                        "<style type='text/css'> " +
                        ".table-square {" +
                        "border: 1px solid #333;" +
                        "border-collapse: separate;" +
                        "border-spacing: 0;" +
                        "empty-cells: show;" +
                        "box-shadow: 0px 3px 3px 3px #ccc;" +
                        "}" +
                        ".table-rounded {" +
                        "border: 1px solid #333;" +
                        "border-collapse: separate;" +
                        "border-spacing: 0;" +
                        "empty-cells: show;" +
                        "border-radius: 5px;" +
                        "box-shadow: 0px 3px 3px 3px #ccc;" +
                        "}" +
                        ".table-top-rounded {" +
                        "border: 1px solid #333;" +
                        "border-collapse: separate;" +
                        "border-spacing: 0;" +
                        "empty-cells: show;" +
                        "border-radius: 5px 5px 0px 0px ;" +
                        "}" +
                        ".table-bottom-rounded {" +
                        "border: 1px solid #333;" +
                        "border-collapse: separate;" +
                        "border-spacing: 0;" +
                        "empty-cells: show;" +
                        "border-radius: 0px 0px 5px 5px ;" +
                        "}" +
                        "</style>" +
                        "</head>" +
                        "<body>" +
                        "<div style='text-align:center;'>" +
                        "<img src=\"cid:BioteraLogo\">" +
                        "</div>" +
                        "<div style='text-align:center;'>" +
                        htmlTable +
                        "</div>" +
                        "</body>" +
                        "</html>";

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(_htmlTable, null, MediaTypeNames.Text.Html);
                //var bioteraLogoFilePath = System.IO.Path.Combine(_hostingEnvironment.ContentRootPath, "Assets", "System", "biotera_logo.jpg");
                LinkedResource pic1 = new LinkedResource(BioteraLogoImagePath, MediaTypeNames.Image.Jpeg);
                pic1.ContentId = "BioteraLogo";
                htmlView.LinkedResources.Add(pic1);
                mailMessage.AlternateViews.Add(htmlView);
#if !DEBUG
                smtpClient.Send(mailMessage);
#endif
            }
            catch (Exception e)
            {

            }
        }
    }
}
