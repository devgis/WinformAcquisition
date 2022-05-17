
// Type: TobaoHelper.ListRecyledtems
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TobaoHelper
{
  public class ListRecyledtems
  {
    public string ResolveHtmlToData(TBJS_UserInfo user, string HtmlText, ListBoughtItems listBoughtItems)
    {
      string pattern = "<script>(\\s*)var data = ([\\s\\S]+?)var tmsURLs";
      Match match = Regex.Match(HtmlText, pattern, RegexOptions.IgnoreCase);
      if (match.Groups.Count < 3 || match.Groups[2].Value.Trim() == "")
        return HtmlText;
      string replacement = "<script> var data =" + this.ResolveJsonToData(user, match.Groups[2].Value, listBoughtItems) + ";\r\n  var tmsURLs";
      return Regex.Replace(HtmlText, pattern, replacement);
    }

    public string ResolveJsonToData(TBJS_UserInfo user, string JsonText, ListBoughtItems listBoughtItems)
    {
      try
      {
        TBJS_Data jsonData = JsonConvert.DeserializeObject<TBJS_Data>(JsonText);
        listBoughtItems.GetChangeListByUserId(user.userid);
        List<TBJS_MainOrder> list = Enumerable.ToList<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) jsonData.mainOrders);
        list.Clear();
        jsonData.page.totalNumber = 0;
        jsonData.page.totalPage = 0;
        jsonData.page.pageSize = 0;
        jsonData.page.currentPage = 0;
        jsonData.mainOrders = list.ToArray();
        this.UpdateTabs(user, jsonData, listBoughtItems);
        return JsonConvert.SerializeObject((object) jsonData);
      }
      catch
      {
        return JsonText;
      }
    }

    public void UpdateTabs(TBJS_UserInfo user, TBJS_Data jsonData, ListBoughtItems listBoughtItems)
    {
      List<TBJS_Tab> tabs = Enumerable.ToList<TBJS_Tab>((IEnumerable<TBJS_Tab>) jsonData.tabs);
      TBJS_Tab tabByCode1 = TBHelper.GetTabByCode("waitPay", tabs);
      TBJS_Tab tabByCode2 = TBHelper.GetTabByCode("waitSend", tabs);
      TBJS_Tab tabByCode3 = TBHelper.GetTabByCode("waitConfirm", tabs);
      TBJS_Tab tabByCode4 = TBHelper.GetTabByCode("waitRate", tabs);
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
            int? count1 = tabByCode1.count;
            int num1 = subOrderCount;
            if ((count1.GetValueOrDefault() < num1 ? 0 : (count1.HasValue ? 1 : 0)) != 0)
            {
              TBJS_Tab tbjsTab = tabByCode1;
              int? count2 = tbjsTab.count;
              int num2 = subOrderCount;
              int? nullable = count2.HasValue ? new int?(count2.GetValueOrDefault() - num2) : new int?();
              tbjsTab.count = nullable;
            }
            else
              tabByCode1.count = new int?(0);
          }
          else if (tbjsVmMainOrder.tradeStatus.Equals("WAIT_SELLER_SEND_GOODS"))
          {
            int? count1 = tabByCode2.count;
            int num1 = subOrderCount;
            if ((count1.GetValueOrDefault() < num1 ? 0 : (count1.HasValue ? 1 : 0)) != 0)
            {
              TBJS_Tab tbjsTab = tabByCode2;
              int? count2 = tbjsTab.count;
              int num2 = subOrderCount;
              int? nullable = count2.HasValue ? new int?(count2.GetValueOrDefault() - num2) : new int?();
              tbjsTab.count = nullable;
            }
            else
              tabByCode2.count = new int?(0);
          }
          else if (tbjsVmMainOrder.tradeStatus.Equals("WAIT_BUYER_CONFIRM_GOODS"))
          {
            int? count1 = tabByCode3.count;
            int num1 = subOrderCount;
            if ((count1.GetValueOrDefault() < num1 ? 0 : (count1.HasValue ? 1 : 0)) != 0)
            {
              TBJS_Tab tbjsTab = tabByCode3;
              int? count2 = tbjsTab.count;
              int num2 = subOrderCount;
              int? nullable = count2.HasValue ? new int?(count2.GetValueOrDefault() - num2) : new int?();
              tbjsTab.count = nullable;
            }
            else
              tabByCode3.count = new int?(0);
          }
          else if (tbjsVmMainOrder.tradeStatus.Equals("TRADE_FINISHED") && TBHelper.IsRateOrder(orderById))
          {
            int? count1 = tabByCode4.count;
            int num1 = subOrderCount;
            if ((count1.GetValueOrDefault() < num1 ? 0 : (count1.HasValue ? 1 : 0)) != 0)
            {
              TBJS_Tab tbjsTab = tabByCode4;
              int? count2 = tbjsTab.count;
              int num2 = subOrderCount;
              int? nullable = count2.HasValue ? new int?(count2.GetValueOrDefault() - num2) : new int?();
              tbjsTab.count = nullable;
            }
            else
              tabByCode4.count = new int?(0);
          }
        }
        else if (tbjsVmMainOrder.tradeStatusText.Equals("交易成功") && tbjsVmMainOrder.IsRate)
        {
          int? count1 = tabByCode4.count;
          int num1 = subOrderCount;
          if ((count1.GetValueOrDefault() < num1 ? 0 : (count1.HasValue ? 1 : 0)) != 0)
          {
            TBJS_Tab tbjsTab = tabByCode4;
            int? count2 = tbjsTab.count;
            int num2 = subOrderCount;
            int? nullable = count2.HasValue ? new int?(count2.GetValueOrDefault() - num2) : new int?();
            tbjsTab.count = nullable;
          }
          else
            tabByCode4.count = new int?(0);
        }
      }
      int? count3 = tabByCode1.count;
      if ((count3.GetValueOrDefault() != 0 ? 0 : (count3.HasValue ? 1 : 0)) != 0)
        tabByCode1.count = new int?();
      int? count4 = tabByCode2.count;
      if ((count4.GetValueOrDefault() != 0 ? 0 : (count4.HasValue ? 1 : 0)) != 0)
        tabByCode2.count = new int?();
      int? count5 = tabByCode3.count;
      if ((count5.GetValueOrDefault() != 0 ? 0 : (count5.HasValue ? 1 : 0)) != 0)
        tabByCode3.count = new int?();
      int? count6 = tabByCode4.count;
      if ((count6.GetValueOrDefault() != 0 ? 0 : (count6.HasValue ? 1 : 0)) != 0)
        tabByCode4.count = new int?();
      jsonData.tabs = tabs.ToArray();
    }
  }
}
