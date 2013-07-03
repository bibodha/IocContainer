using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IocContainer;
using System.Web.Routing;

namespace IocWebsite.IOC
{
    //this will set this controllerfactory as the one that gets called when a controller
    //needs to be created.
    public class IOCControllerFactory : DefaultControllerFactory
    {
        private Container _container;

        public IOCControllerFactory(Container container)
        {
            _container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return (Controller)_container.Resolve(controllerType);
        }
    }
}
