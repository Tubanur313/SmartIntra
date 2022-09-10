using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Business.Interfaces.IntraHr;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.DataAccess.Interfaces.IntraHr;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.Business.Concrete.IntraHr
{
    public class PlaceManager : GenericManager<Place>, IPlaceService
    {
        private readonly IGenericDal<Place> _genericDal;
        private readonly IPlaceDal _placeDal;

        public PlaceManager(IGenericDal<Place> genericDal, IPlaceDal placeDal) : base(genericDal)
        {
            _placeDal = placeDal;
            _genericDal = genericDal;
        }

        public async Task<List<Place>> GetAllAsync(Expression<Func<Place, bool>> filter)
        {
            return await _placeDal.GetAllAsync(filter);
        }

        public Task<List<Place>> GetAllIncAsync()
        {
            return _placeDal.GetAllIncAsync();
        }

        public Task<List<Place>> GetAllIncAsync(Expression<Func<Place, bool>> filter,bool asnotrack = false)
        {
            return _placeDal.GetAllIncAsync(filter,asnotrack);
        }
    }
}
