using ApplicationDbContext.Models;
using DTO.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contract
{
    public class ContractListServices : Shared.BaseListServices<ContractList, ContractListViewModel, int>
    {
        public ContractListServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ContractId")
        {
        }
    }
}
