
// Type: Trand.WinAPI.COMBOBOXINFO
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;

namespace Trand.WinAPI
{
  public struct COMBOBOXINFO
  {
    public int cbSize;
    public RECT rcItem;
    public RECT rcButton;
    public int stateButton;
    public IntPtr hwndCombo;
    public IntPtr hwndItem;
    public IntPtr hwndList;
  }
}
