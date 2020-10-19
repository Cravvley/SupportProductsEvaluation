using SupportProductsEvaluation.Data.Entities;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Services.Interfaces
{
    public interface IRateService
    {
        Task Create(Rate category);
        Task Update(Rate category);
        Task<Rate> Get(int Id);
        Task<Rate> Get(string userId,int productId);
    }
}
