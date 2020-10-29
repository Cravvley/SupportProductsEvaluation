using Compareo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Compareo.Infrastructure.Services.Interfaces
{
    public interface ICommentService
    {
        Task Add(Comment comment);

        Task Delete(int ? id);

        Task<IList<Comment>> GetPaginated(Expression<Func<Comment, bool>> filter = null, int pageSize = 1, int productPage = 1);
    }
}
