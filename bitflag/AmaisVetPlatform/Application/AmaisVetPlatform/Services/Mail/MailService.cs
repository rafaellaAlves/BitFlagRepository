using DTO.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mail
{
    public class MailService
    {
        private readonly MailLogService mailLogService;
        private readonly Dictionary<string, EmailConfigurationViewModel> emailAccounts;

        public MailService(MailLogService emailLogService, Dictionary<string, EmailConfigurationViewModel> emailConfigurationViewModel)
        {
            this.mailLogService = emailLogService;
            this.emailAccounts = emailConfigurationViewModel;
        }
        private SmtpClient GetSmtpClientByAccount(string account)
        {
            return new SmtpClient()
            {
                EnableSsl = true,
                Host = emailAccounts[account].SmtpServer,
                UseDefaultCredentials = false,
                Port = emailAccounts[account].Port,
                Credentials = new NetworkCredential(emailAccounts[account].Username, emailAccounts[account].Password)
            };
        }
        private MailAddress GetMailAddressByAccount(string account)
        {
            return new MailAddress(emailAccounts[account].Username, emailAccounts[account].From);
        }
        private List<string> GetResponsiblesByAccount(string account)
        {
            return emailAccounts[account].Responsibles;
        }
        private string GetDefaultEmailAccount() => emailAccounts.Keys.First();

        #region [Default Account]
        public async Task SendAsync(string title, string htmlContent, string email) => await SendAsync(GetDefaultEmailAccount(), title, htmlContent, new List<string>() { email }, null, null, null);
        public async Task SendToResponsiblesAsync(string title, string htmlContent) => await SendAsync(GetDefaultEmailAccount(), title, htmlContent, GetResponsiblesByAccount(GetDefaultEmailAccount()), null, null, null);
        public async Task SendAsync(string title, string htmlContent, string email, List<Attachment> attachments = null) => await SendAsync(GetDefaultEmailAccount(), title, htmlContent, new List<string>() { email }, attachments, null, null);
        #endregion

        #region [Custom Account]
        public async Task SendAsync(string account, string title, string htmlContent, string email) => await SendAsync(account, title, htmlContent, new List<string>() { email }, null, null, null);
        public async Task SendToResponsiblesAsync(string account, string title, string htmlContent) => await SendAsync(account, title, htmlContent, GetResponsiblesByAccount(GetDefaultEmailAccount()), null, null, null);
        public async Task SendAsync(string account, string title, string htmlContent, string email, List<Attachment> attachments = null) => await SendAsync(account, title, htmlContent, new List<string>() { email }, attachments, null, null);
        #endregion

        public async Task SendAsync(string account, string title, string htmlContent, List<string> mailAddresses, List<Attachment> attachments = null, List<string> replyTo = null, List<string> bcc = null)
        {
            int? mailLogId = null;

            try
            {
                mailLogId = await mailLogService.CreateAsync(mailAddresses, replyTo, bcc, title);

                MailMessage mailMessage = new MailMessage
                {
                    IsBodyHtml = true,
                    From = GetMailAddressByAccount(account),
                    Subject = title,

                };
                mailMessage.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(GetHTMLTemplate(htmlContent), null, MediaTypeNames.Text.Html));

                if (mailAddresses != null) mailAddresses.ForEach(x =>
                {
                    var email = x?.Trim();
                    if (!mailMessage.To.Any(x => x.Address == email) && !string.IsNullOrWhiteSpace(email)) mailMessage.To.Add(email);
                });

                if (replyTo != null) replyTo.ForEach(x =>
                {
                    var email = x?.Trim();
                    if (!mailMessage.To.Any(x => x.Address == email) && !string.IsNullOrWhiteSpace(email)) mailMessage.ReplyToList.Add(email);
                });

                if (bcc != null) bcc.ForEach(x =>
                {
                    var email = x?.Trim(); if (!mailMessage.To.Any(x => x.Address == email) && !string.IsNullOrWhiteSpace(email)) mailMessage.Bcc.Add(email);
                });

                mailMessage.Bcc.Add("yuri.santana@bitflag.systems");
#if !DEBUG
                if (account.ToUpper().Equals("CONTATO")) mailMessage.Bcc.Add("contato@amaisvet.com.br");
                if (account.ToUpper().Equals("CERTIFICADO")) mailMessage.Bcc.Add("certificados@amaisvet.com.br");
#endif

                if (attachments != null) attachments.ForEach(x => mailMessage.Attachments.Add(x));

                await GetSmtpClientByAccount(account).SendMailAsync(mailMessage);
            }
            catch (Exception e)
            {
                if (mailLogId.HasValue)
                    await mailLogService.InsertError(mailLogId.Value, e.Message);

                throw e;
            }
        }
        private string GetHTMLTemplate(string htmlContent)
        {
            return
            "<html>" +
                "<body style=\"font-family: 'Lucida Bright', monospace;\">" +
                    htmlContent +
                "</body>" +
            "</html>";
        }
    }
}
