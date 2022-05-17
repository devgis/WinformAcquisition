
// Type: Trand.WinAPI.WindowsAPI
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Trand.WinAPI
{
  public class WindowsAPI
  {
    [DllImport("shell32.dll")]
    public static extern int ShellAbout(IntPtr hWnd, string szApp, string szOtherStuff, IntPtr hIcon);

    [DllImport("user32.dll")]
    public static extern bool BlockInput(bool fBlockIt);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern int SendMessage(IntPtr HWnd, uint Msg, int WParam, int LParam);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern int SendMessage(IntPtr HWnd, uint Msg, int WParam, ref COPYDATASTRUCT lParam);

    [DllImport("user32.dll ", EntryPoint = "SendMessageA")]
    public static extern int SendMessage(IntPtr hwnd, uint wMsg, int wParam, StringBuilder lParam);

    [DllImport("user32.dll ", EntryPoint = "SendMessageA")]
    public static extern int SendMessage(IntPtr hwnd, uint wMsg, int wParam, string lParam);

    [DllImport("user32.dll ", EntryPoint = "SendMessageA")]
    public static extern int SendMessage(IntPtr hwnd, uint wMsg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll")]
    public static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, int uType);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public static extern int GetShortPathName(string lpszLongPath, StringBuilder lpszShortPath, int cchBuffer);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public static extern int GetShortPathName(string lpszLongPath, string lpszShortPath, int cchBuffer);

    [DllImport("winmm.dll", CharSet = CharSet.Auto)]
    public static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int cchReturn, IntPtr hwndCallback);

    [DllImport("gdi32.dll")]
    public static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);

    [DllImport("gdi32.dll")]
    public static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, IntPtr lpInitData);

    [DllImport("kernel32")]
    public static extern void GetSystemInfo(ref SYSTEM_INFO lpSystemInfo);

    [DllImport("kernel32")]
    public static extern void GlobalMemoryStatus(ref MEMORYSTATUS lpBuffer);

    [DllImport("advapi32.dll", SetLastError = true)]
    public static extern bool OpenProcessToken(IntPtr ProcessHandle, int DesiredAccess, ref IntPtr TokenHandle);

    [DllImport("advapi32.dll", SetLastError = true)]
    public static extern bool LookupPrivilegeValue(string lpSystemName, string lpName, ref long pluid);

    [DllImport("advapi32.dll", SetLastError = true)]
    public static extern bool AdjustTokenPrivileges(IntPtr TokenHandle, bool DisableAllPrivileges, ref TokPriv1Luid NewState, int BufferLength, IntPtr PreviousState, IntPtr ReturnLength);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool ExitWindowsEx(int uFlags, int dwReason);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int ChangeDisplaySettings([In] ref DEVMODE lpDevMode, int dwFlags);

    [DllImport("kernel32.dll")]
    public static extern bool CloseHandle(IntPtr hObject);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll")]
    public static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern bool EnumWindows(WindowsAPI.WNDENUMPROC lpEnumFunc, int lParam);

    [DllImport("user32.dll")]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll")]
    public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

    [DllImport("user32.dll")]
    public static extern int GetWindowTextW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpString, int nMaxCount);

    [DllImport("user32.dll")]
    public static extern int GetClassNameW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpClassName, int nMaxCount);

    [DllImport("user32.dll")]
    public static extern bool GetComboBoxInfo(IntPtr hwndCombo, ref COMBOBOXINFO info);

    [DllImport("Shlwapi.dll")]
    public static extern void SHAutoComplete(IntPtr hwndEdit, int dwFlags);

    [DllImport("Winmm.dll")]
    public static extern bool PlaySound(string pszSound, IntPtr hmod, int fdwSound);

    [DllImport("user32.dll")]
    public static extern bool GetCaretPos(ref Point lpPoint);

    [DllImport("user32.dll")]
    public static extern bool GetCursorPos(ref Point lpPoint);

    [DllImport("winmm.dll")]
    public static extern bool mciExecute(string pszCommand);

    [DllImport("shell32.dll")]
    public static extern uint ExtractIconEx(string lpszFile, int nIconIndex, int[] phiconLarge, int[] phiconSmall, uint nIcons);

    [DllImport("shell32.dll")]
    public static extern int ExtractIcon(int hInst, string lpszExeFileName, int nIconIndex);

    [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern IntPtr GetSystemMenu(IntPtr hWnd, int bRevert);

    [DllImport("kernel32.dll")]
    public static extern bool GetTempPath(int ccBuffer, StringBuilder lpszBuffer);

    [DllImport("user32.dll", EntryPoint = "InsertMenuW", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern bool InsertMenu(IntPtr hMenu, uint uPosition, uint uFlags, uint uIDNewItem, string lpNewItem);

    [DllImport("user32.dll")]
    public static extern bool DeleteMenu(IntPtr hMenu, uint uPosition, uint uFlags);

    [DllImport("user32.dll")]
    public static extern bool RemoveMenu(IntPtr hMenu, uint nPosition, uint wFlags);

    [DllImport("kernel32.dll")]
    public static extern int GetWindowsDirectory(StringBuilder lpBuffer, int uSize);

    [DllImport("kernel32")]
    public static extern void GetSystemDirectory(StringBuilder lpBuffer, int uSize);

    [DllImport("user32.dll")]
    public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll")]
    public static extern bool GetWindowRect(IntPtr handle, ref RECT lpRect);

    [DllImport("user32.dll")]
    public static extern IntPtr GetDesktopWindow();

    [DllImport("kernel32.dll")]
    public static extern void Sleep(int dwMilliseconds);

    [DllImport("user32.dll")]
    public static extern bool ClipCursor(ref RECT lpRect);

    [DllImport("user32.dll")]
    public static extern int ShowCursor(bool bShow);

    [DllImport("user32.dll")]
    public static extern bool DestroyCursor(IntPtr hCursor);

    [DllImport("user32.dll")]
    public static extern void mouse_event(MouseEventFlag flags, int dx, int dy, int data, int extraInfo);

    [DllImport("user32.dll")]
    public static extern IntPtr GetDlgItem(IntPtr hDlg, int nIDDlgItem);

    [DllImport("user32.dll")]
    public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    [DllImport("user32.dll")]
    public static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

    [DllImport("user32.dll")]
    public static extern IntPtr GetActiveWindow();

    [DllImport("kernel32.dll")]
    public static extern IntPtr GetCurrentProcess();

    [DllImport("kernel32.dll")]
    public static extern int GetCurrentProcessId();

    [DllImport("kernel32.dll")]
    public static extern bool GetExitCodeProcess(IntPtr hProcess, ref int lpExitCode);

    [DllImport("user32.dll")]
    public static extern IntPtr WindowFromPoint(Point Point);

    [DllImport("user32.dll")]
    public static extern IntPtr GetTopWindow(IntPtr hWnd);

    [DllImport("mpr.dll")]
    public static extern int WNetGetConnection(string lpLocalName, StringBuilder lpRemoteName, int lpnLength);

    [DllImport("user32.dll")]
    public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

    [DllImport("user32.dll")]
    public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

    [DllImport("gdi32.dll")]
    public static extern bool GetWindowExtEx(IntPtr hdc, ref Size lpSize);

    [DllImport("user32.dll")]
    public static extern IntPtr GetDC(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern bool GetClientRect(IntPtr hWnd, ref RECT lpRect);

    [DllImport("user32.dll")]
    public static extern IntPtr GetWindowDC(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern uint GetWindowModuleFileName(IntPtr hwnd, StringBuilder lpszFileName, uint cchFileNameMax);

    [DllImport("user32.dll")]
    public static extern int GetWindowTextLength(IntPtr hWnd);

    [DllImport("kernel32.dll")]
    public static extern void GetSystemTime(ref SYSTEMTIME lpSystemTime);

    [DllImport("kernel32.dll")]
    public static extern bool SetSystemTime(ref SYSTEMTIME lpSystemTime);

    [DllImport("gdi32.dll")]
    public static extern bool GetCharWidthFloatA(IntPtr hdc, uint iFirstChar, uint iLastChar, ref float pxBuffer);

    [DllImport("gdi32.dll")]
    public static extern bool GetCharWidth32A(IntPtr hdc, uint iFirstChar, uint iLastChar, ref int lpBuffer);

    [DllImport("user32.dll")]
    public static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

    [DllImport("kernel32.dll")]
    public static extern IntPtr OpenFile(string lpFileName, ref OFSTRUCT lpReOpenBuff, uint uStyle);

    [DllImport("kernel32.dll")]
    public static extern bool SetFileShortName(IntPtr hFile, string lpShortName);

    [DllImport("kernel32")]
    public static extern bool QueryPerformanceCounter(ref long PerformanceCount);

    [DllImport("kernel32.dll")]
    public static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, int dwShareMode, int lpSecurityAttributes, int dwCreationDisposition, uint dwFlagsAndAttributes, int hTemplateFile);

    [DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int SHFileOperation(_SHFILEOPSTRUCT str);

    [DllImport("user32.dll")]
    public static extern bool AdjustWindowRect(ref RECT lpRect, int dwStyle, bool bMenu);

    [DllImport("user32.dll")]
    public static extern bool AdjustWindowRectEx(RECT lpRect, int dwStyle, bool bMenu, int dwExStyle);

    [DllImport("kernel32.dll")]
    public static extern int GetUserDefaultLangID();

    [DllImport("kernel32.dll")]
    public static extern int GetUserDefaultLCID();

    [DllImport("kernel32.dll")]
    public static extern int GetSystemDefaultLangID();

    [DllImport("shell32.dll")]
    public static extern int FindExecutable(string lpFile, string lpDirectory, StringBuilder lpResult);

    [DllImport("kernel32.dll")]
    public static extern int GetTickCount();

    [DllImport("advapi32.dll")]
    public static extern bool AbortSystemShutdown(string lpMachineName);

    [DllImport("user32")]
    public static extern short GetKeyState(int nVirtKey);

    [DllImport("user32")]
    public static extern bool LockWindowUpdate(IntPtr hWndLock);

    [DllImport("kernel32.dll")]
    public static extern bool GetComputerName(StringBuilder lpBuffer, ref int lpnSize);

    [DllImport("shell32.dll")]
    public static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern int WaitForSingleObject(IntPtr hHandle, int dwMilliseconds);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr FindFirstFile(string pFileName, ref WIN32_FIND_DATA pFindFileData);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool FindNextFile(IntPtr hndFindFile, ref WIN32_FIND_DATA lpFindFileData);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool FindClose(IntPtr hndFindFile);

    [DllImport("psapi.dll", CharSet = CharSet.Auto)]
    public static extern int GetModuleFileNameEx(IntPtr hProcess, IntPtr hModule, StringBuilder lpFilename, int nSize);

    [DllImport("kernel32.dll")]
    public static extern int GetModuleFileName(IntPtr hModule, StringBuilder lpFilename, int nSize);

    [DllImport("kernel32.dll")]
    public static extern bool GetVersionEx(ref OSVERSIONINFO lpVersionInformation);

    [DllImport("kernel32.dll")]
    public static extern bool GetVersionEx(ref OSVERSIONINFOEX lpVersionInformation);

    [DllImport("comdlg32.dll", CharSet = CharSet.Auto)]
    public static extern bool GetOpenFileName(OPENFILENAME lpofn);

    [DllImport("kernel32.dll")]
    public static extern int GetStartupInfo(ref STARTUPINFO lpStartupInfo);

    [DllImport("kernel32.dll")]
    public static extern int GetNumberOfConsoleMouseButtons(int lpNumberOfMouseButtons);

    [DllImport("kernel32.dll")]
    public static extern IntPtr LoadLibrary(string lpLibFileName);

    [DllImport("kernel32.dll")]
    public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

    [DllImport("kernel32.dll")]
    public static extern bool FreeLibrary(IntPtr hLibModule);

    [DllImport("kernel32.dll")]
    public static extern IntPtr GetModuleHandle(string lpModuleName);

    [DllImport("kernel32.dll")]
    public static extern int GetFullPathName(string lpFileName, int nBufferLength, StringBuilder lpBuffer, string lpFilePart);

    [DllImport("user32.dll")]
    public static extern int GetMessagePos();

    public static int GET_X_LPARAM(int lParam)
    {
      return lParam & (int) ushort.MaxValue;
    }

    public static int GET_Y_LPARAM(int lParam)
    {
      return lParam >> 16;
    }

    [DllImport("user32.dll")]
    public static extern IntPtr GetParent(IntPtr hWnd);

    [DllImport("kernel32.dll")]
    public static extern bool GetProcessTimes(IntPtr hProcess, ref _FILETIME lpCreationTime, ref _FILETIME lpExitTime, ref _FILETIME lpKernelTime, ref _FILETIME lpUserTime);

    [DllImport("kernel32.dll")]
    public static extern int GetLastError();

    [DllImport("kernel32.dll")]
    public static extern bool FileTimeToLocalFileTime([In] ref _FILETIME lpFileTime, out _FILETIME lpLocalTime);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int FileTimeToSystemTime(IntPtr lpFileTime, IntPtr lpSystemTime);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int FileTimeToSystemTime(ref _FILETIME lpFileTime, ref SYSTEMTIME lpSystemTime);

    [DllImport("kernel32.dll")]
    public static extern bool LocalFileTimeToFileTime([In] ref _FILETIME lpLocalTime, out _FILETIME lpFileTime);

    [DllImport("kernel32.dll")]
    public static extern bool SystemTimeToFileTime([In] ref SYSTEMTIME lpSystemTime, out _FILETIME lpFileTime);

    [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr FindFirstUrlCacheEntry([MarshalAs(UnmanagedType.LPTStr)] string lpszUrlSearchPattern, IntPtr lpFirstCacheEntryInfo, ref int lpdwFirstCacheEntryInfoBufferSize);

    [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool FindNextUrlCacheEntry(IntPtr hEnumHandle, IntPtr lpNextCacheEntryInfo, ref int lpdwNextCacheEntryInfoBufferSize);

    [DllImport("wininet.dll")]
    public static extern bool FindCloseUrlCache(IntPtr hEnumHandle);

    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();

    [DllImport("kernel32.dll")]
    public static extern void RtlZeroMemory(IntPtr Destination, int Length);

    [DllImport("user32.dll")]
    public static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

    [DllImport("user32.dll")]
    public static extern IntPtr LoadCursor(IntPtr hInstance, string lpCursorName);

    [DllImport("user32.dll")]
    public static extern IntPtr LoadCursorFromFile(string lpFileName);

    [DllImport("user32.dll")]
    public static extern IntPtr SetCursor(IntPtr hCursor);

    [DllImport("user32.dll")]
    public static extern IntPtr CreateCursor(IntPtr hInst, int xHotSpot, int yHotSpot, int nWidth, int nHeight, ref int pvANDPlane, ref int pvXORPlane);

    [DllImport("user32.dll")]
    public static extern IntPtr CopyIcon(IntPtr hIcon);

    [DllImport("user32.dll")]
    public static extern bool GetClipCursor(ref RECT lpRect);

    [DllImport("user32.dll")]
    public static extern bool SetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

    [DllImport("user32.dll")]
    public static extern bool ShowOwnedPopups(IntPtr hWnd, bool fShow);

    [DllImport("IpHlpApi.dll")]
    public static extern int GetIfTable(byte[] pIfTable, ref uint pdwSize, bool bOrder);

    [DllImport("Iphlpapi.dll")]
    public static extern int SendARP(int DestIP, int SrcIP, ref IntPtr pMacAddr, ref IntPtr PhyAddrLen);

    [DllImport("Ws2_32.dll")]
    public static extern int inet_addr(string cp);

    [DllImport("comdlg32.dll", CharSet = CharSet.Auto)]
    public static extern bool GetSaveFileName(ref OPENFILENAME lpofn);

    [DllImport("kernel32.dll")]
    public static extern uint WinExec(string lpCmdLine, uint uCmdShow);

    [DllImport("shell32.dll", EntryPoint = "Shell_NotifyIconA")]
    public static extern bool Shell_NotifyIcon(int dwMessage, ref NOTIFYICONDATA lpData);

    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(int x, int y);

    [DllImport("user32.dll")]
    public static extern long SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);

    [DllImport("user32.dll")]
    public static extern int SetLayeredWindowAttributes(IntPtr hwnd, int crKey, int bAlpha, int dwFlags);

    [DllImport("user32.dll")]
    public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

    [DllImport("shell32.dll")]
    public static extern int ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);

    [DllImport("kernel32.dll")]
    public static extern IntPtr OpenProcess(int fdwAccess, bool fInherit, int IDProcess);

    [DllImport("user32.dll")]
    public static extern int GetWindowThreadProcessId(IntPtr hWnd, ref int lpdwProcessId);

    [DllImport("Kernel32.dll", CharSet = CharSet.Ansi)]
    public static extern bool CreateProcess(StringBuilder lpApplicationName, StringBuilder lpCommandLine, SECURITY_ATTRIBUTES lpProcessAttributes, SECURITY_ATTRIBUTES lpThreadAttributes, bool bInheritHandles, int dwCreationFlags, StringBuilder lpEnvironment, StringBuilder lpCurrentDirectory, ref STARTUPINFO lpStartupInfo, ref PROCESS_INFORMATION lpProcessInformation);

    [DllImport("kernel32.dll")]
    public static extern bool TerminateProcess(IntPtr hProcess, int uExitCode);

    [DllImport("kernel32.dll")]
    public static extern int GetProcessId(IntPtr Process);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public static extern bool Module32First(IntPtr hSnapshot, ref MODULEENTRY32 lpme);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr CreateToolhelp32Snapshot(uint dwFlags, int th32ProcessID);

    [DllImport("kernel32.dll")]
    public static extern bool Process32First(IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

    [DllImport("kernel32.dll")]
    public static extern bool Process32Next(IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

    [DllImport("psapi.dll")]
    public static extern bool EnumProcessModules(IntPtr hProcess, IntPtr[] lphModule, int cb, ref int lpcbNeeded);

    [DllImport("user32.dll")]
    public static extern IntPtr SetCapture(IntPtr hWnd);

    [DllImport("kernel32.dll")]
    public static extern bool SetComputerName(string lpComputerName);

    [DllImport("user32.dll")]
    public static extern bool SetCaretPos(int X, int Y);

    [DllImport("kernel32.dll")]
    public static extern bool SetEnvironmentVariable(string lpName, string lpValue);

    [DllImport("user32.dll")]
    public static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);

    [DllImport("user32.dll")]
    public static extern bool SetScrollRange(IntPtr hWnd, int nBar, int nMinPos, int nMaxPos, bool bRedraw);

    [DllImport("user32.dll")]
    public static extern bool EnumChildWindows(IntPtr hWndParent, WindowsAPI.ChildWindowsProc lpEnumFunc, int lParam);

    [DllImport("user32.dll")]
    public static extern IntPtr GetWindow(IntPtr hWnd, uint wCmd);

    [DllImport("user32.dll")]
    public static extern int SetScrollInfo(IntPtr hwnd, int fnBar, SCROLLINFO lpsi, bool fRedraw);

    [DllImport("user32.dll")]
    public static extern bool EnumDisplaySettings(string lpszDeviceName, int iModeNum, ref DEVMODE lpDevMode);

    [DllImport("user32.dll")]
    public static extern bool EnumDisplayDevices(string lpDevice, int iDevNum, ref DISPLAY_DEVICE lpDisplayDevice, int dwFlags);

    [DllImport("user32")]
    public static extern int CallWindowProc(int lpPrevWndFunc, IntPtr hWnd, int Msg, int wParam, int lParam);

    [DllImport("user32.dll")]
    public static extern IntPtr ChildWindowFromPoint(IntPtr hWndParent, Point Point);

    [DllImport("gdi32.dll")]
    public static extern bool Rectangle(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

    [DllImport("gdi32.dll")]
    public static extern int SetROP2(IntPtr hdc, int fnDrawMode);

    [DllImport("gdi32.dll")]
    public static extern IntPtr CreatePen(int fnPenStyle, int nWidth, int crColor);

    [DllImport("gdi32.dll")]
    public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

    [DllImport("user32.dll")]
    public static extern bool EnableWindow(IntPtr hWnd, bool bEnable);

    [DllImport("user32.dll")]
    public static extern bool BringWindowToTop(IntPtr hWnd);

    [DllImport("gdi32.dll")]
    public static extern bool DeleteObject(IntPtr hObject);

    [DllImport("user32.dll")]
    public static extern IntPtr ReleaseDC(IntPtr hDC);

    [DllImport("user32.dll")]
    public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

    [DllImport("kernel32.dll")]
    public static extern string GetCommandLine();

    [DllImport("user32.dll")]
    public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, Keys vk);

    [DllImport("user32.dll")]
    public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

    [DllImport("shell32.dll")]
    public static extern int SHGetFileInfo(string pszPath, int dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

    [DllImport("shell32.dll")]
    public static extern IntPtr ExtractAssociatedIcon(IntPtr hInst, string lpIconPath, ref int lpiIcon);

    [DllImport("shell32.dll")]
    public static extern IntPtr ExtractAssociatedIconEx(IntPtr hInst, string lpIconPath, ref int lpiIcon, ref int lpiIconId);

    [DllImport("user32.dll")]
    public static extern int FillRect(IntPtr hDC, ref RECT lprc, IntPtr hbr);

    [DllImport("gdi32.dll")]
    public static extern IntPtr CreateHatchBrush(int fnStyle, int clrref);

    [DllImport("user32.dll")]
    public static extern bool FlashWindow(IntPtr hWnd, bool bInvert);

    [DllImport("user32.dll")]
    public static extern bool FlashWindowEx(ref FLASHWINFO pfwi);

    [DllImport("comdlg32.dll")]
    public static extern IntPtr FindText(ref FINDREPLACE lpfr);

    [DllImport("comdlg32.dll")]
    public static extern IntPtr ReplaceText(ref FINDREPLACE lpfr);

    [DllImport("comdlg32.dll")]
    public static extern bool ChooseColor(ref CHOOSECOLOR lpcc);

    [DllImport("comdlg32.dll")]
    public static extern bool ChooseFont(ref CHOOSEFONT lpcf);

    [DllImport("user32.dll")]
    public static extern bool CloseWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern bool CloseDesktop(IntPtr hDesktop);

    [DllImport("user32.dll")]
    public static extern int GetSystemMetrics(int nIndex);

    [DllImport("user32.dll")]
    public static extern bool AppendMenu(IntPtr hMenu, uint uFlags, uint uIDNewItem, string lpNewItem);

    [DllImport("user32.dll")]
    public static extern bool AnyPopup();

    [DllImport("user32.dll")]
    public static extern IntPtr CreateMenu();

    [DllImport("user32.dll")]
    public static extern IntPtr CreatePopupMenu();

    [DllImport("user32.dll")]
    public static extern bool DestroyMenu(IntPtr hMenu);

    [DllImport("user32.dll")]
    public static extern IntPtr GetMenu(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern bool GetMenuInfo(IntPtr hmenu, ref MENUINFO lpcmi);

    [DllImport("user32.dll")]
    public static extern bool SetMenuInfo(IntPtr hmenu, ref MENUINFO lpcmi);

    [DllImport("gdi32")]
    public static extern IntPtr CreatePatternBrush(IntPtr hbmp);

    [DllImport("user32.dll")]
    public static extern int GetMenuItemCount(IntPtr hMenu);

    [DllImport("user32.dll")]
    public static extern bool ModifyMenu(IntPtr hMnu, uint uPosition, uint uFlags, uint uIDNewItem, string lpNewItem);

    [DllImport("user32.dll")]
    public static extern bool IsCharAlpha(char ch);

    [DllImport("user32.dll")]
    public static extern bool IsCharAlphaNumeric(string ch);

    [DllImport("user32.dll")]
    public static extern bool IsCharLower(char ch);

    [DllImport("user32.dll")]
    public static extern bool IsCharUpper(char ch);

    [DllImport("user32.dll")]
    public static extern bool IsWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern bool IsWindowEnabled(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern bool IsWindowVisible(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern bool IsIconic(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern bool IsZoomed(IntPtr hWnd);

    [DllImport("shlwapi.dll")]
    public static extern bool PathIsContentType(string pszPath, string pszContentType);

    [DllImport("shlwapi.dll")]
    public static extern bool PathIsDirectory(string pszPath);

    [DllImport("shlwapi.dll")]
    public static extern bool PathIsDirectoryEmpty(string pszPath);

    [DllImport("shlwapi.dll")]
    public static extern bool PathIsFileSpec(string lpszPath);

    [DllImport("shlwapi.dll")]
    public static extern string PathGetArgs(string pszPath);

    [DllImport("shlwapi.dll")]
    public static extern bool PathIsPrefix(string pszPrefix, string pszPath);

    [DllImport("shlwapi.dll")]
    public static extern bool PathIsRelative(string lpszPath);

    [DllImport("shlwapi.dll")]
    public static extern bool PathIsRoot(string pPath);

    [DllImport("shlwapi.dll")]
    public static extern bool PathIsSameRoot(string pszPath1, string pszPath2);

    [DllImport("shlwapi.dll")]
    public static extern bool PathIsURL(string pszPath);

    [DllImport("shlwapi.dll")]
    public static extern bool PathMatchSpec(string pszFile, string pszSpec);

    [DllImport("shlwapi.dll", CharSet = CharSet.Auto)]
    public static extern string PathRemoveBackslash(StringBuilder lpszPath);

    [DllImport("shlwapi.dll")]
    public static extern void PathRemoveArgs(StringBuilder pszPath);

    [DllImport("shlwapi.dll")]
    public static extern void PathRemoveBlanks(StringBuilder lpszString);

    [DllImport("shlwapi.dll")]
    public static extern void PathRemoveExtension(StringBuilder pszPath);

    [DllImport("shlwapi.dll")]
    public static extern bool PathRenameExtension(StringBuilder pszPath, string pszExt);

    [DllImport("gdi32.dll")]
    public static extern int SetTextCharacterExtra(IntPtr hdc, int nCharExtra);

    [DllImport("gdi32.dll")]
    public static extern int GetTextCharacterExtra(IntPtr hdc);

    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr CreateFontIndirect(ref LOGFONT lplf);

    [DllImport("user32.dll")]
    public static extern int RegisterClass(ref WNDCLASS Class);

    [DllImport("user32.dll")]
    public static extern int DefWindowProc(IntPtr hWnd, uint Msg, int wParam, int lParam);

    [DllImport("user32.dll")]
    public static extern uint RegisterWindowMessage(string lpString);

    [DllImport("kernel32.dll")]
    public static extern bool GetThreadTimes(IntPtr hThread, ref _FILETIME lpCreationTime, ref _FILETIME lpExitTime, ref _FILETIME lpKernelTime, ref _FILETIME lpUserTime);

    [DllImport("kernel32.dll")]
    public static extern IntPtr GetCurrentThread();

    [DllImport("kernel32.dll")]
    public static extern int GetCurrentThreadId();

    [DllImport("kernel32.dll")]
    public static extern int GetThreadPriority(IntPtr hThread);

    [DllImport("kernel32.dll")]
    public static extern bool SetThreadPriority(IntPtr hThread, int nPriority);

    [DllImport("kernel32.dll")]
    public static extern IntPtr OpenThread(int dwDesiredAccess, bool bInheritHandle, int dwThreadId);

    [DllImport("user32.dll")]
    public static extern IntPtr LoadIcon(IntPtr hInstance, string lpIconName);

    [DllImport("user32.dll")]
    public static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

    [DllImport("uxtheme.dll")]
    public static extern IntPtr SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

    [DllImport("user32.dll")]
    public static extern bool GetMenuItemInfo(IntPtr hMenu, uint uItem, bool fByPosition, ref MENUITEMINFO lpmii);

    [DllImport("user32.dll")]
    public static extern IntPtr GetSubMenu(IntPtr hMenu, int nPos);

    [DllImport("user32.dll")]
    public static extern bool SetMenuItemInfo(IntPtr hMenu, uint uItem, bool fByPosition, ref MENUITEMINFO lpmii);

    [DllImport("user32.dll")]
    public static extern bool UpdateWindow(IntPtr hWnd);

    [DllImport("uxtheme")]
    public static extern IntPtr GetWindowTheme(IntPtr hWnd);

    [DllImport("kernel32.dll")]
    public static extern int GetFileAttributes(string lpFileName);

    [DllImport("kernel32.dll")]
    public static extern bool SetLocalTime(ref SYSTEMTIME lpSystemTime);

    [DllImport("advapi32.dll")]
    public static extern long RegCloseKey(IntPtr hKey);

    [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
    public static extern int RegCreateKeyEx(IntPtr hKey, string lpSubKey, int Reserved, string lpClass, int dwOptions, int samDesigner, SECURITY_ATTRIBUTES lpSecurityAttributes, out IntPtr hkResult, out int lpdwDisposition);

    [DllImport("user32.dll")]
    public static extern bool ScreenToClient(IntPtr hWnd, ref Point lpPoint);

    [DllImport("gdi32.dll")]
    public static extern int GetPixel(IntPtr hdc, int nXPos, int nYPos);

    [DllImport("user32")]
    public static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

    [DllImport("kernel32.dll")]
    public static extern uint GetPrivateProfileInt(string lpAppName, string lpKeyName, int nDefault, string lpFileName);

    [DllImport("kernel32.dll")]
    public static extern bool GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

    [DllImport("kernel32.dll")]
    public static extern bool GetPrivateProfileSection(string lpAppName, StringBuilder lpReturnedString, int nSize, string lpFileName);

    [DllImport("kernel32.dll")]
    public static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

    [DllImport("kernel32.dll")]
    public static extern bool WritePrivateProfileSection(string lpAppName, string lpString, string lpFileName);

    [DllImport("kernel32.dll")]
    public static extern bool WritePrivateProfileStruct(string lpszSection, string lpszKey, StringBuilder lpStruct, uint uSizeStruct, string szFile);

    [DllImport("user32.dll")]
    public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, string pvParam, uint fuWinIni);

    [DllImport("gdi32.dll")]
    public static extern bool GetTextExtentPoint32(IntPtr hdc, string lpString, int c, ref Size lpSize);

    [DllImport("gdi32.dll")]
    public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

    [DllImport("gdi32.dll")]
    public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

    [DllImport("gdi32.dll")]
    public static extern bool DeleteDC(IntPtr hdc);

    [DllImport("user32.dll")]
    public static extern bool GetWindowInfo(IntPtr hwnd, ref WINDOWINFO pwi);

    [DllImport("gdi32.dll")]
    public static extern bool GetWindowOrgEx(IntPtr hdc, ref Point lpPoint);

    [DllImport("winmm.dll")]
    public static extern int waveOutSetVolume(IntPtr hwo, long dwVolume);

    [DllImport("winmm.dll")]
    public static extern int waveOutGetVolume(IntPtr hwo, out long dwVolume);

    [DllImport("user32.dll")]
    public static extern IntPtr CreateWindowEx(int dwExStyle, string lpClassName, string lpWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

    [DllImport("user32.dll")]
    public static extern IntPtr GetNextWindow(IntPtr hWnd, uint wCmd);

    [DllImport("user32.dll")]
    public static extern IntPtr ChildWindowFromPointEx(IntPtr hwndParent, Point pt, uint uFlags);

    [DllImport("user32.dll")]
    public static extern bool OpenIcon(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern int CascadeWindows(IntPtr hwndParent, uint wHow, ref RECT lpRect, uint cKids, IntPtr lpKids);

    [DllImport("user32.dll")]
    public static extern int TileWindows(IntPtr hwndParent, uint wHow, ref RECT lpRect, uint cKids, IntPtr lpKids);

    [DllImport("user32.dll")]
    public static extern uint ArrangeIconicWindows(IntPtr hWnd);

    [DllImport("gdi32.dll")]
    public static extern bool CancelDC(IntPtr hdc);

    [DllImport("user32.dll")]
    public static extern bool CopyRect(string lprcDst, ref RECT lprcSrc);

    [DllImport("user32.dll")]
    public static extern int CountClipboardFormats();

    [DllImport("kernel32.dll")]
    public static extern IntPtr CreateThread(SECURITY_ATTRIBUTES lpsa, int cbStack, IntPtr lpStartAddr, int lpvThreadParam, int fdwCreate, int lpIDThread);

    [DllImport("kernel32.dll")]
    public static extern int ThreadProc(int lpParameter);

    [DllImport("user32.dll")]
    public static extern IntPtr BeginDeferWindowPos(int nNumWindows);

    [DllImport("user32.dll")]
    public static extern IntPtr DeferWindowPos(IntPtr hWinPosInfo, IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

    [DllImport("user32.dll")]
    public static extern bool EndDeferWindowPos(IntPtr hWinPosInfo);

    [DllImport("kernel32.dll")]
    public static extern bool Beep(int dwFreq, int dwDuration);

    [DllImport("kernel32.dll")]
    public static extern int GetFileSize(IntPtr hFile, ref int lpFileSizeHigh);

    [DllImport("kernel32.dll")]
    public static extern int GetFileType(IntPtr hFile);

    [DllImport("kernel32.dll")]
    public static extern bool GetFileInformationByHandle(IntPtr hFile, ref BY_HANDLE_FILE_INFORMATION lpFileInformation);

    [DllImport("user32.dll")]
    public static extern bool SetWindowText(IntPtr hWnd, string lpString);

    [DllImport("user32.dll")]
    public static extern bool IsWindowUnicode(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern IntPtr SetActiveWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern IntPtr GetDCEx(IntPtr hWnd, RECT hrgnClip, int flags);

    [DllImport("user32.dll")]
    public static extern int SaveDC(IntPtr hdc);

    [DllImport("user32.dll")]
    public static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

    [DllImport("user32.dll")]
    public static extern int MapWindowPoints(IntPtr hWndFrom, IntPtr hWndTo, ref Point lpPoints, uint cPoints);

    [DllImport("user32.dll")]
    public static extern IntPtr WindowFromDC(IntPtr hDC);

    [DllImport("kernel32.dll")]
    public static extern int GetCompressedFileSize(string lpFileName, ref int lpFileSizeHigh);

    [DllImport("kernel32.dll")]
    public static extern bool LockFile(IntPtr hFile, int dwFileOffsetLow, int dwFileOffsetHigh, int nNumberOfBytesToLockLow, int nNumberOfBytesToLockHigh);

    [DllImport("kernel32.dll")]
    public static extern long CompareFileTime(_FILETIME lpFileTime1, _FILETIME lpFileTime2);

    [DllImport("kernel32.dll")]
    public static extern bool GetVolumeInformation(string lpRootPathName, string lpVolumeNameBuffer, int nVolumeNameSize, int lpVolumeSerialNumber, int lpMaximumComponentLength, int lpFileSystemFlags, string lpFileSystemNameBuffer, int nFileSystemNameSize);

    [DllImport("user32.dll")]
    public static extern bool IsRectEmpty(ref RECT lprc);

    [DllImport("advapi32.dll")]
    public static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

    [DllImport("kernel32.dll")]
    public static extern bool VerifyVersionInfo(ref OSVERSIONINFOEX lpVersionInfo, int dwTypeMask, int dwlConditionMask);

    [DllImport("psapi.dll")]
    public static extern bool GetModuleInformation(IntPtr hProcess, IntPtr hModule, ref MODULEINFO lpmodinfo, int cb);

    [DllImport("psapi.dll")]
    public static extern bool EnumProcesses(int[] pProcessIds, int cb, ref int pBytesReturned);

    [DllImport("user32.dll")]
    public static extern bool EnumThreadWindows(int dwThreadId, WindowsAPI.ThreadWindowsProc lpfn, int lParam);

    [DllImport("wininet.dll")]
    public static extern bool InternetGetConnectedState(ref int lpdwFlags, int dwReserved);

    [DllImport("Sensapi.dll")]
    public static extern bool IsNetworkAlive(ref int lpdwFlags);

    [DllImport("user32.dll")]
    public static extern int GetWindowRgn(IntPtr hWnd, IntPtr hRgn);

    [DllImport("kernel32.dll")]
    public static extern int GetTimeZoneInformation(ref TIME_ZONE_INFORMATION lpTimeZoneInformation);

    [DllImport("kernel32.dll")]
    public static extern int GetTimeFormat(int Locale, int dwFlags, ref SYSTEMTIME lpTime, string lpFormat, StringBuilder lpTimeStr, int cchTime);

    [DllImport("user32.dll")]
    public static extern bool GetIconInfo(IntPtr hIcon, ref ICONINFO piconinfo);

    [DllImport("kernel32.dll")]
    public static extern int GetDateFormat(int Locale, int dwFlags, ref SYSTEMTIME lpDate, string lpFormat, StringBuilder lpDateStr, int cchDate);

    [DllImport("kernel32.dll")]
    public static extern uint GetDriveType(string lpRootPathName);

    [DllImport("gdi32.dll")]
    public static extern bool BeginPath(IntPtr hdc);

    [DllImport("gdi32.dll")]
    public static extern int SetBkMode(IntPtr hdc, int iBkMode);

    [DllImport("gdi32.dll")]
    public static extern bool EndPath(IntPtr hdc);

    [DllImport("gdi32.dll")]
    public static extern IntPtr PathToRegion(IntPtr hdc);

    [DllImport("gdi32.dll")]
    public static extern bool Ellipse(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

    [DllImport("kernel32.DLL", EntryPoint = "RtlZeroMemory")]
    public static extern bool ZeroMemory(IntPtr Destination, int Length);

    [DllImport("gdi32.dll")]
    public static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest, IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, int dwRop);

    [DllImport("gdi32.dll")]
    public static extern int GetStretchBltMode(IntPtr hdc);

    [DllImport("kernel32.dll")]
    public static extern bool GetBinaryType(string lpApplicationName, ref int lpBinaryType);

    [DllImport("gdi32.dll")]
    public static extern bool RestoreDC(IntPtr hdc, int nSavedDC);

    [DllImport("gdi32.dll")]
    public static extern bool GetDCOrgEx(IntPtr hdc, ref Point lpPoint);

    [DllImport("gdi32.dll")]
    public static extern bool PatBlt(IntPtr hdc, int nXLeft, int nYLeft, int nWidth, int nHeight, int dwRop);

    [DllImport("gdi32.dll")]
    public static extern bool PlgBlt(IntPtr hdcDest, ref Point lpPoint, IntPtr hdcSrc, int nXSrc, int nYSrc, int nWidth, int nHeight, IntPtr hbmMask, int xMask, int yMask);

    [DllImport("gdi32.dll")]
    public static extern bool MaskBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, IntPtr hbmMask, int xMask, int yMask, int dwRop);

    [DllImport("gdi32.dll")]
    public static extern bool TransparentBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int hHeightDest, IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, uint crTransparent);

    [DllImport("gdi32.dll")]
    public static extern int SetPixel(IntPtr hdc, int X, int Y, int crColor);

    [DllImport("gdi32.dll")]
    public static extern bool SetPixelV(IntPtr hdc, int X, int Y, int crColor);

    [DllImport("gdi32.dll")]
    public static extern bool LineTo(IntPtr hdc, int nXEnd, int nYEnd);

    [DllImport("gdi32.dll")]
    public static extern bool LineDDA(int nXStart, int nYStart, int nXEnd, int nYEnd, IntPtr lpLineFunc, IntPtr lpData);

    [DllImport("gdi32.dll")]
    public static extern bool Polyline(IntPtr hdc, ref Point lppt, int cPoints);

    [DllImport("gdi32.dll")]
    public static extern bool PolylineTo(IntPtr hdc, ref Point lppt, int cCount);

    [DllImport("gdi32.dll")]
    public static extern bool PolyBezier(IntPtr hdc, ref Point lppt, int cPoints);

    [DllImport("gdi32.dll")]
    public static extern bool PolyDraw(IntPtr hdc, ref Point lppt, ref byte lpbTypes, int cCount);

    [DllImport("user32.dll")]
    public static extern int RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, uint flags);

    [DllImport("user32.dll")]
    public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

    [DllImport("user32.dll")]
    public static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFO lpmi);

    [DllImport("user32.dll")]
    public static extern bool PrintWindow(IntPtr hwnd, IntPtr hdcBlt, uint nFlags);

    [DllImport("user32.dll")]
    public static extern bool OffsetRect(ref RECT lprc, int dx, int dy);

    [DllImport("shell32.dll")]
    public static extern int SHFormatDrive(IntPtr hwnd, uint drive, uint fmtID, uint options);

    [DllImport("gdi32.dll")]
    public static extern bool ScaleViewportExtEx(IntPtr hdc, int Xnum, int Xdenom, int Ynum, int Ydenom, ref Size lpSize);

    [DllImport("gdi32.dll")]
    public static extern bool ScaleWindowExtEx(IntPtr hdc, int Xnum, int Xdenom, int Ynum, int Ydenom, ref Size lpSize);

    [DllImport("gdi32.dll")]
    public static extern bool GetCharWidth(IntPtr hdc, uint iFirstChar, uint iLastChar, ref int lpBuffer);

    [DllImport("User32.dll", CharSet = CharSet.Auto)]
    public static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

    [DllImport("user32.dll")]
    public static extern IntPtr LoadImage(IntPtr hinst, string lpszName, uint uType, int cxDesired, int cyDesired, uint fuLoad);

    [DllImport("user32.dll")]
    public static extern IntPtr LoadBitmap(IntPtr hInstance, string lpBitmapName);

    [DllImport("kernel32.dll")]
    public static extern void ExitProcess(uint uExitCode);

    [DllImport("shell32.dll")]
    public static extern int SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, int dwFlags);

    [DllImport("user32.dll")]
    public static extern bool InvalidateRect(IntPtr hWnd, ref RECT lpRect, bool bErase);

    [DllImport("wininet.dll")]
    public static extern bool InternetGetConnectedStateEx(ref int lpdwFlags, string lpszConnectionName, int dwNameLen, int dwReserved);

    [DllImport("user32.dll")]
    public static extern int DrawText(IntPtr hDC, string lpString, int nCount, ref RECT lpRect, uint uFormat);

    [DllImport("user32")]
    public static extern bool PaintDesktop(IntPtr hdc);

    [DllImport("user32.dll")]
    public static extern bool IsChild(IntPtr hWndParent, IntPtr hWnd);

    [DllImport("gdi32.dll")]
    public static extern int GetNearestColor(IntPtr hdc, int crColor);

    [DllImport("gdi32.dll")]
    public static extern IntPtr CreateBitmap(int nWidth, int nHeight, uint cPlanes, uint cBitsPerPel, IntPtr lpvBits);

    [DllImport("gdi32.dll")]
    public static extern bool TextOut(IntPtr hdc, int nXStart, int nYStart, string lpString, int cbString);

    [DllImport("gdi32.dll")]
    public static extern bool ExtTextOut(IntPtr hdc, int X, int Y, uint fuOptions, ref RECT lprc, string lpString, uint cbCount, int[] lpDx);

    [DllImport("gdi32.dll")]
    public static extern int DrawTextEx(IntPtr hdc, string lpchText, int cchText, RECT lprc, uint dwDTFormat, DRAWTEXTPARAMS lpDTParams);

    [DllImport("user32.dll")]
    public static extern int SendMessageTimeout(IntPtr hWnd, uint uMsg, int wParam, int lParam, uint fuFlags, uint uTimeout, ref int lpdwResult);

    [DllImport("user32.dll")]
    public static extern int GetClassLong(IntPtr hWnd, int index);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

    public delegate bool WNDENUMPROC(IntPtr hWnd, int lParam);

    public delegate bool ChildWindowsProc(IntPtr hwnd, int lParam);

    public delegate bool ThreadWindowsProc(IntPtr hwnd, int lParam);
  }
}
