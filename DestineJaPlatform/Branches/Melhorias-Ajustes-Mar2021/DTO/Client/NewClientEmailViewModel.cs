using DTO.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Client
{
    public class NewClientEmailViewModel
    {
        public ClientViewModel Client { get; set; }
        public UserViewModel User { get; set; }

        public NewClientEmailViewModel(ClientViewModel client, UserViewModel user)
        {
            Client = client;
            User = user;
        }
    }
}
