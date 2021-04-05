using AMaisImob_DB.Models;
using AMaisImob_WEB.Models;
using AMaisImob_WEB.Utils;
using BLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class CertificateContractualListViewFunctions : BLLBasicFunctions<CertificateContractualListView, CertificateContractualListViewModel>
    {
        public CertificateContractualListViewFunctions(AMaisImob_HomologContext context) : base(context, "CertificateContractualId")
        {
        }

        public override int Create(CertificateContractualListViewModel model) => throw new NotImplementedException();

        public override void Delete(object id) => throw new NotImplementedException();

        public override List<CertificateContractualListViewModel> GetDataViewModel(IEnumerable<CertificateContractualListView> data) => data.Select(x => x.CopyToEntity<CertificateContractualListViewModel>()).ToList();

        public override CertificateContractualListViewModel GetDataViewModel(CertificateContractualListView data) => data.CopyToEntity<CertificateContractualListViewModel>();

        public override void Update(CertificateContractualListViewModel model) => throw new NotImplementedException();

        protected override void SetDbSet() => this.dbSet = context.CertificateContractualListView;

        public double GetTotalGetTotalPriceFromList(Models.DataTablesAjaxPostModel filter, string additionalwhereSQL, SqlParameter[] whereParameters)
        {
            var whereSQL = new StringBuilder();
            var parameters = new List<SqlParameter>();

            #region [FILTER]
            if (string.IsNullOrWhiteSpace(additionalwhereSQL))
                whereSQL.Append("WHERE 1 = 1 AND ( ");
            else
                whereSQL.Append("WHERE (" + additionalwhereSQL + ") AND ( ");
            bool hasColumnFilter = false;

            if (!string.IsNullOrWhiteSpace(filter.search.value))
            {
                foreach (var q in filter.search.value.Split(','))
                {
                    whereSQL.Append("(");
                    foreach (var c in filter.columns)
                    {
                        if (string.IsNullOrWhiteSpace(c.data)) continue;
                        if (typeof(CertificateContractualListView).GetProperty(c.data) == null) continue;

                        var parameterGuid = "PARAM_" + Guid.NewGuid().ToString("N");
                        whereSQL.Append("(" + c.data + " LIKE @" + parameterGuid + ") OR ");
                        parameters.Add(new SqlParameter("@" + parameterGuid, "%" + q.Trim() + "%"));

                    }
                    whereSQL = new StringBuilder(whereSQL.ToString().Remove(whereSQL.ToString().LastIndexOf("OR "), 3));
                    whereSQL.Append(") AND ");
                    hasColumnFilter = true;
                }
            }

            if (!hasColumnFilter)
                whereSQL = new StringBuilder(whereSQL.ToString().Remove(whereSQL.ToString().LastIndexOf("AND ( "), 6));
            else
            {
                whereSQL = new StringBuilder(whereSQL.ToString().Remove(whereSQL.ToString().LastIndexOf("AND "), 4));
                whereSQL.Append(") ");
            }
            #endregion

            using (var connection = context.Database.GetDbConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT ROUND(SUM(ISNULL(CONVERT(FLOAT, InstallmentPrice), PriceQuote)), 2) AS TotalValor from CertificateContractualListView " +  whereSQL;
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddRange(whereParameters);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader["TotalValor"] == DBNull.Value ? 0 : (double)reader["TotalValor"];
                        }

                        return 0;
                    }
                }
            }
        }
    }
}
