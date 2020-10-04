using SupportProductsEvaluation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Core.Repositories
{
    public interface IShopRepository
    {
        Task Create(Shop shop);
        Task Delete(int id);
        Task Update(Shop shop);
        IEnumerable<Task<Shop>> GetAll();
        Task<Shop> Get(int id);
    }
}
