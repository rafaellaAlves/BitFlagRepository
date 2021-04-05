using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Indication
{
    public class NewIndicationViewModel
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int ServiceTypeId { get; set; }
    }
}
