using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using grfcTest.DataLayer;
using grfcTest.DataLayer.Entities;
using grfcTest.Infrastructure.Windsor;

namespace grfcTest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new WindsorContainer();

            container.Install(new WebMvcInstaller(typeof(MvcApplication).Assembly))
                .Install(new RepositoryInstaller(typeof(IgrfcEntity)));


            DependencyResolver.SetResolver(serviceType => container.Kernel.HasComponent(serviceType) ? container.Resolve(serviceType) : null,
                serviceType => container.ResolveAll(serviceType).Cast<object>());
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));
            Database.SetInitializer<grfcDbContext>(null);
        }
    }
}
