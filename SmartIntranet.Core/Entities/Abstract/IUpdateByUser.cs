using System;

namespace SmartIntranet.Core.Entities.Abstract
{
    public interface IUpdateByUserId
    {
        public int? UpdateByUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
