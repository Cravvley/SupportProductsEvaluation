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
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public SubCategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(SubCategory subCategory)
        {
            await _db.SubCategory.AddAsync(subCategory);

            await _db.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var subCategory = await Get(id);

            _db.SubCategory.Remove(subCategory);

            await _db.SaveChangesAsync();
        }

        public async Task Update(SubCategory subCategory)
        {
            var subCategoryEntity = await Get(subCategory.Id);

            subCategoryEntity.CategoryId = subCategory.CategoryId;
            subCategoryEntity.Name = subCategory.Name;

            await _db.SaveChangesAsync();
        }

        public async Task<SubCategory> Get(int? id)
            => await _db.SubCategory.Include(c => c.Category).SingleOrDefaultAsync(s => s.Id == id);

        public async Task<SubCategory> Get(Expression<Func<SubCategory, bool>> filter = null)
            => await _db.SubCategory.Include(c => c.Category).FirstOrDefaultAsync(filter);

        public async Task<IList<SubCategory>> GetAll(Expression<Func<SubCategory, bool>> filter = null)
            => await _db.SubCategory.AsNoTracking().Include(c => c.Category).Where(filter).AsQueryable().ToListAsync();

        public async Task<IList<SubCategory>> GetPaginated(Expression<Func<SubCategory, bool>> filter, int pageSize = 1, int productPage = 1)
                => await _db.SubCategory.AsNoTracking().Include(c => c.Category).Where(filter).AsQueryable().OrderBy(p => p.Name)
                                        .Skip((productPage - 1) * pageSize)
                                        .Take(pageSize).ToListAsync();
    }
}
