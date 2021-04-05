using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Law
{
    public class LawChangeFunctions : BLLBasicFunctions<LawChange, LawChange>
    {
        public LawChangeFunctions(GLAS2Context context) : base(context, "LawChangeId")
        {
        }

        public override int Create(LawChange model)
        {
            this.dbSet.Add(model);
            return model.LawChangeId;
        }

        public override void Delete(object id)
        {
            var entity = GetDataByID(id);

            this.dbSet.Remove(entity);
            this.context.SaveChanges();
        }

        public override List<LawChange> GetDataViewModel(IQueryable<LawChange> data)
        {
            return data.ToList();
        }

        public override LawChange GetDataViewModel(LawChange data)
        {
            return data;
        }

        public override void Update(LawChange model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = this.context.LawChange;
        }

        public async Task DeleteByLawId(int lawId)
        {
            var entities = GetData(x => x.LawId == lawId);

            this.dbSet.RemoveRange(entities);
            await this.context.SaveChangesAsync();
        }
        public async Task CreateRange(List<LawChange> lawChanges)
        {
            await this.dbSet.AddRangeAsync(lawChanges);
            await this.context.SaveChangesAsync();
        }

        public async Task<List<int>> TryCreateRange(int lawId, List<LawChange> lawChanges)
        {
            var changedLaw = await context.Law.SingleAsync(x => x.LawId == lawId);

            lawChanges.ForEach(x => x.ChangedLawId = lawId);

            var r = new List<int>();
            foreach (var item in lawChanges)
            {
                if (await this.dbSet.AnyAsync(x => x.ChangedLawId == item.ChangedLawId && x.LawId == item.LawId)) continue;

                r.Add(item.LawId);
                await this.dbSet.AddAsync(item);

                var law = await context.Law.SingleAsync(x => x.LawId == item.LawId);

                law.AlteredDate = changedLaw.ForceDate;
                law.AlteredBy = $"{changedLaw.Number} - {(changedLaw.Title.Length > 50 ? changedLaw.Title.Substring(0, 50) + "..." : changedLaw.Title)}";
                this.context.Law.Update(law);
            }

            await this.context.SaveChangesAsync();

            return r;
        }

        public async Task DeleteRangeFromLawIdExcept(int lawId, IEnumerable<int> lawIds)
        {
            var changedLaw = await context.Law.SingleAsync(x => x.LawId == lawId);

            dbSet.RemoveRange(GetData(x => !lawIds.Contains(x.LawId) && x.ChangedLawId == lawId));

            await this.context.SaveChangesAsync();
        }

        public IQueryable<DAL.Law> GetLawChangesFromLawId(int lawId) => (from lc in this.dbSet
                                                                         join l in this.context.Law on lc.ChangedLawId equals l.LawId
                                                                         where lc.LawId == lawId
                                                                         select l);
    }
}
