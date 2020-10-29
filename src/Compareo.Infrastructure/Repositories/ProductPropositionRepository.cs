using Compareo.Data;
using Compareo.Data.Entities;
using Compareo.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Compareo.Infrastructure.Repositories
{
    public class ProductPropositionRepository : IProductPropositionRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductPropositionRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task Create(ProductProposition productProposition)
        {
            await _db.ProductProposition.AddAsync(productProposition);

            await _db.SaveChangesAsync();
        }

        public async Task Delete(ProductProposition productProposition)
        {
            _db.ProductProposition.Remove(productProposition);

            await _db.SaveChangesAsync();
        }

        public async Task<ProductProposition> Get(int? id)
            => await _db.ProductProposition.Include(u => u.User).Include(s => s.Shop).Include(c => c.Category).SingleOrDefaultAsync(sp => sp.Id == id);

        public async Task<IList<ProductProposition>> GetAll()
            => await _db.ProductProposition.AsNoTracking().Include(u => u.User)
                                        .Include(s => s.Shop).Include(c => c.Category)
                                        .AsQueryable().ToListAsync();

        public async Task<IList<ProductProposition>> GetPaginated(int pageSize = 1, int productPage = 1)
              => await _db.ProductProposition.AsNoTracking().Include(u => u.User)
                                        .Include(s => s.Shop).Include(c=>c.Category).AsQueryable().OrderByDescending(s => s.Name)
                                        .Skip((productPage - 1) * pageSize)
                                        .Take(pageSize).ToListAsync();
    }
}
