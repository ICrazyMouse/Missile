using Newtonsoft.Json;

namespace Missile.Utils
{
    class JSON
    {
        /// <summary>
        /// 对象转json
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string toString(object o)
        {
            return JsonConvert.SerializeObject(o, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }
        /// <summary>
        /// json转对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T toObject<T>(string json)
        {
            return (T)JsonConvert.DeserializeObject(json, typeof(T));
        }
    }
}
