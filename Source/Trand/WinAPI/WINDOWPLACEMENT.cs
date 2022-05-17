
// Type: Trand.WinAPI.WINDOWPLACEMENT
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System.Drawing;

namespace Trand.WinAPI
{
  public struct WINDOWPLACEMENT
  {
    public int length;
    public int flags;
    public int showCmd;
    public Point ptMinPosition;
    public Point ptMaxPosition;
    public RECT rcNormalPosition;
  }
}
