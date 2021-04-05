using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.EntityFrameworkCore;
using VendasDbContext.Models;

namespace WEB.BLL
{
    public class VendasSystemVariableFunctions
    {
        readonly DbSet<SystemVariable> dbSet;
        readonly VendasContext context;

        public VendasSystemVariableFunctions(VendasContext context)
        {
            this.context = context;
            this.dbSet = context.SystemVariable;
        }

        public string GetSystemVariable(string key)
        {
            if (SystemVariableExists(key))
                return this.dbSet.Single(x => x.Key.ToUpper() == key.ToUpper()).Value;
            else
                return null;
        }

        public bool SystemVariableExists(string key)
        {
            return this.dbSet.Any(x => x.Key.ToUpper() == key.ToUpper());
        }
    }
}
