
// Type: TobaoHelper.OpenshopNotice
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using HtmlAgilityPack;
using System;

namespace TobaoHelper
{
  public class OpenshopNotice
  {
    public static string ClearNoticeInfo(string HtmlText)
    {
      try
      {
        HtmlDocument htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(HtmlText);
        HtmlNode htmlNode1 = htmlDocument.DocumentNode.SelectSingleNode("//div[@id='J_Region']");
        if (htmlNode1 == null)
          return HtmlText;
        HtmlNodeCollection htmlNodeCollection1 = htmlNode1.SelectNodes("//ul[@class='news-list J_NewsList ']/li");
        if (htmlNodeCollection1 != null)
        {
          HtmlNode htmlNode2 = htmlNodeCollection1[1].SelectSingleNode("div/a/em");
          if (htmlNode2 != null)
            htmlNode2.InnerHtml = "0";
        }
        HtmlNodeCollection htmlNodeCollection2 = htmlNode1.SelectNodes("//ul[@class='nav']/li");
        if (htmlNodeCollection2 != null)
        {
          HtmlNode oldChild = htmlNodeCollection2[1].SelectSingleNode("span");
          if (oldChild != null)
            oldChild.InnerHtml = "0";
          htmlNodeCollection2[1].RemoveChild(oldChild);
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
