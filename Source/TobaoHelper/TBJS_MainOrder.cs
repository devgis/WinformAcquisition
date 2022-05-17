
// Type: TobaoHelper.TBJS_MainOrder
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

namespace TobaoHelper
{
  public class TBJS_MainOrder
  {
    public long id { get; set; }

    public long mainOrderId { get; set; }

    public TBJS_Operation[] operations { get; set; }

    public TBJS_Extra extra { get; set; }

    public TBJS_OrderInfo orderInfo { get; set; }

    public TBJS_PayInfo payInfo { get; set; }

    public TBJS_Seller seller { get; set; }

    public TBJS_StatusInfo statusInfo { get; set; }

    public TBJS_SubOrder[] subOrders { get; set; }
  }
}
