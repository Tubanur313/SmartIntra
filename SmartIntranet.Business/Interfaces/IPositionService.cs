using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SmartIntranet.DTO.DTOs.PositionDto;
using SmartIntranet.Entities.Concrete;

namespace SmartIntranet.Business.Interfaces
{
    public interface IPositionService : IGenericService<Position>
    {
        Task<List<Position>> GetAllIncludeAsync();
    }
}
