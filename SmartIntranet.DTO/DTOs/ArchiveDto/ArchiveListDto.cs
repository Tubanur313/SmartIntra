using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.Membership;

namespace SmartIntranet.DTO.DTOs.ArchiveDto
{
    public class ArchiveListDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string File { get; set; }

        public int AddedByUserId { get; set; }
        public IntranetUser AddedByUser { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
