﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLAS2Web.ViewComponents.Question
{
    public class QuestionSubThemeIndexViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int questionThemeId) => await Task.Run(() => View(questionThemeId));
    }
}
