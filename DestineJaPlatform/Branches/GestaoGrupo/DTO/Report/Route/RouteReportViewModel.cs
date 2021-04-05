using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DTO.Report.Route
{
    public class RouteReportViewModel
    {
        public List<RouteReportItemViewModel> Data { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<DateTime> AllDepartureDates => Data.Select(x => x.DepartureDate).Distinct().ToList();

        public List<string> AllDepartureDatesFormated => AllDepartureDates.Select(date => date.ToBrazilianDateFormat()).ToList();

        public List<double> WightsPerDate
        {
            get
            {
                List<double> weights = new List<double>();

                foreach (var date in AllDepartureDates)
                    weights.Add(Data.Where(x => x.DepartureDate == date).Sum(x => x.Weight));

                return weights;
            }
        }
    }
}
