using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.ClassStudent
{
    public class ClassStudentInfoViewModel
    {
        public int ClassStudentId { get; set; }
        public int ClassId { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string ASAAS_customer_id { get; set; }
        public string ClassFullName { get; set; }
    }
}
