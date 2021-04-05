using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using GuardMedWeb.Models;
using BLL;
using GuardMedWeb.BLL.SeguradoProfissional;

namespace GuardMedWeb.BLL.SeguradoClinicaVeterinaria
{
    public class SeguradoClinicaVeterinariaFunctions : BLLBasicFunctions<DAL.SeguradoClinicaVeterinaria, Models.SeguradoClinicaVeterinariaViewModel>
    {

        private readonly BLL.SeguradoProfissional.SeguradoProfissionalFunctions seguradoProfissionalFunctions;
        private readonly BLL.SeguradoProfissional.PlanoSeguroProfissionalFunctions planoSeguroProfissionalFunctions;
        private readonly BLL.SeguradoProfissional.SeguroProfissionalPrecoFunctions seguroProfissionalPrecoFunctions;
        private readonly PlanoSeguroClinicaVeterinariaFunctions PlanoSeguroClinicaVeterinariaFunctions;
        private readonly SeguroClinicaVeterinariaPrecoFunctions seguroClinicaVeterinariaPrecoFunctions;
        private readonly CLTFunctions cltFunctions;

        public SeguradoClinicaVeterinariaFunctions(GuardMedWebContext context, SeguradoProfissionalFunctions seguradoProfissionalFunctions)
            : base(context, "SeguradoClinicaVeterinariaId")
        {
            this.seguradoProfissionalFunctions = seguradoProfissionalFunctions;
            this.planoSeguroProfissionalFunctions = new BLL.SeguradoProfissional.PlanoSeguroProfissionalFunctions(context);
            this.seguroProfissionalPrecoFunctions = new BLL.SeguradoProfissional.SeguroProfissionalPrecoFunctions(context);
            this.PlanoSeguroClinicaVeterinariaFunctions = new BLL.SeguradoClinicaVeterinaria.PlanoSeguroClinicaVeterinariaFunctions(context);
            this.seguroClinicaVeterinariaPrecoFunctions = new BLL.SeguradoClinicaVeterinaria.SeguroClinicaVeterinariaPrecoFunctions(context);
            this.cltFunctions = new CLTFunctions(context);
        }

        public bool ReferenciaExiste(string referencia)
        {
            if (string.IsNullOrWhiteSpace(referencia)) return false;
            return this.dbSet.Any(x => x.Referencia.ToUpper().Equals(referencia.ToUpper()));
        }

        public int GetByReference(string referencia)
        {
            if (string.IsNullOrWhiteSpace(referencia)) return -1;
            return this.dbSet.Single(x => x.Referencia.ToUpper().Equals(referencia.ToUpper())).SeguradoClinicaVeterinariaId;
        }

