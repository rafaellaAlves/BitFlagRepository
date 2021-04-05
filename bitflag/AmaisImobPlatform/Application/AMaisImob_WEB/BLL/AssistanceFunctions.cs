using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMaisImob_DB.Models;
using AMaisImob_WEB.Models;
using AMaisImob_WEB.Utils;
using BLL;
using Microsoft.EntityFrameworkCore;

namespace AMaisImob_WEB.BLL
{
    public class AssistanceFunctions : BLLBasicFunctions<AMaisImob_DB.Models.Assistance, AMaisImob_WEB.Models.AssistanceViewModel>
    {
        public AssistanceFunctions(AMaisImob_HomologContext context)
            : base(context, "AssistanceId")
        {
        }

        public override int Create(AssistanceViewModel model)
        {
            var assistance = new Assistance
            {
                Description = model.Description,
                Name = model.Name,
                Value = model.Value.Value,
                ReportCode = model.ReportCode
            };

            this.dbSet.Add(assistance);
            this.context.SaveChanges();

            return assistance.AssistanceId;
        }

        public override void Delete(object id)
        {
            var assistance = GetDataByID(id);

            assistance.IsDeleted = true;

            this.dbSet.Update(assistance);
            this.context.SaveChanges();
        }

        public override List<AssistanceViewModel> GetDataViewModel(IEnumerable<Assistance> data)
        {
            return (from y in data
                    select new AssistanceViewModel
                    {
                        AssistanceId = y.AssistanceId,
                        Description = y.Description,
                        IsDeleted = y.IsDeleted,
                        Name = y.Name,
                        Value = y.Value,
                        ReportCode = y.ReportCode
                    }).ToList();
        }

        public override AssistanceViewModel GetDataViewModel(Assistance data)
        {
            return new AssistanceViewModel
            {
                AssistanceId = data.AssistanceId,
                Description = data.Description,
                IsDeleted = data.IsDeleted,
                Name = data.Name,
                Value = data.Value,
                ReportCode = data.ReportCode
            };
        }

        public override void Update(AssistanceViewModel model)
        {
            var assistance = GetDataByID(model.AssistanceId);

            assistance.Description = model.Description;
            assistance.Name = model.Name;
            assistance.ReportCode = model.ReportCode;
            assistance.Value = model.Value.Value;

            this.dbSet.Update(assistance);
            this.context.SaveChanges();
        }

        public bool IsInCertificate(int id)
        {
            return this.context.Certificate.Any(x => x.AssistanceId == id && !x.IsDeleted);
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Assistance;
        }

        public List<AssistanceExportViewModel> GetAssistanceExport(int? realEstateId, DateTime refMonth)
        {
            var connection = context.Database.GetDbConnection();
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "[dbo].[pr_GetAssistanceExport]";

            var _realEstateId = command.CreateParameter();
            _realEstateId.ParameterName = "@RealEstateId";
            _realEstateId.Value = realEstateId ?? (object)DBNull.Value;
            command.Parameters.Add(_realEstateId);

            var _refMonth = command.CreateParameter();
            _refMonth.ParameterName = "@RefMonth";
            _refMonth.Value = refMonth;
            command.Parameters.Add(_refMonth);

            var reader = command.ExecuteReader();
            var certificates = new List<AssistanceExportViewModel>();
            while (reader.Read())
            {
                var certificate = new AssistanceExportViewModel
                {
                    Apolice = reader["Apolice"].GetString(),
                    ValorAssistencia = reader["ValorAssistencia"].GetDouble(),
                    Bairro = reader["Bairro"].GetString(),
                    CEP = reader["CEP"].GetString(),
                    Cidade = reader["Cidade"].GetString(),
                    Complemento = reader["Complemento"].GetString(),
                    Corretora = reader["Corretora"].GetString(),
                    CPFInquilino = reader["CPFInquilino"].GetString(),
                    CPFProprietario = reader["CPFProprietario"].GetString(),
                    DataDeInclusao = reader["DataDeInclusao"].GetDateTime().Value,
                    VigencyDate = reader["VigencyDate"].GetDateTime().Value,
                    Imobiliaria = reader["Imobiliaria"].GetString(),
                    LocalDeRisco = reader["LocalDeRisco"].GetString(),
                    NomeInquilino = reader["NomeInquilino"].GetString(),
                    NomeProprietario = reader["NomeProprietario"].GetString(),
                    Numero = reader["Numero"].GetString(),
                    Plano = reader["Plano"].GetString(),
                    Produto = reader["Produto"].GetString(),
                    Referencia = reader["Referencia"].GetString(),
                    TipoDeImovel = reader["TipoDeImovel"].GetString(),
                    UF = reader["UF"].GetString(),
                    ProductId = (int)reader["ProductId"],
                    AssistanceId = (int)reader["ProductId"],
                    NomeAssistancia = reader["NomeAssistancia"].GetString(),
                    AssistanceReportCode = reader["AssistanceReportCode"].GetString()
                };
                certificates.Add(certificate);
            }
            connection.Close();

            return certificates;
        }
    }
}
