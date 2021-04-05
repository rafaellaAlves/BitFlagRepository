using DTO.Route;
using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.Demand
{
    public class DemandClientManageViewModel
    {
        public RouteViewModel Route { get; set; }
        public DemandViewModel Demand { get; set; }
        public List<DemandClientListViewModel> DemandClient { get; set; }
        public List<DemandClientListViewModel> DemandNotUsedClient { get; set; }
        public List<DemandResidueFamilyViewModel> DemandResidueFamily { get; set; }

        public DemandClientManageViewModel() { }
        public DemandClientManageViewModel(DemandViewModel demand, RouteViewModel route, List<DemandClientListViewModel> demandNotUsedClient, List<DemandClientListViewModel> demandClient, List<DemandResidueFamilyViewModel> demandResidueFamily)
        {
            Demand = demand;
            Route = route;
            DemandNotUsedClient = demandNotUsedClient;
            DemandClient = demandClient;
            DemandResidueFamily = demandResidueFamily;
        }

        public string GetJsonFamilies()
        {
            List<string> jsonItems = new List<string>();
            var allDemandClients = DemandClient;
            foreach (var demandNotUsedClient in DemandNotUsedClient)
                if (!allDemandClients.Any(x => x.ClientCollectionAddressId == demandNotUsedClient.ClientCollectionAddressId && x.ContractId == demandNotUsedClient.ContractId && x.ServiceId == demandNotUsedClient.ServiceId))
                    allDemandClients.Add(demandNotUsedClient);

            if (!Demand.DemandId.HasValue) // Quando é crição, todos as familias vinculadas nos clientes da rota já são atribuidas a variavel "addressFamilyIds" que é onde são armazenadas as familias dos clientes
            {
                foreach (var item in allDemandClients)
                {
                    if (item._DemandResidueFamilyIds.Count() == 0) continue;

                    var names = string.Join(",", item._ResidueFamilyName.Select(x => $"\"{x}\""));

                    jsonItems.Add("{" +
                        $"familyIds: [{string.Join(",", item._DemandResidueFamilyIds)}]," +
                        $"familyNames: [{names}]," +
                        $"clientCollectionAddressId: {item.ClientCollectionAddressId}," +
                    "}");
                }
            }
            else
            {
                foreach (var demandClient in allDemandClients)//alimenta a variavel "addressFamilyIds"
                {
                    var demandResidueFamily = DemandResidueFamily.Where(x => x.ClientCollectionAddressId == demandClient.ClientCollectionAddressId);
                    if (demandResidueFamily.Count() == 0) continue;

                    jsonItems.Add("{" +
                        $"familyIds: [{string.Join(",", demandResidueFamily.Select(x => x.ResidueFamilyId))}]," +
                        $"familyNames: [{string.Join(",", demandResidueFamily.Select(x => x.ResidueFamily.NameAbbreviation.IfNullChange(x.ResidueFamily.Name)).Select(x => $"\"{x}\""))}]," +
                        $"clientCollectionAddressId: {demandClient.ClientCollectionAddressId}," +
                    "}");
                }
            }

            return $"{string.Join(", ", jsonItems)}";
        }

        public string GetJsonFamilyNames()
        {
            List<string> familyNames = new List<string>();
            if (!Demand.DemandId.HasValue) return string.Empty;

            foreach (var demandClient in DemandNotUsedClient.Union(DemandClient))
            {
                var demandResidueFamily = DemandResidueFamily.Where(x => x.ClientCollectionAddressId == demandClient.ClientCollectionAddressId);
                if (demandResidueFamily.Count() == 0) continue;

                familyNames.AddRange(demandResidueFamily.Select(x => x.ResidueFamily.NameAbbreviation.IfNullChange(x.ResidueFamily.Name)).Distinct());
            }

            return $"{string.Join(", ", familyNames.Distinct().Select(x => $"\"{x}\""))}";
        }
    }
}
