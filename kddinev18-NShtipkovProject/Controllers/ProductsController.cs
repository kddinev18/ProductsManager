using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            TempData["PageNumber"] = pageNumber; 
            TempData["TotalPages"] = (int)Math.Ceiling((double)_productService.GetCount() / pageSize);

            return View(_productService.GetProducts(pageNumber, (pageNumber - 1) * pageSize));
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
            else
            {
                return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }




        [HttpPost]
        public IActionResult Delete(int id)
        {
            ProductResponseDTO product = _productService.GetProductById(id);
            if (_productService.DeleteProduct(new ProductRequestDTO(product)))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
