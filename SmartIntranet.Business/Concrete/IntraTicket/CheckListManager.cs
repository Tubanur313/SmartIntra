using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.IntraTicket;
using SmartIntranet.Business.Interfaces.IntraTicket;
using SmartIntranet.DataAccess.Interfaces.IntraTicket;

namespace SmartIntranet.Business.Concrete.IntraTicket
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
