using SupportProductsEvaluation.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Services.Interfaces
{
    public interface IShopService
    {
        Task Create(Shop shop);
        Task Delete(int ?id);
        Task Update(Shop shop);
        Task<IList<Shop>> GetAll();
        Task<Shop> Get(int ?id);
        Task<bool> IsExist(Shop shop);
    }
}
