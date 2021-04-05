using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace TerraNostraIdentityDbContext
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string CPF { get; set; }
        public bool MobileNumberConfirmed { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? LastHandler { get; set; }
        public string PasswordRecoveryReference { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool SalesmanAvailable { get; set; }
        public DateTime? LastSaleDate { get; set; }
    }
}
