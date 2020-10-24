using Compareo.Data.Entities;
using Compareo.Data.Repositories;
using Compareo.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Compareo.Infrastructure.Services
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
            if (subCategory is null)
            {
                throw new ArgumentNullException("subcategory doesn't exist");
            }

            await _subCategoryRepository.Create(subCategory);
        }

        public async Task Delete(int? id)
        {
            var subCategoryEntity = await _subCategoryRepository.Get(id);
            if (subCategoryEntity is null)
            {
                return;
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

        public async Task<IList<SubCategory>> GetAll(Expression<Func<SubCategory, bool>> filter = null)
        {
            if (filter is null)
            {
                return await _subCategoryRepository.GetAll(sc=>true);
            }
            
            return await _subCategoryRepository.GetAll(filter);
        }

        public async Task<IList<SubCategory>> GetPaginated(Expression<Func<SubCategory, bool>> filter = null, int pageSize = 0, int productPage = 0)
        {
            if (filter is null)
            {
                return await _subCategoryRepository.GetPaginated(p => true, pageSize, productPage);
            }

            return await _subCategoryRepository.GetPaginated(filter, pageSize, productPage);
        }

        public async Task<bool> Exist(Expression<Func<SubCategory, bool>> filter)
        {
            var subCategoryEntity = await _subCategoryRepository.Get(filter);
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
