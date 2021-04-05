using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VendasDbContext.Models;
using WEB.Configuration;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            string connectionVendas = Configuration.GetConnectionString("DefaultConnectionVendas");

            services.AddDbContext<DB.Models.Insurance_HomologContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<DB.Models.ApplicationDbContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<VendasContext>(options => options.UseSqlServer(connectionVendas));
            services.AddIdentity<DB.Models.User, DB.Models.Role>().AddEntityFrameworkStores<DB.Models.ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddScoped<Services.SeguradoProfissional.SeguradoProfissionalService>();
            services.AddScoped<Services.Advisor.AdvisorService>();
            services.AddScoped<Services.Plano.PlanoSeguroProfissionalService>();
            services.AddScoped<Services.Especialidade.EspecialidadePrecoService>();
            services.AddScoped<Services.Especialidade.EspecialidadeService>();
            services.AddScoped<Services.Pagamento.PagamentoTipoService>();
            services.AddScoped<Services.MedicGroup.MedicGroupService>();
            services.AddScoped<Services.MedicGroup.MedicGroupCRMService>();
            services.AddScoped<Services.Benefits.BenefitsService>();
            services.AddScoped<Services.SeguradoProfissional.SeguradoProfissionalHistoricoService>();
            services.AddScoped<Services.SeguradoProfissional.InsuranceAccessPermissionService>();

            InsuranceConfigurationGetValues(); //metodo para receber as informações do appsettings

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #region [AUTHENTICATION]
            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie();
            #endregion

            services.AddScoped<Services.IUGU.IUGUService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}/{id?}");
            });
        }


        public void InsuranceConfigurationGetValues()
        {
            // carregar parametros do cliente...
            InsuranceConfiguration.VendasWebsite = Configuration.GetValue<string>("VendasWebsite");
        }
    }
}
