using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DMQA.Infrastructure.Ioc;
using Ninject;

namespace DMQA.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            ControllerBuilder.Current.SetControllerFactory(new NinjectConfig(AddBindings));

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);       
        }

        protected void AddBindings(IKernel ninjectKernel)
        {
            //todo:额外的注入代码
            //ninjectKernel.Bind<IAdapter>().To<Adapter>();
        }
    }
}
