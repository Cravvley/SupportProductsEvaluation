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
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Product product)
        {
            await _db.Product.AddAsync(product);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var productEntity = await Get(id);
            _db.Product.Remove(productEntity);
            await _db.SaveChangesAsync();
        }

        public async Task<Product> Get(int? id)
                => await _db.Product.Include(s => s.Shop).Include(c => c.Category)
                                .Include(co => co.Comments).ThenInclude(u => u.User)
                                .Include(r => r.Rates).FirstOrDefaultAsync(p => p.Id == id);


        public async Task Update(Product product)
        {
            var productEntity = await Get(product.Id);

            productEntity.Picture = product.Picture;
            productEntity.Description = product.Description;

            await _db.SaveChangesAsync();

        }

        public async Task<Product> Get(Expression<Func<Product, bool>> filter)
                    => await _db.Product.Include(s => s.Shop).Include(s => s.Category)
                    .Include(s => s.Rates).FirstOrDefaultAsync(filter);

        public async Task<IList<Product>> GetAll(Expression<Func<Product, bool>> filter)
                => await _db.Product.AsNoTracking().Include(s => s.Shop)
                                .Include(c => c.Category)
                                .Include(co => co.Comments).Include(r => r.Rates).Where(filter).AsQueryable()
                                .ToListAsync();

        public async Task<IList<Product>> GetPaginated(Expression<Func<Product, bool>> filter, int pageSize = 1, int productPage = 1)
         => await _db.Product.AsNoTracking().Include(s => s.Shop).Include(s => s.Category).Where(filter).AsQueryable().OrderBy(p => p.Name)
                                      .Skip((productPage - 1) * pageSize)
                                      .Take(pageSize).ToListAsync();

        public async Task<double> GetMaxPrice(Expression<Func<Product, bool>> filter)
            => await _db.Product.Where(filter).Select(p => p.Price).MaxAsync();

        public async Task<double> GetMinPrice(Expression<Func<Product, bool>> filter)
            => await _db.Product.Where(filter).Select(p => p.Price).MinAsync();

        public async Task<double> GetAvgGrade(Expression<Func<Product, bool>> filter)
        {
            var productEntities = await GetAll(filter);
            return productEntities.Select(p => p.AverageGrade).Average();
        }
               
        public async Task<double> GetAvgPrice(Expression<Func<Product, bool>> filter)
                => await _db.Product.Where(filter).Select(p => p.Price).AverageAsync();
    }
}
