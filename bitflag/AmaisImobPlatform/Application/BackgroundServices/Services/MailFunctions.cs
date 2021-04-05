using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundServices.Services
{
    public class MailFunctions
    {
        public static void Send(string title, string htmlContent, List<string> mailAddresses, List<Attachment> attachments, bool useContact = false)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient()
                {
                    Host = "smtpi.kinghost.net",
                    UseDefaultCredentials = false,
                    Port = 587,
                    Credentials = new NetworkCredential("contato@amaisimob.com.br", "BoaSorte99")
                };

                MailMessage mailMessage = new MailMessage
                {
                    IsBodyHtml = true,
                    From = new MailAddress("contato@amaisimob.com.br", "Contato - AMaisImob")
                };

                mailMessage.Subject = title;

                if (mailAddresses != null)
                    foreach (var mailAddress in mailAddresses) mailMessage.To.Add(mailAddress);

                //mailMessage.Bcc.Add("yuri.santana@chokosys.com.br");
                //if (useContact)
                //{
                //    mailMessage.ReplyToList.Add(new MailAddress("contato@amaisimob.com.br", "Contato - AMaisImob"));
                //    mailMessage.Bcc.Add("contato@amaisimob.com.br");
                //}

                string _htmlContent =
                        "<html>" +
                        "<head>" +
                        "</head>" +
                        "<body>" +
                        "<div style='text-align:center;'>" +
                        "<img src=\"cid:AMaisimobLogo\">" +
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
                var imgDirectory = Path.Combine(currentDirectory, "wwwroot", "image", "logo_AMaisImob.png");
                LinkedResource pic1 = new LinkedResource(imgDirectory, MediaTypeNames.Image.Jpeg);
                pic1.ContentId = "AMaisimobLogo";
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
