using Microsoft.AspNetCore.Identity;
using SmartIntranet.Core.Entities.Abstract;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.IntraTicket;
using System;
using System.Collections.Generic;

namespace SmartIntranet.Entities.Concrete.Membership
{
    public class IntranetUser : IdentityUser<int>, IStatus, ICreatedByUser, IUpdateByUserId, IDeleteByUser
    {
        //public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Picture { get; set; } 
        public DateTime? Birthday { get; set; }
        public string Address { get; set; }

        public int? GradeId { get; set; }
        public Grade Grade { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public int? PositionId { get; set; }
        public Position Position { get; set; }

        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdateByUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DeleteByUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<UserContractFile> UserContractFiles { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Watcher> Watchers { get; set; }
        public virtual ICollection<ConfirmTicketUser> ConfirmTicketUsers { get; set; }
        public virtual ICollection<Ticket> TicketEmployees { get; set; }
        public virtual ICollection<Ticket> TicketSupporters { get; set; }
        public virtual ICollection<Ticket> TicketUpdates { get; set; }
        public virtual ICollection<Entrance> Entrances { get; set; }
        public virtual ICollection<CategoryTicket> CategoryTickets { get; set; }
        public virtual ICollection<Discussion> Discussions { get; set; }

    }
}
