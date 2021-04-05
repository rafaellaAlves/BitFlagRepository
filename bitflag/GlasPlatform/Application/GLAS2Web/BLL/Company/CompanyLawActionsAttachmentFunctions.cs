using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO.Company;
using Microsoft.AspNetCore.Http;

namespace BLL.Company
{
    public class CompanyLawActionsAttachmentFunctions : BLLBasicFunctions<DAL.CompanyLawActionAttachment, DTO.Company.CompanyLawActionAttachmentViewModel>
    {

        public CompanyLawActionsAttachmentFunctions(DAL.GLAS2Context context)
           : base(context, "CompanyLawActionAttachmentId")
        {

        }

        public override int Create(CompanyLawActionAttachmentViewModel model)
        {
            var companyLawActionAttachment = new DAL.CompanyLawActionAttachment()
            {
                CompanyLawActionId = model.CompanyLawActionId,
                ContentType = model.ContentType,
                FileName = model.FileName,
                FilePath = model.FilePath,
                Length = model.Length,
                Name = model.Name
            };

            this.dbSet.Add(companyLawActionAttachment);
            this.context.SaveChanges();

            return companyLawActionAttachment.CompanyLawActionAttachmentId;
        }

        public int Create(DTO.Company.CompanyLawActionAttachmentViewModel model, System.IO.Stream stream, string fullPath)
        {
            var CompanyLawActionAttachmentId = this.Create(model);
            using (var fileStream = System.IO.File.Create(fullPath))
            {
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                stream.CopyTo(fileStream);
            }
            return CompanyLawActionAttachmentId;
        }

        public override void Delete(object id)
        {

            var CompanyLawActionAttachment = this.GetDataByID(id);

            CompanyLawActionAttachment.IsDeleted = true;
            CompanyLawActionAttachment.LastHandler = -1;
            CompanyLawActionAttachment.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        public void DeleteByLawActionId(int LawId, string pathToDelete)
        {
            var CompanyLawActionAttachment = this.GetCompanyLawActionAttachmentByLawActionId(LawId);
            if (CompanyLawActionAttachment != null)
            {
                System.IO.File.Delete(pathToDelete);
                this.Delete(CompanyLawActionAttachment.CompanyLawActionAttachmentId);
            }
        }

        public override List<CompanyLawActionAttachmentViewModel> GetDataViewModel(IQueryable<CompanyLawActionAttachment> data)
        {
            var x = data.ToList();
            return (from y in x
                    select new DTO.Company.CompanyLawActionAttachmentViewModel()
                    {
                        CompanyLawActionAttachmentId = y.CompanyLawActionAttachmentId,
                        CompanyLawActionId = y.CompanyLawActionId,
                        CreatedDate = y.CreatedDate,
                        ContentType = y.ContentType,
                        FileName = y.FileName,
                        FilePath = y.FilePath,
                        Length = y.Length,
                        Name = y.Name
                    }).ToList();

        }

        public override CompanyLawActionAttachmentViewModel GetDataViewModel(CompanyLawActionAttachment data)
        {
            return new DTO.Company.CompanyLawActionAttachmentViewModel()
            {
                CompanyLawActionAttachmentId = data.CompanyLawActionAttachmentId,
                CompanyLawActionId = data.CompanyLawActionId,
                ContentType = data.ContentType,
                FileName = data.FileName,
                FilePath = data.FilePath,
                Length = data.Length,
                Name = data.Name,
                CreatedDate = data.CreatedDate
            };
        }

        public override void Update(CompanyLawActionAttachmentViewModel model)
        {
            var CompanyLawActionAttachment = this.GetDataByID(model.CompanyLawActionAttachmentId);

            CompanyLawActionAttachment.ContentType = model.ContentType;
            CompanyLawActionAttachment.FileName = model.FileName;
            CompanyLawActionAttachment.FilePath = model.FilePath;
            CompanyLawActionAttachment.Length = model.Length;
            CompanyLawActionAttachment.Name = model.Name;

            CompanyLawActionAttachment.LastHandler = -1;
            CompanyLawActionAttachment.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        public DTO.Company.CompanyLawActionAttachmentViewModel GetCompanyLawActionAttachmentByLawActionId(int companyLawActionId)
        {
            var CompanyLawActionAttachment = this.dbSet.FirstOrDefault(x => x.CompanyLawActionId == companyLawActionId && !x.IsDeleted);
            if (CompanyLawActionAttachment != null)
            {
                return this.GetDataViewModel(CompanyLawActionAttachment);
            }
            else
            {
                return null;
            }
        }

        public bool CompanyLawActionHasAttachment(int companylawActionId)
        {
            return this.dbSet.Any(x => x.CompanyLawActionId == companylawActionId);
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CompanyLawActionAttachment;
        }

        public DTO.Company.CompanyLawActionAttachmentViewModel GetLawActionAttachmentFromIFormFile(int companyLawActionId, IFormFile file, string filePath)
        {
            return new DTO.Company.CompanyLawActionAttachmentViewModel()
            {
                CompanyLawActionId = companyLawActionId,
                ContentType = file.ContentType,
                FileName = file.FileName,
                FilePath = filePath,
                Length = file.Length,
                Name = file.Name
            };
        }
    }
}
