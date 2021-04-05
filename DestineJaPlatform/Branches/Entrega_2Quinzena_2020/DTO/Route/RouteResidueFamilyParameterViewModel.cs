using DTO.Residue;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Route
{
    public class RouteResidueFamilyParameterViewModel
    {
        /// <summary>
        /// It could be a ContractClientCollectionAddressId or ServiceClientCollectionAddressId
        /// </summary>
        public int ClientCollectionAddressId { get; set; }
        public List<RouteResidueFamilyParameterItemViewModel> Items { get; set; }

        public RouteResidueFamilyParameterViewModel(int clientCollectionAddressId, List<RouteResidueFamilyParameterItemViewModel> items)
        {
            ClientCollectionAddressId = clientCollectionAddressId;
            Items = items;
        }
    }
}
