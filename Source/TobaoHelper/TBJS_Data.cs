
// Type: TobaoHelper.TBJS_Data
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

namespace TobaoHelper
{
  public class TBJS_Data
  {
    public TBJS_MainOrder[] mainOrders { get; set; }

    public TBJS_Data.TBJS_MainExtra extra { get; set; }

    public TBJS_Page page { get; set; }

    public TBJS_Query query { get; set; }

    public TBJS_Tab[] tabs { get; set; }

    public class TBJS_MainExtra
    {
      public string asyncRequestUrl { get; set; }

      public string carttaskServerPath { get; set; }

      public string followModulePath { get; set; }

      public bool hasPageList { get; set; }

      public string i18n { get; set; }

      public string mainBizOrderIds { get; set; }

      public string rateGift { get; set; }

      public bool showB2BMenu { get; set; }

      public string tbskipModulePath { get; set; }
    }
  }
}
