using BLL;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasDbContext.Models;
using WEB.Models;
using WEB.Utils;

namespace WEB.BLL
{
    public class SeguradoProfissionalExtracaoFunctions : BLLListFunctions<VendasDbContext.Models.SeguradoProfissionalExtracaoView>
    {
        public SeguradoProfissionalExtracaoFunctions(VendasContext context) 
            : base(context, "SeguradoProfissionalId")
        {
        }

        public List<SeguradoProfissionalExtracaoViewModel> GetDataViewModel(IEnumerable<SeguradoProfissionalExtracaoView> data)
        {
            return data.Select(x => x.CopyToEntity<SeguradoProfissionalExtracaoViewModel>()).ToList();
        }

        protected override void SetDbSet()
        {
            this.dbSet = ((VendasContext)context).SeguradoProfissionalExtracaoView;
        }

        //public override void Delete(object id)
        //{
        //    var segurado = this.GetDataByID(id);

        //    segurado.IsDeleted = true;

        //    this.context.Update(segurado);
        //    this.context.SaveChanges();
        //}
    }
}
