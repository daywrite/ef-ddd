using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBear
{
    public static class Conv
    {
        #region 通用转换

        /// <summary>
        /// 转换为目标元素
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="data">数据</param>
        public static T To<T>(object data)
        {
            if (data == null)
                return default(T);
            if (data is string && string.IsNullOrWhiteSpace(data.ToString()))
                return default(T);
            Type type = Sys.GetType<T>();
            try
            {
                if (type.Name.ToLower() == "guid")
                    return (T)(object)new Guid(data.ToString());
                if (data is IConvertible)
                    return (T)Convert.ChangeType(data, type);
                return (T)data;
            }
            catch
            {
                return default(T);
            }
        }

        #endregion
    }
}
