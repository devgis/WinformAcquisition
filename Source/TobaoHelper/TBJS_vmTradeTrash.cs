
// Type: TobaoHelper.TBJS_vmTradeTrash
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

namespace TobaoHelper
{
  public class TBJS_vmTradeTrash
  {
    public string id { get; set; }

    public string date { get; set; }

    public string name { get; set; }

    public string other { get; set; }

    public double amount { get; set; }

    public string status { get; set; }

    public bool IsHide { get; set; }

    public long userId { get; set; }

    public string tradeStatusText { get; set; }

    public TBJS_vmTradeTrash()
    {
      this.IsHide = false;
      this.tradeStatusText = "";
    }
  }
}
