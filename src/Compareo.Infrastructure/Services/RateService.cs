using Compareo.Data.Entities;
using Compareo.Data.Repositories;
using Compareo.Infrastructure.Services.Interfaces;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Compareo.Infrastructure.Services
{
    public class RateService : IRateService
    {
        private readonly IRateRepository _rateRepository;

        public RateService(IRateRepository rateRepository)
        {
            _rateRepository = rateRepository;
        }

        public async Task Create(Rate rate)
        {
            if (rate is null)
            {
                throw new ArgumentNullException("rate doesn't exist");
            }
            await _rateRepository.Create(rate);
        }

        public async Task<Rate> Get(int id)
                => await _rateRepository.Get(id);

        public async Task<Rate> Get(Expression<Func<Rate, bool>> filter)
                    => await _rateRepository.Get(filter);

        public async Task Update(Rate rate)
        {
            if (rate is null)
            {
                throw new ArgumentNullException("rate doesn't exist");
            }

            await _rateRepository.Update(rate);
        }
    }
}
