
// Type: Trand.Utils.LogHelper
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using log4net;
using System;

namespace Trand.Utils
{
  public class LogHelper
  {
    public static void WriteLog(Type t, Exception ex)
    {
      LogManager.GetLogger("DetailLog").Error((object) "Error", ex);
    }

    public static void WriteLog(Type t, string msg)
    {
      LogManager.GetLogger("DetailLog").Info((object) msg);
    }

    public static void WriteLog(string msg)
    {
      LogManager.GetLogger("InfoLog").Info((object) msg);
    }
  }
}
