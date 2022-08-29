using AutoMapper;
using SmartIntranet.DTO.DTOs;
using SmartIntranet.DTO.DTOs.AppRoleDto;
using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.DTO.DTOs.ArchiveDto;
using SmartIntranet.DTO.DTOs.BusinessTripDto;
using SmartIntranet.DTO.DTOs.CategoryDto;
using SmartIntranet.DTO.DTOs.CategoryNewsDto;
using SmartIntranet.DTO.DTOs.CategoryTicketDto;
using SmartIntranet.DTO.DTOs.CauseDto;
using SmartIntranet.DTO.DTOs.CheckListDto;
using SmartIntranet.DTO.DTOs.ClauseDto;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.DTO.DTOs.ConfirmTicketUserDto;
using SmartIntranet.DTO.DTOs.ContractDto;
using SmartIntranet.DTO.DTOs.DepartmentDto;
using SmartIntranet.DTO.DTOs.DiscussionDto;
using SmartIntranet.DTO.DTOs.EmailDto;
using SmartIntranet.DTO.DTOs.EntranceDto;
using SmartIntranet.DTO.DTOs.FaqDto;
using SmartIntranet.DTO.DTOs.GradeDto;
using SmartIntranet.DTO.DTOs.InventaryDtos.StockCategoryDto;
using SmartIntranet.DTO.DTOs.InventaryDtos.StockDiscussDto;
using SmartIntranet.DTO.DTOs.InventaryDtos.StockDto;
using SmartIntranet.DTO.DTOs.InventaryDtos.StockImageDto;
using SmartIntranet.DTO.DTOs.NewsDto;
using SmartIntranet.DTO.DTOs.NewsFileDto;
using SmartIntranet.DTO.DTOs.OrderDto;
using SmartIntranet.DTO.DTOs.PersonalContractDto;
using SmartIntranet.DTO.DTOs.PhotoDto;
using SmartIntranet.DTO.DTOs.PlaceDto;
using SmartIntranet.DTO.DTOs.PositionDto;
using SmartIntranet.DTO.DTOs.ReportEmployeeDto;
using SmartIntranet.DTO.DTOs.TerminationContractDto;
using SmartIntranet.DTO.DTOs.TerminationItemDto;
using SmartIntranet.DTO.DTOs.TicketCheckListDto;
using SmartIntranet.DTO.DTOs.TicketDto;
using SmartIntranet.DTO.DTOs.TicketOrderDto;
using SmartIntranet.DTO.DTOs.TicketTripDtos.BusinessTravelDtos;
using SmartIntranet.DTO.DTOs.TicketTripDtos.PermissionDtos;
using SmartIntranet.DTO.DTOs.TicketTripDtos.VacationLeaveDtos;
using SmartIntranet.DTO.DTOs.UserCompDto;
using SmartIntranet.DTO.DTOs.UserContractDto;
using SmartIntranet.DTO.DTOs.VacancyDto;
using SmartIntranet.DTO.DTOs.WatcherDto;
using SmartIntranet.DTO.DTOs.WorkGraphicDto;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.IntraHr;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.Intranet.Archives;
using SmartIntranet.Entities.Concrete.Intranet.FAQ;
using SmartIntranet.Entities.Concrete.IntraTicket;
using SmartIntranet.Entities.Concrete.IntraTicket.TicketTripEnts;
using SmartIntranet.Entities.Concrete.Inventary;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Linq;

