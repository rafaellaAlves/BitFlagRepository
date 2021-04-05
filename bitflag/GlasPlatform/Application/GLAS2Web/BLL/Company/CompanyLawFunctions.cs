using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DTO.Law;
using DTO.Company;
using Utils;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data;
using BLL.Utils;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace BLL.Company
{
    public class CompanyLawFunctions : BLLBasicFunctions<DAL.CompanyLaw, DTO.Company.CompanyLawViewModel>
    {
        private CompanyFunctions companyFunctions;
        private Law.LawFunctions lawFunctions;
        private Law.LawTypeFunctions lawTypeFunctions;
        private Law.LawApplicationTypeFunctions lawApplicationTypeFunctions;
        private Law.LawConclusionStatusFunctions lawConclusionStatusFunctions;
        private Law.LawPotentialityTypeFunctions lawPotentialityTypeFunctions;
        private CompanyLawVerificationListResponseFunctions companyLawVerificationListResponseFunctions;
        private CompanyLawAttachmentFunctions companyLawAttachmentFunctions;

        public CompanyLawFunctions(DAL.GLAS2Context context)
            : base(context, "CompanyLawId")
        {
            this.companyFunctions = new CompanyFunctions(context);
            this.lawFunctions = new Law.LawFunctions(context);
            this.lawTypeFunctions = new Law.LawTypeFunctions(context);
            this.lawApplicationTypeFunctions = new Law.LawApplicationTypeFunctions(context);
            this.lawConclusionStatusFunctions = new Law.LawConclusionStatusFunctions(context);
            this.lawPotentialityTypeFunctions = new Law.LawPotentialityTypeFunctions(context);
            this.companyLawVerificationListResponseFunctions = new CompanyLawVerificationListResponseFunctions(context);
            this.companyLawAttachmentFunctions = new CompanyLawAttachmentFunctions(context);
        }

        public override int Create(CompanyLawViewModel model)
        {
            var companyLaw = new DAL.CompanyLaw();

            companyLaw.CompanyId = model.CompanyId;
            companyLaw.LawId = model.LawId;
            companyLaw.LawApplicationTypeId = model.LawApplicationTypeId;
            companyLaw.LawPotentialityTypeId = model.LawPotentialityTypeId;
            companyLaw.LawConclusionStatusId = model.LawConclusionStatusId;
            companyLaw.RenewDate = model.RenewDate.FromBrazilianDateFormatNullable();
            companyLaw.WarningDate = model.WarningDate.FromBrazilianDateFormatNullable();
            companyLaw.Evidence = model.Evidence;
            companyLaw.IsActive = true;
            companyLaw.IsDeleted = false;
            companyLaw.LastHandler = model.LastHandler;
            companyLaw.ResponsibleId = model.ResponsibleId;
            this.dbSet.Add(companyLaw);
            this.context.SaveChanges();

            return companyLaw.CompanyLawId;
        }
        public CopyCompanyLawResult Create(List<CompanyLaw> datas, int companyId, bool replace, bool EvidencesCheck, bool ResponseCheck, bool AttachmentCheck, bool StatusCheck, IHostingEnvironment _hostingEnvironment)
        {
            var notCompletedStatusId = this.context.LawConclusionStatus.Single(x => x.ExternalCode == "NOTCOMPLETED").LawConclusionStatusId;
            var notApplicableStatusId = this.context.LawConclusionStatus.Single(x => x.ExternalCode == "NOTAPPLICABLE").LawConclusionStatusId;
            var lawApplicableId = this.context.LawApplicationType.Single(x => x.ExternalCode == "APPLICABLE").LawApplicationTypeId;
            var dePara = new Dictionary<CompanyLaw, CompanyLaw>();

            int total = 0;
            int removed = 0;
            foreach (var data in datas)
            {
                if (this.dbSet.Any(x => x.LawId == data.LawId && x.CompanyId == companyId && !x.IsDeleted))
                {
                    if (replace)
                    {
                        var _companyLaw = this.dbSet.First(x => x.LawId == data.LawId && !x.IsDeleted && x.CompanyId == companyId);
                        _companyLaw.IsDeleted = true;
                        _companyLaw.LastHandler = -1;
                        _companyLaw.ModifiedDate = DateTime.Now;
                        this.dbSet.Update(_companyLaw);

                        companyLawAttachmentFunctions.DeleteByCompanyLawId(_companyLaw.CompanyLawId);
                        companyLawVerificationListResponseFunctions.DeleteByCompanyLawId(_companyLaw.CompanyLawId);

                        removed++;
                    }

                    else
                        continue;
                }

                var companyLaw = new DAL.CompanyLaw
                {
                    CompanyId = companyId,
                    LawId = data.LawId,
                    LawApplicationTypeId = data.LawApplicationTypeId,
                    LawPotentialityTypeId = data.LawPotentialityTypeId,
                    LawConclusionStatusId = StatusCheck ? data.LawConclusionStatusId : (data.LawApplicationTypeId == lawApplicableId ? notCompletedStatusId : notApplicableStatusId),
                    RenewDate = data.RenewDate,
                    WarningDate = data.WarningDate,
                    Evidence = EvidencesCheck ? data.Evidence : null,
                    IsActive = true,
                    IsDeleted = false,
                    LastHandler = data.LastHandler
                };

                this.dbSet.Add(companyLaw);

                dePara.Add(data, companyLaw);

                total++;
            }

            this.context.SaveChanges();

            if (ResponseCheck || AttachmentCheck)//Copia os anexos e/ou obrigações dependendo do que foi escolhido na tela
            {
                foreach (var item in dePara)
                {
                    if (ResponseCheck)
                    {
                        companyLawVerificationListResponseFunctions.CopyCompanyLawVerificationListBetweenCompanyLaws(item.Key.CompanyLawId, item.Value.CompanyLawId);
                    }
                    if (AttachmentCheck)
                    {
                        companyLawAttachmentFunctions.CopyCompanyLawAttachmentBetweenCompanyLaws(item.Key.CompanyLawId, item.Value.CompanyLawId, _hostingEnvironment);
                    }
                }
            }
            return new CopyCompanyLawResult(total - removed, removed);
        }

        public override void Delete(object id)
        {
            var law = this.GetDataByID(id);

            law.IsDeleted = true;
            law.LastHandler = -1;
            law.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }
        public async Task DeleteByCompanyId(int companyId, string contentRootPath)
        {
            var _companyLawAction = this.context.CompanyLawAction.Where(x => !x.IsDeleted).ToList();
            var _companyLawActionAttachment = this.context.CompanyLawActionAttachment.Where(x => !x.IsDeleted).ToList();
            var _companyLawActionComment = this.context.CompanyLawActionComment.Where(x => !x.IsDeleted).ToList();
            var _companyLawattachment = this.context.CompanyLawattachment.Where(x => !x.IsDeleted).ToList();
            var _companyLawComment = this.context.CompanyLawComment.Where(x => !x.IsDeleted).ToList();

            await this.dbSet.Where(x => x.CompanyId == companyId).ForEachAsync(companyLaw =>
            {
                #region [COMPANYLAW]
                companyLaw.IsDeleted = true;
                companyLaw.LastHandler = -1;
                companyLaw.ModifiedDate = DateTime.Now;
                #endregion

                #region [ACTIONS]
                _companyLawAction.Where(x => x.CompanyLawId == companyLaw.CompanyLawId).Loop(companyLawAction =>
                {
                    companyLawAction.IsDeleted = true;
                    companyLawAction.LastHandler = -1;
                    companyLawAction.ModifiedDate = DateTime.Now;

                    #region [ACTIONS ATTACHMENTS]
                    _companyLawActionAttachment.Where(x => x.CompanyLawActionId == companyLawAction.CompanyLawActionId).Loop(actionAttachment =>
                    {
                        actionAttachment.IsDeleted = true;
                        actionAttachment.LastHandler = -1;
                        actionAttachment.ModifiedDate = DateTime.Now;

                        var pathToDelete = System.IO.Path.Combine(contentRootPath, actionAttachment.FilePath);
                        if (File.Exists(pathToDelete)) File.Delete(pathToDelete);
                    });
                    #endregion

                    #region [ACTIONS COMMENTS]
                    _companyLawActionComment.Where(x => x.CompanyLawActionId == companyLawAction.CompanyLawActionId).Loop(actionComment =>
                    {
                        actionComment.IsDeleted = true;
                        actionComment.LastHandler = -1;
                        actionComment.ModifiedDate = DateTime.Now;
                    });
                    #endregion
                });
                #endregion

                #region [LAW ATTACHMENTS]
                _companyLawattachment.Where(x => x.CompanyLawId == companyLaw.CompanyLawId).Loop(lawAttachment =>
                {
                    lawAttachment.IsDeleted = true;
                    lawAttachment.LastHandler = -1;
                    lawAttachment.ModifiedDate = DateTime.Now;

                    var pathToDelete = System.IO.Path.Combine(contentRootPath, lawAttachment.FilePath);
                    if (File.Exists(pathToDelete)) File.Delete(pathToDelete);
                });
                #endregion

                #region [LAW COMMENTS]
                _companyLawComment.Where(x => x.CompanyLawId == companyLaw.CompanyLawId).Loop(lawComment =>
                {
                    lawComment.IsDeleted = true;
                    lawComment.LastHandler = -1;
                    lawComment.ModifiedDate = DateTime.Now;
                });
                #endregion
            });

            this.context.SaveChanges();
        }


        public override List<CompanyLawViewModel> GetDataViewModel(IQueryable<DAL.CompanyLaw> data)
        {
            //TODO: AJUSTAR
            var r = (from y in data.ToList()
                     from c in this.context.Company.Where(x => x.CompanyId.Equals(y.CompanyId))
                     from l in this.context.Law.Where(x => x.LawId.Equals(y.LawId))
                     from lt in this.context.LawType.Where(x => l.LawTypeId.Equals(x.LawTypeId)).DefaultIfEmpty()
                     from lat in this.context.LawApplicationType.Where(x => y.LawApplicationTypeId.Equals(x.LawApplicationTypeId)).DefaultIfEmpty()
                     from lcs in this.context.LawConclusionStatus.Where(x => y.LawConclusionStatusId.Equals(x.LawConclusionStatusId)).DefaultIfEmpty()
                     from resp in this.context.User.Where(x => y.ResponsibleId.Equals(x.Id)).DefaultIfEmpty()
                     select new CompanyLawViewModel()
                     {
                         CompanyLawId = y.CompanyLawId,
                         CompanyId = y.CompanyId,
                         LawId = y.LawId,
                         LawApplicationTypeId = y.LawApplicationTypeId,
                         LawApplicationTypeName = lat == null ? null : lat.Name,
                         LawConclusionStatusId = y.LawConclusionStatusId,
                         LawConclusionStatusName = lcs == null ? null : lcs.Name,
                         LawPotentialityTypeId = y.LawPotentialityTypeId,
                         RenewDate = y.RenewDate.ToBrazilianDateFormat(),
                         WarningDate = y.WarningDate.ToBrazilianDateFormat(),
                         Evidence = y.Evidence,
                         IsActive = y.IsActive,
                         ResponsibleId = y.ResponsibleId,
                         ResponsibleName = resp == null ? "" : resp.FirstName + " " + resp.LastName,

                         Law = lawFunctions.GetDataViewModel(l),
                         LawType = lawTypeFunctions.GetDataViewModel(lt),
                         Company = companyFunctions.GetDataViewModel(c)
                     });

            return r.ToList();
        }

        public override CompanyLawViewModel GetDataViewModel(DAL.CompanyLaw data)
        {
            var company = companyFunctions.GetDataByID(data.CompanyId);
            var law = lawFunctions.GetDataByID(data.LawId);
            var lawType = lawTypeFunctions.GetDataByID(law.LawTypeId);
            var lawApplicationType = lawApplicationTypeFunctions.GetDataByID(data.LawApplicationTypeId);
            var lawConclusionStatus = lawConclusionStatusFunctions.GetDataByID(data.LawConclusionStatusId);
            var resp = this.context.User.SingleOrDefault(x => data.ResponsibleId.Equals(x.Id));

            return new CompanyLawViewModel()
            {
                CompanyLawId = data.CompanyLawId,
                CompanyId = data.CompanyId,
                LawId = data.LawId,
                LawApplicationTypeId = data.LawApplicationTypeId,
                LawApplicationTypeName = lawApplicationType == null ? null : lawApplicationType.Name,
                LawConclusionStatusId = data.LawConclusionStatusId,
                LawConclusionStatusName = lawConclusionStatus == null ? null : lawConclusionStatus.Name,
                LawPotentialityTypeId = data.LawPotentialityTypeId,
                RenewDate = data.RenewDate.ToBrazilianDateFormat(),
                WarningDate = data.WarningDate.ToBrazilianDateFormat(),
                Evidence = data.Evidence,
                IsActive = data.IsActive,
                IsDeleted = data.IsDeleted,
                ResponsibleId = data.ResponsibleId,
                ResponsibleName = resp == null ? "" : resp.FirstName + " " + resp.LastName,

                Law = lawFunctions.GetDataViewModel(law),
                LawType = lawTypeFunctions.GetDataViewModel(lawType),
                Company = companyFunctions.GetDataViewModel(company)
            };
        }

        public override void Update(CompanyLawViewModel model)
        {
            var companyLaw = this.GetDataByID(model.CompanyLawId);

            //companyLaw.LawId = model.LawId;
            //companyLaw.CompanyId = model.CompanyId;
            companyLaw.LawApplicationTypeId = model.LawApplicationTypeId;
            companyLaw.LawConclusionStatusId = model.LawConclusionStatusId;
            companyLaw.LawPotentialityTypeId = model.LawPotentialityTypeId;
            companyLaw.RenewDate = model.RenewDate.FromBrazilianDateFormatNullable();
            companyLaw.WarningDate = model.WarningDate.FromBrazilianDateFormatNullable();
            companyLaw.Evidence = model.Evidence;
            companyLaw.IsActive = model.IsActive;
            companyLaw.LastHandler = model.LastHandler;
            companyLaw.ResponsibleId = model.ResponsibleId;
            companyLaw.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CompanyLaw;
        }

        public List<DTO.Company.CompanyLawViewModel> LawsInCompany(int companyId)
        {
            return this.GetDataViewModel(this.dbSet.Where(c => c.CompanyId == companyId && !c.IsDeleted));
        }

        public List<DTO.Company.CompanyLawViewModel> GetCompanyLawByLawId(int lawId)
        {
            return this.GetDataViewModel(from cl in this.dbSet
                                         join c in this.context.Company on cl.CompanyId equals c.CompanyId
                                         where cl.LawId == lawId && !cl.IsDeleted && (c.IsActive) && (c.IsActive && !c.IsDeleted)
                                         select new CompanyLaw
                                         {
                                             CompanyId = cl.CompanyId,
                                             IsDeleted = cl.IsDeleted,
                                             IsActive = cl.IsActive,
                                             CompanyLawId = cl.CompanyLawId,
                                             CreatedDate = cl.CreatedDate,
                                             Evidence = cl.Evidence,
                                             LastHandler = cl.LastHandler,
                                             LawApplicationTypeId = cl.LawApplicationTypeId,
                                             LawConclusionStatusId = cl.LawConclusionStatusId,
                                             LawId = cl.LawId,
                                             LawPotentialityTypeId = cl.LawPotentialityTypeId,
                                             ModifiedDate = cl.ModifiedDate,
                                             RenewDate = cl.RenewDate,
                                             WarningDate = cl.WarningDate,
                                             ResponsibleId = cl.ResponsibleId,
                                         });
        }

        public List<int> GetCompanyIdByKnowlodgeLawId(int lawId)
        {
            var knowledgeId = lawApplicationTypeFunctions.GetData().Where(x => x.ExternalCode == "KNOWLEDGE").First().LawApplicationTypeId;
            var r = (from cl in this.dbSet
                     where cl.LawId == lawId && cl.LawApplicationTypeId == knowledgeId && cl.IsDeleted == false
                     select cl.CompanyId).ToList();
            return r;
        }
        public List<string> GetCompanyNameByCompanyIds(List<int> companyIds)
        {
            var y = (from c in context.Company
                     join cl in companyIds on c.CompanyId equals cl
                     orderby c.NomeFantasia ascending
                     select c.NomeFantasia).ToList();
            return y;
        }

        public List<int> GetCompanyIdByApplicableLawId(int lawId)
        {
            var applicableId = lawApplicationTypeFunctions.GetData().Where(x => x.ExternalCode == "APPLICABLE").First().LawApplicationTypeId;
            var r = (from cl in this.dbSet
                     where cl.LawId == lawId && cl.LawApplicationTypeId == applicableId && cl.IsDeleted == false
                     select cl.CompanyId).ToList();
            return r;
        }

        public bool LawIsInCompany(int lawId, int companyId)
        {
            return this.dbSet.Any(x => x.LawId == lawId && x.CompanyId == companyId && !x.IsDeleted);
        }

        public bool CompanyLawIsCompleted(int companyLawId)
        {
            return (from cl in this.dbSet
                    join lcs in this.context.LawConclusionStatus on cl.LawConclusionStatusId equals lcs.LawConclusionStatusId
                    where cl.CompanyLawId == companyLawId && lcs.ExternalCode == "COMPLETED" // TODO: Retirar FIXO
                    select cl).Any();
        }

        public int GetCompanyIdFromCompanyLawId(int companyLawId)
        {
            return this.dbSet.Single(x => x.CompanyLawId == companyLawId).CompanyId;
        }

        public int GetCompanyLawUserViewCount(int userId, int companyId)
        {
            this.context.Database.OpenConnection();
            using (DbCommand command = this.context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "dbo.GetCompanyLawUserViewCount @UserId, @CompanyId";
                command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int) { Value = userId });
                command.Parameters.Add(new SqlParameter("@CompanyId", SqlDbType.Int) { Value = companyId });
                return (int)command.ExecuteScalar();
            }
        }

        public DateTime? GetRenewDateById(int? id)
        {
            if (!id.HasValue || !Exists(id)) return null;
            return GetDataByID(id).RenewDate;
        }
        public DateTime? GetWarningDateById(int? id)
        {
            if (!id.HasValue || !Exists(id)) return null;
            return GetDataByID(id).WarningDate;
        }
        public DAL.Law GetLawByCompanyLawId(int? id)
        {
            if (!id.HasValue || !Exists(id)) return null;
            var lawId = GetDataByID(id).LawId;

            if (!lawFunctions.Exists(lawId)) return null;

            return lawFunctions.GetDataByID(lawId);
        }

        public bool CompanyHasLaws(int companyId)
        {
            return this.dbSet.Any(x => x.CompanyId == companyId && !x.IsDeleted);
        }

        public async Task<bool> LawIsInUse(int lawId) => await this.dbSet.AnyAsync(x => x.LawId == lawId && !x.IsDeleted);

    }
}