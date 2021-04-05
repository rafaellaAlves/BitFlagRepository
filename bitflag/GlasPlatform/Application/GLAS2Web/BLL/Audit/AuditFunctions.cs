using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO.Audit;
using Utils;
namespace BLL.Audit
{
    public class AuditFunctions : BLLBasicFunctions<DAL.Audit, DTO.Audit.AuditViewModel>
    {
        public AuditFunctions(DAL.GLAS2Context context)
            : base(context, "AuditId")
        {
            this.context = context;
        }

        public override int Create(AuditViewModel model)
        {
            var o = new DAL.Audit
            {
                CompanyId = model.CompanyId,
                Objective = model.Objective,
                LeaderAuditor = model.LeaderAuditor,
                CoAuditors = model.CoAuditors,
                Participants = model.Participants,
                Scope = model.Scope,
                StartDate = model.StartDate.FromBrazilianDateFormatNullable(),
                ConclusionDate = model.ConclusionDate.FromBrazilianDateFormatNullable(),
                ScheduleDate = model.ScheduleDate.FromBrazilianDateFormatNullable(),
                AuditTypeId = model.AuditTypeId,
                SegmentoId = model.SegmentoId,
                AuditStatusId = model.AuditStatusId,
                Description = model.Description,
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
                LastHandler = -1,
                IsActive = true,
                IsDeleted = false
            };

            this.dbSet.Add(o);
            this.context.SaveChanges();

            return o.AuditId;
        }

        public override void Delete(object id)
        {
            var o = this.GetDataByID(id);

            o.IsDeleted = true;
            o.LastHandler = -1;
            o.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        public override List<AuditViewModel> GetDataViewModel(IQueryable<DAL.Audit> data)
        {
            return (from d in data
                    from segmento in this.context.Segmento.Where(x => x.SegmentoId == d.SegmentoId).DefaultIfEmpty()
                    from auditType in this.context.AuditType.Where(x => x.AuditTypeId == d.AuditTypeId).DefaultIfEmpty()
                    from auditStatus in this.context.AuditStatus.Where(x => x.AuditStatusId == d.AuditStatusId).DefaultIfEmpty()
                    select new DTO.Audit.AuditViewModel()
                    {
                        AuditId = d.AuditId,
                        CompanyId = d.CompanyId,
                        Objective = d.Objective,
                        LeaderAuditor = d.LeaderAuditor,
                        CoAuditors = d.CoAuditors,
                        Participants = d.Participants,
                        Scope = d.Scope,
                        StartDate = d.StartDate.ToBrazilianDateFormat(),
                        ConclusionDate = d.ConclusionDate.ToBrazilianDateFormat(),
                        ScheduleDate = d.ScheduleDate.ToBrazilianDateFormat(),
                        AuditTypeId = d.AuditTypeId,
                        AuditTypeName = auditType == null ? null : auditType.Name,
                        SegmentoId = d.SegmentoId,
                        SegmentoName = segmento == null ? null : segmento.Name,
                        AuditStatusId = d.AuditStatusId,
                        AuditStatusName = auditStatus == null ? null : auditStatus.Name,
                        Description = d.Description,
                        CreateDate = d.CreatedDate.ToBrazilianDateFormat()
                    }).ToList();

        }

        public override AuditViewModel GetDataViewModel(DAL.Audit data)
        {
            var segmento = this.context.Segmento.SingleOrDefault(x => x.SegmentoId == data.SegmentoId);
            var auditType = this.context.AuditType.SingleOrDefault(x => x.AuditTypeId == data.AuditTypeId);
            var auditStatus = this.context.AuditStatus.SingleOrDefault(x => x.AuditStatusId == data.AuditStatusId);

            return new DTO.Audit.AuditViewModel()
            {
                AuditId = data.AuditId,
                CompanyId = data.CompanyId,
                Objective = data.Objective,
                LeaderAuditor = data.LeaderAuditor,
                CoAuditors = data.CoAuditors,
                Participants = data.Participants,
                Scope = data.Scope,
                StartDate = data.StartDate.ToBrazilianDateFormat(),
                ConclusionDate = data.ConclusionDate.ToBrazilianDateFormat(),
                ScheduleDate = data.ScheduleDate.ToBrazilianDateFormat(),
                AuditTypeId = data.AuditTypeId,
                AuditTypeName = auditType == null ? null : auditType.Name,
                SegmentoId = data.SegmentoId,
                SegmentoName = segmento == null ? null : segmento.Name,
                AuditStatusId = data.AuditStatusId,
                AuditStatusName = auditStatus == null ? null : auditStatus.Name,
                Description = data.Description,
                CreateDate = data.CreatedDate.ToBrazilianDateFormat()
            };
        }

        public override void Update(AuditViewModel model)
        {
            var o = this.GetDataByID(model.AuditId);

            o.Objective = model.Objective;
            o.LeaderAuditor = model.LeaderAuditor;
            o.CoAuditors = model.CoAuditors;
            o.Participants = model.Participants;
            o.Scope = model.Scope;
            o.StartDate = model.StartDate.FromBrazilianDateFormatNullable();
            o.ConclusionDate = model.ConclusionDate.FromBrazilianDateFormatNullable();
            o.ScheduleDate = model.ScheduleDate.FromBrazilianDateFormatNullable();
            o.AuditTypeId = model.AuditTypeId;
            o.SegmentoId = model.SegmentoId;
            o.AuditStatusId = model.AuditStatusId;
            o.Description = model.Description;

            o.ModifiedDate = DateTime.Now;
            o.LastHandler = -1;

            this.context.SaveChanges();
        }

        public AudtiDashboardViewModel GetDashboardInfo(int companyLawId)
        {
            return (from a in this.context.Audit
                    join ai in this.context.AuditItem on a.AuditId equals ai.AuditId
                    join __ais in this.context.AuditItemStatus on ai.AuditItemStatusId equals __ais.AuditItemStatusId into _ais
                    from ais in _ais.DefaultIfEmpty()
                    where ai.CompanyLawId == companyLawId
                    orderby a.StartDate descending
                    select new AudtiDashboardViewModel()
                    {
                        StartDate = a.StartDate,
                        Status = ais == null ? null : ais.Name,
                        ScheduleDate = a.ScheduleDate
                    }).FirstOrDefault();
        }

        protected override void SetDbSet()
        {
            this.dbSet = this.context.Audit;
        }
    }
}
