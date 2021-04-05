using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;

namespace DTO.Class
{
    public class ClassViewModel
    {
        public int? ClassId { get; set; }
        public int CourseId { get; set; }
        public int ModuleCount { get; set; }
        public string CourseName { get; set; }
        public int studentsCount { get; set; }
        public string State { get; set; }
        public int Year { get; set; }
        public string Info { get; set; }
        public string ClassFullName
        {
            get
            {
                return $"{CourseName}-{State}{Year} ({Info})";
            }
        }
        public int? PeriodId { get; set; }
    }
    
}
