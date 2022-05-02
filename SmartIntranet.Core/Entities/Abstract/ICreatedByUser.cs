using System;

namespace SmartIntranet.Core.Entities.Abstract
{
    public interface ICreatedByUser
    {
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
