
// Type: Trand.WinAPI.MSG
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.Drawing;

namespace Trand.WinAPI
{
  public struct MSG
  {
    public IntPtr hwnd;
    public uint message;
    public int wParam;
    public int lParam;
    public int time;
    public Point pt;
  }
}
