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
    public class UpdateDemandDestinationStatusService : AMaisImob_BackgroundServices.Bases.ServicoProcessamentoFila<List<DemandDestination>>
    {
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

        public UpdateDemandDestinationStatusService(string connectionString) : base()
        {
            Init(connectionString);
        }

        public UpdateDemandDestinationStatusService(string connectionString, Dictionary<string, object> parametros) : base(parametros)
        {
            Init(connectionString);
        }

        public void Init(string connectionString)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext.Context.ApplicationDbContext>();
            options.UseSqlServer(connectionString);
            this.context = new ApplicationDbContext.Context.ApplicationDbContext(options.Options);
        }

        public override async Task<List<DemandDestination>> ObterItem()
        {
            var concludedId = (await this.context.DemandDestinationStatus.SingleAsync(x => x.ExternalCode == "CONCLUIDO")).DemandDestinationStatusId;
            var finishedId = (await this.context.DemandDestinationStatus.SingleAsync(x => x.ExternalCode == "FINALIZADO")).DemandDestinationStatusId;

            return await context.DemandDestination.Where(x => !x.IsDeleted && x.DemandDestinationStatusId != finishedId && x.DemandDestinationStatusId != concludedId).ToListAsync();
        }

        public override async Task ProcessarItem(List<DemandDestination> item)
        {
            var openId = (await this.context.DemandDestinationStatus.SingleAsync(x => x.ExternalCode == "EMABERTO")).DemandDestinationStatusId;
            var progressId = (await this.context.DemandDestinationStatus.SingleAsync(x => x.ExternalCode == "EMANDAMENTO")).DemandDestinationStatusId;
            var today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            foreach (var demandDestination in item)
            {

                if (DateTime.Compare(demandDestination.DepartureDate, today) > 0)
                {
                    demandDestination.DemandDestinationStatusId = openId;
                }
                else if (DateTime.Compare(demandDestination.DepartureDate, today) <= 0)
                {
                    demandDestination.DemandDestinationStatusId = progressId;
                }
            }

            this.context.DemandDestination.UpdateRange(item);
            await this.context.SaveChangesAsync();
        }

        public override Task Progresso(List<DemandDestination> item)
        {
            throw new NotImplementedException();
        }

        public override Task Finalizar(List<DemandDestination> item)
        {
            throw new NotImplementedException();
        }
    }
}
