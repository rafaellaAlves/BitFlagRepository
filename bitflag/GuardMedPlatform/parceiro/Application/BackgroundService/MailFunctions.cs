using BackgroundService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using VendasDbContext.Models;

namespace BackgroundService
{
    public class MailFunctions
    {
        readonly VendasContext vendasContext;

        public MailFunctions(VendasContext vendasContext)
        {
            this.vendasContext = vendasContext;
        }

        public async Task SendAsync(string title, string htmlContent, List<string> mailAddresses, List<Attachment> attachments, bool useContact = false)
        {
            int? emailLogId = null;

            try
            {
                emailLogId = await EmailLogCreate(mailAddresses, null, null, title);

                SmtpClient smtpClient = new SmtpClient()
                {
                    Host = InsuranceConfiguration.MailHost,
                    UseDefaultCredentials = false,
                    Port = InsuranceConfiguration.MailPort,
                    Credentials = new NetworkCredential(InsuranceConfiguration.MailLogin, InsuranceConfiguration.MailPass)
                };

                MailMessage mailMessage = new MailMessage
                {
                    IsBodyHtml = true,
                    From = new MailAddress(InsuranceConfiguration.MailSenderDisplay, InsuranceConfiguration.MailName)
                };

                mailMessage.Subject = title;

                if (InsuranceConfiguration.IsHomolog)
                {
                    mailMessage.To.Add("denis@amaisseg.com.br");
                    mailMessage.To.Add("rpetrilli@guardmed.com.br");
                }
                else
                {
//#if DEBUG
                    mailMessage.Bcc.Add("joao.gregorio@bitflag.systems");
                    mailMessage.Bcc.Add("sarah.reggiani@bitflag.systems");
//#else
                    if (mailAddresses != null)
                        foreach (var mailAddress in mailAddresses) mailMessage.To.Add(mailAddress);
//#endif
                }

                string _htmlContent =
                        "<html>" +
                        "<head>" +
                        "</head>" +
                        "<body>" +
                        "<div>" +
                        "<div style='text-align:center;'>" +
                        "<img src=\"cid:Logo\" width=\"235\">" +
                        "</div>" +
                        "</br></br></br>" +
                        htmlContent +
                        "</br></br>" +
                        "</div>" +
                        "</body>" +
                        "</html>";

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(_htmlContent, null, MediaTypeNames.Text.Html);
#if DEBUG
                var currentDirectory = Directory.GetCurrentDirectory();
#else
                var currentDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
#endif

                if (attachments != null)
                    foreach (var attachment in attachments)
                        mailMessage.Attachments.Add(attachment);
                var imgDirectory = (currentDirectory + InsuranceConfiguration.MailLogoPath);
                LinkedResource pic1 = new LinkedResource(imgDirectory, MediaTypeNames.Image.Jpeg);
                pic1.ContentId = "Logo";
                htmlView.LinkedResources.Add(pic1);
                mailMessage.AlternateViews.Add(htmlView);

                smtpClient.Send(mailMessage);
            }
            catch (Exception e)
            {
                if (emailLogId.HasValue) await EmailLogInsertError(emailLogId.Value, e.Message);
            }
        }

        public async Task<int> EmailLogCreate(List<string> to, List<string> replyTo, List<string> bcc, string subject, bool sended = true, string error = null)
        {
            var email = new EmailLog
            {
                EmailBcc = bcc == null ? null : string.Join(", ", bcc),
                EmailTo = to == null ? null : string.Join(", ", to),
                EmailReply = replyTo == null ? null : string.Join(", ", replyTo),
                Subject = subject,
                ErrorMessage = error,
                Sended = sended,
                CreatedDate = DateTime.Now
            };

            await this.vendasContext.EmailLog.AddAsync(email);
            await this.vendasContext.SaveChangesAsync();

            return email.EmailLogId;
        }

        public async Task EmailLogInsertError(int emailLogId, string error)
        {
            var entity = this.vendasContext.EmailLog.Single(x => x.EmailLogId == emailLogId);

            entity.Sended = false;
            entity.ErrorMessage = error;

            this.vendasContext.EmailLog.Update(entity);
            await this.vendasContext.SaveChangesAsync();
        }
    }
}