using Microsoft.AspNetCore.Mvc;
using Services.Account;
using Services.Client;
using System.Threading.Tasks;

namespace Web.ViewComponents.Client
{
    public class ClientManageViewComponent : ViewComponent
    {
        private readonly ClientServices service;
        public ClientManageViewComponent(ClientServices service)
        {
            this.service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? id) => await Task.Run(() => View(id.HasValue? service.GetViewModelByIdAsync(id.Value).Result : new DTO.Client.ClientViewModel()));
    }
}