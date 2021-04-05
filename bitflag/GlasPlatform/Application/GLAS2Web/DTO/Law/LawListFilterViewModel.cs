using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Law
{
    public class LawListFilterViewModel
    {
        public bool? NotIncludeRevokedLaws { get; set; }
        public string NotGetThisLaws { get; set; }
        public DateTime? ForceDate { get; set; }
        public int? SegmentoId { get; set; }
        public int? EsferaId { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
    }
}
