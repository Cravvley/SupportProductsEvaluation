using SupportProductsEvaluation.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Core.Repositories
{
    public interface ISubCategoryRepository
    {
        Task Create(SubCategory category);
        Task Delete(int? id);
        Task Update(SubCategory category);
        Task<IList<SubCategory>> GetAll();
        Task<SubCategory> Get(int? id);
        Task<SubCategory> Get(SubCategory category);
    }
}
