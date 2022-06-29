using SmartIntranet.Core.Entities.Abstract;
using System;

namespace SmartIntranet.Core.Entities.Concrete
{
    public class BaseEntity : IStatus,ICreatedByUser, IUpdateByUserId, IDeleteByUser
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedByUserId { get ; set ; }
        public DateTime? CreatedDate { get; set ; }
        public int? UpdateByUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? DeleteByUserId { get; set; }
        public DateTime? DeleteDate { get; set; }
       
    }
}
