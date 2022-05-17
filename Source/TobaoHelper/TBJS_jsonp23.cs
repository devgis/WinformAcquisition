
// Type: TobaoHelper.TBJS_jsonp23
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

namespace TobaoHelper
{
  public class TBJS_jsonp23
  {
    public bool status { get; set; }

    public int code { get; set; }

    public TBJS_jsonp23.TBJS_jsonp23_data data { get; set; }

    public string msg { get; set; }

    public string host { get; set; }

    public class TBJS_jsonp23_data
    {
      public TBJS_jsonp23.TBJS_jsonp23_growth[] growthList { get; set; }

      public int vLimit { get; set; }

      public bool hasNext { get; set; }
    }

    public class TBJS_jsonp23_growth
    {
      public string amount { get; set; }

      public long bizOrderId { get; set; }

      public int curScore { get; set; }

      public string gmtCreateTimeFormatted { get; set; }

      public int hint { get; set; }

      public string orderTimeFormatted { get; set; }

      public string orderTimeFull { get; set; }

      public TBJS_jsonp23.TBJS_jsonp23_order[] orders { get; set; }

      public int preScore { get; set; }

      public int score { get; set; }

      public string tradeMemo { get; set; }
    }

    public class TBJS_jsonp23_order
    {
      public string orderUrl { get; set; }

      public string pic { get; set; }

      public string subOrderId { get; set; }

      public string title { get; set; }
    }
  }
}
