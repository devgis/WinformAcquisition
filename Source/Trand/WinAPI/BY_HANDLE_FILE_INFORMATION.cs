
// Type: Trand.WinAPI.BY_HANDLE_FILE_INFORMATION
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

namespace Trand.WinAPI
{
  public struct BY_HANDLE_FILE_INFORMATION
  {
    public int dwFileAttributes;
    public _FILETIME ftCreationTime;
    public _FILETIME ftLastAccessTime;
    public _FILETIME ftLastWriteTime;
    public int dwVolumeSerialNumber;
    public int nFileSizeHigh;
    public int nFileSizeLow;
    public int nNumberOfLinks;
    public int nFileIndexHigh;
    public int nFileIndexLow;
    public int dwOID;
  }
}
