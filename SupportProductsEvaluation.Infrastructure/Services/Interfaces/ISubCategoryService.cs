using SupportProductsEvaluation.Core.Entities;
using System.Collections.Generic;
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
        Task<bool> IsExist(SubCategory subCategory);
    }
}
