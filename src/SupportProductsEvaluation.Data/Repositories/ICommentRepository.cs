using SupportProductsEvaluation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Data.Repositories
{
    public interface ICommentRepository
    {
        Task Add(Comment comment);

        Task<IList<Comment>> GetPaginated(Expression<Func<Comment, bool>> filter, int pageSize = 1, int productPage = 1);
    }
}
