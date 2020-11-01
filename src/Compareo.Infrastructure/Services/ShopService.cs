using AutoMapper;
using Compareo.Data.Entities;
using Compareo.Data.Repositories;
using Compareo.Infrastructure.DTOs;
using Compareo.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Compareo.Infrastructure.Services
{
    public class ShopService : IShopService
    {
        private readonly IShopRepository _shopRepository;
        private readonly IMapper _mapper;

        public ShopService(IShopRepository shopRepository, IMapper mapper)
        {
            _shopRepository = shopRepository;
            _mapper = mapper;
        }

        public async Task Create(Shop shop)
        {
            if (shop is null)
            {
                throw new ArgumentNullException("shop doesn't exist");
            }

            await _shopRepository.Create(shop);
        }

        public async Task Delete(int? id)
        {
            var shopEntity = await _shopRepository.Get(id.Value);
            if (shopEntity is null)
            {
                return;
            }

            await _shopRepository.Delete(shopEntity);
        }

        public async Task<Shop> Get(int? id)
        {
            var shopEntity = await _shopRepository.Get(id.Value);
            if (shopEntity is null)
            {
                throw new ArgumentNullException("shop doesn't exist");
            }

            return shopEntity;
        }

        public async Task<IList<Shop>> GetAllDetails(Expression<Func<Shop, bool>> filter = null)
        {
            if (filter is null)
            {
                return await _shopRepository.GetAll(s => true);
            }

            return await _shopRepository.GetAll(filter);
        }


        public async Task<IList<ShopDto>> GetAllHeaders(Expression<Func<Shop, bool>> filter = null)
        {
            if (filter is null)
            {
                return _mapper.Map<IList<Shop>, IList<ShopDto>>(await _shopRepository.GetAll(s => true));
            }

            return _mapper.Map<IList<Shop>, IList<ShopDto>>(await _shopRepository.GetAll(filter));
        }

        public async Task<IList<ShopDto>> GetPaginatedHeaders(Expression<Func<Shop, bool>> filter = null, int pageSize = 1, int productPage = 1)
        {
            if (filter is null)
            {
                return _mapper.Map<IList<Shop>, IList<ShopDto>>(await _shopRepository.GetPaginated(s => true, pageSize, productPage));
            }

            return _mapper.Map<IList<Shop>, IList<ShopDto>>(await _shopRepository.GetPaginated(filter, pageSize, productPage));
        }
        public async Task<bool> Exist(Expression<Func<Shop, bool>> filter)
        {
            var shopEntity = await _shopRepository.Get(filter);
            if (shopEntity is null)
            {
                return false;
            }

            return true;
        }

        public async Task Update(Shop shop)
        {
            var shopEntity = await _shopRepository.Get(shop.Id);
            if (shopEntity is null)
            {
                throw new ArgumentNullException("shop doesn't exist");
            }

            await _shopRepository.Update(shop);
        }

        public async Task AcceptProposition(ShopProposition shopProposition)
        {
            var shop = _mapper.Map<ShopProposition, Shop>(shopProposition);

            var exist = await Exist(s => s.City.ToLower() == shop.City.ToLower() && s.Country.ToLower()
                                  == shop.Country.ToLower() && s.Name.ToLower() == shop.Name.ToLower() && s.PostalCode.ToLower()
                                  == shop.PostalCode.ToLower() && s.StreetAddress.ToLower() == shop.StreetAddress.ToLower());

            if (exist)
            {
                return;
            }
            else
            {
                await _shopRepository.Create(shop);
            }
        }

        public async Task<(IList<ShopDto> shops, int shopsCount)> GetFiltered(string shopName = null, string cityName = null, int? pageSize = null, int? productPage = null)
        {
            var shops = await GetAllHeaders();

            if (shopName is null && cityName is null)
            {
                return (await GetPaginatedHeaders(s => true, pageSize.Value, productPage.Value), shops.Count);
            }
            else if (!(shopName is null || cityName is null))
            {
                shops = await GetAllHeaders(s => s.Name.ToLower()
                                    .Contains(shopName.ToLower()) && s.City.ToLower()
                                    .Contains(cityName.ToLower()));

                return (await GetPaginatedHeaders(s => s.Name.ToLower()
                                    .Contains(shopName.ToLower()) && s.City.ToLower()
                                    .Contains(cityName.ToLower()), pageSize.Value, productPage.Value), shops.Count);
            }
            else if (!(shopName is null))
            {
                shops = await GetAllHeaders(s => s.Name.ToLower().Contains(shopName.ToLower()));

                return (await GetPaginatedHeaders(s => s.Name.ToLower().Contains(shopName.ToLower()), pageSize.Value, productPage.Value), shops.Count);
            }
            else if (!(cityName is null))
            {
                shops = await GetAllHeaders(s => s.City.ToLower().Contains(cityName.ToLower()));

                return (await GetPaginatedHeaders(s => s.City.ToLower().Contains(cityName.ToLower()), pageSize.Value, productPage.Value), shops.Count);
            }

            return (shops, shops.Count);
        }
    }
}
