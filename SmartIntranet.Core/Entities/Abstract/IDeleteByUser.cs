using System;

namespace SmartIntranet.Core.Entities.Abstract
{
    public interface IDeleteByUser
    {
        public int? DeleteByUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
