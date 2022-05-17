
// Type: TobaoHelper.TBHelper
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using DotNet4.Utilities;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TobaoHelper.Taobao;

namespace TobaoHelper
{
  public class TBHelper
  {
    public static string AppBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
    public static string TBCookie = string.Empty;
    public static string ListBoughtItemsCookie = string.Empty;
    public static TBJS_UserInfo CurrentUserInfo = (TBJS_UserInfo) null;
    public static int LoginStatus = 0;
    public static bool isFirstSslRequest = true;
    private static List<string> _captureSessionUrl = new List<string>();
    private static List<string> _taobaoSessionUrl = new List<string>();
    private static List<string> _mustLoginSessionUrl = new List<string>();
    private static List<string> _mustGetRecyledsSessionUrl = new List<string>();
    private static List<string> _alipaySessionUrl = new List<string>();
    public static BuyerTradeManage buyerTradeManage = new BuyerTradeManage();
    public static UserMyRate MyRate = new UserMyRate();
    public static AlipayTrash alipayTrash = new AlipayTrash();
    public static AlipayManage alipayManage = new AlipayManage();
    public const string HostName = "https://www.taobao.com";
    public const string login_taobao_com = "https://login.taobao.com/member/login.jhtml";
    public const string my_taobao_remind_data_htm = "https://i.taobao.com/json/my_taobao_remind_data.htm";
    public const string my_taobao_htm = "https://i.taobao.com/my_taobao.htm";
    public const string my_taobao_logistics_info_json = "https://i.taobao.com/my_taobao_api/logistics_info.json?";
    public const string list_bought_items_htm = "https://buyertrade.taobao.com/trade/itemlist/list_bought_items.htm";
    public const string asyncbought_htm = "https://buyertrade.taobao.com/trade/itemlist/asyncbought.htm";
    public const string list_recyled_items_htm = "https://buyertrade.taobao.com/trade/itemlist/list_recyled_items.htm";
    public const string asyncrecyleditems_htm = "https://buyertrade.taobao.com/trade/itemlist/asyncRecyledItems.htm";
    public const string get_growth_record_ajax = "https://vip.taobao.com/ajax/growth/get_growth_record.do?";
    public const string myrate_htm = "https://rate.taobao.com/myrate.htm";
    public const string user_myrate_htm = "https://rate.taobao.com/user-myrate";
    public const string notice_taobao_com = "https://notice.taobao.com/?spm=";
    public const string notice_taobao_com_index_htm = "https://notice.taobao.com/index.htm?";
    public const string alipay_trashindex_htm = "https://consumeprod.alipay.com/record/trashindex.htm";
    public const string alipay_com_record_items = "https://lab.alipay.com/consume/record/items.htm";
    public const string alipay_com_yy_content_jygl_xhr = "https://my.alipay.com/tile/service/portal:recent.tile?t=";
    public const string alipay_com_yy_content_jygl = "https://my.alipay.com/portal/i.htm?src=yy_content_jygl";
    public const string alipay_com_yy_content_jygl_advanced = "https://consumeprod.alipay.com/record/advanced.htm";
    public const string alipay_com_yy_content_jygl_standard = "https://consumeprod.alipay.com/record/standard.htm";
    public const string WAIT_BUYER_PAY = "WAIT_BUYER_PAY";
    public const string WAIT_BUYER_PAY_TEXT = "待付款";
    public const string WAIT_SELLER_SEND_GOODS = "WAIT_SELLER_SEND_GOODS";
    public const string WAIT_SELLER_SEND_GOODS_TEXT = "待发货";
    public const string WAIT_BUYER_CONFIRM_GOODS = "WAIT_BUYER_CONFIRM_GOODS";
    public const string WAIT_BUYER_CONFIRM_GOODS_TEXT = "待收货";
    public const string TRADE_CLOSED = "TRADE_CLOSED";
    public const string TRADE_CLOSED_TEXT = "交易关闭";
    public const string CREATE_CLOSED_OF_TAOBAO = "CREATE_CLOSED_OF_TAOBAO";
    public const string CREATE_CLOSED_OF_TAOBAO_TEXT = "交易关闭";
    public const string WAIT_BUYER_RATE = "TRADE_FINISHED";
    public const string WAIT_BUYER_RATE_TEXT = "待评价";
    public const string TRADE_FINISHED = "TRADE_FINISHED";
    public const string TRADE_FINISHED_TEXT = "交易成功";
    public const string TRADE_HIDE_TEXT = "隐藏";
    public const string TABCODE_WAITPAY = "waitPay";
    public const string TABCODE_WAITPAY_TEXT = "待付款";
    public const string TABCODE_WAITSEND = "waitSend";
    public const string TABCODE_WAITSEND_TEXT = "待发货";
    public const string TABCODE_WAITCONFIRM = "waitConfirm";
    public const string TABCODE_WAITCONFIRM_TEXT = "待收货";
    public const string TABCODE_WAITRATE = "waitRate";
    public const string TABCODE_WAITRATE_TEXT = "待评价";
    public const string TRADE_DELETE_TEXT = "删除";

