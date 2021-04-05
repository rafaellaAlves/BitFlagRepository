using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace WEB.BLL
{
    public class MailFunctions
    {
        public static async Task SendAsync(string title, string htmlContent, List<string> mailAddresses, List<Attachment> attachments, bool useContact = false)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient()
                {
                    Host = Configuration.InsuranceConfiguration.MailHost,
                    UseDefaultCredentials = false,
                    Port = Configuration.InsuranceConfiguration.MailPort,
                    Credentials = new NetworkCredential(Configuration.InsuranceConfiguration.MailLogin, Configuration.InsuranceConfiguration.MailPass)
                };

                MailMessage mailMessage = new MailMessage
                {
                    IsBodyHtml = true,
                    From = new MailAddress(Configuration.InsuranceConfiguration.MailSenderDisplay, Configuration.InsuranceConfiguration.MailName)
                };


#if DEBUG
                mailMessage.Subject = "[DEV] " + title;
                mailMessage.To.Add("yuri.santana@bitflag.system");
                mailMessage.To.Add("sarah.reggiani@bitflag.systems");
                mailMessage.To.Add("joao.gregorio@bitflag.systems");
                mailMessage.To.Add("rafaella.silva@bitflag.systems");
#else
                mailMessage.Subject = title;
                if (Configuration.InsuranceConfiguration.IsHomolog)
                {
                    mailMessage.To.Add("denis@amaisseg.com.br");
                    mailMessage.To.Add("rpetrilli@guardmed.com.br");
                }
                else
                {
                    if (mailAddresses != null)
                        foreach (var mailAddress in mailAddresses) mailMessage.To.Add(mailAddress);
                }

                if (useContact)
                {
                    mailMessage.ReplyToList.Add(new MailAddress(Configuration.InsuranceConfiguration.MailSenderDisplay, Configuration.InsuranceConfiguration.MailName));
                    mailMessage.Bcc.Add(Configuration.InsuranceConfiguration.MailSenderDisplay);
                }
#endif


                string _htmlContent =
                        "<html>" +
                        "<head>" +
                        "</head>" +
                        "<body>" +
                        "<div>" +
                        "<br/>" +
                        htmlContent +
                        "</br></br>" +
                        "</div>" +
                        "</br></br></br>" +
                        "<div style='text-align:left;'>" +
                        "<img src=\"cid:Logo\" width=\"235\">" +
                        "</div>" +
                        "</body>" +
                        "</html>";

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(_htmlContent, null, MediaTypeNames.Text.Html);
                var currentDirectory = Directory.GetCurrentDirectory();
                if (attachments != null)
                    foreach (var attachment in attachments)
                        mailMessage.Attachments.Add(attachment);
                var imgDirectory = (currentDirectory + Configuration.InsuranceConfiguration.MailLogoPath);
                LinkedResource pic1 = new LinkedResource(imgDirectory, MediaTypeNames.Image.Jpeg);
                pic1.ContentId = "Logo";
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