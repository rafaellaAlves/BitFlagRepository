using Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using VendasDbContext;
using VendasDbContext.Models;
using Web.DTO;
using Web.DTO.Plano;
using Web.DTO.SeguradoProfissional;
using Web.Services.Plano;

namespace Web.Services.SeguradoProfissional
{
    public class SeguradoProfissionalService : Shared.BaseListServices<VendasDbContext.Models.SeguradoProfissional, SeguradoProfissionalViewModel, int>
    {
        private readonly Services.Especialidade.EspecialidadePrecoService especialidadePrecoService;
        private readonly Services.Especialidade.EspecialidadeService especialidadeService;
        private readonly Services.MedicGroup.MedicGroupService medicGroupService;
        private readonly PlanoSeguroProfissionalService planoSeguroProfissionalService;

        public SeguradoProfissionalService(VendasContext context, MedicGroup.MedicGroupService medicGroupService, Especialidade.EspecialidadePrecoService especialidadePrecoService, Especialidade.EspecialidadeService especialidadeService, PlanoSeguroProfissionalService planoSeguroProfissionalService) : base(context, "SeguradoProfissionalId")
        {
            this.medicGroupService = medicGroupService;
            this.especialidadePrecoService = especialidadePrecoService;
            this.especialidadeService = especialidadeService;
            this.planoSeguroProfissionalService = planoSeguroProfissionalService;
        }

        public DTO.SeguradoProfissionalViewModel ObterSegurado(int seguradoProfissionalId)
        {
            var seguradoProfissional = this.context.SeguradoProfissional.Select(x => x.CopyToEntity<SeguradoProfissionalViewModel>()).Single(x => x.SeguradoProfissionalId == seguradoProfissionalId);

            seguradoProfissional.Especialidades = ObterEspecialidades(seguradoProfissionalId);

            return seguradoProfissional;
        }
        public DTO.SeguradoProfissionalViewModel ObterSegurado(VendasDbContext.Models.SeguradoProfissional data)
        {
            var seguradoProfissional = data.CopyToEntity<SeguradoProfissionalViewModel>();

            if (data.Especialidade1.HasValue) seguradoProfissional.Especialidades.Add(especialidadeService.GetViewModelById(data.Especialidade1.Value));
            if (data.Especialidade2.HasValue) seguradoProfissional.Especialidades.Add(especialidadeService.GetViewModelById(data.Especialidade2.Value));
            if (data.Especialidade3.HasValue) seguradoProfissional.Especialidades.Add(especialidadeService.GetViewModelById(data.Especialidade3.Value));

            seguradoProfissional.PlanoSeguroProfissionalNome = planoSeguroProfissionalService.GetDataById(seguradoProfissional.PlanoSeguroProfissionalId.Value).Nome;

            return seguradoProfissional;
        }

        public List<DTO.EspecialidadeViewModel> ObterEspecialidades(int seguradoProfissionalId)
        {
            return (from ep in this.context.EspecialidadeProfissional
                    join e in this.context.Especialidade on ep.EspecialidadeId equals e.EspecialidadeId
                    where ep.SeguradoProfissionalId == seguradoProfissionalId
                    select new DTO.EspecialidadeViewModel()
                    {
                        EspecialidadeId = e.EspecialidadeId,
                        Nome = e.Nome,
                        Grupo = e.Grupo
                    }).ToList();
        }

        public async Task<Guid> GeneratePasswordResetTokenAsync(int seguradoProfissionalId)
        {
            var token = Guid.NewGuid();
            var seguradoProfissional = GetDataById(seguradoProfissionalId);

            seguradoProfissional.TokenSenha = token;
            this.dbSet.Update(seguradoProfissional);
            await this.context.SaveChangesAsync();

            return token;
        }

