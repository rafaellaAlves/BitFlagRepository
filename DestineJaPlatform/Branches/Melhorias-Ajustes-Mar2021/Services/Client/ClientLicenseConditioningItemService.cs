using ApplicationDbContext.Models;
using DTO.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Client
{
    public class ClientLicenseConditioningItemService : Shared.BaseServices<ClientLicenseConditioningItem, ClientLicenseConditioningItemViewModel, int>
    {
        public ClientLicenseConditioningItemService(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ClientLicenseConditioningItemId")
        {
        }
    }
}
