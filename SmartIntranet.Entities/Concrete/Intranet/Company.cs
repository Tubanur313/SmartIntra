using SmartIntranet.Core.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System.Collections.Generic;


namespace SmartIntranet.Entities.Concrete.Intranet
{

    public class Company : BaseEntity
    {
        //public int Id { get; set; }
        public int? ParentId { get; set; }
        public virtual Company Parent { get; set; }
        public virtual ICollection<Company> Children { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
        public virtual ICollection<IntranetUser> IntranetUsers { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
        public string LogoPath { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
