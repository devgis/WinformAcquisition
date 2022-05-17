
// Type: TobaoHelper.TBJS_Operation
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

namespace TobaoHelper
{
  public class TBJS_Operation
  {
    public string id { get; set; }

    public string style { get; set; }

    public string text { get; set; }

    public string url { get; set; }

    public string action { get; set; }

    public string dataUrl { get; set; }

    public TBJS_Operation.Data data { get; set; }

    public class Data
    {
      public string body { get; set; }

      public string title { get; set; }

      public int height { get; set; }

      public int width { get; set; }
    }
  }
}
