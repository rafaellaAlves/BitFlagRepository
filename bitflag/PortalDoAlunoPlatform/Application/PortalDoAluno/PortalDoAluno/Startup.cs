using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

        public void ConfigureServices(IServiceCollection services)
        {
            #region [Context]
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext.ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            #endregion

            #region [AspNetIdentity]
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

            services.AddMemoryCache();

            #region [Services]
            services.AddScoped<Services.Course.CourseService>();
            services.AddScoped<Services.Class.ClassService>();
            services.AddScoped<Services.Student.StudentService>();
            services.AddScoped<Services.ClassStudent.ClassStudentService>();
            services.AddScoped<Services.ASAAS.ASAASService>();
            services.AddScoped<Services.ProfessionalDocumentStatus.ProfessionalDocumentStatusService>();
            services.AddScoped<Services.Period.PeriodService>();
            services.AddScoped<Helpers.DropDownListHelper>();
            services.AddScoped<Services.OptionPresence.OptionPresenceService>();
            services.AddScoped<Services.ClassStudent.PresenceSituationService>();
            services.AddScoped<Services.ClassStudent.FinanceService>();
            #endregion

            #region [RequestLocalizationOptions]
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("pt-BR");
                options.SupportedCultures = new List<CultureInfo> { new CultureInfo("pt-BR") };
                options.RequestCultureProviders.Clear();
            });
            #endregion

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
            app.UseRouting();
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
