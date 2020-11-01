using Microsoft.EntityFrameworkCore;
using Compareo.Data;
using Compareo.Data.Entities;
using Compareo.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Compareo.Infrastructure.Repositories
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

        public async Task Delete(Shop shop)
        {
            _db.Shop.Remove(shop);

            await _db.SaveChangesAsync();
        }

        public async Task<Shop> Get(int id)
            => await _db.Shop.SingleOrDefaultAsync(s => s.Id == id);

        public async Task<Shop> Get(Expression<Func<Shop, bool>> filter)
            => await _db.Shop.FirstOrDefaultAsync(filter);

        public async Task<IList<Shop>> GetAll(Expression<Func<Shop, bool>> filter)
            => await _db.Shop.AsNoTracking().Where(filter).AsQueryable().ToListAsync();

        public async Task<IList<Shop>> GetPaginated(Expression<Func<Shop, bool>> filter, int pageSize = 1, int productPage = 1)
        => await _db.Shop.AsNoTracking().Where(filter).AsQueryable().OrderBy(p => p.Name)
                                     .Skip((productPage - 1) * pageSize)
                                     .Take(pageSize).ToListAsync();
        public async Task Update(Shop shop)
        {
            var shopEntity = await Get(shop.Id);
            _db.Entry(shopEntity).CurrentValues.SetValues(shop);
            
            await _db.SaveChangesAsync();
        }

    }
}
