using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO.Company;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BLL.Company
{
    public class CompanyLawAttachmentFunctions : BLLBasicFunctions<DAL.CompanyLawAttachment, DTO.Company.CompanyLawAttachmentViewModel>
    {
        public CompanyLawAttachmentFunctions(DAL.GLAS2Context context)
           : base(context, "CompanyLawAttachmentId")
        {

        }

        public override int Create(CompanyLawAttachmentViewModel model)
        {
            var companyLawAttachment = new DAL.CompanyLawAttachment()
            {
                CompanyLawId = model.CompanyLawId,
                ContentType = model.ContentType,
                FileName = model.FileName,
                FilePath = model.FilePath,
                Length = model.Length,
                Name = model.Name
            };

            this.dbSet.Add(companyLawAttachment);
            this.context.SaveChanges();

            return companyLawAttachment.CompanyLawAttachmentId;
        }

        public int Create(DTO.Company.CompanyLawAttachmentViewModel model, System.IO.Stream stream, string fullPath)
        {
            var CompanyLawAttachmentId = this.Create(model);
            using (var fileStream = System.IO.File.Create(fullPath))
            {
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                stream.CopyTo(fileStream);
            }
            return CompanyLawAttachmentId;
        }

        public override void Delete(object id)
        {

            var CompanyLawAttachment = this.GetDataByID(id);

            CompanyLawAttachment.IsDeleted = true;
            CompanyLawAttachment.LastHandler = -1;
            CompanyLawAttachment.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        public void DeleteByLawId(int LawId, string pathToDelete)
        {
            var CompanyLawAttachment = this.GetCompanyLawAttachmentByLawId(LawId);
            if (CompanyLawAttachment != null)
            {
                System.IO.File.Delete(pathToDelete);
                this.Delete(CompanyLawAttachment.CompanyLawAttachmentId);
            }
        }

        public void DeleteByCompanyLawId(int companyLawId)
        {
            this.dbSet.RemoveRange(GetData(x => x.CompanyLawId == companyLawId));
            this.context.SaveChanges();
        }

        public override List<CompanyLawAttachmentViewModel> GetDataViewModel(IQueryable<CompanyLawAttachment> data)
        {
            var x = data.ToList();
            return (from y in x
                    select new DTO.Company.CompanyLawAttachmentViewModel()
                    {
                        CompanyLawAttachmentId = y.CompanyLawAttachmentId,
                        CompanyLawId = y.CompanyLawId,
                        CreatedDate = y.CreatedDate,
                        ContentType = y.ContentType,
                        FileName = y.FileName,
                        FilePath = y.FilePath,
                        Length = y.Length,
                        Name = y.Name
                    }).ToList();

        }

        public override CompanyLawAttachmentViewModel GetDataViewModel(CompanyLawAttachment data)
        {
            return new DTO.Company.CompanyLawAttachmentViewModel()
            {
                CompanyLawAttachmentId = data.CompanyLawAttachmentId,
                CompanyLawId = data.CompanyLawId,
                ContentType = data.ContentType,
                FileName = data.FileName,
                FilePath = data.FilePath,
                Length = data.Length,
                Name = data.Name,
                CreatedDate = data.CreatedDate
            };
        }

        public override void Update(CompanyLawAttachmentViewModel model)
        {
            var CompanyLawAttachment = this.GetDataByID(model.CompanyLawAttachmentId);

            CompanyLawAttachment.ContentType = model.ContentType;
            CompanyLawAttachment.FileName = model.FileName;
            CompanyLawAttachment.FilePath = model.FilePath;
            CompanyLawAttachment.Length = model.Length;
            CompanyLawAttachment.Name = model.Name;

            CompanyLawAttachment.LastHandler = -1;
            CompanyLawAttachment.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        public DTO.Company.CompanyLawAttachmentViewModel GetCompanyLawAttachmentByLawId(int companylawId)
        {
            var CompanyLawAttachment = this.dbSet.FirstOrDefault(x => x.CompanyLawId == companylawId && !x.IsDeleted);
            if (CompanyLawAttachment != null)
            {
                return this.GetDataViewModel(CompanyLawAttachment);
            }
            else
            {
                return null;
            }
        }

        public bool CompanyLawHasAttachment(int companylawId)
        {
            return this.dbSet.Any(x => x.CompanyLawId == companylawId);
        }


        protected override void SetDbSet()
        {
            this.dbSet = context.CompanyLawattachment;
        }

        public DTO.Company.CompanyLawAttachmentViewModel GetLawAttachmentFromIFormFile(int companylawId, IFormFile file, string filePath)
        {
            return new DTO.Company.CompanyLawAttachmentViewModel()
            {
                CompanyLawId = companylawId,
                ContentType = file.ContentType,
                FileName = file.FileName,
                FilePath = filePath,
                Length = file.Length,
                Name = file.Name
            };
        }

        public List<CompanyLawAttachmentListViewModel> GetCompanyLawAttachmentList(int lawId)
        {
            var connection = context.Database.GetDbConnection();
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "[dbo].[pr_GetCompanyLawAttachmentList]";

            var _codJornada = command.CreateParameter();
            _codJornada.ParameterName = "@LawId";
            _codJornada.Value = lawId;
            command.Parameters.Add(_codJornada);

            var reader = command.ExecuteReader();
            var companyLawAttachmentListViewModels = new List<CompanyLawAttachmentListViewModel>();
            while (reader.Read())
            {
                companyLawAttachmentListViewModels.Add(new CompanyLawAttachmentListViewModel
                {
                    CompanyID = (int)reader["CompanyID"],
                    RazaoSocial = (string)reader["RazaoSocial"],
                    NomeFantasia = (string)reader["NomeFantasia"],
                    CompanyLawId = (int)reader["CompanyLawId"],
                    AttachmentCount = (int)reader["AttachmentCount"],
                });
            }
            connection.Close();
            return companyLawAttachmentListViewModels;
        }

        public void CopyCompanyLawAttachmentBetweenCompanyLaws(int copyingByCompanyLawId, int copyingToCompanyLawId, IHostingEnvironment _hostingEnvironment)
        {
            var companylawAttachmentDirectory = System.IO.Path.Combine("Assets", "System", "CompanyLawAttachment");

            var entities = this.GetData(x => x.CompanyLawId == copyingByCompanyLawId && !x.IsDeleted).AsNoTracking();

            foreach (var x in entities)
            {
                var fileBytes = System.IO.File.ReadAllBytes(x.FilePath);

                var fullPath = System.IO.Path.Combine(_hostingEnvironment.ContentRootPath, companylawAttachmentDirectory, string.Format("{0}{1}", Guid.NewGuid().ToString(), System.IO.Path.GetExtension(x.FileName)));

                using (var fileStream = System.IO.File.Create(fullPath))
                {
                    fileStream.Write(fileBytes, 0, fileBytes.Length);
                }

                this.dbSet.AddRange(new CompanyLawAttachment
                {
                    CompanyLawId = copyingToCompanyLawId,
                    ContentType = x.ContentType,
                    CreatedDate = DateTime.Now,
                    FileName = x.FileName,
                    FilePath = fullPath,
                    IsActive = x.IsActive,
                    Length = x.Length,
                    Name = x.Name
                });
            }

            this.context.SaveChanges();
        }
    }
}
