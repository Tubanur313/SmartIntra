using System;
using System.Collections.Generic;
using SmartIntranet.Core.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.Entities.Concrete.IntraHr
{
    public class PersonalContract : BaseEntity
    {
        public string Type { get; set; }
        public string CommandNumber { get; set; }
        public DateTime CommandDate { get; set; }
        public int? PositionId { get; set; }
        public double? Salary { get; set; }
        public int UserId { get; set; }
        public int WorkGraphicId { get; set; }
        public int LastWorkGraphicId { get; set; }
        public bool IsMainPlace { get; set; }
        public int? LastMainVacationDay { get; set; }
        public int? NewMainVacationDay { get; set; }
        public int? LastFullVacationDay { get; set; }
        public int? NewFullVacationDay { get; set; }
        public int VacationDay { get; set; }
        public int? ClauseId { get; set; }
        public bool IsMainVacation { get; set; }
        public int VacationExtraType { get; set; }
        public int? LastDepartmentId { get; set; }
        public int? LastPositionId { get; set; }
        public double LastSalary { get; set; }
        public bool? LastIsMainPlace { get; set; }
        public Clause Clause { get; set; }
        public IntranetUser User { get; set; }

        public virtual ICollection<PersonalContractFile> PersonalContractFiles { get; set; }
    }
}
