using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.FreezedFamily
{
    public class FreezedFamilyListViewModel
    {
        public int FreezedFamilyId { get; set; }
        public string _FreezedFamilyTerraNostraId { get; set; }
        public string FreezedFamilyTerraNostraId { get { return _FreezedFamilyTerraNostraId?? $"{CreatedDate.Year}{CreatedDate.Month.ToString("00")}/{FreezedFamilyId}"; } set { _FreezedFamilyTerraNostraId = value; } }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int MemberCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public string _CreatedDate { get { return CreatedDate.ToDateTimePtBR(); } }
        public int CreatedBy { get; set; }
        public string _CreatedBy { get; set; }
        public bool? Accepted { get; set; }
        public int? AcceptedBy { get; set; }
        public string _AcceptedBy { get; set; }
        public DateTime? AcceptedDate { get; set; }
        public string _AcceptedDate { get { return AcceptedDate.ToDateTimePtBR(); } }
    }
}
