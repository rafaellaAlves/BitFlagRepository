using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DB;
using DTO.Client;
using Microsoft.AspNetCore.Http;

namespace FUNCTIONS.Client
{
    public class ClientArchiveFunctions : BasicFunctions<DB.ClientArchive, DTO.Client.ClientArchiveViewModel>
    {
        public ClientArchiveFunctions(TerraNostraContext context) 
            : base(context, "ClientArchiveId")
        {
        }

        public override int Create(ClientArchiveViewModel model)
        {
            var clientArchive = new DB.ClientArchive()
            {
                ClientId = model.ClientId,
                ContentType = model.ContentType,
                FileName = model.FileName,
                FilePath = model.FilePath,
                Length = model.Length,
                Name = model.Name,
                ClientApplicantId = model.ClientApplicantId
            };

            this.dbSet.Add(clientArchive);
            this.context.SaveChanges();

            return clientArchive.ClientArchiveId;
        }

        public int Create(ClientArchiveViewModel model, Stream stream, string fullPath)
        {
            var clientArchiveId = this.Create(model);
            using (var fileStream = File.Create(fullPath))
            {
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(fileStream);
            }
            return clientArchiveId;
        }

        public override void Delete(object id)
        {
            var clientArchive = this.GetDataByID(id);

            clientArchive.IsDeleted = true;
            clientArchive.LastHandler = -1;
            clientArchive.ModifiedDate = DateTime.Now;

            this.context.SaveChanges();
        }

        public void DeleteByAssociatedAttachmentId(int clientArchiveId, string pathToDelete)
        {
            var clientArchive = this.GetClientArchiveByClientArchiveId(clientArchiveId);
            if (clientArchive != null)
            {
                File.Delete(pathToDelete);
                this.Delete(clientArchive.ClientArchiveId);
            }
        }

        public ClientArchiveViewModel GetClientArchiveByClientArchiveId(int clientArchiveId)
        {
            var clientArchive = this.dbSet.FirstOrDefault(x => x.ClientArchiveId == clientArchiveId && !x.IsDeleted);
            if (clientArchive != null)
            {
                return this.GetDataViewModel(clientArchive);
            }
            else
            {
                return null;
            }
        }

        public bool ClientHasAttachment(int clientArchiveId)
        {
            return this.dbSet.Any(x => x.ClientArchiveId == clientArchiveId);
        }

        public ClientArchiveViewModel GetClientArchiveFromIFormFile(int clientId, IFormFile file, string filePath)
        {
            return new ClientArchiveViewModel()
            {
                ClientId = clientId,
                ContentType = file.ContentType,
                FileName = file.FileName,
                FilePath = filePath,
                Length = file.Length,
                Name = file.Name
            };
        }

        public override List<ClientArchiveViewModel> GetDataViewModel(IEnumerable<ClientArchive> data)
        {
            var x = data.ToList();
            return (from y in x
                    select new ClientArchiveViewModel()
                    {
                        ClientArchiveId = y.ClientArchiveId,
                        ClientId = y.ClientId,
                        CreatedDate = y.CreatedDate,
                        ContentType = y.ContentType,
                        FileName = y.FileName,
                        FilePath = y.FilePath,
                        Length = y.Length,
                        Name = y.Name,
                        IsDeleted = y.IsDeleted,
                        ClientApplicantId = y.ClientApplicantId
                    }).ToList();
        }

        public override ClientArchiveViewModel GetDataViewModel(ClientArchive y)
        {
            return new ClientArchiveViewModel()
            {
                ClientArchiveId = y.ClientArchiveId,
                ClientId = y.ClientId,
                CreatedDate = y.CreatedDate,
                ContentType = y.ContentType,
                FileName = y.FileName,
                FilePath = y.FilePath,
                Length = y.Length,
                Name = y.Name,
                IsDeleted = y.IsDeleted,
                ClientApplicantId = y.ClientApplicantId
            };
        }

        public override void Update(ClientArchiveViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.ClientArchive;
        }

        public void DeleteByClientApplicantId(int clientApplicantId)
        {
            var archives = this.context.ClientArchive.Where(x => x.ClientApplicantId == clientApplicantId && !x.IsDeleted);
            foreach (var item in archives)
            {
                item.IsDeleted = true;
            }

            this.context.ClientArchive.UpdateRange(archives);

            this.context.SaveChanges();
        }

        public List<ClientArchive> GetByClientApplicantId(int clientApplicantId)
        {
            return this.context.ClientArchive.Where(x => x.ClientApplicantId == clientApplicantId && !x.IsDeleted).ToList();
        }
    }
}
