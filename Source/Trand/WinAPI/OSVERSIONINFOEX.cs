
// Type: Trand.WinAPI.OSVERSIONINFOEX
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System.Runtime.InteropServices;

namespace Trand.WinAPI
{
  public struct OSVERSIONINFOEX
  {
    public int dwOSVersionInfoSize;
    public int dwMajorVersion;
    public int dwMinorVersion;
    public int dwBuildNumber;
    public int dwPlatformId;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public string szCSDVersion;
    public short wServicePackMajor;
    public short wServicePackMinor;
    public short wSuiteMask;
    public byte wProductType;
    public byte wReserved;
  }
}
