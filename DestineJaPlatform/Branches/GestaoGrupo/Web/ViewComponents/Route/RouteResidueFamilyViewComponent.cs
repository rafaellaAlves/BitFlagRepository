using DTO.Residue;
using DTO.Route;
using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Org.BouncyCastle.Math.EC.Rfc7748;
using Services.Client;
using Services.Contract;
using Services.Residue;
using Services.Route;
using Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Route
{
    public class RouteResidueFamilyViewComponent : ViewComponent
    {
        private readonly ResidueServices residueServices;
        private readonly ResidueFamilyListService residueFamilyListService;
        private readonly ServiceServices serviceServices;
        private readonly ContractResidueServices contractResidueServices;
        private readonly ServiceResidueFamilyPriceServices serviceResidueFamilyPriceServices;

        public RouteResidueFamilyViewComponent(ContractResidueServices contractResidueServices, ServiceResidueFamilyPriceServices serviceResidueFamilyPriceServices, ResidueServices residueServices, ResidueFamilyListService residueFamilyListService, ServiceServices serviceServices)
        {
            this.residueServices = residueServices;
            this.residueFamilyListService = residueFamilyListService;
            this.serviceServices = serviceServices;

            this.contractResidueServices = contractResidueServices;

            this.serviceResidueFamilyPriceServices = serviceResidueFamilyPriceServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int addressId, int? contractId, int? serviceId, bool loadFromController = false)
        {
            IEnumerable<IGrouping<ResidueFamilyListViewModel, ResidueViewModel>> families;

            if (contractId.HasValue)
            {
                families = (from crs in await contractResidueServices.GetDataAsNoTrackingAsync(x => x.ContractId == contractId)
                            join r in await residueServices.GetViewModelAsNoTrackingAsync() on crs.ResidueId equals r.ResidueId
                            join rf in await residueFamilyListService.GetViewModelAsNoTrackingAsync() on r.ResidueFamilyId equals rf.ResidueFamilyId
                            group r by rf into g
                            select g);
            }
            else if (serviceId.HasValue)
            {
                //var service = await serviceServices.GetDataByIdAsync(serviceId.Value);//serviço
                //var serviceIds = (await serviceServices.GetDataAsNoTrackingAsync(x => !x.IsDeleted && service.ClientId == x.ClientId)).Select(x => x.ServiceId); //Obtem todos serviços relacionados ao mesmo cliente

                //families = (from srf in await serviceResidueFamilyPriceServices.GetDataAsNoTrackingAsync(x => serviceIds.Contains(x.ServiceId))
                families = (from srf in await serviceResidueFamilyPriceServices.GetDataAsNoTrackingAsync(x => serviceId == x.ServiceId)
                            join rf in await residueFamilyListService.GetViewModelAsNoTrackingAsync() on srf.ResidueFamilyId equals rf.ResidueFamilyId
                            join r in await residueServices.GetViewModelAsNoTrackingAsync() on rf.ResidueFamilyId equals r.ResidueFamilyId
                            group r by rf into g
                            select g);
            }
            else
            {
                families = (from rf in await residueFamilyListService.GetViewModelAsNoTrackingAsync(x => !x.IsDeleted)
                            join r in await residueServices.GetViewModelAsNoTrackingAsync(x => !x.IsDeleted) on rf.ResidueFamilyId equals r.ResidueFamilyId
                            group r by rf into g
                            select g);
            }

            var data = (from g in families
                        select new RouteResidueFamilyParameterItemViewModel
                        {
                            ResidueFamily = g.Key,
                            Residues = g.ToList()
                        }).ToList();


            return await Task.Run(() => View(new EntityViewMode<RouteResidueFamilyParameterViewModel>(ViewMode.Editable, new RouteResidueFamilyParameterViewModel(addressId, data), loadFromController)));
        }
    }
}
