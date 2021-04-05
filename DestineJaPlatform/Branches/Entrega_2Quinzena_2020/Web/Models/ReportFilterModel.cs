using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ReportFilterModel
    {
        public Type FilterComponentType { get; set; }
        public object Arguments { get; set; }
        public int? ColSize { get; set; }
        public string Col => ColSize.HasValue ? $"col-md-{ColSize}" : "col-md";

        public ReportFilterModel(Type filterComponentType)
        {
            FilterComponentType = filterComponentType;
        }

        public ReportFilterModel(Type filterComponentType, object arguments, int? colSize)
        {
            FilterComponentType = filterComponentType;
            Arguments = arguments;
            ColSize = colSize;
        }

        public static ReportFilterModel StartAndEndDateFilter(object arguments = null, int? colSize = null) => new ReportFilterModel(typeof(ViewComponents.Report.Filter.StartAndEndDateViewComponent), arguments, colSize);
        public static ReportFilterModel StartAndEndMonthFilter(object arguments = null, int? colSize = null) => new ReportFilterModel(typeof(ViewComponents.Report.Filter.StartAndEndMonthViewComponent), arguments, colSize);
        public static ReportFilterModel StartAndEndYearFilter(object arguments = null, int? colSize = null) => new ReportFilterModel(typeof(ViewComponents.Report.Filter.StartAndEndYearViewComponent), arguments, colSize);
        public static ReportFilterModel MonthFilter(object arguments = null, int? colSize = null) => new ReportFilterModel(typeof(ViewComponents.Report.Filter.MonthViewComponent), arguments, colSize);
        public static ReportFilterModel StateAndCityFilter(object arguments = null, int? colSize = null) => new ReportFilterModel(typeof(ViewComponents.Report.Filter.StateAndCityViewComponent), arguments, colSize);
        public static ReportFilterModel RouteFilter(object arguments = null, int? colSize = null) => new ReportFilterModel(typeof(ViewComponents.Report.Filter.RouteViewComponent), arguments, colSize);
        public static ReportFilterModel ClientFilter(object arguments = null, int? colSize = null) => new ReportFilterModel(typeof(ViewComponents.Report.Filter.ClientViewComponent), arguments, colSize);
        public static ReportFilterModel ClientResidueFilter(object arguments = null, int? colSize = null) => new ReportFilterModel(typeof(ViewComponents.Report.Filter.ClientResidueViewComponent), arguments, colSize);
        public static ReportFilterModel UnitOfMeasurementFilter(object arguments = null, int? colSize = null) => new ReportFilterModel(typeof(ViewComponents.Report.Filter.UnitOfMeasurementViewComponent), arguments, colSize);
    }
}
