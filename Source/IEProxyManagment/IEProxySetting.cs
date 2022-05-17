
// Type: IEProxyManagment.IEProxySetting
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace IEProxyManagment
{
  public class IEProxySetting
  {
    public static bool UnsetProxy()
    {
      return IEProxySetting.SetProxy((string) null, (string) null);
    }

    public static bool SetProxy(string strProxy)
    {
      return IEProxySetting.SetProxy(strProxy, (string) null);
    }

    public static bool SetProxy(string strProxy, string exceptions)
    {
      InternetPerConnOptionList perConnOptionList = new InternetPerConnOptionList();
      int length = string.IsNullOrEmpty(strProxy) ? 1 : (string.IsNullOrEmpty(exceptions) ? 2 : 3);
      InternetConnectionOption[] connectionOptionArray = new InternetConnectionOption[length];
      connectionOptionArray[0].m_Option = PerConnOption.INTERNET_PER_CONN_FLAGS;
      connectionOptionArray[0].m_Value.m_Int = length < 2 ? 1 : 3;
      if (length > 1)
      {
        connectionOptionArray[1].m_Option = PerConnOption.INTERNET_PER_CONN_PROXY_SERVER;
        connectionOptionArray[1].m_Value.m_StringPtr = Marshal.StringToHGlobalAuto(strProxy);
        if (length > 2)
        {
          connectionOptionArray[2].m_Option = PerConnOption.INTERNET_PER_CONN_PROXY_BYPASS;
          connectionOptionArray[2].m_Value.m_StringPtr = Marshal.StringToHGlobalAuto(exceptions);
        }
      }
      perConnOptionList.dwSize = Marshal.SizeOf((object) perConnOptionList);
      perConnOptionList.szConnection = IntPtr.Zero;
      perConnOptionList.dwOptionCount = connectionOptionArray.Length;
      perConnOptionList.dwOptionError = 0;
      int num1 = Marshal.SizeOf(typeof (InternetConnectionOption));
      IntPtr ptr1 = Marshal.AllocCoTaskMem(num1 * connectionOptionArray.Length);
      for (int index = 0; index < connectionOptionArray.Length; ++index)
      {
        IntPtr ptr2 = new IntPtr(ptr1.ToInt32() + index * num1);
        Marshal.StructureToPtr((object) connectionOptionArray[index], ptr2, false);
      }
      perConnOptionList.options = ptr1;
      IntPtr num2 = Marshal.AllocCoTaskMem(perConnOptionList.dwSize);
      Marshal.StructureToPtr((object) perConnOptionList, num2, false);
      int num3 = NativeMethods.InternetSetOption(IntPtr.Zero, InternetOption.INTERNET_OPTION_PER_CONNECTION_OPTION, num2, perConnOptionList.dwSize) ? -1 : 0;
      if (num3 == 0)
        num3 = Marshal.GetLastWin32Error();
      Marshal.FreeCoTaskMem(ptr1);
      Marshal.FreeCoTaskMem(num2);
      if (num3 > 0)
        throw new Win32Exception(Marshal.GetLastWin32Error());
      return num3 < 0;
    }
  }
}
