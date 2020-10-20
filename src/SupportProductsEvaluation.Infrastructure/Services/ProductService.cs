using AutoMapper;
using SupportProductsEvaluation.Data.Entities;
using SupportProductsEvaluation.Data.Repositories;
using SupportProductsEvaluation.Infrastructure.DTOs;
using SupportProductsEvaluation.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task Create(ProductDto product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("product doesn't exist");
            }
            await _productRepository.Create(_mapper.Map<ProductDto, Product>(product));
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

        public async Task<Product> Get(Expression<Func<Product, bool>> filter)
                    => await _productRepository.Get(filter);

        public async Task<IList<Product>> GetAllDetails()
                => await _productRepository.GetAll();

        public async Task<IList<ProductDto>> GetAllHeaders()
        {
            var products = await _productRepository.GetAll();
            return _mapper.Map<IList<Product>, IList<ProductDto>>(products);
        }

        public async Task<ProductDto> GetDto(int? id)
        {
            var productEntity = await _productRepository.Get(id);
            if (productEntity == null)
            {
                throw new ArgumentNullException("product doesn't exist");
            }
            return _mapper.Map<Product,ProductDto>(productEntity);
        }


        public async Task<bool> IsExist(ProductDto product)
        {
            var productyEntity = await _productRepository.Get(_mapper.Map<ProductDto, Product>(product));
            if (productyEntity == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> IsExist(string ProductName, string CategoryName, string SubcategoryName)
        {
            var productyEntity = await _productRepository.Get(ProductName,CategoryName,SubcategoryName);
            if (productyEntity == null)
            {
                return false;
            }
            return true;
        }

        public async Task Update(ProductDto product)
        {
            var productEntity = await _productRepository.Get(product.Id);
            if (productEntity == null)
            {
                throw new ArgumentNullException("product doesn't exist");
            }
            await _productRepository.Update(_mapper.Map<ProductDto, Product>(product));
        }
    }
}
