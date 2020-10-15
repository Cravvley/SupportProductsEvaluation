using Microsoft.EntityFrameworkCore;
using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Core.Repositories;
using SupportProductsEvaluation.Data;
using System;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Repositories
{
    public class RateRepository : IRateRepository
    {
        private readonly ApplicationDbContext _db;
        public RateRepository(ApplicationDbContext db)
        {
            _db=db;
        }
        public async Task Create(Rate rate)
        {
            await _db.Rate.AddAsync(rate);
            await _db.SaveChangesAsync();
        }

        public async Task<Rate> Get(int id)
                => await _db.Rate.SingleOrDefaultAsync(r => r.Id== id);
        public async Task<Rate> Get(string userId,int productId)
                => await _db.Rate.SingleOrDefaultAsync(x => x.UserId == userId&& x.ProductId == productId);

        public async Task Update(Rate rate)
        {
            var rateEntity = await Get(rate.Id); ;
            rateEntity.Grade = rate.Grade;
            await _db.SaveChangesAsync();
        }
    }
}
