using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApplicationDbContext
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string PhotoFileName { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime? BirthDate { get; set; }
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
        public DateTime? FinishDate { get; set; }
        public string MatriculationLocking { get; set; }
        public int? ClassId { get; set; }
        public bool? MatriculationStatus { get; set; }
        public string Comments { get; set; }
        public string ASAAS_customer_id { get; set; }
    }
}
