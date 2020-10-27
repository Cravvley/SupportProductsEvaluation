﻿using Compareo.Data;
using Compareo.Data.Entities;
using Compareo.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Compareo.Infrastructure.Repositories
{
    public class ShopPropositionRepository : IShopPropositionRepository
    {
        private readonly ApplicationDbContext _db;

        public ShopPropositionRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(ShopProposition shopProposition)
        {
            await _db.ShopProposition.AddAsync(shopProposition);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var shopPropositionEntity = await Get(id);
            _db.ShopProposition.Remove(shopPropositionEntity);
            await _db.SaveChangesAsync();
        }

        public async Task<ShopProposition> Get(int? id)
            => await _db.ShopProposition.SingleOrDefaultAsync(sp => sp.Id == id);


        public async Task<IList<ShopProposition>> GetPaginated(Expression<Func<ShopProposition, bool>> filter, int pageSize = 1, int productPage = 1)
              => await _db.ShopProposition.AsNoTracking().Include(u => u.User)
                                        .Where(filter).AsQueryable().OrderByDescending(s => s.Name)
                                        .Skip((productPage - 1) * pageSize)
                                        .Take(pageSize).ToListAsync();
    }
}
