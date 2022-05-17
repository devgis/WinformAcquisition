
// Type: TobaoHelper.Taobao.BuyerTradeManage
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using DotNet4.Utilities;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using TobaoHelper;

namespace TobaoHelper.Taobao
{
  public class BuyerTradeManage
  {
    public int currentPageIndex = 1;
    public int TotalPage;
    public int TotalNumber;

    public event BuyerTradeManage.BindDataEventHandler BindData;

    public void GetDefaultData(TBJS_UserInfo user)
    {
      this.BindData((object) this, new DataBindEventArgs(TaobaoSQL.GetDataTableByPageIndex(user.userid, this.currentPageIndex), this.currentPageIndex, this.TotalPage, this.TotalNumber));
    }

    public string ResolveHtmlToBuyerTrade(TBJS_UserInfo user, string HtmlText, string tabCode)
    {
      string pattern = "<script>(\\s*)var data = ([\\s\\S]+?)</script>";
      Match match = Regex.Match(HtmlText, pattern, RegexOptions.IgnoreCase);
      if (match.Groups.Count < 3 || match.Groups[2].Value.Trim() == "")
        return HtmlText;
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("<script> var data =");
      stringBuilder.Append(this.ResolveJsonToBuyerTrade(user, match.Groups[2].Value, tabCode));
      stringBuilder.Append("</script>");
      string replacement = stringBuilder.ToString();
      return Regex.Replace(HtmlText, pattern, replacement);
    }

