using DTO.Student;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DTO.ClassStudent;

namespace Services.StudentThesis
{
    public class StudentThesis
    {
        private ApplicationDbContext.ApplicationDbContext applicationDbContext;
        public StudentThesis(ApplicationDbContext.ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<int> Add(ClassStudentViewModel model)
        {
            var _StudentThesis = new ApplicationDbContext.Thesis
            {
                Title = model.StudentThesis.Title,
                ApprovalDate = model.StudentThesis.ApprovalDate,
                PresentationDate = model.StudentThesis.PresentationDate,
                Advisor = model.StudentThesis.Advisor,
                Concept = model.StudentThesis.Concept,
                ProtocolNumber = model.StudentThesis.ProtocolNumber,
                ProtocolDate = model.StudentThesis.ProtocolDate,
            };
            await this.applicationDbContext.Thesis.AddAsync(_StudentThesis);
            await this.applicationDbContext.SaveChangesAsync();

            return _StudentThesis.ThesisId;
        }
        public async Task<List<DTO.ClassStudent.StudentThesisViewModel>> List()
        {
            return await (from c in applicationDbContext.Thesis
                          orderby c.ThesisId descending
                          select new DTO.ClassStudent.StudentThesisViewModel
                          {
                              ClassStudentId = c.ClassStudentId,
                              Title = c.Title,
                              ApprovalDate = c.ApprovalDate,
                              PresentationDate = c.PresentationDate,
                              Advisor = c.Advisor,
                              Concept = c.Concept,
                              ProtocolNumber = c.ProtocolNumber,
                              ProtocolDate = c.ProtocolDate,
                              FileName = c.FileName
                          }).AsNoTracking().ToListAsync();
        }

    }
}
