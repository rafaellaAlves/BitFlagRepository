using AMaisImob_WEB.BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.CertificateContractualInstallment
{
    public class CertificateContractualInstallmentViewComponent : ViewComponent
    {
        private readonly CertificateContractualFunctions certificateContractualFunctions;

        public CertificateContractualInstallmentViewComponent(CertificateContractualFunctions certificateContractualFunctions)
        {
            this.certificateContractualFunctions = certificateContractualFunctions;
        }

        public async Task<IViewComponentResult> InvokeAsync(int certificateContractualId) => await Task.Run(() => View(certificateContractualFunctions.GetDataViewModel(certificateContractualFunctions.GetDataByID(certificateContractualId))));
    }
}
