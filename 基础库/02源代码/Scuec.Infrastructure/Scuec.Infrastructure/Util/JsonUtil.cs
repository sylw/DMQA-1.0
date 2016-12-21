using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Scuec.Infrastructure
{
    /// <summary>JSON工具</summary>
    public static class JsonUtil
    {
        /// <summary>生成对象JSON串</summary>
        public static string ToJsonString(this object value, JsonSerializerSettings settings = null)
        {
            return JsonConvert.SerializeObject(value, Formatting.Indented, settings);
        }

        /// <summary>根据JSON串生成对象</summary>
        public static object JsonTo(this string value, JsonSerializerSettings settings = null)
        {
            return JsonConvert.DeserializeObject(value, settings);
        }

        /// <summary>根据JSON串生成指定类型的对象 </summary>
        /// <typeparam name="T">指定类型</typeparam>
        public static T JsonTo<T>(this string value, JsonSerializerSettings settings = null)
        {
            return JsonConvert.DeserializeObject<T>(value, settings);
        }

        /// <summary>JObject转换为字典对象</summary>
        public static Dictionary<string, object> JsonToDictionary(this JObject jObject)
        {
            return JsonToDictionary(jObject, new Dictionary<string, object>());
        }

        /// <summary>JObject转换为指定字典类型对象</summary>
        public static TDict JsonToDictionary<TDict>(this JObject jObject, TDict values)
            where TDict : IDictionary<string, object>
        {
            foreach (var pair in jObject)
            {
                values.Add(pair.Key, pair.Value.JsonToObject());
            }
            return values;
        }

        /// <summary>JObject转换为对象</summary>
        public static object JsonToObject(this JToken jToken)
        {
            switch (jToken.Type)
            {
                case JTokenType.Object:
                    var jObject = jToken.As<JObject>();
                    var dict = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                    foreach (var pair in jObject)
                    {
                        dict.Add(pair.Key, pair.Value.JsonToObject());
                    }
                    return dict;
                case JTokenType.Array:
                    var jArray = jToken.As<JArray>();
                    var list = new List<object>();
                    foreach (var t in jArray)
                    {
                        list.Add(t.JsonToObject());
                    }
                    return list;
                case JTokenType.Comment:
                    return null;
                default:
                    var jValue = jToken.As<JValue>();
                    return jValue.Value;
            }
        }
    }
}
