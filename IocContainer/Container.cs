using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer
{
    public class Container
    {
        private readonly List<ObjToRegister> _registered = new List<ObjToRegister>();

        public void Register<T1, T2>()
        {
            Register<T1, T2>(LifestyleType.Transient);
        }
        public void Register<T1, T2>(LifestyleType lifestyleType)
        {
            _registered.Add(new ObjToRegister(typeof(T1), typeof(T2), lifestyleType));
        }
    }
}
