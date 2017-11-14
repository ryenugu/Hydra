using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using Hydra.Entities;
using Dapper;

namespace Hydra.Controllers
{
    public class TestAController : Controller
    {
        private MCE db = new MCE();

        // GET: TestA
        public ActionResult Index()
        {
            return View();
        }

        // GET: TestA/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MpiHeader_Test mpiHeader_Test = db.MpiHeader_Test.Find(id);
            if (mpiHeader_Test == null)
            {
                return HttpNotFound();
            }
            return View(mpiHeader_Test);
        }

        // GET: TestA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CODE,AssetClassId,NAME,PROVIDER,HCAUNIVERSE,TICKER,CUSIP,MINIMUM,GROSSNET,EXPENSERATIO,PORTDATE,ASSETCLASS,OPENCLOSED,MGRBENCHMARK,HCABENCHMARK,ASSETS,AlternateMappingID,MapReturns,MapReturnsBeforeOrAfter,InceptionDate,FootNote,IsIndex,SubType,PrimaryBMID,StylusTemplate,ACID,StylusUnvID,StylusFundID")] MpiHeader_Test mpiHeader_Test)
        {
            var connection = Models.MpiConn._db;
            if (ModelState.IsValid)
            {
                string code = "Test123";
                string name = "abc";
                connection.Execute("insert [Mpiheader_Test](code, name) values(@code, @name)",
                    new { code, name });
            }

            return View();
        }

        // GET: TestA/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MpiHeader_Test mpiHeader_Test = db.MpiHeader_Test.Find(id);
            if (mpiHeader_Test == null)
            {
                return HttpNotFound();
            }
            return View(mpiHeader_Test);
        }

        // POST: TestA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CODE,AssetClassId,NAME,PROVIDER,HCAUNIVERSE,TICKER,CUSIP,MINIMUM,GROSSNET,EXPENSERATIO,PORTDATE,ASSETCLASS,OPENCLOSED,MGRBENCHMARK,HCABENCHMARK,ASSETS,AlternateMappingID,MapReturns,MapReturnsBeforeOrAfter,InceptionDate,FootNote,IsIndex,SubType,PrimaryBMID,StylusTemplate,ACID,StylusUnvID,StylusFundID")] MpiHeader_Test mpiHeader_Test)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mpiHeader_Test).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mpiHeader_Test);
        }

        // GET: TestA/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MpiHeader_Test mpiHeader_Test = db.MpiHeader_Test.Find(id);
            if (mpiHeader_Test == null)
            {
                return HttpNotFound();
            }
            return View(mpiHeader_Test);
        }

        // POST: TestA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MpiHeader_Test mpiHeader_Test = db.MpiHeader_Test.Find(id);
            db.MpiHeader_Test.Remove(mpiHeader_Test);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
