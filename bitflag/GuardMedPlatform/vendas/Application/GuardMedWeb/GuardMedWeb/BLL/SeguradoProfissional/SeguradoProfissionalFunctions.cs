using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuardMedWeb.DAL;
using GuardMedWeb.Models;
using BLL;
using Microsoft.EntityFrameworkCore;
using GuardMedWeb.BLL.Utils;

namespace GuardMedWeb.BLL.SeguradoProfissional
{

    public class SeguradoProfissionalFunctions : BLLBasicFunctions<DAL.SeguradoProfissional, Models.SeguradoProfissionalViewModel>
    {
        private readonly BLL.SeguradoProfissional.SeguroProfissionalPrecoFunctions seguroProfissionalPrecoFunctions;
        private readonly BLL.SeguradoProfissional.PlanoSeguroProfissionalFunctions planoSeguroProfissionalFunctions;
        private readonly BLL.SeguradoProfissional.EspecialidadeProfissionalFunctions especialidadeProfissionalFunctions;
        private readonly MedicGroupFunctions medicGroupFunctions;

        public SeguradoProfissionalFunctions(GuardMedWebContext context)
            : base(context, "SeguradoProfissionalId")
        {
            this.seguroProfissionalPrecoFunctions = new BLL.SeguradoProfissional.SeguroProfissionalPrecoFunctions(context);
            this.planoSeguroProfissionalFunctions = new BLL.SeguradoProfissional.PlanoSeguroProfissionalFunctions(context);
            this.especialidadeProfissionalFunctions = new BLL.SeguradoProfissional.EspecialidadeProfissionalFunctions(context);
            this.medicGroupFunctions = new MedicGroupFunctions(context);
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

            var seguradoProfissional = new DAL.SeguradoProfissional
            {
                Nome = model.Nome,
                Email = model.Email,
                Telefone = model.Telefone,
                Celular = model.Celular,
                DataNascimento = model.DataNascimento.Value,
                Idade = model.Idade.Value,
                Conveniado = model.Conveniado.Value,
                CRM = model.CRM,
                EstadoCRM = model.EstadoCRM,
                DataCriacao = DateTime.Now,
                CertificadoGerado = false,
                Referencia = model.Referencia,
                ConsultorGuardMed = model.ConsultorGuardMed,
                EscritorioId = model.EscritorioId,
                PlataformaId = model.PlataformaId,
                DescontoPlataforma = model.DescontoPlataforma
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
                CRM = model.CRM,
                EstadoCRM = model.EstadoCRM,
                DataCriacao = DateTime.Now,
                CertificadoGerado = false,
                Referencia = model.Referencia,
                Bairro = model.Bairro,
                Altura = model.Altura,
                CEP = model.CEP,
                Cidade = model.Cidade,
                Complemento = model.Complemento,
                CPF = model.CPF,
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
                     select new SeguradoProfissionalViewModel
                     {
                         PlanoSeguroProfissionalId = y.PlanoSeguroProfissionalId,
                         Nome = y.Nome,
                         Email = y.Email,
                         Telefone = y.Telefone,
                         Celular = y.Celular,
                         DataNascimento = y.DataNascimento,
                         CRM = y.CRM,
                         EstadoCRM = y.EstadoCRM,
                         SeguradoProfissionalId = y.SeguradoProfissionalId,
                         Altura = y.Altura,
                         Bairro = y.Bairro,
                         CEP = y.CEP,
                         Cidade = y.Cidade,
                         Complemento = y.Complemento,
                         Conveniado = y.Conveniado,
                         CPF = y.CPF,
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
                         IUGU_invoice_secure_url = y.IUGU_invoice_secure_url,
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
                         DescontoGrupoMedico = y.DescontoGrupoMedico
                     }).ToList();
            return r;
        }

