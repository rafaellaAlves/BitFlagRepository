using DTO.Shared;
using DTO.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Client
{
    public class CollectionRequestEmailViewModel
    {
        public ClientViewModel Client { get; set; }
        public UserViewModel User { get; set; }
        public AddressBaseViewModel Address { get; set; }
        public ClientCollectionRequestViewModel CollectionRequest { get; set; }

        public CollectionRequestEmailViewModel(ClientViewModel client, UserViewModel user, AddressBaseViewModel address, ClientCollectionRequestViewModel collectionRequest)
        {
            Client = client;
            User = user;
            Address = address;
            CollectionRequest = collectionRequest;
        }
    }
}
