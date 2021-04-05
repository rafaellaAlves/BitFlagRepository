using AMaisImob_WEB.BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.ProductFamily
{
    public class ProductFamilyManageViewComponent : ViewComponent
    {
        private readonly ProductFamilyFunctions productFamilyFunctions;

        public ProductFamilyManageViewComponent(ProductFamilyFunctions productFamilyFunctions)
        {
            this.productFamilyFunctions = productFamilyFunctions;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? id) => await Task.Run(() => View(id.HasValue ? productFamilyFunctions.GetDataViewModel(productFamilyFunctions.GetDataByID(id)) : new Models.ProductFamilyViewModel()));
    }
}
