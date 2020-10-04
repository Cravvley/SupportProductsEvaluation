using SupportProductsEvaluation.Core.Entities;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Services.Interfaces
{
    public interface IShopService
    {
        Task Create(Shop shop);
        Task Delete();
        Task Update();
    }
}
