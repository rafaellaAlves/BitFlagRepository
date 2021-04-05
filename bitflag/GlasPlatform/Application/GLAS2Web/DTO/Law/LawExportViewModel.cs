using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Law
{
    public class LawExportViewModel
    {
        #region [LAW]
        public int? LawId { get; set; }
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
        public DateTime? PublishDate { get; set; }
        public string _PublishDate { get
            {
                return PublishDate?.ToString("dd/MM/yyyy");
            }
        }
        public DateTime? ForceDate { get; set; }
        public string _ForceDate
        {
            get
            {
                return ForceDate?.ToString("dd/MM/yyyy");
            }
        }

        public string Title { get; set; }
        public string Keywords { get; set; }
        public string EsferaName { get; set; }
        public string OrgaoName { get; set; }
        public string SegmentoName { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string Summary { get; set; }
        public string Comments { get; set; }
        public DateTime? RevokedDate { get; set; }
        public string _RevokedDate => RevokedDate?.ToString("dd/MM/yyyy");
        public string RevokedBy { get; set; }
        public int LawVerificationCount { get; set; }
        public DateTime? AlteredDate { get; set; }
        public string _AlteredDate => AlteredDate?.ToString("dd/MM/yyyy");
        #endregion

        public string LawChangesBy { get; set; }
        public string LawChangesFrom { get; set; }
        public string RevokedFrom { get; set; }

        public List<string> CompanyName { get; set; }
        public List<string> CompanyCNPJ { get; set; }
        public List<string> LawApplicationTypeName { get; set; }
    }
}
