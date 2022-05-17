
// Type: Trand.WinAPI.MODULEENTRY32
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.Runtime.InteropServices;

namespace Trand.WinAPI
{
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
  public struct MODULEENTRY32
  {
    public int dwSize;
    public int th32ModuleID;
    public int th32ProcessID;
    public int GlblcntUsage;
    public int ProccntUsage;
    public byte modBaseAddr;
    public int modBaseSize;
    public IntPtr hModule;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    public string szModule;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
    public string szExePath;
  }
}
