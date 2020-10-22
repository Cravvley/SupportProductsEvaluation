using SupportProductsEvaluation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Services.Interfaces
{
    public interface ISubCategoryService
    {
        Task Create(SubCategory subCategory);
        
        Task Delete(int? id);
        
        Task Update(SubCategory subCategory);
        
        Task<SubCategory> Get(int? id);

        Task<bool> Exist(Expression<Func<SubCategory, bool>> filter);
        
        Task<IList<SubCategory>> GetAll(Expression<Func<SubCategory, bool>> filter = null);

        Task<IList<SubCategory>> GetPaginated(Expression<Func<SubCategory, bool>> filter = null, int pageSize = 0, int productPage = 0);
        
    }
}
