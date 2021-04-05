using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO.Law;
using DAL;

namespace BLL.Utils
{
    public class SegmentoFunctions : BLLBasicFunctions<Segmento, SegmentoViewModel>
    {
        public SegmentoFunctions(DAL.GLAS2Context context)
            : base(context, "SegmentoId")
        {
        }

        public override int Create(SegmentoViewModel model)
        {
            var segmento = new Segmento
            {
                Name = model.Name,
                Description = model.Description
            };

            this.dbSet.Add(segmento);
            this.context.SaveChanges();

            return segmento.SegmentoId;
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<SegmentoViewModel> GetDataViewModel(IQueryable<Segmento> data)
        {
            return (from y in data
                    select new SegmentoViewModel
                    {
                        SegmentoId = y.SegmentoId,
                        Description = y.Description,
                        Name = y.Name
                    }).ToList();
        }

        public override SegmentoViewModel GetDataViewModel(Segmento data)
        {
            return new SegmentoViewModel
            {
                SegmentoId = data.SegmentoId,
                Description = data.Description,
                Name = data.Name
            };
        }

        public override void Update(SegmentoViewModel model)
        {
            var segmento = this.GetDataByID(model.SegmentoId);

            segmento.Name = model.Name;
            segmento.Description = model.Description;

            this.dbSet.Update(segmento);
            this.context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Segmento;
        }
    }
}
