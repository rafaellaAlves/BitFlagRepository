using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Services.Email;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundService
{
    public abstract class TimedHostedService : IHostedService, IDisposable
    {
        private readonly ILogger<TimedHostedService> _logger;
        private Timer _timer;
        private float delayHour;

        protected ApplicationDbContext.Context.ApplicationDbContext context;
        protected IConfiguration iConfiguration;
        protected EmailServices emailServices;
        public TimedHostedService(ILogger<TimedHostedService> logger, IConfiguration iConfiguration, float delayHour)
        {
            this.delayHour = delayHour;
            _logger = logger;
            this.context = new ApplicationDbContext.Context.ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext.Context.ApplicationDbContext>().UseSqlServer(iConfiguration.GetConnectionString("DefaultConnection"), opt => { opt.CommandTimeout(3600); }));
            this.iConfiguration = iConfiguration;
            emailServices = new EmailServices(iConfiguration, new EmailLogServices(context));
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"Service {this.GetType().Name} running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromHours(this.delayHour));

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
