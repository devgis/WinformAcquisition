
// Type: Trand.WinAPI.ProcessInfo
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.Drawing;

namespace Trand.WinAPI
{
  public struct ProcessInfo
  {
    public IntPtr hwnd;
    public string ClassName;
    public string WindowText;
    public string path;
    public int processsize;
    public Point location;
    public Size wsize;
    public Size csize;
    public DateTime starttime;
    public string runtime;
    public IntPtr phwnd;
    public int id;
    public string text;
    public int dwStyle;
    public int dwExStyle;
    public uint cxWindowBorders;
    public uint cyWindowBorders;
  }
}
