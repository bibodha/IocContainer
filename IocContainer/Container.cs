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
        //Dictionary of registered objects
        //keys are the type that were registered, values are the instances.
        private IDictionary<ObjToRegister, object> _registered = new Dictionary<ObjToRegister, object>();
        /// <summary>
        /// Register types
        /// </summary>
        /// <typeparam name="T1">Interface</typeparam>
        /// <typeparam name="T2">Implementing class</typeparam>
        public bool Register<T1, T2>()
        {
            bool ret = false;
            //calls the overloaded method with transient as lifestyleType. Makes it default.
            ret = Register<T1, T2>(LifestyleType.Transient);
            return ret;
        }
        /// <summary>
        /// Register types
        /// </summary>
        /// <typeparam name="T1">Interface</typeparam>
        /// <typeparam name="T2">Implementing class</typeparam>
        /// <param name="lifestyleType">Lifestyle type(Transient or Singleton)</param>
        public bool Register<T1, T2>(int lifestyleType)
        {
            int currentCount = _registered.Count;
            bool ret = false;
            //creates a new custom object to put into the list.
            ObjToRegister obj = new ObjToRegister(typeof(T1), typeof(T2), lifestyleType);
            _registered.Add(obj, null);
            if (_registered.Count > currentCount)
                ret = true;
            else
                ret = false;
            return ret;
        }

        /// <summary>
        /// Resolve type
        /// </summary>
        /// <typeparam name="T">Class to resolve.</typeparam>
        /// <returns>Resolved object from registered types.</returns>
        public T Resolve<T>()
        {
            //calls the overloaded method.
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type T)
        {
            object ret = null;
            //first find the registered object in the list.
            foreach(ObjToRegister o in _registered.Keys)
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

        private object GetInstance(ObjToRegister obj)
        {
            object ret = null;
            //create a new instance is there is no instance.
            //if the lifestyle type is transient, create a new instance everytime
            //if the lifestyle is singleton, return the same instance.
            if (obj.LifeStyleType == LifestyleType.Transient || _registered[obj] == null)
            {
                ConstructorInfo consInfo = obj.Implemented.GetConstructors()[0];
                ParameterInfo[] consParams = consInfo.GetParameters();
                //if there are no params, just return a new instance.
                //if there are params, resolve the param types, add it to the constructor and return.
                if (consParams.Length < 1)
                {
                    ret = Activator.CreateInstance(obj.Implemented);
                }
                else
                {
                    List<object> paramList = new List<object>();
                    foreach (ParameterInfo p in consParams)
                    {
                        paramList.Add(Resolve(p.ParameterType));
                    }
                    ret = consInfo.Invoke(paramList.ToArray());
                }
                _registered[obj] = ret;
            }
            else
            {
                ret = _registered[obj];
            }
            return ret;
        }
    }
}