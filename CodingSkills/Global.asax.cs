using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using CodingSkills.Repositories;
using CodingSkills.Services;
using Microsoft.AspNet.WebFormsDependencyInjection.Unity;
using Unity;

namespace CodingSkills
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Config DI
            CreateContainer();
            
            //Config Log4net
            log4net.Config.XmlConfigurator.Configure();
        }

        protected virtual void CreateContainer()
        { 
            var container = this.AddUnity();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IDataRepository, ExcelDataRepository>();
        }
    }
}