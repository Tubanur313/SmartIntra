using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces;
using SmartIntranet.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfContractRepository : EfGenericRepository<Contract>, IContractDal
    {
        public async Task<List<Contract>> GetAllIncCompAsync()
        {
            using var context = new IntranetContext();
            return await context.Contracts.Include(x => x.User)
            .ThenInclude(z => z.Position)
            .ThenInclude(z => z.Company)
            .ThenInclude(z => z.Departments)
            .OrderByDescending(c => c.ContractStart)
            .ToListAsync();
        }

        public async Task<List<Contract>> GetAllIncCompAsync(Expression<Func<Contract, bool>> filter)
        {
            using var context = new IntranetContext();
            return await context.Contracts.Include(x => x.User)
                .ThenInclude(z => z.Position).ThenInclude(z => z.Company)
                .ThenInclude(z => z.Departments).Where(filter)
                .OrderByDescending(c => c.User.Name).ToListAsync();

        }

        public async Task<List<Contract>> GetAllIncCompAsync(
            int companyId, int departmentId, int positionId, string Interval)
        {
            using var context = new IntranetContext();
            if (Interval is null)
            {
                if (companyId > 0 && departmentId == 0 && positionId == 0)
                {
                    return await context.Contracts.Include(x => x.User)
                       .ThenInclude(z => z.Position).ThenInclude(z => z.Company)
                       .ThenInclude(z => z.Departments).Where(x => x.User.CompanyId == companyId
                       && !x.IsDeleted)
                       .OrderByDescending(c => c.User.Name).ToListAsync();
                }
                else if (companyId > 0 && departmentId > 0 && positionId == 0)
                {
                    return await context.Contracts.Include(x => x.User)
                       .ThenInclude(z => z.Position).ThenInclude(z => z.Company)
                       .ThenInclude(z => z.Departments).Where(x =>
                       x.User.CompanyId == companyId
                       && x.User.DepartmentId == departmentId
                       && !x.IsDeleted
                       )
                       .OrderByDescending(c => c.User.Name).ToListAsync();
                }
                else if (companyId > 0 && departmentId > 0 && positionId > 0)
                {
                    return await context.Contracts.Include(x => x.User)
                       .ThenInclude(z => z.Position).ThenInclude(z => z.Company)
                       .ThenInclude(z => z.Departments).Where(x =>
                       x.User.CompanyId == companyId
                       && x.User.DepartmentId == departmentId
                       && x.User.PositionId == positionId
                       && !x.IsDeleted
                       )
                       .OrderByDescending(c => c.User.Name).ToListAsync();
                }
                else
                {
                    return await context.Contracts.Include(x => x.User)
                        .ThenInclude(z => z.Position).ThenInclude(z => z.Company)
                        .ThenInclude(z => z.Departments).Where(x => !x.IsDeleted)
                        .OrderByDescending(c => c.User.Name).ToListAsync();
                }
            }
            else
            {
                var startD = Convert.ToDateTime(Interval.Split("-").First());
                var endD = Convert.ToDateTime(Interval.Split("-").Last());

                if (companyId > 0 && departmentId == 0 && positionId == 0)
                {
                    return await context.Contracts.Include(x => x.User)
                       .ThenInclude(z => z.Position).ThenInclude(z => z.Company)
                       .ThenInclude(z => z.Departments).Where(x => x.User.CompanyId == companyId
                       && !x.IsDeleted
                       && x.ContractStart.Date >= startD.Date
                       && x.ContractStart.Date <= endD.Date
                       )
                       .OrderByDescending(c => c.User.Name).ToListAsync();
                }
                else if (companyId > 0 && departmentId > 0 && positionId == 0)
                {
                    return await context.Contracts.Include(x => x.User)
                       .ThenInclude(z => z.Position).ThenInclude(z => z.Company)
                       .ThenInclude(z => z.Departments).Where(x =>
                       x.User.CompanyId == companyId
                       && x.User.DepartmentId == departmentId
                       && !x.IsDeleted
                       && x.ContractStart.Date >= startD.Date
                       && x.ContractStart.Date <= endD.Date
                       )
                       .OrderByDescending(c => c.User.Name).ToListAsync();
                }
                else if (companyId > 0 && departmentId > 0 && positionId > 0)
                {
                    return await context.Contracts.Include(x => x.User)
                       .ThenInclude(z => z.Position).ThenInclude(z => z.Company)
                       .ThenInclude(z => z.Departments).Where(x =>
                       x.User.CompanyId == companyId
                       && x.User.DepartmentId == departmentId
                       && x.User.PositionId == positionId
                       && !x.IsDeleted
                       && x.ContractStart.Date >= startD.Date
                       && x.ContractStart.Date <= endD.Date
                       )
                       .OrderByDescending(c => c.User.Name).ToListAsync();
                }
                else
                {
                    return await context.Contracts.Include(x => x.User)
                        .ThenInclude(z => z.Position).ThenInclude(z => z.Company)
                        .ThenInclude(z => z.Departments).Where(x => !x.IsDeleted
                       && x.ContractStart.Date >= startD.Date
                       && x.ContractStart.Date <= endD.Date)
                        .OrderByDescending(c => c.User.Name).ToListAsync();
                }
            }
        }

        public async Task<List<Contract>> GetAllIncCompAsync(int? compIdOfUser)
        {
            using var context = new IntranetContext();

            return await context.Contracts.Include(x => x.User)
                .ThenInclude(z => z.Position)
                .ThenInclude(z => z.Company)
                .ThenInclude(z => z.Departments)
                .Where(x => x.User.CompanyId != compIdOfUser && !x.IsDeleted)
                .OrderByDescending(c => c.User.Name)
                .ToListAsync();
        }
    }

}
