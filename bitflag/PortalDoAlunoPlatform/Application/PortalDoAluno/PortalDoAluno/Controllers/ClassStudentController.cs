using DTO.ClassStudent;
using DTO.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Authorize]
    public class ClassStudentController : Controller
    {
        private Services.Class.ClassService classService;
        private Services.ClassStudent.ClassStudentService classStudentService;
        private Services.ClassStudent.PresenceSituationService presenceSituationService;
        private Services.ClassStudent.FinanceService financeService;
        private Services.ASAAS.ASAASService assasService;

        public ClassStudentController(Services.Class.ClassService classService, Services.ClassStudent.ClassStudentService classStudentService, Services.ClassStudent.PresenceSituationService presenceSituationService, Services.ClassStudent.FinanceService financeService, Services.ASAAS.ASAASService assasService)
        {
            this.classService = classService;
            this.classStudentService = classStudentService;
            this.presenceSituationService = presenceSituationService;
            this.financeService = financeService;
            this.assasService = assasService;
        }

        #region [Index]
        [HttpGet]
        public async Task<IActionResult> Index(int classId) => View(await classService.GetById(classId));
        [HttpGet]
        public async Task<IActionResult> List(int classId)
        {
            try
            {
                var students = await classStudentService.GetStudentsInfo(classId);
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

        [HttpPost]
        public async Task<IActionResult> ListStudentClass(int studentId)
        {
            try
            {
                var studentClasses = await classStudentService.ListStudentClass(studentId);
                return await Task.Run<IActionResult>(() => Json(new
                {
                    recordsTotal = studentClasses.Count,
                    recordsFiltered = studentClasses.Count,
                    data = studentClasses
                }));
            }
            catch (Exception exception)
            {
                return await Task.Run(() => Json(new DTO.Shared.ReturnResult(-1, exception.Message, true)));
            }
        }

        #region [Add]
        public async Task<IActionResult> Add(int classId, int studentId)
        {
            await classStudentService.Add(classId, studentId);
            return RedirectToAction(nameof(Index), new { classId, saved = true });
        }
        #endregion

        #region [Document]
        public async Task<IActionResult> Document(int? classStudentId) => await Task.Run(() => View(classStudentId));
        [ActionName("Document")]
        [HttpPost]
        public async Task<IActionResult> _Document(int classId, int classStudentId, ClassStudentViewModel model)
        {
            await classStudentService.SaveStudentDocument(classStudentId, model);
            await classStudentService.SaveStudentThesis(classStudentId, model);

            return RedirectToAction(nameof(Document), new { classId, classStudentId, saved = true });
        }
        #endregion

        #region [Remove]
        public async Task<IActionResult> Remove(int classId, int classStudentId)
        {
            await classStudentService.Remove(classStudentId);
            return RedirectToAction(nameof(Index), new { classId });
        }
        #endregion

        #region [PresentialSituation]
        public async Task<IActionResult> PresentialSituation(int classStudentId) => await Task.Run(() => View(classStudentId));
        [HttpPost]
        public async Task<IActionResult> ListPresentialSituation(int classStudentId)
        {
            var r = await presenceSituationService.List(classStudentId);
            return await Task.Run(() => Json(new DTO.Shared.ReturnResult(r, null, false)));
        }
        public async Task<IActionResult> SavePresentialSituation(ClassStudentPresentialSituationViewModel model)
        {
            if (presenceSituationService.UsingModule(model.StudentPresenceId, model.ClassStudentId, model.Module))
            {
                return await Task.Run(() => Json(new DTO.Shared.ReturnResult(null, "Este estudante já possui um item com este módulo.", true)));
            }

            var id = await presenceSituationService.AddOrUpdate(model);
            return await Task.Run(() => Json(new DTO.Shared.ReturnResult(id, "Dados salvos com sucesso.", false)));
        }
        public async Task RemovePresentialSituation(int studentPresenceId)
        {
            await presenceSituationService.Remove(studentPresenceId);
        }
        #endregion

        #region [Finance]
        public async Task<IActionResult> Finance(int classStudentId) => await Task.Run(() => View(classStudentId));
        [HttpPost]
        public async Task<IActionResult> ListFinance(int classStudentId)
        {
            var r = await financeService.List(classStudentId);
            return await Task.Run(() => Json(new DTO.Shared.ReturnResult(r, null, false)));
        }
        #endregion

        #region [AdministrativeSituation]
        public async Task<IActionResult> AdministrativeSituation(int classId, int classStudentId)
        {
            return await Task.Run(() => View(classStudentId));
        }
        [HttpPost]
        public async Task<IActionResult> CreateCharge(int classId, int classStudentId, string value, int installmentCount, DateTime installmentDate)
        {
            string classFullName = (await classService.GetById(classId)).ClassFullName;

            var success = await assasService.CreateCharge(classStudentId, classFullName, value.ToDouble().GetValueOrDefault(), installmentCount, installmentDate);

            if (!success) TempData["ErrorMessage"] = "Houve um erro ao gerar as cobranças";

            return await Task.Run(() => RedirectToAction("AdministrativeSituation", success ? new { classId, classStudentId, saved = true } : (object)new { classId, classStudentId, error = true }));
        }
        #endregion


        #region [Thesis]
        public async Task<IActionResult> GetThesis(int classStudentId)
        {
            var thesis = await classStudentService.GetStudentThesis(classStudentId);
            var photoPath = @".\docs\";
            //photoPath = @"D:\Downloads\docs\";

            if (string.IsNullOrWhiteSpace(thesis.FileName)) return NotFound();

            var fullPath = System.IO.Path.Combine(photoPath, thesis.FileName);

            if (System.IO.File.Exists(fullPath))
                return File(System.IO.File.OpenRead(fullPath), "application/octet-stream", thesis.FileName);
            else
                return NotFound();
        }
        #endregion
    }
}
