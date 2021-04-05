using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class StudentCommentsViewComponent : ViewComponent
    {
        private Services.ClassStudent.ClassStudentService classStudentService;
        public StudentCommentsViewComponent(Services.ClassStudent.ClassStudentService classStudentService)
        {
            this.classStudentService = classStudentService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? id) => View((object)(id.HasValue ? await this.classStudentService.GetGeneralCommments(id.Value) : string.Empty));
    }
}
