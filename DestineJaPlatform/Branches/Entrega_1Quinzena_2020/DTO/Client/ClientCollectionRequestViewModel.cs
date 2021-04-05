using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Client
{
    public class ClientCollectionRequestViewModel
    {
        public int ClientCollectionRequestId { get; set; }
        public int ClientId { get; set; }
        public string Residue { get; set; }
        public int PhysicalStateId { get; set; }
        public int ResidueFamilyId { get; set; }
        public int PackagingId { get; set; }
        public double? Weight { get; set; }
        public string _Weight { get => Weight.ToWeightPtBr(); set => Weight = value.FromDoublePtBR(); }
        public string Observation { get; set; }
        public string FileName { get; set; }
        public string GuidName { get; set; }
        public string MimeType { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
