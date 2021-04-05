using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace DTO.Law
{
    public class LawViewModel
    {
        public int? LawId { get; set; }
        public int LawTypeId { get; set; }
        public string LawTypeName { get; set; }
        public string Number { get; set; }
        public string _Number
        {
            get
            {
                UInt64 o;
                if (UInt64.TryParse(this.Number, out o))
                    return String.Format(@"{0:n0}", o);
                else
                    return this.Number;
            }
        }
        public string PublishDate { get; set; }
        public DateTime? _ForceDate { get; set; }
        public string ForceDate { get; set; }
        public string Title { get; set; }
        public string Keywords { get; set; }
        public int? EsferaId { get; set; }
        public string EsferaName { get; set; }
        public int? OrgaoId { get; set; }
        public string OrgaoName { get; set; }
        public int? SegmentoId { get; set; }
        public string SegmentoName { get; set; }
        public int? CountryId { get; set; }
        public string Country { get; set; }
        public int? StateId { get; set; }
        public string State { get; set; }
        public int? CityId { get; set; }
        public string City { get; set; }
        public string Summary { get; set; }
        public string Comments { get; set; }
        public string RevokedDate { get; set; }
        public string RevokedBy { get; set; }
        public string AlteredDate { get; set; }
        public string AlteredBy { get; set; }
        public bool HasAttachment { get; set; }
        public string LawInfoForEmail
        {
            get
            {
                return  this.LawTypeName + ", " + this.OrgaoName + ", " + this._Number + " de " + this.ForceDate;
            }
        }
        public bool NotSendEmail { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string _CreatedDate { get { return CreatedDate?.ToString("dd/MM/yyyy HH:mm:ss"); } }
        public int? CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public int? RevokedById { get; set; }
        public int? QuestionThemeId { get; set; }
        public int? QuestionSubThemeId { get; set; }
        public int? LawPotentialityTypeId { get; set; }
    }
}
