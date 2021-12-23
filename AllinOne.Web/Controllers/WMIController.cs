using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllinOne.Entity;

namespace AllinOne.Web.Controllers
{
    public class WMIController : Controller
    {
        // GET: WMI
        public ActionResult Index()
        {
            using (AllinOneModel db = new AllinOneModel())
            {
               var wmi =  db.WmiServerList.ToList();
            }
                return View();
        }

        // GET: WMI/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WMI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WMI/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WMI/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WMI/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WMI/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WMI/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
