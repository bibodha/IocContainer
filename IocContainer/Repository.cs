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
        void ShowMessage(string message);
    }

    //Class that implements the interface.
    public class Repository : IRepository
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
            Console.Read();
        }
    }
}
