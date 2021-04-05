using System;
using System.Collections.Generic;

namespace DB
{
    public partial class ClientApplicant
    {
        public int ClientApplicantId { get; set; }
        public int ClientId { get; set; }
        public string FullName { get; set; }
        public string ConsortFullName { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public DateTime? MarriageDate { get; set; }
        public string MarriagePlace { get; set; }
    }
}
