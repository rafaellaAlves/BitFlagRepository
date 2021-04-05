using AMaisImob_DB.Models;
using AMaisImob_WEB.Models;
using AMaisImob_WEB.Utils;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class ChargeFunctions : BLLBasicFunctions<Charge, ChargeViewModel>
    {
        private BLL.CompanyFunctions companyFunctions;
        private BLL.SystemVariableFunctions systemVariableFunctions;
        private BLL.IUGU.IUGU iUGU;

        public ChargeFunctions(AMaisImob_HomologContext context)
            : base(context, "ChargeId")
        {
            companyFunctions = new CompanyFunctions(context);
            systemVariableFunctions = new SystemVariableFunctions(context);
            string IUGUToken = systemVariableFunctions.GetSystemVariable("TokenIUGU");
            iUGU = new IUGU.IUGU(IUGUToken, context);
        }

        public async Task<int> ChargeActiveRealEstate(int? realEstateAgencyId, int? realEstateId, DateTime mouthRefence)
        {
            int createdCount = 0;

            if (realEstateId.HasValue)
            {
                var id = await Charge(realEstateId.Value, mouthRefence);
                if (id != -1)
                    createdCount++;
            }
            else if (realEstateAgencyId.HasValue)
            {
                var companies = companyFunctions.GetRealEstate().Where(x => x.IsActive && !x.IsDeleted && x.ParentCompanyId == realEstateAgencyId);

                foreach (var realEstate in companies)
                {
                    var id = await Charge(realEstate.CompanyId, mouthRefence);
                    if (id != -1) createdCount++;
                }
            }
            else
            {
                var companies = companyFunctions.GetRealEstate().Where(x => x.IsActive && !x.IsDeleted);

                foreach (var realEstate in companies)
                {
                    var id = await Charge(realEstate.CompanyId, mouthRefence);
                    if (id != -1) createdCount++;
                }
            }

            return createdCount;
        }

        public async Task<int> ChargeActiveRealEstate(int? realEstateAgencyId, int? realEstateId, string _mouthRefence)
        {
            var mouthRefence = _mouthRefence.FromDatePtBR();

            return await ChargeActiveRealEstate(realEstateAgencyId, realEstateId, mouthRefence.Value);
        }

        public async Task<int> Charge(ChargeViewModel model)
        {
            var company = companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(model.RealEstateId));
            var price_cents = Convert.ToInt32(Math.Round(model.Price, 2) * 100d);

            var r = await iUGU.AddInvoice(company, model.IUGUDescription, price_cents, model.DueDate.Value);

            model.IUGUUrl = (string)r.Data["secure_url"];
            var id = Create(model);

            return id;
        }

        public async Task<int> Charge(int realEstateId, string _mouthRefence)
        {
            var mouthRefence = _mouthRefence.FromDatePtBR();
            return await Charge(realEstateId, mouthRefence.Value);
        }

        public async Task<int> Charge(int realEstateId, DateTime mouthRefence)
        {
            var price = GetTotalPrice(realEstateId, mouthRefence, out int count);

            var price_cents = Convert.ToInt32(Math.Round(price, 2) * 100d);
            if (price_cents == 0) return -1;

            var dueDate = new DateTime(DateTime.Now.AddMonths(1).Year, DateTime.Now.AddMonths(1).Month, 15);

            if (new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15).CompareTo(DateTime.Now) > 0)
            {
                dueDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15);
            }

            var model = new Models.ChargeViewModel()
            {
                RealEstateId = realEstateId,
                Description = $"{count} ativos",
                Price = price,
                ReferenceDate = mouthRefence,
                DueDate = dueDate,
                CreateDate = DateTime.Now,
                IUGUUrl = string.Empty,
                IsPayed = false,
                IUGUDescription = $"Boleto - {mouthRefence.ToShortDatePtBR()}",
                PayedToken = ReferenceUtils.GetReference()
            };

            var company = companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(realEstateId));
            var id = Create(model);// criado registro antes do boleto para usar o chargeId no link da IUGU
            model.ChargeId = id;

            var r = await iUGU.AddInvoice(company, model.IUGUDescription, price_cents, model.DueDate.Value);
            if (!r.Data.ContainsKey("secure_url") || !r.Data.ContainsKey("id"))
            {
                Delete(id); // se der erro deleta o registro criado
                return -1;
            }

            model.IUGUUrl = (string)r.Data["secure_url"];
            model.IUGUInvoiceId = (string)r.Data["id"];

            Update(model);
            return id;
        }

        public override int Create(ChargeViewModel model)
        {
            var entity = model.CopyToEntity<Charge>();
            entity.CreateDate = DateTime.Now;

            this.dbSet.Add(entity);
            this.context.SaveChanges();

            return entity.ChargeId;
        }

        public override void Delete(object id)
        {
            var charge = GetDataByID(id);

            this.dbSet.Remove(charge);
            this.context.SaveChanges();
        }

        public async Task<bool> Delete(object id, string iuguInvoiceId)
        {
            //var r = await iUGU.CancelInvoice(iuguInvoiceId);

            //if (r.Status != System.Net.HttpStatusCode.OK) return false;

            var charge = GetDataByID(id);

            this.dbSet.Remove(charge);
            this.context.SaveChanges();

            return true;
        }

        public override List<ChargeViewModel> GetDataViewModel(IEnumerable<Charge> data) => data.Select(x => x.CopyToEntity<ChargeViewModel>()).ToList();

        public override ChargeViewModel GetDataViewModel(Charge data) => data.CopyToEntity<ChargeViewModel>();

        public override void Update(ChargeViewModel model)
        {
            var charge = this.GetDataByID(model.ChargeId);

            charge.RealEstateId = model.RealEstateId;
            charge.Description = model.Description;
            charge.Price = model.Price;
            charge.ReferenceDate = model.ReferenceDate;
            charge.DueDate = model.DueDate;
            charge.IsPayed = false;
            charge.IUGUUrl = model.IUGUUrl;
            charge.IUGUInvoiceId = model.IUGUInvoiceId;
            charge.TotalCertificate = model.TotalCertificate;
            charge.TotalDocuSign = model.TotalDocuSign;
            charge.PriceCertificate = model.PriceCertificate;
            charge.PriceDocuSign = model.PriceDocuSign;
            charge.AlternativePriceCertificate = model.AlternativePriceCertificate;
            charge.AlternativePriceDocuSign = model.AlternativePriceDocuSign;
            charge.AlternativeTotalCertificate = model.AlternativeTotalCertificate;
            charge.AlternativeTotalDocuSign = model.AlternativeTotalDocuSign;

            this.context.Update(charge);
            this.context.SaveChanges();
        }

        public void Paid(int chargeId, bool payed, bool removePayedToken = false)
        {
            var charge = this.GetDataByID(chargeId);

            charge.IsPayed = payed;
            charge.PayedDate = DateTime.Now;
            if (removePayedToken) charge.PayedToken = null;

            this.context.Update(charge);
            this.context.SaveChanges();
        }

        public void PaidByUser(int userId, int chargeId, bool payed, bool removePayedToken = false)
        {
            var charge = this.GetDataByID(chargeId);

            charge.IsPayed = payed;
            charge.PayedBy = userId;
            charge.PayedDate = DateTime.Now;
            if (removePayedToken) charge.PayedToken = null;

            this.context.Update(charge);
            this.context.SaveChanges();
        }

        public void UpdatePaid(int chargeId, DateTime paymentDate)
        {
            var charge = this.GetDataByID(chargeId);

            charge.IsPayed = true;
            charge.PayedDate = paymentDate;

            this.context.Update(charge);
            this.context.SaveChanges();
        }

        public bool ValidatePayedToken(int chargeId, string token)
        {
            return this.dbSet.Any(c => c.ChargeId == chargeId && c.PayedToken == token);
        }

        public List<ChargeViewModel> GetCharges(int? realEstateAgencyId, int? realEstateId, DateTime referenceMonth)
        {
            var connection = context.Database.GetDbConnection();
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "[dbo].[pr_GetCharges]";

            var _realEstateAgencyId = command.CreateParameter();
            _realEstateAgencyId.ParameterName = "@RealEstateAgencyId";
            _realEstateAgencyId.Value = (object)realEstateAgencyId ?? DBNull.Value;
            command.Parameters.Add(_realEstateAgencyId);

            var _realEstateId = command.CreateParameter();
            _realEstateId.ParameterName = "@RealEstateId";
            _realEstateId.Value = (object)realEstateId ?? DBNull.Value;
            command.Parameters.Add(_realEstateId);

            var _refMonth = command.CreateParameter();
            _refMonth.ParameterName = "@RefMonth";
            _refMonth.Value = referenceMonth;
            command.Parameters.Add(_refMonth);

            var reader = command.ExecuteReader();
            var certificates = new List<ChargeViewModel>();
            while (reader.Read())
            {
                var certificate = new ChargeViewModel
                {
                    ChargeId = reader["ChargeId"].GetInt(),
                    CreateDate = reader["CreateDate"].GetDateTime().Value,
                    Description = reader["Description"].GetString(),
                    DueDate = reader["DueDate"].GetDateTime().Value,
                    IsPayed = reader["IsPayed"].GetBool().Value,
                    IUGUInvoiceId = reader["IUGUInvoiceId"].GetString(),
                    IUGUUrl = reader["IUGUUrl"].GetString(),
                    PayedDate = reader["PayedDate"].GetDateTime(),
                    PayedToken = reader["PayedToken"].GetNullableString(),
                    Price = reader["Price"].GetDouble(),
                    RealEstateId = reader["RealEstateId"].GetInt(),
                    ReferenceDate = reader["ReferenceDate"].GetDateTime().Value,
                    CompanyName = reader["CompanyName"].GetString(),
                    PayedBy = reader["PayedBy"].GetNullableInt()
                };
                certificates.Add(certificate);
            }
            connection.Close();

            return certificates;
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Charge;
        }

        public double GetTotalPrice(int? realEstateId, DateTime refMonth, out int count)
        {
            var connection = context.Database.GetDbConnection();
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "[dbo].[pr_GetCertificatePrices]";

            var _realEstateId = command.CreateParameter();
            _realEstateId.ParameterName = "@RealEstateId";
            _realEstateId.Value = (object)realEstateId ?? DBNull.Value;
            command.Parameters.Add(_realEstateId);

            var _refMonth = command.CreateParameter();
            _refMonth.ParameterName = "@RefMonth";
            _refMonth.Value = refMonth;
            command.Parameters.Add(_refMonth);

            var reader = command.ExecuteReader();
            List<double> planPrices = new List<double>();
            List<double> assistancePrices = new List<double>();
            while (reader.Read())
            {
                planPrices.Add(reader["PlanPrice"].GetDouble());
                assistancePrices.Add(reader["AssistancePrice"].GetDouble());
            }
            connection.Close();

            count = planPrices.Count;

            return planPrices.Sum(x => Math.Round(x, 2, MidpointRounding.AwayFromZero)) + assistancePrices.Sum(x => Math.Round(x, 2, MidpointRounding.AwayFromZero));
        }

        public double GetPrice(int month, int year, int? companyId)
        {
            AMaisImob_DB.Models.Company company = null;
            IQueryable<Charge> charges = null;
            if (companyId.HasValue)
            {
                company = companyFunctions.GetDataByID(companyId);

                if (company.CompanyTypeId == 2)
                {
                    charges = GetData().Where(x => x.DueDate.HasValue && x.DueDate.Value.Month == month && x.DueDate.Value.Year == year && x.RealEstateId == companyId);
                }
                else if (company.CompanyTypeId == 1)
                {
                    var sons = companyFunctions.GetRealEstatesByRealEstateAgencyId(companyId.Value).Select(x => x.CompanyId);

                    charges = GetData().Where(x => x.DueDate.HasValue && x.DueDate.Value.Month == month && x.DueDate.Value.Year == year && sons.Contains(x.RealEstateId));
                }
            }
            else
            {
                charges = this.GetData().Where(x => x.DueDate.HasValue && x.DueDate.Value.Month == month && x.DueDate.Value.Year == year);
            }

            return charges.Sum(z => z.Price);

        }

        public bool WasPaid(int realStateId, DateTime refMonth)
        {
            var paid = this.GetData().FirstOrDefault(x => x.RealEstateId == realStateId && x.DueDate.HasValue && x.DueDate.Value.Month == refMonth.Month && x.DueDate.Value.Year == refMonth.Year);
            if (paid == null)
            {
                return false;
            }
            return paid.IsPayed;

        }
    }
}
