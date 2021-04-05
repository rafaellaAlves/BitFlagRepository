using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Student
{
    public class StudentInfoViewModel
    {
        public int? StudentId { get; set; }
        public string Name { get; set; }
        public string PhotoFileName { get; set; }
        public string CPF { get; set; }
        public string _Cpf { get { return CPF.NumbersOnly(); } }
        public string RG { get; set; }
        public string _Rg { get { return RG.NumbersOnly(); } }
        public DateTime? BirthDate { get; set; }
        public string _BirthDate { get { return this.BirthDate.ToBrazilianDateString(); } }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CellPhone { get; set; }
        public string Profession { get; set; }
        public string CouncilDocumentNumber { get; set; }
        public string Zipcode { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public DateTime? StartDate { get; set; }
        public string _StartDate { get { return this.StartDate.ToBrazilianDateString(); } }
        public DateTime? FinishDate { get; set; }
        public string _FinishDate { get { return this.FinishDate.ToBrazilianDateString(); } }
        public string MatriculationLocking { get; set; }
        public int? ClassId { get; set; }
        public string CourseFullName { get; set; }
        public bool? MatriculationStatus { get; set; }
        public string ASAAS_customer_id { get; set; }
        public string Comments { get; set; }
    }
}
