using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class StudentThesisViewComponent : ViewComponent
    {
        private Services.ClassStudent.ClassStudentService classStudentService;
        public StudentThesisViewComponent(Services.ClassStudent.ClassStudentService classStudentService)
        {
            this.classStudentService = classStudentService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? classStudentId) => View(classStudentId.HasValue ? await this.classStudentService.GetStudentThesis(classStudentId.Value) : new DTO.ClassStudent.StudentThesisViewModel());
    }
}
