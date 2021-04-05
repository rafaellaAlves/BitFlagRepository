using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackgroundService.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BackgroundService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<SendClientLicenseConditioningEmail>();
                    services.AddHostedService<SendClientLicenseEmail>();
                    services.AddHostedService<SendTransporterEnvironmentalDocumentationEmail>();
                    services.AddHostedService<SendRecipientEnvironmentalDocumentationEmail>();
                });
    }
}
