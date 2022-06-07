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
using SmartIntranet.Business.Concrete.Inventary;
using SmartIntranet.Business.Interfaces.Inventary;
using SmartIntranet.DataAccess.Interfaces.Inventary;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.Inventary;

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

            services.AddScoped<Interfaces.Membership.IUserContractService, Concrete.Membership.UserContractManager>();
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

            services.AddScoped<IReportEmployeeService, ReportEmployeeManager>();
            services.AddScoped<IReportEmployeeDal, EfReportEmployeeRepository>();

            services.AddScoped<IVacancyService, VacancyManager>();
            services.AddScoped<IVacancyDal, EfVacancyRepository>();

            services.AddScoped<ICategoryNewsService, CategoryNewsManager>();
            services.AddScoped<ICategoryNewsDal, EfCategoryNewsRepository>();

            services.AddScoped<INonWOrkingYearService, NonWorkingYearManager>();
            services.AddScoped<INonWorkingYearDal, EfNonWorkingYearRepository>();

            services.AddScoped<INonWorkingDayService, NonWorkingDayManager>();
            services.AddScoped<INonWorkingDayDal, EfNonWorkingDayRepository>();

            services.AddScoped<IWorkGraphicService, WorkGraphicManager>();
            services.AddScoped<IWorkGraphicDal, EfWorkGraphicRepository>();

            services.AddScoped<IWorkCalendarService, WorkCalendarManager>();
            services.AddScoped<IWorkCalendarDal, EfWorkCalendarRepository>();

            services.AddScoped<IContractService, ContractManager>();
            services.AddScoped<IContractDal, EfContractRepository>();

            services.AddScoped<IContractTypeService, ContractTypeManager>();
            services.AddScoped<IContractTypeDal, EfContractTypeRepository>();

            services.AddScoped<IContractFileService, ContractFileManager>();
            services.AddScoped<IContractFileDal, EfContractFileRepository>();

            services.AddScoped<IClauseService, ClauseManager>();
            services.AddScoped<IClauseDal, EfClauseRepository>();

            services.AddScoped<IPersonalContractService, PersonalContractManager>();
            services.AddScoped<IPersonalContractDal, EfPersonalContractRepository>();

            services.AddScoped<IPersonalContractFileService, PersonalContractFileManager>();
            services.AddScoped<IPersonalContractFileDal, EfPersonalContractFileRepository>();

            services.AddScoped<IUserVacationRemainService, UserVacationRemainManager>();
            services.AddScoped<IUserVacationRemainDal, EfUserVacationRemainRepository>();

            services.AddScoped<IVacationContractService, VacationContractManager>();
            services.AddScoped<IVacationContractDal, EfVacationContractRepository>();

            services.AddScoped<IVacationContractFileService, VacationContractFileManager>();
            services.AddScoped<IVacationContractFileDal, EfVacationContractFileRepository>();

            services.AddScoped<ITerminationContractService, TerminationContractManager>();
            services.AddScoped<ITerminationContractDal, EfTerminationContractRepository>();

            services.AddScoped<ITerminationContractFileService, TerminationContractFileManager>();
            services.AddScoped<ITerminationContractFileDal, EfTerminationContractFileRepository>();

            services.AddScoped<ITerminationItemService, TerminationItemManager>();
            services.AddScoped<ITerminationItemDal, EfTerminationItemRepository>();

            services.AddScoped<IVacationTypeService, VacationTypeManager>();
            services.AddScoped<IVacationTypeDal, EfVacationTypeRepository>();
            services.AddScoped<ICauseService, CauseManager>();
            services.AddScoped<ICauseDal, EfCauseRepository>();

            services.AddScoped<IPlaceService, PlaceManager>();
            services.AddScoped<IPlaceDal, EfPlaceRepository>();

            services.AddScoped<IBusinessTripService, BusinessTripManager>();
            services.AddScoped<IBusinessTripDal, EfBusinessTripRepository>();

            services.AddScoped<IBusinessTripFileService, BusinessTripFileManager>();
            services.AddScoped<IBusinessTripFileDal, EfBusinessTripFileRepository>();
            //inventary
            
            services.AddScoped<IStockService, StockManager>();
            services.AddScoped<IStockDal, EfStockRepository>();

            services.AddScoped<IStockCategoryService, StockCategoryManager>();
            services.AddScoped<IStockCategoryDal, EfStockCategoryRepository>();

            services.AddScoped<IStockDiscussService, StockDiscussManager>();
            services.AddScoped<IStockDiscussDal, EfStockDiscussRepository>(); 

            services.AddScoped<IStockImageService, StockImageManager>();
            services.AddScoped<IStockImageDal, EfStockImageRepository>();

            services.AddScoped<ILongContractService, LongContractManager>();
            services.AddScoped<ILongContractDal, EfLongContractRepository>();

            services.AddScoped<ILongContractFileService, LongContractFileManager>();
            services.AddScoped<ILongContractFileDal, EfLongContractFileRepository>();
        }
    }
}
