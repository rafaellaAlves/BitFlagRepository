using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace BLL.Law
{
    public class LawViewFunctions : BLLBasicFunctions<DAL.LawView, DAL.LawView>
    {
        public LawViewFunctions(DAL.GLAS2Context context)
           : base(context, "LawId")
        {
        }

        public override int Create(LawView model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<LawView> GetDataViewModel(IQueryable<LawView> data)
        {
            return data.ToList();
        }

        public override LawView GetDataViewModel(LawView data)
        {
            return data;
        }

        public override void Update(LawView model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.LawView;
        }

        public List<DTO.Law.LawExportViewModel> GetDataExport(DateTime? startCreatedDate, DateTime? endCreatedDate, int? orgao, int? segmento, int? esfera, int? type, int? aplicabilidade, int? CountryId, int? StateId, int? CityId, int? questionThemeId, int? questionSubThemeId)
        {
            var r = new List<DTO.Law.LawExportViewModel>();

            #region [Executar Proc]
            var connection = (SqlConnection)context.Database.GetDbConnection();

            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "pr_GetLawExport";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@StartCreatedDate", startCreatedDate ?? (object)DBNull.Value));
            command.Parameters.Add(new SqlParameter("@EndCreatedDate", endCreatedDate ?? (object)DBNull.Value));
            command.Parameters.Add(new SqlParameter("@Orgao", orgao ?? (object)DBNull.Value));
            command.Parameters.Add(new SqlParameter("@Segmento", segmento ?? (object)DBNull.Value));
            command.Parameters.Add(new SqlParameter("@Esfera", esfera ?? (object)DBNull.Value));
            command.Parameters.Add(new SqlParameter("@LawType", type ?? (object)DBNull.Value));
            command.Parameters.Add(new SqlParameter("@LawApplicationTypeId", aplicabilidade ?? (object)DBNull.Value));
            command.Parameters.Add(new SqlParameter("@CountryId", CountryId ?? (object)DBNull.Value));
            command.Parameters.Add(new SqlParameter("@StateId", StateId ?? (object)DBNull.Value));
            command.Parameters.Add(new SqlParameter("@CityId", CityId ?? (object)DBNull.Value));
            command.Parameters.Add(new SqlParameter("@QuestionThemeId", questionThemeId ?? (object)DBNull.Value));
            command.Parameters.Add(new SqlParameter("@QuestionSubThemeId", questionSubThemeId ?? (object)DBNull.Value));

            var objs = new List<Dictionary<string, object>>();
            using (var reader = command.ExecuteReader())
            {
                do
                {
                    while (reader.Read())
                    {
                        var o = new Dictionary<string, object>();

                        for (int j = 0; j < reader.FieldCount; j++)
                            o.Add(reader.GetName(j), reader[j] == (DBNull.Value) ? null : reader[j]);

                        objs.Add(o);
                    }
                } while (reader.NextResult());
            }

            command.Parameters.Clear();
            connection.Close();
            #endregion

            #region [Inserir no ViewModel]

            r = (from y in objs
                 group y by new
                 {
                     LawId = (int)y["LawId"],
                     CityName = (string)y["CityName"],
                     Comments = (string)y["Comments"],
                     CountryName = (string)y["CountryName"],
                     EsferaName = (string)y["EsferaName"],
                     ForceDate = (DateTime?)y["ForceDate"],
                     Keywords = (string)y["Keywords"],
                     LawTypeName = (string)y["LawTypeName"],
                     Number = (string)y["Number"],
                     OrgaoName = (string)y["OrgaoName"],
                     PublishDate = (DateTime?)y["PublishDate"],
                     RevokedBy = (string)y["RevokedBy"],
                     RevokedDate = (DateTime?)y["RevokedDate"],
                     SegmentoName = (string)y["SegmentoName"],
                     StateName = (string)y["StateName"],
                     Summary = (string)y["Summary"],
                     Title = (string)y["Title"],
                     LawVerificationCount = (int)y["LawVerificationCount"],
                     LawChangesBy = (string)y["LawChangesBy"],
                     LawChangesFrom = (string)y["LawChangesFrom"],
                     RevokedFrom = (string)y["RevokedFrom"],
                     AlteredDate = (DateTime?)y["AlteredDate"],
                 } into x
                 select new DTO.Law.LawExportViewModel
                 {
                     CityName = x.Key.CityName,
                     Comments = x.Key.Comments,
                     CountryName = x.Key.CountryName,
                     EsferaName = x.Key.EsferaName,
                     ForceDate = x.Key.ForceDate,
                     Keywords = x.Key.Keywords,
                     LawId = x.Key.LawId,
                     LawTypeName = x.Key.LawTypeName,
                     Number = x.Key.Number,
                     OrgaoName = x.Key.OrgaoName,
                     PublishDate = x.Key.PublishDate,
                     RevokedBy = x.Key.RevokedBy,
                     RevokedDate = x.Key.RevokedDate,
                     SegmentoName = x.Key.SegmentoName,
                     StateName = x.Key.StateName,
                     Summary = x.Key.Summary,
                     Title = x.Key.Title,
                     LawChangesBy = x.Key.LawChangesBy,
                     LawChangesFrom = x.Key.LawChangesFrom,
                     RevokedFrom = x.Key.RevokedFrom,
                     AlteredDate = x.Key.AlteredDate,
                     LawVerificationCount = x.Key.LawVerificationCount,
                     CompanyName = x.Where(c => !string.IsNullOrWhiteSpace((string)c["CompanyCNPJ"])).Select(c => (string)c["CompanyName"]).ToList(),
                     CompanyCNPJ = x.Where(c => !string.IsNullOrWhiteSpace((string)c["CompanyCNPJ"])).Select(c => (string)c["CompanyCNPJ"]).ToList(),
                     LawApplicationTypeName = x.Where(c => !string.IsNullOrWhiteSpace((string)c["CompanyCNPJ"])).Select(c => (string)c["LawApplicationTypeName"]).ToList(),
                 }).ToList();

            #endregion
            return r;
        }
    }
}
