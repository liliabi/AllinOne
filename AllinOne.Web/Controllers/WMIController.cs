using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllinOne.Business;
using AllinOne.Entity;

namespace AllinOne.Web.Controllers
{
    public class WMIController : Controller
    {
        private AllinOneModel db = new AllinOneModel();
        private WMIManager wmiManager = new WMIManager();
        // GET: WMI
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return View();
            }


        }
        [CustomHandleErrorAttribute]
        public ActionResult List()
        {
            try
            {
                var wmi = wmiManager.GetAll();
                return View(wmi);
            }
            catch (Exception)
            {
                throw;
                //return View();
            }


        }
        // GET: WMI/Details/5
        public ActionResult Details(string sguid)
        {
            var wmi = db.WmiServerList.Where(f => f.SGUID == sguid).FirstOrDefault();
            return View(wmi);
        }

        // GET: WMI/Create
        [CustomHandleErrorAttribute]
        public ActionResult Create()
        {
            return View();
        }

        // POST: WMI/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServerName,ServerIP,ServerDesc,UserId,UserPwd,ServerType,Creator")] WmiServerList wmiServerList)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    wmiServerList.SGUID = Guid.NewGuid().ToString();
                    wmiServerList.CreateTime = DateTime.Now;

                    db.WmiServerList.Add(wmiServerList);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                // TODO: Add insert logic here

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: WMI/Edit/5
        public ActionResult Edit(string sguid)
        {
            if (!string.IsNullOrWhiteSpace(sguid))
            {
                var wmi = db.WmiServerList.Where(f => f.SGUID == sguid).FirstOrDefault();
                if (wmi != null)
                {
                    return View(wmi);
                }
            }
            return RedirectToAction("Index");
        }

        // POST: WMI/Edit/5
        [HttpPost]
        public ActionResult Edit(string sguid, WmiServerList wmiServerList)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var wmi = db.WmiServerList.Where(f => f.SGUID == sguid).FirstOrDefault();
                    if (wmi != null)
                    {
                        wmi.ServerIP = wmiServerList.ServerIP;
                        wmi.ServerDesc = wmiServerList.ServerDesc;
                        wmi.ServerType = wmiServerList.ServerType;
                        wmi.Updator = wmiServerList.Updator;
                        wmi.UpdateTime = DateTime.Now;
                        wmi.UserId = wmiServerList.UserId;
                        wmi.UserPwd = wmiServerList.UserPwd;
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WMI/Delete/5
        public ActionResult Delete(string sguid)
        {
            var wmi = db.WmiServerList.Where(f => f.SGUID == sguid).FirstOrDefault();
            return View(wmi);
        }

        // POST: WMI/Delete/5
        [HttpPost]
        public ActionResult Delete(string sguid, WmiServerList wmiServerList)
        {
            try
            {
                // TODO: Add delete logic here
                var wmi = db.WmiServerList.Where(f => f.SGUID == sguid).FirstOrDefault();
                if (wmi != null)
                {
                    db.WmiServerList.Remove(wmi);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
