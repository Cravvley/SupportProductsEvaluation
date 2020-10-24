using Compareo.Data.Entities;
using Compareo.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Compareo.Infrastructure.Services.Interfaces
{
    public interface IShopService
    {
        Task Create(Shop shop);

        Task Delete(int ?id);

        Task Update(Shop shop);

        Task<Shop> Get(int? id);

        Task<bool> Exist(Expression<Func<Shop, bool>> filter);
        
        Task<IList<Shop>> GetAllDetails(Expression<Func<Shop,bool>>filter=null);
        
        Task<IList<ShopDto>> GetAllHeaders(Expression<Func<Shop, bool>> filter=null);
        
        Task<IList<ShopDto>> GetPaginatedHeaders(Expression<Func<Shop, bool>> filter = null, int pageSize = 0, int productPage = 0);
    }
}
