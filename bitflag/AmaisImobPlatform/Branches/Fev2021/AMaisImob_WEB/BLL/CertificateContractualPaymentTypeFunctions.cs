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
    public class CertificateContractualPaymentTypeFunctions : BLL.Shared.BLLBasicListFunctions<CertificateContractualPaymentType, CertificateContractualPaymentType>
    {
        public CertificateContractualPaymentTypeFunctions(AMaisImob_HomologContext context) : base(context, "CertificateContractualPaymentTypeId")
        {
        }

        public override List<CertificateContractualPaymentType> GetDataViewModel(IEnumerable<CertificateContractualPaymentType> data) => data.ToList();

        public override CertificateContractualPaymentType GetDataViewModel(CertificateContractualPaymentType data) => data;

        public async Task<CertificateContractualPaymentType> GetDataByExternalCode(string externalCode) => await this.dbSet.SingleOrDefaultAsync(x => x.ExternalCode == externalCode);

        protected override void SetDbSet() => this.dbSet = context.CertificateContractualPaymentType;
    }
}
