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
        public string ShowMessage(string message)
        {
            string ret = message;
            return ret;
        }
    }
}
