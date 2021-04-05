using Microsoft.AspNetCore.Mvc;
using Services.Recipient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Recipient
{
    public class RecipientContactIndexViewComponent : ViewComponent
    {
        private readonly RecipientContactServices service;
        public RecipientContactIndexViewComponent(RecipientContactServices service)
        {
            this.service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(int recipientId) => await Task.Run(() =>
        View(recipientId));
    }
}
