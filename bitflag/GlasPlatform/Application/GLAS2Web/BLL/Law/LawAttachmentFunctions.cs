using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO.Law;
using Microsoft.AspNetCore.Http;

namespace BLL.Law
{
    public class LawAttachmentFunctions : BLLBasicFunctions<DAL.LawAttachment, DTO.Law.LawAttachmentViewModel>
    {

        public LawAttachmentFunctions(DAL.GLAS2Context context)
           : base(context, "LawAttachmentId")
        {
        }

        public override int Create(DTO.Law.LawAttachmentViewModel model)
        {
            var lawAttachment = new DAL.LawAttachment()
            {
                LawId = model.LawId,
                ContentType = model.ContentType,
                FileName = model.FileName,
                FilePath = model.FilePath,
                Length = model.Length,
                Name = model.Name
            };

            this.dbSet.Add(lawAttachment);
            this.context.SaveChanges();

            return lawAttachment.LawAttachmentId;
        }

        public int Create(DTO.Law.LawAttachmentViewModel model, System.IO.Stream stream, string fullPath)
        {
            var LawAttachmentId = this.Create(model);
            using (var fileStream = System.IO.File.Create(fullPath))
            {
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                stream.CopyTo(fileStream);
            }
            return LawAttachmentId;
        }

        public override void Delete(object id)
        {
            var LawAttachment = this.GetDataByID(id);

            LawAttachment.IsDeleted = true;
            LawAttachment.LastHandler = -1;
            LawAttachment.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        public void DeleteByLawId(int LawId, string pathToDelete)
        {
            var LawAttachment = this.GetLawAttachmentByLawId(LawId);
            if (LawAttachment != null)
            {
                System.IO.File.Delete(pathToDelete);
                this.Delete(LawAttachment.LawAttachmentId);
            }
        }

        public override List<LawAttachmentViewModel> GetDataViewModel(IQueryable<LawAttachment> data)
        {
            var r = (from y in data.ToList()
                     select new DTO.Law.LawAttachmentViewModel()
                     {
                         LawAttachmentId = y.LawAttachmentId,
                         LawId = y.LawId,
                         CreatedDate = y.CreatedDate,
                         ContentType = y.ContentType,
                         FileName = y.FileName,
                         FilePath = y.FilePath,
                         Length = y.Length,
                         Name = y.Name,
                         FullLaw = y.FullLaw
                     }).ToList();

            return r;
        }

        public override LawAttachmentViewModel GetDataViewModel(LawAttachment data)
        {
            return new DTO.Law.LawAttachmentViewModel()
            {
                LawAttachmentId = data.LawAttachmentId,
                LawId = data.LawId,
                ContentType = data.ContentType,
                FileName = data.FileName,
                FilePath = data.FilePath,
                Length = data.Length,
                Name = data.Name,
                CreatedDate = data.CreatedDate,
                FullLaw = data.FullLaw
            };
        }

        public override void Update(LawAttachmentViewModel model)
        {
            var LawAttachment = this.GetDataByID(model.LawAttachmentId);

            LawAttachment.ContentType = model.ContentType;
            LawAttachment.FileName = model.FileName;
            LawAttachment.FilePath = model.FilePath;
            LawAttachment.Length = model.Length;
            LawAttachment.Name = model.Name;

            LawAttachment.LastHandler = -1;
            LawAttachment.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        public DTO.Law.LawAttachmentViewModel GetLawAttachmentByLawId(int lawId)
        {
            var LawAttachment = this.dbSet.FirstOrDefault(x => x.LawId == lawId && !x.IsDeleted);
            if (LawAttachment != null)
            {
                return this.GetDataViewModel(LawAttachment);
            }
            else
            {
                return null;
            }
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Lawattachment;
        }

        public DTO.Law.LawAttachmentViewModel GetLawAttachmentFromIFormFile(int lawId, IFormFile file, string filePath)
        {
            return new DTO.Law.LawAttachmentViewModel()
            {
                LawId = lawId,
                ContentType = file.ContentType,
                FileName = file.FileName,
                FilePath = filePath,
                Length = file.Length,
                Name = file.Name
            };
        }

        public async Task RemoveFullLaw(int lawId)
        {
            var lawAttachments = this.dbSet.Where(x => x.LawId == lawId && x.FullLaw);
            foreach (var item in lawAttachments) item.FullLaw = false;

            this.dbSet.UpdateRange(lawAttachments);
            await this.context.SaveChangesAsync();
        }

        public async Task SetFullLaw(int lawAttachmentId)
        {
            var lawAttachment = GetDataByID(lawAttachmentId);
            lawAttachment.FullLaw = true;

            this.dbSet.Update(lawAttachment);
            await this.context.SaveChangesAsync();
        }
    }
}
