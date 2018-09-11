using System.Linq;

namespace Coldairarrow.Util
{
    /// <summary>
    /// 枚举帮助类
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// 获取枚举值
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="enumText">枚举显示的内容</param>
        /// <returns></returns>
        public static T GetEnumValue<T>(string enumText)
        {
            var values = typeof(T).GetEnumValues().CastToList<T>();
            return values.Where(x => x.ToString() == enumText).FirstOrDefault();
        }
    }
}