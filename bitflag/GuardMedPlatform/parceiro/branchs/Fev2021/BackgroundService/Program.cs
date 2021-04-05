using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackgroundService.Models;
using Microsoft.Extensions.Configuration;
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
                    services.AddHostedService<Services.SendRenewEmailService>();
                    ConfigurationGetValues(services.BuildServiceProvider().GetService<IConfiguration>());
                }).UseWindowsService();


        static void ConfigurationGetValues(IConfiguration iConfiguration)
        {
            // carregar parametros do cliente...
            InsuranceConfiguration.LogoFullPath = iConfiguration.GetValue<string>("LogoFullPath");
            InsuranceConfiguration.ClientDisplayName = iConfiguration.GetValue<string>("ClientDisplayName");
            InsuranceConfiguration.MailHost = iConfiguration.GetValue<string>("MailHost");
            InsuranceConfiguration.MailPort = iConfiguration.GetValue<int>("MailPort");
            InsuranceConfiguration.MailLogin = iConfiguration.GetValue<string>("MailLogin");
            InsuranceConfiguration.MailPass = iConfiguration.GetValue<string>("MailPass");
            InsuranceConfiguration.MailName = iConfiguration.GetValue<string>("MailName");
            InsuranceConfiguration.MailSenderDisplay = iConfiguration.GetValue<string>("MailSenderDisplay");
            InsuranceConfiguration.MailLogoPath = iConfiguration.GetValue<string>("MailLogoPath");
            InsuranceConfiguration.InsuranceWebsite = iConfiguration.GetValue<string>("InsuranceWebsite");
            InsuranceConfiguration.IsHomolog = iConfiguration.GetValue<bool>("IsHomolog");
        }
    }
}
