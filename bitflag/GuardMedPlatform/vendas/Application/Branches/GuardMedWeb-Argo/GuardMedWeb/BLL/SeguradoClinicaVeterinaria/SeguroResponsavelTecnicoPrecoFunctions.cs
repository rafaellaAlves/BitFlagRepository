using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using BLL;

namespace GuardMedWeb.BLL.SeguradoClinicaVeterinaria
{
    public class SeguroResponsavelTecnicoPrecoFunctions : BLLBasicFunctions<DAL.SeguroResponsavelTecnicoPreco, DAL.SeguroResponsavelTecnicoPreco>
    {
        public SeguroResponsavelTecnicoPrecoFunctions(GuardMedWebContext context) 
            : base(context, "SeguroResponsavelTecnicoPrecoId")
        {
        }

        public override int Create(SeguroResponsavelTecnicoPreco model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<SeguroResponsavelTecnicoPreco> GetDataViewModel(IQueryable<SeguroResponsavelTecnicoPreco> data)
        {
            return data.ToList();
        }

        public override SeguroResponsavelTecnicoPreco GetDataViewModel(SeguroResponsavelTecnicoPreco data)
        {
            return data;
        }

        public override void Update(SeguroResponsavelTecnicoPreco model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.SeguroResponsavelTecnicoPreco;
        }
    }
}
