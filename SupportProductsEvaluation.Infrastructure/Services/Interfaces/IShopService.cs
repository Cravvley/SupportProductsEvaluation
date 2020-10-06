using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Infrastructure.VMs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Services.Interfaces
{
    public interface IShopService
    {
        Task Create(Shop shop);
        Task Delete(int ?id);
        Task Update(Shop shop);
        Task<IList<Shop>> GetAllDetails();
        Task<IList<ShopVM>> GetAllHeaders();
        Task<Shop> Get(int ?id);
        Task<bool> IsExist(Shop shop);
    }
}
