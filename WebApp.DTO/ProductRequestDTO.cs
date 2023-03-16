using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.DTO
{
    public class ProductRequestDTO
    {
        public ProductRequestDTO(ProductResponseDTO product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
        }
        public ProductRequestDTO()
        {
            
        }
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The Name must be between 3 and 50 characters.")]
        public string Name { get; set; }
        [StringLength(200, MinimumLength = 3, ErrorMessage = "The Description must be between 3 and 50 characters.")]
        public string Description { get; set; }
        [Range(0.00, 200.00, ErrorMessage = "The Price must be between 0.00 and 200.00.")]
        public double Price { get; set; }
    }
}
