using AMaisImob_DB.Models;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class EmailLogFunctions : BLLBasicFunctions<EmailLog, EmailLog>
    {
        public EmailLogFunctions(AMaisImob_HomologContext context) : base(context, "EmailLogId")
        {
        }

        public int Create(List<string> to, List<string> replyTo, List<string> bcc, string subject, bool sended = true, string error = null)
        {
            return Create(new EmailLog
            {
                EmailBcc = bcc == null ? null : string.Join(", ", bcc),
                EmailTo = to == null ? null : string.Join(", ", to),
                EmailReply = replyTo == null ? null : string.Join(", ", replyTo),
                Subject = subject,
                ErrorMessage = error,
                Sended = sended
            });
        }

        public async Task InsertError(int emailLogId, string error)
        {
            var entity = GetDataByID(emailLogId);

            entity.Sended = false;
            entity.ErrorMessage = error;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }

        public override int Create(EmailLog model)
        {
            this.dbSet.Add(model);
            this.context.SaveChanges();

            return model.EmailLogId;
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<EmailLog> GetDataViewModel(IEnumerable<EmailLog> data)
        {
            throw new NotImplementedException();
        }

        public override EmailLog GetDataViewModel(EmailLog data)
        {
            throw new NotImplementedException();
        }

        public override void Update(EmailLog model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.EmailLog;
        }
    }
}
