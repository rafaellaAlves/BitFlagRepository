using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuardMedWeb.DAL;
using GuardMedWeb.Models;
using BLL;

namespace GuardMedWeb.BLL.SeguradoEquipamento
{
    public class EquipamentoFunctions : BLLBasicFunctions<DAL.Equipamento, Models.EquipamentoViewModel>
    {
        public EquipamentoFunctions(GuardMedWebContext context)
            : base(context, "EquipamentoId")
        {
        }

        public override int Create(EquipamentoViewModel model)
        {
            var equipamento = new DAL.Equipamento()
            {
                SeguradoEquipamentoId = model.SeguradoEquipamentoId.Value,
                Marca = model.Marca,
                Modelo = model.Modelo,
                Serie = model.Serie,
                Preco = Convert.ToDouble(model.Preco),
                NF = model.NF,
                Ano = model.Ano,
                EspecificacaoTipo = model.EspecificacaoTipo,
                TipoEquipamentoId = model.TipoEquipamentoId
            };

            dbSet.Add(equipamento);
            context.SaveChanges();

            return equipamento.EquipamentoId;
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<EquipamentoViewModel> GetDataViewModel(IQueryable<Equipamento> data)
        {
            var r = (from y in data.ToList()
                     join te in this.context.TipoEquipamento on y.TipoEquipamentoId equals te.TipoEquipamentoId
                     select new EquipamentoViewModel()
                     {
                         EquipamentoId = y.EquipamentoId,
                         SeguradoEquipamentoId = y.SeguradoEquipamentoId,
                         Marca = y.Marca,
                         Modelo = y.Modelo,
                         Serie = y.Serie,
                         Preco = y.Preco.ToString("0.00"),
                         NF = y.NF,
                         Ano = y.Ano,
                         EspecificacaoTipo = y.EspecificacaoTipo,
                         TipoEquipamentoId = y.TipoEquipamentoId,
                         TipoEquipamentoNome = te.Nome,
                     }).ToList();
            return r;
        }

        public override EquipamentoViewModel GetDataViewModel(Equipamento data)
        {
            return new EquipamentoViewModel()
            {
                EquipamentoId = data.EquipamentoId,
                SeguradoEquipamentoId = data.SeguradoEquipamentoId,
                Marca = data.Marca,
                Modelo = data.Modelo,
                Serie = data.Serie,
                Preco = data.Preco.ToString("0.00"),
                NF = data.NF,
                Ano = data.Ano,
                EspecificacaoTipo = data.EspecificacaoTipo,
                TipoEquipamentoId = data.TipoEquipamentoId,
                TipoEquipamentoNome = this.context.TipoEquipamento.Single(x => x.TipoEquipamentoId == data.TipoEquipamentoId).Nome
                
            };
        }

        public override void Update(EquipamentoViewModel model)
        {
            var equipamento = GetDataByID(model.EquipamentoId);
            equipamento.SeguradoEquipamentoId = model.SeguradoEquipamentoId.Value;
            equipamento.Marca = model.Marca;
            equipamento.Modelo = model.Modelo;
            equipamento.Serie = model.Serie;
            equipamento.Preco = Convert.ToDouble(model.Preco);
            equipamento.NF = model.NF;
            equipamento.Ano = model.Ano;
            equipamento.EspecificacaoTipo = model.EspecificacaoTipo;
            equipamento.TipoEquipamentoId = model.TipoEquipamentoId;

            dbSet.Update(equipamento);
            context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Equipamento;
        }
    }
}
