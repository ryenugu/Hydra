using System.Linq;
using System.Net;
using System.Web.Mvc;
using Hydra.Models;
using PagedList;
using System.Data;
using Dapper.Contrib.Extensions;
using Hydra.Entities;

namespace Hydra.Controllers
{
    public class ProductsController : Controller
    {

        // GET: Employee/AddProduct
        public ActionResult AddProduct()
        {
            return View();
        }

        //Create a product
        [HttpPost]
        //used to To protect from overposting attacks more details see http://stackoverflow.com/documentation/asp.net-mvc/1997/html-antiforgerytoke
        [ValidateAntiForgeryToken]
        // This is the post request with forms data that will be bind the action, if in the data post request have enough information to build a Student instance that will be bind
        public ActionResult AddProduct(MpiHeader_Test product)
        {
            //var product = new MpiHeader_Test()
            //{
            //    NAME = "ManualName",
            //    CODE = "ManualCode"
            //};
            try
            {

                //Gets a value that indicates whether this instance received from the view is valid.
                if (ModelState.IsValid)
                {
                    var db = MpiConn._db;
                    // Adds to the context
                    db.Insert(product);
                    // Persist the data 

                    // Returns an HTTP 302 response to the browser, which causes the browser to make a GET request to the specified action, in this case the index action.
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            // view = default in this case Create and model = student
            return View(product);
        }
        public object Index(string searchParam, string sortOrder, string q, int page = 1, int pageSize = 25)
        {
            ViewBag.searchQuery = string.IsNullOrEmpty(q) ? "" : q;

            page = page > 0 ? page : 1;
            pageSize = pageSize > 0 ? pageSize : 25;

            ViewBag.CodeSortParam = sortOrder == "code" ? "code_desc" : "code";
            ViewBag.NameSortParam = sortOrder == "name" ? "name_desc" : "name";


            ViewBag.CurrentSort = sortOrder;


            var productreturns =
                from r in MpiRepo.GetAllReturns()
                group r by new { r.Code }
                into g
                select new
                {
                    cd = g.Key.Code,
                    RRD = g.Max(x => x.Rtndate),
                };
            var products = MpiRepo.GetProducts();


            var resultproducts = from r in productreturns
                                 join s in products on r.cd equals s.CODE
                                 select new MyHeader
                                 {
                                     Code = s.CODE,
                                     Name = s.NAME,
                                     HCAUniverse = s.HCAUNIVERSE,
                                     RRD = r.RRD,
                                     PBMID = s.PrimaryBMID
                                 };
            var pageNumber = page; // if no page was specified in the querystring, default to the first page (1)


            // will only contain 25 products max because of the pageSize
            switch (sortOrder)
            {
                case "name":
                    resultproducts = resultproducts.OrderBy(x => x.Name);
                    break;
                case "code":
                    resultproducts = resultproducts.OrderBy(x => x.Code);
                    break;
                case "name_desc":
                    resultproducts = resultproducts.OrderByDescending(x => x.Name);
                    break;
                case "code_desc":
                    resultproducts = resultproducts.OrderByDescending(x => x.Code);
                    break;
            }


            if (!string.IsNullOrEmpty(searchParam))
            {
                resultproducts = from t in resultproducts
                                 where
                                 t.Name.ToLower().Contains(searchParam.ToLower()) |
                                 t.Code.ToLower().Contains(searchParam.ToLower())
                                 select t;
            }
            var onePageOfProducts = resultproducts.ToPagedList(pageNumber, pageSize);
            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View();
        }


        //Opens a product showcase on clicking on product id,name etc
        public ActionResult Showcase(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var xcm = new ShowCaseViewModel();
            xcm.ReturnItems = xcm.GetProductReturns().Where(x => x.CODE == id);
            xcm.EquityItems = xcm.GetEquityChars().Where(x => x.CODE == id);


            return View(xcm);
        }
    }

    public class MyHeader
    {
        public string RRD { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string HCAUniverse { get; set; }
        public string PBMID { get; set; }
    }
}