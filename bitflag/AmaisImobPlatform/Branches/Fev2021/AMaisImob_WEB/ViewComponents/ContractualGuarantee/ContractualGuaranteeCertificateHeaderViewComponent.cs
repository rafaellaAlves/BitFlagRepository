using AMaisImob_WEB.BLL;
using AMaisImob_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.ContractualGuarantee
{
    public class ContractualGuaranteeCertificateHeaderViewComponent : ViewComponent
    {
        private readonly CertificateContractualMemberFunctions certificateContractualMemberFunctions;
        private readonly CertificateContractualViewFunctions certificateContractualViewFunctions;

        public ContractualGuaranteeCertificateHeaderViewComponent(BLL.CertificateContractualMemberFunctions certificateContractualMemberFunctions, CertificateContractualViewFunctions certificateContractualViewFunctions)
        {
            this.certificateContractualMemberFunctions = certificateContractualMemberFunctions;
            this.certificateContractualViewFunctions = certificateContractualViewFunctions;
        }

        public async Task<IViewComponentResult> InvokeAsync(int certificateContractualId) => await Task.Run(() => View(new ContractualGuaranteeCertificateHeaderViewModel(certificateContractualViewFunctions.GetDataViewModel(certificateContractualViewFunctions.GetDataByID(certificateContractualId)), certificateContractualMemberFunctions.GetDataViewModel(certificateContractualMemberFunctions.GetData(x => x.CertificateContractualId == certificateContractualId)))));
    }
}
