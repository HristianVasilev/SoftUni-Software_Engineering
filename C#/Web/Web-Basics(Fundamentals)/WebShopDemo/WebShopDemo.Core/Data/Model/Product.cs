﻿namespace WebShopDemo.Core.Data.Model
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Comment("Products to sell.")]
    public class Product
    {
        [Key]
        [Comment("Primary key - identifier")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [Comment("Product name")]
        public string Name { get; set; }

        [Required]
        [Comment("Product price")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Products in stock")]
        public int Quantity { get; set; }
    }
}
