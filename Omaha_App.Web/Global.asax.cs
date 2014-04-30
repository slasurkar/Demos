using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Omaha.Libraries.Membership.Application_Models;
using Omaha_App.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Omaha_App.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
			Database.SetInitializer<AppDbContext>(new AppDbInitializer());

			// Forces initialization of database on model changes.
			using (var context = new AppDbContext())
			{
				context.Database.Initialize(force: true);
			} 

			//UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new AppDbContext()));
        }
    }
}
