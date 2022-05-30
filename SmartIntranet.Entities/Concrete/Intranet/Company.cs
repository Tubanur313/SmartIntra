using SmartIntranet.Core.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System.Collections.Generic;


namespace SmartIntranet.Entities.Concrete.Intranet
{

    public class Company : BaseEntity
    {
        public int? ParentId { get; set; }
        public string LogoPath { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LeaderPosition { get; set; }
        public string Tin { get; set; }
        public string Address { get; set; }
        public string BankName { get; set; }
        public string BankTin { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankCode { get; set; }
        public string SWIFTCode { get; set; }
        public string CorrespondentAccountNumber { get; set; }
        public int? LeaderId { get; set; }
        public virtual IntranetUser Leader { get; set; }
        public virtual Company Parent { get; set; }

        public virtual ICollection<Company> Children { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
        public virtual ICollection<IntranetUser> IntranetUsers { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }
}
