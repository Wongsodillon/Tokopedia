using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Pattern_Software_Design_Qualification.Facades
{
    public class Json
    {
        public static String Encode(Object data)
        {
            return JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
        public static T Decode<T>(String json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}