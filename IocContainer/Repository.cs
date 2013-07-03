using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer
{
    //Interface
    public interface IRepository
    {
        string ShowMessage(string message);
    }

    //Class that implements the interface.
    public class Repository : IRepository
    {
        IServiceProvider _s = null;
        public Repository(IServiceProvider s)
        {
            _s = s;
        }
        public string ShowMessage(string message)
        {
            string ret = message;
            return ret;
        }
    }

    public class Service : IServiceProvider
    {

        public object GetService(Type serviceType)
        {
            return null;
        }
    }
}
