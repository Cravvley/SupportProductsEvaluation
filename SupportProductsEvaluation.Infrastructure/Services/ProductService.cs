using AutoMapper;
using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Core.Repositories;
using SupportProductsEvaluation.Infrastructure.DTOs;
using SupportProductsEvaluation.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task Create(Product product)
        {
            if (product== null)
            {
                throw new ArgumentNullException("product doesn't exist");
            }
            await _productRepository.Create(product);
        }

        public async Task Delete(int? id)
        {
            var productEntity = await _productRepository.Get(id);
            if (productEntity == null)
            {
                throw new ArgumentNullException("product doesn't exist");
            }
            await _productRepository.Delete(id);
        }

        public async Task<Product> Get(int? id)
        {
            var productEntity = await _productRepository.Get(id);
            if (productEntity == null)
            {
                throw new ArgumentNullException("product doesn't exist");
            }
            return productEntity;
        }

        public async Task<IList<Product>> GetAllDetails()
                => await _productRepository.GetAll();

        public async Task<IList<ProductDto>> GetAllHeaders()
        {
            var products = await _productRepository.GetAll();
            return _mapper.Map<IList<Product>, IList<ProductDto>>(products);
        }

        public async Task<bool> IsExist(Product product)
        {
            var productyEntity = await _productRepository.Get(product);
            if (productyEntity == null)
            {
                return false;
            }
            return true;
        }

        public async Task Update(Product product)
        {
            var productEntity = await _productRepository.Get(product.Id);
            if (productEntity == null)
            {
                throw new ArgumentNullException("product doesn't exist");
            }
            await _productRepository.Update(product);
        }
    }
}
