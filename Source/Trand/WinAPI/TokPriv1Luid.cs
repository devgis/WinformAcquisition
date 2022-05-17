
// Type: Trand.WinAPI.TokPriv1Luid
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System.Runtime.InteropServices;

namespace Trand.WinAPI
{
  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct TokPriv1Luid
  {
    public int Count;
    public long Luid;
    public int Attr;
  }
}
