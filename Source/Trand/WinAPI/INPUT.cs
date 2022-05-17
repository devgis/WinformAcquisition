
// Type: Trand.WinAPI.INPUT
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System.Runtime.InteropServices;

namespace Trand.WinAPI
{
  [StructLayout(LayoutKind.Explicit)]
  public struct INPUT
  {
    [FieldOffset(0)]
    public int type;
    [FieldOffset(4)]
    public MOUSEINPUT mi;
    [FieldOffset(4)]
    public KEYBDINPUT ki;
    [FieldOffset(4)]
    public HARDWAREINPUT hi;
  }
}
