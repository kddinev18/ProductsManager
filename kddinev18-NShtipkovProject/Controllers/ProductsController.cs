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
            string errorMesage = "";
            if(!_productService.CreateProduct(product, ref errorMesage))
            {
                ModelState.AddModelError(string.Empty, errorMesage);
            }
            return Create();
        }




        [HttpGet]
        public IActionResult Edit(int id)
        {
            ProductResponseDTO product = _productService.GetProductById(id);
            if(product is null)  
                return RedirectToAction("Error", "Index"); 

            return View(new ProductRequestDTO(product));
        }

        [HttpPost]
        public IActionResult Edit(ProductRequestDTO product)
        {
            string errorMesage = "";
            if (!_productService.EditProduct(product, ref errorMesage))
            {
                ModelState.AddModelError(string.Empty, errorMesage);
                return Edit(product.Id.Value);
            }
            return Index();
        }




        [HttpPost]
        public IActionResult Delete(ProductRequestDTO product)
        {
            if (_productService.DeleteProduct(product))
            {
                return Index();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
