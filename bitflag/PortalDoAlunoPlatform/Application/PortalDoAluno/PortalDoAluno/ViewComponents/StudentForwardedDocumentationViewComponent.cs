using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class StudentForwardedDocumentationViewComponent : ViewComponent
{
    private Services.ClassStudent.ClassStudentService classStudentService;
    public StudentForwardedDocumentationViewComponent(Services.ClassStudent.ClassStudentService classStudentService)
    {
        this.classStudentService = classStudentService;
    }
    public async Task<IViewComponentResult> InvokeAsync(int? classId) => View(classId.HasValue ? await this.classStudentService.GetStudentForwardedDocumentation(classId.Value) : new DTO.ClassStudent.StudentForwardedDocumentationViewModel());
}