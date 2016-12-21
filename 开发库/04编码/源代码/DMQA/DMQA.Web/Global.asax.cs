using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DMQA.DataService.Service;
using DMQA.DataService.Tool;
using Ninject;
using Scuec.Infrastructure.Web;

namespace DMQA.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //额外的初始化工作
            Initialization();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);       
        }

        protected void Initialization()
        {
            //依赖注入
           // ControllerBuilder.Current.SetControllerFactory(new NinjectConfig(AddBindings));

            //初始化映射模型
            AutoMapperExtention.InitializationMapper();

            //初始化异常处理
            var webExceptionConfig = new WebExceptionConfig();
            webExceptionConfig.LoadConfig();
        }

        protected void AddBindings(IKernel ninjectKernel)
        {
            //todo:额外的注入代码
            ninjectKernel.Bind<IHomeService>().To<HomeService>();
        }
    }
}
