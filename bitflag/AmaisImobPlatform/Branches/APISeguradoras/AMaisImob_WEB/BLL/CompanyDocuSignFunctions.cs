using AMaisImob_DB.Models;
using AMaisImob_WEB.Models;
using AMaisImob_WEB.Utils;
using BLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class CompanyDocuSignFunctions : BLLBasicFunctions<CompanyDocuSign, CompanyDocuSignViewModel>
    {
        public CompanyDocuSignFunctions(AMaisImob_HomologContext context) : base(context, "CompanyDocuSignId")
        {
        }

        public override int Create(CompanyDocuSignViewModel model)
        {
            if(this.dbSet.Any(x => x.ReferenceDate == model.ReferenceDate && x.CompanyId == model.CompanyId)) //Nunca vai existir dois itens pra mesma empresa no mesmo mês
            {
                this.dbSet.RemoveRange(this.dbSet.Where(x => x.ReferenceDate == model.ReferenceDate && x.CompanyId == model.CompanyId));
                this.context.SaveChanges();
            }

            var entity = model.CopyToEntity<CompanyDocuSign>();

            this.dbSet.Add(entity);
            this.context.SaveChanges();

            return entity.CompanyDocuSignId;
        }

        public void TryDelete(int companyId, DateTime referenceDate)
        {
            if (this.dbSet.Any(x => x.ReferenceDate == referenceDate && x.CompanyId == companyId)) //Nunca vai existir dois itens pra mesma empresa no mesmo mês
            {
                this.dbSet.RemoveRange(this.dbSet.Where(x => x.ReferenceDate == referenceDate && x.CompanyId == companyId));
                this.context.SaveChanges();
            }
        }

        public override void Delete(object id) => throw new NotImplementedException();

        public override List<CompanyDocuSignViewModel> GetDataViewModel(IEnumerable<CompanyDocuSign> data) => data.Select(x => x.CopyToEntity<CompanyDocuSignViewModel>()).ToList();

        public override CompanyDocuSignViewModel GetDataViewModel(CompanyDocuSign data) => data.CopyToEntity<CompanyDocuSignViewModel>();

        public override void Update(CompanyDocuSignViewModel model)
        {
            var entity = GetDataByID(model.CompanyDocuSignId);

            entity.Amount = model.Amount;
            entity.Price = model.Price;
            entity.CategoryId = model.CategoryId;

            this.dbSet.Update(entity);
            this.context.SaveChanges();
        }

        public async Task<List<CompanyDocuSignViewModel>> GetDataByDate(DateTime referenceDate, int? realEstateAgencyId, int? realEstateId, int? categoryId)
        {
            var connection = context.Database.GetDbConnection();
            await connection.OpenAsync();

            var command = connection.CreateCommand();

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "[dbo].[pr_GetCompanyDocuSign]";

            var referenceDateParam = command.CreateParameter();
            referenceDateParam.ParameterName = "@ReferenceDate";
            referenceDateParam.Value = new DateTime(referenceDate.Year, referenceDate.Month, 1);
            command.Parameters.Add(referenceDateParam);

            var realEstateAgencyParam = command.CreateParameter();
            realEstateAgencyParam.ParameterName = "@RealEstateAgencyId";
            realEstateAgencyParam.Value = realEstateAgencyId;
            command.Parameters.Add(realEstateAgencyParam);

            var realEstateParam = command.CreateParameter();
            realEstateParam.ParameterName = "@RealEstateId";
            realEstateParam.Value = realEstateId;
            command.Parameters.Add(realEstateParam);

            var categoryParam = command.CreateParameter();
            categoryParam.ParameterName = "@CategoryId";
            categoryParam.Value = categoryId;
            command.Parameters.Add(categoryParam);

            var reader = await command.ExecuteReaderAsync();
            var companyDocuSign = new List<CompanyDocuSignViewModel>();
            while (reader.Read())
            {
                companyDocuSign.Add(new CompanyDocuSignViewModel
                {
                    Amount = reader["Amount"].GetInt(),
                    CategoryId = reader["CategoryId"].GetInt(),
                    CategoryDescription = reader["CategoryDescription"].GetString(),
                    CompanyDocuSignId = reader["CompanyDocuSignId"].GetNullableInt(),
                    CompanyId = reader["CompanyId"].GetInt(),
                    Price = reader["Price"].GetDouble(),
                    TotalPrice = reader["TotalPrice"].GetDouble(),
                    ReferenceDate = reader["ReferenceDate"].GetDateTime().Value,
                    Bonus = reader["Bonus"].GetString(),
                    CompanyTradeName = reader["CompanyTradeName"].GetString(),
                    CompanyName = reader["CompanyName"].GetString()
                });
            }
            connection.Close();

            return companyDocuSign;
        }

        protected override void SetDbSet() => this.dbSet = context.CompanyDocuSign;
    }
}
