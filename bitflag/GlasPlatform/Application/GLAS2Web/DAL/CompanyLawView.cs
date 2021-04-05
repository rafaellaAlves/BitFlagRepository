using System;
using System.Collections.Generic;
using Utils;

namespace DAL
{
    public partial class CompanyLawView
    {
        public int CompanyId { get; set; }
        public int LawId { get; set; }
        public int LawTypeId { get; set; }
        public string LawTypeName { get; set; }
        public int? LawOrgaoId { get; set; }
        public string LawOrgaoName { get; set; }
        public string LawTitle { get; set; }
        public int? LawEsferaId { get; set; }
        public string LawEsferaName { get; set; }
        public int? LawSegmentoId { get; set; }
        public string LawSegmentoName { get; set; }
        public DateTime? LawRevokedDate { get; set; }
        public string _LawRevokedDate { get { return LawRevokedDate.ToBrazilianDateFormat(); } }
        public string LawRevokedBy { get; set; }
        public DateTime? LawForceDate { get; set; }
        public string _LawForceDate { get { return LawForceDate.ToBrazilianDateFormat(); } }
        public string LawKeywords { get; set; }
        public bool LawIsDeleted { get; set; }
        public DateTime? LawModifiedDate { get; set; }
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

        [System.ComponentModel.DataAnnotations.Key]
        public int CompanyLawId { get; set; }
        public string CompanyLawEvidence { get; set; }
        public int? CompanyLawApplicationTypeId { get; set; }
        public string CompanyLawApplicationTypeName { get; set; }
        public int? CompanyLawConclusionStatusId { get; set; }
        public string CompanyLawConclusionStatusExternalCode { get; set; }
        public string CompanyLawConclusionStatusName { get; set; }
        public bool CompanyLawIsDeleted { get; set; }
    }
}
