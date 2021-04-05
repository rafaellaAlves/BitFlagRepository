using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Company
{
    public class CompanyLawVisualizationFunctions : BLL.BLLBasicFunctions<CompanyLawVisualization, CompanyLawVisualization>
    {
        public CompanyLawVisualizationFunctions(GLAS2Context context) : base(context, "CompanyLawVisualizationId")
        {
        }

        public override int Create(CompanyLawVisualization model)
        {
            this.dbSet.Add(model);
            this.context.SaveChanges();

            return model.CompanyLawVisualizationId;
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<CompanyLawVisualization> GetDataViewModel(IQueryable<CompanyLawVisualization> data)
        {
            throw new NotImplementedException();
        }

        public override CompanyLawVisualization GetDataViewModel(CompanyLawVisualization data)
        {
            throw new NotImplementedException();
        }

        public override void Update(CompanyLawVisualization model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CompanyLawVisualization;
        }

        public async Task<bool> Exists (int companyLawId, int userId)
        {
            return await this.dbSet.AnyAsync(x => x.UserId == userId && x.CompanyLawId == companyLawId);
        }
    }
}
