using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Service
{
    public class ServiceResidualPaymentTermServices : Shared.BaseListServices<ServiceResidualPaymentTerm, ServiceResidualPaymentTerm, int>
    {
        public ServiceResidualPaymentTermServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ServiceResidualPaymentTermId")
        {
        }
    }
}
