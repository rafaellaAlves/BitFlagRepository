using BLL.Utils;
using DAL;
using DTO.EmailLog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EmailLog
{
    public class EmailLogFunctions : BLLBasicFunctions<DAL.EmailLog, EmailLogViewModel>
    {
        public EmailLogFunctions(GLAS2Context context) : base(context, "EmailLogId")
        {
        }

        public async Task<int> Create(List<string> emails, string subject, string message, int? companyId, int? userId)
        {
            var entity = new DAL.EmailLog
            {
                CompanyId = companyId,
                Emails = emails == null ? "" : string.Join("; ", emails),
                Message = message,
                Subject = subject,
                UserId = userId
            };

            await this.dbSet.AddAsync(entity);
            await this.context.SaveChangesAsync();

            return entity.EmailLogId;
        }

        public async Task NotSended(int emailLogId)
        {
            var entity = await this.dbSet.SingleAsync(x => x.EmailLogId == emailLogId);

            entity.Sended = false;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }

        public override int Create(EmailLogViewModel model)
        {
            var entity = model.CopyToEntity<DAL.EmailLog>();
            this.dbSet.Add(entity);
            this.context.SaveChanges();

            return entity.EmailLogId;
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<EmailLogViewModel> GetDataViewModel(IQueryable<DAL.EmailLog> data)
        {
            var r = (from el in data
                     join __c in this.context.Company on el.CompanyId equals __c.CompanyId into _c
                     from c in _c.DefaultIfEmpty()
                     select new EmailLogViewModel()
                     {
                         EmailLogId = el.EmailLogId,
                         Subject = el.Subject,
                         Emails = el.Emails,
                         Message = el.Message,
                         CompanyId = el.CompanyId,
                         Company = c == null ? "-" : c.RazaoSocial,
                         UserId = el.UserId,
                         Sended = el.Sended,
                         CreatedDate = el.CreatedDate
                     });

            return r.ToList();
        }

        public override EmailLogViewModel GetDataViewModel(DAL.EmailLog data)
        {
            return data.CopyToEntity<EmailLogViewModel>();
        }

        public override void Update(EmailLogViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.EmailLog;
        }
    }
}
