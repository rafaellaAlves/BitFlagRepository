using AMaisImob_DB.Models;
using AMaisImob_WEB.Models;
using AMaisImob_WEB.Utils;
using BLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class CertificateContractualInstallmentFunctions : BLLBasicFunctions<CertificateContractualInstallment, CertificateContractualInstallmentViewModel>
    {
        public CertificateContractualInstallmentFunctions(AMaisImob_HomologContext context) : base(context, "CertificateContractualInstallmentId")
        {
        }

        public override int Create(CertificateContractualInstallmentViewModel model)
        {
            var entity = model.CopyToEntity<CertificateContractualInstallment>();

            this.dbSet.Add(entity);
            this.context.SaveChanges();

            return entity.CertificateContractualInstallmentId;
        }

        public async Task CreateOrUpdateRange(IEnumerable<CertificateContractualInstallmentViewModel> models)
        {
            var newEntities = models.Where(x => !x.CertificateContractualInstallmentId.HasValue).Select(x => x.CopyToEntity<CertificateContractualInstallment>()).ToList();

            await this.dbSet.AddRangeAsync(newEntities);

            foreach (var item in models.Where(x => x.CertificateContractualInstallmentId.HasValue))
            {
                var entity = await dbSet.SingleAsync(x => x.CertificateContractualInstallmentId == item.CertificateContractualInstallmentId);

                //if (entity.Paid) continue;

                entity.Price = item.Price.Value;
                entity.Paid = item.Paid;
                entity.Date = item.Date.Value;

                this.dbSet.Update(entity);
            }

            await this.context.SaveChangesAsync();
        }

        public async Task UpdateCertificateContractualInstallmentPaid(int certificateContractualInstallmentId, bool paid)
        {
            var entity = await this.dbSet.SingleAsync(x => x.CertificateContractualInstallmentId == certificateContractualInstallmentId);

            entity.Paid = paid;

            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }


        public override void Delete(object id)
        {
            var entity = GetDataByID(id);

            this.dbSet.Remove(entity);
            this.context.SaveChanges();
        }

        public void DeleteByCertificateContractual(int id, IEnumerable<int> certificateContractualInstallmentIds)
        {
            var entities = GetData(x => x.CertificateContractualId == id && !certificateContractualInstallmentIds.Contains(x.CertificateContractualInstallmentId));

            this.dbSet.RemoveRange(entities);
            this.context.SaveChanges();
        }

        public override List<CertificateContractualInstallmentViewModel> GetDataViewModel(IEnumerable<CertificateContractualInstallment> data) => data.Select(x => x.CopyToEntity<CertificateContractualInstallmentViewModel>()).ToList();

        public override CertificateContractualInstallmentViewModel GetDataViewModel(CertificateContractualInstallment data) => data.CopyToEntity<CertificateContractualInstallmentViewModel>();

        public override void Update(CertificateContractualInstallmentViewModel model) => throw new NotImplementedException();

        protected override void SetDbSet() => this.dbSet = context.CertificateContractualInstallment;
    }
}
