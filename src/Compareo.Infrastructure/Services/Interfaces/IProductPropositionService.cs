using Compareo.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Compareo.Infrastructure.Services.Interfaces
{
    public interface IProductPropositionService
    {
        Task Create(ProductProposition productProposition);

        Task Delete(int? id);

        Task<ProductProposition> Get(int? id);

        Task<IList<ProductProposition>> GetPaginated(int pageSize = 1, int productPage = 1);

        Task<IList<ProductProposition>> GetAll();
    }
}