    static TBHelper()
    {
      TBHelper._captureSessionUrl.Add("https://i.taobao.com/json/my_taobao_remind_data.htm");
      TBHelper._captureSessionUrl.Add("https://i.taobao.com/my_taobao.htm");
      TBHelper._captureSessionUrl.Add("https://i.taobao.com/my_taobao_api/logistics_info.json?");
      TBHelper._captureSessionUrl.Add("https://buyertrade.taobao.com/trade/itemlist/list_bought_items.htm");
      TBHelper._captureSessionUrl.Add("https://buyertrade.taobao.com/trade/itemlist/asyncbought.htm");
      TBHelper._captureSessionUrl.Add("https://buyertrade.taobao.com/trade/itemlist/list_recyled_items.htm");
      TBHelper._captureSessionUrl.Add("https://buyertrade.taobao.com/trade/itemlist/asyncRecyledItems.htm");
      TBHelper._captureSessionUrl.Add("https://rate.taobao.com/myrate.htm");
      TBHelper._captureSessionUrl.Add("https://rate.taobao.com/user-myrate");
      TBHelper._captureSessionUrl.Add("https://notice.taobao.com/?spm=");
      TBHelper._captureSessionUrl.Add("https://notice.taobao.com/index.htm?");
      TBHelper._captureSessionUrl.Add("https://consumeprod.alipay.com/record/trashindex.htm");
      TBHelper._captureSessionUrl.Add("https://lab.alipay.com/consume/record/items.htm");
      TBHelper._captureSessionUrl.Add("https://my.alipay.com/tile/service/portal:recent.tile?t=");
      TBHelper._captureSessionUrl.Add("https://my.alipay.com/portal/i.htm?src=yy_content_jygl");
      TBHelper._captureSessionUrl.Add("https://consumeprod.alipay.com/record/advanced.htm");
      TBHelper._captureSessionUrl.Add("https://consumeprod.alipay.com/record/standard.htm");
      TBHelper._captureSessionUrl.Add("https://vip.taobao.com/ajax/growth/get_growth_record.do?");
      TBHelper._taobaoSessionUrl.Add("https://i.taobao.com/json/my_taobao_remind_data.htm");
      TBHelper._taobaoSessionUrl.Add("https://i.taobao.com/my_taobao.htm");
      TBHelper._taobaoSessionUrl.Add("https://i.taobao.com/my_taobao_api/logistics_info.json?");
      TBHelper._taobaoSessionUrl.Add("https://buyertrade.taobao.com/trade/itemlist/list_bought_items.htm");
      TBHelper._taobaoSessionUrl.Add("https://buyertrade.taobao.com/trade/itemlist/asyncbought.htm");
      TBHelper._taobaoSessionUrl.Add("https://buyertrade.taobao.com/trade/itemlist/list_recyled_items.htm");
      TBHelper._taobaoSessionUrl.Add("https://buyertrade.taobao.com/trade/itemlist/asyncRecyledItems.htm");
      TBHelper._taobaoSessionUrl.Add("https://rate.taobao.com/myrate.htm");
      TBHelper._taobaoSessionUrl.Add("https://rate.taobao.com/user-myrate");
      TBHelper._taobaoSessionUrl.Add("https://notice.taobao.com/?spm=");
      TBHelper._taobaoSessionUrl.Add("https://notice.taobao.com/index.htm?");
      TBHelper._taobaoSessionUrl.Add("https://vip.taobao.com/ajax/growth/get_growth_record.do?");
      TBHelper._mustGetRecyledsSessionUrl.Add("https://i.taobao.com/json/my_taobao_remind_data.htm");
      TBHelper._mustGetRecyledsSessionUrl.Add("https://i.taobao.com/my_taobao.htm");
      TBHelper._mustGetRecyledsSessionUrl.Add("https://buyertrade.taobao.com/trade/itemlist/list_bought_items.htm");
      TBHelper._mustGetRecyledsSessionUrl.Add("https://buyertrade.taobao.com/trade/itemlist/asyncbought.htm");
      TBHelper._alipaySessionUrl.Add("https://consumeprod.alipay.com/record/trashindex.htm");
      TBHelper._alipaySessionUrl.Add("https://lab.alipay.com/consume/record/items.htm");
      TBHelper._alipaySessionUrl.Add("https://my.alipay.com/portal/i.htm?src=yy_content_jygl");
      TBHelper._alipaySessionUrl.Add("https://consumeprod.alipay.com/record/advanced.htm");
      TBHelper._alipaySessionUrl.Add("https://consumeprod.alipay.com/record/standard.htm");
      TBHelper._alipaySessionUrl.Add("https://my.alipay.com/tile/service/portal:recent.tile?t=");
      TBHelper._mustLoginSessionUrl.Add("https://i.taobao.com/json/my_taobao_remind_data.htm");
      TBHelper._mustLoginSessionUrl.Add("https://i.taobao.com/my_taobao.htm");
      TBHelper._mustLoginSessionUrl.Add("https://buyertrade.taobao.com/trade/itemlist/list_bought_items.htm");
      TBHelper._mustLoginSessionUrl.Add("https://buyertrade.taobao.com/trade/itemlist/list_recyled_items.htm");
      TBHelper._mustLoginSessionUrl.Add("https://rate.taobao.com/myrate.htm");
      TBHelper._mustLoginSessionUrl.Add("https://rate.taobao.com/user-myrate");
      TBHelper._mustLoginSessionUrl.Add("https://notice.taobao.com/?spm=");
      TBHelper._mustLoginSessionUrl.Add("https://notice.taobao.com/index.htm?");
      TBHelper.CurrentUserInfo = new TBJS_UserInfo();
    }

