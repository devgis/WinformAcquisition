
// Type: Trand.WinAPI.OPENFILENAME
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.Runtime.InteropServices;

namespace Trand.WinAPI
{
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
  public class OPENFILENAME
  {
    public IntPtr dlgOwner = IntPtr.Zero;
    public IntPtr instance = IntPtr.Zero;
    public IntPtr custData = IntPtr.Zero;
    public IntPtr hook = IntPtr.Zero;
    public IntPtr reservedPtr = IntPtr.Zero;
    public int structSize;
    public string filter;
    public string customFilter;
    public int maxCustFilter;
    public int filterIndex;
    public string file;
    public int maxFile;
    public string fileTitle;
    public int maxFileTitle;
    public string initialDir;
    public string title;
    public int flags;
    public short fileOffset;
    public short fileExtension;
    public string defExt;
    public string templateName;
    public int reservedInt;
    public int flagsEx;
  }
}
