using ApplicationDbContext.Models;
using DTO.Recipient;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Services.Recipient
{
   public class RecipientEnvironmentalDocumentationServices : Shared.BaseServices<RecipientEnvironmentalDocumentation, RecipientEnvironmentalDocumentationViewModel, int>
    {
        public RecipientEnvironmentalDocumentationServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "RecipientEnvironmentalDocumentationId")
        {
        }
        public async Task BasicUpdateAsync(RecipientEnvironmentalDocumentationViewModel model)
        {
            var entity = GetDataById(model.RecipientEnvironmentalDocumentationId.Value);

            entity.ActivityName = model.ActivityName;
            if(model.DueDate.HasValue) entity.DueDate = model.DueDate.Value;
            entity.Issuer = model.Issuer;
            entity.IssuerDate = model.IssuerDate;
            entity.DocumentName = model.DocumentName;
            entity.Email = model.Email;
            entity.DaysToNotify = model.DaysToNotify;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
    }
}
