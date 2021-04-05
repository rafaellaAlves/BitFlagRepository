using AMaisImob_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class CertificateContractualIncomeTypeFunctions : BLL.Shared.BLLBasicListFunctions<CertificateContractualIncomeType, CertificateContractualIncomeType>
    {
        public CertificateContractualIncomeTypeFunctions(AMaisImob_HomologContext context) : base(context, "CertificateContractualIncomeTypeId")
        {
        }

        public override List<CertificateContractualIncomeType> GetDataViewModel(IEnumerable<CertificateContractualIncomeType> data)
        {
            throw new NotImplementedException();
        }

        public override CertificateContractualIncomeType GetDataViewModel(CertificateContractualIncomeType data)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CertificateContractualIncomeType;
        }
    }
}
