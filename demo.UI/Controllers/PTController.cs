using demo.BLL;
using demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace demo.UI.Controllers
{
    public class PTController : Controller
    {
        private readonly IBLL<ProductType> bll;

        public PTController(IBLL<ProductType> bll) {
            this.bll = bll;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add([FromForm]ProductType pt)
        {
           ViewBag.rs =  bll.Add(pt);

            return View();
        }
    }
}
