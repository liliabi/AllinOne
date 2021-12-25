using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllinOne.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Page500(string msg)
        {

            ViewBag.msg = msg;
            
            return View();
        }
    }
}