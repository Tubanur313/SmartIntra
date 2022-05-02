using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;

namespace SmartIntranet.Business.Concrete
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

    }
}
