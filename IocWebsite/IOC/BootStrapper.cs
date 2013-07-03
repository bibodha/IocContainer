using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IocContainer;
using IocWebsite.Controllers;

namespace IocWebsite.IOC
{
    public static class BootStrapper
    {
        public static void Configure(Container container)
        {
            container.Register<AccountController, AccountController>();
            container.Register<HomeController, HomeController>();
        }
    }
}
