using System.Web;
using System.Web.Mvc;

namespace Bulding_Vistor_Management
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
