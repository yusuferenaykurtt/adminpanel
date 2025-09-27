using Demo_Product.BusinessLayer.Concrete;
using Demo_Product.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductManager _productManager;

        public ProductController(ProductManager productManager)
        {
            _productManager = productManager;
        }

        public IActionResult Index()
        {
            var values = _productManager.TGetList();
            return View(values);
        }

        [HttpPost]
        public IActionResult AddProduct(Product P)
        {
            var validationRules = new BusinessLayer.FluentValidation.ProductValidator();
            ValidationResult validationResult = validationRules.Validate(P);

            if (validationResult.IsValid)
            {
                _productManager.TInsert(P);
                return RedirectToAction("Index");
            }

            foreach (var item in validationResult.Errors)
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

            return View();
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        public IActionResult DeleteProduct(int id)
        {
            var values = _productManager.TGetById(id);
            _productManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var values = _productManager.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            _productManager.TUpdate(product);
            return RedirectToAction("Index");
        }
    }
}
