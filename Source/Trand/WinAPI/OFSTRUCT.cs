
// Type: Trand.WinAPI.OFSTRUCT
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System.Runtime.InteropServices;

namespace Trand.WinAPI
{
  public struct OFSTRUCT
  {
    public byte cBytes;
    public byte fFixedDisk;
    public ushort nErrCode;
    public ushort Reserved1;
    public ushort Reserved2;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
    public string szPathName;
  }
}
