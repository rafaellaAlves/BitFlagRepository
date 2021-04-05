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
    public class CompanyLawCommentFunctions : BLLBasicFunctions<DAL.CompanyLawComment, DTO.Company.CompanyLawCommentViewModel>
    {
        private readonly UserManager<DAL.Identity.User> userManager;
        private readonly BLL.User.UserFunctions userFunctions;

        public CompanyLawCommentFunctions(DAL.GLAS2Context context, UserManager<DAL.Identity.User> userManager)
            : base(context, "CompanyLawCommentId")
        {
            this.userFunctions = new BLL.User.UserFunctions(context, userManager);
            this.userManager = userManager;
        }

        public override int Create(CompanyLawCommentViewModel model)
        {
            var companyLawComment = new DAL.CompanyLawComment();

            companyLawComment.CompanyLawId = model.CompanyLawId;
            companyLawComment.Text = model.Text;
            companyLawComment.AuthorId = model.AuthorId;

            this.dbSet.Add(companyLawComment);
            this.context.SaveChanges();

            return companyLawComment.CompanyLawCommentId;
        }

        public override void Delete(object id)
        {
            var companyLawComment = this.GetDataByID(id);

            companyLawComment.IsDeleted = true;
            companyLawComment.LastHandler = -1;
            companyLawComment.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        public override List<CompanyLawCommentViewModel> GetDataViewModel(IQueryable<DAL.CompanyLawComment> data)
        {
            var q = (from y in data.ToList()
                     join __ur in this.context.User on y.AuthorId equals __ur.Id into _ur
                     where y.AuthorId > 0
                     from ur in _ur.DefaultIfEmpty()
                     group new { y, ur } by new { y, ur } into g
                     select new CompanyLawCommentViewModel()
                     {
                        CompanyLawCommentId = g.Key.y.CompanyLawCommentId,
                        CompanyLawId = g.Key.y.CompanyLawId,
                        Text = g.Key.y.Text,
                        AuthorId = g.Key.y.AuthorId,
                        Name = g.Key.ur.FullName,
                        CreatedDate = g.Key.y.CreatedDate.ToBrazilianDateTimeFormat()
                     }).ToList();

            return q;
        }

        public override CompanyLawCommentViewModel GetDataViewModel(DAL.CompanyLawComment data)
        {                
                return new CompanyLawCommentViewModel()
            {
                CompanyLawCommentId = data.CompanyLawCommentId,
                CompanyLawId = data.CompanyLawId,
                Text = data.Text,
                AuthorId = data.AuthorId,
                CreatedDate = data.CreatedDate.ToBrazilianDateTimeFormat()
                };
        }

        public override void Update(CompanyLawCommentViewModel model)
        {
            var companyLawComment = this.GetDataByID(model.CompanyLawCommentId);

            companyLawComment.CompanyLawId = model.CompanyLawId;
            companyLawComment.Text = model.Text;
            companyLawComment.AuthorId = model.AuthorId;
            companyLawComment.LastHandler = -1;
            companyLawComment.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CompanyLawComment;
        }
    }
}
