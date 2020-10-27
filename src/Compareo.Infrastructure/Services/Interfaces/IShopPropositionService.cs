﻿using Compareo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Compareo.Infrastructure.Services.Interfaces
{
    public interface IShopPropositionService
    {
        Task Create(ShopProposition shopProposition);

        Task Delete(int? id);

        Task<ShopProposition> Get(int? id);

        Task<IList<ShopProposition>> GetPaginated(Expression<Func<ShopProposition, bool>> filter=null, int pageSize = 1, int productPage = 1);
    }
}
