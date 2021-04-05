using DTO.Recipient;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Services.Recipient
{
    public class RecipientServices : Shared.BaseServices<ApplicationDbContext.Models.Recipient, RecipientViewModel, int>
    {
        public RecipientServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "RecipientId")
        {
        }

        public async Task<bool> ExistRecipient(RecipientViewModel model)
        {
            return await Task.Run(async () => await this.dbSet.AnyAsync(x => ((!string.IsNullOrWhiteSpace(model.CPF) && x.CPF == model.CPF) || (!string.IsNullOrWhiteSpace(model.CNPJ) && x.CNPJ == model.CNPJ)) && x.RecipientId != model.RecipientId && !x.IsDeleted));
        }

        public async Task ChangeActivity(int id, bool isActive)
        {
            var entity = await GetDataByIdAsync(id);

            entity.IsActive = isActive;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task CreationComplete(int id)
        {
            var entity = await GetDataByIdAsync(id);

            entity.CreationComplete = true;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
    }
}