    public static TBJS_UserInfo GetUserInfo(string cookie)
    {
      HttpHelper httpHelper = new HttpHelper();
      HttpItem httpItem = new HttpItem()
      {
        URL = string.Format("{0}?spm=a1z02.1.a210b.d1000351.Aim3CW&is_user_do_async=1&nekot={1}", (object) "https://i.taobao.com/my_taobao.htm", (object) DateTime.Now.ToString("yyyyMMddHHmmssfff")),
        Method = "GET",
        ContentType = "text/html; charset=utf-8",
        Allowautoredirect = true
      };
      if (CaptureConfiguration.ProxyRunning)
        httpItem.ProxyIp = string.Format("127.0.0.1:{0}", (object) CaptureConfiguration.ProxyPort);
      if (cookie != null)
        httpItem.Cookie = cookie;
      HttpResult html = httpHelper.GetHtml(httpItem);
      if (html.StatusCode != HttpStatusCode.OK)
        return (TBJS_UserInfo) null;
      TBJS_UserInfo tbjsUserInfo = new TBJS_UserInfo();
      try
      {
        HtmlDocument htmlDocument = new HtmlDocument();
        htmlDocument.OptionFixNestedTags = true;
        htmlDocument.OptionCheckSyntax = true;
        htmlDocument.OptionAutoCloseOnEnd = true;
        htmlDocument.LoadHtml(html.Html);
        htmlDocument.GetElementbyId("mtb-userid");
        string attributeValue = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='mtb-userid']").GetAttributeValue("value", string.Empty);
        tbjsUserInfo.userid = Convert.ToInt64(attributeValue);
        tbjsUserInfo.nickname = htmlDocument.DocumentNode.SelectSingleNode("//input[@id='mtb-nickname']").GetAttributeValue("value", string.Empty);
        return tbjsUserInfo;
      }
      catch
      {
        return (TBJS_UserInfo) null;
      }
    }

    public static string GetWebRequestHtml(string url, string cookie = null)
    {
      HttpHelper httpHelper = new HttpHelper();
      HttpItem httpItem = new HttpItem();
      httpItem.URL = url;
      httpItem.Method = "get";
      httpItem.ContentType = "text/html; charset=utf-8";
      httpItem.Allowautoredirect = true;
      httpItem.ProxyIp = "127.0.0.1:8888";
      if (cookie != null)
        httpItem.Cookie = cookie;
      HttpResult html = httpHelper.GetHtml(httpItem);
      if (html.StatusCode == HttpStatusCode.OK)
        return html.Html;
      return string.Empty;
    }

    public static TBJS_Tab GetTabByCode(string code, List<TBJS_Tab> tabs)
    {
      return tabs.Find((Predicate<TBJS_Tab>) (o => o.code.Equals(code)));
    }

    public static TBJS_Operation GetOperationByText(string text, List<TBJS_Operation> operations)
    {
      return operations.Find((Predicate<TBJS_Operation>) (o =>
      {
        if (!string.IsNullOrEmpty(o.text))
          return o.text.Equals(text);
        return false;
      }));
    }

    public static TBJS_Operation GetOperationById(string id, List<TBJS_Operation> operations)
    {
      return operations.Find((Predicate<TBJS_Operation>) (o =>
      {
        if (!string.IsNullOrEmpty(o.id))
          return o.id.Equals(id);
        return false;
      }));
    }

    public static bool IsRateOrder(TBJS_MainOrder order)
    {
      if (order == null)
        return false;
      List<TBJS_Operation> operations = Enumerable.ToList<TBJS_Operation>((IEnumerable<TBJS_Operation>) order.operations);
      if (operations == null || TBHelper.GetOperationById("rateOrder", operations) == null)
        return false;
      return TBHelper.GetOperationById("rateOrder", operations) != null;
    }

