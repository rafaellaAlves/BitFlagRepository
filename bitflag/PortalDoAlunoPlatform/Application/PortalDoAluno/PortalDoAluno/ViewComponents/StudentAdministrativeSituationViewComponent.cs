using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class StudentAdministrativeSituationViewComponent : ViewComponent
    {
        Services.ASAAS.ASAASService asaasService;
        public StudentAdministrativeSituationViewComponent(Services.ASAAS.ASAASService asaasService)
        {
            this.asaasService = asaasService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int classStudentId)
        {
            var paymentListModel = await asaasService.GetCharges(classStudentId);
            return await Task.Run(() => View(paymentListModel));
        }
    }
}
