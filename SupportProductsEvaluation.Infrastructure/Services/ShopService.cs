using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Core.Repositories;
using SupportProductsEvaluation.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Services
{
    public class ShopService: IShopService
    {
        private readonly IShopRepository _shopRepository;
        public ShopService(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }
        public async Task Create(Shop shop)
        {
            if (shop == null)
            {
                throw new ArgumentNullException("shop doesn't exist");
            }
            var shopEntity = _shopRepository.Get(shop);
            if (shopEntity.Result !=null)
            {
                throw new ArgumentException("shop already exsits");
            }
            await _shopRepository.Create(shop);
        }

        public async Task Delete(int id)
        {
            var shopEntity = await _shopRepository.Get(id);
            if (shopEntity == null)
            {
                throw new ArgumentNullException("shop doesn't exist");
            }
            await _shopRepository.Delete(id);
        }

        public async Task<Shop> Get(int id)
        {
            var shopEntity = await _shopRepository.Get(id);
            if (shopEntity == null)
            {
                throw new ArgumentNullException("shop doesn't exist");
            }
            return shopEntity;
        }

        public async Task<IEnumerable<Shop>> GetAll()
            => await _shopRepository.GetAll();

        public async Task Update(Shop shop)
        {
            var shopEntity = await _shopRepository.Get(shop.Id);
            if (shopEntity == null)
            {
                throw new ArgumentNullException("shop doesn't exist");
            }
            await _shopRepository.Update(shop);
        }
    }
}
