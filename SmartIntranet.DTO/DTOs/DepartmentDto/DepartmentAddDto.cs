using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.DTO.DTOs.DepartmentDto
{
    public class DepartmentAddDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public Department Parent { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
