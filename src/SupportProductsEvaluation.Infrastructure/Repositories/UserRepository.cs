using Microsoft.EntityFrameworkCore;
using SupportProductsEvaluation.Data;
using SupportProductsEvaluation.Data.Entities;
using SupportProductsEvaluation.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<User> Get(string id)
                => await _db.User.SingleOrDefaultAsync(u => u.Id == id);

        public async Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>> filter = null)
            => await _db.User.AsNoTracking().Where(filter).AsQueryable().ToListAsync();

        public async Task<IList<User>> GetPaginated(Expression<Func<User, bool>> filter, int pageSize = 0, int productPage = 0)
         => await _db.User.AsNoTracking().Where(filter).AsQueryable().OrderBy(p => p.Name)
                                     .Skip((productPage - 1) * pageSize)
                                     .Take(pageSize).ToListAsync();

        public async Task Update(User user)
        {
            var userEntity = await Get(user.Id);

            userEntity.LockoutEnd = user.LockoutEnd;

            await _db.SaveChangesAsync();
        }
    }
}
