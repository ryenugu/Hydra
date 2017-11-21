using Hydra.Entities;
using Hydra.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Hydra.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Hydra is Highlands Internal Website.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact research@highlandusa.net with questions";

            return View();
        }

        public ActionResult QuickSearch(string term)
        {
            var products = GetMyProducts(term).Select(a => new { label = a.NAME, category = a.HCAUNIVERSE });
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<MpiHeader_Test> GetMyProducts(string searchString)
        {
            var pds = MpiRepo.GetProducts();
            return from t in pds
                   where
                   t.NAME.ToLower().Contains(searchString.ToLower())
                   orderby t.HCAUNIVERSE
                   select t;
        }
    }
}