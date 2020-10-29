using Compareo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Compareo.Data.Repositories
{
    public interface IShopRepository
    {
        Task Create(Shop shop);
        
        Task Delete(Shop shop);
        
        Task Update(Shop shop);

        Task<Shop> Get(int? id);

        Task<Shop> Get(Expression<Func<Shop, bool>> filter);
        
        Task<IList<Shop>> GetAll(Expression<Func<Shop, bool>> filter);

        Task<IList<Shop>> GetPaginated(Expression<Func<Shop, bool>> filter, int pageSize = 1, int productPage = 1);
    }
}
