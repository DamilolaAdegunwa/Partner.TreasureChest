using System;
using System.Collections.Generic;
using System.Text;

namespace CodeHelper.Generator.Utils
{
    /// <summary>
    /// 字符串扩展方法
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 字符串转值类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="valueAsString"></param>
        /// <returns></returns>
        public static T? GetValueOrNull<T>(this string valueAsString)
            where T : struct
        {
            if (string.IsNullOrEmpty(valueAsString))
                return null;
            return (T)Convert.ChangeType(valueAsString, typeof(T));
        }
    }
}
