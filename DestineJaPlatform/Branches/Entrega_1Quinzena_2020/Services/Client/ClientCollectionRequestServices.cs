using ApplicationDbContext.Models;
using DTO.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Client
{
    public class ClientCollectionRequestServices : Shared.BaseServices<ClientCollectionRequest, ClientCollectionRequestViewModel, int>
    {
        public ClientCollectionRequestServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ClientCollectionRequestId")
        {
        }
    }
}
