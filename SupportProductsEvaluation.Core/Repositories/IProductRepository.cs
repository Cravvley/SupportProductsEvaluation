using SupportProductsEvaluation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Core.Repositories
{
    public interface IProductRepository
    {
        Task Create(Product product);
        Task Delete(int? id);
        Task Update(Product product);
        Task<IList<Product>> GetAll();
        Task<IList<Product>> GetAll(string ProductName, string CategoryName, string SubCategoryName);
        Task<Product> Get(int? id);
        
        Task<Product> Get(Product category);
    }
}
