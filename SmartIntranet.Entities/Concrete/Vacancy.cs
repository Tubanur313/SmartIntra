using SmartIntranet.Core.Entities.Concrete;
using System;

namespace SmartIntranet.Entities.Concrete
{
    public class Vacancy : BaseEntity
    {
        //public int Id { get; set; }
        public string Title { get; set; }
        public string CandidateDesc { get; set; }
        public string PosDesc { get; set; }
        public string Salary { get; set; }
        public string Occupations { get; set; }
        public string ImagePath { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }
}
