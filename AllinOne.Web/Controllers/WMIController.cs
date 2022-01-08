using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Web;
using System.Web.Mvc;
using AllinOne.Business;
using AllinOne.Entity;
using AllinOne.Entity.ViewModel;

namespace AllinOne.Web.Controllers
{
    [CustomHandleErrorAttribute]
    public class WMIController : Controller
    {
        private AllinOneModel db = new AllinOneModel();
        private WMIManager wmiManager = new WMIManager();
        // GET: WMI
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ping(string ServerIP)
        {
            RESTfulResult res = WMIManager.TryPing(ServerIP);
            if (res.Succeeded)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format("答复主机地址:{0};    ", ((PingReply)res.Data).Address.ToString()));
                sb.Append(string.Format("往返时间:{0};  ", ((PingReply)res.Data).RoundtripTime.ToString()));
                sb.Append(string.Format("生存时间(TTL):{0}; ", ((PingReply)res.Data).Options.Ttl.ToString()));
                sb.Append(string.Format("是否控制数据包分段:{0}; ", ((PingReply)res.Data).Options.DontFragment.ToString()));
                sb.Append(string.Format("缓冲区大小:{0}; ", ((PingReply)res.Data).Buffer.Length));
                ViewBag.result = ServerIP + " 已Ping通!";
                ViewBag.message = sb;
            }
            else
            {
                ViewBag.result = ServerIP + " 无法Ping通!";
                ViewBag.message = "请重试！";
            }
            return View(res);
        }

        public ActionResult GetServiceInfo(string sguid)
        {
            RESTfulResult Result = wmiManager.GetServiceInfo(sguid);
            ViewBag.result = Result.Message;
            return View();
        }


        #region CURD Server List
        [CustomHandleErrorAttribute]
        public ActionResult List()
        {
            var wmi = wmiManager.GetAll();
            return View(wmi);
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
            return RedirectToAction("List");
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
            // TODO: Add delete logic here
            var wmi = db.WmiServerList.Where(f => f.SGUID == sguid).FirstOrDefault();
            if (wmi != null)
            {
                db.WmiServerList.Remove(wmi);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
    #endregion
}
