using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Family
{
    public class ClientApplicant
    {
        public int? ClientApplicantId { get; set; }
        public int? ClientId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
