using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WedMVCDemo.Entities.Models;
using WedMVCDemo.Interfaces;
using WedMVCDemo.Models;

namespace WedMVCDemo.Controllers
{
    public class ProductsController : Controller
    {
        private IGenericRepository<Product> _productRepository;
        private IGenericRepository<Category> _categoryRepository;
        public ProductsController(IGenericRepository<Product> productRepository, IGenericRepository<Category> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        // GET: ProductsController
        public async Task<ActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync(incules: new[] { "category"});
            return View("ProductsList", products);
        }

        // GET: ProductsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return View("ProductDetails", product);
        }

        // GET: ProductsController/Create
        public async Task<ActionResult> Create()
        {
            //ViewBag.categoriesList = await _categoryRepository.GetAllAsync();
            var product = new Product();
            product.categoriesList = _categoryRepository.GetAllAsync().Result.ToList();
            return View("CreateProduct", product);
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product item)
        {
            try
            {
               await  _productRepository.AddItemAsync(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("CreateProduct");
            }
        }

        // GET: ProductsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            product.categoriesList = _categoryRepository.GetAllAsync().Result.ToList();
            return View("EditProduct", product);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Product item)
        {
            try
            {
                await _productRepository.UpdateItemAsync(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("EditProduct");
            }
        }

        // GET: ProductsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return View("DeleteProduct", product);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _productRepository.DeleteItemAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("DeleteProduct");
            }
        }
    }
}
