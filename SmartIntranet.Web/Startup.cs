using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartIntranet.Business.Containers.MicrosoftIoC;
using SmartIntranet.Business.DependencyResolvers.Automapper;
using SmartIntranet.Business.Extension;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.Web.GoogleRecaptcha;
using System;

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
            }).AddFluentValidation();
            services.AddCustomCompression();
            services.AddDbContext<IntranetContext>();
            services.AddDependencies();
            services.AddCustomIdentity();
            services.AddCustomValidator();
            services.Configure<GoogleConfigModel>(Configuration.GetSection("GoogleConfig"));
            services.AddAutoMapper(typeof(MapProfile));
            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromDays(20);
                option.Cookie.HttpOnly = true;
                option.Cookie.IsEssential = true;
                option.Cookie.SecurePolicy = _Env.IsDevelopment() ? CookieSecurePolicy.SameAsRequest : CookieSecurePolicy.Always;
                option.Cookie.SameSite = _Env.IsDevelopment() ? SameSiteMode.None : SameSiteMode.Strict;
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                //app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.SeedTicketSystem();
            IntranetDBSeed.SeedClause(app);
            IntranetDBSeed.SeedVacationType(app);
            IntranetDBSeed.SeedNonWorkingGraphics(app);
            IntranetDBSeed.SeedPlace(app);
            IntranetDBSeed.SeedTerminationItem(app);
            IntranetDBSeed.SeedContractType(app);
            //app.UseMiddleware<SecurityHeadersMiddleware>();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();
            app.UseSession();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "default-signin",
                    pattern: "signin.html",
                    defaults: new
                    {
                        controller = "user",
                        action = "signin"
                    });

                endpoints.MapControllerRoute(
                   name: "default-accessdenied",
                    pattern: "accessdenied.html",
                    defaults: new
                    {
                        controller = "user",
                        action = "accessdenied"
                    });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=news}/{action=info}/{id?}");
            });
        }
    }
}

