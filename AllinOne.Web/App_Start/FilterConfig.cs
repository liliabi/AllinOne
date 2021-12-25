using System.Web;
using System.Web.Mvc;

namespace AllinOne.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomHandleErrorAttribute(), 1);
            filters.Add(new HandleErrorAttribute(), 2);

        }
    }
}
