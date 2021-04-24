using Infrastructure.Repositories;
using MatthewKoo.BudgetTracker.ApplicationCore.Entities;
using MatthewKoo.BudgetTracker.ApplicationCore.Exceptions;
using MatthewKoo.BudgetTracker.ApplicationCore.RepositoryInterfaces;
using MatthewKoo.BudgetTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatthewKoo.BudgetTracker.Infrastructure.Repositories
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(BudgetTrackerDbContext dbContext) : base(dbContext)
        {

        }

        // return user along with Incomes and Expenditures
        public override async Task<User> GetByIdAsync(int id)
        {
            var user = await _dbContext.Users.Where(u => u.Id == id).Include(u => u.Incomes)
                                       .Include(u => u.Expenditures).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new NotFoundException("User Not Found");
            }
            return user;
        }
    }
}
