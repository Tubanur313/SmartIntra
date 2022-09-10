﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.Business.Interfaces.IntraHr;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.DataAccess.Interfaces.IntraHr;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.Business.Concrete.IntraHr
{
    public class VacationContractManager : GenericManager<VacationContract>, IVacationContractService
    {
        private readonly IGenericDal<VacationContract> _genericDal;
        private readonly IVacationContractDal _contractDal;

        public VacationContractManager(IGenericDal<VacationContract> genericDal, IVacationContractDal contractDal) : base(genericDal)
        {
            _contractDal = contractDal;
            _genericDal = genericDal;
        }

        public async Task<List<VacationContract>> GetAllAsync(Expression<Func<VacationContract, bool>> filter)
        {
            return await _contractDal.GetAllAsync(filter);
        }

        public Task<List<VacationContract>> GetAllIncCompAsync()
        {
            return _contractDal.GetAllIncCompAsync();
        }

        public Task<List<VacationContract>> GetAllIncCompAsync(Expression<Func<VacationContract, bool>> filter)
        {
            return _contractDal.GetAllIncCompAsync(filter);
        }
    }
}
