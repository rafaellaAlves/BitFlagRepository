using AMaisImob_WEB.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.ContractualGuarantee.File
{
    [ViewComponent(Name = "CertificateContractualPendencyFile")]
    public class CertificateContractualPendencyFileListViewComponent : ViewComponent
    {
        private readonly CertificateContractualPendencyFileFunctions certificateContractualPendencyFileFunctions;

        public CertificateContractualPendencyFileListViewComponent(CertificateContractualPendencyFileFunctions certificateContractualPendencyFileFunctions)
        {
            this.certificateContractualPendencyFileFunctions = certificateContractualPendencyFileFunctions;
        }

        public async Task<IViewComponentResult> InvokeAsync(int certificateContractualId) => await Task.Run(async () => View("List", await certificateContractualPendencyFileFunctions.GetData(x => x.CertificateContractualId == certificateContractualId).ToListAsync()));
    }
}
