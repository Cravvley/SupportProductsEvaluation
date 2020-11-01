using AutoMapper;
using Compareo.Data.Entities;
using Compareo.Data.Repositories;
using Compareo.Infrastructure.DTOs;
using Compareo.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var productEntity = await _productRepository.Get(id.Value);
            if (productEntity is null)
            {
                return;
            }

            await _productRepository.Delete(productEntity);
        }

        public async Task<Product> Get(int? id)
        {
            var productEntity = await _productRepository.Get(id.Value);
            productEntity.Rates = productEntity.Rates.Where(x=>x.User.LockoutEnd==null||x.User.LockoutEnd<DateTime.Now).ToList();
            
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
            var productEntity = await _productRepository.Get(id.Value);
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

        public async Task AcceptProposition(ProductProposition productProposition)
        {
            var product = _mapper.Map<ProductProposition, Product>(productProposition);

            var exist = await Exist(p => p.Name.ToLower() == product.Name.ToLower() &&
                                 p.CategoryId == product.CategoryId
                                 && p.ShopId == product.ShopId);

            if (exist)
            {
                await _productRepository.Update(product);
            }
            else
            {
                await _productRepository.Create(product);
            }
        }

        public async Task<(IList<ProductDto> products, int productsCount)> GetFiltered(string productName = null, string categoryName = null, string shopName = null, int? pageSize = null, int? productPage = null)
        {
            var products = await GetAllHeaders();

            if (productName is null && categoryName is null && shopName is null)
            {
                return (await GetPaginated(s => true, pageSize.Value, productPage.Value), products.Count);
            }
            else if (!(productName is null || categoryName is null || shopName is null))
            {
                products = await GetAllHeaders(p => p.Name.ToLower()
                                  .Contains(productName.ToLower()) && p.Category.Name.ToLower()
                                  .Contains(categoryName.ToLower()) && p.Shop.Name.Contains(shopName));

                return (await GetPaginated(p => p.Name.ToLower()
                                  .Contains(productName.ToLower()) && p.Category.Name.ToLower()
                                  .Contains(categoryName.ToLower()) && p.Shop.Name.Contains(shopName), pageSize.Value, productPage.Value), products.Count);
            }
            else if (!(productName is null || categoryName is null))
            {
                products = await GetAllHeaders(p => p.Name.ToLower()
                                      .Contains(productName.ToLower()) && p.Category.Name.ToLower()
                                      .Contains(categoryName.ToLower()));

                return (await GetPaginated(p => p.Name.ToLower()
                                   .Contains(productName.ToLower()) && p.Category.Name.ToLower()
                                   .Contains(categoryName.ToLower()), pageSize.Value, productPage.Value), products.Count);
            }
            else if (!(productName is null || shopName is null))
            {
                products = await GetAllHeaders(p => p.Name.ToLower()
                                      .Contains(productName.ToLower()) && p.Shop.Name.ToLower()
                                      .Contains(shopName.ToLower()));

                return (await GetPaginated(p => p.Name.ToLower()
                                   .Contains(productName.ToLower()) && p.Shop.Name.ToLower()
                                   .Contains(shopName.ToLower()), pageSize.Value, productPage.Value), products.Count);
            }
            else if (!(categoryName is null || shopName is null))
            {
                products = await GetAllHeaders(p => p.Shop.Name.ToLower()
                                      .Contains(shopName.ToLower()) && p.Category.Name.ToLower()
                                      .Contains(categoryName.ToLower()));

                return (await GetPaginated(p => p.Shop.Name.ToLower()
                                   .Contains(shopName.ToLower()) && p.Category.Name.ToLower()
                                   .Contains(categoryName.ToLower()), pageSize.Value, productPage.Value), products.Count);
            }
            else if (!(productName is null))
            {
                products = await GetAllHeaders(p => p.Name.ToLower().Contains(productName.ToLower()));

                return (await GetPaginated(p => p.Name.ToLower().Contains(productName.ToLower()), pageSize.Value, productPage.Value), products.Count);
            }
            else if (!(categoryName is null))
            {
                products = await GetAllHeaders(p => p.Category.Name.ToLower().Contains(categoryName.ToLower()));

                return (await GetPaginated(p => p.Category.Name.ToLower().Contains(categoryName.ToLower()), pageSize.Value, productPage.Value), products.Count);
            }
            else if (!(shopName is null))
            {
                products = await GetAllHeaders(p => p.Shop.Name.ToLower().Contains(shopName.ToLower()));

                return (await GetPaginated(p => p.Shop.Name.ToLower().Contains(shopName.ToLower()), pageSize.Value, productPage.Value), products.Count);
            }

            return (products, products.Count);
        }
    }
}
