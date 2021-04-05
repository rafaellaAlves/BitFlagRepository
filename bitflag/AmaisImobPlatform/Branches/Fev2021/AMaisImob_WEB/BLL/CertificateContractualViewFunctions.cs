using AMaisImob_DB.Models;
using AMaisImob_WEB.BLL.Shared;
using AMaisImob_WEB.Models;
using AMaisImob_WEB.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class CertificateContractualViewFunctions : BLLBasicListFunctions<CertificateContractualView, _CertificateContractualViewModel>
    {
        public CertificateContractualViewFunctions(AMaisImob_HomologContext context) : base(context, "CertificateContractualId")
        {
        }

        public override List<_CertificateContractualViewModel> GetDataViewModel(IEnumerable<CertificateContractualView> data)
        {
            return data.Select(x => x.CopyToEntity<_CertificateContractualViewModel>()).ToList();
        }

        public override _CertificateContractualViewModel GetDataViewModel(CertificateContractualView data)
        {
            return data.CopyToEntity<_CertificateContractualViewModel>();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CertificateContractualView;
        }
    }
}
