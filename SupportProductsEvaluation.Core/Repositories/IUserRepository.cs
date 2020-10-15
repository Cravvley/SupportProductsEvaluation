using SupportProductsEvaluation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> Get(string id);
        Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>> filter = null);
        Task Update(User user);
    }
}
