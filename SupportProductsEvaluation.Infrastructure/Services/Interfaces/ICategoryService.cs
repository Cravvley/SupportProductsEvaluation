using SupportProductsEvaluation.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Services.Interfaces
{
    public interface ICategoryService
    {
        Task Create(Category category);
        Task Delete(int? id);
        Task Update(Category category);
        Task<Category> Get(int? id);
        Task<IList<Category>> GetAll();
        Task<bool> IsExist(Category category);
    }
}
