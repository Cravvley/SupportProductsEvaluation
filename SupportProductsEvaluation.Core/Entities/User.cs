using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SupportProductsEvaluation.Core.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

    }
}
