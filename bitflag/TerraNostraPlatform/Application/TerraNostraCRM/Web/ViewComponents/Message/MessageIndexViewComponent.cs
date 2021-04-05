using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Message
{
    public class MessageIndexViewComponent : ViewComponent
    {
        public MessageIndexViewComponent() { }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
