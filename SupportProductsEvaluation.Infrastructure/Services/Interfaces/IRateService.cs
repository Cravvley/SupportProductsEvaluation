using SupportProductsEvaluation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
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
