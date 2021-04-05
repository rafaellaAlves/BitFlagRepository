using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.RegistryOffice
{
    public class RegistryOfficeManageViewComponent : ViewComponent
    {
        private readonly FUNCTIONS.RegistryOffice.RegistryOfficeFunctions registryOfficeFunctions;
        public RegistryOfficeManageViewComponent(FUNCTIONS.RegistryOffice.RegistryOfficeFunctions registryOfficeFunctions) 
        {
            this.registryOfficeFunctions = registryOfficeFunctions;
        }

        public IViewComponentResult Invoke(int? id)
        {
            if (!id.HasValue) return View(new DTO.RegistryOffice.RegistryOfficeViewModel());

            return View(registryOfficeFunctions.GetDataViewModel(registryOfficeFunctions.GetDataByID(id.Value)));
        }
    }
}
