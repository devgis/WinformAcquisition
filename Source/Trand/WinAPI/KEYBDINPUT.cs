
// Type: Trand.WinAPI.KEYBDINPUT
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;

namespace Trand.WinAPI
{
  public struct KEYBDINPUT
  {
    public short wVk;
    public short wScan;
    public int dwFlags;
    public int time;
    public IntPtr dwExtraInfo;
  }
}
