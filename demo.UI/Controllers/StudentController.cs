using Microsoft.AspNetCore.Mvc;

namespace demo.UI.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Eidt(int id)
        {
            return View();
        }
    }
}
