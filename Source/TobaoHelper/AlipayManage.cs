
// Type: TobaoHelper.AlipayManage
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace TobaoHelper
{
  public class AlipayManage
  {
    private Dictionary<long, List<TBJS_TradeRecord>> tradeRecords;
    private Dictionary<long, List<TBJS_vmTradeRecord>> changeTradeRecords;

    public AlipayManage()
    {
      this.tradeRecords = new Dictionary<long, List<TBJS_TradeRecord>>();
      this.changeTradeRecords = new Dictionary<long, List<TBJS_vmTradeRecord>>();
    }

    public void SerializeTradeRecords(long userId)
    {
      if (userId == 0L)
        return;
      string path = string.Format("{0}Data\\{1}_traderecords.dat", (object) TBHelper.AppBaseDirectory, (object) userId);
      List<TBJS_vmTradeRecord> tradeRecordsByUserId = this.GetChangeTradeRecordsByUserId(userId);
      if (File.Exists(path))
        File.Delete(path);
      if (tradeRecordsByUserId == null || Enumerable.Count<TBJS_vmTradeRecord>((IEnumerable<TBJS_vmTradeRecord>) tradeRecordsByUserId) == 0)
        return;
      FileStream fileStream = new FileStream(path, FileMode.Create);
      new BinaryFormatter().Serialize((Stream) fileStream, (object) tradeRecordsByUserId);
      fileStream.Close();
    }

    public void DeSerializeTradeRecords(long userId)
    {
      string path = string.Format("{0}Data\\{1}_traderecords.dat", (object) TBHelper.AppBaseDirectory, (object) userId);
      if (!File.Exists(path))
        return;
      FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
      try
      {
        List<TBJS_vmTradeRecord> list = new BinaryFormatter().Deserialize((Stream) fileStream) as List<TBJS_vmTradeRecord>;
        if (this.changeTradeRecords.ContainsKey(userId))
          this.changeTradeRecords.Remove(userId);
        this.changeTradeRecords.Add(userId, list);
      }
      finally
      {
        fileStream.Close();
      }
    }

    public void ChangeLoginUser(long oldUserId, long newUserId)
    {
      this.SerializeTradeRecords(oldUserId);
      this.DeSerializeTradeRecords(newUserId);
    }

    public void ClearData()
    {
      this.tradeRecords.Clear();
    }

    public void ClearAllData()
    {
      this.tradeRecords.Clear();
      this.changeTradeRecords.Clear();
    }

    public DataTable GetDataSource(long userId, DataTable dt)
    {
      List<TBJS_TradeRecord> tradeRecordsByUserId = this.GetTradeRecordsByUserId(userId);
      this.ConvertToDataTable(userId, dt, tradeRecordsByUserId);
      dt.DefaultView.Sort = "date desc";
      return dt;
    }

    public void ConvertToDataTable(long userId, DataTable dt, List<TBJS_TradeRecord> orders)
    {
        lock (dt.Rows.SyncRoot)
        {
            try
            {
                foreach (TBJS_TradeRecord current in orders)
                {
                    if (dt.Rows.Find(current.rowid) == null)
                    {
                        DataRow dataRow = dt.NewRow();
                        dataRow["rowid"] = current.rowid;
                        dataRow["number"] = current.number;
                        dataRow["date"] = current.date;
                        dataRow["name"] = current.name;
                        dataRow["memo"] = current.memo;
                        dataRow["in_amount"] = current.in_amount;
                        dataRow["out_amount"] = current.out_amount;
                        dataRow["balance"] = current.balance;
                        dataRow["from"] = current.from;
                        dataRow["userId"] = userId;
                        dataRow["StatusText"] = "";
                        dataRow["IsClearMemo"] = false;
                        dataRow["IsHide"] = false;
                        dt.Rows.Add(dataRow);
                    }
                }
                List<TBJS_vmTradeRecord> changeTradeRecordsByUserId = this.GetChangeTradeRecordsByUserId(userId);
                if (changeTradeRecordsByUserId != null)
                {
                    foreach (TBJS_vmTradeRecord current2 in changeTradeRecordsByUserId)
                    {
                        DataRow dataRow2 = dt.Rows.Find(current2.rowid);
                        if (dataRow2 != null)
                        {
                            dataRow2["date"] = current2.date;
                            dataRow2["name"] = current2.name;
                            dataRow2["memo"] = current2.memo;
                            dataRow2["in_amount"] = current2.in_amount;
                            dataRow2["out_amount"] = current2.out_amount;
                            dataRow2["StatusText"] = (current2.IsHide ? "隐藏" : "");
                            dataRow2["IsClearMemo"] = current2.IsClearMemo;
                            dataRow2["IsHide"] = current2.IsHide;
                        }
                    }
                }
                dt.AcceptChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public List<TBJS_TradeRecord> GetTradeRecordsByUserId(long userId)
    {
      List<TBJS_TradeRecord> list = (List<TBJS_TradeRecord>) null;
      if (this.tradeRecords.TryGetValue(userId, out list))
        return list;
      return (List<TBJS_TradeRecord>) null;
    }

    public TBJS_TradeRecord GetTradeRecordById(string rowid, List<TBJS_TradeRecord> orders)
    {
      return orders.Find((Predicate<TBJS_TradeRecord>) (o => o.rowid.Equals(rowid)));
    }

    public TBJS_TradeRecord GetTradeRecordById(long userId, string rowid)
    {
      List<TBJS_TradeRecord> orders = (List<TBJS_TradeRecord>) null;
      if (this.tradeRecords.TryGetValue(userId, out orders))
        return this.GetTradeRecordById(rowid, orders);
      return (TBJS_TradeRecord) null;
    }

    public void AddChangeTradeRecord(long userId, TBJS_vmTradeRecord order)
    {
      List<TBJS_vmTradeRecord> list = (List<TBJS_vmTradeRecord>) null;
      if (this.changeTradeRecords.TryGetValue(userId, out list))
        list.Add(order);
      else
        this.changeTradeRecords.Add(userId, new List<TBJS_vmTradeRecord>()
        {
          order
        });
    }

    public List<TBJS_vmTradeRecord> GetChangeTradeRecordsByUserId(long userId)
    {
      List<TBJS_vmTradeRecord> list = (List<TBJS_vmTradeRecord>) null;
      if (this.changeTradeRecords.TryGetValue(userId, out list))
        return list;
      return (List<TBJS_vmTradeRecord>) null;
    }

    public TBJS_vmTradeRecord GetChangeTradeRecordById(string rowid, List<TBJS_vmTradeRecord> orders)
    {
      return orders.Find((Predicate<TBJS_vmTradeRecord>) (o => o.rowid.Equals(rowid)));
    }

    public TBJS_vmTradeRecord GetChangeTradeRecordById(long userId, string rowid)
    {
      List<TBJS_vmTradeRecord> orders = (List<TBJS_vmTradeRecord>) null;
      if (this.changeTradeRecords.TryGetValue(userId, out orders))
        return this.GetChangeTradeRecordById(rowid, orders);
      return (TBJS_vmTradeRecord) null;
    }

    public Dictionary<string, double> CalculateDiffInAmt(long userId, List<TBJS_TradeRecord> orders)
    {
        Func<TBJS_vmTradeRecord, string> func = null;
        List<TBJS_vmTradeRecord> changeTradeRecordsByUserId = this.GetChangeTradeRecordsByUserId(userId);
        if (changeTradeRecordsByUserId == null)
        {
            return null;
        }
        var list = orders.Where<TBJS_TradeRecord>((TBJS_TradeRecord o) =>
        {
            List<TBJS_vmTradeRecord> tBJSVmTradeRecords = changeTradeRecordsByUserId;
            if (func == null)
            {
                func = (TBJS_vmTradeRecord f) => f.rowid;
            }
            return !tBJSVmTradeRecords.Select<TBJS_vmTradeRecord, string>(func).Contains<string>(o.rowid);
        }).Select((TBJS_TradeRecord o) => new { inamt = o.in_amount, outamt = o.out_amount }).ToList();
        var collection = (
            from c in changeTradeRecordsByUserId
            where !c.IsHide
            select new { inamt = c.in_amount, outamt = c.out_amount }).ToList();
        double num = list.Sum((s) => s.inamt) + collection.Sum((s) => s.inamt);
        double num1 = list.Sum((s) => s.outamt) + collection.Sum((s) => s.outamt);
        return new Dictionary<string, double>()
			{
				{ "inamt", num },
				{ "outamt", num1 }
			};
    }

    public string ResolveHtmlToRecordItems(TBJS_UserInfo user, string HtmlText, bool AlipayRecalculate = true)
    {
      List<TBJS_TradeRecord> orders = this.GetTradeRecordsByUserId(user.userid);
      if (orders == null)
      {
        orders = new List<TBJS_TradeRecord>();
        this.tradeRecords.Add(user.userid, orders);
      }
      try
      {
        HtmlDocument htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(HtmlText);
        int PageHiddenCount = 0;
        int num1 = 0;
        foreach (HtmlNode row in (IEnumerable<HtmlNode>) htmlDocument.DocumentNode.SelectNodes("//table[@id='tradeRecords']/tbody/tr"))
        {
          HtmlNodeCollection cells = row.SelectNodes("td");
          string str1 = cells[0].InnerText.Trim();
          string str2 = cells[1].InnerText.Trim();
          string rowid = string.Format("{0}-{1}", (object) str1, (object) Convert.ToDateTime(str2).ToString("yyyyMMddhhmmss"));
          ++num1;
          if (this.GetTradeRecordById(rowid, orders) == null)
          {
            string str3 = cells[3].InnerText.Trim().Replace("&nbsp;", "").Replace("- ", "-");
            string str4 = cells[4].InnerText.Trim().Replace("&nbsp;", "").Replace("- ", "-");
            string str5 = cells[5].InnerText.Trim().Replace("&nbsp;", "").Replace("- ", "-");
            TBJS_TradeRecord tbjsTradeRecord = new TBJS_TradeRecord()
            {
              rowid = rowid,
              number = str1,
              date = cells[1].InnerText.Trim(),
              in_amount = str3.Equals("") ? 0.0 : Convert.ToDouble(str3),
              out_amount = str4.Equals("") ? 0.0 : Convert.ToDouble(str4),
              balance = str5.Equals("") ? 0.0 : Convert.ToDouble(str5),
              from = cells[6].InnerText.Trim()
            };
            HtmlNodeCollection htmlNodeCollection = cells[2].SelectNodes("./ul/li");
            if (htmlNodeCollection != null && Enumerable.Count<HtmlNode>((IEnumerable<HtmlNode>) htmlNodeCollection) > 0)
            {
              HtmlNode node = HtmlNode.CreateNode(htmlNodeCollection[0].InnerHtml);
              tbjsTradeRecord.name = node.InnerText.Trim();
              if (Enumerable.Count<HtmlNode>((IEnumerable<HtmlNode>) htmlNodeCollection) > 1)
                tbjsTradeRecord.memo = htmlNodeCollection[1].InnerText.Trim();
            }
            orders.Add(tbjsTradeRecord);
          }
          else
            this.UpdateRecordItems(user, rowid, row, cells, ref PageHiddenCount);
        }
        htmlDocument.DocumentNode.SelectSingleNode("//span[@class='page-link']").InnerHtml = string.Format("{0} - {1} 条，共{2} 条", (object) 1, (object) (num1 - PageHiddenCount), (object) (num1 - PageHiddenCount));
        if (AlipayRecalculate)
        {
          Dictionary<string, double> dictionary = this.CalculateDiffInAmt(user.userid, orders);
          if (dictionary != null)
          {
            HtmlNodeCollection htmlNodeCollection1 = htmlDocument.DocumentNode.SelectSingleNode("//div[@id='main']").SelectNodes("//span[@class='fn-zoom fn-ml15']/span[@class='ft-green']");
            HtmlNodeCollection htmlNodeCollection2 = htmlDocument.DocumentNode.SelectSingleNode("//div[@id='main']").SelectNodes("//span[@class='fn-zoom fn-ml18']/span[@class='ft-orange']");
            double num2 = dictionary["inamt"];
            double num3 = dictionary["outamt"];
            foreach (HtmlNode htmlNode in (IEnumerable<HtmlNode>) htmlNodeCollection1)
              htmlNode.InnerHtml = num2.ToString();
            foreach (HtmlNode htmlNode in (IEnumerable<HtmlNode>) htmlNodeCollection2)
              htmlNode.InnerHtml = Math.Abs(num3).ToString();
          }
        }
        return htmlDocument.DocumentNode.InnerHtml;
      }
      catch (Exception ex)
      {
        return HtmlText;
      }
    }

    private void UpdateRecordItems(TBJS_UserInfo user, string rowid, HtmlNode row, HtmlNodeCollection cells, ref int PageHiddenCount)
    {
      try
      {
        TBJS_vmTradeRecord changeTradeRecordById = this.GetChangeTradeRecordById(user.userid, rowid);
        if (changeTradeRecordById == null)
          return;
        if (changeTradeRecordById.IsHide)
        {
          ++PageHiddenCount;
          row.Remove();
        }
        else
        {
          cells[1].InnerHtml = changeTradeRecordById.date;
          cells[3].InnerHtml = changeTradeRecordById.in_amount >= 0.0 ? (changeTradeRecordById.in_amount != 0.0 ? changeTradeRecordById.in_amount.ToString() : "&nbsp;") : changeTradeRecordById.in_amount.ToString().Replace("-", "- ");
          cells[4].InnerHtml = changeTradeRecordById.out_amount >= 0.0 ? (changeTradeRecordById.out_amount != 0.0 ? changeTradeRecordById.out_amount.ToString() : "&nbsp;") : changeTradeRecordById.out_amount.ToString().Replace("-", "- ");
          HtmlNode htmlNode = cells[2].SelectSingleNode("./ul");
          if (htmlNode == null)
            return;
          List<HtmlNode> list = Enumerable.ToList<HtmlNode>(htmlNode.Descendants("li"));
          if (Enumerable.Count<HtmlNode>((IEnumerable<HtmlNode>) list) > 0)
            list[0].ChildNodes[0].InnerHtml = changeTradeRecordById.name;
          if (changeTradeRecordById.IsClearMemo)
          {
            if (Enumerable.Count<HtmlNode>((IEnumerable<HtmlNode>) list) <= 1)
              return;
            htmlNode.RemoveChild(list[1]);
          }
          else if (changeTradeRecordById.memo.Equals("") && Enumerable.Count<HtmlNode>((IEnumerable<HtmlNode>) list) > 1)
            htmlNode.RemoveChild(list[1]);
          else if (Enumerable.Count<HtmlNode>((IEnumerable<HtmlNode>) list) > 1)
          {
            list[1].ChildNodes[0].InnerHtml = changeTradeRecordById.memo;
          }
          else
          {
            HtmlNode node = HtmlNode.CreateNode("<li class=\"name-no\"><span class=\"ft-gray\">" + changeTradeRecordById.memo + "</span></li>");
            htmlNode.AppendChild(node);
          }
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public void OneKeyAllHide(long userId)
    {
      List<TBJS_TradeRecord> tradeRecordsByUserId = this.GetTradeRecordsByUserId(userId);
      List<TBJS_vmTradeRecord> orders = this.GetChangeTradeRecordsByUserId(userId);
      if (orders == null)
      {
        orders = new List<TBJS_vmTradeRecord>();
        this.changeTradeRecords.Add(userId, orders);
      }
      foreach (TBJS_TradeRecord tbjsTradeRecord in tradeRecordsByUserId)
      {
        TBJS_vmTradeRecord changeTradeRecordById = this.GetChangeTradeRecordById(tbjsTradeRecord.rowid, orders);
        if (changeTradeRecordById != null)
        {
          changeTradeRecordById.IsHide = true;
          changeTradeRecordById.StatusText = changeTradeRecordById.IsHide ? "删除" : "";
        }
        else
        {
          TBJS_vmTradeRecord tbjsVmTradeRecord = new TBJS_vmTradeRecord()
          {
            rowid = tbjsTradeRecord.rowid,
            number = tbjsTradeRecord.number,
            date = tbjsTradeRecord.date,
            name = tbjsTradeRecord.name,
            memo = tbjsTradeRecord.memo,
            in_amount = tbjsTradeRecord.in_amount,
            out_amount = tbjsTradeRecord.out_amount,
            balance = tbjsTradeRecord.balance,
            from = tbjsTradeRecord.from,
            userId = userId,
            IsHide = true,
            StatusText = "删除"
          };
          orders.Add(tbjsVmTradeRecord);
        }
      }
    }
  }
}
