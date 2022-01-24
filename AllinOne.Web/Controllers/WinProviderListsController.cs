using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AllinOne.Business.WebSpider;
using AllinOne.Entity;

namespace AllinOne.Web.Controllers
{
    [CustomHandleErrorAttribute]
    public class WinProviderListsController : Controller
    {
        private AllinOneModel db = new AllinOneModel();

        #region CURD
        // GET: WinProviderLists
        public ActionResult Index()
        {
            return View(db.WinProviderList.ToList());
        }

        // GET: WinProviderLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WinProviderList winProviderList = db.WinProviderList.Find(id);
            if (winProviderList == null)
            {
                return HttpNotFound();
            }
            return View(winProviderList);
        }

        // GET: WinProviderLists/Create
        public ActionResult Create()
        {
            List<SelectListItem> selects = new List<SelectListItem>
            {
                new SelectListItem{Text="是",Value="Y" },
                new SelectListItem{Text="否",Value="N"}
            };
            ViewData["FieldsReLoad"] = new SelectList(selects, "Value", "Text", "N");
            return View();
        }

        // POST: WinProviderLists/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Win32Provider,Win32Link,FieldsReLoad,Comment")] WinProviderList winProviderList)
        {
            if (ModelState.IsValid)
            {
                db.WinProviderList.Add(winProviderList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(winProviderList);
        }

        // GET: WinProviderLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WinProviderList winProviderList = db.WinProviderList.Find(id);
            if (winProviderList == null)
            {
                return HttpNotFound();
            }
            return View(winProviderList);
        }

        // POST: WinProviderLists/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Win32Provider,Win32Link,FieldsReLoad,Comment")] WinProviderList winProviderList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(winProviderList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(winProviderList);
        }

        // GET: WinProviderLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WinProviderList winProviderList = db.WinProviderList.Find(id);
            if (winProviderList == null)
            {
                return HttpNotFound();
            }
            return View(winProviderList);
        }

        // POST: WinProviderLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WinProviderList winProviderList = db.WinProviderList.Find(id);
            db.WinProviderList.Remove(winProviderList);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        public ActionResult GetProviderFields(int id, string Link)
        {
            CreateSpider spider = new CreateSpider();
            RequestOptions options = new RequestOptions();
            options.Uri = new Uri(Link);
            Dictionary<string, string> dic = spider.InitSpider(options);
            spider.InsertToDb(id, dic);
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
