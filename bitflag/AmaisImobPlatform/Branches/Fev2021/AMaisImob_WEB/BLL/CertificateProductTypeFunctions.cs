using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMaisImob_DB.Models;
using BLL;

namespace AMaisImob_WEB.BLL
{
    public class CertificateProductTypeFunctions : BLLBasicFunctions<AMaisImob_DB.Models.CertificateProductType, AMaisImob_DB.Models.CertificateProductType>
    {
        public CertificateProductTypeFunctions(AMaisImob_HomologContext context) 
            : base(context, "CertificateProductTypeId")
        {
        }

        public override int Create(CertificateProductType model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<CertificateProductType> GetDataViewModel(IEnumerable<CertificateProductType> data)
        {
            return data.ToList();
        }

        public override CertificateProductType GetDataViewModel(CertificateProductType data)
        {
            return data;
        }

        public override void Update(CertificateProductType model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CertificateProductType;
        }
    }
}
