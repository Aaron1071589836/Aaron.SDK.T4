using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Aaron.SDK.T4.Utils
{
    public class EntityHelper
    {
        public static List<Type> GetEntities(string modelFile, string baseTypeName)
        {
            //加载实体程序集
            byte[] fileData = File.ReadAllBytes(modelFile);
            Assembly assembly = Assembly.Load(fileData);
            var types = assembly.GetTypes();

            IEnumerable<Type> modelTypes = types.Where(m => m.BaseType != null && m.BaseType.Name == baseTypeName && !m.IsAbstract);
            return modelTypes.ToList();
        }
    }
}
