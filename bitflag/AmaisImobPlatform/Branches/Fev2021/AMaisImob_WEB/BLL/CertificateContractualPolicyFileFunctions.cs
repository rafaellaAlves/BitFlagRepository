using AMaisImob_DB.Models;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class CertificateContractualPolicyFileFunctions : BLLBasicFunctions<CertificateContractualApolicyFile, CertificateContractualApolicyFile>
    {
        public CertificateContractualPolicyFileFunctions(AMaisImob_HomologContext context) : base(context, "CertificateContractualApolicyFileId")
        {
        }

        public override int Create(CertificateContractualApolicyFile model)
        {
            this.dbSet.Add(model);
            this.context.SaveChanges();

            return model.CertificateContractualApolicyFileId;
        }

        public override void Delete(object id)
        {
            var entity = GetDataByID(id);

            this.dbSet.Remove(entity);
            this.context.SaveChanges();
        }

        public override List<CertificateContractualApolicyFile> GetDataViewModel(IEnumerable<CertificateContractualApolicyFile> data)
        {
            return data.ToList();
        }

        public override CertificateContractualApolicyFile GetDataViewModel(CertificateContractualApolicyFile data)
        {
            return data;
        }

        public override void Update(CertificateContractualApolicyFile model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CertificateContractualPolicyFile;
        }
    }
}
