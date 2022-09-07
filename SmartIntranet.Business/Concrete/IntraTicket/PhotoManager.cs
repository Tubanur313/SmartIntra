using SmartIntranet.Business.Interfaces.IntraTicket;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete.IntraTicket;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.DataAccess.Interfaces.IntraTicket;

namespace SmartIntranet.Business.Concrete.IntraTicket
{
    public class PhotoManager : GenericManager<Photo>, IPhotoService
    {
        private readonly IGenericDal<Photo> _genericDal;
        private readonly IPhotoDal _photoDal;

        public PhotoManager(IGenericDal<Photo> genericDal, IPhotoDal photoDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _photoDal = photoDal;
        }
        public async Task<List<Photo>> GetAllByTicketAsync(int ticketId)
        {
            return await _photoDal.GetAllByTicketAsync(ticketId);
        }
    }
}
