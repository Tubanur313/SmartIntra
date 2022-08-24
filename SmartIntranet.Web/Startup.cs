using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartIntranet.Business.DependencyResolvers.Automapper;
using SmartIntranet.Business.Extension;
using SmartIntranet.Core.Extensions;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.Web.GoogleRecaptcha;
using System.Globalization;

namespace SmartTicket.Web
{
    public class Startup
    {
        private readonly IWebHostEnvironment _Env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _Env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews(opt =>
            {
                opt.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                opt.Filters.Add(new AuthorizeFilter(policy));

            }).AddFluentValidation();

            services.AddCustomCompression(); 
            services.AddRouting(cfg => cfg.LowercaseUrls = true);
            services.AddDbContext<IntranetContext>();
            services.AddCustomIdentity();
            services.AddCustomValidator();
            services.Configure<GoogleConfigModel>(Configuration.GetSection("GoogleConfig"));
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddAutoMapper(typeof(MapProfile));

        }
         public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    //app.UseHsts();
            //}

            app.UseHttpsRedirection();
            //app.SeedTicketSystem();
            //IntranetDBSeed.SeedClause(app);
            //IntranetDBSeed.SeedVacationType(app);
            //IntranetDBSeed.SeedNonWorkingGraphics(app);
            //IntranetDBSeed.SeedPlace(app);
            //IntranetDBSeed.SeedTerminationItem(app);
            //IntranetDBSeed.SeedContractType(app);
            app.UseMiddleware<SecurityHeadersMiddleware>();
            var supportedCultures = new[]
            {
               new CultureInfo("az-AZ"),

            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("ru-RU"),
                SupportedCultures=supportedCultures,
                SupportedUICultures=supportedCultures
            });
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=news}/{action=info}/{id?}");

                endpoints.MapControllerRoute(
                   name: "default-login",
                    pattern: "login.html",
                    defaults: new
                    {
                        controller = "account",
                        action = "login"
                    });

                endpoints.MapControllerRoute(
                   name: "default-accessdenied",
                    pattern: "accessdenied.html",
                    defaults: new
                    {
                        controller = "account",
                        action = "accessdenied"
                    });
            });
        }
    }
}

