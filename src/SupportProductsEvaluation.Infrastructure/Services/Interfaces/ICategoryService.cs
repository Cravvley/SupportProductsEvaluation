using SupportProductsEvaluation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Services.Interfaces
{
    public interface ICategoryService
    {
        Task Create(Category category);
        Task Delete(int? id);
        Task Update(Category category);
        Task<Category> Get(int? id);
        Task<bool> Exist(Expression<Func<Category, bool>> filter);
        Task<IList<Category>> GetAll(Expression<Func<Category, bool>> filter=null);
        Task<IList<Category>> GetPaginated(Expression<Func<Category, bool>> filter=null, int pageSize=0, int productPage=0);
    }
}
