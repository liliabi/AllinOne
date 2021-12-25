using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllinOne
{
    public class CustomHandleErrorAttribute: HandleErrorAttribute
    {
        //private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public override void OnException(ExceptionContext filterContext)
        {
            //1、获取异常对象
            Exception ex = filterContext.Exception;

            //2、获取请求的类名和方法名
            string strController = filterContext.RouteData.Values["controller"].ToString();
            string strAction = filterContext.RouteData.Values["action"].ToString();

            //3、记录异常日志
            string errMsg = String.Format("异常信息：{0}；", ex.ToString());
            //logger.Error(errMsg);

            //4、重定向友好页面
            filterContext.Result = new RedirectResult("/Error/Page500?msg=" + System.Web.HttpUtility.UrlEncode(filterContext.Exception.Message));

            //5、标记异常已经处理完毕
            filterContext.ExceptionHandled = true;

            base.OnException(filterContext);
        }
    }
}