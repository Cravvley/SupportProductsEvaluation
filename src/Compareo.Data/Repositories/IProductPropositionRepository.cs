using Compareo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Compareo.Data.Repositories
{
    public interface IProductPropositionRepository
    {
        Task Create(ProductProposition shopProposition);

        Task Delete(int? id);

        Task<ProductProposition> Get(int? id);

        Task<IList<ProductProposition>> GetPaginated(Expression<Func<ProductProposition, bool>> filter, int pageSize = 1, int productPage = 1);
    }
}
