using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Models;
using WEB.Models;
using BLL;

namespace WEB.BLL
{
    public class AssistanceFunctions : BLLBasicFunctions<DB.Models.Assistance, WEB.Models.AssistanceViewModel>
    {
        public AssistanceFunctions(Insurance_HomologContext context)
            : base(context, "AssistanceId")
        {
        }

        public override int Create(AssistanceViewModel model)
        {
            var assistance = new Assistance
            {
                Description = model.Description,
                Name = model.Name,
                Value = model.Value.Value
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
                        Value = y.Value
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
                Value = data.Value
            };
        }

        public override void Update(AssistanceViewModel model)
        {
            var assistance = GetDataByID(model.AssistanceId);

            assistance.Description = model.Description;
            assistance.Name = model.Name;
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
    }
}
