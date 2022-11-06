﻿using SmartIntranet.Entities.Concrete.Membership;
using System;

namespace SmartIntranet.DTO.DTOs.PersonalContractDto
{
    public class PersonalContractAddDto
    {
        public int Id { get; set; }
        public string CommandNumber { get; set; }
        public DateTime? CommandDate { get; set; }
        public string Type { get; set; }
        public int VacationExtraType { get; set; } // experience 0 , nature 1, child 2
        public int? PositionId { get; set; }
        public int? DepartmentId { get; set; }
        public string Salary { get; set; }
        public int UserId { get; set; }
        public int? WorkGraphicId { get; set; }
        public int? LastWorkGraphicId { get; set; }
        public bool? IsMainPlace { get; set; }
        public int? LastMainVacationDay { get; set; }
        public int? NewMainVacationDay { get; set; }
        public int? LastFullVacationDay { get; set; }
        public int? NewFullVacationDay { get; set; }
        public int? VacationDay { get; set; }
        public int? ClauseId { get; set; }
        public bool IsMainVacation { get; set; }
        public IntranetUser User { get; set; }
        public int? LastDepartmentId { get; set; }
        public int? LastPositionId { get; set; }
        public double LastSalary { get; set; }
        public bool? LastIsMainPlace { get; set; }
        public bool SendMail { get; set; }
        public bool SendNews { get; set; }
    }
}
