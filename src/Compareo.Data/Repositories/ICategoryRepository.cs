using Compareo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Compareo.Data.Repositories
{
    public interface ICategoryRepository
    {
        Task Create(Category category);
     
        Task Delete(int? id);
        
        Task Update(Category category);
        
        Task<Category> Get(int? id);
        
        Task<Category> Get(Expression<Func<Category, bool>> filter);
        
        Task<IList<Category>> GetAll(Expression<Func<Category,bool>>filter);
        
        Task<IList<Category>> GetPaginated(Expression<Func<Category,bool>>filter,int pageSize=1, int productPage=1);
    }
}
