using SupportProductsEvaluation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Data.Repositories
{
    public interface IReportRepository
    {
        Task Create(Report report);

        Task Delete(int? id);

        Task Update(Report report);

        Task<Report> Get(int? id);

        Task<Report> Get(Expression<Func<Report, bool>> filter);

        Task<IList<Report>> GetAll(Expression<Func<Report, bool>> filter);

        Task<IList<Report>> GetPaginated(Expression<Func<Report, bool>> filter, int pageSize = 1, int productPage = 1);

    }
}
