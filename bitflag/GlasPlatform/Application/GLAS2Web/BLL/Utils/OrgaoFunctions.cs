using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DTO.Law;

namespace BLL.Utils
{
    public class OrgaoFunctions : BLLBasicFunctions<DAL.Orgao,DTO.Law.OrgaoViewModel>
    {
        public OrgaoFunctions(DAL.GLAS2Context context)
            : base(context, "OrgaoId")
        {
        }

        public override int Create(OrgaoViewModel model)
        {
            var orgao = new Orgao
            {
                Name = model.Name,
                Description = model.Description
            };

            this.dbSet.Add(orgao);
            this.context.SaveChanges();

            return orgao.OrgaoId;
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<OrgaoViewModel> GetDataViewModel(IQueryable<Orgao> data)
        {
            return (from y in data
                    select new OrgaoViewModel
                    {
                        OrgaoId = y.OrgaoId,
                        Description = y.Description,
                        Name = y.Name
                    }).ToList();
        }

        public override OrgaoViewModel GetDataViewModel(Orgao data)
        {
            return new OrgaoViewModel
            {
                OrgaoId = data.OrgaoId,
                Description = data.Description,
                Name = data.Name
            };
        }

        public override void Update(OrgaoViewModel model)
        {
            var orgao = this.GetDataByID(model.OrgaoId);

            orgao.Name = model.Name;
            orgao.Description = model.Description;

            this.dbSet.Update(orgao);
            this.context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Orgao;
        }
    }
}
