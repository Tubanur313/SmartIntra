using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using System.Linq.Expressions;

namespace SmartIntranet.Business.Concrete
{
    public class PositionManager : GenericManager<Position>, IPositionService
    {
        private readonly IGenericDal<Position> _genericDal;
        private readonly IPositionDal _positionDal;

        public PositionManager(IGenericDal<Position> genericDal, IPositionDal positionDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _positionDal = positionDal;
        }

        public async Task<List<Position>> GetAllIncludeAsync()
        {
            return await _positionDal.GetAllIncludeAsync();
        }
    }
}
