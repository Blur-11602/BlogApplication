using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;

namespace BlogApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IDbConnectionFactory DbFactory;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DbFactory = new OrmLiteConnectionFactory(
                ConfigurationManager.ConnectionStrings["BlogApplication"].ConnectionString,
                new SqlServer2012OrmLiteDialectProvider()
            );

        }
    }
}
