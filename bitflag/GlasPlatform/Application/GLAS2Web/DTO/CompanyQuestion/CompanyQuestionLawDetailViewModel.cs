using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.CompanyQuestion
{
    public class CompanyQuestionLawDetailViewModel
    {
        public int AmountCountryLaws { get; set; }
        public int AmountStateLaws { get; set; }
        public int AmountCityLaws { get; set; }
        public List<CompanyQuestionLawDetailThemeViewModel> Themes { get; set; }
        public List<CompanyQuestionLawDetailSubthemeViewModel> Subthemes { get; set; }
        public int AmountPotentialityFine { get; set; }
        public int AmountPotentialityInspection { get; set; }
        public int AmountPotentialityInterdiction { get; set; }
        public int AmountPotentialityOthers { get; set; }
        public int AmountSegmentSegurancaDoTrabalho { get; set; }
        public int AmountSegmentMeioAmbiente { get; set; }
        public int AmountSegmentAssuntosRegulatorios { get; set; }
        public int AmountSegmentOthers { get; set; }
    }
}
