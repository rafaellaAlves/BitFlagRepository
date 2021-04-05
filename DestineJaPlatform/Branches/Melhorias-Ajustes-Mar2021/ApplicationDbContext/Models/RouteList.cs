using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class RouteList
    {
        [Key]
        public int RouteId { get; set; }
        public string Name { get; set; }
        public string Observation { get; set; }
        public int RouteClientCount { get; set; }
        public bool IsDeleted { get; set; }
        public bool Suspended { get; set; }
        public bool Canceled { get; set; }
        public int? RouteTypeId { get; set; }
        public string RouteTypeName { get; set; }
        public int? RoutePeriodicityId { get; set; }
        public string RoutePeriodicityName { get; set; }
    }
}
