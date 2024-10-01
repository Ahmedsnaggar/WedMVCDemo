using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WedMVCDemo.Entities.Models;
using WedMVCDemo.Interfaces;
using WedMVCDemo.Models;

namespace WedMVCDemo.Controllers
{
    [Authorize(Roles ="AdminsRole, UsersRole")]
    public class CategoriesController : Controller
    {
        private IGenericRepository<Category> _categoryRepository;
        public CategoriesController(IGenericRepository<Category> categoryRepositor)
        {
            _categoryRepository = categoryRepositor;
        }

        // GET: CategoriesController
        public async Task<ActionResult> Index()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return View(categories);
        }

        // GET: CategoriesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var catrgory = await _categoryRepository.GetByIdAsync(id);
            return View(catrgory);
        }
        [Authorize(Roles = "AdminsRole")]
        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "AdminsRole")]
        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Category item)
        {
            try
            {
                var isExists= _categoryRepository.GetAllAsync().Result.Any(c=> c.CategoryName == item.CategoryName);
                if (isExists)
                {
                    ViewBag.Errors = "Category Alreade exists";
                    return View();
                }
             await    _categoryRepository.AddItemAsync(item);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ViewBag.Errors = e.Message;
                return View();
            }
        }
        [Authorize(Roles = "AdminsRole")]
        // GET: CategoriesController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return View(category);
        }
        [Authorize(Roles = "AdminsRole")]
        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Category item)
        {
            try
            {
                //var category = _db.Categories.Find(id);
                //category.CategoryName = item.CategoryName;
                //category.CategoryDescription = item.CategoryDescription;
               await  _categoryRepository.UpdateItemAsync(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "AdminsRole")]
        // GET: CategoriesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return View(category);
        }
        [Authorize(Roles = "AdminsRole")]
        // POST: CategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
               await _categoryRepository.DeleteItemAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
