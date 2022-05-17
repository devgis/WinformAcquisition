
// Type: Trand.WinAPI.MouseEventFlag
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

namespace Trand.WinAPI
{
  public enum MouseEventFlag : uint
  {
    Move = 1U,
    LeftDown = 2U,
    LeftUp = 4U,
    RightDown = 8U,
    RightUp = 16U,
    MiddleDown = 32U,
    MiddleUp = 64U,
    XDown = 128U,
    XUp = 256U,
    Wheel = 2048U,
    VirtualDesk = 16384U,
    Absolute = 32768U,
  }
}
