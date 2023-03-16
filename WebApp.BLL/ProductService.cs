using WebApp.BLL.Interfaces;
using WebApp.DAL.Models.Data;
using WebApp.DAL.Repositories;
using WebApp.DAL.Repositories.Interfaces;
using WebApp.DTO;

namespace WebApp.BLL
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public bool CreateProduct(ProductRequestDTO product, ref string errorMessage)
        { 
            return _productRepository.CreateProduct(new Product(product), ref errorMessage);
        }

        public bool DeleteProduct(int id)
        {
            return _productRepository.DeleteProduct(id);
        }

        public bool DeleteProduct(ProductRequestDTO product)
        {
            return _productRepository.DeleteProduct(new Product(product));
        }

        public bool EditProduct(ProductRequestDTO product, ref string errorMessage)
        {
            return _productRepository.EditProduct(new Product(product), ref errorMessage);
        }

        public ProductResponseDTO GetProductById(int id)
        {
            Product product = _productRepository.GetProductById(id);

            return new ProductResponseDTO()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CreatedAt = product.CreatedAt,
                LastUpdated = product.LastUpdated
            };

        }

        public ICollection<ProductResponseDTO> GetProducts(int pagingSize, int skipAmount)
        {
            IEnumerable<Product> products = _productRepository.GetProducts(pagingSize, skipAmount);
            ICollection<ProductResponseDTO> productsDTO = new List<ProductResponseDTO>(); 

            foreach (Product product in products)
            {
                productsDTO.Add(new ProductResponseDTO()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    CreatedAt = product.CreatedAt,
                    LastUpdated = product.LastUpdated
                });
            }

            return productsDTO;
        }
    }
}