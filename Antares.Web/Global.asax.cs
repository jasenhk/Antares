﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using Antares.Web.Common;

namespace Antares.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SimpleMembershipConfig.Initialize();
            AuthConfig.RegisterAuth();
            AutoMapConfig.RegisterMappings();
            IUnityContainer container = UnityConfig.Initialise(new UnityConfigParameters
            {
                ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AntaresContext"].ConnectionString
                //Filters = GlobalFilters.Filters
            });
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters, container);
        }

        protected void Session_Start()
        {
            var session = SessionWrapper.Current;
        }
    }
}