using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class StudentInstituteDocumentationViewComponent : ViewComponent
{
    private Services.ClassStudent.ClassStudentService classStudentService;
    public StudentInstituteDocumentationViewComponent(Services.ClassStudent.ClassStudentService classStudentService)
    {
        this.classStudentService = classStudentService;
    }
    public async Task<IViewComponentResult> InvokeAsync(int? classStudentId) => View(classStudentId.HasValue ? await this.classStudentService.GetStudentInstituteDocumentation(classStudentId.Value) : new DTO.ClassStudent.StudentInstituteDocumentationViewModel());
}