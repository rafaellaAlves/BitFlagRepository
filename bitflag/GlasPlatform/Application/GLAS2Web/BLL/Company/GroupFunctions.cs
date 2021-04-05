using Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BLL.Company
{
    public class GroupFunctions : BLLBasicFunctions<DAL.Group, DTO.Company.GroupModel>
    {
        private CompanyFunctions bllCompanyFunctions;
        private CompanyGroupFunctions bllCompanyGroupFunctions;

        public GroupFunctions(DAL.GLAS2Context context)
            : base(context, "GroupId")
        {
            this.bllCompanyFunctions = new CompanyFunctions(context);
            this.bllCompanyGroupFunctions = new CompanyGroupFunctions(context);
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Group;
        }
        public override List<DTO.Company.GroupModel> GetDataViewModel(IQueryable<DAL.Group> data)
        {
            var r = (from x in data
                     select new DTO.Company.GroupModel()
                     {
                         GroupId = x.GroupId,
                         Name = x.Name,
                         Description = x.Description,
                         ParentId = x.ParentId
                     }).ToList();

            return r;
        }
        public override DTO.Company.GroupModel GetDataViewModel(DAL.Group data)
        {
            return new DTO.Company.GroupModel()
            {
                GroupId = data.GroupId,
                Name = data.Name,
                Description = data.Description,
                ParentId = data.ParentId
            };
        }
        public override int Create(DTO.Company.GroupModel groupModel)
        {
            var group = new DAL.Group();

            //group.GroupId = groupModel.GroupId.Value;
            group.Name = groupModel.Name;
            group.Description = groupModel.Description;
            group.ParentId = groupModel.ParentId;

            this.dbSet.Add(group);
            this.context.SaveChanges();

            return group.GroupId;
        }
        public override void Update(DTO.Company.GroupModel groupModel)
        {
            var group = this.GetDataByID(groupModel.GroupId);

            group.Name = groupModel.Name;
            group.Description = groupModel.Description;
            group.ParentId = groupModel.ParentId;

            this.context.SaveChanges();
        }
        public override void Delete(object id)
        {
            var group = this.GetDataByID(id);

            var groupModel = this.GetGroupModelHierarchized(group.GroupId, true);
            DeleteRecursive(groupModel);

            this.context.SaveChanges();
        }

        public List<DTO.Company.CompanyViewModel> GetCompanyViewModelInGroupRecursive(int? parentId)
        {
            var output = new List<DTO.Company.CompanyViewModel>();
            var groupModel = this.GetGroupModelHierarchized(parentId, true);
            GetCompaniesRecursive(groupModel, ref output);

            return output.Distinct().ToList();
        }

        private void GetCompaniesRecursive(DTO.Company.GroupModel model, ref List<DTO.Company.CompanyViewModel> output)
        {
            if (model.Children.Count > 0)
                foreach (var item in model.Children)
                    GetCompaniesRecursive(item, ref output);

            if (model.IsCompany)
                output.Add(model.Company);
        }

        private void DeleteRecursive(DTO.Company.GroupModel model)
        {
            if (model.Children.Count > 0)
                foreach (var item in model.Children)
                    DeleteRecursive(item);

            DeleteItem(model);
        }

        private void DeleteItem(DTO.Company.GroupModel model)
        {
            if (!model.IsCompany)
                this.context.Remove(GetDataByID(model.GroupId));
            else
                this.bllCompanyGroupFunctions.Delete(model.CompanyGroupId);

        }

        public DTO.Company.GroupModel GetGroupModelHierarchized(int? parentId, bool loadCompanies = false)
        {
            var groupModels = GetDataViewModel(GetData());
            if (loadCompanies)
            {
                var groupIds = groupModels.Select(x => x.GroupId).ToList();
                if (!parentId.HasValue) groupIds.Add(null);
                foreach (var groupId in groupIds)
                {
                    ////if (bllCompanyGroupFunctions.HasCompanies(groupId.Value)) continue;
                    var companyGroups = bllCompanyGroupFunctions.GetDataByGroupId(groupId);
                    if (companyGroups == null) continue;

                    foreach (var companyGroup in bllCompanyGroupFunctions.GetDataByGroupId(groupId))
                    {
                        var company = bllCompanyFunctions.GetDataByID(companyGroup.CompanyId);
                        if (company == null || company.IsDeleted == true) continue;
                        groupModels.Add(new DTO.Company.GroupModel()
                        {
                            ParentId = companyGroup.GroupId,
                            GroupId = null,
                            Name = company.RazaoSocial,
                            Description = company.NomeFantasia,
                            CompanyGroupId = companyGroup.CompanyGroupId,
                            Company = bllCompanyFunctions.GetDataViewModel(company)
                        });

                    }

                }
            }

            DTO.Company.GroupModel parent;
            if (parentId == null)
                parent = new DTO.Company.GroupModel() { Name = "GLAS", Description = "Gestão e Assessoria em Legislação Ambiental e Segurança do Trabalho", ParentId = null };
            else
                parent = this.GetDataViewModel(this.GetDataByID(parentId));

            groupModels.GetGroupModelHierarchized(parentId, parent);
            return parent;
        }
    }
}
