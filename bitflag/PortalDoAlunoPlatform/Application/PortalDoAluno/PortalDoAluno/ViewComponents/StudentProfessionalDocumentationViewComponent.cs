using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class StudentProfessionalDocumentationViewComponent : ViewComponent
{
    private Services.ClassStudent.ClassStudentService classStudentService;
    public StudentProfessionalDocumentationViewComponent(Services.ClassStudent.ClassStudentService classStudentService)
    {
        this.classStudentService = classStudentService;
    }
    public async Task<IViewComponentResult> InvokeAsync(int? classStudentId) => View(classStudentId.HasValue ? await this.classStudentService.GetStudentProfessionalDocumentation(classStudentId.Value) : new DTO.ClassStudent.StudentProfessionalDocumentationViewModel());
}