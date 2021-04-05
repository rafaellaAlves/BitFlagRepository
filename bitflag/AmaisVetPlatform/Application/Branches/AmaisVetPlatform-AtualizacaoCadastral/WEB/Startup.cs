using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WEB
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
            #region [CultureInfo]
            var cultureInfo = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            #endregion

            #region [Contexts]
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext.Context.ApplicationDbContext>(o => { o.UseSqlServer(connectionString); });
            #endregion

            #region [Options]
            services.AddOptions();

            services.Configure<DTO.Payment.Integration.Iugu.Configuration>(Configuration.GetSection("Iugu"));

            var emailConfiguration = Configuration.GetSection("EmailConfiguration").Get<Dictionary<string, DTO.Mail.EmailConfigurationViewModel>>();
            services.AddSingleton(emailConfiguration);
            services.AddScoped<Services.Mail.MailService>();
            services.AddScoped<Services.Mail.MailLogService>();
            #endregion

            services.AddScoped<Helpers.ViewEngineHelper>();

            services.AddScoped<Services.Subscription.SubscriptionService>();
            services.AddScoped<Services.PlanCoverageType.PlanCoverageTypeService>();
            services.AddScoped<Services.Plan.PlanService>();
            services.AddScoped<Services.OccupationArea.OccupationAreaService>();
            services.AddScoped<Services.ProfessionalSpecialty.ProfessionalSpecialtyService>();
            services.AddScoped<Services.HealthQuestionnaire.HealthQuestionnaireService>();
            services.AddScoped<Services.Payment.Integration.IuguService>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            if (env.IsDevelopment())
            {
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