        public override SeguradoProfissionalViewModel GetDataViewModel(DAL.SeguradoProfissional data)
        {
            string planoSeguroProfissionalNome = "";

            if (data.GrupoMedico.HasValue)
            {
                var medicGroup = medicGroupFunctions.GetDataByID(data.GrupoMedico);

                if (medicGroup.CompanyOfficeId != null)
                {
                    data.EscritorioId = medicGroup.CompanyOfficeId;
                }

                if (medicGroup.CompanyPlatformId != null)
                {
                    data.PlataformaId = medicGroup.CompanyPlatformId;
                }
            }

            if (data.PlanoSeguroProfissionalId.HasValue)
                planoSeguroProfissionalNome = planoSeguroProfissionalFunctions.GetDataByID(data.PlanoSeguroProfissionalId).Nome;

            return new SeguradoProfissionalViewModel
            {
                PlanoSeguroProfissionalId = data.PlanoSeguroProfissionalId,
                PlanoSeguroProfissionalNome = planoSeguroProfissionalNome,
                Nome = data.Nome,
                Email = data.Email,
                Telefone = data.Telefone,
                Celular = data.Celular,
                DataNascimento = data.DataNascimento,
                CRM = data.CRM,
                EstadoCRM = data.EstadoCRM,
                SeguradoProfissionalId = data.SeguradoProfissionalId,
                Altura = data.Altura,
                Bairro = data.Bairro,
                CEP = data.CEP,
                Cidade = data.Cidade,
                Complemento = data.Complemento,
                Conveniado = data.Conveniado,
                CPF = data.CPF,
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
                IUGU_invoice_secure_url = data.IUGU_invoice_secure_url,
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
                DescontoGrupoMedico = data.DescontoGrupoMedico
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
            seguradoProfissional.CPF = model.CPF;
            seguradoProfissional.CRM = model.CRM;
            seguradoProfissional.EstadoCRM = model.EstadoCRM;
            seguradoProfissional.CEP = model.CEP;
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
            seguradoProfissional.CPF = model.CPF;
            //seguradoProfissional.CRM = model.CRM;
            //seguradoProfissional.EstadoCRMV = model.EstadoCRMV;
            seguradoProfissional.CEP = model.CEP;
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

        public void UpdatePagamento(int seguradoProfissionalId, int pagamentoTipoId, int vezesPagamento, double precoTotal)
        {
            var seguradoProfissional = GetDataByID(seguradoProfissionalId);

            seguradoProfissional.PagamentoTipoId = pagamentoTipoId;
            seguradoProfissional.VezesPagamento = vezesPagamento;
            seguradoProfissional.PrecoTotal = precoTotal;
            seguradoProfissional.CertificadoGerado = true;

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
            novoSeguradoProfissional.IUGU_subscription_id = null;
            novoSeguradoProfissional.IUGU_invoice_id = null;
            novoSeguradoProfissional.IUGU_invoice_secure_url = null;
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
            seguradoProfissional.CPF = model.CPF;
            seguradoProfissional.CEP = model.CEP;
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

            return (await this.context.EspecialidadePreco.SingleAsync(x => x.Gropo == grupo && x.PlanoSeguroProfissionalId == planoSeguroProfissionalId)).CopyToEntity<EspecialidadePrecoViewModel>();
        }

        public async Task BlockPayment(int seguradoProfissionalId)
        {
            var insurance = await this.dbSet.SingleAsync(x => x.SeguradoProfissionalId == seguradoProfissionalId);

            insurance.RenovacaoPagamentoBloqueado = true;
            insurance.PagamentoTipoId = 2;

            this.dbSet.Update(insurance);

            await this.context.SaveChangesAsync();
        }

        public async Task<bool> HasSubscription(int seguradoProfissionalId) => await this.dbSet.AnyAsync(x => x.SeguradoProfissionalId == seguradoProfissionalId && !string.IsNullOrWhiteSpace(x.IUGU_subscription_id));
        public async Task<string> GetSubscription(int seguradoProfissionalId) => (await this.dbSet.SingleAsync(x => x.SeguradoProfissionalId == seguradoProfissionalId)).IUGU_subscription_id;

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
    }
}
