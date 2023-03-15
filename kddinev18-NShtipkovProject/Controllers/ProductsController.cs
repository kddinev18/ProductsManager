using Microsoft.AspNetCore.Mvc;
using WebApp.BLL.Interfaces;
using WebApp.DTO;

namespace kddinev18_NShtipkovProject.Controllers
{
    public class ProductsController : Controller
    {
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index(int pageNumber = 1, int pagingSize = 10)
        {
            return View(_productService.GetProducts(pagingSize, (pageNumber-1)*pagingSize));
        }

        [HttpGet]
        public IActionResult DailedInformation()
        {
            return View();
        }



        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductRequestDTO product)
        {
            return View();
        }




        [HttpGet]
        public IActionResult EditProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditProduct(ProductRequestDTO product)
        {
            return View();
        }




        [HttpPost]
        public IActionResult DeleteProduct(ProductRequestDTO product)
        {
            return View();
        }
    }
}