namespace SmartIntranet.Business.DependencyResolvers.Automapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region UserComp-UserCompDto
            CreateMap<UserComp, UserCompAddDto>().ReverseMap();
            
            #endregion


            #region IntranetRole-AppUserDto
            CreateMap<IntranetUser, AppUserClaimsDto>();
            CreateMap<IntranetRole, AppRoleClaimsDto>();
            CreateMap<IntranetUser, AppUserDetailsDto>()
              .ForMember(u => u.FullName, opt => opt.MapFrom(src => src.Name + " " + src.Surname))
              .ForMember(d => d.Company, opt => opt.MapFrom(src => src.Company.Name))
              .ForMember(d => d.Department, opt => opt.MapFrom(src => src.Department.Name))
              .ForMember(d => d.Position, opt => opt.MapFrom(src => src.Position.Name));
            #endregion

            #region IntranetRole-AppRoleDto
            CreateMap<AppRoleAddDto, IntranetRole>();
            CreateMap<IntranetRole, AppRoleAddDto>();
            CreateMap<AppRoleListDto, IntranetRole>();
            CreateMap<IntranetRole, AppRoleListDto>();
            CreateMap<AppRoleUpdateDto, IntranetRole>();
            CreateMap<IntranetRole, AppRoleUpdateDto>();
            #endregion

            #region UserContractFile<->UserContractDto
            CreateMap<UserContractAddDto, UserContractFile>();
            CreateMap<UserContractFile, UserContractAddDto>();
            CreateMap<UserContractListDto, UserContractFile>();
            CreateMap<UserContractFile, UserContractListDto>();

            #endregion

            #region AppUser <-> AppUserDto
            CreateMap<AppUserAddDto, IntranetUser>();
            CreateMap<IntranetUser, AppUserAddDto>(); 

            CreateMap<AppUserListDto, IntranetUser>();
            CreateMap<IntranetUser, AppUserListDto>();

            CreateMap<AppUserPassDto, IntranetUser>();
            CreateMap<IntranetUser, AppUserPassDto>();

            CreateMap<AppUserInfoDto, IntranetUser>();
            CreateMap<IntranetUser, AppUserInfoDto>();

            CreateMap<AppUserSignInDto, IntranetUser>();
            CreateMap<IntranetUser, AppUserSignInDto>();

            CreateMap<AppUserProfileDto, IntranetUser>();
            CreateMap<IntranetUser, AppUserProfileDto>();

            CreateMap<AppUserUpdateDto, IntranetUser>();
            //.ForMember(u => u.FullName, opt => opt.MapFrom(src => src.Name + " " + src.Surname));
            CreateMap<IntranetUser, AppUserUpdateDto>();
            //.ForMember(u => u.Name, opt => opt.MapFrom(src => src.FullName.Split(' ', StringSplitOptions.None).FirstOrDefault()))
            //.ForMember(u => u.Surname, opt => opt.MapFrom(src => src.FullName.Split(' ', StringSplitOptions.None).LastOrDefault()));

            CreateMap<AppUserClaimsDto, IntranetUser>();
            CreateMap<IntranetUser, AppUserClaimsDto>();

            CreateMap<AppRoleClaimsDto, IntranetRole>();
            CreateMap<IntranetRole, AppRoleClaimsDto>();

            CreateMap<AppUserImageDto, IntranetUser>();
            CreateMap<IntranetUser, AppUserImageDto>();

            CreateMap<AppUserContactListDto, IntranetUser>();
            CreateMap<IntranetUser, AppUserContactListDto>();

            #endregion

            #region Company <-> CompanyDto
            CreateMap<CompanyAddDto, Company>();
            CreateMap<Company, CompanyAddDto>();
            CreateMap<AjaxCompanyAddDto, Company>()
                .ForMember(p => p.Name, opt => opt.MapFrom(src => src.Company_Name))
                .ForMember(p => p.Description, opt => opt.MapFrom(src => src.Company_Description))
                .ForMember(p => p.Parent, opt => opt.MapFrom(src => src.Company_Parent))
                .ForMember(p => p.ParentId, opt => opt.MapFrom(src => src.Company_ParentId));
            CreateMap<CompanyListDto, Company>();
            CreateMap<Company, CompanyListDto>();
            CreateMap<CompanyUpdateDto, Company>();
            CreateMap<Company, CompanyUpdateDto>();
            #endregion  

            #region CategoryTicket <-> CategoryTicketDto
            CreateMap<CategoryTicketAddDto, CategoryTicket>();
            CreateMap<CategoryTicket, CategoryTicketAddDto>();
            CreateMap<CategoryTicketListDto, CategoryTicket>();
            CreateMap<CategoryTicket, CategoryTicketListDto>();
            CreateMap<CategoryTicketUpdateDto, CategoryTicket>();
            CreateMap<CategoryTicket, CategoryTicketUpdateDto>();
            #endregion

            #region  Category <-> CategoryListDto
            CreateMap<CategoryAddDto, Category>();
            CreateMap<Category, CategoryAddDto>();
            CreateMap<CategoryListDto, Category>();
            CreateMap<Category, CategoryListDto>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryUpdateDto>();
            #endregion

            #region  CategoryNews <-> CategoryNewsDto
            CreateMap<CategoryNewsListDto, CategoryNews>();
            CreateMap<CategoryNews, CategoryNewsListDto>();
            CreateMap<CategoryNewsAddDto, CategoryNews>();
            CreateMap<CategoryNews, CategoryNewsAddDto>();
            CreateMap<CategoryNewsUpdateDto, CategoryNews>();
            CreateMap<CategoryNews, CategoryNewsUpdateDto>()
                .ForMember(d => d.Title, opt => opt.MapFrom(src => src.News.Title))
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.News.Id))
                .ForMember(d => d.NewsId, opt => opt.MapFrom(src => src.NewsId))
                .ForMember(d => d.Description, opt => opt.MapFrom(src => src.News.Description))
                .ForMember(d => d.IsDeleted, opt => opt.MapFrom(src => src.News.IsDeleted));

            #endregion

            #region Vacancy-VacancytDto
            CreateMap<VacancyAddDto, Vacancy>();
            CreateMap<Vacancy, VacancyAddDto>();
            CreateMap<VacancyListDto, Vacancy>();
            CreateMap<Vacancy, VacancyListDto>();
            CreateMap<VacancyUpdateDto, Vacancy>();
            CreateMap<Vacancy, VacancyUpdateDto>();

            #endregion
            
            #region CheckList <-> CheckListDto
            CreateMap<CheckListAddDto, CheckList>();
            CreateMap<CheckList, CheckListAddDto>();
            CreateMap<CheckListListDto, CheckList>();
            CreateMap<CheckList, CheckListListDto>();
            CreateMap<CheckListUpdateDto, CheckList>();
            CreateMap<CheckList, CheckListUpdateDto>();
            #endregion

            #region Department <-> DepartmentDto
            CreateMap<DepartmentAddDto, Department>();
            CreateMap<Department, DepartmentAddDto>();
            CreateMap<DepartmentListDto, Department>();
            CreateMap<Department, DepartmentListDto>();
            CreateMap<DepartmentUpdateDto, Department>();
            CreateMap<Department, DepartmentUpdateDto>();
            #endregion

            #region Email <-> EmailDto
            CreateMap<EmailListDto, SMTPEmailSetting>();
            CreateMap<SMTPEmailSetting, EmailListDto>();
            #endregion

            #region Email <-> EmailDto
            CreateMap<SettingsDto, Settings>();
            CreateMap<Settings, SettingsDto>();
            #endregion
            #region Discussion <-> DiscussionDto
            CreateMap<DiscussionAddDto, Discussion>();
            CreateMap<Discussion, DiscussionAddDto>();
            CreateMap<DiscussionListDto, Discussion>();
            CreateMap<Discussion, DiscussionListDto>();
            CreateMap<DiscussionListSecondDto, Discussion>();
            CreateMap<Discussion, DiscussionListSecondDto>();
            #endregion 

            #region StockDiscuss <-> StockDiscussDto
            CreateMap<StockDiscussAddDto, StockDiscuss>();
            CreateMap<StockDiscuss, StockDiscussAddDto>();
            CreateMap<StockDiscussListDto, StockDiscuss>();
            CreateMap<StockDiscuss, StockDiscussListDto>();
            CreateMap<StockDiscussListSecondDto, StockDiscuss>();
            CreateMap<StockDiscuss, StockDiscussListSecondDto>();
            #endregion

            #region Entrance <-> EntranceDto
            CreateMap<EntranceAddDto, Entrance>();
            CreateMap<Entrance, EntranceAddDto>();
            CreateMap<EntranceUpdateDto, Entrance>();
            CreateMap<Entrance, EntranceUpdateDto>();
            CreateMap<EntranceListDto, Entrance>();
            CreateMap<Entrance, EntranceListDto>();
            #endregion

            #region Photo <-> PhotoDto
            CreateMap<PhotoAddDto, Photo>();
            CreateMap<Photo, PhotoAddDto>();
            CreateMap<PhotoListDto, Photo>();
            CreateMap<Photo, PhotoListDto>();
            #endregion

            #region Position <-> PositionDto
            CreateMap<PositionAddDto, Position>();
            CreateMap<Position, PositionAddDto>();
            CreateMap<PositionUpdateDto, Position>();
            CreateMap<Position, PositionUpdateDto>();
            CreateMap<PositionListDto, Position>();
            CreateMap<Position, PositionListDto>();
            #endregion

            #region TicketCheckList <-> TicketCheckListDto
            CreateMap<TicketCheckListAddDto, TicketCheckList>();
            CreateMap<TicketCheckList, TicketCheckListAddDto>();
            CreateMap<TicketCheckListUpdateDto, TicketCheckList>();
            CreateMap<TicketCheckList, TicketCheckListUpdateDto>();
            CreateMap<TicketCheckListListDto, TicketCheckList>();
            CreateMap<TicketCheckList, TicketCheckListListDto>();
            #endregion

            #region Ticket <-> TicketDto
            CreateMap<TicketAddDto, Ticket>()
                .ForMember(t => t.CategoryTicketId, opt => opt.MapFrom(src => src.TicketCategoryId))
                .ForMember(u => u.DeadLineStart, opt => opt.MapFrom(src =>
                DateTime.ParseExact(src.DeadLine.Split('-', StringSplitOptions.None).FirstOrDefault(), "dd/MM/yyyy", null)))
                .ForMember(u => u.DeadLineEnd, opt => opt.MapFrom(src =>
                DateTime.ParseExact(src.DeadLine.Split('-', StringSplitOptions.None).LastOrDefault(), "dd/MM/yyyy", null)));
            CreateMap<Ticket, TicketAddDto>()
                .ForMember(t => t.TicketCategoryId, opt => opt.MapFrom(src =>src.CategoryTicketId));
            CreateMap<TicketUpdateDto, Ticket>();
            CreateMap<Ticket, TicketUpdateDto>()
                .ForMember(d => d.DeadLine, opt => opt
                 .MapFrom(src => string.Join("-", new string[] { src.DeadLineStart.Value.ToString("dd/MM/yyyy"), src.DeadLineEnd.Value.ToString("dd/MM/yyyy") })));
            CreateMap<Ticket, TicketInfoDto>();
            CreateMap<TicketListDto, Ticket>();
            CreateMap<Ticket, TicketStatusDto>();
            CreateMap<Ticket, TicketPriorityDto>();
            CreateMap<Ticket, TicketRedirectDto>();
            CreateMap<Ticket, TicketWathcersDto>();
            CreateMap<Ticket, TicketConfirmDto>();
            CreateMap<Ticket, TicketCheklistDto>();
            CreateMap<TicketCheklistDto, Ticket>();
            CreateMap<Ticket, TicketListDto>();
            CreateMap<Ticket, TicketCategoryDto>()
                .ForMember(t => t.TicketCategoryId, opt => opt.MapFrom(src => src.CategoryTicketId));
            #endregion

            #region Watcher <-> WatcherDto
            CreateMap<WatcherAddDto, Watcher>();
            CreateMap<Watcher, WatcherAddDto>();
            CreateMap<WatcherUpdateDto, Watcher>();
            CreateMap<Watcher, WatcherUpdateDto>();
            CreateMap<WatcherListDto, Watcher>();
            CreateMap<Watcher, WatcherListDto>();
            #endregion

            #region ConfirmTicketUser <-> ConfirmTicketUserDto
            CreateMap<ConfirmTicketUserAddDto, ConfirmTicketUser>();
            CreateMap<ConfirmTicketUser, ConfirmTicketUserAddDto>();
            CreateMap<ConfirmTicketUserUpdateDto, ConfirmTicketUser>();
            CreateMap<ConfirmTicketUser, ConfirmTicketUserUpdateDto>();
            CreateMap<ConfirmTicketUserListDto, ConfirmTicketUser>();
            CreateMap<ConfirmTicketUser, ConfirmTicketUserListDto>();
            #endregion

            #region Order <-> OrderDto
            CreateMap<OrderAddDto, Order>();
            CreateMap<Order, OrderAddDto>();
            CreateMap<OrderListDto, Order>();
            CreateMap<Order, OrderListDto>();
            #endregion

            #region TicketOrder <-> TicketOrderDto
            CreateMap<TicketOrderAddDto, TicketOrder>();
            CreateMap<TicketOrder, TicketOrderAddDto>();
            CreateMap<TicketOrderListDto, TicketOrder>();
            CreateMap<TicketOrder, TicketOrderListDto>();
            #endregion

            #region UserContractFile<->UserContractDto
            CreateMap<UserContractAddDto, UserContractFile>();
            CreateMap<UserContractFile, UserContractAddDto>();
            CreateMap<UserContractListDto, UserContractFile>();
            CreateMap<UserContractFile, UserContractListDto>();

            #endregion

            #region  Category <-> CategoryListDto
            CreateMap<CategoryAddDto, Category>();
            CreateMap<Category, CategoryAddDto>();
            CreateMap<CategoryListDto, Category>();
            CreateMap<Category, CategoryListDto>();
            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryUpdateDto>();
            #endregion  

            #region  News <-> NewsDto
            CreateMap<NewsAddDto, News>();
            CreateMap<News, NewsAddDto>();
            CreateMap<NewsUpdateDto, News>();
            CreateMap<News, NewsUpdateDto>();
            CreateMap<NewsListDto, News>();
            CreateMap<News, NewsListDto>();
            #endregion

            #region  Grades <-> GradeDto
            CreateMap<GradeAddDto, Grade>();
            CreateMap<Grade, GradeAddDto>();
            CreateMap<GradeUpdateDto, Grade>();
            CreateMap<Grade, GradeUpdateDto>();
            CreateMap<GradeListDto, Grade>();
            CreateMap<Grade, GradeListDto>();
            #endregion

            #region  NewsFile <-> NewsFileDto
            CreateMap<NewsFileAddDto, NewsFile>();
            CreateMap<NewsFile, NewsFileAddDto>();
            CreateMap<NewsFileListDto, NewsFile>();
            CreateMap<NewsFile, NewsFileListDto>();

            #endregion

            #region  Stock <-> StockDto
            CreateMap<StockAddDto, Stock>()
            .ForMember(dest => dest.DepreciationPercent,
              opt => opt.MapFrom(src => Convert.ToString(src.DepreciationPercent
              .Split(" ", StringSplitOptions.None).FirstOrDefault()).Replace(".", ",")))
            .ForMember(dest => dest.Price,
              opt => opt.MapFrom(src => Convert.ToString(src.Price.Replace(",", "").Replace(".", ","))));
            CreateMap<Stock, StockAddDto>()
                .ForMember(dest => dest.DepreciationPercent,
                  opt => opt.MapFrom(src => Convert.ToDecimal(src.DepreciationPercent)))
            .ForMember(dest => dest.Price,
                  opt => opt.MapFrom(src => Convert.ToDecimal(src.Price)));
            CreateMap<StockListDto, Stock>();
            CreateMap<Stock, StockListDto>();
            CreateMap<StockUpdateDto, Stock>()
            .ForMember(dest => dest.DepreciationPercent,
              opt => opt.MapFrom(src => Convert.ToString(src.DepreciationPercent
              .Split(" ", StringSplitOptions.None).FirstOrDefault()).Replace(".", ",")))
            .ForMember(dest => dest.Price,
              opt => opt.MapFrom(src => Convert.ToString(src.Price.Replace(",", "").Replace(".", ","))));
            CreateMap<Stock, StockUpdateDto>()
                .ForMember(dest => dest.DepreciationPercent,
                  opt => opt.MapFrom(src => Convert.ToDecimal(src.DepreciationPercent)))
                .ForMember(dest => dest.Price,
                  opt => opt.MapFrom(src => src.Price.ToString()));

            #endregion 
            #region  StockCategory <-> StockCategoryDto
            CreateMap<StockCategoryAddDto, StockCategory>();
            CreateMap<StockCategory, StockCategoryAddDto>();
            CreateMap<StockCategoryListDto, StockCategory>();
            CreateMap<StockCategory, StockCategoryListDto>();
            CreateMap<StockCategoryUpdateDto, StockCategory>();
            CreateMap<StockCategory, StockCategoryUpdateDto>();

            #endregion

            #region NonWorkingYear-NonWorkingYearDto
            CreateMap<NonWorkingYearAddDto, NonWorkingYear>().ReverseMap();
            CreateMap<NonWorkingYearListDto, NonWorkingYear>().ReverseMap();
            CreateMap<NonWorkingYearUpdateDto, NonWorkingYear>().ReverseMap();
            #endregion
            #region NonWorkingDay-NonWorkingDayDto
            CreateMap<NonWorkingDayAddDto, NonWorkingDay>().ReverseMap();
            CreateMap<NonWorkingDayListDto, NonWorkingDay>().ReverseMap();
            CreateMap<NonWorkingDayUpdateDto, NonWorkingDay>().ReverseMap();
            #endregion

            #region WorkGraphic-WorkGraphicDto
            CreateMap<WorkGraphicAddDto, WorkGraphic>().ReverseMap();
            CreateMap<WorkGraphicListDto, WorkGraphic>().ReverseMap();
            CreateMap<WorkGraphicUpdateDto, WorkGraphic>().ReverseMap();
            #endregion
            #region WorkCalendar-WorkCalendarDto
            CreateMap<WorkCalendarAddDto, WorkCalendar>().ReverseMap();
            CreateMap<WorkCalendarListDto, WorkCalendar>().ReverseMap();
            CreateMap<WorkCalendarUpdateDto, WorkCalendar>().ReverseMap();
            #endregion

            #region Contract-ContractDto
            CreateMap<ContractAddDto, Contract>().ReverseMap();
            CreateMap<ContractListDto, Contract>().ReverseMap();
            CreateMap<ContractUpdateDto, Contract>().ReverseMap();
            #endregion

            #region Clause-ClauseDto
            CreateMap<ClauseAddDto, Clause>().ReverseMap();
            CreateMap<ClauseListDto, Clause>().ReverseMap();
            CreateMap<ClauseUpdateDto, Clause>().ReverseMap();
            #endregion

            #region Cause-CauseDto
            CreateMap<CauseAddDto, Cause>().ReverseMap();
            CreateMap<CauseListDto, Cause>().ReverseMap();
            CreateMap<CauseUpdateDto, Cause>().ReverseMap();
            #endregion

            #region Place-PlaceDto
            CreateMap<PlaceAddDto, Place>().ReverseMap();
            CreateMap<PlaceListDto, Place>().ReverseMap();
            CreateMap<PlaceUpdateDto, Place>().ReverseMap();
            #endregion

            #region PersonalContract-PersonalContractDto
            CreateMap<PersonalContractAddDto, PersonalContract>().ReverseMap();
            CreateMap<PersonalContractListDto, PersonalContract>().ReverseMap();
            CreateMap<PersonalContractUpdateDto, PersonalContract>().ReverseMap();
            CreateMap<ContractListDto, PersonalContract>().ReverseMap();
            CreateMap<ContractListDto, TerminationContract>().ReverseMap();
            #endregion

            #region UserVacationRemain-UserVacationRemainDto
            CreateMap<UserVacationRemainAddDto, UserVacationRemain>().ReverseMap();
            CreateMap<UserVacationRemainListDto, UserVacationRemain>().ReverseMap();
            CreateMap<UserVacationRemainUpdateDto, UserVacationRemain>().ReverseMap();
            #endregion

            #region VacationContract-VacationContractDto
            CreateMap<VacationContract, VacationContractAddDto>().ReverseMap();
            CreateMap<VacationContract, VacationContractUpdateDto>().ReverseMap();
            CreateMap<VacationContract, VacationContractListDto>().ReverseMap();
            CreateMap<ContractListDto, VacationContract>().ReverseMap();
            #endregion

            #region BusinessTrip-BusinessTripDto
            CreateMap<BusinessTripAddDto, BusinessTrip>().ReverseMap();
            CreateMap<BusinessTripListDto, BusinessTrip>().ReverseMap();
            CreateMap<BusinessTripUpdateDto, BusinessTrip>().ReverseMap();
            CreateMap<ContractListDto, BusinessTrip>().ReverseMap();
            #endregion

            #region TerminationItem-TerminationItemDto
            CreateMap<TerminationItemAddDto, TerminationItem>().ReverseMap();
            CreateMap<TerminationItemListDto, TerminationItem>().ReverseMap();
            CreateMap<TerminationItemUpdateDto, TerminationItem>().ReverseMap();
            #endregion

            #region TerminationContract-TerminationContractDto
            CreateMap<TerminationContractAddDto, TerminationContract>().ReverseMap();
            CreateMap<TerminationContractListDto, TerminationContract>().ReverseMap();
            CreateMap<TerminationContractUpdateDto, TerminationContract>().ReverseMap();
            #endregion

            #region ReportEmployee-ReportEmployeeDto
            CreateMap<ReportEmployeeDto, ReportEmployee>().ReverseMap();
            CreateMap<ReportEmployeeListDto, ReportEmployee>().ReverseMap();
            #endregion
            #region Stock Images <-> Stock ImagesDto
            CreateMap<StockImageAddDto, StockImage>();
            CreateMap<StockImage, StockImageAddDto>();
            CreateMap<StockImageListDto, StockImage>();
            CreateMap<StockImage, StockImageListDto>();
            CreateMap<Stock, StockInfoDto>();
            #endregion

            #region StockDiscuss <-> StockDiscussDto
            CreateMap<StockDiscussAddDto, Discussion>();
            CreateMap<StockDiscuss, StockDiscussAddDto>();
            CreateMap<StockDiscussListDto, StockDiscuss>();
            CreateMap<StockDiscuss, StockDiscussListDto>();
            CreateMap<StockDiscussListSecondDto, StockDiscuss>();
            CreateMap<StockDiscuss, StockDiscussListSecondDto>();
            #endregion

            #region LongContract-LongContractDto
            CreateMap<LongContractAddDto, LongContract>().ReverseMap();
            CreateMap<LongContractListDto, LongContract>().ReverseMap();
            CreateMap<LongContractUpdateDto, LongContract>().ReverseMap();
            CreateMap<ContractListDto, LongContract>().ReverseMap();
            #endregion
            #region BusinessTravel-BusinessTravelDto
            CreateMap<BusinessTravelAddDto, BusinessTravel>().ReverseMap();
            CreateMap<BusinessTravelUpdateDto, BusinessTravel>().ReverseMap();
            #endregion

            #region VacationLeave-VacationLeaveDto
            CreateMap<VacationLeaveAddDto, VacationLeave>().ReverseMap();
            CreateMap<VacationLeaveUpdateDto, VacationLeave>().ReverseMap();
            #endregion

            #region Permission-PermissionDto
            CreateMap<PermissionAddDto, Permission>().ReverseMap();
            CreateMap<PermissionUpdateDto, Permission>().ReverseMap();
            #endregion

            #region Faq-FaqDto
            CreateMap<FaqAddDto, Faq>().ReverseMap();
            CreateMap<FaqUpdateDto, Faq>().ReverseMap();
            CreateMap<FaqListDto, Faq>().ReverseMap();
            #endregion            

            #region Archive-ArchiveDto
            CreateMap<ArchiveAddDto, Archive>().ReverseMap();
            CreateMap<ArchiveUpdateDto, Archive>().ReverseMap();
            CreateMap<ArchiveListDto, Archive>().ReverseMap();
            #endregion
        }
    }

}
