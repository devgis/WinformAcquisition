
// Type: TobaoHelper.WindowWrapper
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.Windows.Forms;

namespace TobaoHelper
{
  public class WindowWrapper : IWin32Window
  {
    private IntPtr _hwnd;

    public IntPtr Handle
    {
      get
      {
        return this._hwnd;
      }
    }

    public WindowWrapper(IntPtr handle)
    {
      this._hwnd = handle;
    }
  }
}
