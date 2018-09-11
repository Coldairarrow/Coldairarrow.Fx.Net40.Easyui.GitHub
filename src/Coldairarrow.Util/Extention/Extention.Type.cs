using System;
using System.Linq;
using System.Reflection;

namespace Coldairarrow.Util
{
    /// <summary>
    /// 拓展类
    /// </summary>
    public static partial class Extention
    {
        /// <summary>
        /// 获取指定特性
        /// </summary>
        /// <param name="element">元素</param>
        /// <param name="attributeType">特性类型</param>
        /// <returns></returns>
        public static Attribute GetCustomAttribute(this MemberInfo element, Type attributeType)
        {
            return element.GetCustomAttribute(attributeType, true);
        }

        /// <summary>
        /// 获取指定特性
        /// </summary>
        /// <param name="element">元素</param>
        /// <param name="attributeType">特性类型</param>
        /// <returns></returns>
        public static Attribute GetCustomAttribute(this MemberInfo element, Type attributeType, bool inherit)
        {
            return element.GetCustomAttributes(attributeType, inherit).FirstOrDefault() as Attribute;
        }

        /// <summary>
        /// 获取指定特性
        /// </summary>
        /// <typeparam name="T">特性类型</typeparam>
        /// <param name="element">元素</param>
        /// <returns></returns>
        public static T GetCustomAttribute<T>(this MemberInfo element) where T : Attribute
        {
            return element.GetCustomAttribute(typeof(T)) as T;
        }
    }
}
