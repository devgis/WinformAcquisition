
// Type: Trand.WinAPI.WIN32_FIND_DATA
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.Runtime.InteropServices;

namespace Trand.WinAPI
{
  [BestFitMapping(false)]
  [Serializable]
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
  public struct WIN32_FIND_DATA
  {
    public int dwFileAttributes;
    public int ftCreationTime_dwLowDateTime;
    public int ftCreationTime_dwHighDateTime;
    public int ftLastAccessTime_dwLowDateTime;
    public int ftLastAccessTime_dwHighDateTime;
    public int ftLastWriteTime_dwLowDateTime;
    public int ftLastWriteTime_dwHighDateTime;
    public int nFileSizeHigh;
    public int nFileSizeLow;
    public int dwReserved0;
    public int dwReserved1;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
    public string cFileName;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
    public string cAlternateFileName;
  }
}
