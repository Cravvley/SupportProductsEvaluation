﻿using Compareo.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Compareo.Infrastructure.DTOs
{
    public class ProductDto
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        
        public double AverageGrade { get; set; }

        [DataType(DataType.Currency), Required, Range(0.01, double.MaxValue, ErrorMessage = "Price should be greater than 0")]
        public double Price { get; set; }

        [Display(Name = "Shop")]
        public int ShopId { get; set; }
        
        public virtual Shop Shop { get; set; }

        [Display(Name = "Category") ]
        public int CategoryId { get; set; }
        
        public virtual Category Category { get; set; }

        public byte[] Picture { get; set; }
    }
}
