using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartIntranet.DTO.DTOs.PersonalContractDto
{
    public class LongContractUpdateDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime FromDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime ToDate { get; set; }
        public IntranetUser User { get; set; }
        public virtual ICollection<LongContractFile> LongContractFiles { get; set; }
    }
}
