using ApplicationDbContext.Models;
using DTO.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Client
{
    public class ClientLicenseConditioningItemListService : Shared.BaseListServices<ClientLicenseConditioningItemList, ClientLicenseConditioningItemListViewModel, int>
    {
        public ClientLicenseConditioningItemListService(ApplicationDbContext.Context.ApplicationDbContext context) : base(context, "ClientLicenseConditioningItemId")
        {
        }
    }
}
