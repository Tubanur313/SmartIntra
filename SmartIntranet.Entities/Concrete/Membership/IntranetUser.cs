using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.IntraTicket;
using SmartIntranet.Entities.Concrete.Inventary;
using SmartIntranet.Entities.Concrete.Intranet.Archives;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.Entities.Concrete.Membership
{
    public class IntranetUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fathername { get; set; }
        public string Gender { get; set; }
        public string Fullname { get; set; }
        public DateTime StartWorkDate { get; set; }
        public string Pin { get; set; }
        public double Salary { get; set; }
        public int VacationMainDay { get; set; }
        public int VacationExtraChild { get; set; }
        public int VacationExtraExperience { get; set; }
        public int VacationExtraNature { get; set; }
        public string EducationLevel { get; set; }
        public string Citizenship { get; set; }
        public string IdCardType { get; set; }
        public string GraduatedPlace { get; set; }
        public string Profession { get; set; }
        public int? WorkGraphicId { get; set; }
        public WorkGraphic WorkGraphic { get; set; }
        public string IdCardNumber { get; set; } // serial + number
        public DateTime IdCardGiveDate { get; set; }
        public string IdCardGivePlace { get; set; } // veren qurum
        public DateTime? IdCardExpireDate { get; set; }
        public string RegisterAdress { get; set; }
        public string Picture { get; set; } = "default.png";
        public DateTime? Birthday { get; set; }
        public string Address { get; set; }
        public string HomePhoneNumber { get; set; }
        public string PersonalPhoneNumber { get; set; }
        public int? GradeId { get; set; }
        public Grade Grade { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public int? PositionId { get; set; }
        public Position Position { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? UpdateByUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DeleteByUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
        public decimal VacationTotal { get; set; }
        public string SsnCode { get; set; }
        public virtual ICollection<UserContractFile> UserContractFiles { get; set; }
        public virtual ICollection<UserComp> UserComps { get; set; }
        public virtual ICollection<UserExperience> UserExperiences { get; set; }
        public virtual ICollection<UserVacationRemain> UserVacationRemains { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Company> LeaderCompaines { get; set; }
        public virtual ICollection<BusinessTripUser> BusinessTripUsers { get; set; }
        public virtual ICollection<Watcher> Watchers { get; set; }
        public virtual ICollection<ConfirmTicketUser> ConfirmTicketUsers { get; set; }
        public virtual ICollection<Ticket> TicketEmployees { get; set; }
        public virtual ICollection<Ticket> TicketSupporters { get; set; }
        public virtual ICollection<Ticket> TicketUpdates { get; set; }
        public virtual ICollection<Entrance> Entrances { get; set; }
        public virtual ICollection<CategoryTicket> CategoryTickets { get; set; }
        public virtual ICollection<Discussion> Discussions { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<StockDiscuss> StockDiscusses { get; set; }
        public virtual ICollection<Archive> Archives { get; set; }

    }
}
