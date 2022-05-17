
// Type: Trand.WinAPI.FLASHWINFO
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;

namespace Trand.WinAPI
{
  public struct FLASHWINFO
  {
    public uint cbSize;
    public IntPtr hwnd;
    public int dwFlags;
    public uint uCount;
    public int dwTimeout;
  }
}
