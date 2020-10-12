using AutoMapper;
using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Core.Repositories;
using SupportProductsEvaluation.Infrastructure.DTOs;
using SupportProductsEvaluation.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Services
{
    public class ShopService : IShopService
    {
        private readonly IShopRepository _shopRepository;
        private readonly IMapper _mapper;

        public ShopService(IShopRepository shopRepository,IMapper mapper)
        {
            _shopRepository = shopRepository;
            _mapper = mapper;
        }
        public async Task Create(Shop shop)
        {
            if (shop == null)
            {
                throw new ArgumentNullException("shop doesn't exist");
            }
            await _shopRepository.Create(shop);
        }

        public async Task Delete(int? id)
        {
            var shopEntity = await _shopRepository.Get(id);
            if (shopEntity == null)
            {
                throw new ArgumentNullException("shop doesn't exist");
            }
            await _shopRepository.Delete(id);
        }

        public async Task<Shop> Get(int? id)
        {
            var shopEntity = await _shopRepository.Get(id);
            if (shopEntity == null)
            {
                throw new ArgumentNullException("shop doesn't exist");
            }
            return shopEntity;
        }

        public async Task<IList<Shop>> GetAllDetails()
            => await _shopRepository.GetAll();

        public async Task<IList<ShopDto>> GetAllHeaders()
        {
            var shops = await _shopRepository.GetAll();
            return _mapper.Map<IList<Shop>, IList<ShopDto>>(shops);
        }
        public async Task<bool> IsExist(Shop shop)
        {
            var shopEntity = await _shopRepository.Get(shop);
            if (shopEntity == null)
            {
                return false;
            }
            return true;
        }

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
