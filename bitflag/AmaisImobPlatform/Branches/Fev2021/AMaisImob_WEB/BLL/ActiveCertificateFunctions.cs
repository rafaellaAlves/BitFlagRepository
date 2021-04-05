using AMaisImob_DB.Models;
using AMaisImob_WEB.Models;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace AMaisImob_WEB.BLL
{
    public class ActiveCertificateFunctions : BLLBasicFunctions<ActiveCertificate, ActiveCertificateViewModel>
    {
        public ActiveCertificateFunctions(AMaisImob_HomologContext context) : base(context, "CertAtivosId")
        {

        }

        public override int Create(ActiveCertificateViewModel model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<ActiveCertificateViewModel> GetDataViewModel(IEnumerable<ActiveCertificate> data)
        {
            throw new NotImplementedException();
        }

        public override ActiveCertificateViewModel GetDataViewModel(ActiveCertificate data)
        {
            throw new NotImplementedException();
        }

        public override void Update(ActiveCertificateViewModel model)
        {
            throw new NotImplementedException();

        }

        protected override void SetDbSet()
        {
            this.dbSet = context.ActiveCertificates;
        }
    }
}
