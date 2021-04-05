using ApplicationDbContext.Models;
using DTO.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Services.Service
{
    public class ServiceListServices : Shared.BaseListServices<ServiceList, ServiceListViewModel, int>
    {
        public ServiceListServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ServiceId")
        {
        }
    }
}
