using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using SmartIntranet.Entities.Concrete.Membership;
using SmartIntranet.Business.Provider;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.Business.ValidationRules.FluentValidation;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.DTO.DTOs.CategoryDto;
using SmartIntranet.DTO.DTOs.AppRoleDto;
using SmartIntranet.DTO.DTOs.DepartmentDto;
using SmartIntranet.DTO.DTOs.PositionDto;
using SmartIntranet.DTO.DTOs.CheckListDto;
using SmartIntranet.DTO.DTOs.TicketDto;
using SmartIntranet.DTO.DTOs.AppUserDto;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Http;
using SmartIntranet.DTO.DTOs.NewsDto;
using SmartIntranet.DTO.DTOs.CategoryNewsDto;
using SmartIntranet.DTO.DTOs.VacancyDto;
using SmartIntranet.DTO.DTOs.GradeDto;
using SmartIntranet.DTO.DTOs.CategoryTicketDto;
using SmartIntranet.DTO.DTOs.BusinessTripDto;
using SmartIntranet.DTO.DTOs.PlaceDto;
using SmartIntranet.DTO.DTOs.CauseDto;
using SmartIntranet.DTO.DTOs.ClauseDto;
using SmartIntranet.DTO.DTOs.PersonalContractDto;
using SmartIntranet.DTO.DTOs.ContractDto;
using SmartIntranet.DTO.DTOs.WorkGraphicDto;
using SmartIntranet.DTO.DTOs.InventaryDtos.StockDto;
using SmartIntranet.Business.ValidationRules.FluentValidation.InventaryValidate;
using SmartIntranet.DTO.DTOs.InventaryDtos.StockCategoryDto;

namespace SmartIntranet.Business.Extension
{
    public static class CollectionExtension
    {
        public static void AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IntranetUser, IntranetRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
            })
             .AddEntityFrameworkStores<IntranetContext>();


            services.AddAuthenticationCore().ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "SmartIntranetCookie";
                //opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(300);
                opt.SlidingExpiration = true;
                //opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/signin.html";
                opt.AccessDeniedPath = "/accessdenied.html";
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();

            services.AddAuthorization(cfg =>
            {

                foreach (var claimName in AppClaimProvider.policies)
                {
                    cfg.AddPolicy(claimName, p =>
                    {
                        p.RequireAssertion(a =>
                        {

                            return a.User.HasClaim(claimName, "1")
                            || a.User.IsInRole("SuperAdmin");

                        });
                        //p.RequireClaim(claimName, "1");
                    });
                }


            });

        }
        public static void AddCustomCompression(this IServiceCollection services)
        {
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.EnableForHttps = true;
            });
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = System.IO.Compression.CompressionLevel.Optimal;
            });

        }
        public static void AddCustomValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateValidator>();
            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddValidator>();
            services.AddTransient<IValidator<AppUserSignInDto>, AppUserSignInValidator>();
            services.AddTransient<IValidator<AppUserPassDto>, AppUserPassValidator>();
            services.AddTransient<IValidator<AppUserProfileDto>, AppUserProfileValidator>();

            services.AddTransient<IValidator<CompanyAddDto>, CompanyAddValidator>();
            services.AddTransient<IValidator<CompanyUpdateDto>, CompanyUpdateValidator>();

            services.AddTransient<IValidator<DepartmentUpdateDto>, DepartmentUpdateValidator>();
            services.AddTransient<IValidator<DepartmentAddDto>, DepartmentAddValidator>();

            services.AddTransient<IValidator<PositionUpdateDto>, PositionUpdateValidator>();
            services.AddTransient<IValidator<PositionAddDto>, PositionAddValidator>();

            services.AddTransient<IValidator<CategoryTicketAddDto>, CategoryTicketAddValidator>();
            services.AddTransient<IValidator<CategoryTicketUpdateDto>, CategoryTicketUpdateValidator>();

            services.AddTransient<IValidator<CheckListAddDto>, CheckListAddValidator>();
            services.AddTransient<IValidator<CheckListUpdateDto>, CheckListUpdateValidator>();
             
            services.AddTransient<IValidator<TicketAddDto>, TicketAddValidator>();
            services.AddTransient<IValidator<TicketUpdateDto>, TicketUpdateValidator>();

            services.AddTransient<IValidator<NewsAddDto>, NewsAddValidator>();
            services.AddTransient<IValidator<NewsUpdateDto>, NewsUpdateValidator>();

            services.AddTransient<IValidator<CategoryNewsAddDto>, CategoryNewsAddValidator>();
            services.AddTransient<IValidator<CategoryNewsUpdateDto>, CategoryNewsUpdateValidator>();

            services.AddTransient<IValidator<CategoryAddDto>, CategoryAddValidator>();
            services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateValidator>();

            services.AddTransient<IValidator<VacancyAddDto>, VacancyAddValidator>();
            services.AddTransient<IValidator<VacancyUpdateDto>, VacancyUpdateValidator>();

            services.AddTransient<IValidator<GradeAddDto>, GradeAddValidator>();
            services.AddTransient<IValidator<GradeUpdateDto>, GradeUpdateValidator>();
            
            services.AddTransient<IValidator<StockAddDto>, StockAddValidator>();
            services.AddTransient<IValidator<StockUpdateDto>, StockUpdateValidator>();
            
            services.AddTransient<IValidator<StockCategoryAddDto>, StockCategoryAddValidator>();
            services.AddTransient<IValidator<StockCategoryUpdateDto>, StockCategoryUpdateValidator>();
        

            services.AddTransient<IValidator<AppRoleAddDto>, AppRoleAddValidator>();
            services.AddTransient<IValidator<AppRoleUpdateDto>, AppRoleUpdateValidator>();

            services.AddTransient<IValidator<NonWorkingYearAddDto>, NonWorkingYearAddValidator>();
            services.AddTransient<IValidator<NonWorkingYearUpdateDto>, NonWorkingYearUpdateValidator>();

            services.AddTransient<IValidator<NonWorkingDayAddDto>, NonWorkingDayAddValidator>();
            services.AddTransient<IValidator<NonWorkingDayUpdateDto>, NonWorkingDayUpdateValidator>();

            services.AddTransient<IValidator<WorkGraphicAddDto>, WorkGraphicAddValidator>();
            services.AddTransient<IValidator<WorkGraphicUpdateDto>, WorkGraphicUpdateValidator>();

            services.AddTransient<IValidator<ContractAddDto>, ContractAddValidator>();
            services.AddTransient<IValidator<ContractUpdateDto>, ContractUpdateValidator>();

            services.AddTransient<IValidator<PersonalContractAddDto>, PersonalContractAddValidator>();
            services.AddTransient<IValidator<PersonalContractUpdateDto>, PersonalContractUpdateValidator>();

            services.AddTransient<IValidator<ClauseAddDto>, ClauseAddValidator>();
            services.AddTransient<IValidator<ClauseUpdateDto>, ClauseUpdateValidator>();

            services.AddTransient<IValidator<UserExperience>, UserExperienceValidator>();

            services.AddTransient<IValidator<CauseAddDto>, CauseAddValidator>();
            services.AddTransient<IValidator<CauseUpdateDto>, CauseUpdateValidator>();

            services.AddTransient<IValidator<PlaceAddDto>, PlaceAddValidator>();
            services.AddTransient<IValidator<PlaceUpdateDto>, PlaceUpdateValidator>();

            services.AddTransient<IValidator<BusinessTripAddDto>, BusinessTripAddValidator>();
            services.AddTransient<IValidator<BusinessTripUpdateDto>, BusinessTripUpdateValidator>();
        }
    }
}
