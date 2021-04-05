using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VendasDbContext.Models;
using System.Globalization;

namespace WEB
{
    public class Startup
    {
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
            #region [CultureInfo]
            var cultureInfo = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            #endregion

            string connection = Configuration.GetConnectionString("DefaultConnection");
            string connectionVendas = Configuration.GetConnectionString("DefaultConnectionVendas");
            InsuranceConfigurationGetValues(); //metodo para receber as informações do appsettings
            services.AddDbContext<DB.Models.Insurance_HomologContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<DB.Models.ApplicationDbContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<VendasContext>(options => options.UseSqlServer(connectionVendas));
            services.AddIdentity<DB.Models.AspNetUser, DB.Models.AspNetRole>()
                .AddEntityFrameworkStores<DB.Models.ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<BLL.UserFunctions>();
            services.AddScoped<BLL.CompanyFunctions>();
            services.AddScoped<BLL.UserCompanyFunctions>();
            services.AddScoped<BLL.CompanyAcceptTermsFunctions>();
            services.AddScoped<BLL.SeguradoProfissionalFunctions>();
            services.AddScoped<BLL.VendasSystemVariableFunctions>();
            services.AddScoped<BLL.CompanyTypeFunctions>();
            services.AddScoped<BLL.MedicGroupFunctions>();
            services.AddScoped<BLL.UserMedicGroupFunctions>();
            services.AddScoped<BLL.MedicGroupCRMFunctions>();
            services.AddScoped<BLL.MedicGroupListViewFunctions>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider services, IConfiguration x)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}");
            });

            
            //usado para criar os perfis(roles).
            //CreateRoles(services).Wait();
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<Microsoft.AspNetCore.Identity.RoleManager<DB.Models.Role>>();

            Microsoft.AspNetCore.Identity.IdentityResult roleResult;

            var roles = new List<string> {
                "Administrator",
                "Corretor",
                "ImobiliariaOperacional",
                //"ImobiliariaFinanceiro",
                "ImobiliarioAdministrativo",
                "GrupoMedico"
            };

            foreach (var role in roles)
            {
                var roleCheck = await roleManager.RoleExistsAsync(role);
                if (!roleCheck)
                    roleResult = await roleManager.CreateAsync(new DB.Models.Role() { Name = role });
            }
        }
        public void InsuranceConfigurationGetValues()
        {
            // carregar parametros do cliente...
            InsuranceConfiguration.LogoFullPath = Configuration.GetValue<string>("LogoFullPath");
            InsuranceConfiguration.PartnerDisplayName = Configuration.GetValue<string>("PartnerDisplayName");
            InsuranceConfiguration.CorretoraDisplayName = Configuration.GetValue<string>("CorretoraDisplayName");
            InsuranceConfiguration.ClientDisplayName = Configuration.GetValue<string>("ClientDisplayName");
            InsuranceConfiguration.MailHost = Configuration.GetValue<string>("MailHost");
            InsuranceConfiguration.MailPort = Configuration.GetValue<int>("MailPort");
            InsuranceConfiguration.MailLogin = Configuration.GetValue<string>("MailLogin");
            InsuranceConfiguration.MailPass = Configuration.GetValue<string>("MailPass");
            InsuranceConfiguration.MailName = Configuration.GetValue<string>("MailName");
            InsuranceConfiguration.MailSenderDisplay = Configuration.GetValue<string>("MailSenderDisplay");
            InsuranceConfiguration.MailLogoPath = Configuration.GetValue<string>("MailLogoPath");
            InsuranceConfiguration.VendasWebsite = Configuration.GetValue<string>("VendasWebsite");
            InsuranceConfiguration.ComissaoPadrao = Configuration.GetValue<double>("ComissaoPadrao");
            InsuranceConfiguration.IsHomolog = Configuration.GetValue<bool>("IsHomolog");
        }
    }
}
