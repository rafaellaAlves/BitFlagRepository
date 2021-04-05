using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Job
{
    public class JobFreezedFamilyInfoViewModel
    {
        public string FullFamilyStruct { get; set; }
        public int FamilyMemberTypeId { get; set; }
        public string FamilyMemberType { get; set; }
        public string FullName { get; set; }
        public string ConsortFullName { get; set; }
        public int CertificateTypeId { get; set; }
        public string CertificateType { get; set; }
        public List<JobFreezedFamilyItemInfoViewModel> Items { get; set; }

        public JobFreezedFamilyInfoViewModel()
        {
            this.Items = new List<JobFreezedFamilyItemInfoViewModel>();
        }
    }
}
