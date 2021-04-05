using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using GuardMedWeb.Models;
using BLL;
using Microsoft.EntityFrameworkCore;
using GuardMedWeb.BLL.Utils;
using InsurenceDbContext.Models;

namespace GuardMedWeb.BLL.SeguradoProfissional
{

    public class SeguradoProfissionalFunctions : BLLBasicFunctions<DAL.SeguradoProfissional, Models.SeguradoProfissionalViewModel>
    {
        private readonly BLL.SeguradoProfissional.SeguroProfissionalPrecoFunctions seguroProfissionalPrecoFunctions;
        private readonly BLL.SeguradoProfissional.PlanoSeguroProfissionalFunctions planoSeguroProfissionalFunctions;
        private readonly BLL.SeguradoProfissional.EspecialidadeProfissionalFunctions especialidadeProfissionalFunctions;
        private readonly MedicGroupFunctions medicGroupFunctions;
        private readonly InsurenceContext insurenceContext;

        public SeguradoProfissionalFunctions(GuardMedWebContext context, InsurenceContext insurenceContext)
            : base(context, "SeguradoProfissionalId")
        {
            this.seguroProfissionalPrecoFunctions = new BLL.SeguradoProfissional.SeguroProfissionalPrecoFunctions(context);
            this.planoSeguroProfissionalFunctions = new BLL.SeguradoProfissional.PlanoSeguroProfissionalFunctions(context);
            this.especialidadeProfissionalFunctions = new BLL.SeguradoProfissional.EspecialidadeProfissionalFunctions(context);
            this.medicGroupFunctions = new MedicGroupFunctions(context);
            this.insurenceContext = insurenceContext;
        }

