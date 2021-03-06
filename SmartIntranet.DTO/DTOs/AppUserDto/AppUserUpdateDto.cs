using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DTO.DTOs.AppUserDto
{
    public class AppUserUpdateDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fathername { get; set; }
        public string Gender { get; set; }
        public string Fullname { get; set; }
        public double Salary { get; set; }
        public DateTime StartWorkDate { get; set; }
        public string Pin { get; set; }
        public int WorkGraphicId { get; set; }
        public int VacationMainDay { get; set; }
        public int VacationExtraDay { get; set; }
        public string EducationLevel { get; set; }
        public string GraduatedPlace { get; set; }
        public string Profession { get; set; }
        public string Citizenship { get; set; }
        public string IdCardType { get; set; }
        public bool IsMainPlace { get; set; } // esas is yeri, komekci
        public string IdCardNumber { get; set; } // serial + number
        public DateTime IdCardGiveDate { get; set; }
        public string IdCardGivePlace { get; set; } // veren qurum
        public DateTime IdCardExpireDate { get; set; }
        public string RegisterAdress { get; set; }
        public DateTime? Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; } = "default.png";
        public int? GradeId { get; set; }
        public Grade Grade { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public int? PositionId { get; set; }
        public Position Position { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<UserExperience> UserExperiences { get; set; }
        public virtual List<UserVacationRemain> UserVacationRemains { get; set; }
    }
}
