using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class StudentClassViewComponent : ViewComponent
    {
        private Services.ClassStudent.ClassStudentService classStudentService;
        public StudentClassViewComponent(Services.ClassStudent.ClassStudentService classStudentService)
        {
            this.classStudentService = classStudentService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int studentId) => View(studentId);
    }
}
