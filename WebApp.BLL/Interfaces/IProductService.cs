using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DTO;

namespace WebApp.BLL.Interfaces
{
    public interface IProductService
    {
        public bool CreateProduct(ProductRequestDTO product, ref string errorMessage);
        public ProductResponseDTO GetProductById(int id);
        public ICollection<ProductResponseDTO> GetProducts(int pagingSize, int skipAmount);
        public bool EditProduct(ProductRequestDTO product, ref string errorMessage);
        public bool DeleteProduct(int id);
        public bool DeleteProduct(ProductRequestDTO product);
        public int GetCount();
    }
}
