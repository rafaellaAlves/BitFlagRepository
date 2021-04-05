using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Message
{
    public class MessageManageViewComponent : ViewComponent
    {
        public MessageManageViewComponent() { }

        public IViewComponentResult Invoke(int id)
        {
            return View(id);
        }
    }
}
