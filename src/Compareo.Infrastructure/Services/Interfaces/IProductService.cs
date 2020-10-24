using Compareo.Data.Entities;
using Compareo.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Compareo.Infrastructure.Services.Interfaces
{
    public interface IProductService
    {
        Task Create(ProductDto product);

        Task Delete(int? id);

        Task Update(ProductDto product);

        Task<Product> Get(int? id);

        Task<ProductDto> GetDto(int? id);

        Task<Product> Get(Expression<Func<Product, bool>> filter);

        Task<bool> Exist(Expression<Func<Product, bool>> filter);

        Task<IList<Product>> GetAllDetails(Expression<Func<Product, bool>> filter = null);

        Task<IList<ProductDto>> GetAllHeaders(Expression<Func<Product, bool>> filter = null);

        Task<IList<ProductDto>> GetPaginated(Expression<Func<Product, bool>> filter = null, int pageSize = 1, int productPage = 1);
    }
}
