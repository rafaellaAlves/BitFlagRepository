using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Utils
{
    public static class SqlParameterUtils
    {
        public static void SetNewParameter(ref List<SqlParameter> param, ref string query, string newParamName, object parameter, string comparator = "=", string add = "AND")
        {
            if (!string.IsNullOrWhiteSpace(query)) query += $" {add} ";

            var paramRefName = GetParamReferenceName(query, newParamName);

            string parameterName = "";
            switch (comparator.ToUpper())
            {
                case "LIKE":
                    parameterName = "'%" + parameter + "%'";
                    break;
                case "IN":
                    parameterName = parameter.ToString();
                    break;
                default:
                    parameterName = paramRefName;
                    break;
            }

            query += $"{newParamName} " + comparator + $" {parameterName}";
            if (comparator.ToUpper() != "IN" && comparator.ToUpper() != "LIKE")
                param.Add(new SqlParameter(paramRefName, parameter ?? DBNull.Value));

        }

        private static string GetParamReferenceName(string query, string paramName)
        {
            int i = 1;

            var paramRefName = paramName + i;
            while (query.ToUpper().Contains(($"@{paramRefName}").ToUpper()))
            {
                i++;
                paramRefName = paramName + i;
            }

            return $"@{paramRefName}";
        }
    }
}
