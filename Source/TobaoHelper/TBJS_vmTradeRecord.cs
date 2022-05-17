
// Type: TobaoHelper.TBJS_vmTradeRecord
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;

namespace TobaoHelper
{
  [Serializable]
  public class TBJS_vmTradeRecord
  {
    public string rowid { get; set; }

    public string number { get; set; }

    public string date { get; set; }

    public string name { get; set; }

    public string memo { get; set; }

    public double in_amount { get; set; }

    public double out_amount { get; set; }

    public double balance { get; set; }

    public string from { get; set; }

    public bool IsHide { get; set; }

    public bool IsClearMemo { get; set; }

    public long userId { get; set; }

    public string StatusText { get; set; }

    public TBJS_vmTradeRecord()
    {
      this.IsHide = false;
      this.IsClearMemo = false;
      this.StatusText = "";
    }
  }
}
