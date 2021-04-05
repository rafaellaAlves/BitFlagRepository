using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using GuardMedWeb.Models;
using BLL;

namespace GuardMedWeb.BLL.SeguradoEquipamento
{
    public class SeguradoEquipamentoFunctions : BLLBasicFunctions<DAL.SeguradoEquipamento, Models.SeguradoEquipamentoViewModel>
    {
        private readonly BLL.SeguradoEquipamento.PlanoSeguroEquipamentoFunctions planoSeguroEquipamentoFunctions;
        private readonly BLL.SeguradoEquipamento.EquipamentoFunctions equipamentoFunctions;
        public SeguradoEquipamentoFunctions(GuardMedWebContext context)
            : base(context, "SeguradoEquipamentoId")
        {
            planoSeguroEquipamentoFunctions = new BLL.SeguradoEquipamento.PlanoSeguroEquipamentoFunctions(context);
            equipamentoFunctions = new BLL.SeguradoEquipamento.EquipamentoFunctions(context);
        }

        public override int Create(SeguradoEquipamentoViewModel model)
        {
            var seguradoEquipamento = new DAL.SeguradoEquipamento
            {
                Nome = model.Nome,
                Email = model.Email,
                Telefone = model.Telefone,
                Celular = model.Celular,
                PrecoEquipamento = Convert.ToDouble(model.PrecoEquipamento),
                QtdEquipamento = model.QtdEquipamento,
                PlanoSeguroEquipamentoId = model.PlanoSeguroEquipamentoId.Value,
                Crmv = model.CRMV,
                Crmvestado = model.CRMVEstado,
                DataCriacao = DateTime.Now,
                Referencia = model.Referencia,
                CertificadoGerado = false
            };

            this.dbSet.Add(seguradoEquipamento);
            context.SaveChanges();

            return seguradoEquipamento.SeguradoEquipamentoId;
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<SeguradoEquipamentoViewModel> GetDataViewModel(IQueryable<DAL.SeguradoEquipamento> data)
        {
            var r = (from y in data.ToList()
                     join pse in context.PlanoSeguroEquipamento on y.PlanoSeguroEquipamentoId equals pse.PlanoSeguroEquipamentoId
                     select new SeguradoEquipamentoViewModel
                     {
                         PlanoSeguroEquipamentoId = y.PlanoSeguroEquipamentoId,
                         PlanoSeguroEquipamentoNome = pse.Nome,
                         Referencia = y.Referencia,
                         Nome = y.Nome,
                         DataNascimento = y.DataNascimento,
                         Email = y.Email,
                         Telefone = y.Telefone,
                         Celular = y.Celular,
                         CRMV = y.Crmv,
                         CRMVEstado = y.Crmvestado,
                         SeguradoEquipamentoId = y.SeguradoEquipamentoId,
                         Bairro = y.Bairro,
                         CEP = y.Cep,
                         Cidade = y.Cidade,
                         Complemento = y.Complemento,
                         CPF = y.Cpf,
                         Endereco = y.Endereco,
                         EnderecoNumero = y.EnderecoNumero,
                         Estado = y.Estado,
                         PrecoEquipamento = (y.PrecoEquipamento.HasValue ? y.PrecoEquipamento.Value.ToString("0.00") : null),
                         PrecoSeguro = (y.PrecoSeguro.HasValue ? y.PrecoSeguro.Value.ToString("0.00") : null),
                         VezesPagamento = y.VezesPagamento,
                         PagamentoTipoId = y.PagamentoTipoId,
                         QtdEquipamento = y.QtdEquipamento,
                         DataCriacao = y.DataCriacao,
                         DataAtualizacao = y.DataAtualizacao,
                         CertificadoGerado = y.CertificadoGerado
                     }).ToList();
            return r;
        }

        public override SeguradoEquipamentoViewModel GetDataViewModel(DAL.SeguradoEquipamento data)
        {
            var equipamentos = equipamentoFunctions.GetDataViewModel(equipamentoFunctions.GetData().Where(x => x.SeguradoEquipamentoId == data.SeguradoEquipamentoId));
            var planoSeguroEquipamento = planoSeguroEquipamentoFunctions.GetDataByID(data.PlanoSeguroEquipamentoId);
            return new SeguradoEquipamentoViewModel
            {
                PlanoSeguroEquipamentoId = data.PlanoSeguroEquipamentoId,
                PlanoSeguroEquipamentoNome = planoSeguroEquipamento.Nome,
                Referencia = data.Referencia,
                Nome = data.Nome,
                DataNascimento = data.DataNascimento,
                Email = data.Email,
                Telefone = data.Telefone,
                Celular = data.Celular,
                CRMV = data.Crmv,
                CRMVEstado = data.Crmvestado,
                SeguradoEquipamentoId = data.SeguradoEquipamentoId,
                Bairro = data.Bairro,
                CEP = data.Cep,
                Cidade = data.Cidade,
                Complemento = data.Complemento,
                CPF = data.Cpf,
                Endereco = data.Endereco,
                EnderecoNumero = data.EnderecoNumero,
                Estado = data.Estado,
                PrecoEquipamento = (data.PrecoEquipamento.HasValue ? data.PrecoEquipamento.Value.ToString("0.00") : null),
                PrecoSeguro = (data.PrecoSeguro.HasValue ? data.PrecoSeguro.Value.ToString("0.00") : null),
                VezesPagamento = data.VezesPagamento,
                PagamentoTipoId = data.PagamentoTipoId,
                QtdEquipamento = data.QtdEquipamento,
                Equipamentos = equipamentos,
                DataCriacao = data.DataCriacao,
                DataAtualizacao = data.DataAtualizacao,
                CertificadoGerado = data.CertificadoGerado
            };
        }

        public override void Update(SeguradoEquipamentoViewModel model)
        {
            throw new NotImplementedException();
        }

        public void UpdateCotacao(SeguradoEquipamentoViewModel model)
        {
            var seguradoEquipamento = GetDataByID(model.SeguradoEquipamentoId);

            seguradoEquipamento.PrecoSeguro = Convert.ToDouble(model.PrecoSeguro);
            seguradoEquipamento.DataAtualizacao = DateTime.Now;

            this.dbSet.Update(seguradoEquipamento);
            context.SaveChanges();
        }

        public void UpdateFormulario(SeguradoEquipamentoViewModel model)
        {
            var seguradoEquipamento = GetDataByID(model.SeguradoEquipamentoId);

            seguradoEquipamento.Nome = model.Nome;
            seguradoEquipamento.DataNascimento = model.DataNascimento;
            seguradoEquipamento.Cpf = model.CPF;
            seguradoEquipamento.Crmv = model.CRMV;
            seguradoEquipamento.Cep = model.CEP;
            seguradoEquipamento.Cidade = model.Cidade;
            seguradoEquipamento.Complemento = model.Complemento;
            seguradoEquipamento.Endereco = model.Endereco;
            seguradoEquipamento.EnderecoNumero = model.EnderecoNumero;
            seguradoEquipamento.Estado = model.Estado;
            seguradoEquipamento.Email = model.Email;
            seguradoEquipamento.Telefone = model.Telefone;
            seguradoEquipamento.Celular = model.Celular;
            seguradoEquipamento.Bairro = model.Bairro;

            seguradoEquipamento.DataAtualizacao = DateTime.Now;

            this.dbSet.Update(seguradoEquipamento);
            context.SaveChanges();
        }

        public void UpdatePagamento(SeguradoEquipamentoViewModel model)
        {
            var seguradoEquipamento = GetDataByID(model.SeguradoEquipamentoId);

            seguradoEquipamento.PagamentoTipoId = model.PagamentoTipoId;
            seguradoEquipamento.VezesPagamento = model.VezesPagamento;

            seguradoEquipamento.CertificadoGerado = true;
            seguradoEquipamento.DataAtualizacao = DateTime.Now;

            this.dbSet.Update(seguradoEquipamento);
            context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.SeguradoEquipamento;
        }

        public bool ReferenciaExiste(string referencia)
        {
            if (string.IsNullOrWhiteSpace(referencia)) return false;
            return this.dbSet.Any(x => x.Referencia.ToUpper().Equals(referencia.ToUpper()));
        }

        public int GetByReference(string referencia)
        {
            if (string.IsNullOrWhiteSpace(referencia)) return -1;
            return this.dbSet.Single(x => x.Referencia.ToUpper().Equals(referencia.ToUpper())).SeguradoEquipamentoId;
        }
    }
}
