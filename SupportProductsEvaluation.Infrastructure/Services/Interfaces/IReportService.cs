using SupportProductsEvaluation.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Services.Interfaces
{
    public interface IReportService
    {
        Task Create(Report report);
        Task Delete(int? id);
        Task Update(Report report);
        Task<Report> Get(int? id);
        Task<IList<Report>> GetAll();
        Task<bool> IsExist(Report report);
    }
}
