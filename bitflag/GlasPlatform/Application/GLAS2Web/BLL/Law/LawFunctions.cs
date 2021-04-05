using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DTO.Law;
using Microsoft.EntityFrameworkCore;
using Utils;

namespace BLL.Law
{
    public class LawFunctions : BLLBasicFunctions<DAL.Law, DTO.Law.LawViewModel>
    {
        private LawTypeFunctions lawTypeFunctions;
        private Utils.EsferaFunctions esferaFunctions;
        private Utils.OrgaoFunctions orgaoFunctions;
        private Utils.SegmentoFunctions segmentoFunctions;

        public LawFunctions(DAL.GLAS2Context context)
            : base(context, "LawId")
        {
            lawTypeFunctions = new LawTypeFunctions(context);
            esferaFunctions = new Utils.EsferaFunctions(context);
            orgaoFunctions = new Utils.OrgaoFunctions(context);
            segmentoFunctions = new Utils.SegmentoFunctions(context);
        }

        public override int Create(LawViewModel model)
        {
            var law = new DAL.Law();

            law.LawTypeId = model.LawTypeId;
            law.Number = model.Number;
            law.PublishDate = model.PublishDate.FromBrazilianDateFormat();
            law.ForceDate = model.ForceDate.FromBrazilianDateFormat();
            law.Title = model.Title;
            law.Keywords = model.Keywords;
            law.EsferaId = model.EsferaId;
            law.OrgaoId = model.OrgaoId;
            law.SegmentoId = model.SegmentoId;
            law.CountryId = model.CountryId;
            law.StateId = model.StateId;
            law.CityId = model.CityId;
            law.Summary = model.Summary;
            law.Comments = model.Comments;
            law.RevokedDate = string.IsNullOrWhiteSpace(model.RevokedDate) ? null : model.RevokedDate.FromBrazilianDateFormatNullable();
            law.RevokedBy = model.RevokedBy;
            law.AlteredDate = string.IsNullOrWhiteSpace(model.AlteredDate) ? null : model.AlteredDate.FromBrazilianDateFormatNullable();
            law.CreatedDate = DateTime.Now;
            law.CreatedBy = model.CreatedBy;
            law.AlteredBy = model.AlteredBy;
            law.RevokedById = model.RevokedById;
            law.QuestionThemeId = model.QuestionThemeId;
            law.QuestionSubThemeId = model.QuestionSubThemeId;
            law.LawPotentialityTypeId = model.LawPotentialityTypeId;

            this.dbSet.Add(law);
            this.context.SaveChanges();

            return law.LawId;

        }

