using Microsoft.EntityFrameworkCore;
using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Core.Repositories;
using SupportProductsEvaluation.Data;
using System.Collections.Generic;
using System.Linq;
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
        
        public async Task<SubCategory> Get(int? id)
            => await _db.SubCategory.Include(c => c.Category).SingleOrDefaultAsync(s => s.Id == id);
        
        public async Task<SubCategory> Get(SubCategory subCategory)
            => await _db.SubCategory.Include(c => c.Category).SingleOrDefaultAsync(c => c.Name.ToLower() == subCategory.Name.ToLower()&&c.CategoryId==subCategory.CategoryId);
        
        public async Task<IList<SubCategory>> GetAll()
            => await _db.SubCategory.Include(c=>c.Category).AsQueryable().ToListAsync();
        
        public async Task Update(SubCategory subCategory)
        {
            var subCategoryEntity = await Get(subCategory.Id);
            subCategoryEntity.CategoryId = subCategory.CategoryId;
            subCategoryEntity.Name = subCategory.Name;
            await _db.SaveChangesAsync();
        }
    }
}
