
// Type: Trand.WinAPI._SHFILEOPSTRUCT
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.Runtime.InteropServices;

namespace Trand.WinAPI
{
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
  public class _SHFILEOPSTRUCT
  {
    public IntPtr hwnd;
    public uint wFunc;
    public string pFrom;
    public string pTo;
    public ushort fFlags;
    public int fAnyOperationsAborted;
    public IntPtr hNameMappings;
    public string lpszProgressTitle;
  }
}
