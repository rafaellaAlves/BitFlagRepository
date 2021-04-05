using System;
using System.Collections.Generic;
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

namespace AMaisImob_WEB
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
            string connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AMaisImob_DB.Models.AMaisImob_HomologContext>(options => options.UseSqlServer(connection));

            services.AddDbContext<AMaisImob_DB.Models.ApplicationDbContext>(options => options.UseSqlServer(connection));


            var emailConfiguration = Configuration.GetSection("EmailConfiguration").Get<AMaisImob_WEB.Models.EmailConfigurationViewModel>();
            services.AddSingleton(emailConfiguration);
            services.AddScoped<AMaisImob_WEB.BLL.MailFunctions>();
            services.AddScoped<AMaisImob_WEB.BLL.EmailLogFunctions>();

            services.AddScoped<AMaisImob_WEB.BLL.CertificateFunctions>();
            services.AddScoped<AMaisImob_WEB.BLL.ChargeFunctions>();
            services.AddScoped<AMaisImob_WEB.BLL.UserCompanyFunctions>();
            services.AddScoped<AMaisImob_WEB.BLL.CompanyFunctions>();
            services.AddScoped<AMaisImob_WEB.BLL.CategoryGuarantorProductTaxFunctions>();
            services.AddScoped<AMaisImob_WEB.BLL.ResidenceTypeFunctions>();
            services.AddScoped<AMaisImob_WEB.BLL.PaymentTypeFunctions>();
            services.AddScoped<AMaisImob_WEB.BLL.GuarantorProductFunctions>();
            services.AddScoped<AMaisImob_WEB.BLL.RegimeTributarioFunctions>();
            services.AddScoped<AMaisImob_WEB.BLL.UtilizacaoFunctions>();
            services.AddScoped<AMaisImob_WEB.BLL.CertificateContractualMemberFunctions>();
            services.AddScoped<AMaisImob_WEB.BLL.CompanyTypeFunctions>();
            services.AddScoped<BLL.StatusTypeFunctions>();
            services.AddScoped<BLL.CertificateContractualFunctions>();
            services.AddScoped<BLL.PaymentWayFunctions>();
            services.AddScoped<BLL.CertificateContractualIncomeTypeFunctions>();
            services.AddScoped<BLL.CertificateContractualQuoteFunctions>();
            services.AddScoped<BLL.MartialStatusFunctions>();
            services.AddScoped<BLL.KinshipFunctions>();
            services.AddScoped<BLL.ProductFamilyFunctions>();
            services.AddScoped<BLL.AuditLogFunctions>();
            services.AddScoped<BLL.GuarantorTypeFunctions>();
            services.AddScoped<BLL.CertificateContractualPolicyFileFunctions>();
            services.AddScoped<BLL.CertificateContractualViewFunctions>();
            services.AddScoped<BLL.UserFunctions>();
            services.AddScoped<BLL.CompanyOwnerTypeFunctions>();
            services.AddScoped<BLL.RoleFunctions>();
            services.AddScoped<BLL.UserListFunctions>();
            services.AddScoped<BLL.CertificateContractualPendencyFileFunctions>();
            services.AddScoped<BLL.CertificateContractualInstallmentFunctions>();
            services.AddScoped<BLL.CertificateContractualPaymentTypeFunctions>();
            services.AddScoped<BLL.HomeFunctions>();
            services.AddScoped<BLL.CategoryFunctions>();
            services.AddScoped<BLL.CompanyDocuSignFunctions>();
            services.AddScoped<BLL.FinancialFunctions>();
            services.AddScoped<BLL.ChargeCertificateContractualFunctions>();
            services.AddScoped<BLL.SystemVariableFunctions>();
            services.AddScoped<BLL.GuarantorProvider.GuarantorProviderFunctions>();
            services.AddScoped<BLL.GuarantorIntegration.Pottencial.PottencialSeguros>();
#if !DEBUG
            services.AddSingleton<BackgroundService.SendAssistanceReportService>();
#endif
            services.AddIdentity<AMaisImob_DB.Models.User, AMaisImob_DB.Models.Role>()
                .AddEntityFrameworkStores<AMaisImob_DB.Models.ApplicationDbContext>()
                .AddDefaultTokenProviders();

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
                options.MinimumSameSitePolicy = SameSiteMode.Strict;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider services)
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

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");

                context.Response.Headers.Remove("Server");
                context.Response.Headers.Remove("X-Powered-By");
                context.Response.Headers.Remove("X-SourceFiles");

                await next();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}");
            });

            //usado para criar os perfis(roles).
            CreateRoles(services).Wait();

            #region [Serviços]
            try
            {

                var sendAssistanceReportService = services.GetRequiredService<BackgroundService.SendAssistanceReportService>();
                sendAssistanceReportService.Init();
            }
            catch (Exception exception) { }
            #endregion
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<Microsoft.AspNetCore.Identity.RoleManager<AMaisImob_DB.Models.Role>>();

            Microsoft.AspNetCore.Identity.IdentityResult roleResult;

            var roles = new List<AMaisImob_DB.Models.Role> {
                new AMaisImob_DB.Models.Role{ Name = "Administrator", Description = "Administrador" },
                new AMaisImob_DB.Models.Role{ Name = "Corretor", Description = "Corretor" }
            };

            roles.AddRange(AMaisImob_WEB.Utils.ClaimUtils.GetRealEstateRoles());

            foreach (var role in roles)
            {
                if (await roleManager.RoleExistsAsync(role.Name)) continue;

                roleResult = await roleManager.CreateAsync(role);
            }
        }
    }
}
