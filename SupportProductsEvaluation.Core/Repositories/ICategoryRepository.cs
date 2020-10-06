using SupportProductsEvaluation.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Core.Repositories
{
    public interface ICategoryRepository
    {
        Task Create(Category category);
        Task Delete(int? id);
        Task Update(Category category);
        Task<IList<Category>> GetAll();
        Task<Category> Get(int? id);
        Task<Category> Get(Category category);
    }
}
