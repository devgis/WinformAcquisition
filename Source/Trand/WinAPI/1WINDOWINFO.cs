
// Type: Trand.WinAPI.WINDOWINFO
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;

namespace Trand.WinAPI
{
  public struct WINDOWINFO
  {
    public int cbSize;
    public RECT rcWindow;
    public RECT rcClient;
    public int dwStyle;
    public int dwExStyle;
    public int dwWindowStatus;
    public uint cxWindowBorders;
    public uint cyWindowBorders;
    public int atomWindowType;
    public int wCreatorVersion;
    public IntPtr hWnd;
    public string szWindowName;
    public string szClassName;
    public string szExePath;
  }
}
