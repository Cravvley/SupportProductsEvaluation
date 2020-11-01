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
            var shopPropositionEntity = await _shopPropositionRepository.Get(id.Value);
            if (shopPropositionEntity is null)
            {
                return;
            }

            await _shopPropositionRepository.Delete(shopPropositionEntity);
        }

        public async Task<ShopProposition> Get(int? id)
        {
            var shopPropositionEntity = await _shopPropositionRepository.Get(id.Value);
            if (shopPropositionEntity is null)
            {
                throw new ArgumentNullException("shop doesn't exist");
            }

            return shopPropositionEntity;
        }

        public async Task<IList<ShopProposition>> GetPaginated(int pageSize = 1, int productPage = 1)
            => await _shopPropositionRepository.GetPaginated(pageSize, productPage);

        public async Task<IList<ShopProposition>> GetAll()
            => await _shopPropositionRepository.GetAll();
    }
}
