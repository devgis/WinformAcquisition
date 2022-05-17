
// Type: TobaoHelper.TBJS_MainOrderComparer
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System.Collections.Generic;

namespace TobaoHelper
{
  internal class TBJS_MainOrderComparer : IEqualityComparer<TBJS_MainOrder>
  {
    public bool Equals(TBJS_MainOrder x, TBJS_MainOrder y)
    {
      return x.id == y.id;
    }

    public int GetHashCode(TBJS_MainOrder obj)
    {
      if (obj == null)
        return 0;
      return obj.ToString().GetHashCode();
    }
  }
}
