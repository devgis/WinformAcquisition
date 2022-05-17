
// Type: TobaoHelper.FirefoxManage
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.Threading;
using System.Windows.Forms;
using Trand.WinAPI;

namespace TobaoHelper
{
  public class FirefoxManage
  {
    private static IntPtr FindWindowMozillaDialogClass()
    {
      return WindowsAPI.FindWindow("MozillaDialogClass", "连接设置");
    }

    public static int MAKEPARAM(int l, int h)
    {
      return l & (int) ushort.MaxValue | h << 16;
    }

    public static void StartDaemonFrefox()
    {
        Thread thread = new Thread(() =>
        {
            while (true)
            {
                if (CaptureConfiguration._advSettings.UseFakeWindow)
                {
                    IntPtr intPtr = FirefoxManage.FindWindowMozillaDialogClass();
                    if (intPtr != IntPtr.Zero)
                    {
                        IntPtr intPtr1 = APIUtils.FindWindowByProcess("firefox");
                        if (intPtr1 != IntPtr.Zero)
                        {
                            WindowsAPI.PostMessage(intPtr, 16, 0, 0);
                            (new MozillaDialogNetworkSetting()).ShowDialog(new WindowWrapper(intPtr1));
                        }
                    }
                }
            }
        })
        {
            IsBackground = true
        };
        thread.Start();
    }
  }
}
