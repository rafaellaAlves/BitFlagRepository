using AMaisImob_DB.Models;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class CertificateContractualPendencyFileFunctions : BLLBasicFunctions<CertificateContractualPendencyFile, CertificateContractualPendencyFile>
    {
        public CertificateContractualPendencyFileFunctions(AMaisImob_HomologContext context) : base(context, "CertificateContractualPendencyFileId")
        {
        }

        public override int Create(CertificateContractualPendencyFile model)
        {
            this.dbSet.Add(model);
            this.context.SaveChanges();

            return model.CertificateContractualPendencyFileId;
        }

        public override void Delete(object id)
        {
            var entity = GetDataByID(id);

            this.dbSet.Remove(entity);
            this.context.SaveChanges();
        }


        public override List<CertificateContractualPendencyFile> GetDataViewModel(IEnumerable<CertificateContractualPendencyFile> data) => data.ToList();

        public override CertificateContractualPendencyFile GetDataViewModel(CertificateContractualPendencyFile data) => data;

        public override void Update(CertificateContractualPendencyFile model) => throw new NotImplementedException();

        protected override void SetDbSet() => this.dbSet = context.CertificateContractualPendencyFile;
    }
}
