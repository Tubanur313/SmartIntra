﻿using SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context;
using SmartIntranet.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions; 
using System.Threading.Tasks;
using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfVacancyRepository : EfGenericRepository<Vacancy>, IVacancyDal
    {
        public async Task<Vacancy> FindByIdAllIncludeAsync(int id)
        {
            using var context = new IntranetContext();
            return await context.Vacancies.Include(x => x.Company).Where(x => x.Id == id).FirstAsync();
        }

        public Vacancy FindByIdIncAsync(int id)
        {
            using var context = new IntranetContext();
            return  context.Vacancies.Include(x => x.Company).Where(x => x.Id == id).First();
        }

        public async Task<List<Vacancy>> GetAllIncludeAsync(Expression<Func<Vacancy, bool>> filter)
        {
            using var context = new IntranetContext();
            return await context.Vacancies.OrderBy(x=>x.StartDate).Include(x => x.Company).Where(filter)
                .OrderByDescending(c => c.CreatedDate).ToListAsync();
        }

        public async Task<List<Vacancy>> GetAllWithIncludeAsync()
        {
            using var context = new IntranetContext();
            return await context.Vacancies.OrderBy(x => x.StartDate)
                .Include(x => x.Company)
                .OrderByDescending(c => c.CreatedDate).ToListAsync();
        }

        public async Task<List<Vacancy>> ShowAllWithIncludeAsync()
        {
            using var context = new IntranetContext();
            return await context.Vacancies.OrderBy(x => x.StartDate)
                .Include(x => x.Company)
                .Where(x=>!x.IsDeleted)
                .OrderByDescending(c => c.CreatedDate).ToListAsync();
        }
    }
}
