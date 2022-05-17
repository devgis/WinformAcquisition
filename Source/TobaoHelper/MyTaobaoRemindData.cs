
// Type: TobaoHelper.MyTaobaoRemindData
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TobaoHelper
{
  public class MyTaobaoRemindData
  {
    public string ResolveHtmlToData(TBJS_UserInfo user, string HtmlText, ListBoughtItems listBoughtItems)
    {
      string pattern1 = "(jsonp[\\d]+)\\(\\[([\\s\\S]+)\\]\\);";
      string pattern2 = "\\w+";
      Match match1 = Regex.Match(HtmlText, pattern1, RegexOptions.IgnoreCase);
      string[] strArray = match1.Groups[2].Value.Split(',');
      int waitRate = Convert.ToInt32(Regex.Match(strArray[2], pattern2, RegexOptions.IgnoreCase).Value);
      int waitConfirm = Convert.ToInt32(Regex.Match(strArray[3], pattern2, RegexOptions.IgnoreCase).Value);
      int waitSend = Convert.ToInt32(Regex.Match(strArray[7], pattern2, RegexOptions.IgnoreCase).Value);
      string pattern3 = "(var[\\s*]" + Regex.Match(strArray[1], pattern2, RegexOptions.IgnoreCase).Value.Trim() + "[\\s*]=[\\s*])(\\[\")([\\d+])(\"\\])";
      Match match2 = Regex.Match(HtmlText, pattern3, RegexOptions.IgnoreCase);
      int waitPay = Convert.ToInt32(match2.Groups[3].Value);
      this.UpdateTabs(user, listBoughtItems, ref waitPay, ref waitSend, ref waitConfirm, ref waitRate);
      strArray[2] = "\"" + waitRate.ToString() + "\"";
      strArray[3] = "\"" + waitConfirm.ToString() + "\"";
      strArray[7] = "\"" + waitSend.ToString() + "\"";
      string replacement1 = "{" + match1.Groups[1].Value + "([" + string.Join(",", strArray) + "]);}";
      HtmlText = Regex.Replace(HtmlText, pattern1, replacement1);
      string replacement2 = match2.Groups[1].Value + match2.Groups[2].Value + waitPay.ToString() + match2.Groups[4].Value;
      HtmlText = Regex.Replace(HtmlText, pattern3, replacement2);
      return HtmlText;
    }

    public void UpdateTabs(TBJS_UserInfo user, ListBoughtItems listBoughtItems, ref int waitPay, ref int waitSend, ref int waitConfirm, ref int waitRate)
    {
      List<TBJS_vmMainOrder> changeListByUserId = listBoughtItems.GetChangeListByUserId(user.userid);
      if (changeListByUserId == null)
        return;
      foreach (TBJS_vmMainOrder tbjsVmMainOrder in changeListByUserId)
      {
        int subOrderCount = tbjsVmMainOrder.subOrderCount;
        TBJS_MainOrder orderById = listBoughtItems.GetOrderById(user.userid, tbjsVmMainOrder.id);
        if (tbjsVmMainOrder.IsHide || tbjsVmMainOrder.tradeStatusText.Equals("交易成功", StringComparison.OrdinalIgnoreCase) && !tbjsVmMainOrder.tradeStatus.Equals("TRADE_FINISHED"))
        {
          if (tbjsVmMainOrder.tradeStatus.Equals("WAIT_BUYER_PAY"))
          {
            if (waitPay >= subOrderCount)
              waitPay -= subOrderCount;
            else
              waitPay = 0;
          }
          else if (tbjsVmMainOrder.tradeStatus.Equals("WAIT_SELLER_SEND_GOODS"))
          {
            if (waitSend >= subOrderCount)
              waitSend -= subOrderCount;
            else
              waitSend = 0;
          }
          else if (tbjsVmMainOrder.tradeStatus.Equals("WAIT_BUYER_CONFIRM_GOODS"))
          {
            if (waitConfirm >= subOrderCount)
              waitConfirm -= subOrderCount;
            else
              waitConfirm = 0;
          }
          else if (tbjsVmMainOrder.tradeStatus.Equals("TRADE_FINISHED") && TBHelper.IsRateOrder(orderById))
          {
            if (waitRate >= subOrderCount)
              waitRate -= subOrderCount;
            else
              waitRate = 0;
          }
        }
        else if (tbjsVmMainOrder.tradeStatusText.Equals("交易成功") && tbjsVmMainOrder.IsRate)
        {
          if (waitRate >= subOrderCount)
            waitRate -= subOrderCount;
          else
            waitRate = 0;
        }
      }
    }
  }
}