    public static bool IsNotFinishedTrade(TBJS_MainOrder order)
    {
      if (order.extra.tradeStatus.Equals("WAIT_BUYER_PAY") || order.extra.tradeStatus.Equals("WAIT_SELLER_SEND_GOODS") || order.extra.tradeStatus.Equals("WAIT_BUYER_CONFIRM_GOODS"))
        return true;
      if (order.extra.tradeStatus.Equals("TRADE_FINISHED"))
        return TBHelper.IsRateOrder(order);
      return false;
    }

    public static string GetOrderTradeStatusText(TBJS_MainOrder order)
    {
      switch (order.extra.tradeStatus)
      {
        case "WAIT_BUYER_PAY":
          return "待付款";
        case "WAIT_SELLER_SEND_GOODS":
          return "待发货";
        case "WAIT_BUYER_CONFIRM_GOODS":
          return "待收货";
        case "TRADE_CLOSED":
          return "交易关闭";
        case "CREATE_CLOSED_OF_TAOBAO":
          return "交易关闭";
        case "TRADE_FINISHED":
          return !TBHelper.IsRateOrder(order) ? "交易成功" : "待评价";
        default:
          return "未知";
      }
    }

    public static string GetTabCodeToTradeStatus(string tabCode)
    {
      switch (tabCode)
      {
        case "waitPay":
          return "待付款";
        case "waitSend":
          return "待发货";
        case "waitConfirm":
          return "待收货";
        case "waitRate":
          return "待评价";
        default:
          return "";
      }
    }

    public static bool IsTradeNotComplete(TBJS_MainOrder order)
    {
      return order.extra.tradeStatus.Equals("WAIT_BUYER_PAY") || order.extra.tradeStatus.Equals("WAIT_SELLER_SEND_GOODS") || order.extra.tradeStatus.Equals("WAIT_BUYER_CONFIRM_GOODS") || order.extra.tradeStatus.Equals("TRADE_FINISHED") && TBHelper.IsRateOrder(order);
    }

    public static bool IsTradeNotComplete(string tradeStatusText)
    {
      return tradeStatusText.Equals("待付款") || tradeStatusText.Equals("待发货") || (tradeStatusText.Equals("待收货") || tradeStatusText.Equals("待评价"));
    }

    public static bool IsWaitConfirm(TBJS_MainOrder order)
    {
      return order.extra.tradeStatus.Equals("WAIT_BUYER_CONFIRM_GOODS");
    }

    public static int GetSubOrderCount(TBJS_MainOrder order)
    {
      return Enumerable.Count<TBJS_SubOrder>(Enumerable.Where<TBJS_SubOrder>((IEnumerable<TBJS_SubOrder>) order.subOrders, (Func<TBJS_SubOrder, bool>) (s => s.id != 0L)));
    }

    public static string GetAlipayTrashEmptyHtml()
    {
      string path = TBHelper.AppBaseDirectory + "j-trash-empty.dat";
      if (System.IO.File.Exists(path))
        return System.IO.File.ReadAllText(path);
      return string.Empty;
    }

    public static string TradeStatus2Text(string tradeStatus)
    {
      return "";
    }

    public static bool IncaptureSessionUrl(string url)
    {
      return Enumerable.Count<string>(Enumerable.Where<string>((IEnumerable<string>) TBHelper._captureSessionUrl, (Func<string, bool>) (c => url.ToLower().StartsWith(c.ToLower())))) > 0;
    }

    public static bool IsHostWithTaobao(string url)
    {
      return Enumerable.Count<string>(Enumerable.Where<string>((IEnumerable<string>) TBHelper._taobaoSessionUrl, (Func<string, bool>) (c => url.ToLower().StartsWith(c.ToLower())))) > 0;
    }

    public static bool IsHostWithIsLogin(string url)
    {
      return Enumerable.Count<string>(Enumerable.Where<string>((IEnumerable<string>) TBHelper._mustLoginSessionUrl, (Func<string, bool>) (c => url.ToLower().StartsWith(c.ToLower())))) > 0;
    }

    public static bool IsHostWithAlipay(string url)
    {
      return Enumerable.Count<string>(Enumerable.Where<string>((IEnumerable<string>) TBHelper._alipaySessionUrl, (Func<string, bool>) (c => url.ToLower().StartsWith(c.ToLower())))) > 0;
    }

    public static bool IsHostWithIsGetRecyleds(string url)
    {
      return Enumerable.Count<string>(Enumerable.Where<string>((IEnumerable<string>) TBHelper._mustGetRecyledsSessionUrl, (Func<string, bool>) (c => url.ToLower().StartsWith(c.ToLower())))) > 0;
    }
  }
}
