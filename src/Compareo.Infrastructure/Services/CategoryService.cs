using Compareo.Data.Entities;
using Compareo.Data.Repositories;
using Compareo.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Compareo.Infrastructure.Services
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
                return;
            }

            await _categoryRepository.Delete(categoryEntity);
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

        public async Task<IList<Category>> GetPaginated(Expression<Func<Category, bool>> filter = null, int pageSize = 1, int productPage = 1)
        {
            if (filter is null)
            {
                return await _categoryRepository.GetPaginated(p => true, pageSize, productPage);
            }

            return await _categoryRepository.GetPaginated(filter, pageSize, productPage);
        }

        public async Task<(IList<Category> categories, int categoriesCount)> GetFiltered(string categoryName = null, int? pageSize = null, int? productPage = null)
        {
            var categories = await GetAll(c=>c.ParentCategoryId==null);

            if ((pageSize is null || productPage is null)&&categoryName is null)
            {
                return (categories,categories.Count);
            }
            else if (categoryName is null)
            {
                return (await GetPaginated(c => c.ParentCategoryId == null, pageSize.Value, productPage.Value),categories.Count);
            }
            else
            {
                categories = await GetAll(c=>c.Name==categoryName);
                return (await GetPaginated(c => c.Name.ToLower().Contains(categoryName.ToLower()) && c.ParentCategoryId == null,
                                                                                pageSize.Value, productPage.Value),categories.Count);
            }
        }
    }
}
