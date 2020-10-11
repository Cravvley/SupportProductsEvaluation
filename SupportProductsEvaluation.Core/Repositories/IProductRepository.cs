using SupportProductsEvaluation.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Core.Repositories
{
    public interface IProductRepository
    {
        Task Create(Product product);
        Task Delete(int? id);
        Task Update(Product product);
        Task<IList<Product>> GetAll();
        Task<Product> Get(int? id);
        Task<Product> Get(Product category);
    }
}
