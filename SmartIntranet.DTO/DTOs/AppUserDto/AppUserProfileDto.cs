using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;

namespace SmartIntranet.DTO.DTOs.AppUserDto
{
    public class AppUserProfileDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public DateTime? Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string HomePhoneNumber { get; set; }
        public string PersonalPhoneNumber { get; set; }
        public string SsnCode { get; set; }
        public int VacationMainDay { get; set; }
        public int VacationExtraChild { get; set; }
        public int VacationExtraExperience { get; set; }
        public int VacationExtraNature { get; set; }
        //public string Picture { get; set; }
        public string Address { get; set; }
        public string RegisterAdress { get; set; }
        public int? GradeId { get; set; }
        public Grade Grade { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public int? PositionId { get; set; }
        public Position Position { get; set; }
        public bool IsDeleted { get; set; }
        public List<UserContractFile> UserContractFiles { get; set; }
        public virtual List<Entities.Concrete.Membership.UserVacationRemain> UserVacationRemains { get; set; }
    }
}
