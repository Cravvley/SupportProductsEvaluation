using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Compareo.Data.Entities
{
    public class ShopProposition
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

        public string AdditionalInformation { get; set; }

        [Display(Name = "User Name")]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }
}
