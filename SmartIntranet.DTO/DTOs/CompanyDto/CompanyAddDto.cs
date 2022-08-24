using SmartIntranet.Entities.Concrete.Intranet;
using System;

namespace SmartIntranet.DTO.DTOs.CompanyDto
{
    public class CompanyAddDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public Company Parent { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoPath { get; set; }
        public string LeaderPosition { get; set; }
        public string Tin { get; set; }
        public string Address { get; set; }
        public string BankName { get; set; }
        public string BankTin { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankCode { get; set; }
        public string SWIFTCode { get; set; }
        public string CorrespondentAccountNumber { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdateByUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int? DeleteByUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }


    }
}
