using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace DAL
{
    public partial class Law
    {
        public int LawId { get; set; }
        public int LawTypeId { get; set; }
        public string Number { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? ForceDate { get; set; }
        public string Title { get; set; }
        public string Keywords { get; set; }
        public int? EsferaId { get; set; }
        public int? OrgaoId { get; set; }
        public int? SegmentoId { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string Summary { get; set; }
        public string Comments { get; set; }
        public DateTime? RevokedDate { get; set; }
        public string RevokedBy { get; set; }
        public DateTime? AlteredDate { get; set; }
        public string AlteredBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public int LastHandler { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool HasAttachment { get; set; }
        public int? RevokedById { get; set; }
        public int? QuestionThemeId { get; set; }
        public int? QuestionSubThemeId { get; set; }
        public int? LawPotentialityTypeId { get; set; }
    }
}
