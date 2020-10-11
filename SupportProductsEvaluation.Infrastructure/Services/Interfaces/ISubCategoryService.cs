using SupportProductsEvaluation.Core.Entities;
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
        Task<IList<SubCategory>> GetAll();
        Task<IList<SubCategory>> GetAll(Expression<Func<SubCategory, bool>> filter = null);
        Task<bool> IsExist(SubCategory subCategory);
    }
}
