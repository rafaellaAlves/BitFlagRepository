using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Web.Services.Mail
{
    public class MailFunctions
    {
        public static async Task SendAsync(string title, string htmlContent, List<string> mailAddresses, List<Attachment> attachments = null, bool useContact = false)
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
                    From = new MailAddress("no-reply@chokosys.com.br", "Vendas - GuardMed")
                };

                mailMessage.Subject = $"GuardMed - {title}";

                if (mailAddresses != null)
                    foreach (var mailAddress in mailAddresses) mailMessage.To.Add(mailAddress);

                //mailMessage.Bcc.Add("lucas.araujo@bitflag.systems");
                //mailMessage.Bcc.Add("yuri.santana@chokosys.com.br");
                if (useContact)
                {
                    //mailMessage.ReplyToList.Add(new MailAddress("contato@amaisimob.com.br", "Contato - GuardMed"));
                    //mailMessage.Bcc.Add("contato@amaisimob.com.br");
                }

                string _htmlContent =
                        "<html>" +
                        "<head>" +
                        "</head>" +
                        "<body>" +
                        "<div style='text-align:center;'>" +
                        "<img src=\"cid:Logo\" width=\"300\">" +
                        "</div>" +
                        "<div>" +
                        "<br/><br/>" +
                        htmlContent +
                        "</div>" +
                        "</body>" +
                        "</html>";

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(_htmlContent, null, MediaTypeNames.Text.Html);
                var currentDirectory = Directory.GetCurrentDirectory();
                if (attachments != null)
                    foreach (var attachment in attachments)
                        mailMessage.Attachments.Add(attachment);
                var imgDirectory = Path.Combine(currentDirectory, "wwwroot", "image", "logoGuardMed.png");
                LinkedResource pic1 = new LinkedResource(imgDirectory, MediaTypeNames.Image.Jpeg);
                pic1.ContentId = "Logo";
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


        public static async Task SendAsync(string title, string htmlContent, List<string> mailAddresses, List<Attachment> attachments, List<LinkedResource> resources, bool useContact = false, bool useDefaultLogo = true, List<string> replyTo = null, string sender = null)
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
                    From = new MailAddress("no-reply@chokosys.com.br", sender ?? "Contato - GuardMed")
                };

                mailMessage.Subject = $"GuardMed - {title}";

                if (mailAddresses != null)
                    foreach (var mailAddress in mailAddresses) mailMessage.To.Add(mailAddress);

                if (replyTo != null)
                    foreach (var _replyTo in replyTo) mailMessage.ReplyToList.Add(_replyTo);


#if !DEBUG
                mailMessage.Bcc.Add("rpetrilli@guardmed.com.br");
#endif
                //mailMessage.Bcc.Add("yuri.santana@chokosys.com.br");
                if (useContact)
                {
                    //mailMessage.ReplyToList.Add(new MailAddress("contato@amaisimob.com.br", "Contato - GuardMed"));
                    //mailMessage.Bcc.Add("contato@amaisimob.com.br");
                }

                string _htmlContent =
                        "<html>" +
                        "<head>" +
                        "</head>" +
                        "<body>" +
                        "<div style='text-align:center;'>" +
                        "<img src=\"cid:Logo\" width=\"300\">" +
                        "</div>" +
                        "<div>" +
                        "<br/><br/>" +
                        htmlContent +
                        "</div>" +
                        "</body>" +
                        "</html>";

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(_htmlContent, null, MediaTypeNames.Text.Html);
                var currentDirectory = Directory.GetCurrentDirectory();
                if (attachments != null)
                    foreach (var attachment in attachments)
                        mailMessage.Attachments.Add(attachment);
                if (useDefaultLogo)
                {
                    var imgDirectory = Path.Combine(currentDirectory, "wwwroot", "image", "logoGuardMed.png");
                    LinkedResource pic1 = new LinkedResource(imgDirectory, MediaTypeNames.Image.Jpeg);
                    pic1.ContentId = "Logo";
                    htmlView.LinkedResources.Add(pic1);
                }
                if (resources != null) resources.ForEach(x => htmlView.LinkedResources.Add(x));

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
