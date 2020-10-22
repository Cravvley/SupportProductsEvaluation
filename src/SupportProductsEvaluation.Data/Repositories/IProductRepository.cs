using SupportProductsEvaluation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Data.Repositories
{
    public interface IProductRepository
    {
        Task Create(Product product);

        Task Delete(int? id);

        Task Update(Product product);

        Task<Product> Get(int? id);

        Task<Product> Get(Expression<Func<Product, bool>> filter);

        Task<IList<Product>> GetAll(Expression<Func<Product, bool>> filter);

        Task<IList<Product>> GetPaginated(Expression<Func<Product, bool>> filter, int pageSize = 1, int productPage = 1);
    }
}
