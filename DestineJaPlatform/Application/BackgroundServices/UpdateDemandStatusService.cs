using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Mime;
using ApplicationDbContext.Models;

namespace BackgroundServices
{
    public class UpdateDemandStatusService : AMaisImob_BackgroundServices.Bases.ServicoProcessamentoFila<List<Demand>>
    {
        public static void Main() { }

        #region [Propriedades]
        private class Retorno
        {
            public string Version { get; set; }
            public int StatusCode { get; set; }
            public bool Success { get; set; }
            public object Content { get; set; }
        }

        private ApplicationDbContext.Context.ApplicationDbContext context;
        #endregion

        public UpdateDemandStatusService(string connectionString) : base()
        {
            Init(connectionString);
        }

        public UpdateDemandStatusService(string connectionString, Dictionary<string, object> parametros) : base(parametros)
        {
            Init(connectionString);
        }

        public void Init(string connectionString)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext.Context.ApplicationDbContext>();
            options.UseSqlServer(connectionString);
            this.context = new ApplicationDbContext.Context.ApplicationDbContext(options.Options);
        }

        public override async Task<List<Demand>> ObterItem()
        {
            var finishedId = (await this.context.DemandStatus.SingleAsync(x => x.ExternalCode == "COLETAFINALIZADA")).DemandStatusId;
            var concludedId = (await this.context.DemandStatus.SingleAsync(x => x.ExternalCode == "PROCESSOCONCLUIDO")).DemandStatusId;

            return await context.Demand.Where(x => !x.IsDeleted && x.DemandStatusId != finishedId && x.DemandStatusId != concludedId && x.DepartureDate.HasValue && x.ArriveDate.HasValue).ToListAsync();
        }

        public override async Task ProcessarItem(List<Demand> item)
        {
            var scheduledId = (await this.context.DemandStatus.SingleAsync(x => x.ExternalCode == "COLETAAGENDADA")).DemandStatusId;
            var progressId = (await this.context.DemandStatus.SingleAsync(x => x.ExternalCode == "COLETAANDAMENTO")).DemandStatusId;
            var returnedId = (await this.context.DemandStatus.SingleAsync(x => x.ExternalCode == "COLETARETORNADA")).DemandStatusId;
            var today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            foreach (var demand in item)
            {

                if (DateTime.Compare(demand.DepartureDate.Value, today) > 0)
                {
                    demand.DemandStatusId = scheduledId;
                }
                else if (DateTime.Compare(demand.ArriveDate.Value.AddDays(1), today) <= 0)
                {
                    demand.DemandStatusId = returnedId;
                }
                else if (DateTime.Compare(demand.DepartureDate.Value, today) <= 0)
                {
                    demand.DemandStatusId = progressId;
                }
            }

            this.context.Demand.UpdateRange(item);
            await this.context.SaveChangesAsync();
        }

        public override Task Progresso(List<Demand> item)
        {
            throw new NotImplementedException();
        }

        public override Task Finalizar(List<Demand> item)
        {
            throw new NotImplementedException();
        }
    }
}
