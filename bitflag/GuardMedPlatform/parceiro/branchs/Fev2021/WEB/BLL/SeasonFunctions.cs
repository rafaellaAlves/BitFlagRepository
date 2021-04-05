using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Models;
using WEB.Models;
using BLL;

namespace WEB.BLL
{
    public class SeasonFunctions : BLLBasicFunctions<DB.Models.Season, WEB.Models.SeasonViewModel>
    {
        public SeasonFunctions(Insurance_HomologContext context)
            : base(context, "SeasonId")
        {
        }

        public override int Create(SeasonViewModel model)
        {
            var season = new Season
            {
                EndDate = model.EndDate.Value,
                Name = model.Name,
                StartDate = model.StartDate.Value
            };

            this.dbSet.Add(season);
            this.context.SaveChanges();

            return season.SeasonId;
        }

        public override void Delete(object id)
        {
            var season = GetDataByID(id);

            season.IsDeleted = true;

            this.dbSet.Update(season);
            this.context.SaveChanges();
        }

        public override List<SeasonViewModel> GetDataViewModel(IEnumerable<Season> data)
        {
            return (from y in data
                    select new SeasonViewModel
                    {
                        EndDate = y.EndDate,
                        IsDeleted = y.IsDeleted,
                        Name = y.Name,
                        SeasonId = y.SeasonId,
                        StartDate = y.StartDate
                    }).ToList();
        }

        public override SeasonViewModel GetDataViewModel(Season data)
        {
            return new SeasonViewModel
            {
                EndDate = data.EndDate,
                IsDeleted = data.IsDeleted,
                Name = data.Name,
                SeasonId = data.SeasonId,
                StartDate = data.StartDate
            };
        }

        public override void Update(SeasonViewModel model)
        {
            var season = GetDataByID(model.SeasonId);

            season.StartDate = model.StartDate.Value;
            season.EndDate = model.EndDate.Value;
            season.Name = model.Name;

            this.dbSet.Update(season);
            this.context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Season;
        }
    }
}
