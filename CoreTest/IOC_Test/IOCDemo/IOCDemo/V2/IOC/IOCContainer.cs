using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCDemo.V2.IOC
{
    public class IOCContainer
    {
        private readonly Hashtable _registrations;

        public IOCContainer()
        {
            _registrations = new Hashtable();
        }

        public void RegisterTransient<TInterface, TImplementation>()
        {
            _registrations.Add(typeof(TInterface), typeof(TImplementation));
        }

        public TInterface Create<TInterface>()
        {
            var typeOfImpl = (Type)_registrations[typeof(TInterface)];
            if (typeOfImpl == null)
            {
                throw new ApplicationException($"Failed to resolve {typeof(TInterface).Name}");
            }
            return (TInterface)Activator.CreateInstance(typeOfImpl);
        }

        public T Resolve<T>()
        {
            var ctor = ((Type)_registrations[typeof(T)]).GetConstructors()[0];
            var dep = ctor.GetParameters()[0].ParameterType;
            var mi = typeof(IOCContainer).GetMethod("Create");
            var gm = mi.MakeGenericMethod(dep);
            return (T)ctor.Invoke(new object[] { gm.Invoke(this, null) });
        }
    }
}
