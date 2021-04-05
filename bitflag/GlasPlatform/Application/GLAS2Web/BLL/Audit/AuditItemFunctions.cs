using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO.Audit;
using Utils;
namespace BLL.Audit
{
    public class AuditItemFunctions : BLLBasicFunctions<DAL.AuditItem, DTO.Audit.AuditItemViewModel>
    {
        public AuditItemFunctions(DAL.GLAS2Context context)
            : base(context, "AuditItemId")
        {
            this.context = context;
        }

        public override int Create(AuditItemViewModel model)
        {
            var o = new DAL.AuditItem
            {
                AuditId = model.AuditId,
                CompanyLawId = model.CompanyLawId,
                CompanyLawActionId = model.CompanyLawActionId,
                AuditItemStatusId = model.AuditItemStatusId,
                Comments = model.Comments,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                LastHandler = -1,
                ModifiedDate = null
            };

            this.dbSet.Add(o);
            this.context.SaveChanges();

            return o.AuditItemId;
        }

        public override void Delete(object id)
        {
            var o = this.GetDataByID(id);

            o.IsDeleted = true;
            o.LastHandler = -1;
            o.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }


        public void DeleteDefinitively(object id)
        {
            this.dbSet.Remove(this.GetDataByID(id));
            this.context.SaveChanges();
        }

        public override List<AuditItemViewModel> GetDataViewModel(IQueryable<DAL.AuditItem> data)
        {
            return (from d in data
                    join clv in this.context.CompanyLawView on d.CompanyLawId equals clv.CompanyLawId
                    select new DTO.Audit.AuditItemViewModel()
                    {
                        AuditItemId = d.AuditItemId,
                        AuditId = d.AuditId,
                        CompanyLawId = d.CompanyLawId,
                        CompanyLawActionId = d.CompanyLawActionId,
                        AuditItemStatusId = d.AuditItemStatusId,
                        Comments = d.Comments,
                        CompanyLawView = clv
                    }).ToList();

        }

        public override AuditItemViewModel GetDataViewModel(DAL.AuditItem data)
        {
            //var segmento = this.context.Segmento.SingleOrDefault(x => x.SegmentoId == data.SegmentoId);
            //var auditType = this.context.AuditType.SingleOrDefault(x => x.AuditTypeId == data.AuditTypeId);
            var companyLawView = this.context.CompanyLawView.SingleOrDefault(x => x.CompanyLawId == data.CompanyLawId);

            return new DTO.Audit.AuditItemViewModel()
            {
                AuditItemId = data.AuditItemId,
                AuditId = data.AuditId,
                CompanyLawId = data.CompanyLawId,
                CompanyLawActionId = data.CompanyLawActionId,
                AuditItemStatusId = data.AuditItemStatusId,
                Comments = data.Comments,
                CompanyLawView = companyLawView
            };
        }

        public override void Update(AuditItemViewModel model)
        {
            var o = this.GetDataByID(model.AuditItemId);

            o.AuditId = model.AuditId;
            o.CompanyLawId = model.CompanyLawId;
            o.CompanyLawActionId = model.CompanyLawActionId;
            o.AuditItemStatusId = model.AuditItemStatusId;
            o.Comments = model.Comments;

            o.ModifiedDate = DateTime.Now;
            o.LastHandler = -1;

            this.context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = this.context.AuditItem;
        }
    }
}
