using DTO.Client.Report;
using DTO.Residue;
using DTO.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Client
{
    public class ClientReportServices
    {
        private readonly ApplicationDbContext.Context.ApplicationDbContext context;

        public ClientReportServices(ApplicationDbContext.Context.ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<ClientReportCollectionHistoryViewModel>> GetClientReportCollectionHistoryViewModel(int? clientId, DateTime? startDate, DateTime? endDate)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_ClientReport_GetCollectionHistory @ClientId = @_ClientId, @StartDate = @_StartDate, @EndDate = @_EndDate";
            command.Parameters.Add(new SqlParameter("@_ClientId", clientId ?? (object)DBNull.Value));
            command.Parameters.Add(new SqlParameter("@_StartDate", startDate ?? (object)DBNull.Value));
            command.Parameters.Add(new SqlParameter("@_EndDate", endDate ?? (object)DBNull.Value));

            await context.Database.OpenConnectionAsync();

            var viewModels = new List<ClientReportCollectionHistoryViewModel>();
            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
            {
                viewModels.Add(new ClientReportCollectionHistoryViewModel
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
                    VisitedDate = result["VisitedDate"].GetDateTimeFromDbDataReader(),
                    NonCollectingReason = result["NonCollectingReason"].GetStringFromDbDataReader()
                });
            }

            return await Task.Run(() => viewModels);
        }

        public async Task<List<ClientReportCollectionMapViewModel>> GetClientReportCollectionMapViewModel(int? clientId, DateTime? startDate, DateTime? endDate, int? residueFamilyId, List<int> residueIds)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_ClientReport_GetCollectionMap @ClientId = @_ClientId, @StartDate = @_StartDate, @EndDate = @_EndDate, @ResidueFamilyId = @_ResidueFamilyId, @ResidueIds = @_ResidueIds";
            command.Parameters.Add(new SqlParameter("@_ClientId", clientId ?? (object)DBNull.Value));
            command.Parameters.Add(new SqlParameter("@_StartDate", startDate ?? (object)DBNull.Value));
            command.Parameters.Add(new SqlParameter("@_EndDate", endDate ?? (object)DBNull.Value));
            command.Parameters.Add(new SqlParameter("@_ResidueFamilyId", residueFamilyId ?? (object)DBNull.Value));
            command.Parameters.Add(new SqlParameter("@_ResidueIds", residueIds == null || residueIds.Count == 0 ? (object)DBNull.Value : string.Join(",", residueIds)));

            await context.Database.OpenConnectionAsync();

            var viewModels = new List<ClientReportCollectionMapViewModel>();
            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
            {
                viewModels.Add(new ClientReportCollectionMapViewModel
                {
                    ResidueFamilyId = result["ResidueFamilyId"].GetIntFromDbDataReader(),
                    ResidueFamilyName = result["ResidueFamilyName"].GetStringFromDbDataReader(),
                    Month = result["Month"].GetDateTimeFromDbDataReader().Value,
                    Weight = result["Weight"].GetDoubleFromDbDataReader().Value
                });
            }

            return await Task.Run(() => viewModels);
        }

        public async Task<List<ClientReportCollectionYearMapViewModel>> GetClientReportCollectionYearMapViewModel(int? clientId, int? startYear, int? endYear, int? residueFamilyId, List<int> residueIds)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_ClientReport_GetCollectionYearMap @ClientId = @_ClientId, @StartYear = @_StartYear, @EndYear = @_EndYear, @ResidueFamilyId = @_ResidueFamilyId, @ResidueIds = @_ResidueIds";
            command.Parameters.Add(new SqlParameter("@_ClientId", clientId ?? (object)DBNull.Value));
            command.Parameters.Add(new SqlParameter("@_StartYear", startYear ?? (object)DBNull.Value));
            command.Parameters.Add(new SqlParameter("@_EndYear", endYear ?? (object)DBNull.Value));
            command.Parameters.Add(new SqlParameter("@_ResidueFamilyId", residueFamilyId ?? (object)DBNull.Value));
            command.Parameters.Add(new SqlParameter("@_ResidueIds", residueIds == null || residueIds.Count == 0 ? (object)DBNull.Value : string.Join(",", residueIds)));

            await context.Database.OpenConnectionAsync();

            var viewModels = new List<ClientReportCollectionYearMapViewModel>();
            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
            {
                viewModels.Add(new ClientReportCollectionYearMapViewModel
                {
                    Date = result["Date"].GetDateTimeFromDbDataReader().Value,
                    Weight = result["Weight"].GetDoubleFromDbDataReader().Value
                });
            }

            return await Task.Run(() => viewModels);
        }

        public async Task<List<ClientReportPGRSViewModel>> GetClientReportPGRSViewModel(int? clientId, DateTime? startDate, DateTime? endDate, int? unitOfMeasurementId)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_ClientReport_PGRS @ClientId = @_ClientId, @StartDate = @_StartDate, @EndDate = @_EndDate, @UnitOfMeasurementId = @_UnitOfMeasurementId";
            command.Parameters.Add(new SqlParameter("@_ClientId", clientId ?? (object)DBNull.Value));
            command.Parameters.Add(new SqlParameter("@_StartDate", startDate ?? (object)DBNull.Value));
            command.Parameters.Add(new SqlParameter("@_EndDate", endDate ?? (object)DBNull.Value));
            command.Parameters.Add(new SqlParameter("@_UnitOfMeasurementId", unitOfMeasurementId ?? (object)DBNull.Value));

            await context.Database.OpenConnectionAsync();

            var viewModels = new List<ClientReportPGRSViewModel>();
            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
                viewModels.Add(result.CopyToEntity<ClientReportPGRSViewModel>());

            return await Task.Run(() => viewModels);
        }

        public async Task<List<ClientReportDownloadViewModel>> GetClientReportDownloadViewModel(int clientId)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_ClientReport_Download @ClientId = @_ClientId";
            command.Parameters.Add(new SqlParameter("@_ClientId", clientId));

            await context.Database.OpenConnectionAsync();

            var viewModels = new List<ClientReportDownloadViewModel>();
            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
            {
                viewModels.Add(new ClientReportDownloadViewModel
                {
                    DemandClientId = result["DemandClientId"].GetIntFromDbDataReader().Value,
                    CertificateId = result["CertificateId"].GetIntFromDbDataReader(),
                    DemandId = result["DemandId"].GetIntFromDbDataReader().Value,
                    AlternativeDemandId = result["AlternativeDemandId"].GetStringFromDbDataReader(),
                    VisitedDate = result["VisitedDate"].GetDateTimeFromDbDataReader().Value,
                    DemandCreatedDate = result["DemandCreatedDate"].GetDateTimeFromDbDataReader().Value,
                    MTRFileGuidName = result["MTRFileGuidName"].GetStringFromDbDataReader()
                });
            }

            return await Task.Run(() => viewModels);
        }

        public async Task<List<ClientReportDownloadDestinationViewModel>> GetClientReportDownloadDestinationViewModel(int demandId)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_ClientReport_DownloadDestination @DemandId = @_DemandId";
            command.Parameters.Add(new SqlParameter("@_DemandId", demandId));

            await context.Database.OpenConnectionAsync();

            var viewModels = new List<ClientReportDownloadDestinationViewModel>();
            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
            {
                viewModels.Add(new ClientReportDownloadDestinationViewModel
                {
                    AlternativeDemandDestinationId = result["AlternativeDemandDestinationId"].GetStringFromDbDataReader(),
                    ArrivedDate = result["ArrivedDate"].GetDateTimeFromDbDataReader().Value,
                    ResidueFamilyName = result["ResidueFamilyName"].GetStringFromDbDataReader(),
                    DepartureDate = result["DepartureDate"].GetDateTimeFromDbDataReader().Value,
                    CDF = result["CDF"].GetStringFromDbDataReader(),
                    DemandDestinationCreatedDate = result["DemandDestinationCreatedDate"].GetDateTimeFromDbDataReader().Value,
                    DemandDestinationId = result["DemandDestinationId"].GetIntFromDbDataReader().Value,
                    MTRFileGuidName = result["MTRFileGuidName"].GetStringFromDbDataReader(),
                    CDFFileGuidName = result["CDFFileGuidName"].GetStringFromDbDataReader(),
                });
            }

            return await Task.Run(() => viewModels);
        }

        public async Task<List<ClientReportDownloadTransporterViewModel>> GetClientReportDownloadTransporterViewModel(int demandId, int clientId)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_ClientReport_DownloadTransporter @DemandId = @_DemandId, @ClientId = @_ClientId";
            command.Parameters.Add(new SqlParameter("@_DemandId", demandId));
            command.Parameters.Add(new SqlParameter("@_ClientId", clientId));

            await context.Database.OpenConnectionAsync();

            var viewModels = new List<ClientReportDownloadTransporterViewModel>();
            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
            {
                viewModels.Add(new ClientReportDownloadTransporterViewModel
                {
                    TransporterId = result["TransporterId"].GetIntFromDbDataReader().Value,
                    TransporterEnvironmentalDocumentationId = result["TransporterEnvironmentalDocumentationId"].GetIntFromDbDataReader().Value,
                    DocumentName = result["DocumentName"].GetStringFromDbDataReader(),
                    License = result["License"].GetStringFromDbDataReader(),
                    DueDate = result["DueDate"].GetDateTimeFromDbDataReader().Value,
                    TransporterCompanyName = result["TransporterCompanyName"].GetStringFromDbDataReader(),
                    TransporterDocument = result["TransporterDocument"].GetStringFromDbDataReader(),
                    TransporterIsCompany = result["TransporterIsCompany"].GetBoolFromDbDataReader().Value,
                    TransporterTradeName = result["TransporterTradeName"].GetStringFromDbDataReader(),
                });
            }

            return await Task.Run(() => viewModels);
        }

        public async Task<List<ClientReportCollectionMovementViewModel>> GetClientReportCollectionMovementViewModel(int? clientId, DateTime? startDate, DateTime? endDate)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_ClientReport_CollectionMovement @ClientId = @_ClientId, @StartDate = @_StartDate, @EndDate = @_EndDate";
            command.Parameters.Add(new SqlParameter("@_ClientId", clientId ?? (object)DBNull.Value));
            command.Parameters.Add(new SqlParameter("@_StartDate", startDate ?? (object)DBNull.Value));
            command.Parameters.Add(new SqlParameter("@_EndDate", endDate ?? (object)DBNull.Value));

            await context.Database.OpenConnectionAsync();

            var viewModels = new List<ClientReportCollectionMovementViewModel>();
            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
            {
                viewModels.Add(new ClientReportCollectionMovementViewModel
                {
                    AlternativeDemandDestinationId = result["AlternativeDemandDestinationId"].GetStringFromDbDataReader(),
                    AlternativeDemandId = result["AlternativeDemandId"].GetStringFromDbDataReader(),
                    DemandDestinationArrivedDate = result["DemandDestinationArrivedDate"].GetDateTimeFromDbDataReader(),
                    DemandVisitedDate = result["DemandVisitedDate"].GetDateTimeFromDbDataReader(),
                    CDF = result["CDF"].GetStringFromDbDataReader(),
                    CertificateId = result["CertificateId"].GetIntFromDbDataReader().Value,
                    CreatedDate = result["CreatedDate"].GetDateTimeFromDbDataReader().Value,
                    DemandDestinationId = result["DemandDestinationId"].GetIntFromDbDataReader(),
                    DemandId = result["DemandId"].GetIntFromDbDataReader().Value,
                    RecipientName = result["RecipientName"].GetStringFromDbDataReader(),
                    ResidueFamilyName = result["ResidueFamilyName"].GetStringFromDbDataReader(),
                    Weight = result["Weight"].GetDoubleFromDbDataReader().Value,
                });
            }

            return await Task.Run(() => viewModels);
        }


        public async Task<List<ResidueFamilyViewModel>> GetClientReportAvailableResidueFamilies(int clientId)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_ClientReport_GetAvailableResidueFamilies @ClientId = @_ClientId";
            command.Parameters.Add(new SqlParameter("@_ClientId", clientId));

            await context.Database.OpenConnectionAsync();

            var viewModels = new List<ResidueFamilyViewModel>();
            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
            {
                viewModels.Add(new ResidueFamilyViewModel
                {
                    ResidueFamilyId = result["ResidueFamilyId"].GetIntFromDbDataReader().Value,
                    Name = result["Name"].GetStringFromDbDataReader(),
                });
            }

            return await Task.Run(() => viewModels);
        }
    }
}
