using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.DTO.DTOs.ArchiveDto
{
    public class ArchiveAddDto 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string File { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
