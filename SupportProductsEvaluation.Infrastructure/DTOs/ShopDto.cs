using System.ComponentModel.DataAnnotations;

namespace SupportProductsEvaluation.Infrastructure.DTOs
{
    public class ShopDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
