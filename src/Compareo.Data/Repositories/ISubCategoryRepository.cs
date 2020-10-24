using Compareo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Compareo.Data.Repositories
{
    public interface ISubCategoryRepository
    {
        Task Create(SubCategory category);
        
        Task Delete(int? id);
        
        Task Update(SubCategory category);
        
        Task<SubCategory> Get(int? id);
        
        Task<SubCategory> Get(Expression<Func<SubCategory, bool>> filter);

        Task<IList<SubCategory>> GetAll(Expression<Func<SubCategory, bool>> filter);
        
        Task<IList<SubCategory>> GetPaginated(Expression<Func<SubCategory, bool>> filter, int pageSize = 1, int productPage = 1);
    }
}
