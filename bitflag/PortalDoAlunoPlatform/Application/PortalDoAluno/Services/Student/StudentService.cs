using DTO.Student;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using System.Threading;
using System.Transactions;
using DTO.ASAAS.Customer;
using ApplicationDbContext;
using DTO.Utils;

namespace Services.Student
{
    public class StudentService
    {
        private ApplicationDbContext.ApplicationDbContext applicationDbContext;
        public StudentService(ApplicationDbContext.ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<int> SaveStudentInfo(StudentInfoViewModel model)
        {
            ApplicationDbContext.Student student = model.StudentId.HasValue ? await this.applicationDbContext.Student.SingleAsync(x => x.StudentId == model.StudentId.Value) : new ApplicationDbContext.Student();

            student.Name = model.Name;
            student.CPF = model._Cpf;
            student.RG = model._Rg;
            student.BirthDate = model.BirthDate;
            student.Gender = model.Gender;
            student.Email = model.Email;
            student.PhoneNumber = model.PhoneNumber;
            student.CellPhone = model.CellPhone;
            student.Profession = model.Profession;
            student.CouncilDocumentNumber = model.CouncilDocumentNumber;
            student.Zipcode = model.Zipcode;
            student.Address = model.Address;
            student.Number = model.Number;
            student.Complement = model.Complement;
            student.Neighborhood = model.Neighborhood;
            student.State = model.State;
            student.City = model.City;
            student.StartDate = model.StartDate;
            student.FinishDate = model.FinishDate;
            student.MatriculationLocking = model.MatriculationLocking;
            student.ClassId = model.ClassId;
            student.MatriculationStatus = model.MatriculationStatus;

            if (!model.StudentId.HasValue) await this.applicationDbContext.Student.AddAsync(student);
            await this.applicationDbContext.SaveChangesAsync();

            return student.StudentId;
        }
        

        public async Task<int> Manage(StudentInfoViewModel model)
        {
            using (var transaction = this.applicationDbContext.Database.BeginTransaction())
            {
                try
                {
                    var studentId = await SaveStudentInfo(model);
                    transaction.Commit();

                    return studentId;
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    throw exception;
                }
            }
        }

        public async Task<List<StudentList>> List()
        {
            return await (from s in applicationDbContext.StudentList
                          orderby s.StudentId descending
                          select s).AsNoTracking().ToListAsync();
        }
        public async Task Remove(int id)
        {
            var student = await this.applicationDbContext.Student.FindAsync(id);
            this.applicationDbContext.Student.Remove(student);
            await this.applicationDbContext.SaveChangesAsync();
        }

        public async Task<StudentInfoViewModel> GetStudentInfo(int id)
        {
            return await (from s in applicationDbContext.Student
                          orderby s.StudentId descending
                          where s.StudentId == id
                          select new DTO.Student.StudentInfoViewModel
                          {
                              StudentId = s.StudentId,
                              Name = s.Name,
                              PhotoFileName = s.PhotoFileName,
                              CPF = s.CPF,
                              RG = s.RG,
                              BirthDate = s.BirthDate,
                              Gender = s.Gender,
                              Email = s.Email,
                              PhoneNumber = s.PhoneNumber,
                              CellPhone = s.CellPhone,
                              Profession = s.Profession,
                              CouncilDocumentNumber = s.CouncilDocumentNumber,
                              Zipcode = s.Zipcode,
                              Address = s.Address,
                              Number = s.Number,
                              Complement = s.Complement,
                              Neighborhood = s.Neighborhood,
                              State = s.State,
                              City = s.City,
                              StartDate = s.StartDate,
                              FinishDate = s.FinishDate,
                              MatriculationLocking = s.MatriculationLocking,
                              ClassId = s.ClassId,
                              MatriculationStatus = s.MatriculationStatus,
                              ASAAS_customer_id = s.ASAAS_customer_id
                          }).AsNoTracking().SingleOrDefaultAsync();
        }
        public async Task<StudentCommentViewModel> GetStudentComments(int id)
        {
            var studentCommentViewModel = await (from s in applicationDbContext.Student
                                                 orderby s.StudentId descending
                                                 where s.StudentId == id
                                                 select new DTO.Student.StudentCommentViewModel
                                                 {
                                                     Comments = s.Comments
                                                 }).AsNoTracking().SingleOrDefaultAsync();

            return studentCommentViewModel ?? new StudentCommentViewModel();
        }

        public bool CheckExistingCPF(string cpf, int? id)
        {
            var _cpf = cpf.NumbersOnly();

            return this.applicationDbContext.Student.Any(x => x.CPF == _cpf && (!id.HasValue || id != x.StudentId));
        }
        public bool CheckExistingEmail(string email, int? id)
        {
            var _email = email.ToUpper();

            return this.applicationDbContext.Student.Any(x => x.Email.ToUpper().Equals(_email) && (!id.HasValue || id != x.StudentId));
        }
    }
}
