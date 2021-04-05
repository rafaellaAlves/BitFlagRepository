using AMaisImob_WEB.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.ContractualGuarantee.File
{
    [ViewComponent(Name = "CertificateContractualPolicyFile")]
    public class CertificateContractualPolicyFileListViewComponent : ViewComponent
    {
        private readonly CertificateContractualPolicyFileFunctions certificateContractualApolicyFileFunctions;

        public CertificateContractualPolicyFileListViewComponent(CertificateContractualPolicyFileFunctions certificateContractualApolicyFileFunctions)
        {
            this.certificateContractualApolicyFileFunctions = certificateContractualApolicyFileFunctions;
        }

        public async Task<IViewComponentResult> InvokeAsync(int certificateContractualId) => await Task.Run(async () => View("List", await certificateContractualApolicyFileFunctions.GetData(x => x.CertificateContractualId == certificateContractualId).ToListAsync()));
    }
}
