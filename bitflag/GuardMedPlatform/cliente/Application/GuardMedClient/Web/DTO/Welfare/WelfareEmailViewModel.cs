using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO.Welfare
{
    public class WelfareEmailViewModel
    {
        public SeguradoProfissionalViewModel SeguradoProfissional { get; set; }
        public int Period { get; set; }
        public string _Period
        {
            get
            {
                if (Period == 1)
                    return "Manhã - das 9h às 12h";

                return "Tarde - das 14h às 17h";
            }
        }
        public DateTime Date { get; set; }
        public string _Date { get => Date.ToString("dd/MM/yyyy"); }

        public WelfareEmailViewModel()
        {
            SeguradoProfissional = new SeguradoProfissionalViewModel();
        }

        public WelfareEmailViewModel(SeguradoProfissionalViewModel seguradoProfissional, int period, DateTime date)
        {
            SeguradoProfissional = seguradoProfissional;
            Period = period;
            Date = date;
        }
    }
}
