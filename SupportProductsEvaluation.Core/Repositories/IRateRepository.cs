using SupportProductsEvaluation.Core.Entities;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Core.Repositories
{
    public interface IRateRepository
    {
        Task Create(Rate category);
        Task Update(Rate category);
        Task<Rate> Get(int Id);
        Task<Rate> Get(string UserId,int productId);
    }
}