        public async Task<bool> TrocarSenha(int id, string newPassword, string TokenPassword)
        {
            var entity = GetDataById(id);
            if (entity.TokenSenha != new Guid(TokenPassword)) return await Task.Run(() => false);

            entity.TokenSenha = null;
            entity.Senha = newPassword;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();

            return await Task.Run(() => true);
        }
        public async Task<bool> TrocarSenha(int id, string newPassword)
        {
            var entity = GetDataById(id);

            entity.TokenSenha = null;
            entity.Senha = newPassword;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();

            return await Task.Run(() => true);
        }

        public async Task<SeguradoProfissionalCertificatePdfViewModel> GetCertificatePdfViewModel(int seguradoProfissionalId)
        {
            var seguradoProfissional = GetDataById(seguradoProfissionalId);

            var viewModel = seguradoProfissional.CopyToEntity<SeguradoProfissionalCertificatePdfViewModel>();
            viewModel.EspecialidadeProfissional = ObterEspecialidades(seguradoProfissionalId);

            var grupoSeguroRCP = viewModel.EspecialidadeProfissional.Max(x => x.Grupo);
            viewModel.EspecialidadePreco = (await especialidadePrecoService.GetViewModelAsNoTrackingAsync(x => x.Grupo == grupoSeguroRCP && x.PlanoSeguroProfissionalId == seguradoProfissional.PlanoSeguroProfissionalId)).Single();

            var medicGroups = await medicGroupService.GetMedicGroupsByCRM(seguradoProfissional.Crm, seguradoProfissional.EstadoCrm);
            var medicGroup = (medicGroups != null && medicGroups.Count > 0) ? medicGroups.OrderByDescending(x => x.Discount).First() : null;
            double desconto = ObterDesconto(seguradoProfissional.SeguradoProfissionalId, medicGroup);

            if (viewModel.PagamentoTipoId == 1)
            {
                viewModel.PrecoTotalComDesconto = viewModel.EspecialidadePreco.PrecoAnual * desconto;
                viewModel.PrecoTotalMenosAdm = viewModel.EspecialidadePreco.PrecoAnual - viewModel.EspecialidadePreco.PrecoAdmAnual;
                viewModel.PrecoAdm = (viewModel.PrecoTotalComDesconto - viewModel.PrecoTotalMenosAdm);
            }
            else
            {
                viewModel.PrecoTotalComDesconto = viewModel.EspecialidadePreco.PrecoMensal * desconto;
                viewModel.PrecoTotalMenosAdm = viewModel.EspecialidadePreco.PrecoMensal - viewModel.EspecialidadePreco.PrecoAdmMensal;
                viewModel.PrecoAdm = (viewModel.PrecoTotalComDesconto - viewModel.PrecoTotalMenosAdm);
            }


            return viewModel;
        }

        public double ObterDesconto(int seguradoProfissionalId, VendasDbContext.Models.MedicGroup medicGroup)
        {
            var segurado = GetDataById(seguradoProfissionalId);

            if (segurado.DescontoPlataforma.HasValue) return (100d - (double)segurado.DescontoPlataforma) / 100d;

            return segurado.DescontoGrupoMedico.HasValue ? ((100d - segurado.DescontoGrupoMedico.Value) / 100d) : (medicGroup != null ? (100d - medicGroup.Discount) / 100d : 1d);
        }

