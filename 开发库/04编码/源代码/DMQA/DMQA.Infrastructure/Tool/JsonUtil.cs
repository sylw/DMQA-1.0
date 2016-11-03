using Newtonsoft.Json;
using System;

namespace DMQA.Infrastructure.Tool
{
    public class JsonUtil
    {
        /// <summary>
        /// 将对象序列化为Json字符串
        /// </summary>
        /// <param name="obj">指定类型的对象</param>
        /// <returns></returns>
        public static string ObjectToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 将Json字符串反序列化为指定类型
        /// </summary>
        /// <param name="jsonString">Json字符串</param>
        /// <param name="type">指定类型</param>
        /// <returns></returns>
        public static object JsonToObject(string jsonString, Type type)
        {
            return JsonConvert.DeserializeObject(jsonString, type);
        }
    }
}