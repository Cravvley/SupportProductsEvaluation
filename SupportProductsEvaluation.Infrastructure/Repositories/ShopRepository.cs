using Microsoft.EntityFrameworkCore;
using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Core.Repositories;
using SupportProductsEvaluation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Repositories
{
    public class ShopRepository : IShopRepository
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

        public async Task Delete(int id)
        {
            var shop = await _db.Shop.Where(s => s.Id == id).FirstOrDefaultAsync();
            _db.Shop.Remove(shop);
            await _db.SaveChangesAsync();
        }

        public Task<Shop> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task<Shop>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Shop shop)
        {
            throw new NotImplementedException();
        }
    }
}
