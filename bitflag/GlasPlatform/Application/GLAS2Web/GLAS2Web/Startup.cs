using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using GLAS2Web.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis.Options;
using Microsoft.AspNetCore.Http.Features;

namespace GLAS2Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .SetBasePath(env.ContentRootPath)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DAL.GLAS2Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<DAL.Identity.ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<DAL.Identity.User, DAL.Identity.Role>()
                .AddEntityFrameworkStores<DAL.Identity.ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddClaimsPrincipalFactory<ApplicationClaimsIdentityFactory>();
                //.AddClaimsPrincipalFactory<IUserClaimsPrincipalFactory<DAL.Identity.User>, ApplicationClaimsIdentityFactory>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 1;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #region [FUNCTIONS]
            services.AddScoped<BLL.Audit.AuditItemStatusFunctions>();
            services.AddScoped<BLL.Utils.EsferaFunctions>();
            services.AddScoped<BLL.Utils.OrgaoFunctions>();
            services.AddScoped<BLL.Utils.SegmentoFunctions>();
            services.AddScoped<BLL.Law.LawFunctions>();
            services.AddScoped<BLL.Law.LawTypeFunctions>();
            services.AddScoped<BLL.Law.LawApplicationTypeFunctions>();
            services.AddScoped<BLL.Company.CompanyLawAttachmentFunctions>();
            services.AddScoped<BLL.User.UserFunctions>();
            services.AddScoped<BLL.Permission.CompanyUserRoleFunctions>();
            services.AddScoped<BLL.Company.CompanyLawVisualizationFunctions>();
            services.AddScoped<BLL.Law.LawVerificationListItemViewFunctions>();
            services.AddScoped<BLL.Law.LawChangeFunctions>();
            services.AddScoped<BLL.Law.LawViewFunctions>();
            services.AddScoped<BLL.EmailLog.EmailLogFunctions>();
            services.AddScoped<BLL.Mail.MailFunctions>();
            services.AddScoped<BLL.Company.CompanyFunctions>();
            services.AddScoped<BLL.Company.CompanyViewFunctions>();
            services.AddScoped<BLL.Company.CompanyLawFunctions>();
            services.AddScoped<BLL.Company.CompanyUserFunctions>();
            services.AddScoped<BLL.Law.LawPotentialityTypeFunctions>();
            services.AddScoped<BLL.Question.QuestionThemeFunctions>();
            services.AddScoped<BLL.Question.QuestionSubThemeFunctions>();
            services.AddScoped<BLL.Question.QuestionFunctions>();
            services.AddScoped<BLL.Question.QuestionAnswerFunctions>();
            services.AddScoped<BLL.Question.QuestionSubThemeListFunctions>();
            services.AddScoped<BLL.Question.QuestionAnswerListFunctions>();
            services.AddScoped<BLL.Question.QuestionListFunctions>();
            services.AddScoped<BLL.CompanyQuestion.CompanyQuestionFunctions>();
            services.AddScoped<BLL.CompanyQuestion.CompanyQuestionAnswerFunctions>();
            services.AddScoped<BLL.CompanyQuestion.CompanyQuestionChoosenAnswerFunctions>();
            services.AddScoped<BLL.CompanyQuestion.CompanyQuestionChoosenAnswerItemFunctions>();
            services.AddScoped<BLL.Utils.CountryFunctions>();
            services.AddScoped<BLL.Utils.StateFunctions>();
            services.AddScoped<BLL.Utils.CityFunctions>();
            services.AddScoped<GLAS2Web.Utils.ControllerUtils>();
            services.AddTransient<BLL.Localization.TranslationFunctions>();
            #endregion

            services.AddMvc()
                .AddJsonOptions(opt => opt.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("UserManagesAnyCompany", policy => policy.Requirements.Add(new CompanyManagementRequirement(new List<string>() { BLL.User.ProfileNames.BioteraConsultor, BLL.User.ProfileNames.ClienteAdministrador })));
                options.AddPolicy("BioteraManagesAnyCompany", policy => policy.Requirements.Add(new CompanyManagementRequirement(new List<string>() { BLL.User.ProfileNames.BioteraConsultor })));
            });
            services.AddTransient<IAuthorizationHandler, UserManagesAnyCompany>();


            services.Configure<FormOptions>(options =>
            {
                options.ValueCountLimit = int.MaxValue;
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
#if DEBUG
            app.Use(async (ctx, next) =>
            {
                await next.Invoke();

                if (ctx.Response.StatusCode == StatusCodes.Status419AuthenticationTimeout)
                {
                    //     ||
                    //(ctx.Response.StatusCode == StatusCodes.Status302Found && !ctx.Request.HttpContext.Request.Query.ContainsKey("ReturnUrl"))
                    string originalPath = ctx.Request.Path.Value;
                    ctx.Items["originalPath"] = originalPath;
                    ctx.Request.Path = "/Account/TimeOut";
                    await next();
                }
            });
#endif
            app.UseSession();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
        }
    }
}
