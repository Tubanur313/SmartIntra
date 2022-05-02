using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.Core.Entities.Abstract
{
    public interface IDeleteByUser
    {
        public int? DeleteByUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
