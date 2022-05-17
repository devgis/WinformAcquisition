
// Type: TobaoHelper.UserMyRate
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using HtmlAgilityPack;
using mshtml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace TobaoHelper
{
  public class UserMyRate
  {
    private Dictionary<long, List<TBJS_Rate>> userMyRates;
    private Dictionary<long, List<TBJS_vmRate>> userChangeMyRates;

    public int IsRequestAllRecordItems { get; set; }

    public UserMyRate()
    {
      this.IsRequestAllRecordItems = 0;
      this.userMyRates = new Dictionary<long, List<TBJS_Rate>>();
      this.userChangeMyRates = new Dictionary<long, List<TBJS_vmRate>>();
    }

    public void SerializeRates(long userId)
    {
      if (userId == 0L)
        return;
      string path = string.Format("{0}Data\\{1}_rates.dat", (object) TBHelper.AppBaseDirectory, (object) userId);
      if (File.Exists(path))
        File.Delete(path);
      List<TBJS_vmRate> changeRatesByUserId = this.GetChangeRatesByUserId(userId);
      if (changeRatesByUserId == null || Enumerable.Count<TBJS_vmRate>((IEnumerable<TBJS_vmRate>) changeRatesByUserId) == 0)
        return;
      FileStream fileStream = new FileStream(path, FileMode.Create);
      new BinaryFormatter().Serialize((Stream) fileStream, (object) changeRatesByUserId);
      fileStream.Close();
    }

    public void DeSerializeRates(long userId)
    {
      string path = string.Format("{0}Data\\{1}_rates.dat", (object) TBHelper.AppBaseDirectory, (object) userId);
      if (!File.Exists(path))
        return;
      FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
      try
      {
        List<TBJS_vmRate> list = new BinaryFormatter().Deserialize((Stream) fileStream) as List<TBJS_vmRate>;
        if (this.userChangeMyRates.ContainsKey(userId))
          this.userChangeMyRates.Remove(userId);
        this.userChangeMyRates.Add(userId, list);
      }
      finally
      {
        fileStream.Close();
      }
    }

    public void ChangeLoginUser(long oldUserId, long newUserId)
    {
      this.SerializeRates(oldUserId);
      this.DeSerializeRates(newUserId);
    }

    public void ClearData()
    {
      this.userMyRates.Clear();
    }

    public void ClearAllData()
    {
      this.userMyRates.Clear();
      this.userChangeMyRates.Clear();
    }

    public DataTable GetDataSource(long userId, DataTable dt)
    {
      List<TBJS_Rate> ratesByUserId = this.GetRatesByUserId(userId);
      this.ConvertToDataTable(userId, dt, ratesByUserId);
      dt.DefaultView.Sort = "rate_type,date desc";
      return dt;
    }

    public void ConvertToDataTable(long userId, DataTable dt, List<TBJS_Rate> orders)
    {
      lock (dt.Rows.SyncRoot)
      {
        try
        {
          foreach (TBJS_Rate item_0 in orders)
          {
            if (dt.Rows.Find(new object[2]
            {
              (object) item_0.id,
              (object) item_0.rate_type
            }) == null)
            {
              DataRow local_1_1 = dt.NewRow();
              local_1_1["id"] = (object) item_0.id;
              local_1_1["user_name"] = (object) item_0.user_name;
              local_1_1["date"] = (object) item_0.date;
              local_1_1["item_id_name"] = (object) item_0.item_id_name;
              local_1_1["userid"] = (object) userId;
              local_1_1["rate_type"] = (object) item_0.rate_type;
              dt.Rows.Add(local_1_1);
            }
          }
          List<TBJS_vmRate> local_2 = this.GetChangeRatesByUserId(userId);
          if (local_2 != null)
          {
            foreach (TBJS_vmRate item_1 in local_2)
            {
              DataRow local_4 = dt.Rows.Find(new object[2]
              {
                (object) item_1.id,
                (object) item_1.rate_type
              });
              if (local_4 != null)
              {
                local_4["date"] = (object) item_1.date;
                local_4["StatusText"] = (object) item_1.StatusText;
              }
            }
          }
          dt.AcceptChanges();
        }
        catch (Exception exception_0)
        {
          throw exception_0;
        }
      }
    }

    public TBJS_vmRate GetChangeRateById(long id, int rateTypeId, List<TBJS_vmRate> rates)
    {
      return rates.Find((Predicate<TBJS_vmRate>) (r =>
      {
        if (r.id == id)
          return r.rate_type == rateTypeId;
        return false;
      }));
    }

    public TBJS_vmRate GetChangeRateById(long userId, long id, int rateTypeId)
    {
      List<TBJS_vmRate> rates = (List<TBJS_vmRate>) null;
      if (this.userChangeMyRates.TryGetValue(userId, out rates))
        return this.GetChangeRateById(id, rateTypeId, rates);
      return (TBJS_vmRate) null;
    }

    public List<TBJS_vmRate> GetChangeRatesByUserId(long userId)
    {
      List<TBJS_vmRate> list = (List<TBJS_vmRate>) null;
      if (this.userChangeMyRates.TryGetValue(userId, out list))
        return list;
      return (List<TBJS_vmRate>) null;
    }

    public void AddChangeRate(long userId, TBJS_vmRate order)
    {
      List<TBJS_vmRate> list = (List<TBJS_vmRate>) null;
      if (this.userChangeMyRates.TryGetValue(userId, out list))
        list.Add(order);
      else
        this.userChangeMyRates.Add(userId, new List<TBJS_vmRate>()
        {
          order
        });
    }

    public TBJS_Rate GetRateById(long id, int rateTypeId, List<TBJS_Rate> rates)
    {
      return rates.Find((Predicate<TBJS_Rate>) (r =>
      {
        if (r.id == id)
          return r.rate_type == rateTypeId;
        return false;
      }));
    }

    public TBJS_Rate GetRateById(long userId, long id, int rateTypeId)
    {
      List<TBJS_Rate> rates = (List<TBJS_Rate>) null;
      if (this.userMyRates.TryGetValue(userId, out rates))
        return this.GetRateById(id, rateTypeId, rates);
      return (TBJS_Rate) null;
    }

    public List<TBJS_Rate> GetRatesByUserId(long userId)
    {
      List<TBJS_Rate> list = (List<TBJS_Rate>) null;
      if (this.userMyRates.TryGetValue(userId, out list))
        return list;
      return (List<TBJS_Rate>) null;
    }

    public TBJS_vmRate GetGridViewRateById(long userId, long id, int rateTypeId)
    {
      TBJS_Rate rateById = this.GetRateById(userId, id, rateTypeId);
      TBJS_vmRate changeRateById = this.GetChangeRateById(userId, id, rateTypeId);
      if (rateById == null)
        return (TBJS_vmRate) null;
      TBJS_vmRate tbjsVmRate = new TBJS_vmRate()
      {
        id = rateById.id,
        date = rateById.date,
        userId = userId,
        rate_type = rateById.rate_type
      };
      if (changeRateById != null)
      {
        tbjsVmRate.date = changeRateById.date;
        tbjsVmRate.IsHide = changeRateById.IsHide;
        tbjsVmRate.StatusText = changeRateById.StatusText;
      }
      return tbjsVmRate;
    }

    public IHTMLElement FindNode(IHTMLElement parent, string tagName)
    {
      foreach (IHTMLElement htmlElement in (IHTMLElementCollection) parent.children)
      {
        if (htmlElement.tagName.ToLower().Equals(tagName))
          return htmlElement;
      }
      return (IHTMLElement) null;
    }

    public List<IHTMLElement> GetHTMLElementChildrens(IHTMLElement node, string tagName)
    {
      List<IHTMLElement> list = new List<IHTMLElement>();
      foreach (IHTMLElement htmlElement in (IHTMLElementCollection) node.children)
      {
        string tagName1 = htmlElement.tagName;
        if (htmlElement.tagName.ToLower().Equals(tagName))
          list.Add(htmlElement);
      }
      return list;
    }

    public string ResolveHtmlToData(TBJS_UserInfo user, string HtmlText, DataTable dt, int rateTypeId)
    {
      try
      {
        List<TBJS_Rate> list = this.GetRatesByUserId(user.userid);
        if (list == null)
        {
          list = new List<TBJS_Rate>();
          this.userMyRates.Add(user.userid, list);
        }
        HtmlDocument htmlDocument = new HtmlDocument();
        htmlDocument.OptionFixNestedTags = true;
        htmlDocument.OptionCheckSyntax = true;
        htmlDocument.OptionAutoCloseOnEnd = true;
        htmlDocument.LoadHtml(HtmlText);
        HtmlNodeCollection htmlNodeCollection1 = htmlDocument.GetElementbyId("J_RateList").SelectNodes("./tbody/tr");
        if (htmlNodeCollection1 != null)
        {
          foreach (HtmlNode row in (IEnumerable<HtmlNode>) htmlNodeCollection1)
          {
            HtmlNodeCollection cells = row.SelectNodes("td");
            if (Enumerable.Count<HtmlNode>((IEnumerable<HtmlNode>) cells) > 1)
            {
              long id = Convert.ToInt64(row.Attributes["data-id"].Value.Trim());
              TBJS_Rate rate = this.GetRateById(id, rateTypeId, list);
              if (rate == null)
              {
                rate = new TBJS_Rate();
                rate.id = id;
                rate.user_name = cells[2].SelectSingleNode("a").InnerText;
                rate.date = cells[1].SelectSingleNode("p[@class='date']").InnerText;
                rate.item_id_name = cells[3].SelectSingleNode("a").InnerText;
                rate.rate_type = rateTypeId;
                list.Add(rate);
              }
              this.UpdateRates(user, rate, row, cells);
            }
          }
          if (Enumerable.Count<TBJS_Rate>((IEnumerable<TBJS_Rate>) list) > 0)
            this.ConvertToDataTable(user.userid, dt, list);
        }
        HtmlNodeCollection htmlNodeCollection2 = htmlDocument.DocumentNode.SelectNodes("//table[@class='tb-rate-table align-c theme-plain']");
        if (htmlNodeCollection2 != null)
        {
          HtmlNodeCollection htmlNodeCollection3 = Enumerable.Count<HtmlNode>((IEnumerable<HtmlNode>) htmlNodeCollection2) <= 1 ? htmlNodeCollection2[0].SelectNodes("./tbody/tr") : htmlNodeCollection2[1].SelectNodes("./tbody/tr");
          if (htmlNodeCollection3 != null)
          {
            HtmlNodeCollection htmlNodeCollection4 = htmlNodeCollection3[0].SelectNodes("td");
            if (!string.IsNullOrEmpty(CaptureConfiguration._advSettings.RateWeekData))
              htmlNodeCollection4[1].SelectSingleNode("a").InnerHtml = CaptureConfiguration._advSettings.RateWeekData.Trim();
            if (!string.IsNullOrEmpty(CaptureConfiguration._advSettings.RateMonth))
              htmlNodeCollection4[2].SelectSingleNode("a").InnerHtml = CaptureConfiguration._advSettings.RateMonth.Trim();
            if (!string.IsNullOrEmpty(CaptureConfiguration._advSettings.RateHalfYear))
              htmlNodeCollection4[3].SelectSingleNode("a").InnerHtml = CaptureConfiguration._advSettings.RateHalfYear.Trim();
            if (!string.IsNullOrEmpty(CaptureConfiguration._advSettings.RateAll))
              htmlNodeCollection4[4].SelectSingleNode("a").InnerHtml = CaptureConfiguration._advSettings.RateAll.Trim();
            htmlNodeCollection4[5].InnerHtml = (Convert.ToInt32(htmlNodeCollection4[3].SelectSingleNode("a").InnerText) + Convert.ToInt32(htmlNodeCollection4[4].SelectSingleNode("a").InnerText)).ToString();
            htmlNodeCollection3[3].SelectNodes("td")[1].SelectSingleNode("a").InnerHtml = (Convert.ToInt32(htmlNodeCollection3[0].SelectNodes("td")[1].SelectSingleNode("a").InnerText) + Convert.ToInt32(htmlNodeCollection3[1].SelectNodes("td")[1].SelectSingleNode("a").InnerText) + Convert.ToInt32(htmlNodeCollection3[2].SelectNodes("td")[1].SelectSingleNode("a").InnerText)).ToString();
            htmlNodeCollection3[3].SelectNodes("td")[2].SelectSingleNode("a").InnerHtml = (Convert.ToInt32(htmlNodeCollection3[0].SelectNodes("td")[2].SelectSingleNode("a").InnerText) + Convert.ToInt32(htmlNodeCollection3[1].SelectNodes("td")[2].SelectSingleNode("a").InnerText) + Convert.ToInt32(htmlNodeCollection3[2].SelectNodes("td")[2].SelectSingleNode("a").InnerText)).ToString();
            htmlNodeCollection3[3].SelectNodes("td")[3].SelectSingleNode("a").InnerHtml = (Convert.ToInt32(htmlNodeCollection3[0].SelectNodes("td")[3].SelectSingleNode("a").InnerText) + Convert.ToInt32(htmlNodeCollection3[1].SelectNodes("td")[3].SelectSingleNode("a").InnerText) + Convert.ToInt32(htmlNodeCollection3[2].SelectNodes("td")[3].SelectSingleNode("a").InnerText)).ToString();
            htmlNodeCollection3[3].SelectNodes("td")[4].SelectSingleNode("a").InnerHtml = (Convert.ToInt32(htmlNodeCollection3[0].SelectNodes("td")[4].SelectSingleNode("a").InnerText) + Convert.ToInt32(htmlNodeCollection3[1].SelectNodes("td")[4].SelectSingleNode("a").InnerText) + Convert.ToInt32(htmlNodeCollection3[2].SelectNodes("td")[4].SelectSingleNode("a").InnerText)).ToString();
            htmlNodeCollection3[3].SelectNodes("td")[5].InnerHtml = (Convert.ToInt32(htmlNodeCollection3[0].SelectNodes("td")[5].InnerText) + Convert.ToInt32(htmlNodeCollection3[1].SelectNodes("td")[5].InnerText) + Convert.ToInt32(htmlNodeCollection3[2].SelectNodes("td")[5].InnerText)).ToString();
            HtmlNode htmlNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='personal-rating']/h4[@class='tb-rate-ico-bg ico-buyer']/a");
            if (htmlNode != null)
              htmlNode.InnerHtml = htmlNodeCollection3[3].SelectNodes("td")[5].InnerHtml;
          }
          if (Enumerable.Count<HtmlNode>((IEnumerable<HtmlNode>) htmlNodeCollection2) > 1)
          {
            HtmlNodeCollection htmlNodeCollection4 = htmlNodeCollection2[0].SelectNodes("./tbody/tr");
            if (htmlNodeCollection4 != null)
            {
              HtmlNodeCollection htmlNodeCollection5 = htmlNodeCollection4[0].SelectNodes("td");
              if (!string.IsNullOrEmpty(CaptureConfiguration._advSettings.RateWeekData))
                htmlNodeCollection5[1].SelectSingleNode("a").InnerHtml = CaptureConfiguration._advSettings.RateWeekDataForSales.Trim();
              if (!string.IsNullOrEmpty(CaptureConfiguration._advSettings.RateMonth))
                htmlNodeCollection5[2].SelectSingleNode("a").InnerHtml = CaptureConfiguration._advSettings.RateMonthForSales.Trim();
              if (!string.IsNullOrEmpty(CaptureConfiguration._advSettings.RateHalfYear))
                htmlNodeCollection5[3].SelectSingleNode("a").InnerHtml = CaptureConfiguration._advSettings.RateHalfYearForSales.Trim();
              if (!string.IsNullOrEmpty(CaptureConfiguration._advSettings.RateAll))
                htmlNodeCollection5[4].SelectSingleNode("a").InnerHtml = CaptureConfiguration._advSettings.RateAllForSales.Trim();
              htmlNodeCollection5[5].InnerHtml = (Convert.ToInt32(htmlNodeCollection5[3].SelectSingleNode("a").InnerText) + Convert.ToInt32(htmlNodeCollection5[4].SelectSingleNode("a").InnerText)).ToString();
              htmlNodeCollection4[3].SelectNodes("td")[1].SelectSingleNode("a").InnerHtml = (Convert.ToInt32(htmlNodeCollection4[0].SelectNodes("td")[1].SelectSingleNode("a").InnerText) + Convert.ToInt32(htmlNodeCollection4[1].SelectNodes("td")[1].SelectSingleNode("a").InnerText) + Convert.ToInt32(htmlNodeCollection4[2].SelectNodes("td")[1].SelectSingleNode("a").InnerText)).ToString();
              htmlNodeCollection4[3].SelectNodes("td")[2].SelectSingleNode("a").InnerHtml = (Convert.ToInt32(htmlNodeCollection4[0].SelectNodes("td")[2].SelectSingleNode("a").InnerText) + Convert.ToInt32(htmlNodeCollection4[1].SelectNodes("td")[2].SelectSingleNode("a").InnerText) + Convert.ToInt32(htmlNodeCollection4[2].SelectNodes("td")[2].SelectSingleNode("a").InnerText)).ToString();
              htmlNodeCollection4[3].SelectNodes("td")[3].SelectSingleNode("a").InnerHtml = (Convert.ToInt32(htmlNodeCollection4[0].SelectNodes("td")[3].SelectSingleNode("a").InnerText) + Convert.ToInt32(htmlNodeCollection4[1].SelectNodes("td")[3].SelectSingleNode("a").InnerText) + Convert.ToInt32(htmlNodeCollection4[2].SelectNodes("td")[3].SelectSingleNode("a").InnerText)).ToString();
              htmlNodeCollection4[3].SelectNodes("td")[4].SelectSingleNode("a").InnerHtml = (Convert.ToInt32(htmlNodeCollection4[0].SelectNodes("td")[4].SelectSingleNode("a").InnerText) + Convert.ToInt32(htmlNodeCollection4[1].SelectNodes("td")[4].SelectSingleNode("a").InnerText) + Convert.ToInt32(htmlNodeCollection4[2].SelectNodes("td")[4].SelectSingleNode("a").InnerText)).ToString();
              htmlNodeCollection4[3].SelectNodes("td")[5].InnerHtml = (Convert.ToInt32(htmlNodeCollection4[0].SelectNodes("td")[5].InnerText) + Convert.ToInt32(htmlNodeCollection4[1].SelectNodes("td")[5].InnerText) + Convert.ToInt32(htmlNodeCollection4[2].SelectNodes("td")[5].InnerText)).ToString();
              HtmlNode htmlNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='personal-rating']/h4[@class='tb-rate-ico-bg ico-seller']/a");
              if (htmlNode != null)
                htmlNode.InnerHtml = htmlNodeCollection4[3].SelectNodes("td")[5].InnerHtml;
            }
          }
        }
        return htmlDocument.DocumentNode.InnerHtml;
      }
      catch
      {
        return HtmlText;
      }
    }

    public string UpdateRateRangeData(string HtmlText, TBJS_UserInfo user, int typeRateId)
    {
      try
      {
        HtmlDocument htmlDocument = new HtmlDocument();
        htmlDocument.OptionFixNestedTags = true;
        htmlDocument.OptionCheckSyntax = true;
        htmlDocument.OptionAutoCloseOnEnd = true;
        htmlDocument.LoadHtml(HtmlText);
        HtmlNodeCollection htmlNodeCollection1 = htmlDocument.DocumentNode.SelectNodes("//table[@class='tb-rate-table align-c theme-plain']/tbody/tr");
        HtmlNodeCollection htmlNodeCollection2 = htmlNodeCollection1[0].SelectNodes("td");
        if (!string.IsNullOrEmpty(CaptureConfiguration._advSettings.RateWeekData))
          htmlNodeCollection2[1].SelectSingleNode("a").InnerHtml = CaptureConfiguration._advSettings.RateWeekData.Trim();
        if (!string.IsNullOrEmpty(CaptureConfiguration._advSettings.RateMonth))
          htmlNodeCollection2[2].SelectSingleNode("a").InnerHtml = CaptureConfiguration._advSettings.RateMonth.Trim();
        if (!string.IsNullOrEmpty(CaptureConfiguration._advSettings.RateHalfYear))
          htmlNodeCollection2[3].SelectSingleNode("a").InnerHtml = CaptureConfiguration._advSettings.RateHalfYear.Trim();
        if (!string.IsNullOrEmpty(CaptureConfiguration._advSettings.RateAll))
          htmlNodeCollection2[4].SelectSingleNode("a").InnerHtml = CaptureConfiguration._advSettings.RateAll.Trim();
        htmlNodeCollection2[5].InnerHtml = (Convert.ToInt32(htmlNodeCollection2[3].SelectSingleNode("a").InnerText) + Convert.ToInt32(htmlNodeCollection2[4].SelectSingleNode("a").InnerText)).ToString();
        htmlNodeCollection1[3].SelectNodes("td")[1].SelectSingleNode("a").InnerHtml = (Convert.ToInt32(htmlNodeCollection1[0].SelectNodes("td")[1].SelectSingleNode("a").InnerText) + Convert.ToInt32(htmlNodeCollection1[1].SelectNodes("td")[1].SelectSingleNode("a").InnerText) + Convert.ToInt32(htmlNodeCollection1[2].SelectNodes("td")[1].SelectSingleNode("a").InnerText)).ToString();
        htmlNodeCollection1[3].SelectNodes("td")[2].SelectSingleNode("a").InnerHtml = (Convert.ToInt32(htmlNodeCollection1[0].SelectNodes("td")[2].SelectSingleNode("a").InnerText) + Convert.ToInt32(htmlNodeCollection1[1].SelectNodes("td")[2].SelectSingleNode("a").InnerText) + Convert.ToInt32(htmlNodeCollection1[2].SelectNodes("td")[2].SelectSingleNode("a").InnerText)).ToString();
        htmlNodeCollection1[3].SelectNodes("td")[3].SelectSingleNode("a").InnerHtml = (Convert.ToInt32(htmlNodeCollection1[0].SelectNodes("td")[3].SelectSingleNode("a").InnerText) + Convert.ToInt32(htmlNodeCollection1[1].SelectNodes("td")[3].SelectSingleNode("a").InnerText) + Convert.ToInt32(htmlNodeCollection1[2].SelectNodes("td")[3].SelectSingleNode("a").InnerText)).ToString();
        htmlNodeCollection1[3].SelectNodes("td")[4].SelectSingleNode("a").InnerHtml = (Convert.ToInt32(htmlNodeCollection1[0].SelectNodes("td")[4].SelectSingleNode("a").InnerText) + Convert.ToInt32(htmlNodeCollection1[1].SelectNodes("td")[4].SelectSingleNode("a").InnerText) + Convert.ToInt32(htmlNodeCollection1[2].SelectNodes("td")[4].SelectSingleNode("a").InnerText)).ToString();
        htmlNodeCollection1[3].SelectNodes("td")[5].InnerHtml = (Convert.ToInt32(htmlNodeCollection1[0].SelectNodes("td")[5].InnerText) + Convert.ToInt32(htmlNodeCollection1[1].SelectNodes("td")[5].InnerText) + Convert.ToInt32(htmlNodeCollection1[2].SelectNodes("td")[5].InnerText)).ToString();
        HtmlNode htmlNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='personal-rating']/h4[@class='tb-rate-ico-bg ico-buyer']/a");
        if (htmlNode != null)
          htmlNode.InnerHtml = htmlNodeCollection1[3].SelectNodes("td")[5].InnerHtml;
        return htmlDocument.DocumentNode.InnerHtml;
      }
      catch
      {
        return HtmlText;
      }
    }

    public string RequestHtmlToData(string HtmlText)
    {
      return (string) null;
    }

    public bool AllowRequestHtml()
    {
      return false;
    }

    private void UpdateRates(TBJS_UserInfo user, TBJS_Rate rate, HtmlNode row, HtmlNodeCollection cells)
    {
      TBJS_vmRate changeRateById = this.GetChangeRateById(user.userid, rate.id, rate.rate_type);
      if (changeRateById == null)
        return;
      if (changeRateById.IsHide)
      {
        row.Remove();
      }
      else
      {
        if (!(changeRateById.date != cells[1].SelectSingleNode("p[@class='date']").InnerText))
          return;
        cells[1].SelectSingleNode("p[@class='date']").InnerHtml = changeRateById.date;
      }
    }
  }
}
