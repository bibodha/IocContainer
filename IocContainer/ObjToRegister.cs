using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainer
{
    //class to register stuff. holds the interface, the class as well as the lifestyle type
    //this way, I can create one dictionary to hold everything instead of dictionary of dictionaries.
    class ObjToRegister
    {
        public ObjToRegister(Type iFace, Type implemented, int lifestyle)
        {
            IFace = iFace;
            Implemented = implemented;
            LifeStyleType = lifestyle;
        }

        public Type IFace { get; set; }
        public Type Implemented { get; set; }
        public int LifeStyleType { get; set; }
    }
}
