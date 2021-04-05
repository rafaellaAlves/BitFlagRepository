using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BackgroundService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Web.Helpers;

namespace Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IWebHostEnvironment webHostingEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .SetBasePath(webHostingEnvironment.ContentRootPath)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            #region [ApplicationDbContext]
            services.AddDbContext<ApplicationDbContext.Context.ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            #endregion

            #region [AspNetIdentity]
            // var dbContextOptionsBuilder = new DbContextOptionsBuilder<AspNetIdentityDbContext.ApplicationDbContext>();
            // dbContextOptionsBuilder.UseSqlServer(connectionString);

            // services.AddTransient<AspNetIdentityDbContext.ApplicationDbContext>(isp => new AspNetIdentityDbContext.ApplicationDbContext(dbContextOptionsBuilder.Options));
            services.AddDbContext<AspNetIdentityDbContext.ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddIdentity<AspNetIdentityDbContext.User, AspNetIdentityDbContext.Role>()
                .AddEntityFrameworkStores<AspNetIdentityDbContext.ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });
            #endregion

            #region [RequestLocalizationOptions]
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("pt-BR");
                options.SupportedCultures = new List<CultureInfo> { new CultureInfo("pt-BR") };
                options.RequestCultureProviders.Clear();
            });
            #endregion

            #region [Services]
            services.AddScoped<Web.Helpers.DropDownListHelper>();

            services.AddScoped<Services.Account.UserService>();
            services.AddScoped<Services.Account.RoleService>();

            services.AddScoped<Services.Client.ClientServices>();
            services.AddScoped<Services.Client.ClientActivityServices>();
            services.AddScoped<Services.Client.ClientCollectionAddressServices>();
            services.AddScoped<Services.Client.ClientContactServices>();
            services.AddScoped<Services.Client.ClientContactTypeServices>();
            services.AddScoped<Services.Client.ClientContactListServices>();
            services.AddScoped<Services.Client.ClientUserServices>();
            services.AddScoped<Services.Client.ClientReportServices>();
            services.AddScoped<Services.Client.ClientCollectionRequestServices>();
            services.AddScoped<Services.Client.ClientLicenseServices>();
            services.AddScoped<Services.Client.ClientLicenseConditioningService>();
            services.AddScoped<Services.Client.ClientLicenseConditioningPeriodicityServices>();
            services.AddScoped<Services.Client.ClientLicenseConditioningItemService>();
            services.AddScoped<Services.Client.ClientLicenseConditioningItemListService>();

            services.AddScoped<Services.Transporter.TransporterServices>();
            services.AddScoped<Services.Transporter.TransporterContactServices>();
            services.AddScoped<Services.Transporter.TransporterDriverServices>();
            services.AddScoped<Services.Transporter.TransporterEnvironmentalDocumentationServices>();
            services.AddScoped<Services.Transporter.TransporterVehicleServices>();
            services.AddScoped<Services.Transporter.TransporterDriverServices>();
            services.AddScoped<Services.Transporter.TransporterDriverServices>();
            services.AddScoped<Services.Transporter.TransporterEnvironmentalDocumentationLicenseResidueFamilyServices>();

            services.AddScoped<Services.Recipient.RecipientServices>();
            services.AddScoped<Services.Recipient.RecipientContactServices>();
            services.AddScoped<Services.Recipient.RecipientEnvironmentalDocumentationServices>();

            services.AddScoped<Services.Contract.ContractServices>();
            services.AddScoped<Services.Contract.ContractPeriodicityServices>();
            services.AddScoped<Services.Contract.ContractSituationServices>();
            services.AddScoped<Services.Contract.ContractListServices>();
            services.AddScoped<Services.Contract.ContractClientCollectionAddressService>();
            services.AddScoped<Services.Contract.ContractStatusServices>();
            services.AddScoped<Services.Contract.ContractResidueServices>();

            services.AddScoped<Services.Residue.ResidueFamilyServices>();
            services.AddScoped<Services.Residue.ResidueFamilyListService>();
            services.AddScoped<Services.Residue.ResidueFamilyClassService>();
            services.AddScoped<Services.Residue.ResidueServices>();
            services.AddScoped<Services.Residue.PackagingServices>();
            services.AddScoped<Services.Residue.PhysicalStateServices>();
            services.AddScoped<Services.Residue.UnitOfMeasurementServices>();
            services.AddScoped<Services.Residue.ResidueListServices>();
            services.AddScoped<Services.Residue.ResiduePriceServices>();
            services.AddScoped<Services.Residue.ResiduePriceListServices>();
            services.AddScoped<Services.Residue.ResidueDestinationTypeServices>();

            services.AddScoped<Services.Service.ServiceServices>();
            services.AddScoped<Services.Service.ServiceFreightPaymentTermServices>();
            services.AddScoped<Services.Service.ServiceResidualPaymentTermServices>();
            services.AddScoped<Services.Service.ServiceResidueFamilyPriceServices>();
            services.AddScoped<Services.Service.ServiceClientCollectionAddressServices>();
            services.AddScoped<Services.Service.ServiceSituationServices>();
            services.AddScoped<Services.Service.ServiceStatusServices>();
            services.AddScoped<Services.Service.ServiceListServices>();
            services.AddScoped<Services.Service.ServiceHistoricServices>();

            services.AddScoped<Services.Route.RouteServices>();
            services.AddScoped<Services.Route.RouteClientServices>();
            services.AddScoped<Services.Route.RouteClientListServices>();
            services.AddScoped<Services.Route.BaseRouteClientListServices>();
            services.AddScoped<Services.Route.RouteResidueFamilyServices>();
            services.AddScoped<Services.Route.RouteListServices>();
            services.AddScoped<Services.Route.RouteTypeServices>();
            services.AddScoped<Services.Route.RoutePeriodicityServices>();

            services.AddScoped<Services.Demand.DemandServices>();
            services.AddScoped<Services.Demand.DemandClientServices>();
            services.AddScoped<Services.Demand.BaseDemandClientListServices>();
            services.AddScoped<Services.Demand.DemandClientListServices>();
            services.AddScoped<Services.Demand.DemandResidueFamilyServices>();
            services.AddScoped<Services.Demand.DemandStatusServices>();
            services.AddScoped<Services.Demand.DemandClientResidueServices>();
            services.AddScoped<Services.Demand.DemandClientResidueListServices>();
            services.AddScoped<Services.Demand.DemandListServices>();
            services.AddScoped<Services.Demand.DemandWeightServices>();
            services.AddScoped<Services.Demand.DemandResidueFamilyTotalWeightServices>();
            services.AddScoped<Services.Demand.DemandNotUsedClientServices>();

            services.AddScoped<Services.DemandDestination.DemandDestinationServices>();
            services.AddScoped<Services.DemandDestination.DemandDestinationStatusServices>();
            services.AddScoped<Services.DemandDestination.DemandDestinationListServices>();
            services.AddScoped<Services.DemandDestination.DemandDestinationDemandServices>();

            services.AddScoped<Services.Home.HomeServices>();

            services.AddScoped<Services.SystemVariable.SystemVariableServices>();

            services.AddScoped<Services.Email.EmailServices>();
            services.AddScoped<Services.Email.EmailLogServices>();

            services.AddScoped<Services.Sintegra.SintegraService>();

            services.AddScoped<Services.Report.ReportService>();

            services.AddScoped<ViewEngineHelper>();

            services.AddSingleton<BackgroundService.UpdateDemandStatusService>();
            services.AddSingleton<BackgroundService.UpdateDemandDestinationStatusService>();

            services.AddHostedService<UpdateContractStatus>();
            services.AddHostedService<SendConractToExpiringSitatuationEmail>();

