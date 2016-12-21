using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scuec.Infrastructure
{
    /// <summary>字符串工具</summary>
    public static class StringUtil
    {
        /// <summary>是否NULL或Empty</summary>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
    }
}
