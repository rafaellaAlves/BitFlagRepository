using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VendasDbContext.Models;

namespace BackgroundService
{
    public abstract class TimedHostedService : IHostedService, IDisposable
    {
        private readonly ILogger<TimedHostedService> _logger;
        private Timer _timer;
        private float delayHour;
        protected IConfiguration iConfiguration;
        public MailFunctions mailFunctions;

        protected DB.Models.Insurance_HomologContext insurance_HomologContext;
        protected VendasContext vendasContext;
        public TimedHostedService(ILogger<TimedHostedService> logger, IConfiguration iConfiguration, float delayHour)
        {
            this.delayHour = delayHour;
            _logger = logger;
            this.iConfiguration = iConfiguration;

            this.insurance_HomologContext = new DB.Models.Insurance_HomologContext(new DbContextOptionsBuilder<DB.Models.Insurance_HomologContext>().UseSqlServer(iConfiguration.GetConnectionString("DefaultConnection")).Options);
            this.vendasContext = new VendasContext(new DbContextOptionsBuilder<VendasContext>().UseSqlServer(iConfiguration.GetConnectionString("DefaultConnectionVendas")).Options);

            this.mailFunctions = new MailFunctions(this.vendasContext);
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"Service {this.GetType().Name} running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromHours(delayHour));

            return Task.CompletedTask;
        }

        public abstract void DoWork(object state);

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"Service {this.GetType().Name} is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose() => _timer?.Dispose();
    }
}
