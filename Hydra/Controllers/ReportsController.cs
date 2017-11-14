using Dapper.Contrib.Extensions;
using System.Web.Mvc;

namespace Hydra.Controllers
{
    public class ReportsController : Controller
    {
        public ActionResult Index()
        {
            var connection = Models.MpiRepo.TestDapper();
            ViewBag.ProductName = connection;
            return View();
        }
    }
}