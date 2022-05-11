using Microsoft.AspNetCore.Mvc;

namespace demo.UI.Controllers
{
    public class StudentController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
