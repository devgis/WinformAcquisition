
// Type: TobaoHelper.TBJS_vmRate
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;

namespace TobaoHelper
{
  [Serializable]
  public class TBJS_vmRate
  {
    public long id { get; set; }

    public string comment { get; set; }

    public string date { get; set; }

    public long user_number_id { get; set; }

    public string user_name { get; set; }

    public long item_id_num { get; set; }

    public string item_id_name { get; set; }

    public string price { get; set; }

    public long userId { get; set; }

    public int rate_type { get; set; }

    public bool IsHide { get; set; }

    public string StatusText { get; set; }

    public TBJS_vmRate()
    {
      this.IsHide = false;
      this.StatusText = "";
    }
  }
}
