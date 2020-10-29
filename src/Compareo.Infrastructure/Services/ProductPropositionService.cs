using Compareo.Data.Entities;
using Compareo.Data.Repositories;
using Compareo.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Compareo.Infrastructure.Services
{
    public class ProductPropositionService : IProductPropositionService
    {
        private readonly IProductPropositionRepository _productPropositionRepository;

        public ProductPropositionService(IProductPropositionRepository productPropositionRepository)
        {
            _productPropositionRepository = productPropositionRepository;
        }

        public async Task Create(ProductProposition productProposition)
        {
            if (productProposition is null)
            {
                throw new ArgumentNullException("shop doesn't exist");
            }

            await _productPropositionRepository.Create(productProposition);
        }

        public async Task Delete(int? id)
        {
            var productPropositionEntity = await _productPropositionRepository.Get(id);
            if (productPropositionEntity is null)
            {
                return;
            }

            await _productPropositionRepository.Delete(productPropositionEntity);
        }

        public async Task<ProductProposition> Get(int? id)
        {
            var productPropositionEntity = await _productPropositionRepository.Get(id);
            if (productPropositionEntity is null)
            {
                throw new ArgumentNullException("product doesn't exist");
            }

            return productPropositionEntity;
        }

        public async Task<IList<ProductProposition>> GetPaginated(int pageSize = 1, int productPage = 1)
            => await _productPropositionRepository.GetPaginated(pageSize, productPage);

        public async Task<IList<ProductProposition>> GetAll()
            => await _productPropositionRepository.GetAll();
    }
}
