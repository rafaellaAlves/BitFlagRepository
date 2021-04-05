using DTO.Contract;
using Microsoft.AspNetCore.Mvc;
using Services.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Contract
{
    public class ContractClientViewComponent : ViewComponent
    {
        private readonly ClientServices clientServices;
        private readonly ClientContactServices clientContactServices;
        private readonly ClientCollectionAddressServices clientCollectionAddressServices;

        public ContractClientViewComponent(ClientServices clientServices, ClientContactServices clientContactServices, ClientCollectionAddressServices clientCollectionAddressServices)
        {
            this.clientServices = clientServices;
            this.clientContactServices = clientContactServices;
            this.clientCollectionAddressServices = clientCollectionAddressServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? clientId, string contactName, string contactCpf, string contactRole, string contactPhone, string contactMobilePhone, string contactEmail, IEnumerable<int> addressesId)
        {
            ContractClientViewModel r = new ContractClientViewModel
            {
                ContactName = contactName,
                ContactPhone = contactPhone,
                ContactMobilePhone = contactMobilePhone,
                ContactEmail = contactEmail,
                ContactCpf = contactCpf,
                ContactRole = contactRole,
                ClientCollectionAddresses = await clientCollectionAddressServices.GetViewModelAsNoTrackingAsync(x => addressesId.Contains(x.ClientCollectionAddressId))
            };

            if (clientId.HasValue)
            {
                r.Client = await clientServices.GetViewModelByIdAsync(clientId.Value);
                r.ClientContact = await clientContactServices.GetViewModelAsNoTrackingAsync(x => x.ClientId == clientId);
            }

            return await Task.Run(() => View(r));
        }
    }
}
