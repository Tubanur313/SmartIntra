using SmartIntranet.Entities.Concrete.Membership;
using SmartIntranet.Core.Entities.Concrete;
using System;
using System.Collections.Generic;


namespace SmartIntranet.Entities.Concrete
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
        public Clause Clause { get; set; }
        public IntranetUser User { get; set; }

        public virtual ICollection<PersonalContractFile> PersonalContractFiles { get; set; }
    }
}
