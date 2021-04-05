using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DTO.Student;
using DTO.ClassStudent;

namespace Services.ClassStudent
{
    public class ClassStudentService
    {
        private ApplicationDbContext.ApplicationDbContext applicationDbContext;
        public ClassStudentService(ApplicationDbContext.ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<List<ClassStudentInfoViewModel>> GetStudentsInfo(int classId)
        {
            return await (from cs in applicationDbContext.ClassStudent
                          join s in applicationDbContext.Student on cs.StudentId equals s.StudentId
                          orderby s.Name descending
                          where cs.ClassId == classId
                          select new ClassStudentInfoViewModel
                          {
                              ClassStudentId = cs.ClassStudentId,
                              ClassId = cs.ClassId,
                              StudentId = s.StudentId,
                              Name = s.Name,
                              CPF = s.CPF,
                              Email = s.Email
                          }).AsNoTracking().ToListAsync();
        }
        public async Task<ClassStudentInfoViewModel> GetClassStudentInfoViewModel(int classStudentId)
        {
            return await (from cs in applicationDbContext.ClassStudent
                          join s in applicationDbContext.Student on cs.StudentId equals s.StudentId
                          orderby s.Name descending
                          where cs.ClassStudentId == classStudentId
                          select new ClassStudentInfoViewModel
                          {
                              ClassStudentId = cs.ClassStudentId,
                              ClassId = cs.ClassId,
                              StudentId = s.StudentId,
                              Name = s.Name,
                              CPF = s.CPF,
                              Email = s.Email
                          }).AsNoTracking().SingleOrDefaultAsync();
        }
        public async Task<string> GetGeneralCommments(int classStudentId)
        {
            var generalComments = await (from sd in applicationDbContext.StudentDocument
                                                    where sd.ClassStudentId == classStudentId
                                                    select sd.GeneralComments).AsNoTracking().SingleOrDefaultAsync();

            return generalComments ?? string.Empty;
        }
        public async Task<StudentInternshipViewModel> GetStudentInternship(int classStudentId)
        {
            var studentInternshipViewModel = await (from sd in applicationDbContext.StudentDocument
                                                    where sd.ClassStudentId == classStudentId
                                                    select new StudentInternshipViewModel
                                                    {
                                                        InternshipDocument1 = sd.InternshipDocument1,
                                                        InternshipDocument2 = sd.InternshipDocument2,
                                                        InternshipComments = sd.InternshipComments
                                                    }).AsNoTracking().SingleOrDefaultAsync();

            return studentInternshipViewModel ?? new StudentInternshipViewModel();
        }
        public async Task<StudentInstituteDocumentationViewModel> GetStudentInstituteDocumentation(int classStudentId)
        {
            var studentInstituteDocumentationViewModel = await (from sd in applicationDbContext.StudentDocument
                                                                where sd.ClassStudentId == classStudentId
                                                                select new StudentInstituteDocumentationViewModel
                                                                {
                                                                    Contract = sd.Contract,
                                                                    MatriculationForm = sd.MatriculationForm,
                                                                    MatriculationRequirement = sd.MatriculationRequirement,
                                                                    Photos = sd.Photos,
                                                                    InternalRegulation = sd.InternalRegulation,
                                                                    ThesisAgreementTerm = sd.ThesisAgreementTerm,
                                                                    InternshipAgreementTerm = sd.InternshipAgreementTerm,
                                                                    InstituteDocumentationComments = sd.InstituteDocumentationComments

                                                                }).AsNoTracking().SingleOrDefaultAsync();

            return studentInstituteDocumentationViewModel ?? new StudentInstituteDocumentationViewModel();
        }
        public async Task<StudentProfessionalDocumentationViewModel> GetStudentProfessionalDocumentation(int classStudentId)
        {
            var studentProfessionalDocumentationViewModel = await (from sd in applicationDbContext.StudentDocument
                                                                   where sd.ClassStudentId == classStudentId
                                                                   select new StudentProfessionalDocumentationViewModel
                                                                   {
                                                                       GraduationCertificate = sd.GraduationCertificate,
                                                                       RegionalCouncilDocument = sd.RegionalCouncilDocument,
                                                                       LeadershipStatement = sd.LeadershipStatement,
                                                                       CurriculumSummary = sd.CurriculumSummary,
                                                                       CertifiedOfSpecialization = sd.CertifiedOfSpecialization,
                                                                       UtiTimeDeclaration = sd.UtiTimeDeclaration,
                                                                       TeachingDeclaration = sd.TeachingDeclaration,
                                                                       ProfessionalDocumentationCommets = sd.ProfessionalDocumentationCommets

                                                                   }).AsNoTracking().SingleOrDefaultAsync();

            return studentProfessionalDocumentationViewModel ?? new StudentProfessionalDocumentationViewModel();
        }
        public async Task<StudentForwardedDocumentationViewModel> GetStudentForwardedDocumentation(int classStudentId)
        {
            var studentForwardedDocumentationViewModel = await (from sd in applicationDbContext.StudentDocument
                                                                where sd.ClassStudentId == classStudentId
                                                                select new StudentForwardedDocumentationViewModel
                                                                {
                                                                    RegularlyMatriculatedDeclaration = sd.RegularlyMatriculatedDeclaration,
                                                                    CertifiedOfMPTI = sd.CertifiedOfMPTI,
                                                                    DocumentOfCNI = sd.DocumentOfCNI,
                                                                    RegularlyMatriculatedDate = sd.RegularlyMatriculatedDate,
                                                                    CertifiedOfMPTIDate = sd.CertifiedOfMPTIDate,
                                                                    DocumentOfCNIDate = sd.DocumentOfCNIDate,
                                                                    DocumentsSentComments = sd.DocumentsSentComments

                                                                }).AsNoTracking().SingleOrDefaultAsync();

            return studentForwardedDocumentationViewModel ?? new StudentForwardedDocumentationViewModel();
        }
        public async Task<StudentThesisViewModel> GetStudentThesis(int classStudentId)
        {
            var studentForwardedDocumentationViewModel = await (from t in applicationDbContext.Thesis
                                                                where t.ClassStudentId == classStudentId
                                                                select new StudentThesisViewModel
                                                                {
                                                                    ClassStudentId = t.ClassStudentId,
                                                                    Title = t.Title,
                                                                    ApprovalDate = t.ApprovalDate,
                                                                    PresentationDate = t.PresentationDate,
                                                                    Advisor = t.Advisor,
                                                                    Concept = t.Concept,
                                                                    ProtocolNumber = t.ProtocolNumber,
                                                                    ProtocolDate = t.ProtocolDate,
                                                                    FileName = t.FileName
                                                                }).AsNoTracking().SingleOrDefaultAsync();

            return studentForwardedDocumentationViewModel ?? new StudentThesisViewModel();
        }
        public async Task<int> SaveStudentThesis(int classStudentId, ClassStudentViewModel model)
        {
            ApplicationDbContext.Thesis thesis = await this.applicationDbContext.Thesis.SingleOrDefaultAsync(x => x.ClassStudentId == classStudentId);
            if (thesis == null) thesis = new ApplicationDbContext.Thesis() { ClassStudentId = classStudentId };

            thesis.Title = model.StudentThesis.Title;
            thesis.ApprovalDate = model.StudentThesis.ApprovalDate;
            thesis.PresentationDate = model.StudentThesis.PresentationDate;
            thesis.Advisor = model.StudentThesis.Advisor;
            thesis.Concept = model.StudentThesis.Concept;
            thesis.ProtocolNumber = model.StudentThesis.ProtocolNumber;
            thesis.ProtocolDate = model.StudentThesis.ProtocolDate;

            if (thesis.ThesisId == 0) await this.applicationDbContext.Thesis.AddAsync(thesis);
            await this.applicationDbContext.SaveChangesAsync();

            return thesis.ThesisId;
        }
        public async Task<int> SaveStudentDocument(int classStudentId, ClassStudentViewModel model)
        {
            ApplicationDbContext.StudentDocument studentDocument = await this.applicationDbContext.StudentDocument.SingleOrDefaultAsync(x => x.ClassStudentId == classStudentId);
            if (studentDocument == null) studentDocument = new ApplicationDbContext.StudentDocument() { ClassStudentId = classStudentId };

            studentDocument.InternshipDocument1 = model.StudentInternship.InternshipDocument1;
            studentDocument.InternshipDocument2 = model.StudentInternship.InternshipDocument2;
            studentDocument.InternshipComments = model.StudentInternship.InternshipComments;

            studentDocument.Contract = model.StudentInstituteDocumentation.Contract;
            studentDocument.MatriculationForm = model.StudentInstituteDocumentation.MatriculationForm;
            studentDocument.MatriculationRequirement = model.StudentInstituteDocumentation.MatriculationRequirement;
            studentDocument.Photos = model.StudentInstituteDocumentation.Photos;
            studentDocument.InternalRegulation = model.StudentInstituteDocumentation.InternalRegulation;
            studentDocument.ThesisAgreementTerm = model.StudentInstituteDocumentation.ThesisAgreementTerm;
            studentDocument.InternshipAgreementTerm = model.StudentInstituteDocumentation.InternshipAgreementTerm;
            studentDocument.InstituteDocumentationComments = model.StudentInstituteDocumentation.InstituteDocumentationComments;

            studentDocument.GraduationCertificate = model.StudentProfessionalDocumentation.GraduationCertificate;
            studentDocument.RegionalCouncilDocument = model.StudentProfessionalDocumentation.RegionalCouncilDocument;
            studentDocument.LeadershipStatement = model.StudentProfessionalDocumentation.LeadershipStatement;
            studentDocument.CurriculumSummary = model.StudentProfessionalDocumentation.CurriculumSummary;
            studentDocument.CertifiedOfSpecialization = model.StudentProfessionalDocumentation.CertifiedOfSpecialization;
            studentDocument.UtiTimeDeclaration = model.StudentProfessionalDocumentation.UtiTimeDeclaration;
            studentDocument.TeachingDeclaration = model.StudentProfessionalDocumentation.TeachingDeclaration;
            studentDocument.ProfessionalDocumentationCommets = model.StudentProfessionalDocumentation.ProfessionalDocumentationCommets;

            studentDocument.RegularlyMatriculatedDeclaration = model.StudentForwardedDocumentation.RegularlyMatriculatedDeclaration;
            studentDocument.CertifiedOfMPTI = model.StudentForwardedDocumentation.RegularlyMatriculatedDeclaration;
            studentDocument.DocumentOfCNI = model.StudentForwardedDocumentation.RegularlyMatriculatedDeclaration;
            studentDocument.RegularlyMatriculatedDate = model.StudentForwardedDocumentation.RegularlyMatriculatedDate;
            studentDocument.CertifiedOfMPTIDate = model.StudentForwardedDocumentation.CertifiedOfMPTIDate;
            studentDocument.DocumentOfCNIDate = model.StudentForwardedDocumentation.DocumentOfCNIDate;
            studentDocument.DocumentsSentComments = model.StudentForwardedDocumentation.DocumentsSentComments;

            studentDocument.GeneralComments = model.GeneralComments;

            if (studentDocument.StudentDocumentId == 0) await this.applicationDbContext.StudentDocument.AddAsync(studentDocument);
            await this.applicationDbContext.SaveChangesAsync();

            return studentDocument.StudentDocumentId;
        }
        public async Task Remove(int classStudentId)
        {
            var classStudent = await applicationDbContext.ClassStudent.SingleOrDefaultAsync(x => x.ClassStudentId == classStudentId);
            if (classStudent == null) return;
            applicationDbContext.Remove(classStudent);
            await applicationDbContext.SaveChangesAsync();
        }
        public async Task<List<ClassStudentInfoViewModel>> GetStudentsNotInClass(int classId)
        {
            var classStudentIds = await applicationDbContext.ClassStudent.Where(x => x.ClassId == classId).Select(x => x.StudentId).ToListAsync();
            var students = await applicationDbContext.Student.OrderBy(x => x.Name).Select(s => new ClassStudentInfoViewModel
            {
                ClassId = classId,
                StudentId = s.StudentId,
                Name = s.Name,
                CPF = s.CPF,
                Email = s.Email
            }).AsNoTracking().ToListAsync();

            return students.Where(x => !classStudentIds.Any(y => y == x.StudentId)).ToList();
        }
        public async Task Add(int classId, int studentId)
        {
            await applicationDbContext.ClassStudent.AddAsync(new ApplicationDbContext.ClassStudent()
            {
                ClassId = classId,
                StudentId = studentId
            });
            await applicationDbContext.SaveChangesAsync();
        }
        public async Task<List<ClassStudentInfoViewModel>> ListStudentClass(int studentId)
        {
            return await (from cs in applicationDbContext.ClassStudent
                          join s in applicationDbContext.Student on cs.StudentId equals s.StudentId
                          join c in applicationDbContext.Class on cs.ClassId equals c.ClassId
                          join _c in applicationDbContext.Course on c.CourseId equals _c.CourseId
                          orderby s.Name descending
                          where cs.StudentId == studentId
                          select new ClassStudentInfoViewModel
                          {
                              ClassStudentId = cs.ClassStudentId,
                              ClassId = cs.ClassId,
                              ClassFullName = $"{_c.Name}-{c.State}{c.Year} ({c.Info})",
                              StudentId = s.StudentId,
                              Name = s.Name,
                              CPF = s.CPF,
                              Email = s.Email
                          }).AsNoTracking().ToListAsync();
        }
    }
}
