using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace GLAS2Web.ViewComponents.AuditItemManagement
{
    public class AuditItemListViewComponent : ViewComponent
    {
        private DAL.GLAS2Context _context;
        private BLL.Audit.AuditFunctions _auditFunctions;
        private BLL.Audit.AuditItemFunctions _auditItemFunctions;
        private BLL.Audit.AuditItemStatusFunctions _auditItemStatusFunctions;
        private int ConclusionStatusId { get; }

        public AuditItemListViewComponent(DAL.GLAS2Context context)
        {
            this._context = context;
            this._auditFunctions = new BLL.Audit.AuditFunctions(context);
            this._auditItemFunctions = new BLL.Audit.AuditItemFunctions(context);
            this._auditItemStatusFunctions = new BLL.Audit.AuditItemStatusFunctions(context);

            ConclusionStatusId = new BLL.Audit.AuditStatusFunctions(context).GetData().Where(x => x.ExternalCode == "COMPLETED").Single().AuditStatusId;
        }

        public IViewComponentResult Invoke(int? auditId)
        {
            var audit = _auditFunctions.GetDataByID(auditId);

            List<DTO.Audit.AuditItemViewModel> model = this._auditItemFunctions.GetDataViewModel(this._auditItemFunctions.GetData(x => x.AuditId == auditId.Value))
                .Where(x => audit.AuditStatusId == ConclusionStatusId || (!x.CompanyLawView.LawRevokedDate.HasValue && !x.CompanyLawView.LawIsDeleted)).ToList(); // Não pega os revogados

            ViewData["AuditItemStatus"] = this._auditItemStatusFunctions.GetData().ToList();

            return View(model);
        }
    }
}
