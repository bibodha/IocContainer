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
            cont.Register<IRepository, Repository>();

            IRepository repo = cont.Resolve<IRepository>();
            repo.ShowMessage("hello");
        }
    }
}