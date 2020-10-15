using SupportProductsEvaluation.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Core.Repositories
{
    public interface IReportRepository
    {
        Task Create(Report report);
        Task Delete(int? id);
        Task Update(Report report);
        Task<IList<Report>> GetAll();
        Task<Report> Get(int? id);
        Task<Report> Get(Report report);
    }
}
