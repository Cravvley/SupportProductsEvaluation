using Compareo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Compareo.Infrastructure.Services.Interfaces
{
    public interface IReportService
    {
        Task Create(Report report);

        Task Delete(int? id);

        Task Update(Report report);
        Task<Report> Get(int? id);

        Task<bool> Exist(Expression<Func<Report, bool>> filter);

        Task<IList<Report>> GetAll(Expression<Func<Report, bool>> filter=null);

        Task<IList<Report>> GetPaginated(Expression<Func<Report, bool>> filter = null, int pageSize = 1, int productPage = 1);
    }
}