        public override void Delete(object id)
        {
            var law = this.GetDataByID(id);

            law.IsDeleted = true;
            law.LastHandler = -1;
            law.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        public void Delete(object id, int userId)
        {
            var law = this.GetDataByID(id);

            law.IsDeleted = true;
            law.LastHandler = userId;
            law.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        public override List<LawViewModel> GetDataViewModel(IQueryable<DAL.Law> data)
        {
            return (from y in data
                        //from __lt in this.context.LawType.Where(x => x.LawTypeId.Equals(y.LawTypeId)).DefaultIfEmpty()
                    join __lt in this.context.LawType on y.LawTypeId equals __lt.LawTypeId into _lt
                    from lt in _lt.DefaultIfEmpty()
                        //from e in this.context.Esfera.Where(x => x.EsferaId.Equals(y.EsferaId)).DefaultIfEmpty()
                    join __e in this.context.Esfera on y.EsferaId equals __e.EsferaId into _e
                    from e in _e.DefaultIfEmpty()
                        //from o in this.context.Orgao.Where(x => x.OrgaoId.Equals(y.OrgaoId)).DefaultIfEmpty()
                    join __o in this.context.Orgao on y.OrgaoId equals __o.OrgaoId into _o
                    from o in _o.DefaultIfEmpty()
                        //from s in this.context.Segmento.Where(x => x.SegmentoId.Equals(y.SegmentoId)).DefaultIfEmpty()
                    join __s in this.context.Segmento on y.SegmentoId equals __s.SegmentoId into _s
                    from s in _s.DefaultIfEmpty()
                    join __u in this.context.User on y.CreatedBy equals __u.Id into _u
                    from u in _u.DefaultIfEmpty()
                    select new DTO.Law.LawViewModel()
                    {
                        LawId = y.LawId,
                        LawTypeId = y.LawTypeId,
                        LawTypeName = lt == null ? null : lt.Name,
                        Number = y.Number,
                        PublishDate = y.PublishDate.ToBrazilianDateFormat(),
                        _ForceDate = y.ForceDate,
                        ForceDate = y.ForceDate.ToBrazilianDateFormat(),
                        Title = y.Title,
                        Keywords = y.Keywords,
                        EsferaId = y.EsferaId,
                        EsferaName = e == null ? null : e.Name,
                        OrgaoId = y.OrgaoId,
                        OrgaoName = o == null ? null : o.Name,
                        SegmentoId = y.SegmentoId,
                        SegmentoName = s == null ? null : s.Name,
                        CountryId = y.CountryId,
                        StateId = y.StateId,
                        CityId = y.CityId,
                        Summary = y.Summary,
                        Comments = y.Comments,
                        RevokedDate = y.RevokedDate.ToBrazilianDateFormat(),
                        RevokedBy = y.RevokedBy,
                        AlteredDate = y.AlteredDate.ToBrazilianDateFormat(),
                        AlteredBy = y.AlteredBy,
                        CreatedDate = y.CreatedDate,
                        CreatedBy = y.CreatedBy,
                        CreatedByName = u != null ? $"{u.FirstName} {u.LastName}" : null,
                        RevokedById = y.RevokedById,

                        QuestionThemeId = y.QuestionThemeId,
                        QuestionSubThemeId = y.QuestionSubThemeId,
                        LawPotentialityTypeId = y.LawPotentialityTypeId
                    }).ToList();
        }

        public override LawViewModel GetDataViewModel(DAL.Law data)
        {
            var createdBy = this.context.User.SingleOrDefault(x => x.Id == data.CreatedBy);

            var r = new DTO.Law.LawViewModel()
            {
                LawId = data.LawId,
                LawTypeId = data.LawTypeId,
                //LawTypeName = lawType == null ? null : lawType.Name,
                Number = data.Number,
                _ForceDate = data.ForceDate,
                PublishDate = data.PublishDate.ToBrazilianDateFormat(),
                ForceDate = data.ForceDate.ToBrazilianDateFormat(),
                Title = data.Title,
                Keywords = data.Keywords,
                EsferaId = data.EsferaId,
                //EsferaName = esfera == null ? null : esfera.Name,
                OrgaoId = data.OrgaoId,
                //OrgaoName = orgao == null ? null : orgao.Name,
                SegmentoId = data.SegmentoId,
                //SegmentoName = segmento == null ? null : segmento.Name,
                CountryId = data.CountryId,
                StateId = data.StateId,
                CityId = data.CityId,
                Summary = data.Summary,
                Comments = data.Comments,
                RevokedDate = data.RevokedDate.ToBrazilianDateFormat(),
                RevokedBy = data.RevokedBy,
                AlteredDate = data.AlteredDate.ToBrazilianDateFormat(),
                AlteredBy = data.AlteredBy,
                CreatedDate = data.CreatedDate,
                CreatedBy = data.CreatedBy,
                CreatedByName = createdBy == null ? null : $"{createdBy.FirstName} {createdBy.LastName}",
                RevokedById = data.RevokedById,

                QuestionThemeId = data.QuestionThemeId,
                QuestionSubThemeId = data.QuestionSubThemeId,
                LawPotentialityTypeId = data.LawPotentialityTypeId
            };

            var lawType = lawTypeFunctions.GetDataByID(data.LawTypeId);
            r.LawTypeName = lawType == null ? null : lawType.Name;

            var esfera = data.EsferaId.HasValue ? esferaFunctions.GetDataByID(data.EsferaId.Value) : null;
            r.EsferaName = esfera == null ? null : esfera.Name;

            var orgao = data.OrgaoId.HasValue ? orgaoFunctions.GetDataByID(data.OrgaoId.Value) : null;
            r.OrgaoName = orgao == null ? null : orgao.Name;

            var segmento = data.SegmentoId.HasValue ? segmentoFunctions.GetDataByID(data.SegmentoId.Value) : null;
            r.SegmentoName = segmento == null ? null : segmento.Name;

            return r;
        }

        public override void Update(LawViewModel model)
        {
            var law = this.GetDataByID(model.LawId);

            law.LawTypeId = model.LawTypeId;
            law.Number = model.Number;
            law.PublishDate = model.PublishDate.FromBrazilianDateFormat();
            law.ForceDate = model.ForceDate.FromBrazilianDateFormat();
            law.Title = model.Title;
            law.Keywords = model.Keywords;
            law.EsferaId = model.EsferaId;
            law.OrgaoId = model.OrgaoId;
            law.SegmentoId = model.SegmentoId;
            law.CountryId = model.CountryId;
            law.StateId = model.StateId;
            law.CityId = model.CityId;
            law.Summary = model.Summary;
            law.Comments = model.Comments;
            law.RevokedDate = model.RevokedDate.FromBrazilianDateFormatNullable();
            law.RevokedBy = model.RevokedBy;
            law.AlteredDate = model.AlteredDate.FromBrazilianDateFormatNullable();
            law.AlteredBy = model.AlteredBy;
            law.RevokedById = model.RevokedById;
            law.QuestionThemeId = model.QuestionThemeId;
            law.QuestionSubThemeId = model.QuestionSubThemeId;
            law.LawPotentialityTypeId = model.LawPotentialityTypeId;

            law.LastHandler = -1;
            law.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Law;
        }

        public bool ExistLaw(LawViewModel model, out DAL.Law law)
        {
            law = this.dbSet.FirstOrDefault(x =>
            x.EsferaId == model.EsferaId &&
            x.Number == model.Number &&
            x.LawTypeId == model.LawTypeId &&
            x.OrgaoId == model.OrgaoId &&
            x.PublishDate == model.PublishDate.FromBrazilianDateFormat() &&
            x.ForceDate == model.ForceDate.FromBrazilianDateFormat() &&
            !x.IsDeleted);

            return law != null;
        }

        public async Task RemoveLawRevokedBy(int revokedById)
        {
            var laws = GetData(x => x.RevokedById == revokedById);

            foreach (var law in laws)
            {
                law.RevokedBy = null;
                law.RevokedById = null;
                law.RevokedDate = null;

                this.dbSet.Update(law);
            }

            await this.context.SaveChangesAsync();
        }

        public async Task InsertLawRevokedBy(int revokedById, List<int> lawRevokedFrom)
        {
            var revoked = GetDataByID(revokedById);

            foreach (var lawId in lawRevokedFrom)
            {
                var entity = GetDataByID(lawId);
                entity.RevokedBy = $"{revoked.Number} - {(revoked.Title.Length > 40 ? revoked.Title.Substring(0, 40) + "..." : revoked.Title)}";
                entity.RevokedById = revokedById;
                entity.RevokedDate = revoked.ForceDate;

                this.dbSet.Update(entity);
            }

            await this.context.SaveChangesAsync();
        }
    }
}
