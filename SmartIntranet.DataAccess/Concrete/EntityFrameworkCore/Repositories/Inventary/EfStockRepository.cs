using Microsoft.EntityFrameworkCore;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces.Inventary;
using SmartIntranet.Entities.Concrete.Inventary;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories.Inventary
{
    public class EfStockRepository : EfGenericRepository<Stock>, IStockDal
    {
        public async Task<List<Stock>> FilterByStatusCategCompAsync(int stockCategoryId,
            int companyId, StockStatus StockStatus)
        {
            using var context = new IntranetContext();
            if (stockCategoryId == 0 && companyId == 0 && StockStatus == 0)
            {
                return await context.Stocks.Where(x => !x.IsDeleted)
                  .Include(x => x.Company)
                  .Include(x => x.StockCategory)
                  .OrderByDescending(x => x.Id)
                  .ToListAsync();
            }
            else
            {
                if (stockCategoryId > 0 && companyId == 0 && StockStatus == 0)
                {
                    return await context.Stocks.Where(x => !x.IsDeleted
                    && x.StockCategoryId == stockCategoryId)
                      .Include(x => x.Company)
                      .Include(x => x.StockCategory)
                      .OrderByDescending(x => x.Id)
                      .ToListAsync();
                }
                else if (companyId > 0 && stockCategoryId == 0 && StockStatus == 0)
                {
                    return await context.Stocks.Where(x => !x.IsDeleted
                    && x.CompanyId == companyId)
                      .Include(x => x.Company)
                      .Include(x => x.StockCategory)
                      .OrderByDescending(x => x.Id)
                      .ToListAsync();
                }
                else if (companyId > 0 && stockCategoryId > 0 && StockStatus == 0)
                {
                    return await context.Stocks.Where(x => !x.IsDeleted
                    && x.CompanyId == companyId
                    && x.StockCategoryId == stockCategoryId)
                      .Include(x => x.Company)
                      .Include(x => x.StockCategory)
                      .OrderByDescending(x => x.Id)
                      .ToListAsync();
                }
                else if (companyId > 0 && stockCategoryId == 0 && StockStatus > 0)
                {
                    if (StockStatus.GetHashCode() == StockStatus.Assigned.GetHashCode())
                    {
                        return await context.Stocks.Where(x => !x.IsDeleted
                        && x.CompanyId == companyId
                        && x.IntranetUser != null)
                         .Include(x => x.Company)
                         .Include(x => x.IntranetUser)
                         .ThenInclude(x => x.Company)
                         .ThenInclude(x => x.Departments)
                         .ThenInclude(x => x.Positions)
                         .Include(x => x.StockCategory)
                         .OrderByDescending(x => x.Id)
                         .ToListAsync();
                    }
                    else
                    {
                        return await context.Stocks.Where(x => !x.IsDeleted
                        && x.CompanyId == companyId
                        && x.IntranetUser == null)
                         .Include(x => x.Company)
                         .Include(x => x.StockCategory)
                         .OrderByDescending(x => x.Id)
                         .ToListAsync();
                    }
                }
                else if (companyId == 0 && stockCategoryId > 0 && StockStatus > 0)
                {
                    if (StockStatus.GetHashCode() == StockStatus.Assigned.GetHashCode())
                    {
                        return await context.Stocks.Where(x => !x.IsDeleted
                        && x.StockCategoryId == stockCategoryId
                        && x.IntranetUser != null)
                         .Include(x => x.Company)
                         .Include(x => x.IntranetUser)
                         .ThenInclude(x => x.Company)
                         .ThenInclude(x => x.Departments)
                         .ThenInclude(x => x.Positions)
                         .Include(x => x.StockCategory)
                         .OrderByDescending(x => x.Id)
                         .ToListAsync();
                    }
                    else
                    {
                        return await context.Stocks.Where(x => !x.IsDeleted
                        && x.StockCategoryId == stockCategoryId
                        && x.IntranetUser == null)
                         .Include(x => x.Company)
                         .Include(x => x.StockCategory)
                         .OrderByDescending(x => x.Id)
                         .ToListAsync();
                    }
                }
                else if (StockStatus > 0 && stockCategoryId == 0 && companyId == 0)
                {
                    if (StockStatus.GetHashCode() == StockStatus.Assigned.GetHashCode())
                    {
                        return await context.Stocks.Where(x => !x.IsDeleted
                        && x.IntranetUser != null)
                         .Include(x => x.Company)
                         .Include(x => x.StockCategory)
                         .OrderByDescending(x => x.Id)
                         .ToListAsync();
                    }
                    else
                    {
                        return await context.Stocks.Where(x => !x.IsDeleted
                        && x.IntranetUser == null)
                         .Include(x => x.Company)
                         .Include(x => x.StockCategory)
                         .OrderByDescending(x => x.Id)
                         .ToListAsync();
                    }

                }
                else
                {
                    if (StockStatus.GetHashCode() == StockStatus.Assigned.GetHashCode())
                    {
                        return await context.Stocks.Where(x => !x.IsDeleted
                        && x.CompanyId == companyId
                        && x.StockCategoryId == stockCategoryId
                        && x.IntranetUser != null)
                             .Include(x => x.Company)
                         .Include(x => x.IntranetUser)
                         .ThenInclude(x => x.Company)
                         .ThenInclude(x => x.Departments)
                         .ThenInclude(x => x.Positions)
                         .Include(x => x.StockCategory)
                         .OrderByDescending(x => x.Id)
                         .ToListAsync();
                    }
                    else
                    {
                        return await context.Stocks.Where(x => !x.IsDeleted
                        && x.CompanyId == companyId
                        && x.StockCategoryId == stockCategoryId
                        && x.IntranetUser == null)
                             .Include(x => x.Company)
                         .Include(x => x.StockCategory)
                         .OrderByDescending(x => x.Id)
                         .ToListAsync();
                    }
                }
            }

        }

        public async Task<Stock> FindByIdIncludeAsync(int id)
        {
            using var context = new IntranetContext();
            return await context.Stocks.Where(x => !x.IsDeleted && x.Id == id)
                .Include(x => x.Company)
                .Include(x => x.IntranetUser)
                .ThenInclude(x => x.Company)
                .ThenInclude(x => x.Departments)
                .ThenInclude(x => x.Positions)
                .Include(x => x.StockCategory)
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Stock>> GetStockAllIncludeAsync()
        {
            using var context = new IntranetContext();
            return await context.Stocks.Where(x => !x.IsDeleted)
                .Include(x => x.Company)
                .Include(x => x.IntranetUser)
                .ThenInclude(x => x.Company)
                .ThenInclude(x => x.Departments)
                .ThenInclude(x => x.Positions)
                .Include(x => x.StockCategory)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }
    }
}
