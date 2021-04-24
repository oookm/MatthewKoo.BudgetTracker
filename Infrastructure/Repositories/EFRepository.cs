using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MatthewKoo.BudgetTracker.ApplicationCore.RepositoryInterfaces;
using MatthewKoo.BudgetTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly BudgetTrackerDbContext _dbContext;



        public EfRepository(BudgetTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public virtual async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            return entity;
        }



        public virtual async Task<IEnumerable<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }


        public virtual async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }



        public virtual async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }



        public virtual async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        // example input is in userservice; where is a boolean expression like 
        // p => p.UserId == _currentUserService.UserId,
        // includes is a list of objects like p => p.Movie
        // params means it takes a variable amount of arguments
        public async Task<IEnumerable<T>> ListAllWithIncludesAsync(Expression<Func<T, bool>> @where,
            params Expression<Func<T, object>>[] includes)
        {
            var query = _dbContext.Set<T>().AsQueryable();

            if (includes != null)
            {
                foreach (Expression<Func<T, object>> navigationProperty in includes)
                {
                    query = query.Include(navigationProperty);
                }
            }
            return await query.Where(@where).ToListAsync();
        }
    }
}
