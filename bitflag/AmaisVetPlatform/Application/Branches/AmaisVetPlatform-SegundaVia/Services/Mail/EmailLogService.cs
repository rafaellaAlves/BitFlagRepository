using ApplicationDbContext.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mail
{
    public class MailLogService
    {
        private readonly ApplicationDbContext.Context.ApplicationDbContext context;
        public MailLogService(ApplicationDbContext.Context.ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateAsync(List<string> to, List<string> replyTo, List<string> bcc, string subject, bool sent = true, string error = null)
        {
            var mailLog = new MailLog
            {
                EmailBcc = bcc == null ? null : string.Join(", ", bcc),
                EmailTo = to == null ? null : string.Join(", ", to),
                EmailReply = replyTo == null ? null : string.Join(", ", replyTo),
                Subject = subject,
                ErrorMessage = error,
                Sent = sent
            };
            await context.AddAsync(mailLog);
            await this.context.SaveChangesAsync();

            return mailLog.MailLogId;
        }

        public async Task InsertError(int mailLogId, string error)
        {
            var entity = context.MailLog.Find(mailLogId);

            entity.Sent = false;
            entity.ErrorMessage = error;

            this.context.MailLog.Update(entity);
            await this.context.SaveChangesAsync();
        }
    }
}
