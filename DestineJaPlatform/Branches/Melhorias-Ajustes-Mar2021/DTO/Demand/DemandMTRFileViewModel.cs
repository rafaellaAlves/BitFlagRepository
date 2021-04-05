using DTO.Client;
using DTO.Residue;
using DTO.Transporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.Demand
{
    public class DemandMTRFileViewModel
    {
        public DemandClientViewModel DemandClient { get; set; }
        public DemandViewModel Demand { get; set; }
        public ClientViewModel Client { get; set; }
        public ClientCollectionAddressViewModel ClientMainAddress { get; set; }
        public ClientContactViewModel ClientContact { get; set; }
        public TransporterViewModel Transporter { get; set; }
        public TransporterDriverViewModel TransporterDriver { get; set; }
        public TransporterVehicleViewModel TransporterVehicle { get; set; }
        public List<ResidueListViewModel> ContractResidues { get; set; }
        public List<ResidueFamilyViewModel> DemandResidueFamilies { get; set; }

        private ResidueFamilyViewModel mtrFileResidueFamily;
        public ResidueFamilyViewModel MTRFileResidueFamily //Familia que irá aparecer na impressão
        {
            get
            {
                if (mtrFileResidueFamily != null) return mtrFileResidueFamily;

                if (DemandResidueFamilies.Count > 0)//Se tiver familia selecionadas na tela de Demand/Manage
                {
                    if (DemandResidueFamilies.Any(x => !string.IsNullOrWhiteSpace(x.GroupName))) //Se tiver familia de agrupamento, ele será atribuido
                        mtrFileResidueFamily = DemandResidueFamilies.First(x => !string.IsNullOrWhiteSpace(x.GroupName));
                    else //Se não tiver familia de agrupamento, será atribuido a primeira familia
                        mtrFileResidueFamily = DemandResidueFamilies.First();
                }
                else
                {
                    var familiesWithGroup = ContractResidues.Where(x => string.IsNullOrWhiteSpace(x.ResidueFamilyGroupName)); // obtem os residuo que a familia possua um agrupamento
                    int index;

                    if(familiesWithGroup.Count() > 0)
                    {
                        var minGroupOrder = familiesWithGroup.Min(x => x.ResidueFamilyGroupOrder);//pega a familia que possua agrupamento com o menor número no "ResidueFamilyGroupOrder"
                        index = familiesWithGroup.ToList().FindIndex(x => x.ResidueFamilyGroupOrder == minGroupOrder);
                    }
                    else//caso nenhuma familia possua agrupamento, será mostrado o primeiro resíduo
                    {
                        index = 0;
                    }


                    mtrFileResidueFamily = new ResidueFamilyViewModel
                    {
                        Name = ContractResidues[index].ResidueFamilyName,
                        ResidueFamilyId = ContractResidues[index].ResidueFamilyId
                    };
                }

                return mtrFileResidueFamily;
            }
        }

        public ResidueListViewModel MTRFileResidue => ContractResidues.First(c => c.ResidueFamilyId == MTRFileResidueFamily.ResidueFamilyId);  //Resíduo que irá aparecer na impressão
    }
}
