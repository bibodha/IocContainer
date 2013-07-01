using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer
{
    class ObjToRegister
    {
        public ObjToRegister(Type toResolve, Type actualType, LifestyleType lifestyle)
        {
            ToResolve = toResolve;
            ActualType = actualType;
            LifeStyleType = lifestyle;
        }

        public Type ToResolve { get; private set; }
        public Type ActualType { get; private set; }
        public LifestyleType LifeStyleType { get; private set; }
    }
}
