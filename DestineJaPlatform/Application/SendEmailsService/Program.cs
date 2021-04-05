using Microsoft.EntityFrameworkCore;
using Services.Client;
using System;

namespace SendEmailsService
{
    class Program
    {
        static ApplicationDbContext.Context.ApplicationDbContext context;

        static void Main(string[] args)
        {

            context = new ApplicationDbContext.Context.ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext.Context.ApplicationDbContext>().UseSqlServer("Server=homolog.chokosys.com.br;Database=DestineJa_Dev;User Id=DestineJa;Password=6VZt7yp68yDT2n3j;MultipleActiveResultSets=true;", opt => { opt.CommandTimeout(3600); }));


            //foreach (var item in collection)
            //{

            //}

        }

        //static 
    }
}
