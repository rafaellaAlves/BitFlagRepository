using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class ClientUser
    {
        public int ClientUserId { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }
    }
}
