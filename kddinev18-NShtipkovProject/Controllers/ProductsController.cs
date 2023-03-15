using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;
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
        public IActionResult Details(int id)
        {
            return View(_productService.GetProductById(id));
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductRequestDTO product)
        {
            if(_productService.CreateProduct(product))
            {
                return Index();
            }
            else
            {
                return null;
            }
        }




        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(ProductRequestDTO product)
        {
            if (_productService.EditProduct(product))
            {
                return View();
            }
            else
            {
                return null;
            }
        }




        [HttpPost]
        public IActionResult Delete(ProductRequestDTO product)
        {
            if (_productService.DeleteProduct(product))
            {
                return View();
            }
            else
            {
                return null;
            }
        }
    }
}
