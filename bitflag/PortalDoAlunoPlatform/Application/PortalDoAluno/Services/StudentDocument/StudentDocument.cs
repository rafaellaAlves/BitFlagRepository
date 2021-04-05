using DTO.Student;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DTO.ClassStudent;

namespace Services.StudentDocument
{
    public class StudentDocument
    {
        private ApplicationDbContext.ApplicationDbContext applicationDbContext;
        public StudentDocument(ApplicationDbContext.ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<int> Add(ClassStudentViewModel model)
        {
            var studentDocument = new ApplicationDbContext.StudentDocument()
            {
                ClassStudentId = model.ClassStudentId,
                InternshipDocument1 = model.StudentInternship.InternshipDocument1,
                InternshipDocument2 = model.StudentInternship.InternshipDocument2,
                InternshipComments = model.StudentInternship.InternshipComments,
                Contract = model.StudentInstituteDocumentation.Contract,
                MatriculationForm = model.StudentInstituteDocumentation.MatriculationForm,
                MatriculationRequirement = model.StudentInstituteDocumentation.MatriculationRequirement,
                Photos = model.StudentInstituteDocumentation.Photos,
                InternalRegulation = model.StudentInstituteDocumentation.InternalRegulation,
                ThesisAgreementTerm = model.StudentInstituteDocumentation.ThesisAgreementTerm,
                InternshipAgreementTerm = model.StudentInstituteDocumentation.InternshipAgreementTerm,
                InstituteDocumentationComments = model.StudentInstituteDocumentation.InstituteDocumentationComments,
                GraduationCertificate = model.StudentProfessionalDocumentation.GraduationCertificate,
                RegionalCouncilDocument = model.StudentProfessionalDocumentation.RegionalCouncilDocument,
                LeadershipStatement = model.StudentProfessionalDocumentation.LeadershipStatement,
                CurriculumSummary = model.StudentProfessionalDocumentation.CurriculumSummary,
                CertifiedOfSpecialization = model.StudentProfessionalDocumentation.CertifiedOfSpecialization,
                UtiTimeDeclaration = model.StudentProfessionalDocumentation.UtiTimeDeclaration,
                TeachingDeclaration = model.StudentProfessionalDocumentation.TeachingDeclaration,
                ProfessionalDocumentationCommets = model.StudentProfessionalDocumentation.ProfessionalDocumentationCommets,
                RegularlyMatriculatedDeclaration = model.StudentForwardedDocumentation.RegularlyMatriculatedDeclaration,
                RegularlyMatriculatedDate = model.StudentForwardedDocumentation.RegularlyMatriculatedDate,
                CertifiedOfMPTI = model.StudentForwardedDocumentation.CertifiedOfMPTI,
                CertifiedOfMPTIDate = model.StudentForwardedDocumentation.CertifiedOfMPTIDate,
                DocumentOfCNI = model.StudentForwardedDocumentation.DocumentOfCNI,
                DocumentOfCNIDate = model.StudentForwardedDocumentation.DocumentOfCNIDate,
                DocumentsSentComments = model.StudentForwardedDocumentation.DocumentsSentComments,
            };

            await this.applicationDbContext.StudentDocument.AddAsync(studentDocument);
            await this.applicationDbContext.SaveChangesAsync();

            return studentDocument.ClassStudentId;
        }
        //public async Task<List<DTO.Student.StudentViewModel>> List()
        //{
        //    return await (from c in applicationDbContext.StudentDocument
        //                  orderby c.ClassStudentId descending
        //                  select new DTO.Student.StudentViewModel
        //                  {
        //                      DocumentGroupId = c.StudentId,
        //                      StudentInternship = new StudentInternshipViewModel()
        //                      {
        //                          InternshipDocument1 = c.InternshipDocument1,
        //                          InternshipDocument2 = c.InternshipDocument2,
        //                          InternshipComments = c.InternshipComments,
        //                      },
        //                      StudentInstituteDocumentation = new StudentInstituteDocumentationViewModel()
        //                      {
        //                          Contract = c.Contract,
        //                          MatriculationForm = c.MatriculationForm,
        //                          MatriculationRequirement = c.MatriculationRequirement,
        //                          Photos = c.Photos,
        //                          InternalRegulation = c.InternalRegulation,
        //                          ThesisAgreementTerm = c.ThesisAgreementTerm,
        //                          InternshipAgreementTerm = c.InternshipAgreementTerm,
        //                          InstituteDocumentationComments = c.InstituteDocumentationComments,
        //                      },
        //                      StudentProfessionalDocumentation = new StudentProfessionalDocumentationViewModel()
        //                      {
        //                          GraduationCertificate = c.GraduationCertificate,
        //                          RegionalCouncilDocument = c.RegionalCouncilDocument,
        //                          LeadershipStatement = c.LeadershipStatement,
        //                          CurriculumSummary = c.CurriculumSummary,
        //                          CertifiedOfSpecialization = c.CertifiedOfSpecialization,
        //                          UtiTimeDeclaration = c.UtiTimeDeclaration,
        //                          TeachingDeclaration = c.TeachingDeclaration,
        //                          ProfessionalDocumentationCommets = c.ProfessionalDocumentationCommets,
        //                      },
        //                      StudentForwardedDocumentation = new StudentForwardedDocumentationViewModel()
        //                      {
        //                          RegularlyMatriculatedDeclaration = c.RegularlyMatriculatedDeclaration,
        //                          RegularlyMatriculatedDate = c.RegularlyMatriculatedDate,
        //                          CertifiedOfMPTI = c.CertifiedOfMPTI,
        //                          CertifiedOfMPTIDate = c.CertifiedOfMPTIDate,
        //                          DocumentOfCNI = c.DocumentOfCNI,
        //                          DocumentOfCNIDate = c.DocumentOfCNIDate,
        //                          DocumentsSentComments = c.DocumentsSentComments
        //                      }
        //                  }).AsNoTracking().ToListAsync();
        //}
    }
}
