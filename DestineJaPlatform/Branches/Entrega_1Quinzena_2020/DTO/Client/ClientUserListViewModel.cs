using DTO.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Client
{
    public class ClientUserListViewModel
    {
        public int ClientId { get; set; }
        public List<UserViewModel> Users { get; set; }
    }
}
