using AllinOne.Business;
using AllinOne.Entity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace AllinOne.Web.Controllers
{
    [CustomHandleErrorAttribute]
    public class WinProviderListsController : Controller
    {
        private BusiWinProviderLists busiWinProviderLists = new BusiWinProviderLists();

        #region CURD
        // GET: WinProviderLists
        public ActionResult Index()
        {
            var WinProviderLists =  busiWinProviderLists.BusiGetAllProviderInfo();
            return View(WinProviderLists);
        }

        // GET: WinProviderLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var WinProviderLists = busiWinProviderLists.BusiGetOneProviderInfo(id);
            if (WinProviderLists == null)
            {
                return HttpNotFound();
            }
            return View(WinProviderLists);
        }

        // GET: WinProviderLists/Create
        public ActionResult Create()
        {
            List<SelectListItem> selects = new List<SelectListItem>
            {
                new SelectListItem{Text="是",Value="Y" },
                new SelectListItem{Text="否",Value="N"}
            };
            ViewData["FieldsReLoad"] = new SelectList(selects, "Value", "Text", "Y");
            return View();
        }

        // POST: WinProviderLists/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Win32Provider,Win32Link,FieldsReLoad,Xpath,Comment")] WinProviderList winProviderList)
        {
            if (ModelState.IsValid)
            {
                busiWinProviderLists.BusiInsertProviderInfo(winProviderList);
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
            var winProviderList = busiWinProviderLists.BusiGetOneProviderInfo(id);
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
        public ActionResult Edit([Bind(Include = "ID,Win32Provider,Win32Link,FieldsReLoad,Xpath,Comment")] WinProviderList winProviderList)
        {
            if (ModelState.IsValid)
            {
                    busiWinProviderLists.BusiUpdateProviderInfo(winProviderList);
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
            var winProviderList = busiWinProviderLists.BusiGetOneProviderInfo(id);
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
            busiWinProviderLists.BusiDeleteProviderInfo(id);
            return RedirectToAction("Index");
        }
        #endregion

        public ActionResult GetProviderFields(int id, string Link)
        {
            RequestOptions options = new RequestOptions();
            options.Uri = new Uri(Link);
            options.winProviderList = busiWinProviderLists.BusiGetOneProviderInfo(id);
            Dictionary<string, string> dic = busiWinProviderLists.InitSpider(options);
            busiWinProviderLists.BusiInsertProviderStructure(id, dic);
            return RedirectToAction("Index");
        }
    }
}
