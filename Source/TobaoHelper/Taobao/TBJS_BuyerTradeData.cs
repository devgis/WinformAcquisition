
// Type: TobaoHelper.Taobao.TBJS_BuyerTradeData
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

namespace TobaoHelper.Taobao
{
  public class TBJS_BuyerTradeData
  {
    public long userid { get; set; }

    public long id { get; set; }

    public string createDay { get; set; }

    public string createTime { get; set; }

    public string tradeStatus { get; set; }

    public bool isHide { get; set; }

    public string editCreateDay { get; set; }

    public string editTradeStatus { get; set; }

    public int pageIndex { get; set; }

    public TBJS_BuyerTradeData()
    {
      this.isHide = false;
      this.pageIndex = 0;
    }
  }
}
