﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopVendorEFCore.Models
{
    public class Laptop
    {
        [Key]
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        public int Year { get; set; }
    }
}
