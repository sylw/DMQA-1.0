using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Scuec.Infrastructure
{
    /// <summary>通用工具</summary>
    public static class Utility
    {
        /// <summary>
        /// 转换类型
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="value">需要转换的值</param>
        /// <returns>目标类型的值</returns>
        public static T As<T>(this object value)
            where T : class
        {
            return value as T;
        }

        /// <summary>
        /// 强制转换类型
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="value">需要转换的值</param>
        /// <returns>目标类型的值</returns>
        public static T CastTo<T>(this object value)
        {
            return (T) value;
        }

        /// <summary>
        /// 深克隆
        /// </summary>
        /// <typeparam name="T">要克隆的对象的类型</typeparam>
        /// <param name="value">要克隆的对象的值</param>
        /// <returns>克隆的对象</returns>
        public static T DeepClone<T>(this T value)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, value);
                stream.Position = 0;
                return (T) formatter.Deserialize(stream);
            }
        }
    }
}
