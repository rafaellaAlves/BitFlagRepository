using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DTO.Law;
using DTO.Company;
using Utils;
using Microsoft.AspNetCore.Identity;

namespace BLL.Company
{
    public class CompanyLawActionCommentFunctions : BLLBasicFunctions<DAL.CompanyLawActionComment, DTO.Company.CompanyLawActionCommentViewModel>
    {
        public CompanyLawActionCommentFunctions(DAL.GLAS2Context context)
            : base(context, "CompanyLawActionCommentId")
        {
        }

        public override int Create(CompanyLawActionCommentViewModel model)
        {
            var companyLawActionComment = new DAL.CompanyLawActionComment();

            companyLawActionComment.CompanyLawActionId = model.CompanyLawActionId;
            companyLawActionComment.Text = model.Text;
            companyLawActionComment.AuthorId = model.AuthorId;

            this.dbSet.Add(companyLawActionComment);
            this.context.SaveChanges();

            return companyLawActionComment.CompanyLawActionCommentId;
        }

        public override void Delete(object id)
        {
            var companyLawComment = this.GetDataByID(id);

            companyLawComment.IsDeleted = true;
            companyLawComment.LastHandler = -1;
            companyLawComment.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        public override List<CompanyLawActionCommentViewModel> GetDataViewModel(IQueryable<DAL.CompanyLawActionComment> data)
        {
            var q = (from y in data.ToList()
                     join __ur in this.context.User on y.AuthorId equals __ur.Id into _ur
                     where y.AuthorId > 0
                     from ur in _ur.DefaultIfEmpty()
                     group new { y, ur } by new { y, ur } into g
                     select new CompanyLawActionCommentViewModel()
                     {
                         CompanyLawActionCommentId = g.Key.y.CompanyLawActionCommentId,
                         CompanyLawActionId = g.Key.y.CompanyLawActionId,
                         Text = g.Key.y.Text,
                         AuthorId = g.Key.y.AuthorId,
                         Name = g.Key.ur.FullName,
                         CreatedDate = g.Key.y.CreatedDate.ToBrazilianDateTimeFormat()
                     }).ToList();

            return q;
        }

        public override CompanyLawActionCommentViewModel GetDataViewModel(DAL.CompanyLawActionComment data)
        {
            return new CompanyLawActionCommentViewModel()
            {
                CompanyLawActionCommentId = data.CompanyLawActionCommentId,
                CompanyLawActionId = data.CompanyLawActionId,
                Text = data.Text,
                AuthorId = data.AuthorId,
                CreatedDate = data.CreatedDate.ToBrazilianDateTimeFormat()
            };
        }

        public override void Update(CompanyLawActionCommentViewModel model)
        {
            var companyLawActionComment = this.GetDataByID(model.CompanyLawActionCommentId);

            companyLawActionComment.CompanyLawActionId = model.CompanyLawActionId;
            companyLawActionComment.Text = model.Text;
            companyLawActionComment.AuthorId = model.AuthorId;
            companyLawActionComment.LastHandler = -1;
            companyLawActionComment.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CompanyLawActionComment;
        }
    }
}
