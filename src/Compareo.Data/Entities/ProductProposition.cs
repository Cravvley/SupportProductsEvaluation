using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Compareo.Data.Entities
{
    public class ProductProposition
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [DataType(DataType.Currency), Required, Range(0.01, double.MaxValue, ErrorMessage = "Price should be greater than 0")]
        public double Price { get; set; }

        [Display(Name = "Shop")]
        public int ShopId { get; set; }

        [ForeignKey("ShopId")]
        public virtual Shop Shop { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public byte[] Picture { get; set; }

        public string AdditionalInformation { get; set; }

        [Display(Name = "User Name")]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }
}
