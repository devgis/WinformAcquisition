
// Type: IEProxyManagment.InternetPerConnOptionList
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.Runtime.InteropServices;

namespace IEProxyManagment
{
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
  public struct InternetPerConnOptionList
  {
    public int dwSize;
    public IntPtr szConnection;
    public int dwOptionCount;
    public int dwOptionError;
    public IntPtr options;
  }
}