        public bool ReferenciaExiste(string referencia)
        {
            if (string.IsNullOrWhiteSpace(referencia)) return false;
            return this.dbSet.Any(x => x.Referencia.ToUpper().Equals(referencia.ToUpper()));
        }
        public int GetByReference(string referencia)
        {
            if (string.IsNullOrWhiteSpace(referencia)) return -1;
            return this.dbSet.Single(x => x.Referencia.ToUpper().Equals(referencia.ToUpper())).SeguradoProfissionalId;
        }
        public override int Create(SeguradoProfissionalViewModel model)
        {
            if (model.GrupoMedico != null)
            {
                var medicGroup = medicGroupFunctions.GetDataByID(model.GrupoMedico);

                if (medicGroup.CompanyOfficeId != null)
                {
                    model.EscritorioId = medicGroup.CompanyOfficeId;
                }

                if (medicGroup.CompanyPlatformId != null)
                {
                    model.PlataformaId = medicGroup.CompanyPlatformId;
                }
            }

            if (model.EscritorioId.HasValue)
            {
                var escritorio = insurenceContext.Company.SingleOrDefault(x => x.CompanyId == model.EscritorioId);
                model.EscritorioComissao = escritorio?.Comissao;
            }
            if (model.PlataformaId.HasValue)
            {
                var plataforma = insurenceContext.Company.SingleOrDefault(x => x.CompanyId == model.PlataformaId);
                model.PlataformaComissao = plataforma?.Comissao;
            }

            var seguradoProfissional = new DAL.SeguradoProfissional
            {
                Nome = model.Nome,
                Email = model.Email,
                Telefone = model.Telefone,
                Celular = model.Celular,
                DataNascimento = model.DataNascimento.Value,
                Idade = model.Idade.Value,
                Conveniado = model.Conveniado.Value,
                Crm = model.CRM,
                EstadoCrm = model.EstadoCRM,
                DataCriacao = DateTime.Now,
                CertificadoGerado = false,
                Referencia = model.Referencia,
                ConsultorGuardMed = model.ConsultorGuardMed,
                EscritorioId = model.EscritorioId,
                PlataformaId = model.PlataformaId,
                DescontoPlataforma = model.DescontoPlataforma,
                EscritorioComissao = model.EscritorioComissao,
                PlataformaComissao = model.PlataformaComissao
            };

            this.dbSet.Add(seguradoProfissional);
            context.SaveChanges();

            return seguradoProfissional.SeguradoProfissionalId;
        }
        public int CreateFromClinica(SeguradoProfissionalViewModel model)
        {
            var seguradoProfissional = new DAL.SeguradoProfissional
            {
                Nome = model.Nome,
                Email = model.Email,
                Telefone = model.Telefone,
                Celular = model.Celular,
                DataNascimento = model.DataNascimento.Value,
                Idade = model.Idade.Value,
                Conveniado = model.Conveniado.Value,
                Crm = model.CRM,
                EstadoCrm = model.EstadoCRM,
                DataCriacao = DateTime.Now,
                CertificadoGerado = false,
                Referencia = model.Referencia,
                Bairro = model.Bairro,
                Altura = model.Altura,
                Cep = model.CEP,
                Cidade = model.Cidade,
                Complemento = model.Complemento,
                Cpf = model.CPF,
                Doencas = model.Doencas,
                DoencasAtuais = model.DoencasAtuais,
                Endereco = model.Endereco,
                EnderecoNumero = model.EnderecoNumero,
                Estado = model.Estado,
                Fumante = model.Fumante,
                Medicamentos = model.Medicamentos,
                SeguradoClinicaVeterinariaId = model.SeguradoClinicaVeterinariaId,
                PlanoSeguroProfissionalId = model.PlanoSeguroProfissionalId,
                Peso = model.Peso
            };

            this.dbSet.Add(seguradoProfissional);
            context.SaveChanges();

            return seguradoProfissional.SeguradoProfissionalId;
        }
        public override void Delete(object id)
        {
            var seguradoProfissional = GetDataByID(id);

            this.dbSet.Remove(seguradoProfissional);

            context.SaveChanges();
        }
        public override List<SeguradoProfissionalViewModel> GetDataViewModel(IQueryable<DAL.SeguradoProfissional> data)
        {

            var r = (from y in data.ToList()
                     join __psp in context.PlanoSeguroProfissional on y.PlanoSeguroProfissionalId equals __psp.PlanoSeguroProfissionalId into _psp
                     from psp in _psp.DefaultIfEmpty()
                     select new SeguradoProfissionalViewModel
                     {
                         PlanoSeguroProfissionalId = psp == null ? null : y.PlanoSeguroProfissionalId,
                         PlanoSeguroProfissionalExternalCode = psp == null ? null : psp.ExternalCode,
                         Nome = y.Nome,
                         Email = y.Email,
                         Telefone = y.Telefone,
                         Celular = y.Celular,
                         DataNascimento = y.DataNascimento,
                         CRM = y.Crm,
                         EstadoCRM = y.EstadoCrm,
                         SeguradoProfissionalId = y.SeguradoProfissionalId,
                         Altura = y.Altura,
                         Bairro = y.Bairro,
                         CEP = y.Cep,
                         Cidade = y.Cidade,
                         Complemento = y.Complemento,
                         Conveniado = y.Conveniado,
                         CPF = y.Cpf,
                         Endereco = y.Endereco,
                         EnderecoNumero = y.EnderecoNumero,
                         Estado = y.Estado,
                         Fumante = y.Fumante,
                         Idade = y.Idade,
                         Peso = y.Peso,
                         PrecoTotal = y.PrecoTotal,
                         Doencas = y.Doencas,
                         DoencasAtuais = y.DoencasAtuais,
                         Medicamentos = y.Medicamentos,
                         DataCriacao = y.DataCriacao,
                         DataAtualizacao = y.DataAtualizacao,
                         VezesPagamento = y.VezesPagamento,
                         PagamentoTipoId = y.PagamentoTipoId,
                         CertificadoGerado = y.CertificadoGerado,
                         IUGU_invoice_secure_url = y.IuguInvoiceSecureUrl,
                         Referencia = y.Referencia,
                         IsLocked = y.IsLocked,
                         LockedToken = y.LockedToken,
                         SeguradoClinicaVeterinariaId = y.SeguradoClinicaVeterinariaId,
                         ProtecaoRenda = y.ProtecaoRenda,
                         ConsultorGuardMed = y.ConsultorGuardMed,
                         AcceptTerm = y.AcceptTerm,
                         EspecialidadeProfissional = especialidadeProfissionalFunctions.GetData().Where(x => x.SeguradoProfissionalId == y.SeguradoProfissionalId).ToList(),
                         DiretorChefeEquipe = y.DiretorChefeEquipe,
                         CoberturaAdicionalDiretorChefeEquipe = y.CoberturaAdicionalDiretorChefeEquipe,
                         SocioEmpresaAreaMedica = y.SocioEmpresaAreaMedica,
                         CoberturaAdicionalSocioEmpresaAreaMedica = y.CoberturaAdicionalSocioEmpresaAreaMedica,
                         GrupoMedico = y.GrupoMedico,
                         Especialidade1 = y.Especialidade1,
                         Especialidade2 = y.Especialidade2,
                         Especialidade3 = y.Especialidade3,
                         PlataformaId = y.PlataformaId,
                         EscritorioId = y.EscritorioId,
                         DataRetroatividade = y.DataRetroatividade,
                         DataVencimentoSeguro = y.DataVencimentoSeguro,
                         HistoricoSeguro = y.HistoricoSeguro,
                         RetroatividadeFileName = y.RetroatividadeFileName,
                         DescontoPlataforma = y.DescontoPlataforma,
                         DataCompra = y.DataCompra,
                         RenovadoPor = y.RenovadoPor,
                         RenovacaoPagamentoBloqueado = y.RenovacaoPagamentoBloqueado,
                         EmProcessoDeRenovacao = y.EmProcessoDeRenovacao,
                         DescontoGrupoMedico = y.DescontoGrupoMedico,
                         PlataformaComissao = y.PlataformaComissao,
                         EscritorioComissao = y.EscritorioComissao,
                         EspecialidadePrecoId = y.EspecialidadePrecoId,
                         EspecialidadePrecoMensal = y.EspecialidadePrecoMensal,
                         EspecialidadePrecoAdmMensal = y.EspecialidadePrecoAdmMensal,
                         EspecialidadePremioTotalMensal = y.EspecialidadePremioTotalMensal,
                         EspecialidadePrecoAnual = y.EspecialidadePrecoAnual,
                         EspecialidadePrecoAdmAnual = y.EspecialidadePrecoAdmAnual,
                         EspecialidadePremioTotalAnual = y.EspecialidadePremioTotalAnual,
                         MedicGroupRevenuesFormId = y.MedicGroupRevenuesFormId,
                         MedicGroupCompanyPlatformId = y.MedicGroupCompanyPlatformId,
                         MedicGroupPlatformAgency = y.MedicGroupPlatformAgency,
                         MedicGroupPlatformLife = y.MedicGroupPlatformLife,
                         MedicGroupPlatformComission = y.MedicGroupPlatformComission,
                         MedicGroupCompanyOfficeId = y.MedicGroupCompanyOfficeId,
                         MedicGroupOfficeAgency = y.MedicGroupOfficeAgency,
                         MedicGroupOfficeLife = y.MedicGroupOfficeLife,
                         MedicGroupOfficeComission = y.MedicGroupOfficeComission,
                         NumeroDaApolice = y.NumeroDaApolice,
                         DataDaApolice = y.DataDaApolice,
                         UsuarioApolice = y.UsuarioApolice
                     }).ToList();
            return r;
        }
        public override SeguradoProfissionalViewModel GetDataViewModel(DAL.SeguradoProfissional data)
        {
            PlanoSeguroProfissional planoSeguroProfissional = data.PlanoSeguroProfissionalId.HasValue ? planoSeguroProfissionalFunctions.GetDataByID(data.PlanoSeguroProfissionalId) : null;

            if (data.GrupoMedico.HasValue)
            {
                var medicGroup = medicGroupFunctions.GetDataByID(data.GrupoMedico);
                data.EscritorioId = medicGroup.CompanyOfficeId;
                data.PlataformaId = medicGroup.CompanyPlatformId;
            }

            return new SeguradoProfissionalViewModel
            {
                PlanoSeguroProfissionalId = data.PlanoSeguroProfissionalId,
                PlanoSeguroProfissionalExternalCode = planoSeguroProfissional?.ExternalCode,
                PlanoSeguroProfissionalNome = planoSeguroProfissional?.Nome,
                Nome = data.Nome,
                Email = data.Email,
                Telefone = data.Telefone,
                Celular = data.Celular,
                DataNascimento = data.DataNascimento,
                CRM = data.Crm,
                EstadoCRM = data.EstadoCrm,
                SeguradoProfissionalId = data.SeguradoProfissionalId,
                Altura = data.Altura,
                Bairro = data.Bairro,
                CEP = data.Cep,
                Cidade = data.Cidade,
                Complemento = data.Complemento,
                Conveniado = data.Conveniado,
                CPF = data.Cpf,
                Endereco = data.Endereco,
                EnderecoNumero = data.EnderecoNumero,
                Estado = data.Estado,
                Fumante = data.Fumante,
                Idade = data.Idade,
                Peso = data.Peso,
                PrecoTotal = data.PrecoTotal,
                Doencas = data.Doencas,
                DoencasAtuais = data.DoencasAtuais,
                Medicamentos = data.Medicamentos,
                DataCriacao = data.DataCriacao,
                DataAtualizacao = data.DataAtualizacao,
                VezesPagamento = data.VezesPagamento,
                PagamentoTipoId = data.PagamentoTipoId,
                CertificadoGerado = data.CertificadoGerado,
                IUGU_invoice_secure_url = data.IuguInvoiceSecureUrl,
                Referencia = data.Referencia,
                IsLocked = data.IsLocked,
                LockedToken = data.LockedToken,
                SeguradoClinicaVeterinariaId = data.SeguradoClinicaVeterinariaId,
                ProtecaoRenda = data.ProtecaoRenda,
                ConsultorGuardMed = data.ConsultorGuardMed,
                AcceptTerm = data.AcceptTerm,
                EspecialidadeProfissional = especialidadeProfissionalFunctions.GetData().Where(x => x.SeguradoProfissionalId == data.SeguradoProfissionalId).ToList(),
                DiretorChefeEquipe = data.DiretorChefeEquipe,
                CoberturaAdicionalDiretorChefeEquipe = data.CoberturaAdicionalDiretorChefeEquipe,
                SocioEmpresaAreaMedica = data.SocioEmpresaAreaMedica,
                CoberturaAdicionalSocioEmpresaAreaMedica = data.CoberturaAdicionalSocioEmpresaAreaMedica,
                GrupoMedico = data.GrupoMedico,
                Especialidade1 = data.Especialidade1,
                Especialidade2 = data.Especialidade2,
                Especialidade3 = data.Especialidade3,
                PlataformaId = data.PlataformaId,
                EscritorioId = data.EscritorioId,
                DataRetroatividade = data.DataRetroatividade,
                DataVencimentoSeguro = data.DataVencimentoSeguro,
                HistoricoSeguro = data.HistoricoSeguro,
                RetroatividadeFileName = data.RetroatividadeFileName,
                DescontoPlataforma = data.DescontoPlataforma,
                DataCompra = data.DataCompra,
                RenovadoPor = data.RenovadoPor,
                RenovacaoPagamentoBloqueado = data.RenovacaoPagamentoBloqueado,
                EmProcessoDeRenovacao = data.EmProcessoDeRenovacao,
                DescontoGrupoMedico = data.DescontoGrupoMedico,
                PlataformaComissao = data.PlataformaComissao,
                EscritorioComissao = data.EscritorioComissao,
                EspecialidadePrecoId = data.EspecialidadePrecoId,
                EspecialidadePrecoMensal = data.EspecialidadePrecoMensal,
                EspecialidadePrecoAdmMensal = data.EspecialidadePrecoAdmMensal,
                EspecialidadePremioTotalMensal = data.EspecialidadePremioTotalMensal,
                EspecialidadePrecoAnual = data.EspecialidadePrecoAnual,
                EspecialidadePrecoAdmAnual = data.EspecialidadePrecoAdmAnual,
                EspecialidadePremioTotalAnual = data.EspecialidadePremioTotalAnual,
                MedicGroupRevenuesFormId = data.MedicGroupRevenuesFormId,
                MedicGroupCompanyPlatformId = data.MedicGroupCompanyPlatformId,
                MedicGroupPlatformAgency = data.MedicGroupPlatformAgency,
                MedicGroupPlatformLife = data.MedicGroupPlatformLife,
                MedicGroupPlatformComission = data.MedicGroupPlatformComission,
                MedicGroupCompanyOfficeId = data.MedicGroupCompanyOfficeId,
                MedicGroupOfficeAgency = data.MedicGroupOfficeAgency,
                MedicGroupOfficeLife = data.MedicGroupOfficeLife,
                MedicGroupOfficeComission = data.MedicGroupOfficeComission,
                NumeroDaApolice = data.NumeroDaApolice,
                DataDaApolice = data.DataDaApolice,
                UsuarioApolice = data.UsuarioApolice
            };
        }
        public override void Update(SeguradoProfissionalViewModel model)
        {
            var seguradoProfissional = GetDataByID(model.SeguradoProfissionalId);

            var medicGroup = medicGroupFunctions.GetDataByID(model.GrupoMedico);

            if (medicGroup.CompanyOfficeId != null)
            {
                model.EscritorioId = medicGroup.CompanyOfficeId;
            }

            if (medicGroup.CompanyPlatformId != null)
            {
                model.PlataformaId = medicGroup.CompanyPlatformId;
            }

            seguradoProfissional.Idade = model.Idade.Value;
            seguradoProfissional.Nome = model.Nome;
            seguradoProfissional.Cpf = model.CPF;
            seguradoProfissional.Crm = model.CRM;
            seguradoProfissional.EstadoCrm = model.EstadoCRM;
            seguradoProfissional.Cep = model.CEP;
            seguradoProfissional.Cidade = model.Cidade;
            seguradoProfissional.Complemento = model.Complemento;
            seguradoProfissional.Conveniado = model.Conveniado;
            seguradoProfissional.Endereco = model.Endereco;
            seguradoProfissional.EnderecoNumero = model.EnderecoNumero;
            seguradoProfissional.Estado = model.Estado;
            seguradoProfissional.DataNascimento = model.DataNascimento.Value;
            seguradoProfissional.Email = model.Email;
            seguradoProfissional.Telefone = model.Telefone;
            seguradoProfissional.Altura = model.Altura;
            seguradoProfissional.Bairro = model.Bairro;
            seguradoProfissional.Fumante = model.Fumante;
            seguradoProfissional.Peso = model.Peso;
            seguradoProfissional.IsLocked = model.IsLocked;
            seguradoProfissional.Celular = model.Celular;
            seguradoProfissional.Doencas = model.Doencas;
            seguradoProfissional.DoencasAtuais = model.DoencasAtuais;
            seguradoProfissional.Medicamentos = model.Medicamentos;
            seguradoProfissional.SeguradoClinicaVeterinariaId = model.SeguradoClinicaVeterinariaId;
            seguradoProfissional.PlanoSeguroProfissionalId = model.PlanoSeguroProfissionalId;
            seguradoProfissional.EscritorioId = model.EscritorioId;
            seguradoProfissional.PlataformaId = model.PlataformaId;

            seguradoProfissional.DataAtualizacao = DateTime.Now;

            this.dbSet.Update(seguradoProfissional);
            context.SaveChanges();
        }
        public void UpdateCotacao(SeguradoProfissionalViewModel model)
        {
            var seguradoProfissional = GetDataByID(model.SeguradoProfissionalId);

            seguradoProfissional.PlanoSeguroProfissionalId = model.PlanoSeguroProfissionalId.Value;
            seguradoProfissional.ProtecaoRenda = model.ProtecaoRenda.Value;

            seguradoProfissional.DataAtualizacao = DateTime.Now;

            this.dbSet.Update(seguradoProfissional);
            context.SaveChanges();
        }
        public void UpdateCoberturasAdicionais(int seguradoProfissionalId, bool diretorChefeEquipe, bool? coberturaAdicionalDiretorChefeEquipe, bool socioEmpresaAreaMedica, bool? coberturaAdicionalSocioEmpresaAreaMedica)
        {
            var seguradoProfissional = GetDataByID(seguradoProfissionalId);
            seguradoProfissional.DiretorChefeEquipe = diretorChefeEquipe;
            seguradoProfissional.CoberturaAdicionalDiretorChefeEquipe = diretorChefeEquipe == false ? null : coberturaAdicionalDiretorChefeEquipe;

            seguradoProfissional.SocioEmpresaAreaMedica = socioEmpresaAreaMedica;
            seguradoProfissional.CoberturaAdicionalSocioEmpresaAreaMedica = socioEmpresaAreaMedica == false ? null : coberturaAdicionalSocioEmpresaAreaMedica;
            seguradoProfissional.DataAtualizacao = DateTime.Now;
            this.dbSet.Update(seguradoProfissional);
            context.SaveChanges();
        }
        public void UpdateFormulario(SeguradoProfissionalViewModel model)
        {
            var seguradoProfissional = GetDataByID(model.SeguradoProfissionalId);

            seguradoProfissional.Nome = model.Nome;
            seguradoProfissional.Cpf = model.CPF;
            //seguradoProfissional.CRM = model.CRM;
            //seguradoProfissional.EstadoCRMV = model.EstadoCRMV;
            seguradoProfissional.Cep = model.CEP;
            seguradoProfissional.Cidade = model.Cidade;
            seguradoProfissional.Complemento = model.Complemento;
            seguradoProfissional.Endereco = model.Endereco;
            seguradoProfissional.EnderecoNumero = model.EnderecoNumero;
            seguradoProfissional.Estado = model.Estado;
            //seguradoProfissional.Idade = model.Idade.Value;
            //seguradoProfissional.DataNascimento = model.DataNascimento.Value;
            seguradoProfissional.Email = model.Email;
            seguradoProfissional.Telefone = model.Telefone;
            seguradoProfissional.Bairro = model.Bairro;

            seguradoProfissional.Fumante = model.Fumante;
            seguradoProfissional.Peso = model.Peso;
            seguradoProfissional.Altura = model.Altura;
            seguradoProfissional.Doencas = model.Doencas;
            seguradoProfissional.DoencasAtuais = model.DoencasAtuais;
            seguradoProfissional.Medicamentos = model.Medicamentos;
            seguradoProfissional.AcceptTerm = model.AcceptTerm;

            //HISTORICO SEGURO e DATAS
            seguradoProfissional.DataRetroatividade = model.DataRetroatividade;
            seguradoProfissional.DataVencimentoSeguro = model.DataVencimentoSeguro;
            seguradoProfissional.HistoricoSeguro = model.HistoricoSeguro;
            if (!string.IsNullOrWhiteSpace(model.RetroatividadeFileName))
            {
                seguradoProfissional.RetroatividadeFileName = model.RetroatividadeFileName;
                seguradoProfissional.RetroatividadeFilePath = model.RetroatividadeFilePath;
            }
            seguradoProfissional.DataAtualizacao = DateTime.Now;

            this.dbSet.Update(seguradoProfissional);
            context.SaveChanges();
        }
        public void UpdatePagamento(int seguradoProfissionalId, int pagamentoTipoId, int vezesPagamento, double precoTotal, EspecialidadePreco especialidadePreco)
        {
            var seguradoProfissional = GetDataByID(seguradoProfissionalId);

            seguradoProfissional.PagamentoTipoId = pagamentoTipoId;
            seguradoProfissional.VezesPagamento = vezesPagamento;
            seguradoProfissional.PrecoTotal = precoTotal;
            seguradoProfissional.CertificadoGerado = true;

            seguradoProfissional.EspecialidadePrecoId = especialidadePreco.EspecialidadePrecoId;
            seguradoProfissional.EspecialidadePrecoMensal = especialidadePreco.PrecoMensal;
            seguradoProfissional.EspecialidadePrecoAdmMensal = especialidadePreco.PrecoAdmMensal;
            seguradoProfissional.EspecialidadePremioTotalMensal = especialidadePreco.PremioTotalMensal;
            seguradoProfissional.EspecialidadePrecoAnual = especialidadePreco.PrecoAnual;
            seguradoProfissional.EspecialidadePrecoAdmAnual = especialidadePreco.PrecoAdmAnual;
            seguradoProfissional.EspecialidadePremioTotalAnual = especialidadePreco.PremioTotalAnual;

            seguradoProfissional.DataCompra = DateTime.Now;
            seguradoProfissional.DataAtualizacao = DateTime.Now;

            this.dbSet.Update(seguradoProfissional);
            context.SaveChanges();
        }
        public Guid? SetIsLocked(string reference, bool isLocked)
        {
            if (string.IsNullOrWhiteSpace(reference)) return null;
            if (!ReferenciaExiste(reference)) return null;

            var segurado = this.dbSet.Single(x => x.Referencia.ToUpper().Equals(reference.ToUpper()));

            segurado.IsLocked = isLocked;

            if (isLocked && !segurado.LockedToken.HasValue)
                segurado.LockedToken = Guid.NewGuid();

            this.dbSet.Update(segurado);
            context.SaveChanges();

            return segurado.LockedToken;
        }
        protected override void SetDbSet()
        {
            this.dbSet = context.SeguradoProfissional;
        }
        public void UpdateEspecialidades(int seguradoProfissionalId, List<Models.EspecialidadeProfissionalViewModel> especialidades)
        {
            var seguradoProfissional = GetDataByID(seguradoProfissionalId);
            if (especialidades.Count == 1)
                seguradoProfissional.Especialidade1 = especialidades[0].EspecialidadeId;
            else if (especialidades.Count == 2)
            {
                seguradoProfissional.Especialidade1 = especialidades[0].EspecialidadeId;
                seguradoProfissional.Especialidade2 = especialidades[1].EspecialidadeId;
            }
            else if (especialidades.Count == 3)
            {
                seguradoProfissional.Especialidade1 = especialidades[0].EspecialidadeId;
                seguradoProfissional.Especialidade2 = especialidades[1].EspecialidadeId;
                seguradoProfissional.Especialidade3 = especialidades[2].EspecialidadeId;
            }
            this.dbSet.Update(seguradoProfissional);
            context.SaveChanges();
        }
        public int? UpdateGrupoMedico(int seguradoProfissionalId, List<DAL.MedicGroup> grupomedico)
        {
            var seguradoProfissional = GetDataByID(seguradoProfissionalId);
            if (grupomedico != null && grupomedico.Count > 0)
            {
                seguradoProfissional.GrupoMedico = grupomedico[0].MedicGroupId;
                seguradoProfissional.MedicGroupCompanyOfficeId = grupomedico[0].CompanyOfficeId;
                seguradoProfissional.MedicGroupCompanyPlatformId = grupomedico[0].CompanyPlatformId;
                seguradoProfissional.MedicGroupOfficeAgency = grupomedico[0].OfficeAgency;
                seguradoProfissional.MedicGroupOfficeComission = grupomedico[0].OfficeComission;
                seguradoProfissional.MedicGroupOfficeLife = grupomedico[0].OfficeLife;
                seguradoProfissional.MedicGroupPlatformAgency = grupomedico[0].PlatformAgency;
                seguradoProfissional.MedicGroupPlatformComission = grupomedico[0].PlatformComission;
                seguradoProfissional.MedicGroupPlatformLife = grupomedico[0].PlatformLife;
                seguradoProfissional.MedicGroupRevenuesFormId = grupomedico[0].RevenuesFormId;
            }

            this.dbSet.Update(seguradoProfissional);
            context.SaveChanges();

            return seguradoProfissional.GrupoMedico;
        }
        public async Task<string> GetAndGenerateNewPassword(int seguradoProfissionalId)
        {
            var entity = await this.dbSet.SingleAsync(x => x.SeguradoProfissionalId == seguradoProfissionalId);

            var password = Utils.Utils.GetReference();
            entity.Senha = password;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();

            return await Task.Run(() => password);
        }
        public async Task<DAL.SeguradoProfissional> GetDataByRenewedBy(int seguradoProfissionalId) => await this.dbSet.FirstOrDefaultAsync(x => x.RenovadoPor == seguradoProfissionalId && !x.IsDeleted);
        public async Task<bool> CanRenew(int seguradoProfissionalId)
        {
            var seguradoAnterior = await this.dbSet.SingleAsync(x => x.SeguradoProfissionalId == seguradoProfissionalId);

            seguradoAnterior.DataCompra.Value.GetVigencyDate(out DateTime seguradoAnteriorInicioVigencia, out DateTime seguradoAnteriorFimVigencia);

            return seguradoAnteriorFimVigencia < DateTime.Today;
        }
        public async Task<DAL.SeguradoProfissional> CreateForRenew(int seguradoProfissionalId)
        {
            var seguradoProfissional = GetDataByID(seguradoProfissionalId);
            var firstSeguradoProfissional = GetFirstInsuranceOfInsured(seguradoProfissionalId);

            var novoSeguradoProfissional = seguradoProfissional.CopyToEntity<DAL.SeguradoProfissional>();

            novoSeguradoProfissional.SeguradoProfissionalId = 0;
            novoSeguradoProfissional.PagamentoTipoId = null;
            novoSeguradoProfissional.VezesPagamento = null;
            novoSeguradoProfissional.PrecoTotal = null;
            novoSeguradoProfissional.CertificadoGerado = false;
            novoSeguradoProfissional.IuguSubscriptionId = null;
            novoSeguradoProfissional.IuguInvoiceId = null;
            novoSeguradoProfissional.IuguInvoiceSecureUrl = null;
            novoSeguradoProfissional.IsLocked = null;
            novoSeguradoProfissional.LockedToken = null;
            novoSeguradoProfissional.DataCompra = null;
            novoSeguradoProfissional.GrupoMedico = null;
            novoSeguradoProfissional.HistoricoSeguro = false;
            novoSeguradoProfissional.DataVencimentoSeguro = null;
            novoSeguradoProfissional.DataRetroatividade = null;
            novoSeguradoProfissional.RetroatividadeFileName = null;
            novoSeguradoProfissional.RetroatividadeFilePath = null;


            novoSeguradoProfissional.EmProcessoDeRenovacao = true;
            novoSeguradoProfissional.RenovadoPor = seguradoProfissionalId;
            novoSeguradoProfissional.DataCriacao = DateTime.Now;
            novoSeguradoProfissional.Idade = new DateTime(DateTime.Now.Subtract(novoSeguradoProfissional.DataNascimento).Ticks).Year - 1;

            novoSeguradoProfissional.HistoricoSeguro = true;
            novoSeguradoProfissional.DataRetroatividade = firstSeguradoProfissional.DataRetroatividade ?? new DateTime(firstSeguradoProfissional.DataCompra.Value.Year, firstSeguradoProfissional.DataCompra.Value.Month, 1);
            novoSeguradoProfissional.DataVencimentoSeguro = new DateTime(seguradoProfissional.DataCompra.Value.Year, seguradoProfissional.DataCompra.Value.Month, 1).AddYears(1);

            do
            {
                novoSeguradoProfissional.Referencia = BLL.Utils.Utils.GetReference();
            } while (ReferenciaExiste(novoSeguradoProfissional.Referencia));

            await this.dbSet.AddAsync(novoSeguradoProfissional);
            await this.context.SaveChangesAsync();

            return novoSeguradoProfissional;
        }
        public DAL.SeguradoProfissional GetFirstInsuranceOfInsured(int seguradoProfissionalId)
        {
            DAL.SeguradoProfissional insurance = GetDataByID(seguradoProfissionalId);
            while (insurance.RenovadoPor.HasValue)
                insurance = GetDataByID(insurance.RenovadoPor);

            return insurance;
        }
        public async Task UpdateIndexRenew(SeguradoProfissionalViewModel model)
        {
            var insurance = GetDataByID(model.SeguradoProfissionalId);

            insurance.Nome = model.Nome;
            insurance.Celular = model.Celular;
            insurance.Telefone = model.Telefone;
            insurance.Email = model.Email;
            insurance.DataNascimento = model.DataNascimento.Value;
            insurance.DataAtualizacao = DateTime.Now;

            this.dbSet.Update(insurance);
            await this.context.SaveChangesAsync();
        }
        public async Task UpdateDiscount(int seguradoProfissionalId, int? discount)
        {
            var insurance = GetDataByID(seguradoProfissionalId);

            insurance.DescontoPlataforma = discount;
            insurance.DataAtualizacao = DateTime.Now;

            this.dbSet.Update(insurance);
            await this.context.SaveChangesAsync();
        }
        public async Task UpdateMedicGroupDiscount(int seguradoProfissionalId, double? discount)
        {
            var insurance = GetDataByID(seguradoProfissionalId);

            insurance.DescontoGrupoMedico = discount;
            insurance.DataAtualizacao = DateTime.Now;

            this.dbSet.Update(insurance);
            await this.context.SaveChangesAsync();
        }
        public void UpdateDetailRenew(SeguradoProfissionalViewModel model)
        {
            var seguradoProfissional = GetDataByID(model.SeguradoProfissionalId);

            seguradoProfissional.Nome = model.Nome;
            seguradoProfissional.Cpf = model.CPF;
            seguradoProfissional.Cep = model.CEP;
            seguradoProfissional.Cidade = model.Cidade;
            seguradoProfissional.Complemento = model.Complemento;
            seguradoProfissional.Endereco = model.Endereco;
            seguradoProfissional.EnderecoNumero = model.EnderecoNumero;
            seguradoProfissional.Estado = model.Estado;
            seguradoProfissional.Email = model.Email;
            seguradoProfissional.Telefone = model.Telefone;
            seguradoProfissional.Bairro = model.Bairro;

            seguradoProfissional.DataAtualizacao = DateTime.Now;

            this.dbSet.Update(seguradoProfissional);
            context.SaveChanges();
        }
        public async Task<int> ObterGrupo(int seguradoProfissionalId)
        {
            var especialidades = this.context.EspecialidadeProfissional.Where(x => x.SeguradoProfissionalId == seguradoProfissionalId);

            return await especialidades.Select(x => context.Especialidade.Single(c => c.EspecialidadeId == x.EspecialidadeId)).MaxAsync(x => x.Grupo);
        }
        public async Task<EspecialidadePrecoViewModel> ObterPreco(int seguradoProfissionalId, int planoSeguroProfissionalId)
        {
            var grupo = await ObterGrupo(seguradoProfissionalId);

            return (await this.context.EspecialidadePreco.SingleAsync(x => x.Grupo == grupo && x.PlanoSeguroProfissionalId == planoSeguroProfissionalId)).CopyToEntity<EspecialidadePrecoViewModel>();
        }
        public async Task BlockPayment(int seguradoProfissionalId)
        {
            var insurance = await this.dbSet.SingleAsync(x => x.SeguradoProfissionalId == seguradoProfissionalId);

            insurance.RenovacaoPagamentoBloqueado = true;
            insurance.PagamentoTipoId = 2;

            this.dbSet.Update(insurance);

            await this.context.SaveChangesAsync();
        }
        public async Task ByPassPayment(int seguradoProfissionalId)
        {
            var seguradoProfissional = await this.dbSet.SingleAsync(x => x.SeguradoProfissionalId == seguradoProfissionalId);

            seguradoProfissional.ByPassPayment = true;

            this.dbSet.Update(seguradoProfissional);
            await this.context.SaveChangesAsync();
        }
        public async Task<bool> HasSubscription(int seguradoProfissionalId) => await this.dbSet.AnyAsync(x => x.SeguradoProfissionalId == seguradoProfissionalId && !string.IsNullOrWhiteSpace(x.IuguSubscriptionId));
        public async Task<string> GetSubscription(int seguradoProfissionalId) => (await this.dbSet.SingleAsync(x => x.SeguradoProfissionalId == seguradoProfissionalId)).IuguSubscriptionId;
        public async Task FinishRenew(int seguradoProfissionalId)
        {
            var insurance = await this.dbSet.SingleAsync(x => x.SeguradoProfissionalId == seguradoProfissionalId);
            var insuranceRenewed = await this.dbSet.SingleAsync(x => x.SeguradoProfissionalId == insurance.RenovadoPor);

            insurance.EmProcessoDeRenovacao = false;
            insurance.RenovacaoPagamentoBloqueado = false;

            var date = new DateTime(insuranceRenewed.DataCompra.Value.Year, insuranceRenewed.DataCompra.Value.Month, 1).AddMonths(12);
            insurance.DataCompra = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
            insurance.DataAtualizacao = DateTime.Now;

            this.dbSet.Update(insurance);

            await this.context.SaveChangesAsync();
        }
        public double ObterDesconto(int seguradoProfissionalId)
        {
            var entity = GetDataByID(seguradoProfissionalId);

            var medicGroup = medicGroupFunctions.GetMedicGroupByInsurance(seguradoProfissionalId);

            if (entity.DescontoPlataforma.HasValue) return (100d - (double)entity.DescontoPlataforma) / 100d;

            return entity.DescontoGrupoMedico.HasValue ? ((100d - entity.DescontoGrupoMedico.Value) / 100d) : (medicGroup != null ? (100d - medicGroup.Discount) / 100d : 1d);
        }
        public double? ObterNumeroDoDesconto(int seguradoProfissionalId)
        {
            var entity = GetDataByID(seguradoProfissionalId);

            var medicGroup = medicGroupFunctions.GetMedicGroupByInsurance(seguradoProfissionalId);

            if (entity.DescontoPlataforma.HasValue) return (double)entity.DescontoPlataforma;

            return entity.DescontoGrupoMedico.HasValue ? entity.DescontoGrupoMedico : (medicGroup != null ? medicGroup.Discount : (double?)null);
        }
        public async Task<List<CotacaoViewModel>> ObterCotacoes(int seguradoProfissionalId)
        {
            var seguradoProfissional = GetDataByID(seguradoProfissionalId);
            int grupo = await ObterGrupo(seguradoProfissionalId);

            double percentualDescontoGrupoMedico = 0;
            var medicGroups = medicGroupFunctions.GetMedicGroupsByCRM(seguradoProfissional.Crm, seguradoProfissional.EstadoCrm);
            if (medicGroups != null && medicGroups.Count > 0)
            {
                var medicGroup = medicGroupFunctions.GetDataViewModel(medicGroups.OrderByDescending(x => x.Discount).First());
                percentualDescontoGrupoMedico = medicGroup.DiscountNumber;
            }

            var q = await (from psp in context.PlanoSeguroProfissional
                           join ep in context.EspecialidadePreco on psp.PlanoSeguroProfissionalId equals ep.PlanoSeguroProfissionalId
                           where ep.Grupo == grupo && psp.EstaAtivo
                           orderby psp.ValorCobertura
                           select new CotacaoViewModel()
                           {
                               EspecialidadePrecoId = ep.EspecialidadePrecoId,
                               PlanoSeguroProfissionalId = psp.PlanoSeguroProfissionalId,
                               Nome = psp.Nome,
                               ValorCobertura = psp.ValorCobertura,
                               Franquia = psp.Franquia,
                               PercentualDescontoGrupoMedico = percentualDescontoGrupoMedico,
                               PercentualDescontoPlataforma = seguradoProfissional.DescontoPlataforma,
                               PrecoMensal = ep.PrecoMensal,
                               PrecoAnual = ep.PrecoAnual
                           }).ToListAsync();

            return q;
        }
        public async Task<CotacaoViewModel> ObterCotacao(int seguradoProfissionalId)
        {
            var seguradoProfissional = GetDataByID(seguradoProfissionalId);
            var cotacoes = await ObterCotacoes(seguradoProfissional.SeguradoProfissionalId);

            return cotacoes.Single(x => x.PlanoSeguroProfissionalId == seguradoProfissional.PlanoSeguroProfissionalId);
        }
    }
}
