using Compareo.Data.Entities;
using Compareo.Data.Repositories;
using Compareo.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Compareo.Infrastructure.Services
{
    public class ShopPropositionService : IShopPropositionService
    {

        private readonly IShopPropositionRepository _shopPropositionRepository;

        public ShopPropositionService(IShopPropositionRepository shopPropositionRepository)
        {
            _shopPropositionRepository = shopPropositionRepository;
        }

        public async Task Create(ShopProposition shopProposition)
        {
            if (shopProposition is null)
            {
                throw new ArgumentNullException("shop doesn't exist");
            }

            await _shopPropositionRepository.Create(shopProposition);
        }

        public async Task Delete(int? id)
        {
            var shopPropositionEntity = await _shopPropositionRepository.Get(id);
            if (shopPropositionEntity is null)
            {
                return;
            }

            await _shopPropositionRepository.Delete(id);
        }

        public async Task<ShopProposition> Get(int? id)
        {
            var shopPropositionEntity = await _shopPropositionRepository.Get(id);
            if (shopPropositionEntity is null)
            {
                throw new ArgumentNullException("shop doesn't exist");
            }

            return shopPropositionEntity;
        }

        public async Task<IList<ShopProposition>> GetPaginated(Expression<Func<ShopProposition, bool>> filter = null, int pageSize = 1, int productPage = 1)
        {
            if (filter is null)
            {
                return await _shopPropositionRepository.GetPaginated(filter => true, pageSize, productPage);
            }

            return await _shopPropositionRepository.GetPaginated(filter, pageSize, productPage);
        }
    }
}
