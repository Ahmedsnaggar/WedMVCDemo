using Microsoft.AspNetCore.Mvc;

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
    }
}
