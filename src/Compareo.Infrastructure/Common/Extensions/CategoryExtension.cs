using Compareo.Data.Entities;
using Compareo.Infrastructure.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Compareo.Infrastructure.Common.Extensions
{
    public static class CategoryExtensions
    {
        public static IList<CategoryDto> BuildTrees(this IList<Category> categories)
        {
            var dtos = categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Title = c.Name,
                ParentId = c.ParentCategoryId,
            }).ToList();

            return BuildTrees(null, dtos);
        }

        private static IList<CategoryDto> BuildTrees(int? pid, IList<CategoryDto> candicates)
        {
            var subs = candicates.Where(c => c.ParentId == pid).ToList();
            if (subs.Count() == 0)
            {
                return new List<CategoryDto>();
            }
            foreach (var i in subs)
            {
                i.Subs = BuildTrees(i.Id, candicates);
            }
            return subs;
        }
    }
}
