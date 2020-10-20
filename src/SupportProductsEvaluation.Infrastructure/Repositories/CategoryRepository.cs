using Microsoft.EntityFrameworkCore;
using SupportProductsEvaluation.Data;
using SupportProductsEvaluation.Data.Entities;
using SupportProductsEvaluation.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            => await _db.Category.Include(p => p.ChildrenCategories).Include(p => p.ParentCategory).SingleOrDefaultAsync(s => s.Id == id);

        public async Task<Category> Get(Expression<Func<Category, bool>> filter)
            => await _db.Category.Include(p => p.ChildrenCategories).Include(p => p.ParentCategory).SingleOrDefaultAsync(filter);

        public async Task<IList<Category>> GetAll(Expression<Func<Category, bool>> filter)
            => await _db.Category.AsNoTracking().Include(p => p.ChildrenCategories).Include(p => p.ParentCategory)
                      .Where(filter).OrderBy(p => p.Name).AsQueryable().ToListAsync();

        public async Task<IList<Category>> GetPaginated(Expression<Func<Category, bool>> filter = null, int pageSize = 1, int productPage = 1)
        => await _db.Category.AsNoTracking().Include(p => p.ChildrenCategories).Include(p => p.ParentCategory).
                           Where(filter).OrderBy(p => p.Name)
                          .Skip((productPage - 1) * pageSize)
                          .Take(pageSize).ToListAsync();

        public async Task Update(Category category)
        {
            var categoryEntity = await Get(category.Id);
            categoryEntity.Name = category.Name;
            await _db.SaveChangesAsync();
        }
    }
}
