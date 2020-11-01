using Compareo.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Compareo.Data.Repositories
{
    public interface IProductPropositionRepository
    {
        Task Create(ProductProposition productProposition);

        Task Delete(ProductProposition productProposition);

        Task<ProductProposition> Get(int id);

        Task<IList<ProductProposition>> GetPaginated(int pageSize = 1, int productPage = 1);

        Task<IList<ProductProposition>> GetAll();
    }
}
