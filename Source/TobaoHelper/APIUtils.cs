
// Type: TobaoHelper.APIUtils
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace TobaoHelper
{
  public class APIUtils
  {
    [DllImport("user32.dll")]
    private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

    public static IntPtr FindWindowByProcess(string ProcessesName)
    {
      Process[] processesByName = Process.GetProcessesByName(ProcessesName);
      if (processesByName != null && processesByName.Length != 0)
        return processesByName[0].MainWindowHandle;
      return IntPtr.Zero;
    }

    public static int GetProcessesId(string ProcessesName)
    {
      Process[] processesByName = Process.GetProcessesByName(ProcessesName);
      if (processesByName != null && processesByName.Length != 0)
        return processesByName[0].Id;
      return 0;
    }

    public static void Delay(int milliSecond)
    {
      int tickCount = Environment.TickCount;
      while (Environment.TickCount - tickCount < milliSecond)
        Application.DoEvents();
    }

    public static string Hash(string strPlain)
    {
      using (HashAlgorithm hashAlgorithm = HashAlgorithm.Create("SHA1"))
        return BitConverter.ToString(hashAlgorithm.ComputeHash(Encoding.Unicode.GetBytes(strPlain))).Replace("-", "");
    }

    public static bool TestifAlreadyRunning()
    {
      Process currentProcess = Process.GetCurrentProcess();
      foreach (Process process in Process.GetProcesses())
      {
        if (process.Id != currentProcess.Id && process.ProcessName == currentProcess.ProcessName)
        {
          APIUtils.ShowWindowAsync(process.MainWindowHandle, 5);
          return true;
        }
      }
      return false;
    }

    public static bool IsWindowsXP()
    {
      if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major == 5)
        return Environment.OSVersion.Version.Minor == 1;
      return false;
    }

    public static bool IsWindows7()
    {
      if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major == 6)
        return Environment.OSVersion.Version.Minor == 1;
      return false;
    }

    public static bool IsWindows8()
    {
      if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major == 6)
        return Environment.OSVersion.Version.Minor == 2;
      return false;
    }
  }
}
