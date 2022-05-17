
// Type: TobaoHelper.UserMyTaobao
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TobaoHelper
{
  public class UserMyTaobao
  {
    public string ResolveHtmlToData(TBJS_UserInfo user, string HtmlText, ListBoughtItems listBoughtItems, bool ClearLogistics = false)
    {
      string pattern1 = "(<span>待付款)(<em>)?([\\d]*)(</em>)?(</span>)";
      Match match1 = Regex.Match(HtmlText, pattern1, RegexOptions.IgnoreCase);
      int waitPay = 0;
      if (!match1.Groups[3].Value.Trim().Equals(""))
        waitPay = Convert.ToInt32(match1.Groups[3].Value);
      string pattern2 = "(<span>待发货)(<em>)?([\\d]*)(</em>)?(</span>)";
      Match match2 = Regex.Match(HtmlText, pattern2, RegexOptions.IgnoreCase);
      int waitSend = 0;
      if (!match2.Groups[3].Value.Trim().Equals(""))
        waitSend = Convert.ToInt32(match2.Groups[3].Value);
      string pattern3 = "(<span>待收货)(<em>)?([\\d]*)(</em>)?(</span>)";
      Match match3 = Regex.Match(HtmlText, pattern3, RegexOptions.IgnoreCase);
      int waitConfirm = 0;
      if (!match3.Groups[3].Value.Trim().Equals(""))
        waitConfirm = Convert.ToInt32(match3.Groups[3].Value);
      string pattern4 = "(<span>待评价)(<em>)?([\\d]*)(</em>)?(</span>)";
      Match match4 = Regex.Match(HtmlText, pattern4, RegexOptions.IgnoreCase);
      int waitRate = 0;
      if (!match4.Groups[3].Value.Trim().Equals(""))
        waitRate = Convert.ToInt32(match4.Groups[3].Value);
      this.UpdateTabs(user, listBoughtItems, ref waitPay, ref waitSend, ref waitConfirm, ref waitRate);
      string replacement1 = waitPay <= 0 ? "<span>待付款</span>" : "<span>待付款<em>" + waitPay.ToString() + "</em></span>";
      HtmlText = Regex.Replace(HtmlText, pattern1, replacement1);
      string replacement2 = waitSend <= 0 ? "<span>待发货</span>" : "<span>待发货<em>" + waitSend.ToString() + "</em></span>";
      HtmlText = Regex.Replace(HtmlText, pattern2, replacement2);
      string replacement3 = waitConfirm <= 0 ? "<span>待收货</span>" : "<span>待收货<em>" + waitConfirm.ToString() + "</em></span>";
      HtmlText = Regex.Replace(HtmlText, pattern3, replacement3);
      string replacement4 = waitRate <= 0 ? "<span>待评价</span>" : "<span>待评价<em>" + waitRate.ToString() + "</em></span>";
      HtmlText = Regex.Replace(HtmlText, pattern4, replacement4);
      if (ClearLogistics)
      {
        HtmlDocument htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(HtmlText);
        HtmlNode htmlNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='m-logistics g-box-base g-mb-set']");
        HtmlNodeCollection htmlNodeCollection = htmlDocument.DocumentNode.SelectNodes("//div[@class='m-logistics g-box-base g-mb-set']/div/ul/li");
        for (int index = Enumerable.Count<HtmlNode>((IEnumerable<HtmlNode>) htmlNodeCollection) - 1; index >= 0; --index)
        {
          Match match5 = Regex.Match(htmlNodeCollection[index].InnerHtml, "bizOrderId=([0-9]*)", RegexOptions.IgnoreCase);
          if (match5.Groups.Count == 2)
          {
            long orderId = Convert.ToInt64(match5.Groups[1].Value.Trim());
            TBJS_vmMainOrder changeOrderById = listBoughtItems.GetChangeOrderById(user.userid, orderId);
            if (changeOrderById != null && (changeOrderById.IsHide || changeOrderById.tradeStatusText.Equals("交易成功")))
              htmlNodeCollection.Remove(index);
          }
        }
        if (htmlNodeCollection.Count == 0)
          htmlNode.InnerHtml = "";
        HtmlText = htmlDocument.DocumentNode.InnerHtml;
      }
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
        else if (tbjsVmMainOrder.IsRate)
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
