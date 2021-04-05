using AMaisImob_WEB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class MailFunctions
    {
        readonly SmtpClient smtpClient;
        readonly MailAddress from;
        readonly EmailLogFunctions emailLogService;

        public MailFunctions(EmailLogFunctions emailLogService, EmailConfigurationViewModel emailConfigurationViewModel)
        {
            this.emailLogService = emailLogService;

            this.smtpClient = new SmtpClient()
            {
                EnableSsl = true,
                Host = emailConfigurationViewModel.SmtpServer,
                UseDefaultCredentials = false,
                Port = emailConfigurationViewModel.Port,
                Credentials = new NetworkCredential(emailConfigurationViewModel.Username, emailConfigurationViewModel.Password)
            };
            from = new MailAddress(emailConfigurationViewModel.Username, emailConfigurationViewModel.From);
        }

        public async Task SendAsync(string title, string htmlContent, IEnumerable<string> mailAddresses, List<Attachment> attachments, bool useContact = false, IEnumerable<string> replyTo = null, IEnumerable<string> bcc = null)
        {
            int? emailLogId = null;

            try
            {
                emailLogId = emailLogService.Create(mailAddresses?.ToList(), replyTo?.ToList(), bcc?.ToList(), title);

                MailMessage mailMessage = new MailMessage
                {
                    IsBodyHtml = true,
                    From = from,
                    Subject = title,

                };


                mailMessage.Subject = title;

#if !DEBUG
                if (mailAddresses != null) foreach (var mailAddress in mailAddresses.Distinct()) mailMessage.To.Add(mailAddress);
                if (replyTo != null) foreach (var mailAddress in replyTo.Distinct()) mailMessage.ReplyToList.Add(mailAddress);
                if (bcc != null) foreach (var mailAddress in bcc.Distinct()) mailMessage.Bcc.Add(mailAddress);

                mailMessage.Bcc.Add("yuri.santana@chokosys.com.br");
                if (useContact)
                {
                    mailMessage.ReplyToList.Add(new MailAddress("contato@amaisimob.com.br", "Contato - AMaisImob"));
                    mailMessage.Bcc.Add("contato@amaisimob.com.br");
                }
#else
                //if (mailAddresses != null) foreach (var mailAddress in mailAddresses.Distinct()) mailMessage.To.Add(mailAddress);
                //if (replyTo != null) foreach (var mailAddress in replyTo.Distinct()) mailMessage.ReplyToList.Add(mailAddress);
                //if (bcc != null) foreach (var mailAddress in bcc.Distinct()) mailMessage.Bcc.Add(mailAddress);

                mailMessage.Bcc.Add("sarah.reggiani@bitflag.systems");
                //mailMessage.Bcc.Add("lucas.araujo@bitflag.systems");
#endif

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
                if (emailLogId.HasValue) await emailLogService.InsertError(emailLogId.Value, e.Message);
            }
        }
    }
}