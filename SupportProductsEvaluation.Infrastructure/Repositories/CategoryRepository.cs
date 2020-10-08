using Microsoft.EntityFrameworkCore;
using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Core.Repositories;
using SupportProductsEvaluation.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task Create(Category category)
        {
            await _db.Category.AddAsync(category);
            await _db.SaveChangesAsync();
        }
        public async Task Delete(int? id)
        {
            var category = await Get(id);
            _db.Category.Remove(category);
            await _db.SaveChangesAsync();
        }
        public async Task<Category> Get(int? id)
            => await _db.Category.SingleOrDefaultAsync(s => s.Id == id);
        public async Task<Category> Get(Category category)
            => await _db.Category.SingleOrDefaultAsync(c => c.Name == category.Name);
        public async Task<IList<Category>> GetAll()
            => await _db.Category.AsQueryable().ToListAsync();
        public async Task Update(Category category)
        {
            var categoryEntity = await Get(category.Id);
            categoryEntity.Name = category.Name;
            await _db.SaveChangesAsync();
        }
    }
}
