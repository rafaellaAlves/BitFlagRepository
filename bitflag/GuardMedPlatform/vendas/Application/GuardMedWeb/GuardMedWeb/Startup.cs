using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsurenceDbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GuardMedWeb.Configuration;
using BLL.Mail;
using InsurenceDbContext.Models;

namespace GuardMedWeb
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            string connectionInsurence = Configuration.GetConnectionString("DefaultConnectionInsurence");

            services.AddDbContext<DAL.GuardMedWebContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<InsurenceContext>(options => options.UseSqlServer(connectionInsurence));

            services.AddScoped<GuardMedWeb.BLL.SeguradoProfissional.MedicGroupFunctions>();
            services.AddScoped<GuardMedWeb.BLL.Insurance.Company.CompanyFunctions>();
            services.AddScoped<GuardMedWeb.BLL.SeguradoProfissional.SeguradoProfissionalFunctions>();
            services.AddScoped<GuardMedWeb.BLL.SeguradoProfissional.EspecialidadePrecoFunctions>();
            services.AddScoped<GuardMedWeb.BLL.SeguradoProfissional.PlanoSeguroProfissionalFunctions>();
            services.AddScoped<MailFunctions>();

            //services.AddDbContext<DAL.Identity.ApplicationDbContext>(options => options.UseSqlServer(connection));

            //services.AddIdentity<DAL.Identity.User, DAL.Identity.Role>()
            //    .AddEntityFrameworkStores<DAL.Identity.ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            ConfigurationGetValues();

            services.AddMvc();
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                "Default",
                "{controller}/{action}",
                new { controller = "SeguroProfissional", action = "Index" });
            });
        }

        public void ConfigurationGetValues()
        {
            // carregar parametros do cliente...
            InsuranceConfiguration.ClientWebsite = Configuration.GetValue<string>("ClientWebsite");
            InsuranceConfiguration.InsuranceWebsite = Configuration.GetValue<string>("InsuranceWebsite");
        }
    }
}
