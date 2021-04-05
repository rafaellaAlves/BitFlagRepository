using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DTO.Law;
using DTO.Company;
using Utils;
using Microsoft.EntityFrameworkCore;

namespace BLL.Company
{
    public class CompanyLawVerificationListResponseFunctions : BLLBasicFunctions<DAL.CompanyLawVerificationListItemResponse, DTO.Company.CompanyLawVerificationListItemResponseViewModel>
    {
        public CompanyLawVerificationListResponseFunctions(DAL.GLAS2Context context)
            : base(context, "CompanyLawVerificationListItemResponseId")
        {
        }

        public override int Create(CompanyLawVerificationListItemResponseViewModel model)
        {
            var companyLawVerificationListResponse = new DAL.CompanyLawVerificationListItemResponse();

            companyLawVerificationListResponse.CompanyLawId = model.CompanyLawId;
            companyLawVerificationListResponse.LawVerificationListId = model.LawVerificationListId;
            companyLawVerificationListResponse.LawVerificationListItemId = model.LawVerificationListItemId;
            companyLawVerificationListResponse.ImplementationTypeId = model.ImplementationTypeId;
            companyLawVerificationListResponse.CreateCompanyLawAction = model.CreateCompanyLawAction;
            companyLawVerificationListResponse.CompanyLawActionType = model.CompanyLawActionType;
            companyLawVerificationListResponse.Comments = model.Comments;
            companyLawVerificationListResponse.LastHandler = model.LastHandler;
            companyLawVerificationListResponse.ModifiedDate = DateTime.Now;

            this.dbSet.Add(companyLawVerificationListResponse);
            this.context.SaveChanges();

            return companyLawVerificationListResponse.CompanyLawVerificationListItemResponseId;
        }

        public override void Delete(object id)
        {
            var companyLawVerificationListResponse = this.GetDataByID(id);

            //companyLawVerificationListResponse.IsDeleted = true;
            //companyLawVerificationListResponse.LastHandler = -1;
            //companyLawVerificationListResponse.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        public override List<CompanyLawVerificationListItemResponseViewModel> GetDataViewModel(IQueryable<DAL.CompanyLawVerificationListItemResponse> data)
        {
            throw new NotImplementedException();
        }

        public override CompanyLawVerificationListItemResponseViewModel GetDataViewModel(DAL.CompanyLawVerificationListItemResponse data)
        {
            throw new NotImplementedException();
        }

        public override void Update(CompanyLawVerificationListItemResponseViewModel model)
        {
            var companyLawVerificationListResponse = this.GetDataByID(model.CompanyLawVerificationListItemResponseId);

            companyLawVerificationListResponse.CompanyLawId = model.CompanyLawId;
            companyLawVerificationListResponse.LawVerificationListId = model.LawVerificationListId;
            companyLawVerificationListResponse.LawVerificationListItemId = model.LawVerificationListItemId;
            companyLawVerificationListResponse.ImplementationTypeId = model.ImplementationTypeId;
            companyLawVerificationListResponse.CreateCompanyLawAction = model.CreateCompanyLawAction;
            companyLawVerificationListResponse.CompanyLawActionType = model.CompanyLawActionType;
            companyLawVerificationListResponse.Comments = model.Comments;
            companyLawVerificationListResponse.LastHandler = model.LastHandler;
            companyLawVerificationListResponse.ModifiedDate = DateTime.Now;
            //companyLawVerificationListResponse.LastHandler = -1;
            //companyLawVerificationListResponse.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CompanyLawVerificationListItemResponse;
        }

        public List<CompanyLawVerificationListItemResponseViewModel> GetCompanyLawVerificationListItemResponse(int companyLawId, int lawVerificationListId)
        {
            var l = new List<CompanyLawVerificationListItemResponseViewModel>();
            var r = this.dbSet.Where(x => x.CompanyLawId.Equals(companyLawId) && x.LawVerificationListId.Equals(lawVerificationListId)).ToList();
            foreach (var item in this.context.LawVerificationListItem.Where(x => x.LawVerificationListId.Equals(lawVerificationListId) && !x.IsDeleted))
            {
                var o = new CompanyLawVerificationListItemResponseViewModel()
                {
                    LawVerificationListId = item.LawVerificationListId,
                    LawVerificationListItemId = item.LawVerificationListItemId,
                    Reference = item.Reference,
                    Description = item.Description
                };

                var response = r.SingleOrDefault(x => x.CompanyLawId.Equals(companyLawId) && x.LawVerificationListId.Equals(lawVerificationListId) && x.LawVerificationListItemId.Equals(item.LawVerificationListItemId));
                if (response != null)
                {
                    o.CompanyLawVerificationListItemResponseId = response.CompanyLawVerificationListItemResponseId;
                    o.ImplementationTypeId = response.ImplementationTypeId;
                    o.CreateCompanyLawAction = response.CreateCompanyLawAction;
                    o.CompanyLawActionType = response.CompanyLawActionType;
                    o.Comments = response.Comments;
                    o.LastHandler = response.LastHandler;
                    o.ModifiedDate = response.ModifiedDate;
                }

                l.Add(o);
            }
            return l;
        }

        public void CopyCompanyLawVerificationListBetweenCompanyLaws(int copyingByCompanyLawId, int copyingToCompanyLawId)
        {
            var entities = this.GetData(x => x.CompanyLawId == copyingByCompanyLawId).AsNoTracking();

            this.dbSet.AddRange(entities.Select(x => new CompanyLawVerificationListItemResponse
            {
                Comments = x.Comments,
                CompanyLawActionType = x.CompanyLawActionType,
                CompanyLawId = copyingToCompanyLawId,
                CreateCompanyLawAction = x.CreateCompanyLawAction,
                ImplementationTypeId = x.ImplementationTypeId,
                LawVerificationListId = x.LawVerificationListId,
                LawVerificationListItemId = x.LawVerificationListItemId,
                ModifiedDate = DateTime.Now
            }));

            this.context.SaveChanges();
        }

        public void DeleteByCompanyLawId(int companyLawId)
        {
            this.dbSet.RemoveRange(GetData(x => x.CompanyLawId == companyLawId));
            this.context.SaveChanges();
        }
    }
}
