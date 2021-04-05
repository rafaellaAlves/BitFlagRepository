using DTO.Home;
using DTO.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Home
{
    public class HomeServices
    {
        private readonly ApplicationDbContext.Context.ApplicationDbContext context;

        public HomeServices(ApplicationDbContext.Context.ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<HomeClientViewModel> GetHomeClientViewModel(int clientId)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_GetHomeClientOverallInfo @ClientId = @_ClientId";
            command.Parameters.Add(new SqlParameter("@_ClientId", clientId));

            await context.Database.OpenConnectionAsync();

            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
            {
                return await Task.Run(() => new HomeClientViewModel
                {
                    CollectedWeight = result["CollectedWeight"].GetDoubleFromDbDataReader(),
                    ContractedWeight = result["ContractedWeight"].GetDoubleFromDbDataReader(),
                    ContractMonthlyPrice = result["ContractMonthlyPrice"].GetDoubleFromDbDataReader(),
                    FinishedCollections = result["FinishedCollections"].GetIntFromDbDataReader(),
                    NextColletionDate = result["NextColletionDate"].GetDateTimeFromDbDataReader(),
                    RemainingCollections = result["RemainingCollections"].GetIntFromDbDataReader(),
                    RemainingWeight = result["RemainingWeight"].GetDoubleFromDbDataReader(),
                    Route = result["Route"].GetIntFromDbDataReader(),
                    TotalCollections = result["TotalCollections"].GetIntFromDbDataReader(),
                });
            }

            return await Task.Run(() => new HomeClientViewModel());
        }


        public async Task<List<HomeDemandClientListViewModel>> GetHomeDemandClientListViewModel(int clientId)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_Home_DemandClientList @ClientId = @_ClientId";
            command.Parameters.Add(new SqlParameter("@_ClientId", clientId));

            await context.Database.OpenConnectionAsync();

            var viewModels = new List<HomeDemandClientListViewModel>();
            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
            {
                viewModels.Add(new HomeDemandClientListViewModel
                {
                    AlternativeDemandId = result["AlternativeDemandId"].GetStringFromDbDataReader(),
                    ArrivedTime = result["ArrivedTime"].GetTimeSpanFromDbDataReader(),
                    CertificateId = result["CertificateId"].GetIntFromDbDataReader(),
                    ClientId = result["ClientId"].GetIntFromDbDataReader().Value,
                    Collected = result["Collected"].GetBoolFromDbDataReader(),
                    DemandClientId = result["DemandClientId"].GetIntFromDbDataReader().Value,
                    DemandCreatedDate = result["DemandCreatedDate"].GetDateTimeFromDbDataReader().Value,
                    DemandId = result["DemandId"].GetIntFromDbDataReader().Value,
                    DriverName = result["DriverName"].GetStringFromDbDataReader(),
                    ReceptorName = result["ReceptorName"].GetStringFromDbDataReader(),
                    TransporterDriverId = result["TransporterDriverId"].GetIntFromDbDataReader().Value,
                    Visited = result["Visited"].GetBoolFromDbDataReader(),
                    Weight = result["Weight"].GetDoubleFromDbDataReader(),
                    VisitedDate = result["VisitedDate"].GetDateTimeFromDbDataReader()
                });
            }

            return await Task.Run(() => viewModels);
        }


        public async Task<List<HomeDemandClientResidueFamilyCollectedViewModel>> GetHomeDemandClientResidueFamilyCollectedViewModel(int clientId)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_Home_GetDemandClientResidueFamilyCollected @ClientId = @_ClientId";
            command.Parameters.Add(new SqlParameter("@_ClientId", clientId));

            await context.Database.OpenConnectionAsync();

            List<HomeDemandClientResidueFamilyCollectedViewModel> r = new List<HomeDemandClientResidueFamilyCollectedViewModel>();
            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
            {
                r.Add(new HomeDemandClientResidueFamilyCollectedViewModel
                {
                    Name = result["Name"].GetStringFromDbDataReader(),
                    ResidueFamilyId = result["ResidueFamilyId"].GetIntFromDbDataReader().Value,
                    Weight = result["Weight"].GetDoubleFromDbDataReader().Value,
                });
            }

            return await Task.Run(() => r);
        }

        public async Task<List<HomeLastMonthlyCollectionsViewModel>> GetHomeLastMonthlyCollections(int clientId, int year)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_Home_GetLastMonthlyCollections @ClientId = @_ClientId, @Year = @_Year";
            command.Parameters.Add(new SqlParameter("@_ClientId", clientId));
            command.Parameters.Add(new SqlParameter("@_Year", year));

            await context.Database.OpenConnectionAsync();

            List<HomeLastMonthlyCollectionsViewModel> r = new List<HomeLastMonthlyCollectionsViewModel>();
            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
            {
                r.Add(new HomeLastMonthlyCollectionsViewModel
                {
                    Month = result["Month"].GetDateTimeFromDbDataReader().Value,
                    Weight = result["Weight"].GetDoubleFromDbDataReader().Value,
                });
            }

            return await Task.Run(() => r);
        }

        public async IAsyncEnumerable<HomeDemandClientResidueCollectedViewModel> GetHomeDemandClientResidueCollectedViewModel(int clientId)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_Home_GetDemandClientResidueCollected @ClientId = @_ClientId";
            command.Parameters.Add(new SqlParameter("@_ClientId", clientId));

            await context.Database.OpenConnectionAsync();

            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
            {
                yield return new HomeDemandClientResidueCollectedViewModel
                {
                    ResidueFamilyName = result["ResidueFamilyName"].GetStringFromDbDataReader(),
                    ResidueName = result["ResidueName"].GetStringFromDbDataReader(),
                    ResidueId = result["ResidueId"].GetIntFromDbDataReader().Value,
                    Weight = result["Weight"].GetDoubleFromDbDataReader().Value,
                };
            }
        }

        public async IAsyncEnumerable<DateTime> GetHomeGetNextVisits(int clientId, DateTime date, bool getAtLeastOneRow = true)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_Home_GetNextVisits @ClientId = @_ClientId, @Date = @_Date, @GetAtLeastOneRow = @_GetAtLeastOneRow";
            command.Parameters.Add(new SqlParameter("@_ClientId", clientId));
            command.Parameters.Add(new SqlParameter("@_Date", date));
            command.Parameters.Add(new SqlParameter("@_GetAtLeastOneRow", getAtLeastOneRow));

            await context.Database.OpenConnectionAsync();

            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
            {
                yield return result["NextVisitDates"].GetDateTimeFromDbDataReader().Value;
            }
        }

        public async Task<DateTime?> GetFirstCollectDateFromClient(int clientId)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "SELECT dbo.[GetFirstCollectDateFromClient](@ClientId) as 'FirstCollection'";
            command.Parameters.Add(new SqlParameter("@ClientId", clientId));

            await context.Database.OpenConnectionAsync();

            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
            {
                return result["FirstCollection"].GetDateTimeFromDbDataReader();
            }

            return null;
        }
    }
}
