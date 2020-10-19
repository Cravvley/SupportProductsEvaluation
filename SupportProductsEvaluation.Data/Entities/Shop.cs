using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SupportProductsEvaluation.Data.Entities
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string Country { get; set; }
    }
}