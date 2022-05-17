
// Type: IEProxyManagment.PerConnFlags
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;

namespace IEProxyManagment
{
  [Flags]
  public enum PerConnFlags
  {
    PROXY_TYPE_DIRECT = 1,
    PROXY_TYPE_PROXY = 2,
    PROXY_TYPE_AUTO_PROXY_URL = 4,
    PROXY_TYPE_AUTO_DETECT = 8,
  }
}
