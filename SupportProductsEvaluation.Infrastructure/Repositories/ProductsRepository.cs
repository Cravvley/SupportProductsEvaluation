using Microsoft.EntityFrameworkCore;
using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Core.Repositories;
using SupportProductsEvaluation.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Repositories
{
    public class ProductsRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductsRepository(ApplicationDbContext db)
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
                                .Include(sc => sc.SubCategory).Include(co => co.Comments)
                                .Include(r => r.Rates).SingleOrDefaultAsync(p => p.Id == id);

        public async Task<Product> Get(Product product)
                => await _db.Product.Include(s => s.Shop).Include(c => c.Category)
                                .Include(sc => sc.SubCategory).Include(co => co.Comments)
                                .Include(r => r.Rates)
                                .SingleOrDefaultAsync(p => p.Name.ToLower() == product.Name.ToLower() &&
                                 p.CategoryId == product.CategoryId &&
                                 p.SubCategoryId == product.SubCategoryId &&
                                 p.ShopId == product.ShopId);

        public async Task<IList<Product>> GetAll()
                => await _db.Product.AsQueryable().ToListAsync();

        public async Task Update(Product product)
        {
            var productEntity = await Get(product.Id);
            productEntity.Name = product.Name;
            productEntity.Picture = product.Picture;
            productEntity.Description = product.Description;
            productEntity.CategoryId = product.CategoryId;
            productEntity.SubCategoryId = product.SubCategoryId;
            productEntity.ShopId = product.ShopId;
            await _db.SaveChangesAsync();
        }
    }
}
