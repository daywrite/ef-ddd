using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OBear
{
    /// <summary>
    /// 反射操作
    /// </summary>
    public static class Reflection
    {
        #region CreateInstance(动态创建实例)

        /// <summary>
        /// 动态创建实例
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="className">类名，包括命名空间,如果类型不处于当前执行程序集中，需要包含程序集名，范例：Test.Core.Test2,Test.Core</param>
        /// <param name="parameters">传递给构造函数的参数</param>        
        public static T CreateInstance<T>(string className, params object[] parameters)
        {
            Type type = Type.GetType(className) ?? Assembly.GetCallingAssembly().GetType(className);
            return CreateInstance<T>(type, parameters);
        }

        /// <summary>
        /// 动态创建实例
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="type">类型</param>
        /// <param name="parameters">传递给构造函数的参数</param>        
        public static T CreateInstance<T>(Type type, params object[] parameters)
        {
            return Conv.To<T>(Activator.CreateInstance(type, parameters));
        }

        #endregion

        #region GetByInterface(获取实现了接口的所有具体类型)

        /// <summary>
        /// 获取实现了接口的所有具体类型
        /// </summary>
        /// <typeparam name="T">接口类型</typeparam>
        /// <param name="assembly">在该程序集中查找</param>
        public static List<T> GetByInterface<T>(Assembly assembly)
        {
            var typeInterface = typeof(T);
            return assembly.GetTypes()
                .Where(t => typeInterface.IsAssignableFrom(t) && t != typeInterface && t.IsAbstract == false)
                .Select(t => CreateInstance<T>(t)).ToList();
        }

        #endregion
    }
}
