using AutoMapper;
using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Core.Repositories;
using SupportProductsEvaluation.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task Create(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException("category doesn't exist");
            }
            await _categoryRepository.Create(category);
        }

        public async Task Delete(int? id)
        {
            var categoryEntity = await _categoryRepository.Get(id);
            if (categoryEntity == null)
            {
                throw new ArgumentNullException("category doesn't exist");
            }
            await _categoryRepository.Delete(id);
        }

        public async Task<Category> Get(int? id)
        {
            var categoryEntity = await _categoryRepository.Get(id);
            if (categoryEntity == null)
            {
                throw new ArgumentNullException("category doesn't exist");
            }
            return categoryEntity;
        }

        public async Task<IList<Category>> GetAll()
            => await _categoryRepository.GetAll();
        public async Task<bool> IsExist(Category category)
        {
            var categoryEntity = await _categoryRepository.Get(category);
            if (categoryEntity == null)
            {
                return false;
            }
            return true;
        }
        public async Task Update(Category category)
        {
            var categoryEntity = await _categoryRepository.Get(category.Id);
            if (categoryEntity == null)
            {
                throw new ArgumentNullException("category doesn't exist");
            }
            await _categoryRepository.Update(category);
        }
    }
}
