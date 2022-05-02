using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;

namespace SmartIntranet.Business.Concrete
{
    public class CheckListManager : GenericManager<CheckList>, ICheckListService
    {
        private readonly IGenericDal<CheckList> _genericDal;
        private readonly IChecklistDal _checkListDal;

        public CheckListManager(IGenericDal<CheckList> genericDal, IChecklistDal checkListDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _checkListDal = checkListDal;

        }

    }
}
