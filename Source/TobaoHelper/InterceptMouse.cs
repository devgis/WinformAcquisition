
// Type: TobaoHelper.InterceptMouse
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.Runtime.InteropServices;

namespace TobaoHelper
{
  public class InterceptMouse
  {
    private static InterceptMouse.LowLevelMouseProc _proc = new InterceptMouse.LowLevelMouseProc(InterceptMouse.MouseHookProc);
    private static IntPtr _hookID = IntPtr.Zero;

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int SetWindowsHookEx(int idHook, InterceptMouse.HookProc lpfn, IntPtr hInstance, int threadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern bool UnhookWindowsHookEx(int idHook);

    [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr GetModuleHandle(string lpModuleName);

    private static IntPtr SetHook(InterceptMouse.LowLevelMouseProc proc)
    {
      return (IntPtr) 0;
    }

    private static IntPtr MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
    {
      MouseHookStruct mouseHookStruct = (MouseHookStruct) Marshal.PtrToStructure(lParam, typeof (MouseHookStruct));
      return (IntPtr) 0;
    }

    public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

    private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
  }
}
