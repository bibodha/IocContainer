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
            Container cont = new Container();
            cont.Register<IRepository, Repository>();

            IRepository repo = cont.Resolve<IRepository>();
            repo.ShowMessage("hello");
        }
    }
}
