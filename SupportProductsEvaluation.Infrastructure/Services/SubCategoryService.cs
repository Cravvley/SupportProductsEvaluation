using SupportProductsEvaluation.Core.Entities;
using SupportProductsEvaluation.Core.Repositories;
using SupportProductsEvaluation.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Infrastructure.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }
        public async Task Create(SubCategory subCategory)
        {
            if (subCategory == null)
            {
                throw new ArgumentNullException("subcategory doesn't exist");
            }
            await _subCategoryRepository.Create(subCategory);
        }

        public async Task Delete(int? id)
        {
            var subCategoryEntity = await _subCategoryRepository.Get(id);
            if (subCategoryEntity == null)
            {
                throw new ArgumentNullException("subcategory doesn't exist");
            }
            await _subCategoryRepository.Delete(id);
        }

        public async Task<SubCategory> Get(int? id)
        {
            var subCategoryEntity = await _subCategoryRepository.Get(id);
            if (subCategoryEntity == null)
            {
                throw new ArgumentNullException("subcategory doesn't exist");
            }
            return subCategoryEntity;
        }

        public async Task<IList<SubCategory>> GetAll()
            => await _subCategoryRepository.GetAll();
       
        public async Task<bool> IsExist(SubCategory subCategory)
        {
            var subCategoryEntity = await _subCategoryRepository.Get(subCategory);
            if (subCategoryEntity == null)
            {
                return false;
            }
            return true;
        }
        
        public async Task Update(SubCategory subCategory)
        {
            var subCategoryEntity = await _subCategoryRepository.Get(subCategory.Id);
            if (subCategoryEntity == null)
            {
                throw new ArgumentNullException("subcategory doesn't exist");
            }
            await _subCategoryRepository.Update(subCategory);
        }
    }
}
