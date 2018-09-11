using System.Reflection;

namespace Coldairarrow.Util
{
    /// <summary>
    /// 拓展类
    /// </summary>
    public static partial class Extention
    {
        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="propertyInfo">属性</param>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static object GetValue(this PropertyInfo propertyInfo, object obj)
        {
            return propertyInfo.GetValue(obj, null);
        }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="propertyInfo">属性</param>
        /// <param name="obj">对象</param>
        /// <param name="value">值</param>
        public static void SetValue(this PropertyInfo propertyInfo, object obj, object value)
        {
            propertyInfo.SetValue(obj, value, null);
        }
    }
}
