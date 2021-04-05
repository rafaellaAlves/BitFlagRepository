using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DB.Models;
using VendasDbContext.Models;
using WEB.Models;

namespace WEB.BLL
{
    public class ReportFunctions
    {
        private VendasContext context;
        public ReportFunctions(VendasContext context)
        {
            this.context = context;
        }

        public void DeleteSeguradoProfissional(int id, int userId)
        {
            
            var seguradoProfissional = this.context.SeguradoProfissional.SingleOrDefault(x => x.SeguradoProfissionalId == id);
            


            if (seguradoProfissional == null)
            {
                return;
            }
            else 
            {
                seguradoProfissional.IsDeleted = true;
                seguradoProfissional.DeletedBy = userId;
                seguradoProfissional.DeletedDate = DateTime.Now;
            }

            this.context.Update(seguradoProfissional);
            this.context.SaveChanges();
        }

    }
}
