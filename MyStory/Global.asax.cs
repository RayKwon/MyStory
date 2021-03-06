﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MyStory.Models;
using System.Data.Entity;
using MyStory.Infrastructure.AutoMapper;
using MyStory.Infrastructure;

namespace MyStory
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Tag",
                "tags/{tag}",
                new { controller = "Tag", action = "Index" }
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id=UrlParameter.Optional} // Parameter defaults
            );

            
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            DependencyResolver.SetResolver(new NinjectDependencyResolver());

            // create mapping rule
            //IMapper mapper = new PostMapper();
            //mapper.Execute();
            CreateAutoMapping();

        }

        private void CreateAutoMapping()
        {
            NinjectDependencyResolver resolver = new NinjectDependencyResolver();

            var mappers = resolver.GetServices<IMapper>();

            foreach (var mapper in mappers)
            {
                mapper.Execute();
            }
        }
    }
}