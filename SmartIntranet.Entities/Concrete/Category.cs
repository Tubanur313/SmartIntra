using SmartIntranet.Core.Entities.Concrete;
using System.Collections.Generic;


namespace SmartIntranet.Entities.Concrete
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> Children { get; set; }
        public virtual ICollection<CategoryNews> CategoryNews { get; set; }
    }
}
