using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DB
{
    public class FreezedFamilyList
    {
        [Key]
        public int FreezedFamilyId { get; set; }
        public string FreezedFamilyTerraNostraId { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int MemberCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public string _CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public string _CreatedBy { get; set; }
        public bool? Accepted { get; set; }
        public int? AcceptedBy { get; set; }
        public string _AcceptedBy { get; set; }
        public DateTime? AcceptedDate { get; set; }
        public string _AcceptedDate { get; set; }
        public int? ResponsibleId { get; set; }
    }
}
