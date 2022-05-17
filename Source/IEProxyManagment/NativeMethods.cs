
// Type: IEProxyManagment.NativeMethods
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.Runtime.InteropServices;

namespace IEProxyManagment
{
  internal static class NativeMethods
  {
    [DllImport("WinInet.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool InternetSetOption(IntPtr hInternet, InternetOption dwOption, IntPtr lpBuffer, int dwBufferLength);
  }
}
