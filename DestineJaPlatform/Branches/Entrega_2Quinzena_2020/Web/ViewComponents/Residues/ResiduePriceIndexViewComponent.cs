﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Residues
{
    public class ResiduePriceIndexViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int recipientId) => await Task.Run(() => View(recipientId));
    }
}
