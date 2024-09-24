using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WedMVCDemo.Entities.Models;
using WedMVCDemo.Interfaces;

namespace WedMVCDemo.Controllers
{
    public class StoresController : Controller
    {
        private IStoreRepository _storeRepository;
        public StoresController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        // GET: StoresController
        public async Task<ActionResult> Index()
        {
            var stores = await _storeRepository.GetAllStores();
            return View(stores);
        }

        // GET: StoresController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var store = await _storeRepository.GetStoreById(id);
            return View(store);
        }

        // GET: StoresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Store item)
        {
            try
            {
                await _storeRepository.AddStore(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoresController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var store = await _storeRepository.GetStoreById(id);
            return View(store);
        }

        // POST: StoresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Store item)
        {
            try
            {
                await _storeRepository.UpdateStore(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoresController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var store = await _storeRepository.GetStoreById(id);
            return View(store);
        }

        // POST: StoresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _storeRepository.DeleteStore(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
