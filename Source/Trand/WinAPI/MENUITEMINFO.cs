
// Type: Trand.WinAPI.MENUITEMINFO
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;

namespace Trand.WinAPI
{
  public struct MENUITEMINFO
  {
    public uint cbSize;
    public uint fMask;
    public uint fType;
    public uint fState;
    public int wID;
    public int hSubMenu;
    public int hbmpChecked;
    public int hbmpUnchecked;
    public int dwItemData;
    public IntPtr dwTypeData;
    public uint cch;
  }
}
