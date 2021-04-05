using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuardMedWeb.DAL;
using BLL;

namespace GuardMedWeb.BLL.SeguradoClinicaVeterinaria
{
    public class SeguradoClinicaVeterinariaViewFunctions : BLLBasicFunctions<DAL.SeguradoClinicaVeterinariaView, DAL.SeguradoClinicaVeterinariaView>
    {
        public SeguradoClinicaVeterinariaViewFunctions(GuardMedWebContext context) 
            : base(context, "SeguradoClinicaVeterinariaId")
        {
        }

        public override int Create(SeguradoClinicaVeterinariaView model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<SeguradoClinicaVeterinariaView> GetDataViewModel(IQueryable<SeguradoClinicaVeterinariaView> data)
        {
            return data.ToList();
        }

        public override SeguradoClinicaVeterinariaView GetDataViewModel(SeguradoClinicaVeterinariaView data)
        {
            return data;
        }

        public override void Update(SeguradoClinicaVeterinariaView model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.SeguradoClinicaVeterinariaView;
        }
    }
}
