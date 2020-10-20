using SupportProductsEvaluation.Data.Entities;
using SupportProductsEvaluation.Data.Repositories;
using SupportProductsEvaluation.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Create(Category category)
        {
            if (category is null)
            {
                throw new ArgumentNullException("category doesn't exist");
            }
            await _categoryRepository.Create(category);
        }

        public async Task Delete(int? id)
        {
            var categoryEntity = await _categoryRepository.Get(id);
            if (categoryEntity is null)
            {
                throw new ArgumentNullException("category doesn't exist");
            }
            await _categoryRepository.Delete(id);
        }

        public async Task<Category> Get(int? id)
        {
            var categoryEntity = await _categoryRepository.Get(id);
            if (categoryEntity is null)
            {
                throw new ArgumentNullException("category doesn't exist");
            }
            return categoryEntity;
        }

        public async Task<IList<Category>> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            if (filter is null)
            {
                return await _categoryRepository.GetAll(p => true);
            }
            return await _categoryRepository.GetAll(filter);
        }


        public async Task<bool> Exist(Expression<Func<Category, bool>> filter)
        {
            var categoryEntity = await _categoryRepository.Get(filter);
            if (categoryEntity is null)
            {
                return false;
            }
            return true;
        }

        public async Task Update(Category category)
        {
            var categoryEntity = await _categoryRepository.Get(category.Id);
            if (categoryEntity is null)
            {
                throw new ArgumentNullException("category doesn't exist");
            }
            await _categoryRepository.Update(category);
        }

        public async Task<IList<Category>> GetPaginated(Expression<Func<Category, bool>> filter=null, int pageSize=1, int productPage=1)
        {
            if(filter is null)
            {
                return await _categoryRepository.GetPaginated(p => true, pageSize, productPage);
            }
            return await _categoryRepository.GetPaginated(filter, pageSize, productPage);
        }
    }
}
