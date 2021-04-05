using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Services.Class
{
    public class ClassService
    {
        private ApplicationDbContext.ApplicationDbContext applicationDbContext;
        public ClassService(ApplicationDbContext.ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<int> Add(ClassViewModel model)
        {
            var _class = new ApplicationDbContext.Class()
            {
                CourseId = model.CourseId,
                ModuleCount = model.ModuleCount,
                State = model.State,
                Year = model.Year,
                Info = model.Info,
                PeriodId = model.PeriodId
            };

            await this.applicationDbContext.Class.AddAsync(_class);
            await this.applicationDbContext.SaveChangesAsync();

            return _class.ClassId;
        }

        public async Task<List<DTO.Class.ClassViewModel>> List()
        {
            return await (from c in applicationDbContext.Class
                          join _c in applicationDbContext.Course on c.CourseId equals _c.CourseId
                          let count = applicationDbContext.ClassStudent.Count(x => x.ClassId == c.ClassId)
                          orderby c.ClassId descending
                          select new DTO.Class.ClassViewModel
                          {
                              ClassId = c.ClassId,
                              CourseName = _c.Name,
                              ModuleCount = c.ModuleCount,
                              State = c.State,
                              Year = c.Year,
                              Info = c.Info,
                              CourseId = c.CourseId,
                              PeriodId = c.PeriodId,
                              studentsCount = count
                          }).AsNoTracking().ToListAsync();
        }
        public async Task<DTO.Class.ClassViewModel> GetById(int classId)
        {
            var students = applicationDbContext.Student.AsNoTracking();

            return await (from c in applicationDbContext.Class
                          join _c in applicationDbContext.Course on c.CourseId equals _c.CourseId
                          where c.ClassId == classId
                          select new DTO.Class.ClassViewModel
                          {
                              ClassId = c.ClassId,
                              CourseName = _c.Name,
                              ModuleCount = c.ModuleCount,
                              State = c.State,
                              Year = c.Year,
                              Info = c.Info,
                              CourseId = c.CourseId,
                              PeriodId = c.PeriodId,
                              studentsCount = students.Count(x => x.ClassId == c.ClassId)
                          }).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<DTO.Class.ClassViewModel> GetByStudentId(int studentId)
        {
            var students = applicationDbContext.Student.AsNoTracking();

            return await (from s in applicationDbContext.Student
                          join c in applicationDbContext.Class on s.ClassId equals c.ClassId
                          join _c in applicationDbContext.Course on c.CourseId equals _c.CourseId
                          where s.StudentId == studentId
                          select new DTO.Class.ClassViewModel
                          {
                              ClassId = c.ClassId,
                              CourseName = _c.Name,
                              ModuleCount = c.ModuleCount,
                              State = c.State,
                              Year = c.Year,
                              Info = c.Info,
                              CourseId = c.CourseId,
                              PeriodId = c.PeriodId,
                              studentsCount = students.Count(x => x.ClassId == c.ClassId)
                          }).AsNoTracking().SingleOrDefaultAsync();
        }
    }
}
