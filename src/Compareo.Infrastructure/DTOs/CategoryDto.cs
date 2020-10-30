using System.Collections.Generic;

namespace Compareo.Infrastructure.DTOs
{
    public class CategoryDto
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public IList<CategoryDto> Subs { get; set; }
    }
}
