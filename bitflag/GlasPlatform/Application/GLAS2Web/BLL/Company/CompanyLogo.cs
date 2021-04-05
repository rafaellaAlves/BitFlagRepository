using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL;
using DTO.Company;
using Microsoft.AspNetCore.Http;

namespace BLL.Company
{
    public class CompanyLogoFunctions : BLLBasicFunctions<DAL.CompanyLogo, DTO.Company.CompanyLogo>
    {
        public CompanyLogoFunctions(DAL.GLAS2Context context)
            : base(context, "CompanyLogoId")
        {

        }

        public void SaveCompanyLogoFile(System.IO.Stream stream, string filePath)
        {

        }

        public override int Create(DTO.Company.CompanyLogo model)
        {
            var companyLogo = new DAL.CompanyLogo()
            {
                CompanyId = model.CompanyId,
                ContentType = model.ContentType,
                FileName = model.FileName,
                FilePath = model.FilePath,
                Length = model.Length,
                Name = model.Name
            };

            this.dbSet.Add(companyLogo);
            this.context.SaveChanges();

            return companyLogo.CompanyLogoId;
        }

        public int Create(DTO.Company.CompanyLogo model, System.IO.Stream stream, string fullPath)
        {
            var companyLogoId = this.Create(model);
            using (var fileStream = System.IO.File.Create(fullPath))
            {
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                stream.CopyTo(fileStream);
            }
            return companyLogoId;
        }

        public override void Delete(object id)
        {
            var companyLogo = this.GetDataByID(id);

            companyLogo.IsDeleted = true;
            companyLogo.LastHandler = -1;
            companyLogo.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        public void DeleteByCompanyId(int companyId,string pathToDelete)
        {
            var companyLogo = this.GetCompanyLogoByCompanyId(companyId);
            if (companyLogo != null)
            {
                System.IO.File.Delete(pathToDelete);
                this.Delete(companyLogo.CompanyLogoId);
            }
        }

        public override List<DTO.Company.CompanyLogo> GetDataViewModel(IQueryable<DAL.CompanyLogo> data)
        {
            var r = (from y in data
                     select new DTO.Company.CompanyLogo()
                     {
                         CompanyLogoId = y.CompanyLogoId,
                         CompanyId = y.CompanyId,
                         ContentType = y.ContentType,
                         FileName = y.FileName,
                         FilePath = y.FilePath,
                         Length = y.Length,
                         Name = y.Name
                     }).ToList();

            return r;
        }

        public override DTO.Company.CompanyLogo GetDataViewModel(DAL.CompanyLogo data)
        {
            return new DTO.Company.CompanyLogo()
            {
                CompanyLogoId = data.CompanyLogoId,
                CompanyId = data.CompanyId,
                ContentType = data.ContentType,
                FileName = data.FileName,
                FilePath = data.FilePath,
                Length = data.Length,
                Name = data.Name
            };
        }

        public override void Update(DTO.Company.CompanyLogo model)
        {
            var companyLogo = this.GetDataByID(model.CompanyLogoId);

            companyLogo.ContentType = model.ContentType;
            companyLogo.FileName = model.FileName;
            companyLogo.FilePath = model.FilePath;
            companyLogo.Length = model.Length;
            companyLogo.Name = model.Name;

            companyLogo.LastHandler = -1;
            companyLogo.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        public DTO.Company.CompanyLogo GetCompanyLogoByCompanyId(int companyId)
        {
            var companyLogo = this.dbSet.FirstOrDefault(x => x.CompanyId == companyId && !x.IsDeleted);
            if(companyLogo != null)
            {
                return this.GetDataViewModel(companyLogo);
            }
            else
            {
                return null;
            }
        }

        public bool CompanyHasLogo(int companyId)
        {
            return this.dbSet.Any(x => x.CompanyId == companyId);
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CompanyLogo;
        }

        public DTO.Company.CompanyLogo GetCompanyLogoFromIFormFile(int companyId, IFormFile file, string filePath)
        {
            return new DTO.Company.CompanyLogo()
            {
                CompanyId = companyId,
                ContentType = file.ContentType,
                FileName = file.FileName,
                FilePath = filePath,
                Length = file.Length,
                Name = file.Name
            };
        }
    }
}
