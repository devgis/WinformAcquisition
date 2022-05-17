
// Type: Trand.WinAPI.FINDREPLACE
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;

namespace Trand.WinAPI
{
  public struct FINDREPLACE
  {
    public int lStructSize;
    public IntPtr hwndOwner;
    public IntPtr hInstance;
    public int Flags;
    public string lpstrFindWhat;
    public string lpstrReplaceWith;
    public ushort wFindWhatLen;
    public ushort wReplaceWithLen;
    public uint lCustData;
    public FRHookProc lpfnHook;
    public string lpTemplateName;
  }
}
