using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IOCDemo.V1.Factory
{
    public class DefaultIOCFactory: IIOCFactory
    {

        private Dictionary<string, Type> _typeDict = new Dictionary<string, Type>();
        private Dictionary<string, object> _objectDict = new Dictionary<string, object>();

        public DefaultIOCFactory(string assemblyString)
        {
            InitIOC(assemblyString);
        }

        private void InitIOC(string assemblyString)
        {
            var assembly = Assembly.Load(assemblyString);
            Type[] types = assembly.GetTypes().Where(t => t.FullName.Contains("Models")).ToArray();

            //1 缓存所有type
            foreach (var type in types)
            {
                _typeDict.Add(type.FullName, type);
            }

            //2 初始化所有对象
            foreach (var type in types)
            {
                var instance = CreateInstance(type);
                _objectDict.Add(type.FullName,instance);
            }
        }

        private object CreateInstance(Type type)
        {
            //构造参数初始化
            var constructorInfo = type.GetConstructors()[0];
            ParameterInfo[] parameterInfos = constructorInfo.GetParameters();

            object[] paraObjects = new object[parameterInfos.Length];
            for (int i = 0; i < parameterInfos.Length; i++)
            {
                paraObjects[i] = CreateInstance(parameterInfos[i].ParameterType);
            }

            return Activator.CreateInstance(type, paraObjects);
        }

        public object GetInstent(string type)
        {
            var key = _objectDict.Keys.Where(k => k.Contains(type)).FirstOrDefault();
            if (!string.IsNullOrEmpty(key))
            {
                return _objectDict[key];
            }
            return null;
        }
    }
}
