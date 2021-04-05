using ApplicationDbContext.Models;
using DTO.Route;
using DTO.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Route
{
    public class RouteServices : Shared.BaseServices<ApplicationDbContext.Models.Route, RouteViewModel, int>
    {
        public RouteServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "RouteId")
        {
        }
        public async IAsyncEnumerable<AddressBaseViewModel> GetContractAndServiceAvailbleCities()
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_GetContractAndServiceAvailbleCities";
            context.Database.OpenConnection();

            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
            {
                yield return new AddressBaseViewModel
                {
                    State = result["State"].ToString(),
                    City = result["City"].ToString()
                };
            }
        }
        public async Task<List<RouteClientSelectionViewModel>> GetContractAndServiceAvailbleCities(List<AddressBaseViewModel> address)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_GetAvailbleClientAddress @States, @Cities";

            command.Parameters.Add(new SqlParameter("@States", string.Join(";", address.Select(x => x.State))));
            command.Parameters.Add(new SqlParameter("@Cities", string.Join(";", address.Select(x => x.City))));

            context.Database.OpenConnection();

            var r = new List<RouteClientSelectionViewModel>();

            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
            {
                r.Add(new RouteClientSelectionViewModel
                {
                    ContractSituationName = (result["ContractSituationName"] == DBNull.Value ? null : result["ContractSituationName"].ToString()),
                    RowColor = result["RowColor"].ToString(),
                    ClientId = (int)result["ClientId"],
                    Address = result["Address"].ToString(),
                    ClientCollectionAddressId = (int)result["ClientCollectionAddressId"],
                    CompanyName = result["CompanyName"].ToString(),
                    ContractId = (result["ContractId"] == DBNull.Value ? null : (int?)result["ContractId"]),
                    InOtherRoute = (bool)result["InOtherRoute"],
                    Neighborhood = result["Neighborhood"].ToString(),
                    Number = result["Number"].ToString(),
                    ServiceId = (result["ServiceId"] == DBNull.Value ? null : (int?)result["ServiceId"]),
                    TradeName = result["TradeName"].ToString(),
                    State = result["State"].ToString(),
                    City = result["City"].ToString(),
                    ServiceCode = (result["ServiceCode"] == DBNull.Value ? null : result["ServiceCode"].ToString()),
                    ContractCode = (result["ContractCode"] == DBNull.Value ? null : result["ContractCode"].ToString())
                });
            }

            return await Task.Run(() => r);
        }

        public async Task<int> GetLastId()
        {
            try
            {
                return await Task.Run(async () => await this.dbSet.MaxAsync(x => x.RouteId));
            }
            catch
            {
                return await Task.Run(() => 1);
            }
        }

        public async Task Cancel(int routeId, string reason)
        {
            var entity = await GetDataByIdAsync(routeId);

            entity.Canceled = true;
            entity.CancelReason = reason;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task Suspend(int routeId, string reason, bool suspended = true)
        {
            var entity = await GetDataByIdAsync(routeId);

            entity.Suspended = suspended;

            if (suspended) entity.SuspendReason = reason;
            else entity.EnableReason = reason;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task<List<ResidueFamilyList>> GetResidueFamiliesByRouteId(int id)
        {
            return await (from rrf in this.context.RouteResidueFamily
                          join rf in this.context.ResidueFamilyList on rrf.ResidueFamilyId equals rf.ResidueFamilyId
                          where rrf.RouteId == id
                          select rf).Distinct().ToListAsync();
        }
    }
}
