namespace WebShopDemo.Core.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Product model
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// Product identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Product Name
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null;

        /// <summary>
        /// Product price
        /// </summary>
        [Range(typeof(decimal), "0.1", "79228162514264337593543950335", ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }

        /// <summary>
        /// Product availability
        /// </summary>
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
