using System.Web.Mvc;

namespace Hydra.Controllers
{
    public class ResearchController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Notes()
        {
            return View();
        }

        public ActionResult ShowFile()
        {
            string path = @"C:\Users\Ravindar\Desktop\ASPMVC.pdf";


            return File(path, "application /pdf");
        }
    }
}