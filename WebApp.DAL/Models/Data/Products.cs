using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DTO;

namespace WebApp.DAL.Models.Data
{
    public class Product
    {
        public Product(ProductRequestDTO product)
        {
            if(product.Id.HasValue)
            {
                Id = product.Id.Value;
            }
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            CreatedAt = DateTime.Now;
            LastUpdated = DateTime.Now;
        }

        public Product(ProductResponseDTO product)
        {
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            CreatedAt = product.CreatedAt;
            LastUpdated = product.LastUpdated;
        }

        public Product(int id, string name, string description, double price, DateTime createdAt, DateTime lastUpdated)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CreatedAt = createdAt;
            LastUpdated = lastUpdated;
        }

        public Product()
        {
            Name = String.Empty;
            Description = String.Empty;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
