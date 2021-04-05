using Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BLL.Company
{
    public class CompanyGroupFunctions : BLLBasicFunctions<DAL.CompanyGroup, DTO.Company.CompanyGroupModel>
    {
        public CompanyGroupFunctions(DAL.GLAS2Context context)
            : base(context, "CompanyGroupId")
        {
        }
        protected override void SetDbSet()
        {
            this.dbSet = context.CompanyGroup;
        }
        public override List<DTO.Company.CompanyGroupModel> GetDataViewModel(IQueryable<DAL.CompanyGroup> data)
        {
            var r = (from x in data
                     select new DTO.Company.CompanyGroupModel()
                     {
                         CompanyGroupId = x.CompanyGroupId,
                         CompanyId = x.CompanyId,
                         GroupId = x.GroupId,
                         CreatedDate = x.CreatedDate,
                         LastHandler = x.LastHandler
                     }).ToList();

            return r;
        }
        public override DTO.Company.CompanyGroupModel GetDataViewModel(DAL.CompanyGroup data)
        {
            return new DTO.Company.CompanyGroupModel()
            {
                CompanyGroupId = data.CompanyGroupId,
                CompanyId = data.CompanyId,
                GroupId = data.GroupId,
                CreatedDate = data.CreatedDate,
                LastHandler = data.LastHandler
            };
        }
        public override int Create(DTO.Company.CompanyGroupModel groupCompanyModel)
        {
            var companyGroup = new DAL.CompanyGroup();

            companyGroup.CompanyGroupId = groupCompanyModel.CompanyGroupId;
            companyGroup.GroupId = groupCompanyModel.GroupId;
            companyGroup.CompanyId = groupCompanyModel.CompanyId;
            companyGroup.CreatedDate = groupCompanyModel.CreatedDate;
            companyGroup.LastHandler = groupCompanyModel.LastHandler;

            this.dbSet.Add(companyGroup);
            this.context.SaveChanges();

            return companyGroup.CompanyGroupId;
        }
        public override void Update(DTO.Company.CompanyGroupModel groupCompanyModel)
        {
            var companyGroup = this.GetDataByID(groupCompanyModel.GroupId);

            companyGroup.CompanyId = groupCompanyModel.CompanyId;
            companyGroup.GroupId = groupCompanyModel.GroupId;

            this.context.SaveChanges();
        }
        public override void Delete(object id)
        {
            var companyGroup = this.GetDataByID(id);

            this.context.Remove(companyGroup);
            this.context.SaveChanges();
        }
        public bool HasCompanies(int groupId)
        {
            return this.dbSet.Count(x => x.GroupId == groupId) > 0;
        }
        public IEnumerable<DAL.CompanyGroup> GetDataByGroupId(int? groupId)
        {
            return this.dbSet.Where(x => x.GroupId == groupId);
        }
    }
}
