using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace IocContainer
{
    public class Container
    {
        //List of registered objects
        private readonly List<ObjToRegister> _registered = new List<ObjToRegister>();

        public void Register<T1, T2>()
        {
            //calls the overloaded method with transient as lifestyleType. Makes it default.
            Register<T1, T2>(LifestyleType.Transient);
        }
        public void Register<T1, T2>(LifestyleType lifestyleType)
        {
            //creates a new custom object to put into the list.
            _registered.Add(new ObjToRegister(typeof(T1), typeof(T2), lifestyleType));
        }

        public T Resolve<T>()
        {
            //calls the overloaded method.
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type T)
        {
            object ret = null;
            //first find the registered object in the list.
            foreach(ObjToRegister o in _registered)
            {
                if (o.IFace == T)
                {
                    //if the type of T is registered, get the instance of it
                    //getinstance should figure out how to return based on lifestyle type.
                    ret = GetInstance(o);
                    break;
                }
            }
            //if ret is null, that means it was not registered.
            if (ret == null)
            {
                throw new NotRegisteredException("Register \"" + T + "\" before resolving.");
            }

            return ret;
        }

        private object GetInstance(ObjToRegister o)
        {
            object ret = null;
            //if lifestyle is transient, create a new instance
            //else return what you got.
            if (o.LifeStyleType == LifestyleType.Transient)
            {
                ConstructorInfo consInfo = o.Implemented.GetConstructors()[0];
                ParameterInfo[] consParams = consInfo.GetParameters();
                //if there are no params, just return a new instance.
                //if there are params, resolve the param types, add it to the constructor and return.
                if (consParams.Length < 1)
                {
                    ret = Activator.CreateInstance(o.Implemented);
                }
                else
                {
                    List<object> param = new List<object>();
                    foreach (ParameterInfo p in consParams)
                    {
                        param.Add(Resolve(p.ParameterType));
                    }
                    ret = consInfo.Invoke(param.ToArray());
                }
            }
            else
            {
                ret = o.Implemented;
            }
            return ret;
        }
    }
}
