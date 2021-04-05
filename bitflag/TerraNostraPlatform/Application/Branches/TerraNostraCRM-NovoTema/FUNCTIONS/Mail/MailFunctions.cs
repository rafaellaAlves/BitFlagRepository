using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace FUNCTIONS.Mail
{
    public class MailFunctions
    {
        public static async Task SendAsync(string title, string htmlContent, string style, List<string> mailAddresses, List<Attachment> attachments, List<LinkedResource> linkedResources = null, bool useContact = false)
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
                    From = new MailAddress("no-reply@chokosys.com.br", "Terra Nostra")
                };

                mailMessage.Subject = title;

                if (mailAddresses != null)
                    foreach (var mailAddress in mailAddresses) mailMessage.To.Add(mailAddress);

                //mailMessage.Bcc.Add("yuri.santana@chokosys.com.br");
                if (useContact)
                {
                    //mailMessage.ReplyToList.Add(new MailAddress("contato@amaisvet.com.br", "Contato - AmaisVet"));
                    //mailMessage.Bcc.Add("contato@amaisvet.com.br");
                }

                string _htmlContent =
                        "<html>" +
                        "<head>" +
                        style +
                        "</head>" +
                        "<body>" +
                        "<div style='text-align:center;'>" +
                        "<img src=\"cid:LogoTerraNostraHighResolution\" width='300'>" +
                        "</div>" +
                        "<div>" +
                        "<br/><br/>" +
                        htmlContent +
                        "</div>" +
                        "</body>" +
                        "</html>";

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(_htmlContent, null, MediaTypeNames.Text.Html);
                if (attachments != null)
                    foreach (var attachment in attachments)
                        mailMessage.Attachments.Add(attachment);

                if (linkedResources != null)
                    foreach (var linkedResource in linkedResources)
                        htmlView.LinkedResources.Add(linkedResource);

                var imgDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "LogoTerraNostraHighResolution.jpg");
                LinkedResource pic1 = new LinkedResource(imgDirectory, MediaTypeNames.Image.Jpeg);
                pic1.ContentId = "LogoTerraNostraHighResolution";
                htmlView.LinkedResources.Add(pic1);

                mailMessage.AlternateViews.Add(htmlView);

                smtpClient.Send(mailMessage);
            }
            catch (Exception e)
            {

            }
        }
    }
}
