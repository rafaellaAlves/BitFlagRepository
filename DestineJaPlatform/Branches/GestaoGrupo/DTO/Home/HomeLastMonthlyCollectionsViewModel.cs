using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DTO.Home
{
    public class HomeLastMonthlyCollectionsViewModel
    {
        public DateTime Month { get; set; }
        public string Name => new CultureInfo("pt-BR").TextInfo.ToTitleCase(new CultureInfo("pt-BR").DateTimeFormat.GetMonthName(Month.Month)).Substring(0, 3);
        public double Weight { get; set; }
        public double Y
        {
            get
            {
                if ((Weight * 100) % 1 == 0)
                    return Weight;

                return Math.Round(Weight, 2);
            }
        }
    }
}
