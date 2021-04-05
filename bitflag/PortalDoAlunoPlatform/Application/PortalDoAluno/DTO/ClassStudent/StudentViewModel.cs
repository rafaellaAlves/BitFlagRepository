using System;
using System.Collections.Generic;
using System.Text;
using DTO.ClassStudent;
using DTO.Utils;

namespace DTO.ClassStudent
{
    public class ClassStudentViewModel
    {
        public int ClassStudentId { get; set; }

        public StudentInternshipViewModel StudentInternship { get; set; }
        public StudentInstituteDocumentationViewModel StudentInstituteDocumentation { get; set; }
        public StudentProfessionalDocumentationViewModel StudentProfessionalDocumentation { get; set; }
        public StudentForwardedDocumentationViewModel StudentForwardedDocumentation { get; set; }
        public StudentThesisViewModel StudentThesis { get; set; }
        //public StudentCommentViewModel StudentComment { get; set; }

        public ClassStudentViewModel()
        {
            this.StudentInternship = new StudentInternshipViewModel();
            this.StudentInstituteDocumentation = new StudentInstituteDocumentationViewModel();
            this.StudentProfessionalDocumentation = new StudentProfessionalDocumentationViewModel();
            this.StudentForwardedDocumentation = new StudentForwardedDocumentationViewModel();
            this.StudentThesis = new StudentThesisViewModel();
            //this.StudentComment = new StudentCommentViewModel();
        }

        //ProfesisonalDocumentStatus
        public int StatusId { get; set; }
        public string Description { get; set; }
        public string GeneralComments { get; set; }
    }
}
