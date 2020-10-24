using AutoMapper;
using Compareo.Data.Entities;
using Compareo.Data.Repositories;
using Compareo.Infrastructure.DTOs;
using Compareo.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Compareo.Infrastructure.Services
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
            if (product is null)
            {
                throw new ArgumentNullException("product doesn't exist");
            }
            await _productRepository.Create(_mapper.Map<ProductDto, Product>(product));
        }

        public async Task Delete(int? id)
        {
            var productEntity = await _productRepository.Get(id);
            if (productEntity is null)
            {
                return;
            }
            await _productRepository.Delete(id);
        }

        public async Task<Product> Get(int? id)
        {
            var productEntity = await _productRepository.Get(id);
            if (productEntity is null)
            {
                throw new ArgumentNullException("product doesn't exist");
            }
            return productEntity;
        }

        public async Task<Product> Get(Expression<Func<Product, bool>> filter)
                    => await _productRepository.Get(filter);
        public async Task<ProductDto> GetDto(int? id)
        {
            var productEntity = await _productRepository.Get(id);
            if (productEntity is null)
            {
                throw new ArgumentNullException("product doesn't exist");
            }

            return _mapper.Map<Product, ProductDto>(productEntity);
        }

        public async Task<IList<ProductDto>> GetAllHeaders(Expression<Func<Product, bool>> filter = null)
        {
            if (filter is null)
            {
                return _mapper.Map<IList<Product>, IList<ProductDto>>(await _productRepository.GetAll(p => true));
            }

            return _mapper.Map<IList<Product>, IList<ProductDto>>(await _productRepository.GetAll(filter));
        }

        public async Task<IList<ProductDto>> GetPaginated(Expression<Func<Product, bool>> filter = null, int pageSize = 1, int productPage = 1)
        {
            if (filter is null)
            {
                return _mapper.Map<IList<Product>, IList<ProductDto>>(await _productRepository.GetPaginated(p => true, pageSize, productPage));
            }

            return _mapper.Map<IList<Product>, IList<ProductDto>>(await _productRepository.GetPaginated(filter, pageSize, productPage));
        }

        public async Task<IList<Product>> GetAllDetails(Expression<Func<Product, bool>> filter = null)
        {
            if (filter is null)
            {
                return await _productRepository.GetAll(p => true);
            }

            return await _productRepository.GetAll(filter);
        }

        public async Task Update(ProductDto product)
        {
            var productEntity = await _productRepository.Get(product.Id);
            if (productEntity is null)
            {
                throw new ArgumentNullException("product doesn't exist");
            }
            await _productRepository.Update(_mapper.Map<ProductDto, Product>(product));
        }

        public async Task<bool> Exist(Expression<Func<Product, bool>> filter)
        {
            var productEntity = await _productRepository.Get(filter);
            if (productEntity is null)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> Exist(Expression<Func<ProductDto, bool>> filter)
        {
            var productEntity = await _productRepository.Get(_mapper.Map<Expression<Func<ProductDto, bool>>, Expression<Func<Product, bool>>>(filter));
            if (productEntity is null)
            {
                return false;
            }

            return true;
        }
    }
}
