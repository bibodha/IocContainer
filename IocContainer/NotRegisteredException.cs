using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IocContainer
{
    //Simple exception class.
    public class NotRegisteredException : Exception
    {
        public NotRegisteredException()
        {
        }

        public NotRegisteredException(string message) : base(message)
        {
        }

        public NotRegisteredException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
