using DTO.Contract;
using DTO.Report;
using DTO.Report.Route;
using DTO.Service;
using DTO.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Report
{
    public class ReportService
    {
        readonly ApplicationDbContext.Context.ApplicationDbContext context;

        public ReportService(ApplicationDbContext.Context.ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<NewContractAndServiceViewModel>> GetNewContractAndService(DateTime startDate, DateTime endDate, string state, string city)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_Report_NewContractAndService @StartDate = @_StartDate, @EndDate = @_EndDate, @State = @_State, @City = @_City";
            command.Parameters.Add(new SqlParameter("@_StartDate", startDate));
            command.Parameters.Add(new SqlParameter("@_EndDate", endDate));
            command.Parameters.Add(new SqlParameter("@_State", string.IsNullOrWhiteSpace(state) ? DBNull.Value : (object)state));
            command.Parameters.Add(new SqlParameter("@_City", string.IsNullOrWhiteSpace(city) ? DBNull.Value : (object)city));

            await context.Database.OpenConnectionAsync();

            var viewModels = new List<NewContractAndServiceViewModel>();
            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
                viewModels.Add(
                    new NewContractAndServiceViewModel
                    {
                        Date = result["Date"].GetDateTimeFromDbDataReader().Value,
                        ContractCount = result["ContractCount"].GetIntFromDbDataReader().Value,
                        ServiceCount = result["ServiceCount"].GetIntFromDbDataReader().Value,
                    });

            return viewModels;
        }


        public async Task<List<NewAndEndedContractViewModel>> GetNewAndEndedContracts(DateTime startDate, DateTime endDate)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_Report_NewAndEndedContracts @StartDate = @_StartDate, @EndDate = @_EndDate";
            command.Parameters.Add(new SqlParameter("@_StartDate", startDate));
            command.Parameters.Add(new SqlParameter("@_EndDate", endDate));

            await context.Database.OpenConnectionAsync();

            var viewModels = new List<NewAndEndedContractViewModel>();
            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
                viewModels.Add(
                    new NewAndEndedContractViewModel
                    {
                        Date = result["Date"].GetDateTimeFromDbDataReader().Value,
                        NewContractCount = result["NewContractCount"].GetIntFromDbDataReader().Value,
                        EndedContractCount = result["EndedContractCount"].GetIntFromDbDataReader().Value,
                    });

            return viewModels;
        }

        public async Task<NewAndEndedContractDetailViewModel> GetNewAndEndedContractDetails(DateTime date)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_Report_NewAndEndedContractDetails @Date = @_Date";
            command.Parameters.Add(new SqlParameter("@_Date", date));

            await context.Database.OpenConnectionAsync();

            var model = new NewAndEndedContractDetailViewModel();
            using var result = await command.ExecuteReaderAsync();

            while (result.Read())
                model.NewContract.Add(result.CopyToEntity<ContractListViewModel>());

            result.NextResult();

            while (result.Read())
                model.EndedContract.Add(result.CopyToEntity<ContractListViewModel>());

            return model;
        }

        public async Task<List<ContractListViewModel>> GetEndedContracts(DateTime startDate, DateTime endDate)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_Report_EndedContracts @StartDate = @_StartDate, @EndDate = @_EndDate";
            command.Parameters.Add(new SqlParameter("@_StartDate", startDate));
            command.Parameters.Add(new SqlParameter("@_EndDate", endDate));

            await context.Database.OpenConnectionAsync();

            var viewModels = new List<ContractListViewModel>();
            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
                viewModels.Add(result.CopyToEntity<ContractListViewModel>());

            return viewModels;
        }

        public async Task<List<ServiceListViewModel>> GetServices(DateTime date)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_Report_Services @Date = @_Date";
            command.Parameters.Add(new SqlParameter("@_Date", date));

            await context.Database.OpenConnectionAsync();

            var viewModels = new List<ServiceListViewModel>();
            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
                viewModels.Add(result.CopyToEntity<ServiceListViewModel>());

            return viewModels;
        }

        public async Task<RouteReportViewModel> GetRoutes(DateTime startDate, DateTime endDate, string routeIds)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_Report_Route @StartDate = @_StartDate, @EndDate = @_EndDate, @RouteIds = @_RouteIds";
            command.Parameters.Add(new SqlParameter("@_StartDate", startDate));
            command.Parameters.Add(new SqlParameter("@_EndDate", endDate));
            command.Parameters.Add(new SqlParameter("@_RouteIds", string.IsNullOrWhiteSpace(routeIds) ? DBNull.Value : (object)routeIds));

            await context.Database.OpenConnectionAsync();

            var viewModels = new List<RouteReportItemViewModel>();
            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
                viewModels.Add(result.CopyToEntity<RouteReportItemViewModel>());

            return new RouteReportViewModel
            {
                Data = viewModels,
                StartDate = startDate,
                EndDate = endDate
            };
        }
    }
}
