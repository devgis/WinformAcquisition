
// Type: Trand.WinAPI.APIMethod
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Trand.WinAPI
{
  public sealed class APIMethod
  {
    private List<WindowInfo> childList = new List<WindowInfo>();

    public IntPtr DeskHwnd
    {
      get
      {
        return WindowsAPI.GetDesktopWindow();
      }
    }

    public void DoExitWin(int flg)
    {
      IntPtr currentProcess = WindowsAPI.GetCurrentProcess();
      IntPtr TokenHandle = IntPtr.Zero;
      WindowsAPI.OpenProcessToken(currentProcess, 40, ref TokenHandle);
      TokPriv1Luid NewState;
      NewState.Count = 1;
      NewState.Luid = 0L;
      NewState.Attr = 2;
      WindowsAPI.LookupPrivilegeValue((string) null, "SeShutdownPrivilege", ref NewState.Luid);
      WindowsAPI.AdjustTokenPrivileges(TokenHandle, false, ref NewState, 0, IntPtr.Zero, IntPtr.Zero);
      WindowsAPI.ExitWindowsEx(flg, 0);
    }

    public void DoExitWin(WinExit exit)
    {
      int uFlags = 0;
      if (exit == WinExit.SHUTDOWN)
        uFlags = 1;
      else if (exit == WinExit.REBOOT)
        uFlags = 2;
      else if (exit == WinExit.POWEROFF)
        uFlags = 8;
      else if (exit == WinExit.LOGOFF)
        uFlags = 0;
      else if (exit == WinExit.FORCEIFHUNG)
        uFlags = 16;
      else if (exit == WinExit.FORCE)
        uFlags = 4;
      IntPtr currentProcess = WindowsAPI.GetCurrentProcess();
      IntPtr TokenHandle = IntPtr.Zero;
      WindowsAPI.OpenProcessToken(currentProcess, 40, ref TokenHandle);
      TokPriv1Luid NewState;
      NewState.Count = 1;
      NewState.Luid = 0L;
      NewState.Attr = 2;
      WindowsAPI.LookupPrivilegeValue((string) null, "SeShutdownPrivilege", ref NewState.Luid);
      WindowsAPI.AdjustTokenPrivileges(TokenHandle, false, ref NewState, 0, IntPtr.Zero, IntPtr.Zero);
      WindowsAPI.ExitWindowsEx(uFlags, 0);
    }

    public void DisplaySetting(int width, int height, int frequency)
    {
        DEVMODE dEVMODE = default(DEVMODE);
        dEVMODE.dmSize = (int)((short)Marshal.SizeOf(typeof(DEVMODE)));
        dEVMODE.dmPelsWidth = width;
        dEVMODE.dmPelsHeight = height;
        dEVMODE.dmDisplayFrequency = frequency;
        dEVMODE.dmFields = 5767168;
        WindowsAPI.ChangeDisplaySettings(ref dEVMODE, 1);
    }

    public void DisplaySetting(DisplaySettings dis, int frequency)
    {
        int dmPelsWidth = 1024;
        int dmPelsHeight = 768;
        switch (dis)
        {
            case DisplaySettings.Smallest:
                dmPelsWidth = 600;
                dmPelsHeight = 480;
                break;
            case DisplaySettings.Small:
                dmPelsWidth = 800;
                dmPelsHeight = 600;
                break;
            case DisplaySettings.Normal:
                dmPelsWidth = 1024;
                dmPelsHeight = 768;
                break;
            case DisplaySettings.Largest:
                dmPelsWidth = 1280;
                dmPelsHeight = 1024;
                break;
        }
        DEVMODE dEVMODE = default(DEVMODE);
        dEVMODE.dmSize = (int)((short)Marshal.SizeOf(typeof(DEVMODE)));
        dEVMODE.dmPelsWidth = dmPelsWidth;
        dEVMODE.dmPelsHeight = dmPelsHeight;
        dEVMODE.dmDisplayFrequency = frequency;
        dEVMODE.dmFields = 5767168;
        WindowsAPI.ChangeDisplaySettings(ref dEVMODE, 1);
    }

    public string GetWindowsDirectory()
    {
      StringBuilder lpBuffer = new StringBuilder();
      WindowsAPI.GetWindowsDirectory(lpBuffer, 100);
      return lpBuffer.ToString() + "\\";
    }

    public string GetSystemDirectory()
    {
      StringBuilder lpBuffer = new StringBuilder();
      WindowsAPI.GetSystemDirectory(lpBuffer, 100);
      return lpBuffer.ToString() + "\\";
    }

    public string GetTempPath()
    {
      StringBuilder lpszBuffer = new StringBuilder(260);
      WindowsAPI.GetTempPath(lpszBuffer.Capacity, lpszBuffer);
      return lpszBuffer.ToString();
    }

    public string PathRemoveBack(string path)
    {
      StringBuilder lpszPath = new StringBuilder(path);
      WindowsAPI.PathRemoveBackslash(lpszPath);
      return lpszPath.ToString();
    }

    public string PathRemoveArgs(string path)
    {
      StringBuilder pszPath = new StringBuilder(path);
      WindowsAPI.PathRemoveArgs(pszPath);
      return pszPath.ToString();
    }

    public string PathRemoveBlanks(string path)
    {
      StringBuilder lpszString = new StringBuilder(path);
      WindowsAPI.PathRemoveBlanks(lpszString);
      return lpszString.ToString();
    }

    public string PathRemoveExtension(string path)
    {
      StringBuilder pszPath = new StringBuilder(path);
      WindowsAPI.PathRemoveExtension(pszPath);
      return pszPath.ToString();
    }

    public string PathRenameExtension(string path, string ext)
    {
      StringBuilder pszPath = new StringBuilder(path);
      WindowsAPI.PathRenameExtension(pszPath, ext);
      return pszPath.ToString();
    }

    public void SleepProgram(int time)
    {
      WindowsAPI.Sleep(time);
    }

    public int GetInternetTempFiles()
    {
      TStringList tstringList = new TStringList();
      int num1 = 0;
      int lpdwFirstCacheEntryInfoBufferSize = 0;
      WindowsAPI.FindFirstUrlCacheEntry((string) null, IntPtr.Zero, ref lpdwFirstCacheEntryInfoBufferSize);
      int num2;
      if (Marshal.GetLastWin32Error() == 259)
      {
        num2 = 0;
      }
      else
      {
        int cb = lpdwFirstCacheEntryInfoBufferSize;
        IntPtr num3 = Marshal.AllocHGlobal(cb);
        IntPtr firstUrlCacheEntry = WindowsAPI.FindFirstUrlCacheEntry((string) null, num3, ref lpdwFirstCacheEntryInfoBufferSize);
        while (true)
        {
          int lpdwNextCacheEntryInfoBufferSize;
          bool nextUrlCacheEntry;
          do
          {
            INTERNET_CACHE_ENTRY_INFO internetCacheEntryInfo = (INTERNET_CACHE_ENTRY_INFO) Marshal.PtrToStructure(num3, typeof (INTERNET_CACHE_ENTRY_INFO));
            this.FileTimeToWindowsTime(internetCacheEntryInfo.LastModifiedTime).ToString();
            this.FileTimeToWindowsTime(internetCacheEntryInfo.ExpireTime).ToString();
            this.FileTimeToWindowsTime(internetCacheEntryInfo.LastAccessTime).ToString();
            this.FileTimeToWindowsTime(internetCacheEntryInfo.LastSyncTime).ToString();
            try
            {
              Marshal.PtrToStringAuto(internetCacheEntryInfo.lpszSourceUrlName);
              ++num1;
            }
            catch
            {
            }
            lpdwNextCacheEntryInfoBufferSize = cb;
            nextUrlCacheEntry = WindowsAPI.FindNextUrlCacheEntry(firstUrlCacheEntry, num3, ref lpdwNextCacheEntryInfoBufferSize);
            if (!nextUrlCacheEntry && Marshal.GetLastWin32Error() == 259)
              goto label_9;
          }
          while (nextUrlCacheEntry || lpdwNextCacheEntryInfoBufferSize <= cb);
          cb = lpdwNextCacheEntryInfoBufferSize;
          num3 = Marshal.ReAllocHGlobal(num3, (IntPtr) cb);
          WindowsAPI.FindNextUrlCacheEntry(firstUrlCacheEntry, num3, ref lpdwNextCacheEntryInfoBufferSize);
        }
label_9:
        Marshal.FreeHGlobal(num3);
        num2 = num1;
      }
      return num2;
    }

    public Point GetLastMessagePosition()
    {
      return new Point()
      {
        X = WindowsAPI.GET_X_LPARAM(WindowsAPI.GetMessagePos()),
        Y = WindowsAPI.GET_Y_LPARAM(WindowsAPI.GetMessagePos())
      };
    }

    public OSVERSIONINFO GetWindowsVersion()
    {
      OSVERSIONINFO lpVersionInformation = new OSVERSIONINFO();
      lpVersionInformation.dwOSVersionInfoSize = Marshal.SizeOf((object) lpVersionInformation);
      WindowsAPI.GetVersionEx(ref lpVersionInformation);
      return lpVersionInformation;
    }

    public OSVERSIONINFOEX GetWindowsVersionEx()
    {
      OSVERSIONINFOEX lpVersionInformation = new OSVERSIONINFOEX();
      lpVersionInformation.dwOSVersionInfoSize = Marshal.SizeOf((object) lpVersionInformation);
      WindowsAPI.GetVersionEx(ref lpVersionInformation);
      return lpVersionInformation;
    }

    private OSVERSIONINFOEX VerifyVersionInfo()
    {
      OSVERSIONINFOEX lpVersionInfo = new OSVERSIONINFOEX();
      lpVersionInfo.dwOSVersionInfoSize = Marshal.SizeOf((object) lpVersionInfo);
      WindowsAPI.VerifyVersionInfo(ref lpVersionInfo, (int) byte.MaxValue, 6);
      return lpVersionInfo;
    }

    public string GetCurrentWindowsVersion()
    {
      OSVERSIONINFO windowsVersion = this.GetWindowsVersion();
      string str = windowsVersion.dwMajorVersion.ToString() + "." + windowsVersion.dwMinorVersion.ToString() + "." + windowsVersion.dwBuildNumber.ToString() + " " + windowsVersion.szCSDVersion + " " + windowsVersion.dwPlatformId.ToString();
      return str == "5.1.2600  2" || str == "5.1.2600 Service Pack 1 2" || (str == "5.1.2600 Service Pack 2 2" || str == "5.1.2600 Service Pack 3 2") ? "Windows XP" : (str == "6.0.6000  2" || str == "6.0.6001 Service Pack 1 2" ? "Windows Vista" : (!(str == "6.0.6001") ? "Unknown" : "Windows 2008"));
    }

    public string GetCurrentWindowsVersionEx()
    {
      OSVERSIONINFOEX windowsVersionEx = this.GetWindowsVersionEx();
      string str = windowsVersionEx.dwMajorVersion.ToString() + "." + windowsVersionEx.dwMinorVersion.ToString() + "." + windowsVersionEx.dwBuildNumber.ToString() + " " + windowsVersionEx.szCSDVersion + " " + windowsVersionEx.dwPlatformId.ToString();
      return !(str == "5.1.2600  2") ? (!(str == "5.1.2600 Service Pack 1 2") ? (!(str == "5.1.2600 Service Pack 2 2") ? (!(str == "5.1.2600 Service Pack 3 2") ? (!(str == "6.0.6000  2") ? (!(str == "6.0.6001 Service Pack 1 2") ? (!(str == "6.0.6001") ? "Unknown" : "Windows 2008") : "Windows Vista Sevice Pack 1") : "Windows Vista") : "Windows XP SP2") : "Windows XP SP2") : "Windows XP SP1") : "Windows XP";
    }

    public Size GetScreenSize()
    {
      return new Size(WindowsAPI.GetSystemMetrics(0), WindowsAPI.GetSystemMetrics(1));
    }

    public void NotifyIcon(IntPtr hwnd, IntPtr icon, string tip)
    {
      NOTIFYICONDATA lpData = new NOTIFYICONDATA();
      lpData.cbSize = Marshal.SizeOf((object) lpData);
      lpData.hWnd = hwnd;
      lpData.hIcon = icon;
      lpData.uID = 100U;
      lpData.uFlags = 63U;
      lpData.szTip = tip;
      lpData.dwState = 2;
      lpData.dwStateMask = 2;
      lpData.dwInfoFlags = 1;
      WindowsAPI.Shell_NotifyIcon(0, ref lpData);
    }

    public void WindowMove(IntPtr hwnd, int x, int y)
    {
      Size windowSize = this.GetWindowSize(hwnd);
      WindowsAPI.MoveWindow(hwnd, x, y, windowSize.Width, windowSize.Height, true);
    }

    public void WindowMove(IntPtr hwnd, Point p)
    {
      Size windowSize = this.GetWindowSize(hwnd);
      WindowsAPI.MoveWindow(hwnd, p.X, p.Y, windowSize.Width, windowSize.Height, true);
    }

    public IntPtr GetCurrentIntPtr()
    {
      Point lpPoint = new Point();
      WindowsAPI.GetCursorPos(ref lpPoint);
      return WindowsAPI.WindowFromPoint(lpPoint);
    }

    public Point GetCurrentPos()
    {
      Point lpPoint = new Point();
      WindowsAPI.GetCursorPos(ref lpPoint);
      return lpPoint;
    }

    public System.Drawing.Color GetColor(IntPtr hwnd)
    {
      Point currentPos = this.GetCurrentPos();
      int pixel = WindowsAPI.GetPixel(WindowsAPI.GetDC(hwnd), currentPos.X, currentPos.Y);
      return System.Drawing.Color.FromArgb(pixel & (int) byte.MaxValue, (pixel & 65280) >> 8, (pixel & 16711680) >> 16);
    }

    public string HColor(System.Drawing.Color color)
    {
      return "#" + Convert.ToInt32(color.R).ToString("X").PadLeft(2, '0') + Convert.ToInt32(color.G).ToString("X").PadLeft(2, '0') + Convert.ToInt32(color.B).ToString("X").PadLeft(2, '0');
    }

    public System.Drawing.Color GetColor(Point P)
    {
      Graphics g = Graphics.FromHdc(WindowsAPI.CreateDC("DISPLAY", (string) null, (string) null, IntPtr.Zero));
      Bitmap bitmap = new Bitmap(1, 1, g);
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      IntPtr hdc1 = g.GetHdc();
      IntPtr hdc2 = graphics.GetHdc();
      WindowsAPI.BitBlt(hdc2, 0, 0, 1, 1, hdc1, P.X, P.Y, 13369376U);
      g.ReleaseHdc(hdc1);
      graphics.ReleaseHdc(hdc2);
      System.Drawing.Color pixel = bitmap.GetPixel(0, 0);
      g.Dispose();
      graphics.Dispose();
      bitmap.Dispose();
      return pixel;
    }

    public void AnimateWindowOpen(IntPtr hwnd)
    {
      WindowsAPI.AnimateWindow(hwnd, 3000, 655360);
    }

    public void AnimateWindowOpen(IntPtr hwnd, int time)
    {
      WindowsAPI.AnimateWindow(hwnd, time, 655360);
    }

    public void AnimateWindowClose(IntPtr hwnd)
    {
      WindowsAPI.AnimateWindow(hwnd, 3000, 65538);
    }

    public void AnimateWindowClose(IntPtr hwnd, int time)
    {
      WindowsAPI.AnimateWindow(hwnd, time, 65538);
    }

    public void SetWallpaperA(string path)
    {
      if (!File.Exists(path))
        return;
      RegeditManageMent regeditManageMent = new RegeditManageMent();
      regeditManageMent.RegeditKey = Registry.CurrentUser;
      regeditManageMent.RegeditPath = "Control Panel\\desktop";
      regeditManageMent.SetStringValue("TileWallpaper", "0");
      regeditManageMent.SetStringValue("WallpaperStyle", "0");
      WindowsAPI.SystemParametersInfo(20U, 0U, path, 1U);
    }

    public void SetWallpaperB(string path)
    {
      if (!File.Exists(path))
        return;
      RegeditManageMent regeditManageMent = new RegeditManageMent();
      regeditManageMent.RegeditKey = Registry.CurrentUser;
      regeditManageMent.RegeditPath = "Control Panel\\desktop";
      regeditManageMent.SetStringValue("TileWallpaper", "1");
      regeditManageMent.SetStringValue("WallpaperStyle", "0");
      WindowsAPI.SystemParametersInfo(20U, 0U, path, 1U);
    }

    public void SetWallpaperC(string path)
    {
      if (!File.Exists(path))
        return;
      RegeditManageMent regeditManageMent = new RegeditManageMent();
      regeditManageMent.RegeditKey = Registry.CurrentUser;
      regeditManageMent.RegeditPath = "Control Panel\\desktop";
      regeditManageMent.SetStringValue("TileWallpaper", "0");
      regeditManageMent.SetStringValue("WallpaperStyle", "2");
      WindowsAPI.SystemParametersInfo(20U, 0U, path, 1U);
    }

    public Point CenterPoint(IntPtr hwnd)
    {
      Size windowSize = this.GetWindowSize(hwnd);
      Size screenSize = this.GetScreenSize();
      return new Point((screenSize.Width - windowSize.Width) / 2, (screenSize.Height - windowSize.Height) / 2 - 14);
    }

    public Point CenterPoint(Size size)
    {
      Size screenSize = this.GetScreenSize();
      return new Point((screenSize.Width - size.Width) / 2, (screenSize.Height - size.Height) / 2 - 14);
    }

    public RECT GetRect(IntPtr hwnd)
    {
      RECT lpRect = new RECT();
      WindowsAPI.GetWindowRect(hwnd, ref lpRect);
      return lpRect;
    }

    public void ArrangeWindowsA(IntPtr hwnd)
    {
      RECT rect = this.GetRect(hwnd);
      uint cKids = (uint) this.GetAllChildControls(hwnd).Length;
      WindowsAPI.CascadeWindows(IntPtr.Zero, 2U, ref rect, cKids, IntPtr.Zero);
    }

    public void ArrangeWindowsB(IntPtr hwnd)
    {
      RECT rect = this.GetRect(hwnd);
      uint cKids = (uint) this.GetAllChildControls(hwnd).Length;
      WindowsAPI.CascadeWindows(IntPtr.Zero, 4U, ref rect, cKids, IntPtr.Zero);
    }

    public void ArrangeWindowsC(IntPtr hwnd)
    {
      RECT rect = this.GetRect(hwnd);
      uint cKids = (uint) this.GetAllChildControls(hwnd).Length;
      WindowsAPI.TileWindows(IntPtr.Zero, 1U, ref rect, cKids, IntPtr.Zero);
    }

    public void ArrangeWindowsD(IntPtr hwnd)
    {
      RECT rect = this.GetRect(hwnd);
      uint cKids = (uint) this.GetAllChildControls(hwnd).Length;
      WindowsAPI.TileWindows(IntPtr.Zero, 0U, ref rect, cKids, IntPtr.Zero);
    }

    public int GetMinimizeCount(IntPtr hwnd)
    {
      return Convert.ToInt32(WindowsAPI.ArrangeIconicWindows(this.DeskHwnd));
    }

    public void CreateWindowEx(IntPtr hwnd)
    {
      WindowsAPI.CreateWindowEx(0, "button", "API", 1342177280, 320, 10, 75, 23, hwnd, IntPtr.Zero, WindowsAPI.GetModuleHandle(this.GetExecutePath(hwnd)), IntPtr.Zero);
    }

    public void ControlSound()
    {
      WindowsAPI.waveOutSetVolume(IntPtr.Zero, -1L);
      long dwVolume;
      WindowsAPI.waveOutGetVolume(IntPtr.Zero, out dwVolume);
      int num = int.Parse(string.Format("{0:X}", (object) dwVolume).PadLeft(8, '0').Substring(0, 4), NumberStyles.HexNumber);
      if (num >= (int) ushort.MaxValue)
        return;
      string str = (num + 655).ToString();
      str.PadLeft(4, '0');
      string s = str + str;
      WindowsAPI.waveOutSetVolume(IntPtr.Zero, long.Parse(s, NumberStyles.HexNumber));
    }

    public void WinExec(ControlPanel cp)
    {
      switch (cp)
      {
        case ControlPanel.辅助功能选项:
          int num1 = (int) WindowsAPI.WinExec("rundll32.exe shell32.dll,Control_RunDLL access.cpl", 5U);
          break;
        case ControlPanel.添加或删除程序:
          int num2 = (int) WindowsAPI.WinExec("rundll32.exe shell32.dll,Control_RunDLL appwiz.cpl", 5U);
          break;
        case ControlPanel.显示属性:
          int num3 = (int) WindowsAPI.WinExec("rundll32.exe shell32.dll,Control_RunDLL desk.cpl", 5U);
          break;
        case ControlPanel.Windows防火墙:
          int num4 = (int) WindowsAPI.WinExec("rundll32.exe shell32.dll,Control_RunDLL firewall.cpl", 5U);
          break;
        case ControlPanel.添加硬件向导:
          int num5 = (int) WindowsAPI.WinExec("rundll32.exe shell32.dll,Control_RunDLL hdwwiz.cpl", 5U);
          break;
        case ControlPanel.Internet属性:
          int num6 = (int) WindowsAPI.WinExec("rundll32.exe shell32.dll,Control_RunDLL inetcpl.cpl", 5U);
          break;
        case ControlPanel.区域和语言选项:
          int num7 = (int) WindowsAPI.WinExec("rundll32.exe shell32.dll,Control_RunDLL intl.cpl", 5U);
          break;
        case ControlPanel.游戏控制器:
          int num8 = (int) WindowsAPI.WinExec("rundll32.exe shell32.dll,Control_RunDLL joy.cpl", 5U);
          break;
        case ControlPanel.鼠标属性:
          int num9 = (int) WindowsAPI.WinExec("rundll32.exe shell32.dll,Control_RunDLL main.cpl", 5U);
          break;
        case ControlPanel.声音和音频设备属性:
          int num10 = (int) WindowsAPI.WinExec("rundll32.exe shell32.dll,Control_RunDLL mmsys.cpl", 5U);
          break;
        case ControlPanel.网络连接:
          int num11 = (int) WindowsAPI.WinExec("rundll32.exe shell32.dll,Control_RunDLL ncpa.cpl", 5U);
          break;
        case ControlPanel.网络安装向导:
          int num12 = (int) WindowsAPI.WinExec("rundll32.exe shell32.dll,Control_RunDLL netsetup.cpl", 5U);
          break;
        case ControlPanel.用户账户:
          int num13 = (int) WindowsAPI.WinExec("rundll32.exe shell32.dll,Control_RunDLL nusrmgr.cpl", 5U);
          break;
        case ControlPanel.ODBC数据元管理器:
          int num14 = (int) WindowsAPI.WinExec("rundll32.exe shell32.dll,Control_RunDLL odbccp32.cpl", 5U);
          break;
        case ControlPanel.电源选项:
          int num15 = (int) WindowsAPI.WinExec("rundll32.exe shell32.dll,Control_RunDLL powercfg.cpl", 5U);
          break;
        case ControlPanel.系统属性:
          int num16 = (int) WindowsAPI.WinExec("rundll32.exe shell32.dll,Control_RunDLL sysdm.cpl", 5U);
          break;
        case ControlPanel.位置信息:
          int num17 = (int) WindowsAPI.WinExec("rundll32.exe shell32.dll,Control_RunDLL telephon.cpl", 5U);
          break;
        case ControlPanel.日期和时间属性:
          int num18 = (int) WindowsAPI.WinExec("rundll32.exe shell32.dll,Control_RunDLL timedate.cpl", 5U);
          break;
        case ControlPanel.Windows安全中心:
          int num19 = (int) WindowsAPI.WinExec("rundll32.exe shell32.dll,Control_RunDLL wscui.cpl", 5U);
          break;
        case ControlPanel.自动更新:
          int num20 = (int) WindowsAPI.WinExec("rundll32.exe shell32.dll,Control_RunDLL wuaucpl.cpl", 5U);
          break;
      }
    }

    public void ShellExecute(ControlPanel cp)
    {
      SHELLEXECUTEINFO lpExecInfo = new SHELLEXECUTEINFO();
      lpExecInfo.cbSize = Marshal.SizeOf((object) lpExecInfo);
      lpExecInfo.lpFile = "rundll32.exe";
      switch (cp)
      {
        case ControlPanel.辅助功能选项:
          lpExecInfo.lpParameters = "shell32.dll,Control_RunDLL access.cpl";
          WindowsAPI.ShellExecuteEx(ref lpExecInfo);
          break;
        case ControlPanel.添加或删除程序:
          lpExecInfo.lpParameters = "shell32.dll,Control_RunDLL appwiz.cpl";
          WindowsAPI.ShellExecuteEx(ref lpExecInfo);
          break;
        case ControlPanel.显示属性:
          lpExecInfo.lpParameters = "shell32.dll,Control_RunDLL desk.cpl";
          WindowsAPI.ShellExecuteEx(ref lpExecInfo);
          break;
        case ControlPanel.Windows防火墙:
          lpExecInfo.lpParameters = "shell32.dll,Control_RunDLL firewall.cpl";
          WindowsAPI.ShellExecuteEx(ref lpExecInfo);
          break;
        case ControlPanel.添加硬件向导:
          lpExecInfo.lpParameters = "shell32.dll,Control_RunDLL hdwwiz.cpl";
          WindowsAPI.ShellExecuteEx(ref lpExecInfo);
          break;
        case ControlPanel.Internet属性:
          lpExecInfo.lpParameters = "shell32.dll,Control_RunDLL inetcpl.cpl";
          WindowsAPI.ShellExecuteEx(ref lpExecInfo);
          break;
        case ControlPanel.区域和语言选项:
          lpExecInfo.lpParameters = "shell32.dll,Control_RunDLL intl.cpl";
          WindowsAPI.ShellExecuteEx(ref lpExecInfo);
          break;
        case ControlPanel.游戏控制器:
          lpExecInfo.lpParameters = "shell32.dll,Control_RunDLL joy.cpl";
          WindowsAPI.ShellExecuteEx(ref lpExecInfo);
          break;
        case ControlPanel.鼠标属性:
          lpExecInfo.lpParameters = "shell32.dll,Control_RunDLL main.cpl";
          WindowsAPI.ShellExecuteEx(ref lpExecInfo);
          break;
        case ControlPanel.声音和音频设备属性:
          lpExecInfo.lpParameters = "shell32.dll,Control_RunDLL mmsys.cpl";
          WindowsAPI.ShellExecuteEx(ref lpExecInfo);
          break;
        case ControlPanel.网络连接:
          lpExecInfo.lpParameters = "shell32.dll,Control_RunDLL ncpa.cpl";
          WindowsAPI.ShellExecuteEx(ref lpExecInfo);
          break;
        case ControlPanel.网络安装向导:
          lpExecInfo.lpParameters = "shell32.dll,Control_RunDLL netsetup.cpl";
          WindowsAPI.ShellExecuteEx(ref lpExecInfo);
          break;
        case ControlPanel.用户账户:
          lpExecInfo.lpParameters = "shell32.dll,Control_RunDLL nusrmgr.cpl";
          WindowsAPI.ShellExecuteEx(ref lpExecInfo);
          break;
        case ControlPanel.ODBC数据元管理器:
          lpExecInfo.lpParameters = "shell32.dll,Control_RunDLL odbccp32.cpl";
          WindowsAPI.ShellExecuteEx(ref lpExecInfo);
          break;
        case ControlPanel.电源选项:
          lpExecInfo.lpParameters = "shell32.dll,Control_RunDLL powercfg.cpl";
          WindowsAPI.ShellExecuteEx(ref lpExecInfo);
          break;
        case ControlPanel.系统属性:
          lpExecInfo.lpParameters = "shell32.dll,Control_RunDLL sysdm.cpl";
          WindowsAPI.ShellExecuteEx(ref lpExecInfo);
          break;
        case ControlPanel.位置信息:
          lpExecInfo.lpParameters = "shell32.dll,Control_RunDLL telephon.cpl";
          WindowsAPI.ShellExecuteEx(ref lpExecInfo);
          break;
        case ControlPanel.日期和时间属性:
          lpExecInfo.lpParameters = "shell32.dll,Control_RunDLL timedate.cpl";
          WindowsAPI.ShellExecuteEx(ref lpExecInfo);
          break;
        case ControlPanel.Windows安全中心:
          lpExecInfo.lpParameters = "shell32.dll,Control_RunDLL wscui.cpl";
          WindowsAPI.ShellExecuteEx(ref lpExecInfo);
          break;
        case ControlPanel.自动更新:
          lpExecInfo.lpParameters = "shell32.dll,Control_RunDLL wuaucpl.cpl";
          WindowsAPI.ShellExecuteEx(ref lpExecInfo);
          break;
      }
    }

    public IntPtr RunProgram(string exename, string dir)
    {
      SHELLEXECUTEINFO lpExecInfo = new SHELLEXECUTEINFO();
      lpExecInfo.cbSize = Marshal.SizeOf((object) lpExecInfo);
      lpExecInfo.fMask = 12;
      lpExecInfo.dwHotKey = 0;
      lpExecInfo.lpClass = (string) null;
      lpExecInfo.lpDirectory = dir;
      lpExecInfo.lpFile = exename;
      lpExecInfo.lpIDList = new IntPtr(0);
      lpExecInfo.lpParameters = (string) null;
      lpExecInfo.lpVerb = "open";
      lpExecInfo.nShow = 5;
      WindowsAPI.ShellExecuteEx(ref lpExecInfo);
      return lpExecInfo.hwnd;
    }

    public bool SwapMouseButton()
    {
      return WindowsAPI.GetSystemMetrics(23) != 0;
    }

    public IntPtr FirstChildIntPtr(IntPtr hwnd)
    {
      return WindowsAPI.GetWindow(hwnd, 5U);
    }

    public IntPtr GetTaskBar()
    {
      return WindowsAPI.FindWindowEx(WindowsAPI.FindWindowEx(WindowsAPI.FindWindowEx(WindowsAPI.FindWindowEx(WindowsAPI.GetDesktopWindow(), IntPtr.Zero, "Shell_TrayWnd", (string) null), IntPtr.Zero, "ReBarWindow32", (string) null), IntPtr.Zero, "MSTaskSwWClass", (string) null), IntPtr.Zero, "ToolbarWindow32", (string) null);
    }

    public void EmptyRecycleBin()
    {
      WindowsAPI.SHEmptyRecycleBin(IntPtr.Zero, (string) null, 0);
    }

    public WindowInfo[] GetAllDesktopWindows()
    {
      List<WindowInfo> wndList = new List<WindowInfo>();
      WindowsAPI.EnumWindows((WindowsAPI.WNDENUMPROC) ((hWnd, lParam) =>
      {
        WindowInfo windowInfo = new WindowInfo();
        StringBuilder stringBuilder = new StringBuilder(512);
        windowInfo.hWnd = hWnd;
        WindowsAPI.GetWindowTextW(hWnd, stringBuilder, stringBuilder.Capacity);
        windowInfo.szWindowName = stringBuilder.ToString();
        WindowsAPI.GetClassNameW(hWnd, stringBuilder, stringBuilder.Capacity);
        windowInfo.szClassName = stringBuilder.ToString();
        wndList.Add(windowInfo);
        return true;
      }), 0);
      return wndList.ToArray();
    }

    public WINDOWINFO[] GetAllDesktopWindowsEx()
    {
      List<WINDOWINFO> wndList = new List<WINDOWINFO>();
      WindowsAPI.EnumWindows((WindowsAPI.WNDENUMPROC) ((hWnd, lParam) =>
      {
        WINDOWINFO pwi = new WINDOWINFO();
        pwi.cbSize = Marshal.SizeOf((object) pwi);
        StringBuilder stringBuilder = new StringBuilder(512);
        WindowsAPI.GetWindowInfo(hWnd, ref pwi);
        pwi.hWnd = hWnd;
        WindowsAPI.GetWindowTextW(hWnd, stringBuilder, stringBuilder.Capacity);
        pwi.szWindowName = stringBuilder.ToString();
        WindowsAPI.GetClassNameW(hWnd, stringBuilder, stringBuilder.Capacity);
        pwi.szClassName = stringBuilder.ToString();
        pwi.szExePath = this.GetExecutePath(pwi.hWnd);
        wndList.Add(pwi);
        return true;
      }), 0);
      return wndList.ToArray();
    }

    public IntPtr[] GetAllDesktopWindowsHandle()
    {
      List<IntPtr> wndList = new List<IntPtr>();
      WindowsAPI.EnumWindows((WindowsAPI.WNDENUMPROC) ((hWnd, lParam) =>
      {
        wndList.Add(hWnd);
        return true;
      }), 0);
      return wndList.ToArray();
    }

    public WindowInfo[] GetAllChildControls(IntPtr phwnd)
    {
      WindowsAPI.ChildWindowsProc lpEnumFunc = new WindowsAPI.ChildWindowsProc(this.EnumWinowsChildPro);
      WindowsAPI.EnumChildWindows(phwnd, lpEnumFunc, 0);
      return this.childList.ToArray();
    }

    public WindowInfo[] GetAllChildControlsW(IntPtr phwnd)
    {
      List<WindowInfo> child = new List<WindowInfo>();
      WindowsAPI.EnumChildWindows(phwnd, (WindowsAPI.ChildWindowsProc) ((hWnd, lParam) =>
      {
        WindowInfo windowInfo = new WindowInfo();
        StringBuilder stringBuilder = new StringBuilder(512);
        windowInfo.hWnd = hWnd;
        WindowsAPI.GetWindowTextW(hWnd, stringBuilder, stringBuilder.Capacity);
        windowInfo.szWindowName = stringBuilder.ToString();
        WindowsAPI.GetClassNameW(hWnd, stringBuilder, stringBuilder.Capacity);
        windowInfo.szClassName = stringBuilder.ToString();
        child.Add(windowInfo);
        return true;
      }), 0);
      return child.ToArray();
    }

    public WINDOWINFO[] GetAllChildControlsEx(IntPtr phwnd)
    {
      List<WINDOWINFO> child = new List<WINDOWINFO>();
      WindowsAPI.EnumChildWindows(phwnd, (WindowsAPI.ChildWindowsProc) ((hWnd, lParam) =>
      {
        WINDOWINFO pwi = new WINDOWINFO();
        pwi.cbSize = Marshal.SizeOf((object) pwi);
        StringBuilder stringBuilder = new StringBuilder(512);
        WindowsAPI.GetWindowInfo(hWnd, ref pwi);
        pwi.hWnd = hWnd;
        WindowsAPI.GetWindowTextW(hWnd, stringBuilder, stringBuilder.Capacity);
        pwi.szWindowName = stringBuilder.ToString();
        WindowsAPI.GetClassNameW(hWnd, stringBuilder, stringBuilder.Capacity);
        pwi.szClassName = stringBuilder.ToString();
        pwi.szExePath = this.GetExecutePath(pwi.hWnd);
        child.Add(pwi);
        return true;
      }), 0);
      return child.ToArray();
    }

    public IntPtr[] GetAllChildControlsHandle(IntPtr phwnd)
    {
      List<IntPtr> child = new List<IntPtr>();
      WindowsAPI.EnumChildWindows(phwnd, (WindowsAPI.ChildWindowsProc) ((hWnd, lParam) =>
      {
        child.Add(hWnd);
        return true;
      }), 0);
      return child.ToArray();
    }

    private bool EnumWinowsChildPro(IntPtr hWnd, int lParam)
    {
      WindowInfo windowInfo = new WindowInfo();
      StringBuilder stringBuilder = new StringBuilder(512);
      windowInfo.hWnd = hWnd;
      WindowsAPI.GetWindowTextW(hWnd, stringBuilder, stringBuilder.Capacity);
      windowInfo.szWindowName = stringBuilder.ToString();
      WindowsAPI.GetClassNameW(hWnd, stringBuilder, stringBuilder.Capacity);
      windowInfo.szClassName = stringBuilder.ToString();
      this.childList.Add(windowInfo);
      return true;
    }

    public int[] GetAllProcesses(IntPtr handle)
    {
      int pBytesReturned = 0;
      int[] pProcessIds = new int[256];
      WindowsAPI.EnumProcesses(pProcessIds, 256, ref pBytesReturned);
      ArrayList arrayList = new ArrayList((ICollection) pProcessIds);
      while (arrayList.IndexOf((object) 0) != -1)
        arrayList.Remove((object) 0);
      Array array = (Array) arrayList.ToArray();
      int[] numArray = new int[array.Length];
      array.CopyTo((Array) numArray, 0);
      return numArray;
    }

    public IntPtr[] GetAllProcessModules(IntPtr handle)
    {
      int IDProcess = 0;
      IntPtr[] lphModule = new IntPtr[256];
      WindowsAPI.GetWindowThreadProcessId(handle, ref IDProcess);
      WindowsAPI.EnumProcessModules(WindowsAPI.OpenProcess(1040, false, IDProcess), lphModule, 256, ref IDProcess);
      ArrayList arrayList = new ArrayList((ICollection) lphModule);
      while (arrayList.IndexOf((object) IntPtr.Zero) != -1)
        arrayList.Remove((object) IntPtr.Zero);
      Array array = (Array) arrayList.ToArray();
      IntPtr[] numArray = new IntPtr[array.Length];
      array.CopyTo((Array) numArray, 0);
      return numArray;
    }

    public void APIProcess(string path)
    {
      STARTUPINFO lpStartupInfo = new STARTUPINFO();
      PROCESS_INFORMATION lpProcessInformation = new PROCESS_INFORMATION();
      if (!WindowsAPI.CreateProcess((StringBuilder) null, new StringBuilder(path), (SECURITY_ATTRIBUTES) null, (SECURITY_ATTRIBUTES) null, false, 0, (StringBuilder) null, (StringBuilder) null, ref lpStartupInfo, ref lpProcessInformation))
        throw new Exception("调用失败");
      int lpExitCode = 0;
      WindowsAPI.GetExitCodeProcess(lpProcessInformation.hProcess, ref lpExitCode);
      WindowsAPI.TerminateProcess(lpProcessInformation.hProcess, lpExitCode);
      WindowsAPI.CloseHandle(lpProcessInformation.hProcess);
      WindowsAPI.CloseHandle(lpProcessInformation.hThread);
    }

    public DateTime GetPorcessCreationTime()
    {
      IntPtr currentIntPtr = this.GetCurrentIntPtr();
      int lpdwProcessId = 0;
      WindowsAPI.GetWindowThreadProcessId(currentIntPtr, ref lpdwProcessId);
      IntPtr hProcess = WindowsAPI.OpenProcess(1040, false, lpdwProcessId);
      _FILETIME lpCreationTime = new _FILETIME();
      _FILETIME lpExitTime = new _FILETIME();
      _FILETIME lpKernelTime = new _FILETIME();
      _FILETIME lpUserTime = new _FILETIME();
      WindowsAPI.GetProcessTimes(hProcess, ref lpCreationTime, ref lpExitTime, ref lpKernelTime, ref lpUserTime);
      return this.FileTimeToWindowsTimeEx(lpCreationTime);
    }

    public DateTime GetPorcessCreationTime(IntPtr hwnd)
    {
      int lpdwProcessId = 0;
      WindowsAPI.GetWindowThreadProcessId(hwnd, ref lpdwProcessId);
      hwnd = WindowsAPI.OpenProcess(1040, false, lpdwProcessId);
      _FILETIME lpCreationTime = new _FILETIME();
      _FILETIME lpExitTime = new _FILETIME();
      _FILETIME lpKernelTime = new _FILETIME();
      _FILETIME lpUserTime = new _FILETIME();
      WindowsAPI.GetProcessTimes(hwnd, ref lpCreationTime, ref lpExitTime, ref lpKernelTime, ref lpUserTime);
      return this.FileTimeToWindowsTimeEx(lpCreationTime);
    }

    public string GetProcessRunTime(IntPtr hwnd)
    {
      DateTime porcessCreationTime = this.GetPorcessCreationTime(hwnd);
      int num = (DateTime.Now.Hour - porcessCreationTime.Hour) * 60 * 60 * 1000 + (DateTime.Now.Minute - porcessCreationTime.Minute) * 60 * 1000 + (DateTime.Now.Second - porcessCreationTime.Second) * 1000;
      return (num / 1000 / 60 / 60 % 24).ToString().PadLeft(2, '0') + "小时" + (num / 1000 / 60 % 60).ToString().PadLeft(2, '0') + "分" + (num / 1000 % 60).ToString().PadLeft(2, '0') + "秒";
    }

    public WINDOWINFO GetWindowInfo(IntPtr hwnd)
    {
      WINDOWINFO pwi = new WINDOWINFO();
      pwi.cbSize = Marshal.SizeOf((object) pwi);
      WindowsAPI.GetWindowInfo(hwnd, ref pwi);
      return pwi;
    }

    public int GetWindowBorder(IntPtr hwnd)
    {
      WINDOWINFO pwi = new WINDOWINFO();
      pwi.cbSize = Marshal.SizeOf((object) pwi);
      WindowsAPI.GetWindowInfo(hwnd, ref pwi);
      return Convert.ToInt32(pwi.cxWindowBorders);
    }

    public int GetWindowThreadProcessId(IntPtr hwnd)
    {
      int lpdwProcessId = 0;
      WindowsAPI.GetWindowThreadProcessId(hwnd, ref lpdwProcessId);
      return lpdwProcessId;
    }

    public ProcessInfo ProcessInfo(IntPtr hwnd)
    {
      ProcessInfo processInfo = new ProcessInfo();
      WINDOWINFO windowInfo = this.GetWindowInfo(hwnd);
      processInfo.hwnd = hwnd;
      processInfo.csize = this.GetWindowClientSize(hwnd);
      processInfo.location = this.GetLocation(hwnd);
      processInfo.wsize = this.GetWindowSize(hwnd);
      processInfo.WindowText = this.GetWindowText(hwnd);
      processInfo.ClassName = this.GetClassName(hwnd);
      processInfo.cxWindowBorders = windowInfo.cxWindowBorders;
      processInfo.cyWindowBorders = windowInfo.cyWindowBorders;
      processInfo.dwExStyle = windowInfo.dwExStyle;
      processInfo.dwStyle = windowInfo.dwStyle;
      processInfo.id = this.GetWindowThreadProcessId(hwnd);
      processInfo.text = this.GetControlText(hwnd);
      processInfo.starttime = this.GetPorcessCreationTime(hwnd);
      processInfo.runtime = this.GetProcessRunTime(hwnd);
      processInfo.path = this.GetExecutePath(hwnd);
      processInfo.processsize = this.GetFileSize(processInfo.path);
      processInfo.phwnd = WindowsAPI.GetParent(hwnd);
      return processInfo;
    }

    public void RestrictCursor(IntPtr handle)
    {
      RECT lpRect = new RECT();
      WindowsAPI.GetWindowRect(handle, ref lpRect);
      WindowsAPI.ClipCursor(ref lpRect);
    }

    public void ReleaseCursor()
    {
      RECT lpRect = new RECT();
      WindowsAPI.GetWindowRect(WindowsAPI.GetDesktopWindow(), ref lpRect);
      WindowsAPI.ClipCursor(ref lpRect);
    }

    public void IsShowCursor(bool bshow)
    {
      WindowsAPI.ShowCursor(bshow);
    }

    public CPUInformation CPUInfo()
    {
      CPUInformation cpuInformation = new CPUInformation();
      cpuInformation.core = 0U;
      cpuInformation.level2 = 0U;
      cpuInformation.type = "";
      try
      {
        SYSTEM_INFO lpSystemInfo = new SYSTEM_INFO();
        WindowsAPI.GetSystemInfo(ref lpSystemInfo);
        cpuInformation.core = lpSystemInfo.dwNumberOfProcessors;
        cpuInformation.level2 = lpSystemInfo.dwPageSize;
        Decimal d = (Decimal) (lpSystemInfo.lpMaximumApplicationAddress / 1024U / 1024U);
        cpuInformation.masterfrequency = (uint) Math.Round(d, 0);
        uint num = lpSystemInfo.dwProcessorType;
        if (num <= 486U)
        {
          if ((int) num == 386)
          {
            cpuInformation.type = "Intel 386";
            goto label_14;
          }
          else if ((int) num == 486)
          {
            cpuInformation.type = "Intel 486";
            goto label_14;
          }
        }
        else if ((int) num == 586)
        {
          cpuInformation.type = "Intel Pentium";
          goto label_14;
        }
        else if ((int) num == 4000)
        {
          cpuInformation.type = "MIPS R4000";
          goto label_14;
        }
        else if ((int) num == 21064)
        {
          cpuInformation.type = "DEC Alpha 21064";
          goto label_14;
        }
        cpuInformation.type = "(unknown)";
      }
      catch
      {
      }
label_14:
      return cpuInformation;
    }

    public MemoryInformation MemoryInfo()
    {
      MEMORYSTATUS lpBuffer = new MEMORYSTATUS();
      WindowsAPI.GlobalMemoryStatus(ref lpBuffer);
      return new MemoryInformation()
      {
        AvailablePageFile = (double) (lpBuffer.dwAvailPageFile / 1024U / 1024U),
        AvailablePhysicalMemory = (double) (lpBuffer.dwAvailPhys / 1024U / 1024U),
        AvailableVirtualMemory = (double) (lpBuffer.dwAvailVirtual / 1024U / 1024U),
        SizeofStructure = lpBuffer.dwLength,
        MemoryInUse = (double) lpBuffer.dwMemoryLoad,
        TotalPageSize = (double) (lpBuffer.dwTotalPageFile / 1024U / 1024U),
        TotalPhysicalMemory = (double) (lpBuffer.dwTotalPhys / 1024U / 1024U),
        TotalVirtualMemory = (double) (lpBuffer.dwTotalVirtual / 1024U / 1024U)
      };
    }

    public void DynamicDebug()
    {
      IntPtr num1 = WindowsAPI.LoadLibrary("Kernel32.dll");
      int num2 = (Marshal.GetDelegateForFunctionPointer(WindowsAPI.GetProcAddress(num1, "Beep"), typeof (APIMethod.Delegate_Beep)) as APIMethod.Delegate_Beep)(100U, 100U) ? 1 : 0;
      WindowsAPI.FreeLibrary(num1);
    }

    public float GetCharWidth(IntPtr handle, char char1, char char2)
    {
      float pxBuffer = 0.0f;
      int lpBuffer = 0;
      IntPtr dc = WindowsAPI.GetDC(handle);
      WindowsAPI.GetCharWidthFloatA(dc, (uint) char1, (uint) char2, ref pxBuffer);
      WindowsAPI.GetCharWidth32A(dc, (uint) char1, (uint) char2, ref lpBuffer);
      return pxBuffer;
    }

    public DISPLAY_DEVICE EnumDisplayDevices()
    {
      DISPLAY_DEVICE lpDisplayDevice = new DISPLAY_DEVICE();
      lpDisplayDevice.cb = Marshal.SizeOf((object) lpDisplayDevice);
      WindowsAPI.EnumDisplayDevices((string) null, 0, ref lpDisplayDevice, 1);
      return lpDisplayDevice;
    }

    public string DisplayDeviceName()
    {
      DISPLAY_DEVICE lpDisplayDevice = new DISPLAY_DEVICE();
      lpDisplayDevice.cb = Marshal.SizeOf((object) lpDisplayDevice);
      WindowsAPI.EnumDisplayDevices((string) null, 0, ref lpDisplayDevice, 1);
      return lpDisplayDevice.DeviceName;
    }

    public DateTime FileTimeToWindowsTime(_FILETIME time)
    {
      IntPtr num1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (_FILETIME)));
      IntPtr num2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (SYSTEMTIME)));
      Marshal.StructureToPtr((object) time, num1, true);
      WindowsAPI.FileTimeToSystemTime(num1, num2);
      SYSTEMTIME systemtime = (SYSTEMTIME) Marshal.PtrToStructure(num2, typeof (SYSTEMTIME));
      return DateTime.Parse(systemtime.wYear.ToString() + "/" + systemtime.wMonth.ToString() + "/" + systemtime.wDay.ToString() + " " + systemtime.wHour.ToString() + ":" + systemtime.wMinute.ToString() + ":" + systemtime.wSecond.ToString());
    }

    public DateTime FileTimeToWindowsTimeEx(_FILETIME time)
    {
      _FILETIME lpLocalTime = new _FILETIME();
      IntPtr num1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (_FILETIME)));
      IntPtr num2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (SYSTEMTIME)));
      WindowsAPI.FileTimeToLocalFileTime(ref time, out lpLocalTime);
      time = lpLocalTime;
      Marshal.StructureToPtr((object) time, num1, true);
      WindowsAPI.FileTimeToSystemTime(num1, num2);
      SYSTEMTIME systemtime = (SYSTEMTIME) Marshal.PtrToStructure(num2, typeof (SYSTEMTIME));
      return DateTime.Parse(systemtime.wYear.ToString() + "/" + systemtime.wMonth.ToString() + "/" + systemtime.wDay.ToString() + " " + systemtime.wHour.ToString() + ":" + systemtime.wMinute.ToString() + ":" + systemtime.wSecond.ToString());
    }

    public _FILETIME WindowsTimeToFileTime(DateTime dt)
    {
        _FILETIME result = default(_FILETIME);
        _FILETIME fILETIME = default(_FILETIME);
        SYSTEMTIME sYSTEMTIME = default(SYSTEMTIME);
        sYSTEMTIME.wDay = (ushort)dt.Day;
        sYSTEMTIME.wDayOfWeek = (ushort)dt.DayOfWeek;
        sYSTEMTIME.wHour = (ushort)dt.Hour;
        sYSTEMTIME.wMilliseconds = (ushort)dt.Millisecond;
        sYSTEMTIME.wMinute = (ushort)dt.Minute;
        sYSTEMTIME.wMonth = (ushort)dt.Month;
        sYSTEMTIME.wSecond = (ushort)dt.Second;
        sYSTEMTIME.wYear = (ushort)dt.Year;
        WindowsAPI.SystemTimeToFileTime(ref sYSTEMTIME, out fILETIME);
        WindowsAPI.LocalFileTimeToFileTime(ref fILETIME, out result);
        return result;
    }

    public SYSTEMTIME WindowsTimeToSystemTime(DateTime dt)
    {
      return new SYSTEMTIME()
      {
        wDay = (ushort) dt.Day,
        wDayOfWeek = (ushort) dt.DayOfWeek,
        wHour = (ushort) dt.Hour,
        wMilliseconds = (ushort) dt.Millisecond,
        wMinute = (ushort) dt.Minute,
        wMonth = (ushort) dt.Month,
        wSecond = (ushort) dt.Second,
        wYear = (ushort) dt.Year
      };
    }

    public DateTime SystemTimeToWindowsTime(SYSTEMTIME st)
    {
      return DateTime.Parse(st.wYear.ToString() + "/" + st.wMonth.ToString() + "/" + st.wDay.ToString() + " " + st.wHour.ToString() + ":" + st.wMinute.ToString() + ":" + st.wSecond.ToString());
    }

    public string GetRunTime()
    {
      int tickCount = WindowsAPI.GetTickCount();
      return (tickCount / 1000 / 60 / 60 / 24).ToString().PadLeft(2, '0') + "天" + (tickCount / 1000 / 60 / 60 % 24).ToString().PadLeft(2, '0') + "小时" + (tickCount / 1000 / 60 % 60).ToString().PadLeft(2, '0') + "分" + (tickCount / 1000 % 60).ToString().PadLeft(2, '0') + "秒";
    }

    public IntPtr GetFileHandleOpenFile(string path)
    {
      path = Path.GetFullPath(path);
      OFSTRUCT lpReOpenBuff = new OFSTRUCT();
      lpReOpenBuff.cBytes = (byte) Marshal.SizeOf((object) lpReOpenBuff);
      return WindowsAPI.OpenFile(path, ref lpReOpenBuff, 2U);
    }

    public IntPtr GetFileHandleOpenFileEx(string path)
    {
      path = Path.GetFullPath(path);
      OFSTRUCT lpReOpenBuff = new OFSTRUCT();
      lpReOpenBuff.cBytes = (byte) Marshal.SizeOf((object) lpReOpenBuff);
      return WindowsAPI.OpenFile(path, ref lpReOpenBuff, 1073741824U);
    }

    public IntPtr GetFileHandleCreateFile(string path)
    {
      path = Path.GetFullPath(path);
      IntPtr file = WindowsAPI.CreateFile(path, 1U, 3, 0, 4, 128U, 0);
      WindowsAPI.CloseHandle(file);
      return file;
    }

    public int RenameFile(string path, string newname)
    {
      path = Path.GetFullPath(path);
      string fullPath = Path.GetFullPath(newname);
      if (Path.GetDirectoryName(path) != Path.GetDirectoryName(fullPath))
        newname = Path.GetDirectoryName(path) + "\\" + Path.GetFileName(newname);
      return WindowsAPI.SHFileOperation(new _SHFILEOPSTRUCT()
      {
        wFunc = 4U,
        pFrom = path + (object) char.MinValue,
        pTo = newname,
        fFlags = (ushort) 80
      });
    }

    public bool SetWindowsTime(DateTime dt)
    {
        SYSTEMTIME sYSTEMTIME = default(SYSTEMTIME);
        sYSTEMTIME.wDay = (ushort)dt.Day;
        sYSTEMTIME.wDayOfWeek = (ushort)dt.DayOfWeek;
        sYSTEMTIME.wHour = (ushort)(dt.Hour % 24 - 8);
        sYSTEMTIME.wMilliseconds = (ushort)dt.Millisecond;
        sYSTEMTIME.wMinute = (ushort)dt.Minute;
        sYSTEMTIME.wMonth = (ushort)dt.Month;
        sYSTEMTIME.wSecond = (ushort)dt.Second;
        sYSTEMTIME.wYear = (ushort)dt.Year;
        return WindowsAPI.SetSystemTime(ref sYSTEMTIME);
    }


    public bool SetWindowsTimeEx(DateTime dt)
    {
        SYSTEMTIME sYSTEMTIME = default(SYSTEMTIME);
        sYSTEMTIME.wDay = (ushort)dt.Day;
        sYSTEMTIME.wDayOfWeek = (ushort)dt.DayOfWeek;
        sYSTEMTIME.wHour = (ushort)dt.Hour;
        sYSTEMTIME.wMilliseconds = (ushort)dt.Millisecond;
        sYSTEMTIME.wMinute = (ushort)dt.Minute;
        sYSTEMTIME.wMonth = (ushort)dt.Month;
        sYSTEMTIME.wSecond = (ushort)dt.Second;
        sYSTEMTIME.wYear = (ushort)dt.Year;
        return WindowsAPI.SetLocalTime(ref sYSTEMTIME);
    }

    public void WritePrivateProfileString(string option, object[] caption, object[] text, string path)
    {
      for (int index = 0; index < text.Length; ++index)
        WindowsAPI.WritePrivateProfileString(option, caption[index].ToString(), text[index].ToString(), path);
    }

    public void WritePrivateProfileSection(string option, string text, string path)
    {
      WindowsAPI.WritePrivateProfileSection(option, text, path);
    }

    public string[] GetPrivateProfileStrings(string option, object[] caption, string path)
    {
      StringBuilder lpReturnedString = new StringBuilder((int) short.MaxValue);
      TStringList tstringList = new TStringList();
      for (int index = 0; index < caption.Length; ++index)
      {
        WindowsAPI.GetPrivateProfileString(option, caption[index].ToString(), "", lpReturnedString, lpReturnedString.Capacity, path);
        tstringList.Add(lpReturnedString.ToString());
      }
      return tstringList.Strings;
    }

    public string GetPrivateProfileString(string option, object caption, string path)
    {
      StringBuilder lpReturnedString = new StringBuilder((int) short.MaxValue);
      WindowsAPI.GetPrivateProfileString(option, caption.ToString(), "", lpReturnedString, lpReturnedString.Capacity, path);
      return lpReturnedString.ToString();
    }

    public uint[] GetPrivateProfileInt(string option, object[] caption, string path)
    {
      ArrayList arrayList = new ArrayList();
      for (int index = 0; index < caption.Length; ++index)
        arrayList.Add((object) WindowsAPI.GetPrivateProfileInt(option, caption[index].ToString(), 0, path));
      int count = arrayList.Count;
      uint[] numArray = new uint[count];
      Array.Copy((Array) arrayList.ToArray(), (Array) numArray, count);
      return numArray;
    }

    public string GetPrivateProfileSection(string option, string path)
    {
      StringBuilder lpReturnedString = new StringBuilder((int) short.MaxValue);
      WindowsAPI.GetPrivateProfileSection(option, lpReturnedString, lpReturnedString.Capacity, path);
      return lpReturnedString.ToString();
    }

    public int GetFileSize(string path)
    {
      int lpFileSizeHigh = 0;
      return WindowsAPI.GetFileSize(this.GetFileHandleOpenFileEx(path), ref lpFileSizeHigh);
    }

    public BY_HANDLE_FILE_INFORMATION GetFileInformationByHandle(string path)
    {
      BY_HANDLE_FILE_INFORMATION lpFileInformation = new BY_HANDLE_FILE_INFORMATION();
      WindowsAPI.GetFileInformationByHandle(this.GetFileHandleOpenFile(path), ref lpFileInformation);
      return lpFileInformation;
    }

    public int GetCompressedFileSize(string path)
    {
      int lpFileSizeHigh = 0;
      return WindowsAPI.GetCompressedFileSize("D:\\Paint.rar", ref lpFileSizeHigh);
    }

    public string GetInternetURL(string path)
    {
      AdditionalMethod.ModifyExpandName(ref path, ".url");
      return !File.Exists(path) ? "" : this.GetPrivateProfileString("InternetShortcut", (object) "URL", path);
    }

    public string[] FileFind(string path, string extension)
    {
      WIN32_FIND_DATA wiN32FindData = new WIN32_FIND_DATA();
      TStringList tstringList = new TStringList();
      string[] strArray;
      if (!Directory.Exists(path))
      {
        strArray = tstringList.Strings;
      }
      else
      {
        extension = Path.GetExtension(extension);
        path = Path.GetFullPath(path) + "*" + extension;
        IntPtr firstFile = WindowsAPI.FindFirstFile(path, ref wiN32FindData);
        while (WindowsAPI.FindNextFile(firstFile, ref wiN32FindData))
          tstringList.Add(wiN32FindData.cFileName);
        strArray = tstringList.Strings;
      }
      return strArray;
    }

    public IntPtr LoadImage(string path)
    {
      return WindowsAPI.LoadImage(IntPtr.Zero, path, 0U, 0, 0, 16U);
    }

    public bool APIOpenFileDialog(IntPtr owner, string title, string initialDir, string filter, bool multibutton)
    {
      filter = filter.Replace("|*", "\0*");
      filter = filter.Replace("|", "\0");
      if (filter.Substring(filter.Length - 1, 1) != "\0")
        filter += "\0";
      OPENFILENAME lpofn = new OPENFILENAME();
      if (!Directory.Exists(initialDir))
        initialDir = this.GetWindowsDirectory();
      lpofn.structSize = Marshal.SizeOf((object) lpofn);
      lpofn.filter = filter;
      lpofn.flags = !multibutton ? 524804 : 524800;
      lpofn.dlgOwner = owner;
      lpofn.file = new string(new char[256]);
      lpofn.maxFile = lpofn.file.Length;
      lpofn.fileTitle = new string(new char[64]);
      lpofn.maxFileTitle = lpofn.fileTitle.Length;
      lpofn.initialDir = initialDir;
      lpofn.title = title;
      lpofn.defExt = "txt";
      return WindowsAPI.GetOpenFileName(lpofn);
    }

    public bool APISaveFileDialog(IntPtr owner, string title, string initialDir, string filter)
    {
      filter = filter.Replace("|*", "\0*");
      filter = filter.Replace("|", "\0");
      if (filter.Substring(filter.Length - 1, 1) != "\0")
        filter += "\0";
      OPENFILENAME lpofn = new OPENFILENAME();
      if (!Directory.Exists(initialDir))
        initialDir = this.GetWindowsDirectory();
      lpofn.structSize = Marshal.SizeOf((object) lpofn);
      lpofn.filter = filter;
      lpofn.flags = 524800;
      lpofn.dlgOwner = owner;
      lpofn.file = new string(new char[256]);
      lpofn.maxFile = lpofn.file.Length;
      lpofn.fileTitle = new string(new char[64]);
      lpofn.maxFileTitle = lpofn.fileTitle.Length;
      lpofn.initialDir = initialDir;
      lpofn.title = title;
      lpofn.defExt = "txt";
      return WindowsAPI.GetSaveFileName(ref lpofn);
    }

    public void APIFindDialog(IntPtr hwnd)
    {
      FINDREPLACE lpfr = new FINDREPLACE();
      lpfr.lStructSize = Marshal.SizeOf((object) lpfr);
      lpfr.hwndOwner = hwnd;
      lpfr.Flags = 65537;
      lpfr.lpstrFindWhat = "";
      lpfr.wFindWhatLen = (ushort) 256;
      WindowsAPI.FindText(ref lpfr);
    }

    public void APIReplaceDialog(IntPtr hwnd)
    {
      FINDREPLACE lpfr = new FINDREPLACE();
      lpfr.lStructSize = Marshal.SizeOf((object) lpfr);
      lpfr.hwndOwner = hwnd;
      lpfr.Flags = 65536;
      lpfr.lpstrReplaceWith = "";
      lpfr.wReplaceWithLen = (ushort) 80;
      lpfr.lpstrFindWhat = "";
      lpfr.wFindWhatLen = (ushort) 80;
      WindowsAPI.ReplaceText(ref lpfr);
    }

    public void APIChooseColorDialog(IntPtr hwnd)
    {
      System.Drawing.Color black = System.Drawing.Color.Black;
      int[] numArray = new int[3]
      {
        (int) System.Drawing.Color.Black.A,
        (int) System.Drawing.Color.Black.B,
        (int) System.Drawing.Color.Black.G
      };
      int num1 = (int) System.Drawing.Color.Black.A;
      CHOOSECOLOR lpcc = new CHOOSECOLOR();
      IntPtr num2 = Marshal.AllocCoTaskMem(64);
      try
      {
        Marshal.Copy(numArray, 0, num2, 16);
        lpcc.hwndOwner = hwnd;
        lpcc.rgbResult = ColorTranslator.ToWin32(black);
        lpcc.lpCustColors = num2;
        int num3 = 17;
        lpcc.Flags = num3;
        Marshal.Copy(num2, numArray, 0, 16);
        WindowsAPI.ChooseColor(ref lpcc);
      }
      finally
      {
        Marshal.FreeCoTaskMem(num2);
      }
    }

    public void APIChooseFont(IntPtr hwnd)
    {
        CHOOSEFONT cHOOSEFONT = new CHOOSEFONT();
        LOGFONT lOGFONT = new LOGFONT();
        lOGFONT.lfHeight = 9;
        lOGFONT.lfFaceName = "Arial";
        WindowsAPI.CreateFontIndirect(ref lOGFONT);
        cHOOSEFONT.lStructSize = Marshal.SizeOf(cHOOSEFONT);
        cHOOSEFONT.hwndOwner = hwnd;
        cHOOSEFONT.rgbColors = Color.Black.ToArgb();
        cHOOSEFONT.nFontType = 1024;
        cHOOSEFONT.nSizeMin = 10;
        cHOOSEFONT.nSizeMax = 72;
        WindowsAPI.ChooseFont(ref cHOOSEFONT);
    }

    public void SetControlReadOnly(IntPtr hwnd, bool only)
    {
      int WParam = 1;
      if (!only)
        WParam = 0;
      WindowsAPI.SendMessage(hwnd, 207U, WParam, 0);
    }

    public void CloseProgram(IntPtr hwnd)
    {
      WindowsAPI.SendMessage(hwnd, 16U, 0, 0);
    }

    public void StopPaint(IntPtr handle)
    {
      WindowsAPI.SendMessage(handle, 11U, 0, 0);
    }

    public void StartPaint(IntPtr handle)
    {
      WindowsAPI.SendMessage(handle, 11U, 1, 0);
    }

    public WINDOWPLACEMENT GetWindowPlacement(IntPtr handle)
    {
      WINDOWPLACEMENT lpwndpl = new WINDOWPLACEMENT();
      lpwndpl.length = Marshal.SizeOf((object) lpwndpl);
      lpwndpl.flags = 7;
      WindowsAPI.GetWindowPlacement(handle, ref lpwndpl);
      return lpwndpl;
    }

    public bool SetWindowPlacement(IntPtr handle)
    {
      WINDOWPLACEMENT lpwndpl = new WINDOWPLACEMENT();
      lpwndpl.length = Marshal.SizeOf((object) lpwndpl);
      lpwndpl.flags = 7;
      return WindowsAPI.SetWindowPlacement(handle, ref lpwndpl);
    }

    public string GetControlText(IntPtr hwnd)
    {
      StringBuilder lParam = new StringBuilder(99999999);
      WindowsAPI.SendMessage(hwnd, 13U, 999, lParam);
      return lParam.ToString();
    }

    public string GetControlText(string lpWindowName, string lpChildText)
    {
      IntPtr window = WindowsAPI.FindWindow((string) null, lpWindowName);
      int windowLong = WindowsAPI.GetWindowLong(WindowsAPI.FindWindowEx(window, IntPtr.Zero, (string) null, lpChildText), -12);
      IntPtr dlgItem = WindowsAPI.GetDlgItem(window, windowLong);
      StringBuilder lParam = new StringBuilder(99999999);
      WindowsAPI.SendMessage(dlgItem, 13U, 999, lParam);
      return lParam.ToString();
    }

    public int SetControlText(string lpWindowName, string lpChildText, string newtext)
    {
      return WindowsAPI.SendMessage(WindowsAPI.FindWindowEx(WindowsAPI.FindWindow((string) null, lpWindowName), IntPtr.Zero, (string) null, lpChildText), 12U, 0, newtext);
    }

    public int SetControlText(IntPtr hwnd, string newtext)
    {
      return WindowsAPI.SendMessage(hwnd, 12U, 0, newtext);
    }

    public string GetClassName(IntPtr hwnd)
    {
      StringBuilder lpClassName = new StringBuilder(1024);
      WindowsAPI.GetClassNameW(hwnd, lpClassName, lpClassName.Capacity);
      return lpClassName.ToString();
    }

    public string GetWindowText(IntPtr hwnd)
    {
      StringBuilder lpString = new StringBuilder(1024);
      WindowsAPI.GetWindowTextW(hwnd, lpString, lpString.MaxCapacity);
      return lpString.ToString();
    }

    public string GetExecutePath(IntPtr hwnd)
    {
      int lpdwProcessId = 0;
      WindowsAPI.GetWindowThreadProcessId(hwnd, ref lpdwProcessId);
      MODULEENTRY32 lpme = new MODULEENTRY32();
      lpme.dwSize = Marshal.SizeOf((object) lpme);
      WindowsAPI.Module32First(WindowsAPI.CreateToolhelp32Snapshot(8U, lpdwProcessId), ref lpme);
      return lpme.szExePath;
    }

    public string GetExecutePathEx(IntPtr hwnd)
    {
      StringBuilder lpFilename = new StringBuilder(256);
      int lpdwProcessId = 0;
      WindowsAPI.GetWindowThreadProcessId(hwnd, ref lpdwProcessId);
      WindowsAPI.GetModuleFileNameEx(WindowsAPI.OpenProcess(1040, false, lpdwProcessId), IntPtr.Zero, lpFilename, lpFilename.Capacity);
      return lpFilename.ToString();
    }

    private void GetExecutePath_SB(IntPtr hwnd)
    {
      this.GetAllProcessModules(hwnd);
      int lpdwProcessId = 0;
      MODULEINFO lpmodinfo = new MODULEINFO();
      WindowsAPI.GetWindowThreadProcessId(hwnd, ref lpdwProcessId);
      WindowsAPI.GetModuleInformation(WindowsAPI.OpenProcess(1040, false, lpdwProcessId), IntPtr.Zero, ref lpmodinfo, Marshal.SizeOf((object) lpmodinfo));
    }

    public void HideInTaskBar(IntPtr hwnd)
    {
      WindowsAPI.SetWindowLong(hwnd, -8, 128);
    }

    public void ShowInTaskBar(IntPtr hwnd)
    {
      WindowsAPI.SetWindowLong(hwnd, -20, 262144);
    }

    public TStringList GetWindowStyle(IntPtr hwnd)
    {
      int windowLong = WindowsAPI.GetWindowLong(hwnd, -16);
      TStringList tstringList = new TStringList();
      if ((windowLong & 8388608) != 0)
        tstringList.Add("WS_BORDER");
      if ((windowLong & 12582912) != 0)
        tstringList.Add("WS_CAPTION");
      if ((windowLong & 1073741824) != 0)
        tstringList.Add("WS_CHILD");
      if ((windowLong & 1073741824) != 0)
        tstringList.Add("WS_CHILDWINDOW");
      if ((windowLong & 33554432) != 0)
        tstringList.Add("WS_CLIPCHILDREN");
      if ((windowLong & 67108864) != 0)
        tstringList.Add("WS_CLIPSIBLINGS");
      if ((windowLong & 134217728) != 0)
        tstringList.Add("WS_DISABLED");
      if ((windowLong & 4194304) != 0)
        tstringList.Add("WS_DLGFRAME");
      if ((windowLong & 131072) != 0)
        tstringList.Add("WS_GROUP");
      if ((windowLong & 1048576) != 0)
        tstringList.Add("WS_HSCROLL");
      if ((windowLong & 536870912) != 0)
        tstringList.Add("WS_ICONIC");
      if ((windowLong & 16777216) != 0)
        tstringList.Add("WS_MAXIMIZE");
      if ((windowLong & 65536) != 0)
        tstringList.Add("WS_MAXIMIZEBOX");
      if ((windowLong & 536870912) != 0)
        tstringList.Add("WS_MINIMIZE");
      if ((windowLong & 131072) != 0)
        tstringList.Add("WS_MINIMIZEBOX");
      if ((windowLong & 13565952) != 0)
        tstringList.Add("WS_OVERLAPPEDWINDOW");
      if (((long) windowLong & (long) int.MinValue) != 0L)
        tstringList.Add("WS_POPUP");
      if (((long) windowLong & -2138570752L) != 0L)
        tstringList.Add("WS_POPUPWINDOW");
      if ((windowLong & 262144) != 0)
        tstringList.Add("WS_SIZEBOX");
      if ((windowLong & 524288) != 0)
        tstringList.Add("WS_SYSMENU");
      if ((windowLong & 65536) != 0)
        tstringList.Add("WS_TABSTOP");
      if ((windowLong & 262144) != 0)
        tstringList.Add("WS_THICKFRAME");
      if ((windowLong & 13565952) != 0)
        tstringList.Add("WS_TILEDWINDOW");
      if ((windowLong & 268435456) != 0)
        tstringList.Add("WS_VISIBLE");
      if ((windowLong & 2097152) != 0)
        tstringList.Add("WS_VSCROLL");
      string lastString = tstringList.LastString;
      return tstringList;
    }

    public TStringList GetWindowStyleEx(IntPtr hwnd)
    {
      int windowLong = WindowsAPI.GetWindowLong(hwnd, -20);
      TStringList tstringList = new TStringList();
      if ((windowLong & 16) != 0)
        tstringList.Add("WS_EX_ACCEPTFILES");
      if ((windowLong & 262144) != 0)
        tstringList.Add("WS_EX_APPWINDOW");
      if ((windowLong & 512) != 0)
        tstringList.Add("WS_EX_CLIENTEDGE");
      if ((windowLong & 33554432) != 0)
        tstringList.Add("WS_EX_COMPOSITED");
      if ((windowLong & 1024) != 0)
        tstringList.Add("WS_EX_CONTEXTHELP");
      if ((windowLong & 65536) != 0)
        tstringList.Add("WS_EX_CONTROLPARENT");
      if ((windowLong & 1) != 0)
        tstringList.Add("WS_EX_DLGMODALFRAME");
      if ((windowLong & 524288) != 0)
        tstringList.Add("WS_EX_LAYERED");
      if ((windowLong & 4194304) != 0)
        tstringList.Add("WS_EX_LAYOUTRTL");
      if ((windowLong & 16384) != 0)
        tstringList.Add("WS_EX_LEFTSCROLLBAR");
      if ((windowLong & 64) != 0)
        tstringList.Add("WS_EX_MDICHILD");
      if ((windowLong & 134217728) != 0)
        tstringList.Add("WS_EX_NOACTIVATE");
      if ((windowLong & 1048576) != 0)
        tstringList.Add("WS_EX_NOINHERITLAYOUT");
      if ((windowLong & 4) != 0)
        tstringList.Add("WS_EX_NOPARENTNOTIFY");
      if ((windowLong & 768) != 0)
        tstringList.Add("WS_EX_OVERLAPPEDWINDOW");
      if ((windowLong & 392) != 0)
        tstringList.Add("WS_EX_PALETTEWINDOW");
      if ((windowLong & 4096) != 0)
        tstringList.Add("WS_EX_RIGHT");
      if ((windowLong & 8192) != 0)
        tstringList.Add("WS_EX_RTLREADING");
      if ((windowLong & 131072) != 0)
        tstringList.Add("WS_EX_STATICEDGE");
      if ((windowLong & 128) != 0)
        tstringList.Add("WS_EX_TOOLWINDOW");
      if ((windowLong & 8) != 0)
        tstringList.Add("WS_EX_TOPMOST");
      if ((windowLong & 32) != 0)
        tstringList.Add("WS_EX_TRANSPARENT");
      if ((windowLong & 256) != 0)
        tstringList.Add("WS_EX_WINDOWEDGE");
      return tstringList;
    }

    public TStringList GetWindowStyleEx(int style)
    {
      TStringList tstringList = new TStringList();
      if ((style & 16) != 0)
        tstringList.Add("WS_EX_ACCEPTFILES");
      if ((style & 262144) != 0)
        tstringList.Add("WS_EX_APPWINDOW");
      if ((style & 512) != 0)
        tstringList.Add("WS_EX_CLIENTEDGE");
      if ((style & 33554432) != 0)
        tstringList.Add("WS_EX_COMPOSITED");
      if ((style & 1024) != 0)
        tstringList.Add("WS_EX_CONTEXTHELP");
      if ((style & 65536) != 0)
        tstringList.Add("WS_EX_CONTROLPARENT");
      if ((style & 1) != 0)
        tstringList.Add("WS_EX_DLGMODALFRAME");
      if ((style & 524288) != 0)
        tstringList.Add("WS_EX_LAYERED");
      if ((style & 4194304) != 0)
        tstringList.Add("WS_EX_LAYOUTRTL");
      if ((style & 16384) != 0)
        tstringList.Add("WS_EX_LEFTSCROLLBAR");
      if ((style & 64) != 0)
        tstringList.Add("WS_EX_MDICHILD");
      if ((style & 134217728) != 0)
        tstringList.Add("WS_EX_NOACTIVATE");
      if ((style & 1048576) != 0)
        tstringList.Add("WS_EX_NOINHERITLAYOUT");
      if ((style & 4) != 0)
        tstringList.Add("WS_EX_NOPARENTNOTIFY");
      if ((style & 768) != 0)
        tstringList.Add("WS_EX_OVERLAPPEDWINDOW");
      if ((style & 392) != 0)
        tstringList.Add("WS_EX_PALETTEWINDOW");
      if ((style & 4096) != 0)
        tstringList.Add("WS_EX_RIGHT");
      if ((style & 8192) != 0)
        tstringList.Add("WS_EX_RTLREADING");
      if ((style & 131072) != 0)
        tstringList.Add("WS_EX_STATICEDGE");
      if ((style & 128) != 0)
        tstringList.Add("WS_EX_TOOLWINDOW");
      if ((style & 8) != 0)
        tstringList.Add("WS_EX_TOPMOST");
      if ((style & 32) != 0)
        tstringList.Add("WS_EX_TRANSPARENT");
      if ((style & 256) != 0)
        tstringList.Add("WS_EX_WINDOWEDGE");
      return tstringList;
    }

    public void TransparentA(IntPtr Handle)
    {
      WindowsAPI.GetWindowLong(Handle, -20);
      WindowsAPI.SetWindowLong(Handle, -20, 524320);
      WindowsAPI.SetLayeredWindowAttributes(Handle, 0, 100, 2);
    }

    public void TransparentA(IntPtr Handle, int trans)
    {
      WindowsAPI.GetWindowLong(Handle, -20);
      WindowsAPI.SetWindowLong(Handle, -20, 524320);
      WindowsAPI.SetLayeredWindowAttributes(Handle, 0, trans, 2);
    }

    public void TransparentB(IntPtr Handle)
    {
      WindowsAPI.GetWindowLong(Handle, -20);
      WindowsAPI.SetWindowLong(Handle, -20, 524288);
      WindowsAPI.SetLayeredWindowAttributes(Handle, 0, 100, 2);
    }

    public void TransparentB(IntPtr Handle, int tr)
    {
      WindowsAPI.GetWindowLong(Handle, -20);
      WindowsAPI.SetWindowLong(Handle, -20, 524288);
      WindowsAPI.SetLayeredWindowAttributes(Handle, 0, tr, 2);
    }

    public void TransparentC(IntPtr Handle)
    {
      WindowsAPI.SetLayeredWindowAttributes(Handle, 0, (int) byte.MaxValue, 0);
    }

    public bool FlashForm(IntPtr hwnd, int times, int style)
    {
      FLASHWINFO pfwi = new FLASHWINFO();
      pfwi.cbSize = (uint) Marshal.SizeOf((object) pfwi);
      pfwi.dwFlags = 1;
      pfwi.uCount = (uint) times;
      pfwi.hwnd = hwnd;
      return WindowsAPI.FlashWindowEx(ref pfwi);
    }

    public Size GetControlSize(IntPtr handle)
    {
      Size size = new Size();
      WINDOWPLACEMENT lpwndpl = new WINDOWPLACEMENT();
      lpwndpl.length = Marshal.SizeOf((object) lpwndpl);
      lpwndpl.flags = 7;
      WindowsAPI.GetWindowPlacement(handle, ref lpwndpl);
      size.Width = lpwndpl.rcNormalPosition.right - lpwndpl.rcNormalPosition.left;
      size.Height = lpwndpl.rcNormalPosition.bottom - lpwndpl.rcNormalPosition.top;
      return size;
    }

    public Point GetLocation()
    {
      IntPtr currentIntPtr = this.GetCurrentIntPtr();
      RECT lpRect = new RECT();
      WindowsAPI.GetWindowRect(currentIntPtr, ref lpRect);
      return new Point(lpRect.left, lpRect.top);
    }

    public Point GetLocation(IntPtr hwnd)
    {
      RECT lpRect = new RECT();
      WindowsAPI.GetWindowRect(hwnd, ref lpRect);
      return new Point(lpRect.left, lpRect.top);
    }

    public bool SetCurrentWindowState(IntPtr handle, int hwnd)
    {
      return WindowsAPI.SetWindowPos(handle, (IntPtr) hwnd, 0, 0, 0, 0, 3U);
    }

    public void ReverseFormTitle(IntPtr hwnd)
    {
      WindowsAPI.SetWindowLong(hwnd, -20, 173867264);
    }

    public void ReverseFormTitleBack(IntPtr hwnd)
    {
      WindowsAPI.SetWindowLong(hwnd, -20, 327936);
    }

    public Size GetWindowSize()
    {
      IntPtr currentIntPtr = this.GetCurrentIntPtr();
      Size size = new Size();
      RECT lpRect = new RECT();
      WindowsAPI.GetWindowRect(currentIntPtr, ref lpRect);
      size.Width = lpRect.right - lpRect.left;
      size.Height = lpRect.bottom - lpRect.top;
      return size;
    }

    public Size GetWindowSize(IntPtr hwnd)
    {
      Size size = new Size();
      RECT lpRect = new RECT();
      WindowsAPI.GetWindowRect(hwnd, ref lpRect);
      size.Width = lpRect.right - lpRect.left;
      size.Height = lpRect.bottom - lpRect.top;
      return size;
    }

    public Size GetWindowClientSize(IntPtr hwnd)
    {
      RECT lpRect = new RECT();
      WindowsAPI.GetClientRect(hwnd, ref lpRect);
      return new Size(lpRect.right - lpRect.left, lpRect.bottom - lpRect.top);
    }

    public void RemoveMaximizeBox(IntPtr hwnd)
    {
      int dwNewLong = WindowsAPI.GetWindowLong(hwnd, -16) - 65536;
      WindowsAPI.SetWindowLong(hwnd, -16, dwNewLong);
    }

    public void RemoveMinimizeBox(IntPtr hwnd)
    {
      int dwNewLong = WindowsAPI.GetWindowLong(hwnd, -16) - 131072;
      WindowsAPI.SetWindowLong(hwnd, -16, dwNewLong);
    }

    public void RemoveTitle(IntPtr hwnd)
    {
      int dwNewLong = WindowsAPI.GetWindowLong(hwnd, -16) - 12582912;
      WindowsAPI.SetWindowLong(hwnd, -16, dwNewLong);
    }

    public void RemoveSystemMenu(IntPtr hwnd)
    {
      int dwNewLong = WindowsAPI.GetWindowLong(hwnd, -16) - 262144;
      WindowsAPI.SetWindowLong(hwnd, -16, dwNewLong);
    }

    public void RemoveSizeBox(IntPtr hwnd)
    {
      int dwNewLong = WindowsAPI.GetWindowLong(hwnd, -16) - 262144;
      WindowsAPI.SetWindowLong(hwnd, -16, dwNewLong);
    }

    public void AddMaximizeBox(IntPtr hwnd)
    {
      int dwNewLong = WindowsAPI.GetWindowLong(hwnd, -16) | 65536;
      WindowsAPI.SetWindowLong(hwnd, -16, dwNewLong);
    }

    public void AddMinimizeBox(IntPtr hwnd)
    {
      int dwNewLong = WindowsAPI.GetWindowLong(hwnd, -16) + 131072;
      WindowsAPI.SetWindowLong(hwnd, -16, dwNewLong);
    }

    public void AddTitle(IntPtr hwnd)
    {
      int dwNewLong = WindowsAPI.GetWindowLong(hwnd, -16) + 12582912;
      WindowsAPI.SetWindowLong(hwnd, -16, dwNewLong);
    }

    public void AddSystemMenu(IntPtr hwnd)
    {
      int dwNewLong = WindowsAPI.GetWindowLong(hwnd, -16) + 262144;
      WindowsAPI.SetWindowLong(hwnd, -16, dwNewLong);
    }

    public void AddSizeBox(IntPtr hwnd)
    {
      int dwNewLong = WindowsAPI.GetWindowLong(hwnd, -16) + 262144;
      WindowsAPI.SetWindowLong(hwnd, -16, dwNewLong);
    }

    public void CloseTheme(IntPtr hwnd)
    {
      WindowsAPI.SetWindowTheme(hwnd, "", "");
    }

    public void OpenTheme(IntPtr hwnd)
    {
      WindowsAPI.SetWindowTheme(hwnd, (string) null, (string) null);
    }

    public Point GetWindowOrgEx(IntPtr hwnd)
    {
      IntPtr windowDc = WindowsAPI.GetWindowDC(hwnd);
      Point lpPoint = new Point();
      WindowsAPI.GetWindowOrgEx(windowDc, ref lpPoint);
      return lpPoint;
    }

    public bool ShowTaskBar()
    {
      IntPtr window = WindowsAPI.FindWindow("Shell_TrayWnd", (string) null);
      bool flag;
      if (WindowsAPI.IsWindowVisible(window))
      {
        WindowsAPI.ShowWindow(window, 0);
        flag = false;
      }
      else
      {
        WindowsAPI.ShowWindow(window, 5);
        flag = true;
      }
      return flag;
    }

    public bool NetState()
    {
      int lpdwFlags = 0;
      return WindowsAPI.IsNetworkAlive(ref lpdwFlags);
    }

    public string NetworkState()
    {
      int lpdwFlags = 0;
      string str = "";
      if (WindowsAPI.IsNetworkAlive(ref lpdwFlags))
      {
        if ((lpdwFlags & 4) == 4)
          str = "AOL";
        if ((lpdwFlags & 1) == 1)
          str = "LAN";
        if ((lpdwFlags & 2) == 2)
          str = "WAN";
      }
      else
        str = "OFFLINE";
      return str;
    }

    public string NetworkStateA()
    {
      int lpdwFlags = 0;
      WindowsAPI.InternetGetConnectedState(ref lpdwFlags, 0);
      int num1 = lpdwFlags & 2;
      int num2 = lpdwFlags & 1;
      int num3 = lpdwFlags & 4;
      int num4 = lpdwFlags & 8;
      return "OFFLINE";
    }

    public int NetStatus()
    {
      int lpdwFlags = 0;
      WindowsAPI.InternetGetConnectedStateEx(ref lpdwFlags, (string) null, 254, 0);
      return lpdwFlags;
    }

    public void DrawRectangle()
    {
      Point lpPoint = new Point();
      RECT lpRect = new RECT();
      IntPtr windowDc = WindowsAPI.GetWindowDC(WindowsAPI.GetDesktopWindow());
      int fnDrawMode = WindowsAPI.SetROP2(windowDc, 10);
      WindowsAPI.GetCursorPos(ref lpPoint);
      WindowsAPI.GetWindowRect(WindowsAPI.WindowFromPoint(lpPoint), ref lpRect);
      if (lpRect.left < 0)
        lpRect.left = 0;
      if (lpRect.top < 0)
        lpRect.top = 0;
      IntPtr pen = WindowsAPI.CreatePen(0, 3, 0);
      IntPtr hgdiobj = WindowsAPI.SelectObject(windowDc, pen);
      WindowsAPI.Rectangle(windowDc, lpRect.left, lpRect.top, lpRect.right, lpRect.bottom);
      WindowsAPI.Sleep(300);
      WindowsAPI.Rectangle(windowDc, lpRect.left, lpRect.top, lpRect.right, lpRect.bottom);
      WindowsAPI.SetROP2(windowDc, fnDrawMode);
      WindowsAPI.SelectObject(windowDc, hgdiobj);
      WindowsAPI.DeleteObject(pen);
      IntPtr num = IntPtr.Zero;
    }

    public void DrawRectangleEx(RECT rc)
    {
      IntPtr desktopWindow = WindowsAPI.GetDesktopWindow();
      IntPtr windowDc = WindowsAPI.GetWindowDC(desktopWindow);
      int fnDrawMode = WindowsAPI.SetROP2(windowDc, 10);
      if (rc.left < 0)
        rc.left = 0;
      if (rc.top < 0)
        rc.top = 0;
      IntPtr pen = WindowsAPI.CreatePen(0, 2, 0);
      IntPtr hgdiobj = WindowsAPI.SelectObject(windowDc, pen);
      WindowsAPI.Rectangle(windowDc, rc.left, rc.top, rc.right, rc.bottom);
      WindowsAPI.Sleep(10);
      WindowsAPI.Rectangle(windowDc, rc.left, rc.top, rc.right, rc.bottom);
      WindowsAPI.SetROP2(windowDc, fnDrawMode);
      WindowsAPI.SelectObject(windowDc, hgdiobj);
      WindowsAPI.DeleteObject(pen);
      WindowsAPI.ReleaseDC(desktopWindow);
      IntPtr num = IntPtr.Zero;
    }

    private void DrawRectangleDesk(IntPtr hwnd)
    {
      RECT lpRect = new RECT();
      WindowsAPI.GetWindowRect(hwnd, ref lpRect);
      WindowsAPI.CreateCompatibleDC(hwnd);
      IntPtr compatibleBitmap = WindowsAPI.CreateCompatibleBitmap(hwnd, lpRect.right, lpRect.bottom);
      IntPtr hgdiobj = WindowsAPI.SelectObject(WindowsAPI.GetWindowDC(hwnd), compatibleBitmap);
      WindowsAPI.BitBlt(WindowsAPI.GetWindowDC(this.DeskHwnd), this.GetLocation().X, this.GetLocation().Y, lpRect.right - lpRect.left, lpRect.bottom - lpRect.top, WindowsAPI.GetWindowDC(hwnd), lpRect.left, lpRect.top, 13369376U);
      WindowsAPI.SelectObject(WindowsAPI.GetWindowDC(hwnd), hgdiobj);
    }

    public void DrawRevFrame(IntPtr hWnd)
    {
      if (hWnd == IntPtr.Zero)
        return;
      IntPtr windowDc = WindowsAPI.GetWindowDC(hWnd);
      RECT rect = new RECT();
      WindowsAPI.GetWindowRect(hWnd, ref rect);
      WindowsAPI.OffsetRect(ref rect, -rect.left, -rect.top);
      WindowsAPI.PatBlt(windowDc, rect.left, rect.top, rect.right - rect.left, 3, 5570569);
      WindowsAPI.PatBlt(windowDc, rect.left, rect.bottom - 3, 3, -(rect.bottom - rect.top - 6), 5570569);
      WindowsAPI.PatBlt(windowDc, rect.right - 3, rect.top + 3, 3, rect.bottom - rect.top - 6, 5570569);
      WindowsAPI.PatBlt(windowDc, rect.right, rect.bottom - 3, -(rect.right - rect.left), 3, 5570569);
    }

    public Icon GetFileIconEx(string FileName)
    {
      SHFILEINFO psfi = new SHFILEINFO();
      Icon icon = (Icon) null;
      if (WindowsAPI.SHGetFileInfo(FileName, 100, ref psfi, 0U, 273U) > 0)
        icon = Icon.FromHandle(psfi.hIcon);
      return icon;
    }

    public Icon GetFileIcon(IntPtr hwnd)
    {
      int lpiIcon = 0;
      return Icon.FromHandle(WindowsAPI.ExtractAssociatedIcon(hwnd, this.GetExecutePath(hwnd), ref lpiIcon));
    }

    public Icon GetFileIcon(IntPtr hwnd, string path)
    {
      int lpiIcon = 0;
      return Icon.FromHandle(WindowsAPI.ExtractAssociatedIcon(hwnd, path, ref lpiIcon));
    }

    public void PlaySound(string path)
    {
      if (!File.Exists(path))
        return;
      new APIMethod.PlayAudio()
      {
        FileName = path
      }.Play();
    }

    public Bitmap GetScreen()
    {
      Graphics g = Graphics.FromHdc(WindowsAPI.CreateDC("DISPLAY", (string) null, (string) null, IntPtr.Zero));
      Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, g);
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      IntPtr hdc1 = g.GetHdc();
      IntPtr hdc2 = graphics.GetHdc();
      WindowsAPI.BitBlt(hdc2, 0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, hdc1, 0, 0, 13369376U);
      g.ReleaseHdc(hdc1);
      graphics.ReleaseHdc(hdc2);
      return bitmap;
    }

    public Bitmap GetScreen(IntPtr hwnd)
    {
      Graphics g = Graphics.FromHdc(WindowsAPI.GetWindowDC(hwnd));
      Size windowSize = this.GetWindowSize(hwnd);
      int num = this.GetWindowBorder(hwnd);
      if (num == 3)
        num = 10;
      Bitmap bitmap = new Bitmap(windowSize.Width + num, windowSize.Height + num, g);
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      IntPtr hdc1 = g.GetHdc();
      IntPtr hdc2 = graphics.GetHdc();
      WindowsAPI.BitBlt(hdc2, 0, 0, windowSize.Width + num, windowSize.Height + num, hdc1, 0, 0, 1087111200U);
      g.ReleaseHdc(hdc1);
      graphics.ReleaseHdc(hdc2);
      return bitmap;
    }

    public Bitmap GetScreenSnapShot()
    {
      int systemMetrics1 = WindowsAPI.GetSystemMetrics(0);
      int systemMetrics2 = WindowsAPI.GetSystemMetrics(1);
      IntPtr dc = WindowsAPI.GetDC(this.DeskHwnd);
      IntPtr compatibleDc = WindowsAPI.CreateCompatibleDC(dc);
      IntPtr compatibleBitmap = WindowsAPI.CreateCompatibleBitmap(dc, systemMetrics1, systemMetrics2);
      IntPtr hgdiobj = WindowsAPI.SelectObject(compatibleDc, compatibleBitmap);
      WindowsAPI.BitBlt(compatibleDc, 0, 0, systemMetrics1, systemMetrics2, dc, 0, 0, 1087111200U);
      WindowsAPI.SelectObject(compatibleDc, hgdiobj);
      Bitmap bitmap = Image.FromHbitmap(compatibleBitmap);
      WindowsAPI.DeleteDC(compatibleDc);
      WindowsAPI.DeleteObject(compatibleBitmap);
      return bitmap;
    }

    public Bitmap GetScreenSnapShot(IntPtr hwnd)
    {
      Point location = this.GetLocation(hwnd);
      int x = location.X;
      int nYSrc = location.Y;
      int width = this.GetWindowSize(hwnd).Width;
      int height = this.GetWindowSize(hwnd).Height;
      if (this.GetCurrentWindowsVersion().StartsWith("Windows XP") && WindowsAPI.GetParent(hwnd) == IntPtr.Zero)
      {
        x = location.X;
        nYSrc = location.Y + 2;
        height -= 2;
      }
      IntPtr dc = WindowsAPI.GetDC(this.DeskHwnd);
      IntPtr compatibleDc = WindowsAPI.CreateCompatibleDC(dc);
      IntPtr compatibleBitmap = WindowsAPI.CreateCompatibleBitmap(dc, width, height);
      IntPtr hgdiobj = WindowsAPI.SelectObject(compatibleDc, compatibleBitmap);
      WindowsAPI.BitBlt(compatibleDc, 0, 0, width, height, dc, x, nYSrc, 1087111200U);
      WindowsAPI.SelectObject(compatibleDc, hgdiobj);
      Bitmap bitmap = Image.FromHbitmap(compatibleBitmap);
      WindowsAPI.DeleteDC(compatibleDc);
      WindowsAPI.DeleteObject(compatibleBitmap);
      return bitmap;
    }

    public Bitmap GetScreenSnapShot(RECT rc)
    {
      int nXSrc = rc.left;
      int nYSrc = rc.top;
      int nWidth = Math.Abs(rc.right - rc.left);
      int nHeight = Math.Abs(rc.bottom - rc.top);
      IntPtr dc = WindowsAPI.GetDC(this.DeskHwnd);
      IntPtr compatibleDc = WindowsAPI.CreateCompatibleDC(dc);
      IntPtr compatibleBitmap = WindowsAPI.CreateCompatibleBitmap(dc, nWidth, nHeight);
      IntPtr hgdiobj = WindowsAPI.SelectObject(compatibleDc, compatibleBitmap);
      WindowsAPI.BitBlt(compatibleDc, 0, 0, nWidth, nHeight, dc, nXSrc, nYSrc, 1087111200U);
      WindowsAPI.SelectObject(compatibleDc, hgdiobj);
      Bitmap bitmap = Image.FromHbitmap(compatibleBitmap);
      WindowsAPI.DeleteDC(compatibleDc);
      WindowsAPI.DeleteObject(compatibleBitmap);
      return bitmap;
    }

    public Bitmap GetScreenEx()
    {
      Graphics g = Graphics.FromHdc(WindowsAPI.CreateDC("DISPLAY", (string) null, (string) null, IntPtr.Zero));
      Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, g);
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      IntPtr hdc1 = g.GetHdc();
      IntPtr hdc2 = graphics.GetHdc();
      WindowsAPI.BitBlt(hdc2, 0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, hdc1, 0, 0, 1087111200U);
      g.ReleaseHdc(hdc1);
      graphics.ReleaseHdc(hdc2);
      string str = this.GetTempPath() + "CSGraphicsSnapShot.bmp";
      if (File.Exists(str))
        File.Delete(str);
      bitmap.Save(str, ImageFormat.Bmp);
      bitmap.Dispose();
      return new Bitmap(str);
    }

    public void SaveScreen(string path, string filename)
    {
      if (!Directory.Exists(path))
        path = Environment.SpecialFolder.Personal.ToString();
      if (filename == "")
        filename = "屏幕截图.bmp";
      this.GetScreen().Save(path + filename);
    }

    public Bitmap GetCurrentWindowPicture()
    {
      IntPtr currentIntPtr = this.GetCurrentIntPtr();
      int width = this.GetWindowSize(currentIntPtr).Width;
      int height = this.GetWindowSize(currentIntPtr).Height;
      int x = this.GetLocation(currentIntPtr).X;
      int y = this.GetLocation(currentIntPtr).Y;
      string currentWindowsVersion = this.GetCurrentWindowsVersion();
      int windowBorder = this.GetWindowBorder(currentIntPtr);
      if (currentWindowsVersion.StartsWith("Windows Vista") && windowBorder == 3)
      {
        x -= 5;
        y -= 5;
        width += 10;
        height += 10;
      }
      if (currentWindowsVersion.StartsWith("Windows XP"))
        y += 2;
      Bitmap bitmap = new Bitmap(width, height);
      Graphics.FromImage((Image) bitmap).CopyFromScreen(x, y, 0, 0, new Size(width, height), (CopyPixelOperation) 1087111200);
      return bitmap;
    }

    public Bitmap GetCurrentWindowPicture(IntPtr hwnd)
    {
      int width = this.GetWindowSize(hwnd).Width;
      int height = this.GetWindowSize(hwnd).Height;
      int x = this.GetLocation(hwnd).X;
      int y = this.GetLocation(hwnd).Y;
      string currentWindowsVersion = this.GetCurrentWindowsVersion();
      int windowBorder = this.GetWindowBorder(hwnd);
      if (currentWindowsVersion.StartsWith("Windows Vista") && windowBorder == 3)
      {
        x -= 5;
        y -= 5;
        width += 10;
        height += 10;
      }
      if (currentWindowsVersion.StartsWith("Windows XP"))
        y += 2;
      Bitmap bitmap = new Bitmap(width, height);
      Graphics.FromImage((Image) bitmap).CopyFromScreen(x, y, 0, 0, new Size(width, height));
      return bitmap;
    }

    public Bitmap GetCurrentWindowPicture(IntPtr hwnd, ref Point p)
    {
      int width = this.GetWindowSize(hwnd).Width;
      int height = this.GetWindowSize(hwnd).Height;
      int x = this.GetLocation(hwnd).X;
      int y = this.GetLocation(hwnd).Y;
      string currentWindowsVersion = this.GetCurrentWindowsVersion();
      int windowBorder = this.GetWindowBorder(hwnd);
      if (currentWindowsVersion.StartsWith("Windows Vista") && windowBorder == 3)
      {
        x -= 5;
        y -= 5;
        width += 10;
        height += 10;
      }
      if (currentWindowsVersion.StartsWith("Windows XP") && WindowsAPI.GetParent(hwnd) == IntPtr.Zero)
        y += 2;
      Bitmap bitmap = new Bitmap(width, height);
      Graphics.FromImage((Image) bitmap).CopyFromScreen(x, y, 0, 0, new Size(width, height));
      p = new Point(x, y);
      return bitmap;
    }

    public Point GetCurrentWindowPicturePoint(IntPtr hwnd)
    {
      int x = this.GetLocation(hwnd).X;
      int y = this.GetLocation(hwnd).Y;
      string currentWindowsVersion = this.GetCurrentWindowsVersion();
      if (currentWindowsVersion.StartsWith("Windows Vista") && WindowsAPI.GetParent(hwnd) == IntPtr.Zero)
      {
        x -= 5;
        y -= 5;
      }
      if (currentWindowsVersion.StartsWith("Windows XP") && WindowsAPI.GetParent(hwnd) == IntPtr.Zero)
        y += 2;
      return new Point(x, y);
    }

    public Bitmap GetCurrentWindowPicture(RECT rect)
    {
      Bitmap bitmap = new Bitmap(Math.Abs(rect.right - rect.left), Math.Abs(rect.bottom - rect.top));
      Graphics.FromImage((Image) bitmap).CopyFromScreen(rect.left, rect.top, 0, 0, new Size(Math.Abs(rect.right - rect.left), Math.Abs(rect.bottom - rect.top)));
      return bitmap;
    }

    public Bitmap GetCurrentWindowPictureEx(RECT rect)
    {
      int nWidth = Math.Abs(rect.right - rect.left);
      int nHeight = Math.Abs(rect.bottom - rect.top);
      IntPtr dc = WindowsAPI.GetDC(this.DeskHwnd);
      IntPtr compatibleDc = WindowsAPI.CreateCompatibleDC(dc);
      IntPtr compatibleBitmap = WindowsAPI.CreateCompatibleBitmap(dc, nWidth, nHeight);
      IntPtr hgdiobj = WindowsAPI.SelectObject(compatibleDc, compatibleBitmap);
      WindowsAPI.BitBlt(compatibleDc, 0, 0, nWidth, nHeight, dc, rect.left, rect.top, 1087111200U);
      WindowsAPI.SelectObject(compatibleDc, hgdiobj);
      Bitmap bitmap = Image.FromHbitmap(compatibleBitmap);
      WindowsAPI.DeleteDC(compatibleDc);
      WindowsAPI.DeleteObject(compatibleBitmap);
      return bitmap;
    }

    public Bitmap GetWindowCaptureAsBitmap(int hwnd)
    {
      IntPtr num = new IntPtr(hwnd);
      RECT lpRect = new RECT();
      Bitmap bitmap1;
      if (!WindowsAPI.GetWindowRect(num, ref lpRect))
      {
        bitmap1 = (Bitmap) null;
      }
      else
      {
        Bitmap bitmap2 = new Bitmap(lpRect.right - lpRect.left, lpRect.bottom - lpRect.top);
        Graphics graphics = Graphics.FromImage((Image) bitmap2);
        IntPtr hdc = graphics.GetHdc();
        IntPtr windowDc = WindowsAPI.GetWindowDC(num);
        WindowsAPI.BitBlt(hdc, 0, 0, lpRect.right - lpRect.left, lpRect.bottom - lpRect.top, windowDc, 0, 0, 13369376U);
        graphics.ReleaseHdc(hdc);
        WindowsAPI.ReleaseDC(num, windowDc);
        graphics.Dispose();
        bitmap1 = bitmap2;
      }
      return bitmap1;
    }

    public Bitmap GetWindowCaptureAsBitmap(IntPtr hwnd)
    {
      RECT lpRect = new RECT();
      Bitmap bitmap1;
      if (!WindowsAPI.GetWindowRect(hwnd, ref lpRect))
      {
        bitmap1 = (Bitmap) null;
      }
      else
      {
        Bitmap bitmap2 = new Bitmap(lpRect.right - lpRect.left, lpRect.bottom - lpRect.top);
        Graphics graphics = Graphics.FromImage((Image) bitmap2);
        IntPtr hdc = graphics.GetHdc();
        IntPtr windowDc = WindowsAPI.GetWindowDC(hwnd);
        WindowsAPI.BitBlt(hdc, 0, 0, lpRect.right - lpRect.left, lpRect.bottom - lpRect.top, windowDc, 0, 0, 13369376U);
        graphics.ReleaseHdc(hdc);
        WindowsAPI.ReleaseDC(hwnd, windowDc);
        graphics.Dispose();
        bitmap1 = bitmap2;
      }
      return bitmap1;
    }

    public Bitmap GetWindowCaptureAsBitmapEx(IntPtr hwnd)
    {
      RECT lpRect = new RECT();
      Bitmap bitmap1;
      if (!WindowsAPI.GetWindowRect(hwnd, ref lpRect))
      {
        bitmap1 = (Bitmap) null;
      }
      else
      {
        Bitmap bitmap2 = new Bitmap(lpRect.right - lpRect.left, lpRect.bottom - lpRect.top);
        Graphics graphics = Graphics.FromImage((Image) bitmap2);
        IntPtr hdc = graphics.GetHdc();
        IntPtr windowDc = WindowsAPI.GetWindowDC(hwnd);
        WindowsAPI.BitBlt(hdc, 0, 0, lpRect.right - lpRect.left, lpRect.bottom - lpRect.top, windowDc, 0, 0, 1087111200U);
        graphics.ReleaseHdc(hdc);
        WindowsAPI.ReleaseDC(hwnd, windowDc);
        graphics.Dispose();
        bitmap1 = bitmap2;
      }
      return bitmap1;
    }

    public void PrintScreen()
    {
      WindowsAPI.keybd_event((byte) 44, (byte) 0, 2, 0);
    }

    public void PrintScreenEx()
    {
      INPUT input = new INPUT();
      input.ki.wVk = (short) 44;
      input.ki.wScan = (short) 0;
      input.ki.dwFlags = 1;
      input.ki.dwExtraInfo = IntPtr.Zero;
      input.type = 1;
      int num = (int) WindowsAPI.SendInput(1U, new INPUT[1]
      {
        input
      }, Marshal.SizeOf((object) input));
    }

    public Image GetDestopImage()
    {
      int width = Screen.PrimaryScreen.Bounds.Width;
      int height = Screen.PrimaryScreen.Bounds.Height;
      Bitmap bitmap = new Bitmap(width, height);
      Graphics.FromImage((Image) bitmap).CopyFromScreen(0, 0, 0, 0, new Size(width, height));
      Clipboard.SetImage((Image) bitmap);
      return (Image) bitmap;
    }

    public Bitmap CaptureHandle(IntPtr handle)
    {
      Bitmap bitmap = (Bitmap) null;
      try
      {
        using (Graphics g = Graphics.FromHwnd(handle))
        {
          RECT lpRect = new RECT();
          WindowsAPI.GetWindowRect(handle, ref lpRect);
          if ((int) g.VisibleClipBounds.Width > 0)
          {
            if ((int) g.VisibleClipBounds.Height > 0)
            {
              bitmap = new Bitmap(lpRect.right - lpRect.left, lpRect.bottom - lpRect.top, g);
              using (Graphics graphics = Graphics.FromImage((Image) bitmap))
                graphics.CopyFromScreen(lpRect.left, lpRect.top, 0, 0, new Size(lpRect.right - lpRect.left, lpRect.bottom - lpRect.top), CopyPixelOperation.SourceCopy);
            }
          }
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString(), "Capture failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      return bitmap;
    }

    public void Magnify(Bitmap bmp, int multiple)
    {
      if (bmp == null)
        return;
      if (multiple < 1)
        multiple = 1;
      Size size = bmp.Size;
      IntPtr hbitmap = bmp.GetHbitmap();
      IntPtr dc = WindowsAPI.GetDC(this.DeskHwnd);
      IntPtr compatibleDc = WindowsAPI.CreateCompatibleDC(dc);
      IntPtr hgdiobj = WindowsAPI.SelectObject(compatibleDc, hbitmap);
      Point currentPos = this.GetCurrentPos();
      WindowsAPI.StretchBlt(dc, currentPos.X - 3, currentPos.Y - 6, bmp.Width * multiple, bmp.Height * multiple, compatibleDc, 0, 0, bmp.Width, bmp.Height, 13369376);
      WindowsAPI.DeleteObject(WindowsAPI.SelectObject(compatibleDc, hgdiobj));
      WindowsAPI.DeleteDC(compatibleDc);
    }

    public void Magnify(Bitmap bmp, int multiple, IntPtr hwnd)
    {
      if (bmp == null)
        return;
      Point location = this.GetLocation(hwnd);
      if (multiple < 1)
        multiple = 1;
      Size size = bmp.Size;
      IntPtr hbitmap = bmp.GetHbitmap();
      IntPtr dc = WindowsAPI.GetDC(hwnd);
      IntPtr compatibleDc = WindowsAPI.CreateCompatibleDC(dc);
      IntPtr hgdiobj = WindowsAPI.SelectObject(compatibleDc, hbitmap);
      WindowsAPI.StretchBlt(dc, 0, location.Y - 10, bmp.Width * multiple, bmp.Height * multiple, compatibleDc, 0, 0, bmp.Width, bmp.Height, 13369376);
      WindowsAPI.DeleteObject(WindowsAPI.SelectObject(compatibleDc, hgdiobj));
      WindowsAPI.DeleteDC(compatibleDc);
    }

    public Bitmap MagnifyEx(int Width, int Height, int x, int y, int multiple)
    {
      IntPtr dc = WindowsAPI.CreateDC("DISPLAY", (string) null, (string) null, IntPtr.Zero);
      IntPtr compatibleDc = WindowsAPI.CreateCompatibleDC(dc);
      IntPtr compatibleBitmap = WindowsAPI.CreateCompatibleBitmap(dc, Width, Height);
      IntPtr num = WindowsAPI.SelectObject(compatibleDc, compatibleBitmap);
      WindowsAPI.BitBlt(compatibleDc, 0, 0, Width, Height, dc, x, y, 1087111200U);
      Bitmap bitmap1;
      if (WindowsAPI.StretchBlt(compatibleDc, 0, 0, Width * multiple, Height * multiple, compatibleDc, 0, 0, Width, Height, 13369376))
      {
        Bitmap bitmap2 = Image.FromHbitmap(WindowsAPI.SelectObject(compatibleDc, num));
        WindowsAPI.ReleaseDC(compatibleBitmap, dc);
        WindowsAPI.DeleteDC(dc);
        WindowsAPI.DeleteDC(compatibleDc);
        WindowsAPI.DeleteDC(num);
        WindowsAPI.DeleteObject(compatibleBitmap);
        bitmap1 = bitmap2;
      }
      else
        bitmap1 = (Bitmap) null;
      return bitmap1;
    }

    public void Register(IntPtr hwnd, Keys key)
    {
      WindowsAPI.RegisterHotKey(hwnd, 17, 2U, key);
    }

    public void Register(IntPtr hwnd, int key)
    {
      int WParam = 4 * 256 + 65;
      WindowsAPI.SendMessage(hwnd, 50U, WParam, 0);
    }

    public void UnRegister(IntPtr hwnd)
    {
      WindowsAPI.UnregisterHotKey(hwnd, 17);
    }

    public Point GetCursorPos(TextBox textBox)
    {
      Point point = new Point(0, 0);
      int WParam = WindowsAPI.SendMessage(textBox.Handle, 201U, textBox.SelectionStart, 0);
      int num = textBox.SelectionStart - WindowsAPI.SendMessage(textBox.Handle, 187U, WParam, 0);
      point.Y = WParam + 1;
      point.X = num + 1;
      return point;
    }

    public Point GetCursorPos(RichTextBox richTextBox)
    {
      Point point = new Point(0, 0);
      int WParam = WindowsAPI.SendMessage(richTextBox.Handle, 201U, richTextBox.SelectionStart, 0);
      int num = richTextBox.SelectionStart - WindowsAPI.SendMessage(richTextBox.Handle, 187U, WParam, 0);
      point.Y = WParam + 1;
      point.X = num + 1;
      return point;
    }

    public void GoToLine(TextBox textBox, int line)
    {
      textBox.SelectionStart = WindowsAPI.SendMessage(textBox.Handle, 187U, line - 1, 0);
      textBox.ScrollToCaret();
    }

    public void RandomDrag(Form form)
    {
      form.MouseDown += new MouseEventHandler(this.form_MouseDown);
    }

    public void RandomDrag(Control control)
    {
      control.MouseDown += new MouseEventHandler(this.control_MouseDown);
    }

    private void form_MouseDown(object sender, MouseEventArgs e)
    {
      Form form = (Form) sender;
      WindowsAPI.ReleaseCapture();
      if (form.IsDisposed)
        return;
      WindowsAPI.SendMessage(form.Handle, 161U, 2, 0);
    }

    private void control_MouseDown(object sender, MouseEventArgs e)
    {
      Control control = (Control) sender;
      WindowsAPI.ReleaseCapture();
      WindowsAPI.SendMessage(control.Handle, 161U, 2, 0);
    }

    public void Shake(IntPtr hwnd, int times)
    {
      RECT lpRect = new RECT();
      int dwMilliseconds = 40;
      int num = 4;
      for (int index = 0; index < times; ++index)
      {
        WindowsAPI.GetWindowRect(hwnd, ref lpRect);
        this.WindowMove(hwnd, lpRect.left - num, lpRect.top);
        WindowsAPI.Sleep(dwMilliseconds);
        this.WindowMove(hwnd, lpRect.left, lpRect.top - num);
        WindowsAPI.Sleep(dwMilliseconds);
        this.WindowMove(hwnd, lpRect.left + num, lpRect.top);
        WindowsAPI.Sleep(dwMilliseconds);
        this.WindowMove(hwnd, lpRect.left, lpRect.top + num);
        WindowsAPI.Sleep(dwMilliseconds);
        this.WindowMove(hwnd, lpRect.left, lpRect.top);
      }
    }

    public void Shake(IntPtr hwnd, int times, int speed)
    {
      RECT lpRect = new RECT();
      int num = 4;
      for (int index = 0; index < times; ++index)
      {
        WindowsAPI.GetWindowRect(hwnd, ref lpRect);
        this.WindowMove(hwnd, lpRect.left - num, lpRect.top);
        WindowsAPI.Sleep(speed);
        this.WindowMove(hwnd, lpRect.left, lpRect.top - num);
        WindowsAPI.Sleep(speed);
        this.WindowMove(hwnd, lpRect.left + num, lpRect.top);
        WindowsAPI.Sleep(speed);
        this.WindowMove(hwnd, lpRect.left, lpRect.top + num);
        WindowsAPI.Sleep(speed);
        this.WindowMove(hwnd, lpRect.left, lpRect.top);
      }
    }

    public void ShakeQQ(IntPtr hwnd, int times)
    {
      this.PlaySound(new RegeditManageMent().GetValue("SOFTWARE\\TENCENT\\QQ\\", Registry.LocalMachine, "Install") + "sound\\up.wav");
      RECT lpRect = new RECT();
      int dwMilliseconds = 40;
      int num = 4;
      for (int index = 0; index < times; ++index)
      {
        WindowsAPI.GetWindowRect(hwnd, ref lpRect);
        this.WindowMove(hwnd, lpRect.left + num, lpRect.top);
        WindowsAPI.Sleep(dwMilliseconds);
        this.WindowMove(hwnd, lpRect.left, lpRect.top - num);
        WindowsAPI.Sleep(dwMilliseconds);
        this.WindowMove(hwnd, lpRect.left - num, lpRect.top);
        WindowsAPI.Sleep(dwMilliseconds);
        this.WindowMove(hwnd, lpRect.left, lpRect.top + num);
        WindowsAPI.Sleep(dwMilliseconds);
        this.WindowMove(hwnd, lpRect.left, lpRect.top);
      }
    }

    public void ShakeQQ(IntPtr hwnd, int times, int speed)
    {
      this.PlaySound(new RegeditManageMent().GetValue("SOFTWARE\\TENCENT\\QQ\\", Registry.LocalMachine, "Install") + "sound\\up.wav");
      RECT lpRect = new RECT();
      int num = 4;
      for (int index = 0; index < times; ++index)
      {
        WindowsAPI.GetWindowRect(hwnd, ref lpRect);
        this.WindowMove(hwnd, lpRect.left + num, lpRect.top);
        WindowsAPI.Sleep(speed);
        this.WindowMove(hwnd, lpRect.left, lpRect.top - num);
        WindowsAPI.Sleep(speed);
        this.WindowMove(hwnd, lpRect.left - num, lpRect.top);
        WindowsAPI.Sleep(speed);
        this.WindowMove(hwnd, lpRect.left, lpRect.top + num);
        WindowsAPI.Sleep(speed);
        this.WindowMove(hwnd, lpRect.left, lpRect.top);
      }
    }

    public void ShakeExA(IntPtr hwnd)
    {
      int maxValue = 5;
      int x = this.GetLocation(hwnd).X;
      int y = this.GetLocation(hwnd).Y;
      Random random = new Random();
      for (int index = 0; index < 100; ++index)
      {
        int num1 = random.Next(maxValue);
        int num2 = random.Next(maxValue);
        if (num1 % 2 == 0)
          this.WindowMove(hwnd, x + num1, y);
        else
          this.WindowMove(hwnd, x - num1, y);
        if (num2 % 2 == 0)
          this.WindowMove(hwnd, x, y + num2);
        else
          this.WindowMove(hwnd, x, y + num2);
      }
      this.WindowMove(hwnd, x, y);
    }

    public void ShakeExB(Form form)
    {
      int maxValue = 5;
      int x = form.Location.X;
      int y = form.Location.Y;
      Random random = new Random();
      for (int index = 0; index < 50; ++index)
      {
        int num1 = random.Next(maxValue);
        int num2 = random.Next(maxValue);
        if (num1 % 2 == 0)
          form.Left += num1;
        else
          form.Left -= num1;
        if (num2 % 2 == 0)
          form.Top += num2;
        else
          form.Top -= num2;
        Thread.Sleep(1);
      }
      form.Left = x;
      form.Top = y;
    }

    public Icon GetFileIcon(string path, int index)
    {
      Icon icon;
      if (!File.Exists(path))
      {
        icon = SystemIcons.WinLogo;
      }
      else
      {
        int[] phiconLarge = new int[1];
        int[] phiconSmall = new int[1];
        int num = (int) WindowsAPI.ExtractIconEx(path, index, phiconLarge, phiconSmall, 1U);
        icon = Icon.FromHandle(new IntPtr(phiconSmall[0]));
      }
      return icon;
    }

    public void SetIcon(Form form, string path, int index)
    {
      if (!File.Exists(path))
        return;
      IntPtr handle = new IntPtr(WindowsAPI.ExtractIcon(form.Handle.ToInt32(), path, index));
      if (handle == IntPtr.Zero || handle.ToInt32() == 0)
        return;
      form.Icon = Icon.FromHandle(handle);
    }

    public void OwnIcon(Form form)
    {
      IntPtr handle = new IntPtr(WindowsAPI.ExtractIcon(form.Handle.ToInt32(), "./" + Path.GetFileName(Application.ExecutablePath), 0));
      if (handle == IntPtr.Zero)
        return;
      form.Icon = Icon.FromHandle(handle);
    }

    public class ScreenCapture
    {
      public Image CaptureScreen()
      {
        return this.CaptureWindow(WindowsAPI.GetDesktopWindow());
      }

      public Image CaptureScreen(IntPtr hwnd)
      {
        return this.CaptureWindow(hwnd);
      }

      public Image CaptureWindow(IntPtr handle)
      {
        IntPtr windowDc = WindowsAPI.GetWindowDC(handle);
        RECT lpRect = new RECT();
        WindowsAPI.GetWindowRect(handle, ref lpRect);
        int nWidth = lpRect.right - lpRect.left;
        int nHeight = lpRect.bottom - lpRect.top;
        IntPtr compatibleDc = WindowsAPI.CreateCompatibleDC(windowDc);
        IntPtr compatibleBitmap = WindowsAPI.CreateCompatibleBitmap(windowDc, nWidth, nHeight);
        IntPtr hgdiobj = WindowsAPI.SelectObject(compatibleDc, compatibleBitmap);
        WindowsAPI.BitBlt(compatibleDc, 0, 0, nWidth, nHeight, windowDc, 0, 0, 13369376U);
        WindowsAPI.SelectObject(compatibleDc, hgdiobj);
        WindowsAPI.DeleteDC(compatibleDc);
        WindowsAPI.ReleaseDC(handle, windowDc);
        Image image = (Image) Image.FromHbitmap(compatibleBitmap);
        WindowsAPI.DeleteObject(compatibleBitmap);
        return image;
      }

      public void CaptureWindowToFile(IntPtr handle, string filename, ImageFormat format)
      {
        this.CaptureWindow(handle).Save(filename, format);
      }

      public void CaptureScreenToFile(string filename, ImageFormat format)
      {
        this.CaptureScreen().Save(filename, format);
      }
    }

    private delegate bool Delegate_Beep(uint dwFreq, uint dwDuration);

    public class PlayAudio
    {
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
      private string Name = "";
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
      private string durLength = "";
      [MarshalAs(UnmanagedType.LPTStr)]
      private string TemStr = "";
      public APIMethod.PlayAudio.structMCI mc = new APIMethod.PlayAudio.structMCI();
      private System.Windows.Forms.Timer time;
      private int ilong;

      public string FileName
      {
        get
        {
          return this.mc.iName;
        }
        set
        {
          try
          {
            this.TemStr = "";
            this.TemStr = this.TemStr.PadLeft((int) sbyte.MaxValue, Convert.ToChar(" "));
            this.Name = this.Name.PadLeft(260, Convert.ToChar(" "));
            this.mc.iName = value;
            if (!Path.HasExtension(this.mc.iName))
            {
              this.mc.iName = Path.GetFileNameWithoutExtension(this.mc.iName);
              this.mc.iName = this.mc.iName + ".mp3";
            }
            this.ilong = WindowsAPI.GetShortPathName(this.mc.iName, this.Name, this.Name.Length);
            this.Name = this.GetCurrPath(this.Name);
            this.Name = "open " + (object) Convert.ToChar(34) + this.Name + (string) (object) Convert.ToChar(34) + " alias media";
            this.ilong = WindowsAPI.mciSendString("close all", this.TemStr, this.TemStr.Length, IntPtr.Zero);
            this.ilong = WindowsAPI.mciSendString(this.Name, this.TemStr, this.TemStr.Length, IntPtr.Zero);
            this.ilong = WindowsAPI.mciSendString("set media time format milliseconds", this.TemStr, this.TemStr.Length, IntPtr.Zero);
            this.mc.state = APIMethod.PlayAudio.State.mStop;
          }
          catch
          {
            int num = (int) MessageBox.Show("出错错误!");
          }
        }
      }

      public int Duration
      {
        get
        {
          this.durLength = "";
          this.durLength = this.durLength.PadLeft(128, Convert.ToChar(" "));
          WindowsAPI.mciSendString("status media length", this.durLength, this.durLength.Length, IntPtr.Zero);
          this.durLength = this.durLength.Trim();
          return !(this.durLength == "") ? (int) (Convert.ToDouble(this.durLength) / 1000.0) : 0;
        }
      }

      public int CurrentPosition
      {
        get
        {
          this.durLength = "";
          this.durLength = this.durLength.PadLeft(128, Convert.ToChar(" "));
          WindowsAPI.mciSendString("status media position", this.durLength, this.durLength.Length, IntPtr.Zero);
          this.durLength = this.durLength.Trim();
          if (this.durLength == "")
            return 0;
          try
          {
            this.mc.iPos = (int) (Convert.ToDouble(this.durLength) / 1000.0);
            return this.mc.iPos;
          }
          catch
          {
            return this.mc.iPos = 0;
          }
        }
      }

      public event APIMethod.PlayAudio.Loop Playing
      {
        [MethodImpl(MethodImplOptions.Synchronized)] add
        {
        }
        [MethodImpl(MethodImplOptions.Synchronized)] remove
        {
        }
      }

      public event APIMethod.PlayAudio.Loop Stoped
      {
        [MethodImpl(MethodImplOptions.Synchronized)] add
        {
        }
        [MethodImpl(MethodImplOptions.Synchronized)] remove
        {
        }
      }

      public event APIMethod.PlayAudio.Loop Paused
      {
        [MethodImpl(MethodImplOptions.Synchronized)] add
        {
        }
        [MethodImpl(MethodImplOptions.Synchronized)] remove
        {
        }
      }

      public PlayAudio()
      {
        this.time = new System.Windows.Forms.Timer();
        this.time.Interval = 500;
        this.time.Tick += new EventHandler(this.time_Tick);
      }

      public void Play()
      {
        this.time.Enabled = true;
        this.TemStr = "";
        this.TemStr = this.TemStr.PadLeft((int) sbyte.MaxValue, Convert.ToChar(" "));
        WindowsAPI.mciSendString("play media", this.TemStr, this.TemStr.Length, IntPtr.Zero);
        this.mc.state = APIMethod.PlayAudio.State.mPlaying;
      }

      public void Stop()
      {
        this.TemStr = "";
        this.TemStr = this.TemStr.PadLeft(128, Convert.ToChar(" "));
        this.ilong = WindowsAPI.mciSendString("close media", this.TemStr, 128, IntPtr.Zero);
        this.ilong = WindowsAPI.mciSendString("close all", this.TemStr, 128, IntPtr.Zero);
        this.mc.state = APIMethod.PlayAudio.State.mStop;
        this.time.Enabled = false;
      }

      public void Puase()
      {
        this.TemStr = "";
        this.TemStr = this.TemStr.PadLeft(128, Convert.ToChar(" "));
        this.ilong = WindowsAPI.mciSendString("pause media", this.TemStr, this.TemStr.Length, IntPtr.Zero);
        this.mc.state = APIMethod.PlayAudio.State.mPuase;
      }

      public void OpenCD()
      {
        WindowsAPI.mciSendString("set cdaudio door open", "", 0, IntPtr.Zero);
      }

      public void CloseCD()
      {
        WindowsAPI.mciSendString("set cdaudio door closed", "", 0, IntPtr.Zero);
      }

      private string GetCurrPath(string name)
      {
        string str;
        if (name.Length < 1)
        {
          str = "";
        }
        else
        {
          name = name.Trim();
          name = name.Substring(0, name.Length - 1);
          str = name;
        }
        return str;
      }

      private void time_Tick(object sender, EventArgs e)
      {
        if (this.mc.state == APIMethod.PlayAudio.State.mPlaying)
          this.OnPlayLoop();
        else if (this.mc.state == APIMethod.PlayAudio.State.mPuase)
        {
          this.OnPaused();
        }
        else
        {
          if (this.mc.state != APIMethod.PlayAudio.State.mStop)
            return;
          this.OnStoped();
        }
      }

      private void OnPlayLoop()
      {
      }

      private void OnPaused()
      {
      }

      private void OnStoped()
      {
      }

      public enum State
      {
        mPlaying = 1,
        mPuase = 2,
        mStop = 3,
      }

      public struct structMCI
      {
        public bool bMut;
        public int iDur;
        public int iPos;
        public int iVol;
        public int iBal;
        public string iName;
        public APIMethod.PlayAudio.State state;
      }

      public delegate void Loop(object sender, EventArgs e);
    }

    public class SystemMenu
    {
      public const int M_AboutID = 256;
      public const int M_ResetID = 257;
      public const int M_Separator = 258;
      private IntPtr syshwnd;
      private int count;

      public SystemMenu(IntPtr hwnd)
      {
        this.syshwnd = WindowsAPI.GetSystemMenu(hwnd, 0);
        this.count = this.GetMenuCount(hwnd);
      }

      public static void ResetSystemMenu(IntPtr hwnd)
      {
        WindowsAPI.GetSystemMenu(hwnd, 1);
      }

      public bool InsertSeparator(uint Pos)
      {
        return WindowsAPI.InsertMenu(this.syshwnd, Pos, 3072U, 258U, "");
      }

      public bool InsertMenu(uint Pos, uint ID, string Item)
      {
        return WindowsAPI.InsertMenu(this.syshwnd, Pos, 1024U, ID, Item);
      }

      public bool InsertMenu(uint Pos, uint Flags, uint ID, string Item)
      {
        return WindowsAPI.InsertMenu(this.syshwnd, Pos, Flags, ID, Item);
      }

      public bool AppendSeparator()
      {
        return WindowsAPI.AppendMenu(this.syshwnd, 3072U, 258U, "");
      }

      public bool AppendMenu(uint ID, string Item)
      {
        return WindowsAPI.AppendMenu(this.syshwnd, 0U, ID, Item);
      }

      public bool AppendMenu(uint ID, string Item, uint Flags)
      {
        return WindowsAPI.AppendMenu(this.syshwnd, Flags, ID, Item);
      }

      public bool ModifyMenu(uint Pos, uint flags, uint ID, string title)
      {
        return WindowsAPI.ModifyMenu(this.syshwnd, Pos, flags, ID, title);
      }

      public bool DeleteMove()
      {
        return WindowsAPI.DeleteMenu(this.syshwnd, 61456U, 4096U);
      }

      public bool DeleteSIZE()
      {
        return WindowsAPI.DeleteMenu(this.syshwnd, 61440U, 4096U);
      }

      public bool DeleteMINIMIZE()
      {
        return WindowsAPI.DeleteMenu(this.syshwnd, 61472U, 4096U);
      }

      public bool DeleteMAXIMIZE()
      {
        return WindowsAPI.DeleteMenu(this.syshwnd, 61488U, 4096U);
      }

      public bool DeleteCLOSE()
      {
        return WindowsAPI.DeleteMenu(this.syshwnd, 61536U, 4096U);
      }

      public bool DeleteRESTORE()
      {
        return WindowsAPI.DeleteMenu(this.syshwnd, 61728U, 4096U);
      }

      public bool DeleteSEPARATOR()
      {
        return WindowsAPI.DeleteMenu(this.syshwnd, 61455U, 2048U);
      }

      public bool DeleteAll()
      {
        bool flag = false;
        for (int index = this.count - 1; index >= 0; --index)
          flag = WindowsAPI.DeleteMenu(this.syshwnd, (uint) index, 1024U);
        return flag;
      }

      private bool DeleteMove(IntPtr hMenu)
      {
        return WindowsAPI.DeleteMenu(hMenu, 61456U, 4096U);
      }

      private bool DeleteSIZE(IntPtr hMenu)
      {
        return WindowsAPI.DeleteMenu(hMenu, 61440U, 4096U);
      }

      private bool DeleteMINIMIZE(IntPtr hMenu)
      {
        return WindowsAPI.DeleteMenu(hMenu, 61472U, 4096U);
      }

      private bool DeleteMAXIMIZE(IntPtr hMenu)
      {
        return WindowsAPI.DeleteMenu(hMenu, 61488U, 4096U);
      }

      private bool DeleteCLOSE(IntPtr hMenu)
      {
        return WindowsAPI.DeleteMenu(hMenu, 61536U, 4096U);
      }

      private bool DeleteRESTORE(IntPtr hMenu)
      {
        return WindowsAPI.DeleteMenu(hMenu, 61728U, 4096U);
      }

      private bool RemoveMove(IntPtr hMenu)
      {
        return WindowsAPI.RemoveMenu(hMenu, 61456U, 4096U);
      }

      private bool RemoveSIZE(IntPtr hMenu)
      {
        return WindowsAPI.RemoveMenu(hMenu, 61440U, 4096U);
      }

      private bool RemoveMINIMIZE(IntPtr hMenu)
      {
        return WindowsAPI.RemoveMenu(hMenu, 61472U, 4096U);
      }

      private bool RemoveMAXIMIZE(IntPtr hMenu)
      {
        return WindowsAPI.RemoveMenu(hMenu, 61488U, 4096U);
      }

      private bool RemoveCLOSE(IntPtr hMenu)
      {
        return WindowsAPI.RemoveMenu(hMenu, 61536U, 4096U);
      }

      private bool RemoveRESTORE(IntPtr hMenu)
      {
        return WindowsAPI.RemoveMenu(hMenu, 61728U, 4096U);
      }

      public MENUINFO GetWindowMenu(IntPtr hwnd)
      {
        MENUINFO lpcmi = new MENUINFO();
        lpcmi.cbSize = Marshal.SizeOf((object) lpcmi);
        lpcmi.fMask = 31;
        WindowsAPI.GetMenuInfo(WindowsAPI.GetSystemMenu(hwnd, 0), ref lpcmi);
        return lpcmi;
      }

      public void SystemMenuColor(Form frm, System.Drawing.Color color)
      {
        MENUINFO lpcmi = new MENUINFO();
        lpcmi.cbSize = Marshal.SizeOf((object) lpcmi);
        lpcmi.fMask = 2;
        Bitmap bitmap = new Bitmap(200, 200);
        Brush brush = (Brush) new SolidBrush(color);
        Graphics.FromImage((Image) bitmap).FillRectangle(brush, new Rectangle(0, 0, 200, 200));
        lpcmi.hbrBack = bitmap != null ? WindowsAPI.CreatePatternBrush(bitmap.GetHbitmap()) : IntPtr.Zero;
        try
        {
          WindowsAPI.SetMenuInfo(WindowsAPI.GetSystemMenu(frm.Handle, 0), ref lpcmi);
        }
        catch
        {
        }
      }

      public void SystemMenuColor(Form frm, Image image)
      {
        MENUINFO lpcmi = new MENUINFO();
        lpcmi.cbSize = Marshal.SizeOf((object) lpcmi);
        lpcmi.fMask = 2;
        Bitmap bitmap = new Bitmap(200, 200);
        Brush brush = (Brush) new TextureBrush(image);
        Graphics.FromImage((Image) bitmap).FillRectangle(brush, new Rectangle(0, 0, 200, 200));
        lpcmi.hbrBack = bitmap != null ? WindowsAPI.CreatePatternBrush(bitmap.GetHbitmap()) : IntPtr.Zero;
        try
        {
          WindowsAPI.SetMenuInfo(WindowsAPI.GetSystemMenu(frm.Handle, 0), ref lpcmi);
        }
        catch
        {
        }
      }

      public void SystemMenuColor(Form frm, System.Drawing.Color color1, System.Drawing.Color color2, int direct)
      {
        MENUINFO lpcmi = new MENUINFO();
        lpcmi.cbSize = Marshal.SizeOf((object) lpcmi);
        lpcmi.fMask = 2;
        Bitmap bitmap = new Bitmap(200, 200);
        Point point1;
        Point point2;
        if (direct == 0)
        {
          point1 = new Point(0, 0);
          point2 = new Point(200, 0);
        }
        else if (direct == 1)
        {
          point1 = new Point(0, 0);
          point2 = new Point(0, 200);
        }
        else if (direct == 2)
        {
          point2 = new Point(0, 0);
          point1 = new Point(200, 200);
        }
        else
        {
          point2 = new Point(200, 0);
          point1 = new Point(0, 200);
        }
        Brush brush = (Brush) new LinearGradientBrush(point1, point2, color1, color2);
        Graphics.FromImage((Image) bitmap).FillRectangle(brush, new Rectangle(0, 0, 200, 200));
        lpcmi.hbrBack = bitmap != null ? WindowsAPI.CreatePatternBrush(bitmap.GetHbitmap()) : IntPtr.Zero;
        try
        {
          WindowsAPI.SetMenuInfo(WindowsAPI.GetSystemMenu(frm.Handle, 0), ref lpcmi);
        }
        catch
        {
        }
      }

      public void UnSystemMenuColor(Form frm)
      {
        MENUINFO lpcmi = new MENUINFO();
        lpcmi.cbSize = Marshal.SizeOf((object) lpcmi);
        lpcmi.fMask = 2;
        lpcmi.hbrBack = IntPtr.Zero;
        try
        {
          WindowsAPI.SetMenuInfo(WindowsAPI.GetSystemMenu(frm.Handle, 0), ref lpcmi);
        }
        catch
        {
        }
      }

      public int GetMenuCount(IntPtr hwnd)
      {
        return WindowsAPI.GetMenuItemCount(WindowsAPI.GetSystemMenu(hwnd, 0));
      }
    }

    public class WindowsMessage
    {
      public static void SendMessage(string destProcessName, int msgID, string strMsg)
      {
        if (strMsg == null)
          return;
        COPYDATASTRUCT lParam;
        lParam.dwData = (IntPtr) msgID;
        lParam.lpData = strMsg;
        lParam.cbData = Encoding.Default.GetBytes(strMsg).Length + 1;
        WindowsAPI.SendMessage(WindowsAPI.FindWindow((string) null, destProcessName), 74U, 0, ref lParam);
      }

      public static string ReceiveMessage(ref Message m)
      {
        return ((COPYDATASTRUCT) m.GetLParam(typeof (COPYDATASTRUCT))).lpData;
      }
    }

    public class Shell_NotifyIconEx
    {
      public static readonly Version myVersion = new Version(1, 2);
      private readonly IntPtr formTmpHwnd = IntPtr.Zero;
      internal IntPtr formHwnd = IntPtr.Zero;
      internal IntPtr contextMenuHwnd = IntPtr.Zero;
      internal readonly int WM_NOTIFY_TRAY = 3025;
      internal readonly uint uID = 5000U;
      private readonly bool VersionOk;
      private bool forgetDelNotifyBox;
      internal APIMethod.Shell_NotifyIconEx.delegateOfCallBack _delegateOfCallBack;

      public bool VersionPass
      {
        get
        {
          return this.VersionOk;
        }
      }

      public Shell_NotifyIconEx(IntPtr hwnd)
      {
        ++this.WM_NOTIFY_TRAY;
        ++this.uID;
        this.formTmpHwnd = hwnd;
        this.VersionOk = this.GetShell32VersionInfo() >= 5;
      }

      ~Shell_NotifyIconEx()
      {
        if (!this.forgetDelNotifyBox)
          return;
        this.DelNotifyBox();
      }

      private NOTIFYICONDATA GetNOTIFYICONDATA(IntPtr iconHwnd, string sTip, string boxTitle, string boxText)
      {
        NOTIFYICONDATA notifyicondata = new NOTIFYICONDATA();
        notifyicondata.cbSize = Marshal.SizeOf((object) notifyicondata);
        notifyicondata.hWnd = this.formTmpHwnd;
        notifyicondata.uID = this.uID;
        notifyicondata.uFlags = 23U;
        notifyicondata.uCallbackMessage = (uint) this.WM_NOTIFY_TRAY;
        notifyicondata.hIcon = iconHwnd;
        notifyicondata.uTimeout = 10003U;
        notifyicondata.dwInfoFlags = 1;
        notifyicondata.szTip = sTip;
        notifyicondata.szInfoTitle = boxTitle;
        notifyicondata.szInfo = boxText;
        return notifyicondata;
      }

      private int GetShell32VersionInfo()
      {
        FileInfo fileInfo = new FileInfo(Path.Combine(Environment.SystemDirectory, "shell32.dll"));
        if (fileInfo.Exists)
        {
          FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(fileInfo.FullName);
          int length = versionInfo.FileVersion.IndexOf('.');
          if (length > 0)
          {
            try
            {
              return int.Parse(versionInfo.FileVersion.Substring(0, length));
            }
            catch
            {
            }
          }
        }
        return 0;
      }

      public int AddNotifyBox(IntPtr iconHwnd, string sTip, string boxTitle, string boxText)
      {
        int num;
        if (!this.VersionOk)
        {
          num = -1;
        }
        else
        {
          NOTIFYICONDATA notifyicondata = this.GetNOTIFYICONDATA(iconHwnd, sTip, boxTitle, boxText);
          if (WindowsAPI.Shell_NotifyIcon(0, ref notifyicondata))
          {
            this.forgetDelNotifyBox = true;
            num = 1;
          }
          else
            num = 0;
        }
        return num;
      }

      public int DelNotifyBox()
      {
        int num;
        if (!this.VersionOk)
        {
          num = -1;
        }
        else
        {
          NOTIFYICONDATA notifyicondata = this.GetNOTIFYICONDATA(IntPtr.Zero, (string) null, (string) null, (string) null);
          if (WindowsAPI.Shell_NotifyIcon(2, ref notifyicondata))
          {
            this.forgetDelNotifyBox = false;
            num = 1;
          }
          else
            num = 0;
        }
        return num;
      }

      public int ModiNotifyBox(IntPtr iconHwnd, string sTip, string boxTitle, string boxText)
      {
        int num;
        if (!this.VersionOk)
        {
          num = -1;
        }
        else
        {
          NOTIFYICONDATA notifyicondata = this.GetNOTIFYICONDATA(iconHwnd, sTip, boxTitle, boxText);
          num = WindowsAPI.Shell_NotifyIcon(1, ref notifyicondata) ? 1 : 0;
        }
        return num;
      }

      public void ConnectMyMenu(IntPtr _formHwnd, IntPtr _contextMenuHwnd)
      {
        this.formHwnd = _formHwnd;
        this.contextMenuHwnd = _contextMenuHwnd;
      }

      public void Dispose()
      {
        this._delegateOfCallBack = (APIMethod.Shell_NotifyIconEx.delegateOfCallBack) null;
      }

      internal delegate void delegateOfCallBack(MouseButtons mb);
    }
  }
}
