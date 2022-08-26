using SmartIntranet.Business.Interfaces.IntraTicket;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.IntraTicket;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete.IntraTicket
{
    public class CategoryTicketManager : GenericManager<CategoryTicket>, ICategoryTicketService
    {
        private readonly IGenericDal<CategoryTicket> _genericDal;
        private readonly ICategoryTicketDal _categoryDal;

        public CategoryTicketManager(IGenericDal<CategoryTicket> genericDal, ICategoryTicketDal categoryDal) : base(genericDal)
        {
            _categoryDal = categoryDal;
            _genericDal = genericDal;
        }

        public async Task<CategoryTicket> GetIncludeAsync(int id)
        {
            return await _categoryDal.GetIncludeAsync(id);
        }

        public async Task<List<CategoryTicket>> GetAllIncludeAsync()
        {
            return await _categoryDal.GetAllIncludeAsync();
        }
    }
}
