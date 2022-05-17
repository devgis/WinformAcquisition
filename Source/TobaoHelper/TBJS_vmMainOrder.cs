
// Type: TobaoHelper.TBJS_vmMainOrder
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;

namespace TobaoHelper
{
  [Serializable]
  public class TBJS_vmMainOrder
  {
    public long id { get; set; }

    public long userid { get; set; }

    public string tradeStatus { get; set; }

    public string tradeStatusText { get; set; }

    public string createDay { get; set; }

    public DateTime createTime { get; set; }

    public bool IsHide { get; set; }

    public bool IsRate { get; set; }

    public int subOrderCount { get; set; }

    public TBJS_vmMainOrder()
    {
      this.IsHide = false;
      this.IsRate = false;
      this.subOrderCount = 0;
    }
  }
}
