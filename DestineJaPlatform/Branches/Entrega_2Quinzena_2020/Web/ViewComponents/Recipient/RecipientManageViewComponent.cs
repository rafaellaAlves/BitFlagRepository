using Microsoft.AspNetCore.Mvc;
using Services.Account;
using System.Threading.Tasks;
using DTO.Recipient;

namespace Web.ViewComponents.Recipient
{
    public class RecipientManageViewComponent : ViewComponent
    {
        private readonly Services.Recipient.RecipientServices recipientServices;

        public RecipientManageViewComponent(Services.Recipient.RecipientServices recipientServices)
        {
            this.recipientServices = recipientServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? id) => await Task.Run(() => View(id.HasValue? recipientServices.GetViewModelByIdAsync(id.Value).Result : new DTO.Recipient.RecipientViewModel())); 
    }
}