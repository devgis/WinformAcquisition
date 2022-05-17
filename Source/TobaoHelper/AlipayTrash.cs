
// Type: TobaoHelper.AlipayTrash
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TobaoHelper
{
  public class AlipayTrash
  {
    private Dictionary<long, List<TBJS_TradeTrash>> tradeTrashs;
    private Dictionary<long, List<TBJS_vmTradeTrash>> changeTradeTrashs;

    public AlipayTrash()
    {
      this.tradeTrashs = new Dictionary<long, List<TBJS_TradeTrash>>();
      this.changeTradeTrashs = new Dictionary<long, List<TBJS_vmTradeTrash>>();
    }

    public List<TBJS_TradeTrash> GetTradeRecordsByUserId(long userId)
    {
      List<TBJS_TradeTrash> list = (List<TBJS_TradeTrash>) null;
      if (this.tradeTrashs.TryGetValue(userId, out list))
        return list;
      return (List<TBJS_TradeTrash>) null;
    }

    public TBJS_TradeTrash GetTradeRecordById(string id, List<TBJS_TradeTrash> orders)
    {
      return orders.Find((Predicate<TBJS_TradeTrash>) (o => o.id.Equals(id)));
    }

    public TBJS_TradeTrash GetTradeRecordById(long userId, string id)
    {
      List<TBJS_TradeTrash> orders = (List<TBJS_TradeTrash>) null;
      if (this.tradeTrashs.TryGetValue(userId, out orders))
        return this.GetTradeRecordById(id, orders);
      return (TBJS_TradeTrash) null;
    }

    public void AddChangeTradeRecord(long userId, TBJS_vmTradeTrash order)
    {
      List<TBJS_vmTradeTrash> list = (List<TBJS_vmTradeTrash>) null;
      if (this.changeTradeTrashs.TryGetValue(userId, out list))
        list.Add(order);
      else
        this.changeTradeTrashs.Add(userId, new List<TBJS_vmTradeTrash>()
        {
          order
        });
    }

    public TBJS_vmTradeTrash GetChangeTradeRecordById(string id, List<TBJS_vmTradeTrash> orders)
    {
      return orders.Find((Predicate<TBJS_vmTradeTrash>) (o => o.id.Equals(id)));
    }

    public TBJS_vmTradeTrash GetChangeTradeRecordById(long userId, string id)
    {
      List<TBJS_vmTradeTrash> orders = (List<TBJS_vmTradeTrash>) null;
      if (this.changeTradeTrashs.TryGetValue(userId, out orders))
        return this.GetChangeTradeRecordById(id, orders);
      return (TBJS_vmTradeTrash) null;
    }

    public List<TBJS_vmTradeTrash> GetJoinTradeRecordsByUserId(long userId)
    {
      List<TBJS_vmTradeTrash> orders = new List<TBJS_vmTradeTrash>();
      List<TBJS_TradeTrash> list1 = (List<TBJS_TradeTrash>) null;
      if (this.tradeTrashs.TryGetValue(userId, out list1))
      {
        foreach (TBJS_TradeTrash tbjsTradeTrash in Enumerable.ToList<TBJS_TradeTrash>((IEnumerable<TBJS_TradeTrash>) Enumerable.OrderByDescending<TBJS_TradeTrash, string>((IEnumerable<TBJS_TradeTrash>) list1, (Func<TBJS_TradeTrash, string>) (c => c.date))))
        {
          TBJS_vmTradeTrash tbjsVmTradeTrash = new TBJS_vmTradeTrash()
          {
            id = tbjsTradeTrash.id,
            date = tbjsTradeTrash.date,
            name = tbjsTradeTrash.name,
            other = tbjsTradeTrash.other,
            amount = tbjsTradeTrash.amount,
            status = tbjsTradeTrash.status,
            userId = userId
          };
          orders.Add(tbjsVmTradeTrash);
        }
      }
      List<TBJS_vmTradeTrash> list2 = (List<TBJS_vmTradeTrash>) null;
      if (this.changeTradeTrashs.TryGetValue(userId, out list2))
      {
        foreach (TBJS_vmTradeTrash tbjsVmTradeTrash in list2)
        {
          TBJS_vmTradeTrash changeTradeRecordById = this.GetChangeTradeRecordById(tbjsVmTradeTrash.id, orders);
          if (changeTradeRecordById != null)
          {
            changeTradeRecordById.IsHide = tbjsVmTradeTrash.IsHide;
            changeTradeRecordById.tradeStatusText = tbjsVmTradeTrash.tradeStatusText;
          }
        }
      }
      return orders;
    }

    public TBJS_vmTradeTrash GetFrontModifyTradeRecordById(long userId, string id)
    {
      TBJS_TradeTrash tradeRecordById = this.GetTradeRecordById(userId, id);
      TBJS_vmTradeTrash changeTradeRecordById = this.GetChangeTradeRecordById(userId, id);
      if (tradeRecordById == null)
        return (TBJS_vmTradeTrash) null;
      TBJS_vmTradeTrash tbjsVmTradeTrash = new TBJS_vmTradeTrash()
      {
        id = tradeRecordById.id,
        name = tradeRecordById.name,
        other = tradeRecordById.other,
        amount = tradeRecordById.amount,
        status = tradeRecordById.status,
        userId = userId
      };
      if (changeTradeRecordById != null)
      {
        tbjsVmTradeTrash.IsHide = changeTradeRecordById.IsHide;
        tbjsVmTradeTrash.tradeStatusText = changeTradeRecordById.tradeStatusText;
      }
      return tbjsVmTradeTrash;
    }

    public string ResolveHtmlToData(string HtmlText)
    {
      try
      {
        HtmlDocument htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(HtmlText);
        foreach (HtmlNode htmlNode in (IEnumerable<HtmlNode>) htmlDocument.DocumentNode.SelectNodes("//table[@id='tradeRecordsIndex']/tbody/tr"))
          htmlNode.Remove();
        htmlDocument.DocumentNode.SelectSingleNode("//table[@id='tradeRecordsIndex']/tfoot").Remove();
        string alipayTrashEmptyHtml = TBHelper.GetAlipayTrashEmptyHtml();
        if (!string.IsNullOrEmpty(alipayTrashEmptyHtml))
        {
          HtmlNode htmlNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@id='J-main-table']");
          HtmlNode refChild = htmlDocument.DocumentNode.SelectSingleNode("//table[@id='tradeRecordsIndex']");
          HtmlNode node = HtmlNode.CreateNode(alipayTrashEmptyHtml);
          htmlNode.InsertAfter(node, refChild);
        }
        return htmlDocument.DocumentNode.InnerHtml;
      }
      catch (Exception ex)
      {
        return HtmlText;
      }
    }

    public string ResolveHtmlToRecordItems(TBJS_UserInfo user, string HtmlText)
    {
      List<TBJS_TradeTrash> orders = this.GetTradeRecordsByUserId(user.userid);
      if (orders == null)
      {
        orders = new List<TBJS_TradeTrash>();
        this.tradeTrashs.Add(user.userid, orders);
      }
      try
      {
        HtmlDocument htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(HtmlText);
        foreach (HtmlNode htmlNode in (IEnumerable<HtmlNode>) htmlDocument.DocumentNode.SelectNodes("//table[@id='tradeRecordsIndex']/tbody/tr"))
        {
          HtmlNodeCollection htmlNodeCollection = htmlNode.SelectNodes("td");
          string attributeValue = htmlNode.GetAttributeValue("id", "");
          string str = htmlNodeCollection[4].InnerText.Trim();
          if (this.GetTradeRecordById(attributeValue, orders) == null)
          {
            TBJS_TradeTrash tbjsTradeTrash = new TBJS_TradeTrash()
            {
              id = attributeValue,
              date = htmlNodeCollection[1].InnerText.Trim(),
              name = htmlNodeCollection[2].InnerText.Trim(),
              other = htmlNodeCollection[3].InnerText.Trim(),
              amount = Convert.ToDouble(str),
              status = htmlNodeCollection[5].InnerText.Trim()
            };
            orders.Add(tbjsTradeTrash);
          }
        }
        return htmlDocument.DocumentNode.InnerHtml;
      }
      catch (Exception ex)
      {
        return HtmlText;
      }
    }
  }
}
