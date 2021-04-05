using ApplicationDbContext.Models;
using DTO.Recipient;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Services.Recipient
{
   public class RecipientContactServices : Shared.BaseServices<RecipientContact, RecipientContactViewModel, int>
    {
        public RecipientContactServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "RecipientContactId")
        {
        }
    }
}
