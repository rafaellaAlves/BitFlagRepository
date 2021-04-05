using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using BLL;

namespace GuardMedWeb.BLL.SeguradoClinicaVeterinaria
{
    public class PlanoSeguroClinicaVeterinariaFunctions : BLLBasicFunctions<DAL.PlanoSeguroClinicaVeterinaria, DAL.PlanoSeguroClinicaVeterinaria>
    {
        public PlanoSeguroClinicaVeterinariaFunctions(GuardMedWebContext context) 
            : base(context, "PlanoSeguroClinicaVeterinariaId")
        {
        }

        public override int Create(DAL.PlanoSeguroClinicaVeterinaria model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<DAL.PlanoSeguroClinicaVeterinaria> GetDataViewModel(IQueryable<DAL.PlanoSeguroClinicaVeterinaria> data)
        {
            return data.ToList();
        }

        public override DAL.PlanoSeguroClinicaVeterinaria GetDataViewModel(DAL.PlanoSeguroClinicaVeterinaria data)
        {
            return data;
        }

        public override void Update(DAL.PlanoSeguroClinicaVeterinaria model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.PlanoSeguroClinicaVeterinaria;
        }
    }
}
