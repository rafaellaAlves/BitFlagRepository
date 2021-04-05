using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private Services.Student.StudentService studentService;
        private Services.Class.ClassService classService;


        public StudentController(Services.Student.StudentService studentService, Services.Class.ClassService classService)
        {
            this.studentService = studentService;
            this.classService = classService;
        }

        #region [Index]
        public async Task<IActionResult> Index() => await Task.Run(() => View());
        [HttpPost]
        public async Task<IActionResult> List()
        {
            try
            {
                var students = await studentService.List();
                return await Task.Run<IActionResult>(() => Json(new
                {
                    recordsTotal = students.Count,
                    recordsFiltered = students.Count,
                    data = students
                }));
            }
            catch (Exception exception)
            {
                return await Task.Run(() => Json(new DTO.Shared.ReturnResult(-1, exception.Message, true)));
            }
        }
        #endregion

        #region [Manage]
        public async Task<IActionResult> Manage() => await Task.Run(() => View());
        [HttpPost]
        [ActionName("Manage")]
        public async Task<IActionResult> _Manage(DTO.Student.StudentInfoViewModel model)
        {
            try
            {
                var studentId = await studentService.SaveStudentInfo(model);
                //await assasService.SaveStudent(studentId);

                return RedirectToAction("Index", new { success = true });
            }
            catch (Exception exception)
            {
                TempData["ErrorMessage"] = exception.Message;
                return RedirectToAction("Manage", new { error = true, id = model.StudentId });
            }

        }
        #endregion

        public async Task<IActionResult> GetPhoto(int studentId)
        {
            var studentInfoViewModel = await studentService.GetStudentInfo(studentId);
            var photoPath = @".\fotos\";
            var photoFileName = string.IsNullOrWhiteSpace(studentInfoViewModel.PhotoFileName) ? "default.jpg" : studentInfoViewModel.PhotoFileName;
            var fullPath = System.IO.Path.Combine(photoPath, photoFileName);
            var defaultPhotoFullPath = System.IO.Path.Combine(photoPath, "default.jpg");

            if (System.IO.File.Exists(fullPath))
                return File(System.IO.File.OpenRead(fullPath), "application/octet-stream");
            else if(System.IO.File.Exists(defaultPhotoFullPath))
                return File(System.IO.File.OpenRead(defaultPhotoFullPath), "application/octet-stream");
            else
                return NotFound();
        }

        public IActionResult Print(DTO.ClassStudent.ClassStudentViewModel student)
        {
            return View(new DTO.ClassStudent.ClassStudentViewModel());
        }
        public async Task<bool> CheckExistingCPF(string cpf, int? id) => await Task.Run(() => studentService.CheckExistingCPF(cpf, id));
        public async Task<bool> CheckExistingEmail(string email, int? id) => await Task.Run(() => studentService.CheckExistingEmail(email, id));

    }
}