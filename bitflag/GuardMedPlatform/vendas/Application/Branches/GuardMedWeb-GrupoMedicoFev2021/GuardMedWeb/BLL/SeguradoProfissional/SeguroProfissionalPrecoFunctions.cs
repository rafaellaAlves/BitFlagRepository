using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuardMedWeb.DAL;
using BLL;

namespace GuardMedWeb.BLL.SeguradoProfissional
{
    public class SeguroProfissionalPrecoFunctions : BLLBasicFunctions<DAL.SeguroProfissionalPreco, Models.SeguroProfissionalPrecoViewModel>
    {
        public SeguroProfissionalPrecoFunctions(GuardMedWebContext context) 
            : base(context, "SeguroProfissionalPrecoId")
        {
        }

        public override int Create(Models.SeguroProfissionalPrecoViewModel model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<Models.SeguroProfissionalPrecoViewModel> GetDataViewModel(IQueryable<SeguroProfissionalPreco> data)
        {
            var r = (from y in data
                     select new Models.SeguroProfissionalPrecoViewModel() {
                         Custo = y.Custo.ToString("0.00"),
                         CustoAssociado = y.CustoAssociado.ToString("0.00"),
                         CustoAssociadoMensal = y.CustoAssociadoMensal.ToString("0.00"),
                         CustoMensal = y.CustoMensal.ToString("0.00"),
                         CustoPanAnual = y.CustoPanAnual.ToString("0.00"),
                         CustoPanAnualAssociado = y.CustoPanAnualAssociado.ToString("0.00"),
                         CustoPanMensal = y.CustoPanMensal.ToString("0.00"),
                         CustoPanMensalAssociado = y.CustoPanMensalAssociado.ToString("0.00"),
                         IdadeMax = y.IdadeMax,
                         IdadeMin = y.IdadeMin,
                         PlanoSeguroProfissionalId = y.PlanoSeguroProfissionalId,
                         SeguroProfissionalPrecoId = y.SeguroProfissionalPrecoId
                     }).ToList();
            return r;
        }

        public override Models.SeguroProfissionalPrecoViewModel GetDataViewModel(SeguroProfissionalPreco data)
        {
            return new Models.SeguroProfissionalPrecoViewModel()
            {
                Custo = data.Custo.ToString("0.00"),
                CustoAssociado = data.CustoAssociado.ToString("0.00"),
                CustoAssociadoMensal = data.CustoAssociadoMensal.ToString("0.00"),
                CustoMensal = data.CustoMensal.ToString("0.00"),
                CustoPanAnual = data.CustoPanAnual.ToString("0.00"),
                CustoPanAnualAssociado = data.CustoPanAnualAssociado.ToString("0.00"),
                CustoPanMensal = data.CustoPanMensal.ToString("0.00"),
                CustoPanMensalAssociado = data.CustoPanMensalAssociado.ToString("0.00"),
                IdadeMax = data.IdadeMax,
                IdadeMin = data.IdadeMin,
                PlanoSeguroProfissionalId = data.PlanoSeguroProfissionalId,
                SeguroProfissionalPrecoId = data.SeguroProfissionalPrecoId
            };
        }

        public override void Update(Models.SeguroProfissionalPrecoViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.SeguroProfissionalPreco;
        }
    }
}
