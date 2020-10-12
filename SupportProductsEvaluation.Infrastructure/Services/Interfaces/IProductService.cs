using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Infrastructure.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Services.Interfaces
{
    public interface IProductService
    {
        Task Create(ProductDto product);
        Task Delete(int? id);
        Task Update(ProductDto product);
        Task<IList<Product>> GetAllDetails();
        Task<IList<ProductDto>> GetAllHeaders();
        Task<Product> Get(int? id);
        Task<ProductDto> GetDto(int? id);
        Task<bool> IsExist(ProductDto product);
    }
}
