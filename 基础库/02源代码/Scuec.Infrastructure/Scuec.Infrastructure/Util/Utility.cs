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
        #region 转换方法
        /// <summary>转换类型</summary>
        public static T As<T>(this object value)
            where T : class
        {
            return value as T;
        }
        /// <summary>强制转换类型</summary>
        public static T CastTo<T>(this object value)
        {
            return (T)value;
        }
        #endregion

        #region 逻辑方法
        /// <summary>值是否在数组中</summary>
        public static bool In<T>(this T value, params T[] values)
        {
            return values.Any(e => Equals(e, value));
        }
        /// <summary>值是否在数组中</summary>
        public static bool FastIn<T>(this T value, params T[] values)
            where T : IEquatable<T>
        {
            return values.Any(e => e.Equals(value));
        }
        #endregion

        #region 克隆方法
        /// <summary>深克隆</summary>
        public static T DeepClone<T>(this T value)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, value);
                stream.Position = 0;
                return (T)formatter.Deserialize(stream);
            }
        }
        #endregion
    }
}
