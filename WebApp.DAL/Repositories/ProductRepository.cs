using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DAL.Models.Data;
using WebApp.DAL.Repositories.Interfaces;
using WebApp.DTO;

namespace WebApp.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ProductManagerDbContext _context;
        public ProductRepository(ProductManagerDbContext context)
        {
            _context = context;
        }
        public bool CreateProduct(ProductRequestDTO product)
        {
            try
            {
                _context.Products.Add(new Product(product));
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct(ProductRequestDTO product)
        {
            throw new NotImplementedException();
        }

        public bool EditProduct(ProductRequestDTO product)
        {
            throw new NotImplementedException();
        }

        public ProductResponseDTO GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<ProductResponseDTO> GetProducts(int pagingSize, int skipAmount)
        {
            throw new NotImplementedException();
        }
    }
}
