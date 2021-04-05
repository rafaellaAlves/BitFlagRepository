using BLL.Company;
using BLL.Law;
using BLL.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLAS2Web.ViewComponents.LawManagement
{
    [ViewComponent(Name = "LawManagement")]
    public class AssociateCompanyListViewComponent : ViewComponent
    {
        private readonly CompanyFunctions companyFunctions;
        private readonly CompanyLawFunctions companyLawFunctions;
        private readonly LawFunctions lawFunctions;
        private readonly int esferaFederalId;
        private readonly int esferaEstadualId;
        private readonly int esferaMunicipalId;

        public AssociateCompanyListViewComponent(CompanyFunctions companyFunctions, CompanyLawFunctions companyLawFunctions, LawFunctions lawFunctions, EsferaFunctions esferaFunctions)
        {
            this.companyFunctions = companyFunctions;
            this.lawFunctions = lawFunctions;
            this.companyLawFunctions = companyLawFunctions;

            this.esferaFederalId = esferaFunctions.GetByExternalCode("FEDERAL").EsferaId;
            this.esferaEstadualId = esferaFunctions.GetByExternalCode("ESTADUAL").EsferaId;
            this.esferaMunicipalId = esferaFunctions.GetByExternalCode("MUNICIPAL").EsferaId;
        }

        public async Task<IViewComponentResult> InvokeAsync(int lawId, bool valideByEsfera)
        {
            var companies = this.companyFunctions.GetDataViewModel(this.companyFunctions.GetData(x => x.IsActive == true && x.IsDeleted == false));

            if (valideByEsfera)
            {
                var law = lawFunctions.GetDataByID(lawId);

                if (law.EsferaId == esferaFederalId)
                    companies = companies.Where(x => x.CountryId == law.CountryId).ToList();
                else if (law.EsferaId == esferaEstadualId)
                    companies = companies.Where(x => x.StateId == law.StateId).ToList();
                else if (law.EsferaId == esferaMunicipalId)
                    companies = companies.Where(x => x.CityId == law.CityId).ToList();
            }

            var usedCompanyIds = companyLawFunctions.GetCompanyIdByKnowlodgeLawId(lawId);
            usedCompanyIds.AddRange(companyLawFunctions.GetCompanyIdByApplicableLawId(lawId));
            foreach (var id in usedCompanyIds)
                companies.RemoveAll(x => x.CompanyId == id);

            return await Task.Run(() => View("AssociateCompanyList", companies));
        }
    }
}
