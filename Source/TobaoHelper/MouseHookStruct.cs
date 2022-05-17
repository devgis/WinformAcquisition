
// Type: TobaoHelper.MouseHookStruct
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System.Runtime.InteropServices;

namespace TobaoHelper
{
  [StructLayout(LayoutKind.Sequential)]
  public class MouseHookStruct
  {
    public POINT pt;
    public int hwnd;
    public int wHitTestCode;
    public int dwExtraInfo;
  }
}
