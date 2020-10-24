using Compareo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Compareo.Infrastructure.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Get(string id);

        Task<bool> Lock(string userId, bool lockUser);

        Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>> filter = null);

        Task<IList<User>> GetPaginated(Expression<Func<User, bool>> filter = null, int pageSize = 0, int productPage = 0);
    }
}
