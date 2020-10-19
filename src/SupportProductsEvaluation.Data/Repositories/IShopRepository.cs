using SupportProductsEvaluation.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Data.Repositories
{
    public interface IShopRepository
    {
        Task Create(Shop shop);
        
        Task Delete(int ?id);
        
        Task Update(Shop shop);
        
        Task<IList<Shop>> GetAll();
        
        Task<Shop> Get(int ?id);
        
        Task<Shop> Get(Shop shop);
    }
}