        public async Task UpdateBasicData(DTO.SeguradoProfissionalViewModel model)
        {
            var entity = GetDataById(model.SeguradoProfissionalId);

            entity.Nome = model.Nome;
            entity.Celular = model.Celular;
            entity.Telefone = model.Telefone;
            entity.Cep = model.CEP;
            entity.Endereco = model.Endereco;
            entity.EnderecoNumero = model.EnderecoNumero;
            entity.Complemento = model.Complemento;
            entity.Bairro = model.Bairro;
            entity.Cidade = model.Cidade;
            entity.Estado = model.Estado;
            //entity.DataAtualizacao = DateTime.Now;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }

        public void UpdateProfessionalData(int seguradoProfissionalId, int? especialidade1, int? especialidade2, int? especialidade3, bool upgradePlan, out PlanoSeguroProfissionalViewModel upgradedPlan)
        {
            var entity = GetDataById(seguradoProfissionalId);
            upgradedPlan = null;

            #region [ESPECIALIDADES]
            if (especialidade1.HasValue)
            {
                entity.Especialidade1 = especialidade1;
                this.context.EspecialidadeProfissional.Add(new VendasDbContext.Models.EspecialidadeProfissional
                {
                    EspecialidadeId = especialidade1.Value,
                    SeguradoProfissionalId = seguradoProfissionalId
                });
            }
            if (especialidade2.HasValue)
            {
                entity.Especialidade2 = especialidade2;
                this.context.EspecialidadeProfissional.Add(new VendasDbContext.Models.EspecialidadeProfissional
                {
                    EspecialidadeId = especialidade2.Value,
                    SeguradoProfissionalId = seguradoProfissionalId
                });
            }
            if (especialidade3.HasValue)
            {
                entity.Especialidade3 = especialidade3;
                this.context.EspecialidadeProfissional.Add(new VendasDbContext.Models.EspecialidadeProfissional
                {
                    EspecialidadeId = especialidade3.Value,
                    SeguradoProfissionalId = seguradoProfissionalId
                });
            }

            this.context.SaveChanges();
            #endregion

            #region [PLANO]
            if (upgradePlan)
            {
                if (TryGetNextPlan(seguradoProfissionalId, out PlanoSeguroProfissionalViewModel nextPlan))
                {
                    upgradedPlan = nextPlan;

                    entity.PrecoTotal = GetPlanPrice(seguradoProfissionalId, nextPlan.PlanoSeguroProfissionalId);
                    entity.PlanoSeguroProfissionalId = nextPlan.PlanoSeguroProfissionalId;
                }
                else
                {
                    return;//Retornar erro
                }
            }
            #endregion

            //entity.DataAtualizacao = DateTime.Now;

            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }

        public async Task<double?> GetPriceForUpdateProfessionalData(int seguradoProfissionalId, int? especialidade1, int? especialidade2, int? especialidade3, bool upgradePlan)
        {
            var entity = ObterSegurado(seguradoProfissionalId);

            List<VendasDbContext.Models.Especialidade> especialidades = new List<VendasDbContext.Models.Especialidade>();

            #region [Organiza as Especialidades]
            //Obtem as especialidades, tanto as já salvas quanto as selecionadas pela tela
            if (especialidade1.HasValue)
            {
                especialidades.Add(especialidadeService.GetDataById(especialidade1.Value));
            }
            else if (entity.Especialidades.Count > 0)
            {
                especialidades.Add(especialidadeService.GetDataById(entity.Especialidades[0].EspecialidadeId));
            }

            if (especialidade2.HasValue)
            {
                especialidades.Add(especialidadeService.GetDataById(especialidade2.Value));
            }
            else if (entity.Especialidades.Count > 1)
            {
                especialidades.Add(especialidadeService.GetDataById(entity.Especialidades[1].EspecialidadeId));
            }

            if (especialidade3.HasValue)
            {
                especialidades.Add(especialidadeService.GetDataById(especialidade3.Value));
            }
            else if (entity.Especialidades.Count > 2)
            {
                especialidades.Add(especialidadeService.GetDataById(entity.Especialidades[2].EspecialidadeId));
            }
            #endregion

            if (upgradePlan) //caso o cliente vá dar um upgrade no plano pega o valor total baseado no novo plano
            {
                if (TryGetNextPlan(seguradoProfissionalId, out PlanoSeguroProfissionalViewModel nextPlan))
                {
                    return await Task.Run(() => GetPlanPrice(seguradoProfissionalId, nextPlan.PlanoSeguroProfissionalId, especialidades));
                }
            }
            else //caso o cliente não dê um upgrade no plano pega o valor total baseado no plano atual
            {
                return await Task.Run(() => GetPlanPrice(seguradoProfissionalId, entity.PlanoSeguroProfissionalId.Value, especialidades));
            }

            return await Task.Run(() => (double?)null);//Retornar erro

        }
        public bool TryGetNextPlan(int seguradoProfissionalId, out PlanoSeguroProfissionalViewModel nextPlan)
        {
            var entity = GetDataById(seguradoProfissionalId);

            PlanoSeguroProfissionalViewModel plano = planoSeguroProfissionalService.GetViewModelAsNoTracking(x => x.PlanoSeguroProfissionalId == entity.PlanoSeguroProfissionalId).FirstOrDefault();
            nextPlan = planoSeguroProfissionalService.GetViewModelAsNoTracking(x => x.ValorCobertura > plano.ValorCobertura).FirstOrDefault();

            return nextPlan != null;
        }

        public double GetPlanPrice(int seguradoProfissionalId, int planoSeguroProfissionalId, List<VendasDbContext.Models.Especialidade> especialidades)
        {
            var entity = GetDataById(seguradoProfissionalId);
            double totalPrice;

            var medicGroups = medicGroupService.GetMedicGroupsByCRM(entity.Crm, entity.EstadoCrm).Result;
            var medicGroup = (medicGroups != null && medicGroups.Count > 0) ? medicGroups.OrderByDescending(x => x.Discount).First() : null;
            double desconto = ObterDesconto(entity.SeguradoProfissionalId, medicGroup);

            var grupoSeguroRCP = especialidades.Max(x => x.Grupo);
            var precoSeguroRCP = this.context.EspecialidadePreco.Single(x => x.Grupo == grupoSeguroRCP && x.PlanoSeguroProfissionalId == planoSeguroProfissionalId);

            totalPrice = precoSeguroRCP.PrecoAnual * desconto;

            double valorCoberturaAdicional = totalPrice / 100 * 10;

            if ((entity.DiretorChefeEquipe == true && entity.CoberturaAdicionalDiretorChefeEquipe == true) || (entity.SocioEmpresaAreaMedica == true && entity.CoberturaAdicionalSocioEmpresaAreaMedica == true))
            {
                totalPrice += valorCoberturaAdicional;
            }

            return totalPrice;
        }

        public double GetPlanPrice(int seguradoProfissionalId, int planoSeguroProfissionalId)
        {
            var entity = GetDataById(seguradoProfissionalId);
            double totalPrice;

            var medicGroups = medicGroupService.GetMedicGroupsByCRM(entity.Crm, entity.EstadoCrm).Result;
            var medicGroup = (medicGroups != null && medicGroups.Count > 0) ? medicGroups.OrderByDescending(x => x.Discount).First() : null;
            double desconto = ObterDesconto(entity.SeguradoProfissionalId, medicGroup);

            var grupoSeguroRCP = ObterEspecialidades(seguradoProfissionalId).Max(x => x.Grupo);
            var precoSeguroRCP = this.context.EspecialidadePreco.Single(x => x.Grupo == grupoSeguroRCP && x.PlanoSeguroProfissionalId == planoSeguroProfissionalId);

            totalPrice = precoSeguroRCP.PrecoAnual * desconto;

            double valorCoberturaAdicional = totalPrice / 100 * 10;

            if ((entity.DiretorChefeEquipe == true && entity.CoberturaAdicionalDiretorChefeEquipe == true) || (entity.SocioEmpresaAreaMedica == true && entity.CoberturaAdicionalSocioEmpresaAreaMedica == true))
            {
                totalPrice += valorCoberturaAdicional;
            }

            return totalPrice;
        }

        public async Task<List<InsuranceLogViewModel>> GetInsuranceLog(int seguradoProfissionalId)
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "pr_ObterHistoricoSeguroProfissional @SeguradoProfissionalId = @_SeguradoProfissionalId";

                command.Parameters.Add(new SqlParameter("@_SeguradoProfissionalId", seguradoProfissionalId));

                await context.Database.OpenConnectionAsync();

                var models = new List<InsuranceLogViewModel>();

                using (var result = await command.ExecuteReaderAsync())
                {
                    while (await result.ReadAsync())
                        models.Add(result.CopyToEntity<InsuranceLogViewModel>());
                }
                return models;
            }
        }
    }
}
