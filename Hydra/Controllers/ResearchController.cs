using Hydra.Models;
using System;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace Hydra.Controllers
{
    public class ResearchController : Controller
    {
        public ActionResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";

            return View();
        }

        [HttpPost]
        public JsonResult AutoComplete(string prefix)
        {
            var mgrs = MpiRepo.FillManagers();

            var locs = (from x in mgrs
                        where x.ManagerName.ToLower().StartsWith(prefix.ToLower())
                        select new
                        {
                            label = x.ManagerName,
                            val = x.ManagerId
                        }).ToList();
            return Json(locs);
        }

        [HttpPost]
        public ActionResult Index(string ManagerName, string ManagerId)
        {
            ViewBag.Message = "Manager Name: " + ManagerName + " ManagerId: " + ManagerId;
            return View();
        }
    }
}