using Microsoft.AspNetCore.Mvc;
using WedMVCDemo.Models;

namespace WedMVCDemo.Controllers
{
    public class TestController : Controller
    {    
        public IActionResult Index()
        {
            int[] ints = { 1, 2, 3 };
            ViewData["userName"] = "User";
            ViewBag.userName = "Admin";
            ViewBag.numbers = ints;
            ViewData["MyName"] = "Ahmed";
           
            return View();
        }
        [Route("calculate/{num?}")]
        public int Calc(int num = 50)
        {
            return num;
        }
        public IActionResult ShowData()
        {
            List<TestClass> list = new List<TestClass>()
            {
                new TestClass() {Id = 1 , Name = "Name 1"},
                new TestClass() {Id = 2, Name = "Name 2"}
            };
            return View(list);
        }
    }
}
