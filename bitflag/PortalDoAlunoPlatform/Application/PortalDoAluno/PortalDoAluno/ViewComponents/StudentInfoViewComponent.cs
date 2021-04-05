using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class StudentInfoViewComponent : ViewComponent
    {
        private Services.Student.StudentService studentService;
        public StudentInfoViewComponent(Services.Student.StudentService studentService)
        {
            this.studentService = studentService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? id) => View(id.HasValue ? await this.studentService.GetStudentInfo(id.Value) : new DTO.Student.StudentInfoViewModel());
    }
}
