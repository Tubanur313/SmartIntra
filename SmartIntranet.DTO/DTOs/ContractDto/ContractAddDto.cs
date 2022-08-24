using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System;

namespace SmartIntranet.DTO.DTOs.ContractDto
{
    public class ContractAddDto
    {
        public int Id { get; set; }
        public string ContractFileType { get; set; }
        public DateTime ContractStart { get; set; }
        public DateTime? ContractEnd { get; set; }
        public DateTime CommandDate { get; set; }
        public string ContractNumber { get; set; }
        public string CommandNumber { get; set; }
        public bool HasTerm { get; set; } // muddetli, muddetsiz
        public bool IsMainPlace { get; set; } // esas is yeri, komekci
        public bool IsAlternate { get; set; } // novbeli, novbesiz
        public bool ByTransport { get; set; } // neqliyyatlaç neqliyyatsiz
        public int WorkGraphicId { get; set; }
        public WorkGraphic WorkGraphic { get; set; }
        public int? ClauseId { get; set; }
        public Clause Clause { get; set; }
        public int UserId { get; set; }
        public IntranetUser User { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdateByUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int? DeleteByUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool SendMail { get; set; }
        public bool SendNews { get; set; }
    }
}
