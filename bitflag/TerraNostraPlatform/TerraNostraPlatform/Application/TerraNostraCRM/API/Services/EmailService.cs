using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IEmailService
    {
        void Send(string title, string body, List<string> mailAddresses);
    }
    public class EmailService : IEmailService
    {
        public void Send(string title, string body, List<string> mailAddresses)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient()
                {
                    Host = "smtp.chokosys.com.br",
                    UseDefaultCredentials = false,
                    Port = 587,
                    Credentials = new NetworkCredential("no-reply@chokosys.com.br", "F3~7eHKbSs\"KC9#w")
                };

                MailMessage mailMessage = new MailMessage
                {
                    IsBodyHtml = true,
                    From = new MailAddress("no-reply@chokosys.com.br", "Terra Nostra Assessoria")
                };

                mailMessage.Subject = title;

                if (mailAddresses != null)
                    foreach (var mailAddress in mailAddresses) mailMessage.To.Add(mailAddress);
                mailMessage.Bcc.Add("yuri.santana@chokosys.com.br");

                string _htmlContent = "<html><body><div style='text-align:center;'><img src=\"cid:LogoTerraNostraHighResolution\" width='300'></div><div><br/><br/>" + body + "</div></body></html>";

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(_htmlContent, null, MediaTypeNames.Text.Html);

                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "LogoTerraNostraHighResolution.jpg");
                LinkedResource logo = new LinkedResource(imagePath, MediaTypeNames.Image.Jpeg);
                logo.ContentId = "LogoTerraNostraHighResolution";
                htmlView.LinkedResources.Add(logo);

                mailMessage.AlternateViews.Add(htmlView);

                smtpClient.Send(mailMessage);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
