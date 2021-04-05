using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.ViewComponents;

[Authorize]
public class ViewComponentLoaderController : Controller
{
    public ViewComponentLoaderController() { }

    public async Task<IActionResult> StudentInfo(int? id) => await Task.Run(() => ViewComponent(typeof(StudentInfoViewComponent), id));
    public async Task<IActionResult> StudentAdministrativeSituation(int? classStudentId) => await Task.Run(() => ViewComponent(typeof(StudentAdministrativeSituationViewComponent), classStudentId));
    public async Task<IActionResult> PresentialSituation(int classStudentId) => await Task.Run(() => ViewComponent(typeof(PresentialSituationViewComponent), classStudentId));
    public async Task<IActionResult> Finance(int classStudentId) => await Task.Run(() => ViewComponent(typeof(FinanceViewComponent), classStudentId));
    public async Task<IActionResult> StudentInternship(int? classStudentId) => await Task.Run(() => ViewComponent(typeof(StudentInternshipViewComponent), classStudentId));
    public async Task<IActionResult> StudentInstituteDocumentation(int? classStudentId) => await Task.Run(() => ViewComponent(typeof(StudentInstituteDocumentationViewComponent), classStudentId));
    public async Task<IActionResult> StudentProfessionalDocumentation(int? classStudentId) => await Task.Run(() => ViewComponent(typeof(StudentProfessionalDocumentationViewComponent), classStudentId));
    public async Task<IActionResult> StudentForwardedDocumentation(int? classStudentId) => await Task.Run(() => ViewComponent(typeof(StudentForwardedDocumentationViewComponent), classStudentId));
    public async Task<IActionResult> StudentThesis(int? classStudentId) => await Task.Run(() => ViewComponent(typeof(StudentThesisViewComponent), classStudentId));
    public async Task<IActionResult> StudentComments(int? classStudentId) => await Task.Run(() => ViewComponent(typeof(StudentCommentsViewComponent), classStudentId));
    public async Task<IActionResult> StudentClass(int? studentId) => await Task.Run(() => ViewComponent(typeof(StudentClassViewComponent), studentId));
}