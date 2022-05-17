
// Type: TobaoHelper.TBJS_SubOrder
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

namespace TobaoHelper
{
  public class TBJS_SubOrder
  {
    public string amount { get; set; }

    public long id { get; set; }

    public TBJS_SubOrder.TBJS_ItemInfo itemInfo { get; set; }

    public TBJS_Operation[] operations { get; set; }

    public TBJS_SubOrder.TBJS_PriceInfo priceInfo { get; set; }

    public string quantity { get; set; }

    public long subOrderId { get; set; }

    public class TBJS_ItemInfo
    {
      public long id { get; set; }

      public string itemUrl { get; set; }

      public string pic { get; set; }

      public TBJS_SubOrder.TBJS_ServiceIcons[] serviceIcons { get; set; }

      public TBJS_SubOrder.TBJS_SkuText[] skuText { get; set; }

      public string snapUrl { get; set; }

      public string title { get; set; }
    }

    public class TBJS_PriceInfo
    {
      public string original { get; set; }

      public string realTotal { get; set; }
    }

    public class TBJS_ServiceIcons
    {
      public string linkTitle { get; set; }

      public string linkUrl { get; set; }

      public string name { get; set; }

      public string title { get; set; }

      public int type { get; set; }

      public string url { get; set; }
    }

    public class TBJS_SkuText
    {
      public string name { get; set; }

      public string value { get; set; }
    }
  }
}
