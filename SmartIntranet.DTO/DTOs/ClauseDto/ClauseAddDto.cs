using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.DTO.DTOs.ClauseDto
{
    public class ClauseAddDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string Key { get; set; }
        public bool IsDeletable { get; set; } // seed de yaranma statusu
        public bool IsBackground { get; set; } // arxa planda isledilir
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
