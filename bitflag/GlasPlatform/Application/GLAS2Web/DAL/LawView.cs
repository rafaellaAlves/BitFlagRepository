using System;
using System.Collections.Generic;
using Utils;

namespace DAL
{
    public partial class LawView
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int LawId { get; set; }
        public int LawTypeId { get; set; }
        public string LawTypeName { get; set; }
        public string LawNumber { get; set; }
        public long LawNumberOrdering { get; set; }
        public string _LawNumberOrdering { get; set; }
        public string _LawNumber
        {
            get
            {
                UInt64 o;
                if (UInt64.TryParse(this.LawNumber, out o))
                    return String.Format(@"{0:n0}", o);
                else
                    return this.LawNumber;
            }
        }
        public string LawTitle { get; set; }
        public int? LawOrgaoId { get; set; }
        public string LawOrgaoName { get; set; }
        public int? LawEsferaId { get; set; }
        public string LawEsferaName { get; set; }
        public DateTime? LawForceDate { get; set; }
        public string _LawForceDate => LawForceDate.ToBrazilianDateFormat();
        public DateTime? LawRevokedDate { get; set; }
        public string _LawRevokedDate => LawRevokedDate.ToBrazilianDateFormat();
        public string LawKeywords { get; set; }
        public string LawRevokedBy { get; set; }
        public int? LawSegmentoId { get; set; }
        public string LawSegmentoName { get; set; }
        public int? FullLawAttachmentId { get; set; }
        public string FullLawAttachmentName { get; set; }
        public int? LawCountryId { get; set; }
        public string LawCountryName { get; set; }
        public string LawCountryExternalCode { get; set; }
        public int? LawStateId { get; set; }
        public string LawStateName { get; set; }
        public string LawStateExternalCode { get; set; }
        public int? LawCityId { get; set; }
        public string LawCityName { get; set; }
        public DateTime? LawAlteredDate { get; set; }
        public string _LawAlteredDate => LawAlteredDate.ToBrazilianDateFormat();
        public string LawAlteredBy { get; set; }
    }
}
