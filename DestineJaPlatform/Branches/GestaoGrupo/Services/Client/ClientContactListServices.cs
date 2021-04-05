using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Client
{
    public class ClientContactListServices : Shared.BaseListServices<ClientContactList, ClientContactList, int>
    {
        public ClientContactListServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ClientContactId")
        {
        }
    }
}
