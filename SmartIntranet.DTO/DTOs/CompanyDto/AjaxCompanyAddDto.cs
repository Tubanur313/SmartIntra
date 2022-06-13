using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.DTO.DTOs.CompanyDto
{
    public class AjaxCompanyAddDto
    {
        public string Company_Name { get; set; }
        public string Company_Description { get; set; }
        public int? Company_ParentId { get; set; }
        public virtual Company Company_Parent { get; set; }


    }
}
