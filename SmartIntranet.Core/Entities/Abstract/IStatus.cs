using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.Core.Entities.Abstract
{
    public interface IStatus
    {
        
        public bool IsDeleted { get; set; }
    }
}
