using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Recipient
{
    public class RecipientEnvironmentalDocumentationIndexViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int recipientId) => await Task.Run(() => View(recipientId));
    }
}
