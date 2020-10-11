using SupportProductsEvaluation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Core.Repositories
{
    public interface ISubCategoryRepository
    {
        Task Create(SubCategory category);
        Task Delete(int? id);
        Task Update(SubCategory category);
        Task<IList<SubCategory>> GetAll();
        Task<IList<SubCategory>> GetAll(Expression<Func<SubCategory, bool>> filter=null);
        Task<SubCategory> Get(int? id);
        Task<SubCategory> Get(SubCategory category);
    }
}
