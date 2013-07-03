using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Step 1: create a container, register, resolve
            //Step 2: call the method.
            //Step 3: profit. 
            Container cont = new Container();
            cont.Register<IRepository, Repository>(LifestyleType.Singleton);

            IRepository repo1 = cont.Resolve<IRepository>();
            IRepository repo2 = cont.Resolve<IRepository>();
            bool ret = repo1 == repo2;
            repo1.ShowMessage("hello");
        }
    }
}