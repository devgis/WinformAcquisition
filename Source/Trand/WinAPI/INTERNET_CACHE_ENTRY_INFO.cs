
// Type: Trand.WinAPI.INTERNET_CACHE_ENTRY_INFO
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.Runtime.InteropServices;

namespace Trand.WinAPI
{
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
  public struct INTERNET_CACHE_ENTRY_INFO
  {
    public int dwStructSize;
    public IntPtr lpszSourceUrlName;
    public IntPtr lpszLocalFileName;
    public int CacheEntryType;
    public int dwUseCount;
    public int dwHitRate;
    public int dwSizeLow;
    public int dwSizeHigh;
    public _FILETIME LastModifiedTime;
    public _FILETIME ExpireTime;
    public _FILETIME LastAccessTime;
    public _FILETIME LastSyncTime;
    public IntPtr lpHeaderInfo;
    public int dwHeaderInfoSize;
    public IntPtr lpszFileExtension;
    public int dwExemptDelta;
  }
}
