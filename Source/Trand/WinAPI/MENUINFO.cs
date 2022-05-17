
// Type: Trand.WinAPI.MENUINFO
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;

namespace Trand.WinAPI
{
  public struct MENUINFO
  {
    public int cbSize;
    public int fMask;
    public int dwStyle;
    public int cyMax;
    public IntPtr hbrBack;
    public int dwContextHelpID;
    public int dwMenuData;
  }
}
