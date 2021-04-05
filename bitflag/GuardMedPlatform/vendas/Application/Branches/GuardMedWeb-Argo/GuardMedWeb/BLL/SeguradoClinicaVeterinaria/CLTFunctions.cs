using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using GuardMedWeb.Models;
using BLL;

namespace GuardMedWeb.BLL.SeguradoClinicaVeterinaria
{
    public class CLTFunctions : BLLBasicFunctions<DAL.Clt, Models.CLTViewModel>
    {
        public CLTFunctions(GuardMedWebContext context)
            : base(context, "Cltid")
        {
        }

        public override int Create(CLTViewModel model)
        {
            var clt = new Clt
            {
                SeguradoClinicaVeterinariaId = model.SeguradoClinicaVeterinariaId,
                Cpf = model.CPF,
                DataNascimento = model.DataNascimento,
                Nome = model.Nome
            };

            this.dbSet.Add(clt);
            context.SaveChanges();

            return clt.Cltid;
        }

        public override void Delete(object id)
        {
            var clt = GetDataByID(id);

            this.dbSet.Remove(clt);
            context.SaveChanges();
        }

        public override List<CLTViewModel> GetDataViewModel(IQueryable<Clt> data)
        {
            return (from y in data
                    select new CLTViewModel
                    {
                        CLTId = y.Cltid,
                        CPF = y.Cpf,
                        DataNascimento = y.DataNascimento,
                        Nome = y.Nome,
                        SeguradoClinicaVeterinariaId = y.SeguradoClinicaVeterinariaId
                    }).ToList();
        }

        public override CLTViewModel GetDataViewModel(Clt data)
        {
            return new CLTViewModel
            {
                CLTId = data.Cltid,
                CPF = data.Cpf,
                DataNascimento = data.DataNascimento,
                Nome = data.Nome,
                SeguradoClinicaVeterinariaId = data.SeguradoClinicaVeterinariaId
            };
        }

        public override void Update(CLTViewModel model)
        {
            var clt = GetDataByID(model.CLTId);

            clt.SeguradoClinicaVeterinariaId = model.SeguradoClinicaVeterinariaId;
            clt.Cpf = model.CPF;
            clt.DataNascimento = model.DataNascimento;
            clt.Nome = model.Nome;

            dbSet.Update(clt);
            context.SaveChanges();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Clt;
        }
    }
}
