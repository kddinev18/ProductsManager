using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DAL.Models.Data;
using WebApp.DAL.Repositories.Interfaces;
using WebApp.DTO;
using static System.Net.Mime.MediaTypeNames;

namespace WebApp.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ProductManagerDbContext _context;
        public ProductRepository(IProductManagerDbContex context)
        {
            _context = context as ProductManagerDbContext;
        }
        public bool CreateProduct(Product product, ref string errorMessage)
        {
            char[] SpecialChars = "!@#$%^&*()".ToCharArray();
            int indexOf = product.Name.IndexOfAny(SpecialChars);
            try
            {
                if (product.Name.All(char.IsDigit) || product.Name.Any(c => char.IsSymbol(c)))
                    throw new ArgumentException("Name cannot contain digits");

                if (indexOf != -1)
                    throw new ArgumentException("Name cannot contain symbols");

                _context.Products.Add(product);
                _context.SaveChanges();
            }
            catch (ArgumentException ex)
            {
                errorMessage = ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("unique"))
                    errorMessage = "Can't have products with the same name";
                else 
                    errorMessage = "Server error";
                return false;
            }
            return true;
        }

        public bool DeleteProduct(int id)
        {
            try
            {
                _context.Products.Remove(_context.Products.Where(product => product.Id == id).First());
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteProduct(Product productToRemove)
        {
            try
            {
                _context.Products.Remove(_context.Products.Where(product => product.Id == productToRemove.Id).First());
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool EditProduct(Product productToEdit, ref string errorMessage)
        {
            try
            {
                Product product = _context.Products
                    .Where(product => product.Id == productToEdit.Id)
                    .First();

                product.Name = productToEdit.Name;
                product.Price = productToEdit.Price;
                product.Description = productToEdit.Description;
                product.LastUpdated = DateTime.Now;

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UniqueConstraint"))
                    errorMessage = "Can't have products with the same name";
                else
                    errorMessage = "Server error";

                return false;
            }

            return true;
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Products.CountAsync();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Where(product => product.Id == id).First();
        }

        public IEnumerable<Product> GetProducts(int pagingSize, int skipAmount)
        {
            return _context.Products.Skip(skipAmount).Take(pagingSize);
        }
    }
}
