using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.ClassStudent
{
    public class ClassStudentPresentialSituationViewModel
    {
        public int? StudentPresenceId { get; set; }
        public int ClassStudentId { get; set; }
        public string StudentName { get; set; }
        public int Module { get; set; }
        public int? Saturday { get; set; }
        public string SaturdayOptionPresence { get; set; }
        public DateTime? SaturdayDate { get; set; }
        public string SaturdayDateFormatted => SaturdayDate.ToBrazilianDateString();
        public string SaturdayComments { get; set; }
        public int? Sunday { get; set; }
        public string SundayOptionPresence { get; set; }
        public DateTime? SundayDate { get; set; }
        public string SundayDateFormatted => SundayDate.ToBrazilianDateString();
        public string SundayComments { get; set; }
        public double? TestGrade { get; set; }
        public string TestGradeFormatted => TestGrade.ToBrazilian();
        public double? ActivityGrade { get; set; }
        public string ActivityGradeFormatted => ActivityGrade.ToBrazilian();
        public int? CompletionPercent { get; set; }
        public string Comments { get; set; }
    }
}
