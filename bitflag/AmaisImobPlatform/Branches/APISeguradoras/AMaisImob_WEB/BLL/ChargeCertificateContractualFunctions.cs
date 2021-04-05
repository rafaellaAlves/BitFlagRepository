using AMaisImob_DB.Models;
using AMaisImob_WEB.Models.Charge;
using AMaisImob_WEB.Utils;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class ChargeCertificateContractualFunctions : BLLBasicFunctions<ChargeCertificateContractual, ChargeCertificateContractualViewModel>
    {
        public ChargeCertificateContractualFunctions(AMaisImob_HomologContext context) : base(context, "ChargeCertificateContractualId")
        {
        }

        public override int Create(ChargeCertificateContractualViewModel model)
        {
            var entity = model.CopyToEntity<ChargeCertificateContractual>();
            this.dbSet.Add(entity);
            this.context.SaveChanges();

            return entity.ChargeCertificateContractualId;
        }

        public override void Delete(object id)
        {
            this.dbSet.Add(GetDataByID(id));
            this.context.SaveChanges();
        }

        public void DeleteRange(IEnumerable<ChargeCertificateContractual> entities)
        {
            this.dbSet.RemoveRange(entities);
            this.context.SaveChanges();
        }

        public override List<ChargeCertificateContractualViewModel> GetDataViewModel(IEnumerable<ChargeCertificateContractual> data) => data.Select(x => x.CopyToEntity<ChargeCertificateContractualViewModel>()).ToList();

        public override ChargeCertificateContractualViewModel GetDataViewModel(ChargeCertificateContractual data) => data.CopyToEntity<ChargeCertificateContractualViewModel>();

        public override void Update(ChargeCertificateContractualViewModel model)
        {
            var entity = GetDataByID(model.ChargeCertificateContractualId);

            entity.AlternativePrice = model.AlternativePrice;
            entity.AlternativeTotal = model.AlternativeTotal;

            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }

        public void UpdateFile(ChargeCertificateContractualViewModel model)
        {
            var entity = GetDataByID(model.ChargeCertificateContractualId);

            entity.FileName = model.FileName;
            entity.GuidFileName = model.GuidFileName;
            entity.MimeType = model.MimeType;

            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }
        public void DeleteFile(int chargeCertificateContractualId)
        {
            var entity = GetDataByID(chargeCertificateContractualId);

            entity.InvoiceFileName = null;
            entity.InvoiceGuidFileName = null;
            entity.InvoiceMimeType = null;

            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }

        public void UpdateInvoiceFile(ChargeCertificateContractualViewModel model)
        {
            var entity = GetDataByID(model.ChargeCertificateContractualId);

            entity.InvoiceFileName = model.InvoiceFileName;
            entity.InvoiceGuidFileName = model.InvoiceGuidFileName;
            entity.InvoiceMimeType = model.InvoiceMimeType;

            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }
        public void DeleteInvoiceFile(int chargeCertificateContractualId)
        {
            var entity = GetDataByID(chargeCertificateContractualId);

            entity.InvoiceFileName = null;
            entity.InvoiceGuidFileName = null;
            entity.InvoiceMimeType = null;

            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.ChargeCertificateContractual;
        }
    }
}
