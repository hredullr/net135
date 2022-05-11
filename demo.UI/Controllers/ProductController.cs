using Microsoft.AspNetCore.Mvc;

namespace demo.UI.Controllers
{
    using demo.BLL;
    using demo.Models;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class ProductController : Controller
    {
        private readonly IBLL<Products> bll;
        private readonly IBLL<ProductType> bll2;

        public ProductController(IBLL<Products> bll, IBLL<ProductType> bll2) {
            this.bll = bll;
            this.bll2 = bll2;
        }

        

        [HttpGet]
        public IActionResult Add()
        {

            ViewBag.PT = new SelectList(bll2.Select( pt=> 1==1 ),"PTID","PTName"  );

            return View();
        }

        [HttpPost]
        public IActionResult Add([FromForm]Products p)
        {
            ViewBag.PT = new SelectList(bll2.Select(pt => 1 == 1), "PTID", "PTName");


            ViewBag.rs = bll.Add(p);
            return View();
        }
    }
}
