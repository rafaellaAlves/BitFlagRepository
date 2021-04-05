using DTO.Residue;
using DTO.Route;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.Demand
{
    public class DemandClientSelectionViewModel
    {
        public RouteViewModel Route { get; set; }
        public List<ResidueFamilyListViewModel> ResidueFamily { get; set; }
        public IEnumerable<int> ResidueFamilyIds => ResidueFamily.Select(x => x.ResidueFamilyId).Distinct();


        public DemandClientSelectionViewModel() { }
        public DemandClientSelectionViewModel(RouteViewModel route, List<ResidueFamilyListViewModel> residueFamily)
        {
            Route = route;
            ResidueFamily = residueFamily;
        }
    }
}
