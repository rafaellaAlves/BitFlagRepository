using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class StudentInternshipViewComponent : ViewComponent
    {
        private Services.ClassStudent.ClassStudentService classStudentService;
        public StudentInternshipViewComponent(Services.ClassStudent.ClassStudentService classStudentService)
        {
            this.classStudentService = classStudentService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? classStudentId) => View(classStudentId.HasValue ? await this.classStudentService.GetStudentInternship(classStudentId.Value) : new DTO.ClassStudent.StudentInternshipViewModel());
    }
}