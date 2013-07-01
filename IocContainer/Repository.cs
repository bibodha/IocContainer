using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer
{
    public interface IRepository
    {
        void ShowMessage(string message);
    }

    public class Repository : IRepository
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
