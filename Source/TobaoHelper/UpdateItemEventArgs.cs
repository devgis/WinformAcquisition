
// Type: TobaoHelper.UpdateItemEventArgs
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;

namespace TobaoHelper
{
  public class UpdateItemEventArgs : EventArgs
  {
    public readonly long userId;
    public readonly TBJS_vmMainOrder Data;

    public UpdateItemEventArgs(long userId, TBJS_vmMainOrder Data)
    {
      this.userId = userId;
      this.Data = Data;
    }
  }
}
