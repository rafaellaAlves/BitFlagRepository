using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasDbContext;
using VendasDbContext.Models;
using Web.DTO;
using Web.DTO.SeguradoProfissional;
using Web.Helpers;

namespace Web.Services.SeguradoProfissional
{
    public class SeguradoProfissionalHistoricoService : Shared.BaseListServices<SeguradoProfissionalHistorico, SeguradoProfissionalHistorico, int>
    {
        private readonly SeguradoProfissionalService seguradoProfissionalService;

        public SeguradoProfissionalHistoricoService(VendasContext context, SeguradoProfissionalService seguradoProfissionalService) : base(context, "SeguradoProfissionalHistoricoId")
        {
            this.seguradoProfissionalService = seguradoProfissionalService;
        }
        public async Task Create(int seguradoProfissionalId)
        {
            await Create(seguradoProfissionalService.GetDataById(seguradoProfissionalId));
        }
        public async Task Create(VendasDbContext.Models.SeguradoProfissional data)
        {
            var especialidades = seguradoProfissionalService.ObterEspecialidades(data.SeguradoProfissionalId);

            if (especialidades.Count > 0) data.Especialidade1 = especialidades[0].EspecialidadeId;
            if (especialidades.Count > 1) data.Especialidade2 = especialidades[1].EspecialidadeId;
            if (especialidades.Count > 2) data.Especialidade3 = especialidades[2].EspecialidadeId;

            var entity = data.CopyToEntity<SeguradoProfissionalHistorico>();

            await this.dbSet.AddAsync(entity);
            await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Obtem as alterações feitas em determinado Segurado
        /// </summary>
        /// <param name="seguradoProfissionalId"></param>
        /// <param name="getHistoricItems">Se "true" retornara as propriedades alteradas, caso "false" irá retorna apenas os dados básicos</param>
        /// <param name="getCurrentData">Se "false" desconsiderará apenas os dados salvos na tabela SeguradoProfissionalHistorico sem considerar os dados atuais armazenados na tabela SeguradoProfissional</param>
        /// <returns></returns>
        public async Task<List<SeguradoProfissionalHistoricoViewModel>> GetChanges(int seguradoProfissionalId, bool getHistoricItems = true, bool getCurrentData = true)
        {
            var entities = (await GetDataAsNoTrackingAsync(x => x.SeguradoProfissionalId == seguradoProfissionalId)).OrderBy(x => x.DataCriacaoHistorico).ToList();
            var segurado = seguradoProfissionalService.GetDataById(seguradoProfissionalId);

            var r = new List<SeguradoProfissionalHistoricoViewModel>();

            for (int i = 0; i < entities.Count; i++)
            {
                SeguradoProfissionalHistorico item = entities[i];
                r.Add(new SeguradoProfissionalHistoricoViewModel
                {
                    DataCriacaoHistorico = item.DataAtualizacao.Value,
                    SeguradoProfissionalHistoricoId = item.SeguradoProfissionalHistoricoId,
                    SeguradoProfissionalId = item.SeguradoProfissionalId,
                    Creation = i == 0,
                    Changes = getHistoricItems ? GetSeguradoProfissionalHistoricoItemViewModel(i == 0 ? null : entities[i - 1].CopyToEntity<VendasDbContext.Models.SeguradoProfissional>(), item.CopyToEntity<VendasDbContext.Models.SeguradoProfissional>()) : null
                });
            }

            if (getCurrentData)
            {
                r.Add(new SeguradoProfissionalHistoricoViewModel
                {
                    DataCriacaoHistorico = segurado.DataAtualizacao.Value,
                    SeguradoProfissionalHistoricoId = null,
                    SeguradoProfissionalId = segurado.SeguradoProfissionalId,
                    Creation = entities.Count == 0,
                    Changes = getHistoricItems ? GetSeguradoProfissionalHistoricoItemViewModel(entities.Count == 0 ? null : entities.Last().CopyToEntity<VendasDbContext.Models.SeguradoProfissional>(), segurado.CopyToEntity<VendasDbContext.Models.SeguradoProfissional>()) : null
                });
            }

            return r;
        }

        public async Task<SeguradoProfissionalHistoricoViewModel> GetChange(int? seguradoProfissionalHistoricoId, int seguradoProfissionalId)
        {
            var entities = (await GetDataAsNoTrackingAsync(x => x.SeguradoProfissionalId == seguradoProfissionalId)).OrderBy(x => x.DataCriacaoHistorico).ToList();

            if (seguradoProfissionalHistoricoId.HasValue)
            {

                var i = entities.IndexOf(entities.Single(x => x.SeguradoProfissionalHistoricoId == seguradoProfissionalHistoricoId));

                return new SeguradoProfissionalHistoricoViewModel
                {
                    DataCriacaoHistorico = entities[i].DataAtualizacao.Value,
                    SeguradoProfissionalHistoricoId = entities[i].SeguradoProfissionalHistoricoId,
                    SeguradoProfissionalId = entities[i].SeguradoProfissionalId,
                    Creation = i == 0,
                    Changes = GetSeguradoProfissionalHistoricoItemViewModel(i == 0 ? null : entities[i - 1].CopyToEntity<VendasDbContext.Models.SeguradoProfissional>(), entities[i].CopyToEntity<VendasDbContext.Models.SeguradoProfissional>())
                };
            }
            else
            {
                var segurado = seguradoProfissionalService.GetDataById(seguradoProfissionalId);

                return new SeguradoProfissionalHistoricoViewModel
                {
                    DataCriacaoHistorico = segurado.DataAtualizacao.Value,
                    SeguradoProfissionalHistoricoId = null,
                    SeguradoProfissionalId = segurado.SeguradoProfissionalId,
                    Creation = entities.Count == 0,
                    Changes = GetSeguradoProfissionalHistoricoItemViewModel(entities.Count == 0 ? null : entities.Last().CopyToEntity<VendasDbContext.Models.SeguradoProfissional>(), segurado.CopyToEntity<VendasDbContext.Models.SeguradoProfissional>())
                };
            }
        }


        private List<SeguradoProfissionalHistoricoItemViewModel> GetSeguradoProfissionalHistoricoItemViewModel(VendasDbContext.Models.SeguradoProfissional entity1, VendasDbContext.Models.SeguradoProfissional entity2)
        {
            var item1 = seguradoProfissionalService.ObterSegurado(entity1);
            var item2 = seguradoProfissionalService.ObterSegurado(entity2);

            if (item1 == null)
            {
                return typeof(SeguradoProfissionalViewModel).GetProperties().Where(x => Attribute.IsDefined(x, typeof(ShowInHistoric))).Select(x =>
                {
                    var showInHistoricAttr = (ShowInHistoric)Attribute.GetCustomAttribute(x, typeof(ShowInHistoric));

                    return new SeguradoProfissionalHistoricoItemViewModel
                    {
                        Propriety = string.IsNullOrWhiteSpace(showInHistoricAttr.PropertyDisplayName) ? x.Name : showInHistoricAttr.PropertyDisplayName,
                        OldValue = null,
                        Value = x.GetValue(item2)?.ToString()
                    };
                }).ToList();
            }

            var r = new List<SeguradoProfissionalHistoricoItemViewModel>();
            foreach (var prop in typeof(SeguradoProfissionalViewModel).GetProperties().Where(x => Attribute.IsDefined(x, typeof(ShowInHistoric))))
            {
                var item1Val = prop.GetValue(item1);
                var item2Val = prop.GetValue(item2);


                if (!(item1Val ?? "").Equals(item2Val ?? ""))
                {
                    var showInHistoricAttr = (ShowInHistoric)Attribute.GetCustomAttribute(prop, typeof(ShowInHistoric));

                    r.Add(new SeguradoProfissionalHistoricoItemViewModel
                    {
                        Propriety = string.IsNullOrWhiteSpace(showInHistoricAttr.PropertyDisplayName) ? prop.Name : showInHistoricAttr.PropertyDisplayName,
                        OldValue = item1Val?.ToString(),
                        Value = item2Val?.ToString()
                    });
                }
            }
            return r;
        }
    }
}
