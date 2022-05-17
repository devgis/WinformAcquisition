
// Type: Trand.WinAPI.MONITORINFOEX
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System.Runtime.InteropServices;

namespace Trand.WinAPI
{
  public struct MONITORINFOEX
  {
    public int cbSize;
    public RECT rcMonitor;
    public RECT rcWork;
    public int dwFlags;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    public string szDevice;
  }
}
