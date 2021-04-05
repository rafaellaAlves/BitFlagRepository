using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuardMedWeb.DAL;
using BLL;
using GuardMedWeb.Models;

namespace GuardMedWeb.BLL.SeguradoProfissional
{
    public class PlanoSeguroProfissionalFunctions : BLLBasicFunctions<DAL.PlanoSeguroProfissional, PlanoSeguroProfissionalViewModel>
    {
        public PlanoSeguroProfissionalFunctions(GuardMedWebContext context)
            : base(context, "PlanoSeguroProfissionalId")
        {
        }

        public override int Create(PlanoSeguroProfissionalViewModel model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<PlanoSeguroProfissionalViewModel> GetDataViewModel(IQueryable<PlanoSeguroProfissional> data)
        {
            return (from y in data
                    select new PlanoSeguroProfissionalViewModel
                    {
                        Descricao = y.Descricao,
                        EstaAtivo = y.EstaAtivo,
                        ExternalCode = y.ExternalCode,
                        Nome = y.Nome,
                        PlanoSeguroProfissionalId = y.PlanoSeguroProfissionalId,
                        PrecoMensal = y.PrecoMensal.ToString("0.00"),
                        Franquia = y.Franquia,
                        ValorCobertura = y.ValorCobertura
                    }).ToList();
        }

        public override PlanoSeguroProfissionalViewModel GetDataViewModel(PlanoSeguroProfissional data)
        {
            return new PlanoSeguroProfissionalViewModel
            {
                Descricao = data.Descricao,
                EstaAtivo = data.EstaAtivo,
                ExternalCode = data.ExternalCode,
                Nome = data.Nome,
                PlanoSeguroProfissionalId = data.PlanoSeguroProfissionalId,
                PrecoMensal = data.PrecoMensal.ToString("0.00"),
                Franquia = data.Franquia,
                ValorCobertura = data.ValorCobertura
            };
        }

        public override void Update(PlanoSeguroProfissionalViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.PlanoSeguroProfissional;
        }
    }
}
