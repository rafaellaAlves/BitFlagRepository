using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLAS2Web.ViewComponents.AuditManagement
{
    public class AuditCompanyLawSelectViewComponent : ViewComponent
    {
        private DAL.GLAS2Context _context;
        private BLL.Company.CompanyLawViewFunctions _companyLawViewFunctions;
        private BLL.Law.LawApplicationTypeFunctions _lawApplicationTypeFunctions;
        public AuditCompanyLawSelectViewComponent(DAL.GLAS2Context context)
        {
            this._context = context;
            this._companyLawViewFunctions = new BLL.Company.CompanyLawViewFunctions(context);
            this._lawApplicationTypeFunctions = new BLL.Law.LawApplicationTypeFunctions(context);
        }

        public IViewComponentResult Invoke(int? companyId, int? segmentoId, int? esferaId, int? lawTypeId, int? orgaoId)
        {
            var lawApplicationType = this._lawApplicationTypeFunctions.GetDataFiltered(x => x.ExternalCode.ToUpper().Equals("APPLICABLE")).Single();
            var companyLawView = this._companyLawViewFunctions.GetData(x => x.CompanyId == companyId.Value && x.CompanyLawApplicationTypeId == lawApplicationType.LawApplicationTypeId && x.CompanyLawIsDeleted == false && x.LawIsDeleted == false);

            if (segmentoId.HasValue) companyLawView = companyLawView.Where(x => x.LawSegmentoId == segmentoId.Value);
            if (esferaId.HasValue) companyLawView = companyLawView.Where(x => x.LawEsferaId == esferaId.Value);
            if (lawTypeId.HasValue) companyLawView = companyLawView.Where(x => x.LawTypeId == lawTypeId.Value);
            if (orgaoId.HasValue) companyLawView = companyLawView.Where(x => x.LawOrgaoId == orgaoId.Value);

            return View(companyLawView.ToList());
        }
    }
}
