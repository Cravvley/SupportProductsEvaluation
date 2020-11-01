using Compareo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Compareo.Data.Repositories
{
    public interface IShopPropositionRepository
    {
        Task Create(ShopProposition shopProposition);

        Task Delete(ShopProposition shopProposition);

        Task<ShopProposition> Get(int id);

        Task<IList<ShopProposition>> GetPaginated(int pageSize = 1, int productPage = 1);

        Task<IList<ShopProposition>> GetAll();
    }
}
