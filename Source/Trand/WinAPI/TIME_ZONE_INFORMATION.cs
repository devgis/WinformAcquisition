
// Type: Trand.WinAPI.TIME_ZONE_INFORMATION
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System.Runtime.InteropServices;

namespace Trand.WinAPI
{
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
  public struct TIME_ZONE_INFORMATION
  {
    public long Bias;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    public string StandardName;
    public SYSTEMTIME StandardDate;
    public long StandardBias;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    public string DaylightName;
    private SYSTEMTIME DaylightDate;
    public long DaylightBias;
  }
}
