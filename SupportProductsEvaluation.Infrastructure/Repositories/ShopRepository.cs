using Microsoft.EntityFrameworkCore;
using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Core.Repositories;
using SupportProductsEvaluation.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Repositories
{
    public class ShopRepository: IShopRepository
    {
        private readonly ApplicationDbContext _db;

        public ShopRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task Create(Shop shop)
        {
            await _db.Shop.AddAsync(shop);
            await _db.SaveChangesAsync();
        }
        public async Task Delete(int ?id)
        {
            var shop = await Get(id);
            _db.Shop.Remove(shop);
            await _db.SaveChangesAsync();
        }
        public async Task<Shop> Get(int ?id)
            => await _db.Shop.SingleOrDefaultAsync(s => s.Id == id);
        public async Task<Shop> Get(Shop shop)
            => await _db.Shop.SingleOrDefaultAsync(s => s.City == shop.City && s.Country == shop.Country && s.Name == shop.Name && s.PostalCode == shop.PostalCode && s.StreetAddress == shop.StreetAddress);
        public async Task<IList<Shop>> GetAll()
            => await _db.Shop.AsQueryable().ToListAsync();
        public async Task Update(Shop shop)
        {
            var shopEntity = await Get(shop.Id);
            shopEntity.City = shop.City;
            shopEntity.Country = shop.Country;
            shopEntity.Name = shop.Name;
            shopEntity.PostalCode = shop.PostalCode;
            shopEntity.StreetAddress = shop.StreetAddress;

            await _db.SaveChangesAsync();
        }

    }
}
