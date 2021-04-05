using AMaisImob_DB.Models;
using AMaisImob_WEB.Models;
using AMaisImob_WEB.Models.Charge;
using AMaisImob_WEB.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class FinancialFunctions
    {
        private readonly AMaisImob_HomologContext context;
        private BLL.IUGU.IUGU iUGU;

        public FinancialFunctions(AMaisImob_HomologContext context, SystemVariableFunctions systemVariableFunctions)
        {
            this.context = context;

            iUGU = new IUGU.IUGU(systemVariableFunctions.GetSystemVariable("TokenIUGU"), context);

        }

        public async Task<List<CompanyChargeViewModel>> GetCompaniesForCharge(FinancialFilterViewModel filter, bool onlyWithInvoice)
        {
            var connection = context.Database.GetDbConnection();
            await connection.OpenAsync();

            var command = connection.CreateCommand();

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "[dbo].[pr_GetCompaniesForCharge]";

            var realEstateAgencyParam = command.CreateParameter();
            realEstateAgencyParam.ParameterName = "@RealEstateAgencyId";
            realEstateAgencyParam.Value = filter.RealEstateAgencyId ?? (object)DBNull.Value;
            command.Parameters.Add(realEstateAgencyParam);

            var realEstateParam = command.CreateParameter();
            realEstateParam.ParameterName = "@RealEstateId";
            realEstateParam.Value = filter.RealEstateId ?? (object)DBNull.Value;
            command.Parameters.Add(realEstateParam);

            var referenceDateParam = command.CreateParameter();
            referenceDateParam.ParameterName = "@ReferenceDate";
            referenceDateParam.Value = filter.ReferenceDate.HasValue? new DateTime(filter.ReferenceDate.Value.Year, filter.ReferenceDate.Value.Month, 1) : (object)DBNull.Value;
            command.Parameters.Add(referenceDateParam);

            var startDateParam = command.CreateParameter();
            startDateParam.ParameterName = "@StartDate";
            startDateParam.Value = filter.StartDate.HasValue ? new DateTime(filter.StartDate.Value.Year, filter.StartDate.Value.Month, 1) : (object)DBNull.Value;
            command.Parameters.Add(startDateParam);

            var endDateParam = command.CreateParameter();
            endDateParam.ParameterName = "@EndDate";
            endDateParam.Value = filter.EndDate.HasValue ? new DateTime(filter.EndDate.Value.Year, filter.EndDate.Value.Month, 1) : (object)DBNull.Value;
            command.Parameters.Add(endDateParam);

            var chargeContractualGuaranteeParam = command.CreateParameter();
            chargeContractualGuaranteeParam.ParameterName = "@ChargeContractualGuarantee";
            chargeContractualGuaranteeParam.Value = filter.ChargeContractualGuarantee;
            command.Parameters.Add(chargeContractualGuaranteeParam);

            var onlyWithInvoiceParam = command.CreateParameter();
            onlyWithInvoiceParam.ParameterName = "@OnlyWithInvoice";
            onlyWithInvoiceParam.Value = onlyWithInvoice;
            command.Parameters.Add(onlyWithInvoiceParam);

            var reader = await command.ExecuteReaderAsync();
            var certificates = new List<CompanyChargeViewModel>();
            while (reader.Read())
            {
                certificates.Add(new CompanyChargeViewModel
                {
                    ChargeId = reader["ChargeId"].GetNullableInt(),
                    IsLocked = reader["IsLocked"].GetBool().Value,
                    AllFilesUploaded = reader["AllFilesUploaded"].GetBool().Value,
                    CompanyName = reader["CompanyName"].GetString(),
                    CompanyTradeName = reader["CompanyTradeName"].GetString(),
                    CreateDate = reader["CreateDate"].GetDateTime(),
                    InvoiceDate = reader["InvoiceDate"].GetDateTime(),
                    DueDate = reader["DueDate"].GetDateTime(),
                    PayedDate = reader["PayedDate"].GetDateTime(),
                    RealEstateId = reader["RealEstateId"].GetInt(),
                    CompanyChargeContractualGuarantee = reader["CompanyChargeContractualGuarantee"].GetBool().Value,
                    RealEstateAgencyId = reader["RealEstateAgencyId"].GetInt(),
                    ParentCompanyName = reader["ParentCompanyName"].GetString(),
                    ParentCompanyTradeName = reader["ParentCompanyTradeName"].GetString(),
                    IUGUUrl = reader["IUGUUrl"].GetNullableString(),
                    ReferenceDate = reader["ReferenceDate"].GetDateTime(),
                    IUGUInvoiceId = reader["IUGUInvoiceId"].GetNullableString()
                });
            }
            connection.Close();

            return certificates;
        }

        public async Task<List<ChargePriceItem>> GetValuesForCharge(int? realEstateId, DateTime referenceDate)
        {
            var connection = context.Database.GetDbConnection();
            await connection.OpenAsync();

            var command = connection.CreateCommand();

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "[dbo].[pr_GetValuesForCharge]";

            var realEstateParam = command.CreateParameter();
            realEstateParam.ParameterName = "@RealEstateId";
            realEstateParam.Value = realEstateId ?? (object)DBNull.Value;
            command.Parameters.Add(realEstateParam);

            var referenceDateParam = command.CreateParameter();
            referenceDateParam.ParameterName = "@ReferenceDate";
            referenceDateParam.Value = new DateTime(referenceDate.Year, referenceDate.Month, 1);
            command.Parameters.Add(referenceDateParam);

            var reader = await command.ExecuteReaderAsync();
            var certificates = new List<ChargePriceItem>();
            do
            {
                while (reader.Read())
                {
                    certificates.Add(new ChargePriceItem
                    {
                        Name = reader["Name"].GetString(),
                        Amount = reader["TotalCount"].GetInt(),
                        AlternativeAmount = reader["AlternativeTotalCount"].GetNullableInt(),
                        Price = reader["TotalPrice"].GetDouble(),
                        AlternativeTotalPrice = reader["AlternativeTotalPrice"].GetDoubleNullable(),
                        CertificateContractual = reader["CertificateContractual"].GetBool().Value,
                        Certificate = reader["Certificate"].GetBool().Value,
                        DocuSign = reader["DocuSign"].GetBool().Value,
                        Order = reader["Order"].GetInt(),
                        GuarantorId = reader["GuarantorId"].GetInt(),
                        ChargeCertificateContractualId = reader["ChargeCertificateContractualId"].GetNullableInt(),
                        CertificateContractualHasFile = reader["CertificateContractualHasFile"].GetBool(),
                        CertificateContractualHasInvoiceFile = reader["CertificateContractualHasInvoiceFile"].GetBool(),
                        ChargeCreatedDate = reader["ChargeCreatedDate"].GetDateTime()
                    });
                }
            } while (reader.NextResult());

            connection.Close();

            return certificates.Where(x => x.Amount > 0).OrderBy(x => x.Order).ToList();
        }

        public async Task<ChargeResult> Charge(int chargeId)
        {
            var charge = await this.context.Charge.SingleAsync(x => x.ChargeId == chargeId);
            var company = (await this.context.Company.SingleAsync(x => x.CompanyId == charge.RealEstateId)).CopyToEntity<CompanyViewModel>();

            var user_Partner = await GetUserPartner(charge.RealEstateId);

            if (charge.IsLocked) return new ChargeResult
            {
                ChargeId = chargeId,
                Message = "Já foi gerado um boleto para esta imobilíaria.",
                Success = false,
                RealEstate = company
            };

            var values = await GetValuesForCharge(charge.RealEstateId, charge.ReferenceDate);

            var totalPrice = values.Sum(x => x.CertificateContractual && company.ChargeContractualGuarantee == false? 0 : x.AlternativeTotalPrice ?? x.Price);
            if (totalPrice == 0)
            {
                if (values.Count(x => x.CertificateContractual && company.ChargeContractualGuarantee == false) == values.Count)// Se todos os itens desta cobrança são garantias contratuas que não precisam ser pagas o 
                {
                    await UpdateCharge(charge, totalPrice, null, null, null, true);
                    return new ChargeResult
                    {
                        ChargeId = chargeId,
                        Message = "O boleto foi encerrado e os e-mails enviados. Não foi gerado boleto na IUGU já que o valor seria de com R$0,00.",
                        Success = true,
                        RealEstate = company
                    };
                }
                else
                {
                    return new ChargeResult
                    {
                        ChargeId = chargeId,
                        Message = "O valor do boleto seria de com R$0,00.",
                        Success = false,
                        RealEstate = company
                    };
                }
            }

            var dueDate = new DateTime(DateTime.Now.AddMonths(1).Year, DateTime.Now.AddMonths(1).Month, 15); // dia 15 do próximo mês

            if (new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15).CompareTo(DateTime.Now) > 0) // se o dia atual ainda é anterior ao dia 15, então o vencimento será no dia 15 do mês atual
                dueDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15);

            var r = await iUGU.AddInvoice(company, dueDate, values, charge, company.Email?? user_Partner?.Email);

            if (!r.Data.ContainsKey("secure_url") || !r.Data.ContainsKey("id"))
            {
                string erro = null;
                if (r.Data.ContainsKey("errors"))
                {
                    var _erro = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(r.Data["errors"].ToString());
                    erro = $"(IUGU) {_erro.First().Key}: {_erro.First().Value}";
                }

                return new ChargeResult
                {
                    ChargeId = chargeId,
                    Message = erro ?? "Houve um erro ao gerar o boleto.",
                    Success = false,
                    RealEstate = (await this.context.Company.SingleAsync(x => x.CompanyId == charge.RealEstateId)).CopyToEntity<CompanyViewModel>()
                };
            }

            await UpdateCharge(charge, totalPrice, dueDate, (string)r.Data["secure_url"], (string)r.Data["id"]);

            return new ChargeResult
            {
                ChargeId = chargeId,
                Message = "Boleto criado com sucesso!",
                Success = true,
                RealEstate = company
            };
        }

        async Task<User> GetUserPartner(int realEstateId)
        {
            var roleId_Partner = (await this.context.Role.SingleAsync(x => x.NormalizedName == "IMOBILIARIOSOCIO")).Id;
            var userIds = await this.context.UserCompany.Where(x => x.CompanyId == realEstateId).AsNoTracking().Select(x => x.UserId).ToListAsync();
            var userId_Partner = await this.context.AspNetUserRoles.FirstOrDefaultAsync(x => userIds.Contains(x.UserId) && x.RoleId == roleId_Partner);

            if (userId_Partner == null) return null;

            return await this.context.User.FirstAsync(x => userId_Partner.UserId == x.Id);

        }

        private async Task UpdateCharge(Charge charge, double totalPrice, DateTime? dueDate, string secure_url, string id, bool isPayed = false)
        {
            charge.Price = totalPrice;
            charge.DueDate = dueDate;
            charge.InvoiceDate = DateTime.Now;
            charge.IsPayed = isPayed;
            //charge.IUGUDescription = $"Boleto - {mouthRefence.ToShortDatePtBR()}";
            charge.PayedToken = ReferenceUtils.GetReference();
            charge.IUGUUrl = secure_url;
            charge.IUGUInvoiceId = id;
            charge.IsLocked = true;

            this.context.Charge.Update(charge);
            await this.context.SaveChangesAsync();
        }
    }
}
