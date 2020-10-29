using Compareo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Compareo.Data.Repositories
{
    public interface IProductRepository
    {
        Task Create(Product product);

        Task Delete(Product product);

        Task Update(Product product);

        Task<Product> Get(int? id);

        Task<Product> Get(Expression<Func<Product, bool>> filter);

        Task<double> GetMaxPrice(Expression<Func<Product, bool>> filter);

        Task<double> GetMinPrice(Expression<Func<Product, bool>> filter);

        Task<double> GetAvgGrade(Expression<Func<Product, bool>> filter);

        Task<double> GetAvgPrice(Expression<Func<Product, bool>> filter);

        Task<IList<Product>> GetAll(Expression<Func<Product, bool>> filter);

        Task<IList<Product>> GetPaginated(Expression<Func<Product, bool>> filter, int pageSize = 1, int productPage = 1);
    }
}
