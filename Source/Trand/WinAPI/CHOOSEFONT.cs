
// Type: Trand.WinAPI.CHOOSEFONT
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.Runtime.InteropServices;

namespace Trand.WinAPI
{
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
  public class CHOOSEFONT
  {
    public int lStructSize = Marshal.SizeOf(typeof (CHOOSEFONT));
    public IntPtr lCustData = IntPtr.Zero;
    public IntPtr hwndOwner;
    public IntPtr hDC;
    public IntPtr lpLogFont;
    public int iPointSize;
    public int Flags;
    public int rgbColors;
    public WndProc lpfnHook;
    public string lpTemplateName;
    public IntPtr hInstance;
    public string lpszStyle;
    public short nFontType;
    public short ___MISSING_ALIGNMENT__;
    public int nSizeMin;
    public int nSizeMax;
  }
}
