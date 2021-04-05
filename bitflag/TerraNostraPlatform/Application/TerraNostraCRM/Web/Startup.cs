using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.SignalRHubs;

namespace Web
{
    public class Startup
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .SetBasePath(env.ContentRootPath)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US");
                options.SupportedCultures = new List<CultureInfo> { new CultureInfo("en-US") };
                options.RequestCultureProviders.Clear();
            });


            string connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DB.TerraNostraContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<TerraNostraIdentityDbContext.ApplicationDbContext>(options => options.UseSqlServer(connection));

            services.AddIdentity<TerraNostraIdentityDbContext.User, TerraNostraIdentityDbContext.Role>()
                .AddEntityFrameworkStores<TerraNostraIdentityDbContext.ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });

            #region [RequestLocalizationOptions]
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("pt-BR");
                options.SupportedCultures = new List<CultureInfo> { new CultureInfo("pt-BR") };
                options.RequestCultureProviders.Clear();
            });
            #endregion

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<FUNCTIONS.AuditLog.AuditLogFunctions>();
            services.AddScoped<FUNCTIONS.Client.ClientCalendarFunctions>();
            services.AddScoped<FUNCTIONS.Client.ClientArchiveFunctions>();
            services.AddScoped<FUNCTIONS.Client.ClientFunctions>();
            services.AddScoped<FUNCTIONS.Client.ClientLogFunctions>();
            services.AddScoped<FUNCTIONS.Client.ClientTypeFunctions>();
            services.AddScoped<FUNCTIONS.Client.FamilyTreeFunctions>();
            services.AddScoped<FUNCTIONS.Client.ClientDependentFunctions>();
            services.AddScoped<FUNCTIONS.Client.ClientDependentTypeFunctions>();
            services.AddScoped<FUNCTIONS.Client.ClientListFunctions>();
            services.AddScoped<FUNCTIONS.Client.ClientTaskNotificationFunctions>();
            services.AddScoped<FUNCTIONS.Indication.IndicationFunctions>();
            services.AddScoped<FUNCTIONS.Job.JobFunctions>();
            services.AddScoped<FUNCTIONS.Mail.MailFunctions>();
            services.AddScoped<FUNCTIONS.Message.MessageFunctions>();
            services.AddScoped<FUNCTIONS.Role.RoleFunctions>();
            services.AddScoped<FUNCTIONS.ServiceType.ServiceTypeFunctions>();
            services.AddScoped<FUNCTIONS.Ticket.TicketAreaFunctions>();
            services.AddScoped<FUNCTIONS.Ticket.TicketFunctions>();
            services.AddScoped<FUNCTIONS.Ticket.TicketHistoryFunctions>();
            services.AddScoped<FUNCTIONS.Ticket.TicketStatusFunctions>();
            services.AddScoped<FUNCTIONS.User.UserFunctions>();
            services.AddScoped<FUNCTIONS.User.UserListViewFunctions>();
            services.AddScoped<FUNCTIONS.Workflow.WorkflowFunctions>();
            services.AddScoped<FUNCTIONS.Family.FamilyFunctions>();
            services.AddScoped<FUNCTIONS.Family.ClientApplicantFunctions>();
            services.AddScoped<FUNCTIONS.Client.ClientStatusFunctions>();
            services.AddScoped<FUNCTIONS.Client.ClientStatusHistoryFunctions>();
            services.AddScoped<FUNCTIONS.SystemVariable.SystemVariableFunctions>();
            services.AddScoped<FUNCTIONS.Family.FreezedFamilyFunctions>();
            services.AddScoped<FUNCTIONS.Invoice.InvoiceFunctions>();
            services.AddScoped<FUNCTIONS.Invoice.InvoiceStatusFunctions>();
            services.AddScoped<FUNCTIONS.Invoice.InvoiceFreezedFamilyItemFunctions>();
            services.AddScoped<FUNCTIONS.Invoice.InvoiceItemFunctions>();
            services.AddScoped<FUNCTIONS.Invoice.InvoicePaymentTypeFunctions>();
            services.AddScoped<FUNCTIONS.Invoice.InvoicePaymentFunctions>();
            services.AddScoped<FUNCTIONS.Invoice.InvoiceViewFunctions>();
            services.AddScoped<FUNCTIONS.Workbench.WorkbenchListFunctions>();
            services.AddScoped<FUNCTIONS.Family.FreezedFamilyListFunctions>();
            services.AddScoped<FUNCTIONS.Invoice.InvoicePaymentListFunctions>();
            services.AddScoped<FUNCTIONS.RegistryOffice.RegistryOfficeFunctions>();
            services.AddScoped<FUNCTIONS.ContactMedium.ContactMediumFunctions>();
            services.AddScoped<FUNCTIONS.RDStation.RDStationLogFunctions>();

            services.AddSingleton<BackgroundService.ClientTaskNotificationService>();

            #region [SignalR]
            services.AddSignalR();
            services.AddScoped<NotificationHub>();
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider services)
        {
            if(env.IsProduction()) app.UseExceptionHandler("/Home/Error");

            app.Use(async (ctx, next) =>
            {
                await next.Invoke();

                if (ctx.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    string originalPath = ctx.Request.Path.Value;
                    ctx.Items["originalPath"] = originalPath;
                    ctx.Request.Path = "/Home/PageNotFound";
                    await next();
                }
            });

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSignalR(routes =>
            {
                routes.MapHub<NotificationHub>("/notificationhub");
            });
            app.UseCookiePolicy();
            app.UseRequestLocalization();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}");
            });

            
            //criar perfis
            CreateRoles(services).Wait();

            #region [Serviços]
            //try
            //{
            //    var calendarNotificationService = services.GetRequiredService<BackgroundService.ClientTaskNotificationService>();
            //    calendarNotificationService.Init(int.Parse(Configuration.GetSection("CalendarNotificationService")["Interval"]));
            //}
            //catch (Exception exception) { }
            #endregion
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<Microsoft.AspNetCore.Identity.RoleManager<TerraNostraIdentityDbContext.Role>>();

            Microsoft.AspNetCore.Identity.IdentityResult roleResult;

            var roles = new List<string> {
                "Administrator",
                "Client",
                "Agent",
                "Salesman"
            };

            foreach (var role in roles)
            {
                var roleCheck = await roleManager.RoleExistsAsync(role);
                if (!roleCheck)
                    roleResult = await roleManager.CreateAsync(new TerraNostraIdentityDbContext.Role() { Name = role });
            }
        }
    }
}