        public override int Create(SeguradoClinicaVeterinariaViewModel model)
        {
            var seguradoClinicaVeterinaria = new DAL.SeguradoClinicaVeterinaria
            {
                RazaoSocial = model.RazaoSocial,
                NomeContato = model.NomeContato,
                Email = model.Email,
                Celular = model.Celular,
                Telefone = model.Telefone,
                DataCriacao = model.DataCriacao,
                Referencia = model.Referencia,
                CertificadoGerado = false
            };

            this.dbSet.Add(seguradoClinicaVeterinaria);
            context.SaveChanges();

            return seguradoClinicaVeterinaria.SeguradoClinicaVeterinariaId;
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<SeguradoClinicaVeterinariaViewModel> GetDataViewModel(IQueryable<DAL.SeguradoClinicaVeterinaria> data)
        {
            var r = (from y in data.ToList()
                     select new SeguradoClinicaVeterinariaViewModel
                     {
                         SeguradoClinicaVeterinariaId = y.SeguradoClinicaVeterinariaId,
                         PlanoClinicaVeterinariaId = y.PlanoClinicaVeterinariaId,
                         PlanoExtensaoCoberturaId = y.PlanoExtensaoCoberturaId,
                         PlanoResponsavelTecnicoId = y.PlanoResponsavelTecnicoId,
                         NomeContato = y.NomeContato,
                         RazaoSocial = y.RazaoSocial,
                         Email = y.Email,
                         Telefone = y.Telefone,
                         CNPJ = y.Cnpj,
                         NomeGerenteFinanceiro = y.NomeGerenteFinanceiro,
                         NomeResponsavelTecnico = y.NomeResponsavelTecnico,
                         CPFTecnico = y.Cpftecnico,
                         CRMVTecnico = y.Crmvtecnico,
                         CRMVEstado = y.Crmvestado,
                         DataNascimentoTecnico = y.DataNascimentoTecnico,
                         Bairro = y.Bairro,
                         CEP = y.Cep,
                         Cidade = y.Cidade,
                         Complemento = y.Complemento,
                         CPF = y.Cpf,
                         Endereco = y.Endereco,
                         EnderecoNumero = y.EnderecoNumero,
                         Estado = y.Estado,
                         QtdFuncionarios = y.QtdFuncionarios,
                         PagamentoTipoId = y.PagamentoTipoId,
                         PrecoTotal = (y.PrecoTotal.HasValue ? y.PrecoTotal.Value.ToString("0.00") : string.Empty),
                         QtdFuncionarios20 = y.QtdFuncionarios20,
                         QtdFuncionarios30 = y.QtdFuncionarios30,
                         QtdFuncionarios40 = y.QtdFuncionarios40,
                         QtdFuncionarios50 = y.QtdFuncionarios50,
                         PlanoClinicaVeterinariaPreco = (y.PlanoClinicaVeterinariaPreco.HasValue ? y.PlanoClinicaVeterinariaPreco.Value.ToString("0.00") : string.Empty),
                         PlanoResponsavelTecnicoPreco = (y.PlanoResponsavelTecnicoPreco.HasValue ? y.PlanoResponsavelTecnicoPreco.Value.ToString("0.00") : string.Empty),
                         PlanoExtensaoCobertura20Preco = (y.PlanoExtensaoCobertura20Preco.HasValue ? y.PlanoExtensaoCobertura20Preco.Value.ToString("0.00") : string.Empty),
                         PlanoExtensaoCobertura30Preco = (y.PlanoExtensaoCobertura30Preco.HasValue ? y.PlanoExtensaoCobertura30Preco.Value.ToString("0.00") : string.Empty),
                         PlanoExtensaoCobertura40Preco = (y.PlanoExtensaoCobertura40Preco.HasValue ? y.PlanoExtensaoCobertura40Preco.Value.ToString("0.00") : string.Empty),
                         PlanoExtensaoCobertura50Preco = (y.PlanoExtensaoCobertura50Preco.HasValue ? y.PlanoExtensaoCobertura50Preco.Value.ToString("0.00") : string.Empty),
                         DataCriacao = y.DataCriacao,
                         DataAtualizacao = y.DataAtualizacao,
                         Referencia = y.Referencia,
                         Celular = y.Celular,
                         CertificadoGerado = y.CertificadoGerado,
                         QtdCLT = y.QtdClt,
                         SeguroVida = y.SeguroVida,
                         CelularResponsavelFinanceiro = y.CelularResponsavelFinanceiro,
                         EmailResponsavelFinanceiro = y.EmailResponsavelFinanceiro,
                         NomeResponsavelFinanceiro = y.NomeResponsavelFinanceiro,
                         TelefoneResponsavelFinanceiro = y.TelefoneResponsavelFinanceiro,
                         TecnicoFumante = y.TecnicoFumante,
                         TecnicoPeso = y.TecnicoPeso,
                         TecnicoAltura = y.TecnicoAltura,
                         TecnicoDoencas = y.TecnicoDoencas,
                         TecnicoDoencasAtuais = y.TecnicoDoencasAtuais,
                         TecnicoMedicamentos = y.TecnicoMedicamentos,
                         Funcionarios = seguradoProfissionalFunctions.GetData().Where(x => x.SeguradoClinicaVeterinariaId == y.SeguradoClinicaVeterinariaId).ToList(),
                         //CLTs = cltFunctions.GetData().Where(x => x.SeguradoClinicaVeterinariaId == y.SeguradoClinicaVeterinariaId).ToList(),
                         IUGU_customer_id = y.IuguCustomerId,
                         IUGU_invoice_id = y.IuguInvoiceId,
                         IUGU_invoice_secure_url = y.IuguInvoiceSecureUrl,
                         IUGU_subscription_id = y.IuguSubscriptionId
                     }).ToList();
            return r;
        }

        public override SeguradoClinicaVeterinariaViewModel GetDataViewModel(DAL.SeguradoClinicaVeterinaria data)
        {
            string PlanoResponsavelTecnicoNome = "", PlanoExtensaoCoberturaNome = "", PlanoClinicaVeterinariaNome = "";
            if (data.PlanoClinicaVeterinariaId.HasValue)
                PlanoClinicaVeterinariaNome = PlanoSeguroClinicaVeterinariaFunctions.GetDataByID(data.PlanoClinicaVeterinariaId).Nome;
            if (data.PlanoResponsavelTecnicoId.HasValue)
                PlanoResponsavelTecnicoNome = planoSeguroProfissionalFunctions.GetDataByID(data.PlanoResponsavelTecnicoId).Nome;
            if (data.PlanoExtensaoCoberturaId.HasValue)
                PlanoExtensaoCoberturaNome = planoSeguroProfissionalFunctions.GetDataByID(data.PlanoExtensaoCoberturaId).Nome;
            var r = new SeguradoClinicaVeterinariaViewModel
            {
                PlanoClinicaVeterinariaNome = PlanoClinicaVeterinariaNome,
                PlanoResponsavelTecnicoNome = PlanoResponsavelTecnicoNome,
                PlanoExtensaoCoberturaNome = PlanoExtensaoCoberturaNome,
                SeguradoClinicaVeterinariaId = data.SeguradoClinicaVeterinariaId,
                PlanoClinicaVeterinariaId = data.PlanoClinicaVeterinariaId,
                PlanoExtensaoCoberturaId = data.PlanoExtensaoCoberturaId,
                PlanoResponsavelTecnicoId = data.PlanoResponsavelTecnicoId,
                NomeContato = data.NomeContato,
                RazaoSocial = data.RazaoSocial,
                Email = data.Email,
                Celular = data.Celular,
                Telefone = data.Telefone,
                CNPJ = data.Cnpj,
                NomeGerenteFinanceiro = data.NomeGerenteFinanceiro,
                NomeResponsavelTecnico = data.NomeResponsavelTecnico,
                CPFTecnico = data.Cpftecnico,
                CRMVTecnico = data.Crmvtecnico,
                CRMVEstado = data.Crmvestado,
                DataNascimentoTecnico = data.DataNascimentoTecnico,
                Bairro = data.Bairro,
                CEP = data.Cep,
                Cidade = data.Cidade,
                Complemento = data.Complemento,
                CPF = data.Cpf,
                Endereco = data.Endereco,
                EnderecoNumero = data.EnderecoNumero,
                Estado = data.Estado,
                QtdFuncionarios = data.QtdFuncionarios,
                PagamentoTipoId = data.PagamentoTipoId,
                PrecoTotal = (data.PrecoTotal.HasValue ? data.PrecoTotal.Value.ToString("0.00") : string.Empty),
                QtdFuncionarios20 = data.QtdFuncionarios20,
                QtdFuncionarios30 = data.QtdFuncionarios30,
                QtdFuncionarios40 = data.QtdFuncionarios40,
                QtdFuncionarios50 = data.QtdFuncionarios50,
                PlanoClinicaVeterinariaPreco = (data.PlanoClinicaVeterinariaPreco.HasValue ? data.PlanoClinicaVeterinariaPreco.Value.ToString("0.00") : string.Empty),
                PlanoResponsavelTecnicoPreco = (data.PlanoResponsavelTecnicoPreco.HasValue ? data.PlanoResponsavelTecnicoPreco.Value.ToString("0.00") : string.Empty),
                PlanoExtensaoCobertura20Preco = (data.PlanoExtensaoCobertura20Preco.HasValue ? data.PlanoExtensaoCobertura20Preco.Value.ToString("0.00") : string.Empty),
                PlanoExtensaoCobertura30Preco = (data.PlanoExtensaoCobertura30Preco.HasValue ? data.PlanoExtensaoCobertura30Preco.Value.ToString("0.00") : string.Empty),
                PlanoExtensaoCobertura40Preco = (data.PlanoExtensaoCobertura40Preco.HasValue ? data.PlanoExtensaoCobertura40Preco.Value.ToString("0.00") : string.Empty),
                PlanoExtensaoCobertura50Preco = (data.PlanoExtensaoCobertura50Preco.HasValue ? data.PlanoExtensaoCobertura50Preco.Value.ToString("0.00") : string.Empty),
                DataCriacao = data.DataCriacao,
                DataAtualizacao = data.DataAtualizacao,
                Referencia = data.Referencia,
                CertificadoGerado = data.CertificadoGerado,
                QtdCLT = data.QtdClt,
                SeguroVida = data.SeguroVida,
                CelularResponsavelFinanceiro = data.CelularResponsavelFinanceiro,
                EmailResponsavelFinanceiro = data.EmailResponsavelFinanceiro,
                NomeResponsavelFinanceiro = data.NomeResponsavelFinanceiro,
                TelefoneResponsavelFinanceiro = data.TelefoneResponsavelFinanceiro,
                TecnicoFumante = data.TecnicoFumante,
                TecnicoPeso = data.TecnicoPeso,
                TecnicoAltura = data.TecnicoAltura,
                TecnicoDoencas = data.TecnicoDoencas,
                TecnicoDoencasAtuais = data.TecnicoDoencasAtuais,
                TecnicoMedicamentos = data.TecnicoMedicamentos,
                Funcionarios = seguradoProfissionalFunctions.GetData().Where(x => x.SeguradoClinicaVeterinariaId == data.SeguradoClinicaVeterinariaId).ToList(),
                //CLTs = cltFunctions.GetData().Where(x => x.SeguradoClinicaVeterinariaId == data.SeguradoClinicaVeterinariaId).ToList(),
                IUGU_customer_id = data.IuguCustomerId,
                IUGU_invoice_id = data.IuguInvoiceId,
                IUGU_invoice_secure_url = data.IuguInvoiceSecureUrl,
                IUGU_subscription_id = data.IuguSubscriptionId
            };
            return r;
        }

        public override void Update(SeguradoClinicaVeterinariaViewModel model)
        {
            throw new NotImplementedException();
        }
        public void UpdateCotacao(SeguradoClinicaVeterinariaViewModel model)
        {
            var seguradoClinicaVeterinaria = GetDataByID(model.SeguradoClinicaVeterinariaId);

            seguradoClinicaVeterinaria.PlanoClinicaVeterinariaId = model.PlanoClinicaVeterinariaId;
            seguradoClinicaVeterinaria.PlanoExtensaoCoberturaId = model.PlanoExtensaoCoberturaId;
            seguradoClinicaVeterinaria.PlanoResponsavelTecnicoId = model.PlanoResponsavelTecnicoId;
            seguradoClinicaVeterinaria.DataNascimentoTecnico = model.DataNascimentoTecnico;
            seguradoClinicaVeterinaria.QtdFuncionarios = model.QtdFuncionarios;
            seguradoClinicaVeterinaria.QtdFuncionarios20 = model.QtdFuncionarios20;
            seguradoClinicaVeterinaria.QtdFuncionarios30 = model.QtdFuncionarios30;
            seguradoClinicaVeterinaria.QtdFuncionarios40 = model.QtdFuncionarios40;
            seguradoClinicaVeterinaria.QtdFuncionarios50 = model.QtdFuncionarios50;
            seguradoClinicaVeterinaria.QtdClt = model.QtdCLT;
            seguradoClinicaVeterinaria.SeguroVida = model.SeguroVida;


            seguradoClinicaVeterinaria.DataAtualizacao = DateTime.Now;

            this.dbSet.Update(seguradoClinicaVeterinaria);
            context.SaveChanges();
        }

        public void UpdateFormulario(SeguradoClinicaVeterinariaViewModel model)
        {
            var seguradoClinicaVeterinaria = GetDataByID(model.SeguradoClinicaVeterinariaId);

            seguradoClinicaVeterinaria.NomeContato = model.NomeContato;
            seguradoClinicaVeterinaria.Cpf = model.CPF;
            seguradoClinicaVeterinaria.RazaoSocial = model.RazaoSocial;
            seguradoClinicaVeterinaria.Cnpj = model.CNPJ;
            seguradoClinicaVeterinaria.Cep = model.CEP;
            seguradoClinicaVeterinaria.Cidade = model.Cidade;
            seguradoClinicaVeterinaria.Complemento = model.Complemento;
            seguradoClinicaVeterinaria.Endereco = model.Endereco;
            seguradoClinicaVeterinaria.EnderecoNumero = model.EnderecoNumero;
            seguradoClinicaVeterinaria.Estado = model.Estado;
            seguradoClinicaVeterinaria.Email = model.Email;
            seguradoClinicaVeterinaria.Telefone = model.Telefone;
            seguradoClinicaVeterinaria.Celular = model.Celular;
            seguradoClinicaVeterinaria.Bairro = model.Bairro;
            seguradoClinicaVeterinaria.NomeGerenteFinanceiro = model.NomeGerenteFinanceiro;
            seguradoClinicaVeterinaria.NomeResponsavelTecnico = model.NomeResponsavelTecnico;
            seguradoClinicaVeterinaria.Cpftecnico = model.CPFTecnico;
            seguradoClinicaVeterinaria.Crmvtecnico = model.CRMVTecnico;
            seguradoClinicaVeterinaria.Crmvestado = model.CRMVEstado;
            seguradoClinicaVeterinaria.DataNascimentoTecnico = model.DataNascimentoTecnico;
            seguradoClinicaVeterinaria.CelularResponsavelFinanceiro = model.CelularResponsavelFinanceiro;
            seguradoClinicaVeterinaria.EmailResponsavelFinanceiro = model.EmailResponsavelFinanceiro;
            seguradoClinicaVeterinaria.NomeResponsavelFinanceiro = model.NomeResponsavelFinanceiro;
            seguradoClinicaVeterinaria.TelefoneResponsavelFinanceiro = model.TelefoneResponsavelFinanceiro;
            seguradoClinicaVeterinaria.TecnicoFumante = model.TecnicoFumante;
            seguradoClinicaVeterinaria.TecnicoPeso = model.TecnicoPeso;
            seguradoClinicaVeterinaria.TecnicoAltura = model.TecnicoAltura;
            seguradoClinicaVeterinaria.TecnicoDoencas = model.TecnicoDoencas;
            seguradoClinicaVeterinaria.TecnicoDoencasAtuais = model.TecnicoDoencasAtuais;
            seguradoClinicaVeterinaria.TecnicoMedicamentos = model.TecnicoMedicamentos;

            seguradoClinicaVeterinaria.DataAtualizacao = DateTime.Now;

            this.dbSet.Update(seguradoClinicaVeterinaria);
            context.SaveChanges();
        }

        public void UpdateConfirmacao(SeguradoClinicaVeterinariaViewModel model)
        {
            var seguradoClinicaVeterinaria = GetDataByID(model.SeguradoClinicaVeterinariaId);

            seguradoClinicaVeterinaria.PagamentoTipoId = model.PagamentoTipoId;
            seguradoClinicaVeterinaria.PrecoTotal = Convert.ToDouble(model.PrecoTotal);
            seguradoClinicaVeterinaria.PlanoClinicaVeterinariaPreco = Convert.ToDouble(model.PlanoClinicaVeterinariaPreco);
            seguradoClinicaVeterinaria.PlanoResponsavelTecnicoPreco = Convert.ToDouble(model.PlanoResponsavelTecnicoPreco);
            seguradoClinicaVeterinaria.PlanoExtensaoCobertura20Preco = Convert.ToDouble(model.PlanoExtensaoCobertura20Preco);
            seguradoClinicaVeterinaria.PlanoExtensaoCobertura30Preco = Convert.ToDouble(model.PlanoExtensaoCobertura30Preco);
            seguradoClinicaVeterinaria.PlanoExtensaoCobertura40Preco = Convert.ToDouble(model.PlanoExtensaoCobertura40Preco);
            seguradoClinicaVeterinaria.PlanoExtensaoCobertura50Preco = Convert.ToDouble(model.PlanoExtensaoCobertura50Preco);
            seguradoClinicaVeterinaria.VezesPagamento = model.VezesPagamento;
            seguradoClinicaVeterinaria.CertificadoGerado = true;

            seguradoClinicaVeterinaria.DataAtualizacao = DateTime.Now;

            this.dbSet.Update(seguradoClinicaVeterinaria);
            context.SaveChanges();
        }

        public Models.SeguradoProfissionalViewModel GetTecnico(int? seguradoClinicaVeterinariaId)
        {
            var segurado = GetDataByID(seguradoClinicaVeterinariaId);

            string planoSeguroProfissionalNome = "";
            if (segurado.PlanoResponsavelTecnicoId.HasValue)
                planoSeguroProfissionalNome = planoSeguroProfissionalFunctions.GetDataByID(segurado.PlanoResponsavelTecnicoId).Nome;

            return new Models.SeguradoProfissionalViewModel()
            {
                Nome = segurado.NomeResponsavelTecnico,
                DataNascimento = segurado.DataNascimentoTecnico,
                Altura = segurado.TecnicoAltura,
                Doencas = segurado.TecnicoDoencas,
                DoencasAtuais = segurado.TecnicoDoencasAtuais,
                Fumante = segurado.TecnicoFumante,
                Medicamentos = segurado.TecnicoMedicamentos,
                Peso = segurado.TecnicoPeso,
                CPF = segurado.Cpftecnico,
                CRM = segurado.Crmvtecnico,
                EstadoCRM = segurado.Crmvestado,
                Telefone = segurado.Telefone,
                Celular = segurado.Celular,
                Email = segurado.Email,
                PlanoSeguroProfissionalId = segurado.PlanoResponsavelTecnicoId,
                PlanoSeguroProfissionalNome = planoSeguroProfissionalNome,
                Idade = new DateTime(DateTime.Now.Subtract(segurado.DataNascimentoTecnico.Value).Ticks).Year - 1
            };
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.SeguradoClinicaVeterinaria;
        }
    }
}
