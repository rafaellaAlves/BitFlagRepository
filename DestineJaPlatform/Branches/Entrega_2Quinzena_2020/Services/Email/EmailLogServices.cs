using ApplicationDbContext.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Email
{
    public class EmailLogServices : Shared.BaseServices<EmailLog, EmailLog, int>
    {
        public EmailLogServices(ApplicationDbContext.Context.ApplicationDbContext context) : base(context, "EmailLogId")
        {
        }

        public int Create(List<string> to, List<string> replyTo, List<string> bcc, string subject, bool sended = true, string error = null)
        {
            return Create(new EmailLog
            {
                EmailBCC = bcc == null? null : string.Join(", ", bcc),
                EmailTo = to == null ? null : string.Join(", ", to),
                EmailReply = replyTo == null ? null : string.Join(", ", replyTo),
                Subject = subject,
                ErrorMessage = error,
                Sended = sended
            });
        }

        public void InsertError(int emailLogId, string error)
        {
            var entity = GetDataById(emailLogId);

            entity.Sended = false;
            entity.ErrorMessage = error;

            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }
    }
}
