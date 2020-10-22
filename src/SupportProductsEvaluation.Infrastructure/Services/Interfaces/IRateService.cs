using SupportProductsEvaluation.Data.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Services.Interfaces
{
    public interface IRateService
    {
        Task Create(Rate category);

        Task Update(Rate category);

        Task<Rate> Get(int Id);

        Task<Rate> Get(Expression<Func<Rate,bool>>filter);
    }
}
