
// Type: TobaoHelper.TBJS_PayInfo
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

namespace TobaoHelper
{
  public class TBJS_PayInfo
  {
    public string actualFee { get; set; }

    public TBJS_PayInfo.TBJS_Icons[] icons { get; set; }

    public TBJS_PayInfo.TBJS_PostFees[] postFees { get; set; }

    public class TBJS_Icons
    {
      public string title { get; set; }

      public int type { get; set; }

      public string url { get; set; }
    }

    public class TBJS_PostFees
    {
      public string prefix { get; set; }

      public string suffix { get; set; }

      public string value { get; set; }
    }
  }
}
