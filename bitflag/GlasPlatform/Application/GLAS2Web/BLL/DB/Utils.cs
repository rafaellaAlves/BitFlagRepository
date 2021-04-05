using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Dynamic;
using System.Text;

namespace BLL.DB
{
    public class Utils
    {
        private readonly DbContext _context;
        public Utils(DbContext context)
        {
            this._context = context;
        }


        public List<ExpandoObject> GetData(string storedProcedure)
        {
            return GetData(storedProcedure, null);
        }

        public List<ExpandoObject> GetData(string storedProcedure, SqlParameter[] parameters)
        {
            List<ExpandoObject> l = new List<ExpandoObject>();

            this._context.Database.OpenConnection();
            try
            {
                using (var command = this._context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    if(parameters != null) command.Parameters.AddRange(parameters);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var o = new ExpandoObject() as IDictionary<string, object>;
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                o.Add(reader.GetName(i), reader[i]);
                            }
                            l.Add((ExpandoObject)o);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                var o = new ExpandoObject() as IDictionary<string, object>;

                o.Add("Error", e.Message);
                l.Add((ExpandoObject)o);
            }
            finally
            {
                this._context.Database.CloseConnection();
            }
            return l;
        }
    }
}
