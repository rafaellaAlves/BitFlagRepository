using Microsoft.AspNetCore.Mvc;
using Services.Account;
using System.Threading.Tasks;

namespace Web.ViewComponents.Transporter
{
    public class TransporterManageViewComponent : ViewComponent
    {
        private readonly Services.Transporter.TransporterServices transporterServices;

        public TransporterManageViewComponent(Services.Transporter.TransporterServices transporterServices)
        {
            this.transporterServices = transporterServices;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? id) => await Task.Run(() => View(id.HasValue? transporterServices.GetViewModelByIdAsync(id.Value).Result : new DTO.Transporter.TransporterViewModel()));
    }
}