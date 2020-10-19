﻿using SupportProductsEvaluation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SupportProductsEvaluation.Data.Repositories
{
    public interface IProductRepository
    {
        Task Create(Product product);
        
        Task Delete(int? id);
        
        Task Update(Product product);
        
        Task<IList<Product>> GetAll();
        
        Task<Product> Get(string ProductName, string CategoryName, string SubCategoryName);
        
        Task<Product> Get(int? id);
        
        Task<Product> Get(Expression<Func<Product,bool>>filter);
        
        Task<Product> Get(Product category);
    }
}