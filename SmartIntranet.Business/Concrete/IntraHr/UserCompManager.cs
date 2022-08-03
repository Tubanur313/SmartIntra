using SmartIntranet.Business.Interfaces.IntraHr;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.IntraHr;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.Business.Concrete.IntraHr
{
    public class UserCompManager : GenericManager<UserComp>, IUserCompService
    {
        public UserCompManager(IGenericDal<UserComp> dal) : base(dal)
        {
        }
    }
}
