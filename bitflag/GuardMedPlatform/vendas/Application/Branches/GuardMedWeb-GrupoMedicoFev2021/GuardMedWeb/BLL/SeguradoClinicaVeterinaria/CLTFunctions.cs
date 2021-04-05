using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuardMedWeb.DAL;
using GuardMedWeb.Models;
using BLL;

namespace GuardMedWeb.BLL.SeguradoClinicaVeterinaria
{
    public class CLTFunctions : BLLBasicFunctions<DAL.CLT, Models.CLTViewModel>
    {
        public CLTFunctions(GuardMedWebContext context)
            : base(context, "CLTId")
        {
        }

        public override int Create(CLTViewModel model)
        {
            var clt = new CLT
            {
                SeguradoClinicaVeterinariaId = model.SeguradoClinicaVeterinariaId,
                CPF = model.CPF,
                DataNascimento = model.DataNascimento,
                Nome = model.Nome
            };

            this.dbSet.Add(clt);
            context.SaveChanges();

            return clt.CLTId;
        }

        public override void Delete(object id)
        {
            var clt = GetDataByID(id);

            this.dbSet.Remove(clt);
            context.SaveChanges();
        }

        public override List<CLTViewModel> GetDataViewModel(IQueryable<CLT> data)
        {
            return (from y in data
                    select new CLTViewModel
                    {
                        CLTId = y.CLTId,
                        CPF = y.CPF,
                        DataNascimento = y.DataNascimento,
                        Nome = y.Nome,
                        SeguradoClinicaVeterinariaId = y.SeguradoClinicaVeterinariaId
                    }).ToList();
        }

        public override CLTViewModel GetDataViewModel(CLT data)
        {
            return new CLTViewModel
            {
                CLTId = data.CLTId,
                CPF = data.CPF,
                DataNascimento = data.DataNascimento,
                Nome = data.Nome,
                SeguradoClinicaVeterinariaId = data.SeguradoClinicaVeterinariaId
            };
        }

        public override void Update(CLTViewModel model)
        {
            var clt = GetDataByID(model.CLTId);

            clt.SeguradoClinicaVeterinariaId = model.SeguradoClinicaVeterinariaId;
            clt.CPF = model.CPF;
            clt.DataNascimento = model.DataNascimento;
            clt.Nome = model.Nome;

            dbSet.Update(clt);
            context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CLT;
        }
    }
}
