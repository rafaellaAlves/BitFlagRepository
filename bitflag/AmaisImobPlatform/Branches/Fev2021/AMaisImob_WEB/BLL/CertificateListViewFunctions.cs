using AMaisImob_DB.Models;
using AMaisImob_WEB.Models;
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
    public class CertificateListViewFunctions : BLLBasicFunctions<CertificateListView, CertificateListViewModel>
    {
        public class CertificateTotals
        {
            //    totalValorSeguro += d.data[i].planAssistancePrice;
            //    totalTaxa += d.data[i].taxes;
            //    totalValor += d.data[i].totalPrice;
            public double TotalSeguro { get; set; }
            public double TotalTaxa { get; set; }
            public double TotalValor { get; set; }
        }

        public CertificateListViewFunctions(AMaisImob_HomologContext context) : base(context, "CertificateId")
        {
            
        }

        public CertificateTotals GetTotals(string whereSQL, SqlParameter[] whereParameters)
        {
            var sql = new StringBuilder();

            using (var connection = context.Database.GetDbConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT ROUND(SUM(planAssistancePrice), 2) AS TotalSeguro, ROUND(SUM(Taxes), 2) AS TotalTaxa, ROUND(SUM(TotalPrice), 2) AS TotalValor from CertificateListView " + (string.IsNullOrWhiteSpace(whereSQL) ? string.Empty : "WHERE (" + whereSQL + ")");
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddRange(whereParameters);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new CertificateTotals()
                            {
                                TotalSeguro = reader["TotalSeguro"] == DBNull.Value ? 0 : (double)reader["TotalSeguro"],
                                TotalValor = reader["TotalSeguro"] == DBNull.Value ? 0 : (double)reader["TotalValor"],
                                TotalTaxa = reader["TotalSeguro"] == DBNull.Value ? 0 : (double)reader["TotalTaxa"]
                            };
                        }

                        return new CertificateTotals();
                    }
                }
            }
        }

        public override int Create(CertificateListViewModel model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<CertificateListViewModel> GetDataViewModel(IEnumerable<CertificateListView> data)
        {
            return (from y in data
                    select new CertificateListViewModel
                    {
                        Reference = y.Reference,
                        Bairro = y.Bairro,
                        Cep = y.Cep,
                        ProductId = y.ProductId,
                        ProductName = y.ProductName,
                        Cidade = y.Cidade,
                        Complemento = y.Complemento,
                        Endereco = y.Endereco,
                        IsApproved = y.IsApproved,
                        LocatorCpf = y.LocatorCpf,
                        LocatorName = y.LocatorName,
                        Numero = y.Numero,
                        PropertyTypeDescription = y.PropertyTypeDescription,
                        PropertyTypeId = y.PropertyTypeId,
                        RenterCpf = y.RenterCpf,
                        RenterName = y.RenterName,
                        Uf = y.Uf,
                        CertificateId = y.CertificateId,
                        IsDeleted = y.IsDeleted,
                        PropertyTypeName = y.PropertyTypeName,
                        InsurancePolicyId = y.InsurancePolicyId,
                        InsurancePolicyNumber = y.InsurancePolicyNumber,
                        RealEstateAgencyId = y.RealEstateAgencyId,
                        RealEstateAgencyName = y.RealEstateAgencyName,
                        RealEstateAgencyCNPJ = y.RealEstateAgencyCNPJ,
                        RealEstateAgencyDocument = y.RealEstateAgencyDocument,
                        RealEstateId = y.RealEstateId,
                        RealEstateName = y.RealEstateName,
                        RealEstateCNPJ = y.RealEstateCNPJ,
                        RealEstateDocument = y.RealEstateDocument,
                        RenterPhone = y.RenterPhone,
                        RenterEmail = y.RenterEmail,
                        CreatedDate = y.CreatedDate,
                        ApprovedBy = y.ApprovedBy,
                        ApprovedDate = y.ApprovedDate,
                        TotalPrice = y.TotalPrice,
                        Taxes = y.Taxes,
                        RealEstateReference = y.RealEstateReference,
                        DeletedBy = y.DeletedBy,
                        DeletedDate = y.DeletedDate,
                        NameDeletedBy = y.NameDeletedBy,
                        CopiedFrom = y.CopiedFrom,
                        CopiedBy = y.CopiedBy,
                        PlanPrice = y.PlanPrice,
                        PlanAssistancePrice = y.PlanAssistancePrice,
                        PaymentTimes = y.PaymentTimes,
                        AdherenceDate = y.AdherenceDate,
                        VigencyDate = y.VigencyDate,
                        AdherenceBy = y.AdherenceBy,
                        NameAdherenceBy = y.NameAdherenceBy,
                        CreatedBy = y.CreatedBy,
                        NameCreatedBy = y.NameCreatedBy,
                        RenewBy = y.RenewBy,
                        NameRenewBy = y.NameRenewBy,
                        AssistanceName = y.AssistanceName,
                        ConstructionTypeName = y.ConstructionTypeName,
                        HabitationTypeName = y.HabitationTypeName,
                        PlanName = y.PlanName,
                        CopiedByReference = y.CopiedByReference,
                        ModifiedBy = y.ModifiedBy,
                        ModifiedDate = y.ModifiedDate,
                        NameModifiedBy = y.NameModifiedBy,
                        BlockRenew = y.BlockRenew
                        

                    }).ToList();

        }

        public override CertificateListViewModel GetDataViewModel(CertificateListView data)
        {
            throw new NotImplementedException();
        }

        public override void Update(CertificateListViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CertificateListView;
        }
    }
}
