using AMaisImob_WEB.Models.Home;
using AMaisImob_WEB.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class HomeFunctions
    {
        private readonly AMaisImob_DB.Models.AMaisImob_HomologContext context;

        public HomeFunctions(AMaisImob_DB.Models.AMaisImob_HomologContext context)
        {
            this.context = context;
        }

        public async Task<HomeVIPViewModel> GetHomeVIPViewModel(int? realEstateAgencyId, int? realStateId)
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {

                command.CommandText = "pr_GetHomeVIPInformation @RealEstateAgencyId = @_RealEstateAgencyId, @RealEstateId = @_RealEstateId";
                command.Parameters.Add(new SqlParameter("@_RealEstateAgencyId", realEstateAgencyId ?? (object)DBNull.Value));
                command.Parameters.Add(new SqlParameter("@_RealEstateId", realStateId ?? (object)DBNull.Value));

                await context.Database.OpenConnectionAsync();

                using (var result = await command.ExecuteReaderAsync())
                {
                    while (result.Read())
                    {
                        return new HomeVIPViewModel
                        {
                            RealEstateAgencyId = realEstateAgencyId,
                            RealEstateId = realStateId,
                            CertificateActiveCount = result["CertificateActiveCount"].GetInt(),
                            CertificateActivePoints = result["CertificateActivePoints"].GetInt(),
                            CertificateContractualActiveCount = result["CertificateContractualActiveCount"].GetInt(),
                            CertificateContractualActivePoints = result["CertificateContractualActivePoints"].GetInt(),
                            CertificateContractualNewCount = result["CertificateContractualNewCount"].GetInt(),
                            CertificateContractualNewPoints = result["CertificateContractualNewPoints"].GetInt(),
                            CertificateRenewCount = result["CertificateRenewCount"].GetInt(),
                            CertificateRenewPoints = result["CertificateRenewPoints"].GetInt(),
                            CertificateSimulationCount = result["CertificateSimulationCount"].GetInt(),
                            CertificateSimulationPoints = result["CertificateSimulationPoints"].GetInt(),
                            NeededPoints = result["NeededPoints"].GetNullableInt(),
                            TotalPoints = result["TotalPoints"].GetNullableInt(),
                            VIP = result["VIP"].GetBool()
                        };
                    }
                }
            }
            return await Task.Run(() => new HomeVIPViewModel());
        }
    }
}
