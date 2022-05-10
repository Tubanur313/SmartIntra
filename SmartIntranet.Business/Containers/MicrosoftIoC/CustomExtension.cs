using SmartIntranet.Business.Concrete;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using SmartIntranet.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using SmartIntranet.Core.Utilities.FileUploader;
using SmartIntranet.Business.Concrete.IntraTicket;
using SmartIntranet.Business.Concrete.Intranet;
using SmartIntranet.Business.Interfaces.Intranet;
using SmartIntranet.Business.Interfaces.Membership;
using SmartIntranet.Business.Concrete.Membership;
using SmartIntranet.Business.Interfaces.IntraTicket;

namespace SmartIntranet.Business.Containers.MicrosoftIoC
{
    public static class CustomExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<INewsService, NewsManager>();
            services.AddScoped<INewsDal, EfNewsRepository>();

            services.AddScoped<INewsFileService, NewsFileManager>();
            services.AddScoped<INewsFileDal, EfNewsFileRepository>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryRepository>();

            services.AddScoped<IUserContractService, UserContractManager>();
            services.AddScoped<IUserContractFileDal, EfUserContractRepository>();

            services.AddScoped<IGradeService, GradeManager>();
            services.AddScoped<IGradeDal, EfGradeRepository>();

            services.AddScoped<IVacancyService, VacancyManager>();
            services.AddScoped<IVacancyDal, EfVacancyRepository>();

            services.AddScoped<ICategoryNewsService, CategoryNewsManager>();
            services.AddScoped<ICategoryNewsDal, EfCategoryNewsRepository>();

            services.AddSingleton<IFileManager, FileManager>();

            services.AddScoped<ICategoryTicketService, CategoryTicketManager>();
            services.AddScoped<ICategoryTicketDal, EfCategoryTicketRepository>();

            services.AddScoped<ISmtpEmailService, SmtpEmailManager>();
            services.AddScoped<ISmtpEmailDal, EfSmtpEmailRepository>();

            services.AddScoped<IAppUserService, AppUserManager>(); 
            services.AddScoped<IAppUserDal, EfAppUserRepository>();

            services.AddScoped<IAppRoleService, AppRoleManager>();
            services.AddScoped<IAppRoleDal, EfAppRoleRepository>();

            services.AddScoped<ICompanyService, CompanyManager>();
            services.AddScoped<ICompanyDal, EfCompanyRepository>();

            services.AddScoped<ICheckListService, CheckListManager>();
            services.AddScoped<IChecklistDal, EfChecklistRepository>();

            services.AddScoped<IDepartmentService, DepartmentManager>();
            services.AddScoped<IDepartmentDal, EfDepartmentRepository>();

            services.AddScoped<IPositionService, PositionManager>();
            services.AddScoped<IPositionDal, EfPositionRepository>();

            services.AddScoped<IDiscussionService, DiscussionManager>();
            services.AddScoped<IDiscussionDal, EfDiscussionRepository>();

            services.AddScoped<IEntranceService, EntranceManager>();
            services.AddScoped<IEntranceDal, EfEntranceRepository>();

            services.AddScoped<IPhotoService, PhotoManager>();
            services.AddScoped<IPhotoDal, EfPhotoRepository>();

            services.AddScoped<IPositionService, PositionManager>();
            services.AddScoped<IPositionDal, EfPositionRepository>();

            services.AddScoped<ITicketCheckListService, TicketCheckListManager>();
            services.AddScoped<ITicketCheckListDal, EfTicketCheckListRepository>();

            services.AddScoped<IWatcherService, WatcherManager>();
            services.AddScoped<IWatcherDal, EfWatcherRepository>();

            services.AddScoped<ITicketService, TicketManager>();
            services.AddScoped<ITicketDal, EfTicketRepository>();
            
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IOrderDal, EfOrderRepository>();  
            
            services.AddScoped<IConfirmTicketUserService, ConfirmTicketUserManager>();
            services.AddScoped<IConfirmTicketUserDal, EfConfirmTicketUserRepository>();
            
            services.AddScoped<ITicketOrderService, TicketOrderManager>();
            services.AddScoped<ITicketOrderDal, EfTicketOrderRepository>();
        }
    }
}
