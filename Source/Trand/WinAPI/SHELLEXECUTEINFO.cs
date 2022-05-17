
// Type: Trand.WinAPI.SHELLEXECUTEINFO
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;

namespace Trand.WinAPI
{
  public struct SHELLEXECUTEINFO
  {
    public int cbSize;
    public int fMask;
    public IntPtr hwnd;
    public string lpVerb;
    public string lpFile;
    public string lpParameters;
    public string lpDirectory;
    public int nShow;
    public IntPtr hInstApp;
    public IntPtr lpIDList;
    public string lpClass;
    public IntPtr hkeyClass;
    public int dwHotKey;
    public IntPtr hIcon;
    public IntPtr hProcess;
  }
}
