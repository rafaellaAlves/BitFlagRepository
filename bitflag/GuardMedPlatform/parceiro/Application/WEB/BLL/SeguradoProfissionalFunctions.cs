using BLL;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using VendasDbContext.Models;
using WEB.Models;
using WEB.Utils;

namespace WEB.BLL
{
    public class SeguradoProfissionalFunctions
    {
        readonly VendasContext context;
        readonly DbSet<VendasDbContext.Models.SeguradoProfissional> dbSet;

        public SeguradoProfissionalFunctions(VendasContext context)
        {
            this.context = context;
            dbSet = context.SeguradoProfissional;
        }

        public async Task UpdateRetroactivityFile(int seguradoProfissionalId, string retroatividadeFilePath, string retroatividadeFileName)
        {
            var entity = await this.dbSet.SingleAsync(x => x.SeguradoProfissionalId == seguradoProfissionalId);

            entity.RetroatividadeFilePath = retroatividadeFilePath;
            entity.RetroatividadeFileName = retroatividadeFileName;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task<List<InsuranceLogViewModel>> GetInsuranceLog(int seguradoProfissionalId)
        {
            using (var command = context.Database.GetDbConnection().CreateCommand()) {

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
