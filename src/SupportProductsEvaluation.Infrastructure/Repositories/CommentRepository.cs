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
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _db;
        public CommentRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task Add(Comment comment)
        {
            comment.UpdateAt = DateTime.Now;

            await _db.Comment.AddAsync(comment);
            await _db.SaveChangesAsync();
        }

        public async Task<IList<Comment>> GetPaginated(Expression<Func<Comment, bool>> filter, int pageSize = 1, int productPage = 1)
                        => await _db.Comment.AsNoTracking().Include(u=>u.User).Include(p=>p.Product)
                                        .Where(filter).AsQueryable().OrderByDescending(p => p.UpdateAt)
                                        .Skip((productPage - 1) * pageSize)
                                        .Take(pageSize).ToListAsync();
    }
}
