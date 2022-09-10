using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.ComponentModel.DataAnnotations;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DTO.DTOs.ContractDto
{
    public class ContractUpdateDto
    {
        public int Id { get; set; }
        public string ContractFileType { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime ContractStart { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime CommandDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? ContractEnd { get; set; }
        public string ContractNumber { get; set; }
        public string CommandNumber { get; set; }
        public bool HasTerm { get; set; }
        public bool IsMainPlace { get; set; } // esas is yeri, komekci
        public bool IsAlternate { get; set; } // novbeli, novbesiz
        public bool ByTransport { get; set; } // neqliyyatlaç neqliyyatsiz
        public int WorkGraphicId { get; set; }
        public WorkGraphic WorkGraphic { get; set; }
        public int? ClauseId { get; set; }
        public Clause Clause { get; set; }
        public int UserId { get; set; }
        public IntranetUser User { get; set; }
    }
}
