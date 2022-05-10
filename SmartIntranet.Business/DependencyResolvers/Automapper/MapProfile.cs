using AutoMapper;
using SmartIntranet.DTO.DTOs.AppRoleDto;
using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.DTO.DTOs.CategoryDto;
using SmartIntranet.DTO.DTOs.CategoryNewsDto;
using SmartIntranet.DTO.DTOs.CategoryTicketDto;
using SmartIntranet.DTO.DTOs.CheckListDto;
using SmartIntranet.DTO.DTOs.CompanyDto;
using SmartIntranet.DTO.DTOs.ConfirmTicketUserDto;
using SmartIntranet.DTO.DTOs.DepartmentDto;
using SmartIntranet.DTO.DTOs.DiscussionDto;
using SmartIntranet.DTO.DTOs.EmailDto;
using SmartIntranet.DTO.DTOs.EntranceDto;
using SmartIntranet.DTO.DTOs.GradeDto;
using SmartIntranet.DTO.DTOs.NewsDto;
using SmartIntranet.DTO.DTOs.NewsFileDto;
using SmartIntranet.DTO.DTOs.OrderDto;
using SmartIntranet.DTO.DTOs.PhotoDto;
using SmartIntranet.DTO.DTOs.PositionDto;
using SmartIntranet.DTO.DTOs.TicketCheckListDto;
using SmartIntranet.DTO.DTOs.TicketDto;
using SmartIntranet.DTO.DTOs.TicketOrderDto;
using SmartIntranet.DTO.DTOs.UserContractDto;
using SmartIntranet.DTO.DTOs.VacancyDto;
using SmartIntranet.DTO.DTOs.WatcherDto;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.IntraTicket;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Linq;

namespace SmartIntranet.Business.DependencyResolvers.Automapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region IntranetRole-AppUserDto
            CreateMap<IntranetUser, AppUserClaimsDto>();
            CreateMap<IntranetRole, AppRoleClaimsDto>();
            CreateMap<IntranetUser, AppUserDetailsDto>()
              //.ForMember(d => d.FullName, opt => opt.MapFrom(src => src.FullName))
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
            //.ForMember(u => u.FullName, opt => opt.MapFrom(src => src.Name + " " + src.Surname));
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

            #region Discussion <-> DiscussionDto
            CreateMap<DiscussionAddDto, Discussion>();
            CreateMap<Discussion, DiscussionAddDto>();
            CreateMap<DiscussionUpdateDto, Discussion>();
            CreateMap<Discussion, DiscussionUpdateDto>();
            CreateMap<DiscussionListDto, Discussion>();
            CreateMap<Discussion, DiscussionListDto>();
            CreateMap<DiscussionListSecondDto, Discussion>();
            CreateMap<Discussion, DiscussionListSecondDto>();
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
            CreateMap<PhotoUpdateDto, Photo>();
            CreateMap<Photo, PhotoUpdateDto>();
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
                .ForMember(u => u.DeadLineStart, opt => opt.MapFrom(src =>
                DateTime.ParseExact(src.DeadLine.Split('-', StringSplitOptions.None).FirstOrDefault(), "dd/MM/yyyy", null)))
                .ForMember(u => u.DeadLineEnd, opt => opt.MapFrom(src =>
                DateTime.ParseExact(src.DeadLine.Split('-', StringSplitOptions.None).LastOrDefault(), "dd/MM/yyyy", null)));
            CreateMap<Ticket, TicketAddDto>();
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
            CreateMap<Ticket, TicketCategoryDto>();
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
        }
    }

}
