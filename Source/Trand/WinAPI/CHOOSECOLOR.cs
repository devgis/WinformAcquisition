
// Type: Trand.WinAPI.CHOOSECOLOR
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.Runtime.InteropServices;

namespace Trand.WinAPI
{
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
  public class CHOOSECOLOR
  {
    public int lStructSize = Marshal.SizeOf(typeof (CHOOSECOLOR));
    public IntPtr lCustData = IntPtr.Zero;
    public IntPtr hwndOwner;
    public IntPtr hInstance;
    public int rgbResult;
    public IntPtr lpCustColors;
    public int Flags;
    public WndProc lpfnHook;
    public string lpTemplateName;
  }
}
