using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Service
{
    public class ServiceFreightPaymentTermServices : Shared.BaseListServices<ServiceFreightPaymentTerm, ServiceFreightPaymentTerm, int>
    {
        public ServiceFreightPaymentTermServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ServiceFreightPaymentTermId")
        {
        }
    }
}