#if !DEBUG
            services.AddSingleton<BackgroundService.UpdateDemandStatusService>();
            services.AddSingleton<BackgroundService.UpdateDemandDestinationStatusService>();

            services.AddHostedService<SendClientLicenseConditioningEmail>();
            services.AddHostedService<SendClientLicenseEmail>();
            services.AddHostedService<SendRecipientEnvironmentalDocumentationEmail>();
            services.AddHostedService<SendTransporterEnvironmentalDocumentationEmail>();
            services.AddHostedService<SendRecipientEnvironmentalDocumentationAdministrativeEmail>();
            services.AddHostedService<SendTransporterEnvironmentalDocumentationAdministrativeEmail>();
            services.AddHostedService<UpdateContractStatus>();
            services.AddHostedService<SendClientNoServiceEmail>();
            services.AddHostedService<SendClientNoContractAndServiceEmail>();
            services.AddHostedService<SendContractExpiringEmail>();
            services.AddHostedService<SendConractToExpiringSitatuationEmail>();
#endif
            #endregion

            services.AddControllersWithViews();

            services.AddSession(opt =>
            {
                opt.IdleTimeout = TimeSpan.FromDays(1);
            });

            services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue; // if don't set default value is: 128 MB
                options.MultipartHeadersLengthLimit = int.MaxValue;
            });

            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
                options.Limits.MaxRequestBodySize = int.MaxValue; // if don't set default value is: 30 MB
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
                options.MaxRequestBodySize = int.MaxValue;
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Services.Account.RoleService roleService, IServiceProvider services)
        {
            app.UseSession();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "SystemArchives")),
                RequestPath = "/SystemArchives"
            });

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            roleService.CreateBasicRoles();

            #region [Serviços]
#if !DEBUG
            try
            {
                var updateDemandStatusService = services.GetRequiredService<BackgroundService.UpdateDemandStatusService>();
                updateDemandStatusService.Init();


                var updateDemandDestinationStatusService = services.GetRequiredService<BackgroundService.UpdateDemandDestinationStatusService>();
                updateDemandDestinationStatusService.Init();
            }
            catch (Exception exception) { }
#endif
            #endregion
        }
    }
}