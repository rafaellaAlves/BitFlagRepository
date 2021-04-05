using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DB.Models;
using WEB.Models;

namespace WEB.BLL
{
    public class RevenuesFormFunctions : BLLBasicFunctions<RevenuesForm,RevenuesForm>
    {
        public RevenuesFormFunctions(Insurance_HomologContext context) : base(context, "RevenuesFormId")
        {

        }

        public override int Create(RevenuesForm model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<RevenuesForm> GetDataViewModel(IEnumerable<RevenuesForm> data)
        {
            return data.ToList();
        }

        public override RevenuesForm GetDataViewModel(RevenuesForm data)
        {
            return data;
        }

        public RevenuesForm GetDataByExternalCode(string externalCode)
        {
            return dbSet.Single(x => x.ExternalCode == externalCode);
        }


        public override void Update(RevenuesForm model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.RevenuesForm;
        }
    }
}