    public string ResolveJsonToBuyerTrade(TBJS_UserInfo user, string JsonText, string tabCode)
    {
      try
      {
        TBJS_Data jsonData = JsonConvert.DeserializeObject<TBJS_Data>(JsonText);
        List<TBJS_MainOrder> MainOrders = Enumerable.ToList<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) jsonData.mainOrders);
        if (tabCode.Equals(""))
        {
          this.currentPageIndex = jsonData.page.currentPage;
          this.TotalPage = jsonData.page.totalPage;
          this.TotalNumber = jsonData.page.totalNumber;
          this.BindData((object) this, new DataBindEventArgs(TaobaoSQL.MergeBuyerTrade(user.userid, MainOrders, jsonData.page.currentPage), this.currentPageIndex, this.TotalPage, this.TotalNumber));
        }
        else
          this.BindData((object) this, new DataBindEventArgs(TaobaoSQL.GetDataTableByPageIndex(user.userid, jsonData.page.currentPage), this.currentPageIndex, this.TotalPage, this.TotalNumber));
        this.UpdateBuyerTrade(user, jsonData, tabCode);
        return JsonConvert.SerializeObject((object) jsonData);
      }
      catch
      {
        return JsonText;
      }
    }

    private TBJS_MainOrder SetTradeFinished(TBJS_UserInfo user, TBJS_MainOrder order)
    {
      order.extra.batch = false;
      order.extra.batchAgentPay = false;
      order.extra.batchConfirm = false;
      order.extra.batchPay = false;
      order.extra.tradeStatus = "TRADE_FINISHED";
      order.extra.finish = true;
      List<TBJS_Operation> list1 = Enumerable.ToList<TBJS_Operation>((IEnumerable<TBJS_Operation>) order.operations);
      list1.Clear();
      list1.Add(new TBJS_Operation()
      {
        style = "t0",
        text = "追加评论",
        url = string.Format("//rate.taobao.com/appendRate.htm?bizOrderId={0}&subTradeId={1}&isArchive=false", (object) order.id, (object) order.id)
      });
      list1.Add(new TBJS_Operation()
      {
        action = "a1",
        dataUrl = string.Format("buyAgain.htm?orderid={0}&_tb_token_=EdkFNJ4Lpu9bQE3", (object) order.id),
        style = "t0",
        text = "再次购买"
      });
      list1.Add(new TBJS_Operation()
      {
        id = "viewShopActive",
        style = "thead",
        text = "查看店铺活动"
      });
      list1.Add(new TBJS_Operation()
      {
        id = "share",
        style = "thead",
        text = "分享"
      });
      list1.Add(new TBJS_Operation()
      {
        id = "resell",
        style = "thead",
        text = "转卖",
        url = string.Format("//sell.2.taobao.com/publish/outer_site_resell.htm?bizOrderId={0}&isArchive=false", (object) order.id)
      });
      list1.Add(new TBJS_Operation()
      {
        id = "flag",
        style = "thead",
        text = "编辑标记信息，仅自己可见",
        url = string.Format("//trade.taobao.com/trade/memo/update_buy_memo.htm?bizOrderId={0}&buyerId={1}&user_type=0&pageNum=1&auctionTitle=null&bizOrderTimeBegin=null&bizOrderTimeEnd=null&commentStatus=null&sellerNick=null&auctionStatus=null&isArchive=false&logisticsService=null&visibility=true", (object) order.id, (object) user.userid)
      });
      list1.Add(new TBJS_Operation()
      {
        id = "delOrder",
        style = "thead",
        text = "删除订单",
        url = (string) null,
        action = "a7",
        dataUrl = string.Format("/trade/itemlist/asyncBought.htm?action=itemlist/RecyleAction&event_submit_do_delete=1&_input_charset=utf8&order_ids={0}&isArchive=false", (object) order.id),
        data = new TBJS_Operation.Data()
        {
          body = "删除后，您可在订单回收站找回，或永久删除。",
          height = 0,
          title = "您确定要删除该订单吗？",
          width = 0
        }
      });
      order.operations = list1.ToArray();
      List<TBJS_Operation> operations1 = Enumerable.ToList<TBJS_Operation>((IEnumerable<TBJS_Operation>) order.statusInfo.operations);
      TBJS_Operation operationById = TBHelper.GetOperationById("viewLogistic", operations1);
      if (operationById != null)
      {
        operationById.style = "t0";
        operationById.action = (string) null;
        operationById.dataUrl = (string) null;
      }
      else
        operations1.Add(new TBJS_Operation()
        {
          id = "viewLogistic",
          style = "t0",
          text = "查看物流",
          url = string.Format("//wuliu.taobao.com/user/order_detail_new.htm?trade_id={0}&seller_id={1}", (object) order.id, (object) order.seller.id)
        });
      if (TBHelper.GetOperationByText("双方已评", operations1) == null)
        operations1.Add(new TBJS_Operation()
        {
          style = "t0",
          text = "双方已评",
          url = string.Format("//rate.taobao.com/RateDetailBuyer.htm?parent_trade_id={0}", (object) order.id)
        });
      order.statusInfo.operations = operations1.ToArray();
      order.statusInfo.text = "交易成功";
      List<TBJS_SubOrder> list2 = Enumerable.ToList<TBJS_SubOrder>((IEnumerable<TBJS_SubOrder>) order.subOrders);
      foreach (TBJS_SubOrder tbjsSubOrder in list2)
      {
        if (tbjsSubOrder.id > 0L && tbjsSubOrder.operations != null && Enumerable.Count<TBJS_Operation>((IEnumerable<TBJS_Operation>) tbjsSubOrder.operations) > 0)
        {
          List<TBJS_Operation> operations2 = Enumerable.ToList<TBJS_Operation>((IEnumerable<TBJS_Operation>) tbjsSubOrder.operations);
          TBJS_Operation operationByText = TBHelper.GetOperationByText("退款/退货", operations2);
          if (operationByText != null)
            operations2.Remove(operationByText);
          if (TBHelper.GetOperationByText("违规举报", operations2) == null)
            operations2.Add(new TBJS_Operation()
            {
              style = "t0",
              text = "违规举报",
              url = string.Format("//archer.taobao.com/myservice/report/accusePunishItemPost.htm?display_type=3&parent_reason_id=9375&auction_num_id={0}", (object) tbjsSubOrder.itemInfo.id)
            });
          tbjsSubOrder.operations = operations2.ToArray();
        }
      }
      order.subOrders = list2.ToArray();
      return order;
    }

    private TBJS_MainOrder SetTradeWaitRate(TBJS_UserInfo user, TBJS_MainOrder order)
    {
      List<TBJS_Operation> list = Enumerable.ToList<TBJS_Operation>((IEnumerable<TBJS_Operation>) order.operations);
      list.Clear();
      list.Add(new TBJS_Operation()
      {
        style = "t0",
        text = "追加评论",
        url = string.Format("//rate.taobao.com/appendRate.htm?bizOrderId={0}&subTradeId={1}&isArchive=false", (object) order.id, (object) order.id)
      });
      list.Add(new TBJS_Operation()
      {
        action = "a1",
        dataUrl = string.Format("buyAgain.htm?orderid={0}&_tb_token_=EdkFNJ4Lpu9bQE3", (object) order.id),
        style = "t0",
        text = "再次购买"
      });
      list.Add(new TBJS_Operation()
      {
        id = "viewShopActive",
        style = "thead",
        text = "查看店铺活动"
      });
      list.Add(new TBJS_Operation()
      {
        id = "share",
        style = "thead",
        text = "分享"
      });
      list.Add(new TBJS_Operation()
      {
        id = "resell",
        style = "thead",
        text = "转卖",
        url = string.Format("//sell.2.taobao.com/publish/outer_site_resell.htm?bizOrderId={0}&isArchive=false", (object) order.id)
      });
      list.Add(new TBJS_Operation()
      {
        id = "flag",
        style = "thead",
        text = "编辑标记信息，仅自己可见",
        url = string.Format("//trade.taobao.com/trade/memo/update_buy_memo.htm?bizOrderId={0}&buyerId={1}&user_type=0&pageNum=1&auctionTitle=null&bizOrderTimeBegin=null&bizOrderTimeEnd=null&commentStatus=null&sellerNick=null&auctionStatus=null&isArchive=false&logisticsService=null&visibility=true", (object) order.id, (object) user.userid)
      });
      list.Add(new TBJS_Operation()
      {
        action = "a7",
        data = new TBJS_Operation.Data()
        {
          body = "删除后，您可在订单回收站找回，或永久删除。",
          height = 0,
          title = "您确定要删除该订单吗？",
          width = 0
        },
        dataUrl = string.Format("/trade/itemlist/asyncBought.htm?action=itemlist/RecyleAction&event_submit_do_delete=1&_input_charset=utf8&order_ids={0}&isArchive=false", (object) order.id),
        id = "delete",
        style = "thead",
        text = "删除订单"
      });
      order.operations = list.ToArray();
      List<TBJS_Operation> operations = Enumerable.ToList<TBJS_Operation>((IEnumerable<TBJS_Operation>) order.statusInfo.operations);
      if (TBHelper.GetOperationByText("我已评价", operations) == null)
        operations.Add(new TBJS_Operation()
        {
          style = "t0",
          text = "我已评价",
          url = string.Format("//rate.taobao.com/RateDetailBuyer.htm?parent_trade_id={0}", (object) order.id)
        });
      order.statusInfo.operations = operations.ToArray();
      return order;
    }

    private void UpdateBuyerTrade(TBJS_UserInfo user, TBJS_Data jsonData, string tabCode = "")
    {
        List<TBJS_Tab> list = jsonData.tabs.ToList<TBJS_Tab>();
        List<TBJS_MainOrder> list2 = jsonData.mainOrders.ToList<TBJS_MainOrder>();
        IList<long> list3 = (from m in list2
                             select m.id).ToArray<long>();
        TBJS_Tab tabByCode = TBHelper.GetTabByCode("waitPay", list);
        TBJS_Tab tabByCode2 = TBHelper.GetTabByCode("waitSend", list);
        TBJS_Tab tabByCode3 = TBHelper.GetTabByCode("waitConfirm", list);
        TBJS_Tab tabByCode4 = TBHelper.GetTabByCode("waitRate", list);
        List<TBJS_BuyerTradeData> localData = null;
        if (tabCode.Equals(""))
        {
            localData = TaobaoSQL.GetDataTableToList(user.userid, list3, jsonData.page.currentPage);
        }
        else
        {
            localData = TaobaoSQL.GetDataTableToList(user.userid, this.currentPageIndex);
        }
        IEnumerable<TBJS_BuyerTradeData> source = from m in list2
                                                  join l in localData on m.id equals l.id into temp
                                                  from tt in temp.DefaultIfEmpty<TBJS_BuyerTradeData>()
                                                  where tt == null || (tt != null && !tt.isHide)
                                                  select new TBJS_BuyerTradeData
                                                  {
                                                      id = m.id,
                                                      isHide = tt != null && tt.isHide,
                                                      editCreateDay = (tt == null) ? m.orderInfo.createDay : tt.editCreateDay,
                                                      editTradeStatus = (tt == null) ? TBHelper.GetOrderTradeStatusText(m) : tt.editTradeStatus
                                                  };
        if (!tabCode.Equals(""))
        {
            source = from t in source
                     where t.editTradeStatus.Equals(TBHelper.GetTabCodeToTradeStatus(tabCode))
                     select t;
            if (localData.Count<TBJS_BuyerTradeData>() > 0)
            {
                source = from t in source
                         where (from l in localData
                                select l.id).Contains(t.id)
                         select t;
            }
        }
        List<TBJS_BuyerTradeData> list4 = source.ToList<TBJS_BuyerTradeData>();
        int num = localData.FindAll((TBJS_BuyerTradeData o) => o.editTradeStatus.Equals("待付款")).ToList<TBJS_BuyerTradeData>().Count<TBJS_BuyerTradeData>();
        int num2 = localData.FindAll((TBJS_BuyerTradeData o) => o.editTradeStatus.Equals("待发货")).ToList<TBJS_BuyerTradeData>().Count<TBJS_BuyerTradeData>();
        int num3 = localData.FindAll((TBJS_BuyerTradeData o) => o.editTradeStatus.Equals("待收货")).ToList<TBJS_BuyerTradeData>().Count<TBJS_BuyerTradeData>();
        int num4 = localData.FindAll((TBJS_BuyerTradeData o) => o.editTradeStatus.Equals("待评价")).ToList<TBJS_BuyerTradeData>().Count<TBJS_BuyerTradeData>();
        tabByCode.count = ((num > 0) ? new int?(num) : null);
        tabByCode2.count = ((num2 > 0) ? new int?(num2) : null);
        tabByCode3.count = ((num3 > 0) ? new int?(num3) : null);
        tabByCode4.count = ((num4 > 0) ? new int?(num4) : null);
        list2 = (from m in list2
                 join s in list4 on m.id equals s.id
                 select m).ToList<TBJS_MainOrder>();
        using (List<TBJS_MainOrder>.Enumerator enumerator = list2.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                TBJS_MainOrder m = enumerator.Current;
                TBJS_BuyerTradeData tBJS_BuyerTradeData = list4.Find((TBJS_BuyerTradeData o) => o.id == m.id);
                if (tBJS_BuyerTradeData != null)
                {
                    if (tBJS_BuyerTradeData.isHide)
                    {
                        list2.Remove(m);
                    }
                    else
                    {
                        m.orderInfo.createDay = tBJS_BuyerTradeData.editCreateDay;
                        m.orderInfo.createTime = string.Format("{0} {1}", tBJS_BuyerTradeData.editCreateDay, Convert.ToDateTime(m.orderInfo.createTime).ToString("HH:mm:ss"));
                        if (tabCode.Equals("") && tBJS_BuyerTradeData.editTradeStatus.Equals("交易成功") && !tBJS_BuyerTradeData.editTradeStatus.Equals(m.statusInfo.text))
                        {
                            this.SetTradeFinished(user, m);
                        }
                        else if (tBJS_BuyerTradeData.editTradeStatus.Equals("交易成功") && TBHelper.IsRateOrder(m))
                        {
                            this.SetTradeWaitRate(user, m);
                        }
                    }
                }
            }
        }
        jsonData.mainOrders = list2.ToArray();
        jsonData.extra.mainBizOrderIds = string.Join<long>("-", list3.ToArray<long>());
        jsonData.tabs = list.ToArray();
        if (jsonData.mainOrders.Count<TBJS_MainOrder>() == 0)
        {
            jsonData.page.totalNumber = 0;
            jsonData.page.totalPage = 0;
            jsonData.page.pageSize = 0;
            jsonData.page.currentPage = 0;
        }
    }

    public bool SynchronousBuyerTrade(string HttpCookieString, int page, int pageSize)
    {
      try
      {
        HttpHelper httpHelper = new HttpHelper();
        HttpItem httpItem = new HttpItem()
        {
          URL = "https://buyertrade.taobao.com/trade/itemlist/asyncBought.htm?action=itemlist/BoughtQueryAction&event_submit_do_query=1&_input_charset=utf8&is_user_do_async=1",
          Host = "buyertrade.taobao.com",
          Method = "post",
          ContentType = "application/x-www-form-urlencoded; charset=UTF-8",
          Cookie = HttpCookieString,
          Postdata = string.Format("options=0&pageNum={0}&pageSize={1}&queryOrder=desc", (object) page, (object) pageSize)
        };
        if (CaptureConfiguration.ProxyRunning)
          httpItem.ProxyIp = string.Format("127.0.0.1:{0}", (object) CaptureConfiguration.ProxyPort);
        HttpResult html = httpHelper.GetHtml(httpItem);
        if (html.StatusCode == HttpStatusCode.OK && !html.Html.Trim().Equals(""))
        {
          string pattern = "<script>(\\s*)var data = ([\\s\\S]+?)</script>";
          Match match = Regex.Match(html.Html, pattern, RegexOptions.IgnoreCase);
          if (match.Groups.Count < 3 || match.Groups[2].Value.Trim() == "")
            return false;
          TBJS_Data tbjsData = JsonConvert.DeserializeObject<TBJS_Data>(match.Groups[2].Value);
          List<TBJS_MainOrder> MainOrders = Enumerable.ToList<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) tbjsData.mainOrders);
          TaobaoSQL.SynchronousBuyerTrade(TBHelper.CurrentUserInfo.userid, MainOrders, tbjsData.page.currentPage);
        }
        return false;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public DataTable OneKeyAllWaitPay(long userid, IList<long> ids)
    {
      return TaobaoSQL.OneKeyAllHandle(userid, ids, "待付款");
    }

    public DataTable OneKeyAllWaitSend(long userid, IList<long> ids)
    {
      return TaobaoSQL.OneKeyAllHandle(userid, ids, "待发货");
    }

    public DataTable OneKeyAllWaitConfirm(long userid, IList<long> ids)
    {
      return TaobaoSQL.OneKeyAllHandle(userid, ids, "待收货");
    }

    public DataTable OneKeyAllWaitRate(long userid, IList<long> ids)
    {
      return TaobaoSQL.OneKeyAllHandle(userid, ids, "待评价");
    }

    public DataTable OneKeyAllHide(long userid, IList<long> ids)
    {
      return TaobaoSQL.OneKeyAllHide(userid, ids);
    }

    public DataTable OneKeyAllReset(long userid, IList<long> ids)
    {
      return TaobaoSQL.OneKeyAllReset(userid, ids);
    }

    public DataTable ResetSingleBuyerTrade(long userid, long id)
    {
      return TaobaoSQL.ResetSingleBuyerTrade(userid, id);
    }

    public DataTable ClearDataByUserId(long userid)
    {
      return TaobaoSQL.ClearDataByUserId(userid);
    }

    public int ActionDeleteOrder(TBJS_UserInfo user, long id)
    {
      return TaobaoSQL.DeleteBuyerTrade(user.userid, id);
    }

    public string ListRecyledtems_ResolveHtmlToJson(TBJS_UserInfo user, string HtmlText)
    {
      string pattern = "<script>(\\s*)var data = ([\\s\\S]+?)var tmsURLs";
      Match match = Regex.Match(HtmlText, pattern, RegexOptions.IgnoreCase);
      if (match.Groups.Count < 3 || match.Groups[2].Value.Trim() == "")
        return HtmlText;
      return match.Groups[2].Value;
    }

    public string ResolveHtmlToListRecyledtems(TBJS_UserInfo user, string HtmlText)
    {
      string pattern = "<script>(\\s*)var data = ([\\s\\S]+?)var tmsURLs";
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("<script> var data =");
      stringBuilder.Append(this.ResolveJsonToListRecyledtems(user, this.ListRecyledtems_ResolveHtmlToJson(user, HtmlText)));
      stringBuilder.Append(";\r\n  var tmsURLs");
      string replacement = stringBuilder.ToString();
      return Regex.Replace(HtmlText, pattern, replacement);
    }

    public string ResolveJsonToListRecyledtems(TBJS_UserInfo user, string JsonText)
    {
      try
      {
        TBJS_Data jsonData = JsonConvert.DeserializeObject<TBJS_Data>(JsonText);
        List<TBJS_MainOrder> list = Enumerable.ToList<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) jsonData.mainOrders);
        this.UpdateListRecyledtems(user, jsonData);
        if (CaptureConfiguration._advSettings.ClearTaoBaoListRecyledItems)
        {
          list.Clear();
          jsonData.page.totalNumber = 0;
          jsonData.page.totalPage = 0;
          jsonData.page.pageSize = 0;
          jsonData.page.currentPage = 0;
          jsonData.mainOrders = list.ToArray();
        }
        return JsonConvert.SerializeObject((object) jsonData);
      }
      catch
      {
        return JsonText;
      }
    }

    private void UpdateListRecyledtems(TBJS_UserInfo user, TBJS_Data jsonData)
    {
      List<TBJS_Tab> tabs = Enumerable.ToList<TBJS_Tab>((IEnumerable<TBJS_Tab>) jsonData.tabs);
      TBJS_Tab tabByCode1 = TBHelper.GetTabByCode("waitPay", tabs);
      TBJS_Tab tabByCode2 = TBHelper.GetTabByCode("waitSend", tabs);
      TBJS_Tab tabByCode3 = TBHelper.GetTabByCode("waitConfirm", tabs);
      TBJS_Tab tabByCode4 = TBHelper.GetTabByCode("waitRate", tabs);
      List<TBJS_BuyerTradeData> dataTableToList = TaobaoSQL.GetDataTableToList(user.userid, this.currentPageIndex);
      int num1 = Enumerable.Count<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) Enumerable.ToList<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) dataTableToList.FindAll((Predicate<TBJS_BuyerTradeData>) (o => o.editTradeStatus.Equals("待付款")))));
      int num2 = Enumerable.Count<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) Enumerable.ToList<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) dataTableToList.FindAll((Predicate<TBJS_BuyerTradeData>) (o => o.editTradeStatus.Equals("待发货")))));
      int num3 = Enumerable.Count<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) Enumerable.ToList<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) dataTableToList.FindAll((Predicate<TBJS_BuyerTradeData>) (o => o.editTradeStatus.Equals("待收货")))));
      int num4 = Enumerable.Count<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) Enumerable.ToList<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) dataTableToList.FindAll((Predicate<TBJS_BuyerTradeData>) (o => o.editTradeStatus.Equals("待评价")))));
      tabByCode1.count = num1 > 0 ? new int?(num1) : new int?();
      tabByCode2.count = num2 > 0 ? new int?(num2) : new int?();
      tabByCode3.count = num3 > 0 ? new int?(num3) : new int?();
      tabByCode4.count = num4 > 0 ? new int?(num4) : new int?();
    }

    public string ResolveHtmlToMyTaobao(TBJS_UserInfo user, string HtmlText, bool ClearLogistics = false)
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
      List<TBJS_BuyerTradeData> dataTableToList = TaobaoSQL.GetDataTableToList(user.userid, this.currentPageIndex);
      this.UpdateMyTaobaoTabs(user, ref waitPay, ref waitSend, ref waitConfirm, ref waitRate, dataTableToList);
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
        HtmlNodeCollection htmlNodeCollection = htmlDocument.DocumentNode.SelectNodes("//ul[@class=\"lg-list\"]/li");
        if (htmlNodeCollection == null)
          return HtmlText;
        IList<long> list = (IList<long>) new List<long>();
        for (int index = Enumerable.Count<HtmlNode>((IEnumerable<HtmlNode>) htmlNodeCollection) - 1; index >= 0; --index)
        {
          Match match5 = Regex.Match(htmlNodeCollection[index].InnerHtml, "bizOrderId=([0-9]*)", RegexOptions.IgnoreCase);
          if (match5.Groups.Count == 2)
          {
            long orderid = Convert.ToInt64(match5.Groups[1].Value.Trim());
            TBJS_BuyerTradeData tbjsBuyerTradeData = dataTableToList.Find((Predicate<TBJS_BuyerTradeData>) (o => o.id == orderid));
            if (tbjsBuyerTradeData == null || tbjsBuyerTradeData != null && (tbjsBuyerTradeData.isHide || tbjsBuyerTradeData.editTradeStatus.Equals("交易成功")))
            {
              list.Add(orderid);
              htmlNodeCollection.RemoveAt(index);
            }
          }
        }
        if (Enumerable.Count<HtmlNode>((IEnumerable<HtmlNode>) htmlNodeCollection) == 0)
          htmlNode.InnerHtml = "";
        HtmlText = htmlDocument.DocumentNode.InnerHtml;
      }
      return HtmlText;
    }

    public void UpdateMyTaobaoTabs(TBJS_UserInfo user, ref int waitPay, ref int waitSend, ref int waitConfirm, ref int waitRate, List<TBJS_BuyerTradeData> localData)
    {
      waitPay = Enumerable.Count<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) Enumerable.ToList<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) localData.FindAll((Predicate<TBJS_BuyerTradeData>) (o => o.editTradeStatus.Equals("待付款")))));
      waitSend = Enumerable.Count<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) Enumerable.ToList<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) localData.FindAll((Predicate<TBJS_BuyerTradeData>) (o => o.editTradeStatus.Equals("待发货")))));
      waitConfirm = Enumerable.Count<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) Enumerable.ToList<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) localData.FindAll((Predicate<TBJS_BuyerTradeData>) (o => o.editTradeStatus.Equals("待收货")))));
      waitRate = Enumerable.Count<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) Enumerable.ToList<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) localData.FindAll((Predicate<TBJS_BuyerTradeData>) (o => o.editTradeStatus.Equals("待评价")))));
    }

    public string ResolveHtmlToLogisticsInfoJson(TBJS_UserInfo user, string HtmlText, bool ClearLogistics = false)
    {
      if (!ClearLogistics)
        return HtmlText;
      TBLI_LogisticsInfo tbliLogisticsInfo = JsonConvert.DeserializeObject<TBLI_LogisticsInfo>(HtmlText);
      List<TBLI_ItemForMe> itemForMes = Enumerable.ToList<TBLI_ItemForMe>((IEnumerable<TBLI_ItemForMe>) tbliLogisticsInfo.data.itemForMe);
      List<TBJS_BuyerTradeData> dataTableToList = TaobaoSQL.GetDataTableToList(user.userid, this.currentPageIndex);
      for (int i = Enumerable.Count<TBLI_ItemForMe>((IEnumerable<TBLI_ItemForMe>) itemForMes) - 1; i >= 0; --i)
      {
        TBJS_BuyerTradeData tbjsBuyerTradeData = dataTableToList.Find((Predicate<TBJS_BuyerTradeData>) (o => o.id == itemForMes[i].tradeId));
        if (tbjsBuyerTradeData == null || tbjsBuyerTradeData != null && (tbjsBuyerTradeData.isHide || tbjsBuyerTradeData.editTradeStatus.Equals("交易成功")))
          itemForMes.RemoveAt(i);
      }
      tbliLogisticsInfo.data.itemForMe = itemForMes.ToArray();
      tbliLogisticsInfo.data.itemNum = Enumerable.Count<TBLI_ItemForMe>((IEnumerable<TBLI_ItemForMe>) itemForMes);
      return JsonConvert.SerializeObject((object) tbliLogisticsInfo);
    }

    public string ResolveHtmlToRemindData(TBJS_UserInfo user, string HtmlText)
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
      this.UpdateRemindDataTabs(user, ref waitPay, ref waitSend, ref waitConfirm, ref waitRate);
      strArray[2] = "\"" + waitRate.ToString() + "\"";
      strArray[3] = "\"" + waitConfirm.ToString() + "\"";
      strArray[7] = "\"" + waitSend.ToString() + "\"";
      string replacement1 = "{" + match1.Groups[1].Value + "([" + string.Join(",", strArray) + "]);}";
      HtmlText = Regex.Replace(HtmlText, pattern1, replacement1);
      string replacement2 = match2.Groups[1].Value + match2.Groups[2].Value + waitPay.ToString() + match2.Groups[4].Value;
      HtmlText = Regex.Replace(HtmlText, pattern3, replacement2);
      return HtmlText;
    }

    public void UpdateRemindDataTabs(TBJS_UserInfo user, ref int waitPay, ref int waitSend, ref int waitConfirm, ref int waitRate)
    {
      List<TBJS_BuyerTradeData> dataTableToList = TaobaoSQL.GetDataTableToList(user.userid, this.currentPageIndex);
      waitPay = Enumerable.Count<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) Enumerable.ToList<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) dataTableToList.FindAll((Predicate<TBJS_BuyerTradeData>) (o => o.editTradeStatus.Equals("待付款")))));
      waitSend = Enumerable.Count<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) Enumerable.ToList<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) dataTableToList.FindAll((Predicate<TBJS_BuyerTradeData>) (o => o.editTradeStatus.Equals("待发货")))));
      waitConfirm = Enumerable.Count<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) Enumerable.ToList<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) dataTableToList.FindAll((Predicate<TBJS_BuyerTradeData>) (o => o.editTradeStatus.Equals("待收货")))));
      waitRate = Enumerable.Count<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) Enumerable.ToList<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) dataTableToList.FindAll((Predicate<TBJS_BuyerTradeData>) (o => o.editTradeStatus.Equals("待评价")))));
    }

    public string ResolveJsonToGrowthRecord(TBJS_UserInfo user, string jsonText)
    {
      string pattern = "(jsonp[0-9]*)\\(([\\s\\S]+?)(\\))";
      try
      {
        Match match = Regex.Match(jsonText, pattern, RegexOptions.IgnoreCase);
        if (match.Groups.Count < 4 || match.Groups[2].Value.Trim() == "")
          return jsonText;
        TBJS_jsonp23 tbjsJsonp23 = JsonConvert.DeserializeObject<TBJS_jsonp23>(match.Groups[2].Value.Trim());
        List<TBJS_jsonp23.TBJS_jsonp23_growth> list = Enumerable.ToList<TBJS_jsonp23.TBJS_jsonp23_growth>((IEnumerable<TBJS_jsonp23.TBJS_jsonp23_growth>) tbjsJsonp23.data.growthList);
        list.Clear();
        tbjsJsonp23.data.growthList = list.ToArray();
        tbjsJsonp23.data.hasNext = false;
        return string.Format("{0}{1}{2})", (object) match.Groups[1], (object) JsonConvert.SerializeObject((object) tbjsJsonp23), (object) match.Groups[3]);
      }
      catch (Exception ex)
      {
        return jsonText;
      }
    }

    public APJS_TradeRecord GetTradeRecordById(string tradeNo, List<APJS_TradeRecord> tradeRecords)
    {
      return tradeRecords.Find((Predicate<APJS_TradeRecord>) (o => o.tradeNo.Equals(tradeNo)));
    }

    public TBJS_vmMainOrder GetTradeRecordByBizCreate(string gmtBizCreate, List<TBJS_vmMainOrder> changes)
    {
      return changes.Find((Predicate<TBJS_vmMainOrder>) (o => o.createTime.ToString("yyyyMMddHHmmss").Equals(gmtBizCreate)));
    }

    private DateTime gmtBizCreateToDateTime(string gmtBizCreate)
    {
      return Convert.ToDateTime(gmtBizCreate.Substring(0, 4) + "-" + gmtBizCreate.Substring(4, 2) + "-" + gmtBizCreate.Substring(6, 2) + " " + gmtBizCreate.Substring(8, 2) + ":" + gmtBizCreate.Substring(10, 2) + ":" + gmtBizCreate.Substring(12, 2));
    }

    public void UpdateTradeRecords(TBJS_UserInfo user, HtmlNode row, List<APJS_TradeRecord> tradeRecords, int rowIndex)
    {
      HtmlNodeCollection htmlNodeCollection = row.SelectNodes("td");
      if (Enumerable.Count<HtmlNode>((IEnumerable<HtmlNode>) htmlNodeCollection) < 4)
        return;
      HtmlNode htmlNode1 = htmlNodeCollection[4].SelectSingleNode("./a");
      if (htmlNode1 == null)
        return;
      string attributeValue = htmlNode1.GetAttributeValue("href", "");
      if (attributeValue.Equals(""))
        return;
      DateTime toDateTime = this.gmtBizCreateToDateTime(Regex.Match(attributeValue, "gmtBizCreate=([\\s\\S]*[0-9]*)", RegexOptions.IgnoreCase).Groups[1].Value.ToString().Trim());
      TBJS_BuyerTradeData tbjsBuyerTradeData = TaobaoSQL.GetDataToModelByCreateTime(user.userid, toDateTime) ?? TaobaoSQL.GetDataToModelByCreateTime(user.userid, toDateTime.AddSeconds(-1.0));
      if (tbjsBuyerTradeData == null)
        return;
      if (tbjsBuyerTradeData.isHide)
      {
        row.Remove();
      }
      else
      {
        htmlNodeCollection[0].SelectSingleNode("./p").InnerHtml = Convert.ToDateTime(tbjsBuyerTradeData.editCreateDay).ToString("yyyy.MM.dd");
        if (!tbjsBuyerTradeData.editTradeStatus.Equals("交易成功"))
          return;
        HtmlNode htmlNode2 = htmlNodeCollection[5].SelectNodes("./p")[0];
        if (htmlNode2.InnerText.Trim().Equals("等待付款"))
        {
          htmlNode2.InnerHtml = "交易成功";
          foreach (HtmlNode htmlNode3 in (IEnumerable<HtmlNode>) htmlNodeCollection[6].SelectNodes("./select[@id=\"J-operation-select-" + rowIndex.ToString() + "\"]/option"))
          {
            HtmlAttribute htmlAttribute = htmlNode3.Attributes["seed"];
            if (htmlAttribute != null && (htmlAttribute.Value.Equals("trade-apply") || htmlAttribute.Value.Equals("find-otherpay") || htmlAttribute.Value.Equals("close-trade")))
              htmlNode3.Remove();
          }
        }
        else if (htmlNode2.InnerText.Trim().Equals("等待对方发货"))
        {
          htmlNode2.InnerHtml = "交易成功";
          foreach (HtmlNode htmlNode3 in (IEnumerable<HtmlNode>) htmlNodeCollection[6].SelectNodes("./select[@id=\"J-operation-select-" + rowIndex.ToString() + "\"]/option"))
          {
            HtmlAttribute htmlAttribute = htmlNode3.Attributes["seed"];
            if (htmlAttribute != null && (htmlAttribute.Value.Equals("trade-refund") || htmlAttribute.Value.Equals("trade-detail") || htmlAttribute.Value.Equals("close-trade")))
              htmlNode3.Remove();
          }
        }
        else
        {
          if (!htmlNode2.InnerText.Trim().Equals("等待确认收货"))
            return;
          htmlNode2.InnerHtml = "交易成功";
          foreach (HtmlNode htmlNode3 in (IEnumerable<HtmlNode>) htmlNodeCollection[6].SelectNodes("./select[@id=\"J-operation-select-" + rowIndex.ToString() + "\"]/option"))
          {
            HtmlAttribute htmlAttribute = htmlNode3.Attributes["seed"];
            if (htmlAttribute != null && (htmlAttribute.Value.Equals("confirm-goods") || htmlAttribute.Value.Equals("trade-refund") || htmlAttribute.Value.Equals("long-time")))
              htmlNode3.Remove();
          }
        }
      }
    }

    public string ResolveHtmlToTradeRecords(TBJS_UserInfo user, string HttpCookieString, string HtmlText)
    {
      List<APJS_TradeRecord> tradeRecords = (List<APJS_TradeRecord>) null;
      try
      {
        HtmlDocument htmlDocument = new HtmlDocument();
        htmlDocument.OptionFixNestedTags = true;
        htmlDocument.OptionCheckSyntax = true;
        htmlDocument.OptionAutoCloseOnEnd = true;
        htmlDocument.LoadHtml(HtmlText);
        int rowIndex = 1;
        string str = string.Empty;
        HtmlNodeCollection htmlNodeCollection = htmlDocument.DocumentNode.SelectNodes("//table[@id='tradeRecordsIndex']/tbody/tr");
        if (htmlNodeCollection == null)
          return HtmlText;
        foreach (HtmlNode row in (IEnumerable<HtmlNode>) htmlNodeCollection)
        {
          this.UpdateTradeRecords(user, row, tradeRecords, rowIndex);
          ++rowIndex;
        }
        return htmlDocument.DocumentNode.InnerHtml;
      }
      catch (Exception ex)
      {
        return HtmlText;
      }
    }

    public string ResolveHtmlToTradeRecordsAdvanced(TBJS_UserInfo user, string HttpCookieString, string htmlText)
    {
      if (user.userid == 0L)
        return htmlText;
      try
      {
        HtmlDocument htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(htmlText);
        int num = 1;
        foreach (HtmlNode htmlNode1 in (IEnumerable<HtmlNode>) htmlDocument.DocumentNode.SelectNodes("//table[@id='tradeRecordsIndex']/tbody/tr"))
        {
          HtmlNodeCollection htmlNodeCollection = htmlNode1.SelectNodes("td");
          if (Enumerable.Count<HtmlNode>((IEnumerable<HtmlNode>) htmlNodeCollection) >= 9)
          {
            string str = htmlNodeCollection[3].SelectNodes("./p")[0].InnerText.Trim();
            long id = str.IndexOf('P') <= 0 ? 0L : Convert.ToInt64(str.Substring(str.IndexOf('P') + 1));
            TBJS_BuyerTradeData dataToModelById = TaobaoSQL.GetDataToModelById(user.userid, id);
            if (dataToModelById != null)
            {
              if (dataToModelById.isHide)
              {
                htmlNode1.Remove();
              }
              else
              {
                htmlNodeCollection[0].SelectSingleNode("./p").InnerHtml = Convert.ToDateTime(dataToModelById.editCreateDay).ToString("yyyy.MM.dd");
                if (dataToModelById.editTradeStatus.Equals("交易成功"))
                {
                  HtmlNode htmlNode2 = htmlNodeCollection[7].SelectNodes("./p")[0];
                  if (htmlNode2.InnerText.Trim().Equals("等待付款"))
                  {
                    htmlNode2.InnerHtml = "交易成功";
                    foreach (HtmlNode htmlNode3 in (IEnumerable<HtmlNode>) htmlNodeCollection[8].SelectNodes("./select[@id=\"J-operation-select-" + num.ToString() + "\"]/option"))
                    {
                      HtmlAttribute htmlAttribute = htmlNode3.Attributes["seed"];
                      if (htmlAttribute != null && (htmlAttribute.Value.Equals("trade-apply") || htmlAttribute.Value.Equals("find-otherpay") || htmlAttribute.Value.Equals("close-trade")))
                        htmlNode3.Remove();
                    }
                  }
                  else if (htmlNode2.InnerText.Trim().Equals("等待对方发货"))
                  {
                    htmlNode2.InnerHtml = "交易成功";
                    foreach (HtmlNode htmlNode3 in (IEnumerable<HtmlNode>) htmlNodeCollection[8].SelectNodes("./select[@id=\"J-operation-select-" + num.ToString() + "\"]/option"))
                    {
                      HtmlAttribute htmlAttribute = htmlNode3.Attributes["seed"];
                      if (htmlAttribute != null && (htmlAttribute.Value.Equals("trade-refund") || htmlAttribute.Value.Equals("trade-detail")))
                        htmlNode3.Remove();
                    }
                  }
                  else if (htmlNode2.InnerText.Trim().Equals("等待确认收货"))
                  {
                    htmlNode2.InnerHtml = "交易成功";
                    foreach (HtmlNode htmlNode3 in (IEnumerable<HtmlNode>) htmlNodeCollection[8].SelectNodes("./select[@id=\"J-operation-select-" + num.ToString() + "\"]/option"))
                    {
                      HtmlAttribute htmlAttribute = htmlNode3.Attributes["seed"];
                      if (htmlAttribute != null && (htmlAttribute.Value.Equals("confirm-goods") || htmlAttribute.Value.Equals("trade-refund") || htmlAttribute.Value.Equals("long-time")))
                        htmlNode3.Remove();
                    }
                  }
                }
              }
            }
            ++num;
          }
        }
        return htmlDocument.DocumentNode.InnerHtml;
      }
      catch (Exception ex)
      {
        return htmlText;
      }
    }

    public void UpdateTradeRecordsStandard(TBJS_UserInfo user, HtmlNode row, List<APJS_TradeRecord> tradeRecords, int rowIndex)
    {
      HtmlNodeCollection htmlNodeCollection = row.SelectNodes("td");
      string attributeValue = htmlNodeCollection[2].SelectSingleNode("./p/a").GetAttributeValue("href", "");
      if (attributeValue.Equals("") || this.GetTradeRecordById(Regex.Match(attributeValue, "tradeNo=([0-9]*)", RegexOptions.IgnoreCase).Groups[1].Value.ToString().Trim(), tradeRecords) == null)
        return;
      TBJS_vmMainOrder tbjsVmMainOrder = (TBJS_vmMainOrder) null;
      if (tbjsVmMainOrder == null)
        return;
      if (tbjsVmMainOrder.IsHide)
      {
        row.Remove();
      }
      else
      {
        if (!tbjsVmMainOrder.tradeStatusText.Equals("交易成功"))
          return;
        HtmlNode htmlNode1 = htmlNodeCollection[6].SelectNodes("./p")[0];
        if (htmlNode1.InnerText.Trim().Equals("等待付款"))
        {
          htmlNode1.InnerHtml = "交易成功";
          foreach (HtmlNode htmlNode2 in (IEnumerable<HtmlNode>) htmlNodeCollection[7].SelectNodes("./select[@id=\"J-operation-select-" + rowIndex.ToString() + "\"]/option"))
          {
            HtmlAttribute htmlAttribute = htmlNode2.Attributes["seed"];
            if (htmlAttribute != null && (htmlAttribute.Value.Equals("trade-apply") || htmlAttribute.Value.Equals("find-otherpay") || htmlAttribute.Value.Equals("close-trade")))
              htmlNode2.Remove();
          }
        }
        else if (htmlNode1.InnerText.Trim().Equals("等待对方发货"))
        {
          htmlNode1.InnerHtml = "交易成功";
          foreach (HtmlNode htmlNode2 in (IEnumerable<HtmlNode>) htmlNodeCollection[7].SelectNodes("./select[@id=\"J-operation-select-" + rowIndex.ToString() + "\"]/option"))
          {
            HtmlAttribute htmlAttribute = htmlNode2.Attributes["seed"];
            if (htmlAttribute != null && (htmlAttribute.Value.Equals("trade-refund") || htmlAttribute.Value.Equals("trade-detail")))
              htmlNode2.Remove();
          }
        }
        if (!htmlNode1.InnerText.Trim().Equals("等待确认收货"))
          return;
        htmlNode1.InnerHtml = "交易成功";
        foreach (HtmlNode htmlNode2 in (IEnumerable<HtmlNode>) htmlNodeCollection[7].SelectNodes("./select[@id=\"J-operation-select-" + rowIndex.ToString() + "\"]/option"))
        {
          HtmlAttribute htmlAttribute = htmlNode2.Attributes["seed"];
          if (htmlAttribute != null && (htmlAttribute.Value.Equals("confirm-goods") || htmlAttribute.Value.Equals("trade-refund") || htmlAttribute.Value.Equals("long-time")))
            htmlNode2.Remove();
        }
      }
    }

    public string ResolveHtmlToTradeRecordsStandard(TBJS_UserInfo user, string HttpCookieString, string htmlText)
    {
      if (user.userid == 0L)
        return htmlText;
      List<APJS_TradeRecord> tradeRecords = (List<APJS_TradeRecord>) null;
      tradeRecords.Clear();
      try
      {
        HtmlDocument htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(htmlText);
        int rowIndex = 1;
        foreach (HtmlNode row in (IEnumerable<HtmlNode>) htmlDocument.DocumentNode.SelectNodes("//table[@id='tradeRecordsIndex']/tbody/tr"))
        {
          this.UpdateTradeRecordsStandard(user, row, tradeRecords, rowIndex);
          ++rowIndex;
        }
        return htmlDocument.DocumentNode.InnerHtml;
      }
      catch (Exception ex)
      {
        return htmlText;
      }
    }

    public delegate void BindDataEventHandler(object sender, DataBindEventArgs e);
  }
}
