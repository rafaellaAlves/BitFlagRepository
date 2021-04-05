using ApplicationDbContext.Models;
using DTO.Transporter;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Services.Transporter
{
    public class TransporterContactServices : Shared.BaseServices<TransporterContact, TransporterContactViewModel, int>
    {
        public TransporterContactServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "TransporterContactId")
        {
        }
    }
}
