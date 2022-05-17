
// Type: TobaoHelper.JsonHelper
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace TobaoHelper
{
  public class JsonHelper
  {
    public static string SerializeObject(object o)
    {
      return JsonConvert.SerializeObject(o);
    }

    public static T DeserializeJsonToObject<T>(string json) where T : class
    {
      return new JsonSerializer().Deserialize((JsonReader) new JsonTextReader((TextReader) new StringReader(json)), typeof (T)) as T;
    }

    public static List<T> DeserializeJsonToList<T>(string json) where T : class
    {
      return new JsonSerializer().Deserialize((JsonReader) new JsonTextReader((TextReader) new StringReader(json)), typeof (List<T>)) as List<T>;
    }

    public static T DeserializeAnonymousType<T>(string json, T anonymousTypeObject)
    {
      return JsonConvert.DeserializeAnonymousType<T>(json, anonymousTypeObject);
    }
  }
}
