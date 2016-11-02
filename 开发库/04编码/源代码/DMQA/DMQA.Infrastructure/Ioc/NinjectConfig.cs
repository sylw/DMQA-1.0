using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ninject;
using System.Web.Routing;

namespace DMQA.Infrastructure.Ioc
{
    public class NinjectConfig : DefaultControllerFactory
    {
        private readonly IKernel _ninjectKernel;

        public NinjectConfig(Action<IKernel> addBindings)
        {
            _ninjectKernel = new StandardKernel();
            addBindings(_ninjectKernel);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_ninjectKernel.Get(controllerType);
        }
    }
}
