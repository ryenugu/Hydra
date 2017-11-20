using Hydra.Models;
using System.Web.Mvc;

namespace Hydra.Controllers
{
    public class ResearchController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(string Prefix)
        {
            var elist = MpiRepo.FillManagers(Prefix);
            return Json(elist);
        }
    }
}