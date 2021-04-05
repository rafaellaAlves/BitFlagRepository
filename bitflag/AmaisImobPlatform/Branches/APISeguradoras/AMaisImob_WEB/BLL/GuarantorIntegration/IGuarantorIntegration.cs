using AMaisImob_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL.GuarantorIntegration
{
    public interface IGuarantorIntegration
    {
        string Send(CertificateContractualViewModel certificateContractualViewModel, List<CertificateContractualMemberViewModel> certificateContractualMemberViewModels);
        string ProcessStatus<T>(T data);
        GuarantorProvider GetGuarantorProvider();
    }
}
