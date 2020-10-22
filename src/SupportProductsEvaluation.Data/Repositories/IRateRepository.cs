using SupportProductsEvaluation.Data.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Data.Repositories
{
    public interface IRateRepository
    {
        Task Create(Rate category);
        
        Task Update(Rate category);
        
        Task<Rate> Get(int Id);

        Task<Rate> Get(Expression<Func<Rate, bool>> filter);
    }
}
