using DTO.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.ClassStudent
{
    public class AddToClassViewModel
    {
        public List<ClassStudentInfoViewModel> ClassStudentInfoViewModels { get; set; }
        public ClassViewModel ClassViewModel { get; set; }
    }
}
