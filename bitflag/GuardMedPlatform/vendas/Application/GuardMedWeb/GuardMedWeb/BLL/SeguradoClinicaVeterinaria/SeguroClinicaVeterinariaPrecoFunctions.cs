using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuardMedWeb.DAL;
using BLL;

namespace GuardMedWeb.BLL.SeguradoClinicaVeterinaria
{
    public class SeguroClinicaVeterinariaPrecoFunctions : BLLBasicFunctions<DAL.SeguroClinicaVeterinariaPreco, DAL.SeguroClinicaVeterinariaPreco>
    {
        public SeguroClinicaVeterinariaPrecoFunctions(GuardMedWebContext context) 
            : base(context, "SeguroClinicaVeterinariaPrecoId")
        {
        }

        public override int Create(SeguroClinicaVeterinariaPreco model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<SeguroClinicaVeterinariaPreco> GetDataViewModel(IQueryable<SeguroClinicaVeterinariaPreco> data)
        {
            return data.ToList();
        }

        public override SeguroClinicaVeterinariaPreco GetDataViewModel(SeguroClinicaVeterinariaPreco data)
        {
            return data;
        }

        public override void Update(SeguroClinicaVeterinariaPreco model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.SeguroClinicaVeterinariaPreco;
        }
    }
}
