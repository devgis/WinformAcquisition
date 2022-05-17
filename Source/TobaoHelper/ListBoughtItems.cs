
// Type: TobaoHelper.ListBoughtItems
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using DotNet4.Utilities;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;

namespace TobaoHelper
{
  public class ListBoughtItems
  {
    private Dictionary<long, List<TBJS_MainOrder>> userMainOrders;
    private Dictionary<long, List<TBJS_vmMainOrder>> userChangeMainOrders;
    private Dictionary<long, List<TBJS_MainOrder>> userRecyledtems;
    private Dictionary<long, List<APJS_TradeRecord>> userLastMonthTradeRecords;

    public int IsRequestAllRecordItems { get; set; }

    public event ListBoughtItems.UpdateItemEventHandler UpdateItem;

    public ListBoughtItems()
    {
      this.IsRequestAllRecordItems = 0;
      this.userMainOrders = new Dictionary<long, List<TBJS_MainOrder>>();
      this.userRecyledtems = new Dictionary<long, List<TBJS_MainOrder>>();
      this.userChangeMainOrders = new Dictionary<long, List<TBJS_vmMainOrder>>();
      this.userLastMonthTradeRecords = new Dictionary<long, List<APJS_TradeRecord>>();
    }

    public void SerializeMainOrders(long userId)
    {
      if (userId == 0L)
        return;
      string path = string.Format("{0}Data\\{1}_orders.dat", (object) TBHelper.AppBaseDirectory, (object) userId);
      if (System.IO.File.Exists(path))
        System.IO.File.Delete(path);
      List<TBJS_vmMainOrder> changeListByUserId = this.GetChangeListByUserId(userId);
      if (changeListByUserId == null || Enumerable.Count<TBJS_vmMainOrder>((IEnumerable<TBJS_vmMainOrder>) changeListByUserId) == 0)
        return;
      FileStream fileStream = new FileStream(path, FileMode.Create);
      new BinaryFormatter().Serialize((Stream) fileStream, (object) changeListByUserId);
      fileStream.Close();
    }

    public void SerializeMainOrders(long userId, List<TBJS_vmMainOrder> changes)
    {
      if (userId == 0L)
        return;
      string path = string.Format("{0}Data\\{1}_orders.dat", (object) TBHelper.AppBaseDirectory, (object) userId);
      if (System.IO.File.Exists(path))
        System.IO.File.Delete(path);
      if (changes == null || Enumerable.Count<TBJS_vmMainOrder>((IEnumerable<TBJS_vmMainOrder>) changes) == 0)
        return;
      FileStream fileStream = new FileStream(path, FileMode.Create);
      new BinaryFormatter().Serialize((Stream) fileStream, (object) changes);
      fileStream.Close();
    }

    public void DeSerializeMainOrders(long userId)
    {
      string path = string.Format("{0}Data\\{1}_orders.dat", (object) TBHelper.AppBaseDirectory, (object) userId);
      if (!System.IO.File.Exists(path))
        return;
      FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
      try
      {
        List<TBJS_vmMainOrder> list = new BinaryFormatter().Deserialize((Stream) fileStream) as List<TBJS_vmMainOrder>;
        if (this.userChangeMainOrders.ContainsKey(userId))
          this.userChangeMainOrders.Remove(userId);
        this.userChangeMainOrders.Add(userId, list);
      }
      finally
      {
        fileStream.Close();
      }
    }

    public void ChangeLoginUser(long oldUserId, long newUserId)
    {
      this.SerializeMainOrders(oldUserId);
      this.DeSerializeMainOrders(newUserId);
    }

    public void SyncUserChangeData(long userId)
    {
      List<TBJS_vmMainOrder> changeListByUserId = this.GetChangeListByUserId(userId);
      if (changeListByUserId == null || Enumerable.Count<TBJS_vmMainOrder>((IEnumerable<TBJS_vmMainOrder>) changeListByUserId) == 0)
        return;
      List<TBJS_MainOrder> orders = this.GetOrdersByUserId(userId);
      if (orders == null)
        return;
      List<TBJS_vmMainOrder> changes = Enumerable.ToList<TBJS_vmMainOrder>(Enumerable.Where<TBJS_vmMainOrder>((IEnumerable<TBJS_vmMainOrder>) changeListByUserId, (Func<TBJS_vmMainOrder, bool>) (c => !Enumerable.Contains<long>(Enumerable.Select<TBJS_MainOrder, long>((IEnumerable<TBJS_MainOrder>) orders, (Func<TBJS_MainOrder, long>) (o => o.id)), c.id))));
      foreach (TBJS_vmMainOrder tbjsVmMainOrder in changes)
      {
        TBJS_MainOrder orderById = this.GetOrderById(tbjsVmMainOrder.id, orders);
        if (orderById != null && !orderById.extra.tradeStatus.Equals(tbjsVmMainOrder.tradeStatus))
        {
          if (!tbjsVmMainOrder.IsHide && tbjsVmMainOrder.createDay.Equals(orderById.orderInfo.createDay))
          {
            changes.Remove(tbjsVmMainOrder);
          }
          else
          {
            tbjsVmMainOrder.tradeStatus = orderById.extra.tradeStatus;
            tbjsVmMainOrder.tradeStatusText = orderById.statusInfo.text;
          }
        }
      }
      this.SerializeMainOrders(userId, changes);
    }

    public void ClearData()
    {
      this.userMainOrders.Clear();
      this.userRecyledtems.Clear();
    }

    public void ClearAllData()
    {
      this.userMainOrders.Clear();
      this.userRecyledtems.Clear();
      this.userChangeMainOrders.Clear();
    }

    public DataTable GetDataSource(long userId, DataTable dt)
    {
      List<TBJS_MainOrder> ordersByUserId = this.GetOrdersByUserId(userId);
      if (ordersByUserId == null)
        return dt;
      this.ConvertToDataTable(userId, dt, ordersByUserId);
      dt.DefaultView.Sort = "createTime desc";
      return dt;
    }

    public void ConvertToDataTable(long userId, DataTable dt, List<TBJS_MainOrder> orders)
    {
      lock (dt.Rows.SyncRoot)
      {
        try
        {
          foreach (TBJS_MainOrder item_0 in orders)
          {
            DataRow local_1 = dt.Rows.Find((object) item_0.id);
            if (local_1 == null)
            {
              DataRow local_1_1 = dt.NewRow();
              local_1_1["id"] = (object) item_0.id;
              local_1_1["createDay"] = (object) item_0.orderInfo.createDay;
              local_1_1["createTime"] = (object) item_0.orderInfo.createTime;
              local_1_1["tradeStatusText"] = (object) item_0.statusInfo.text;
              local_1_1["userid"] = (object) userId;
              local_1_1["tradeSubStatusText"] = TBHelper.IsRateOrder(item_0) ? (object) "待评价" : (object) item_0.statusInfo.text;
              dt.Rows.Add(local_1_1);
            }
            else
            {
              local_1["createDay"] = (object) item_0.orderInfo.createDay;
              local_1["createTime"] = (object) item_0.orderInfo.createDay;
              local_1["tradeStatusText"] = (object) item_0.statusInfo.text;
              local_1["tradeSubStatusText"] = TBHelper.IsRateOrder(item_0) ? (object) "待评价" : (object) item_0.statusInfo.text;
            }
          }
          List<TBJS_vmMainOrder> local_2 = this.GetChangeListByUserId(userId);
          if (local_2 != null)
          {
            foreach (TBJS_vmMainOrder item_1 in local_2)
            {
              DataRow local_4 = dt.Rows.Find((object) item_1.id);
              if (local_4 != null)
              {
                local_4["createDay"] = (object) item_1.createDay;
                local_4["tradeStatusText"] = (object) item_1.tradeStatusText;
                local_4["createDay"] = (object) item_1.createDay;
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

    public void UpdateCreateDay(long userId, long id, string createDay)
    {
      lock (this.userChangeMainOrders)
      {
        List<TBJS_vmMainOrder> local_0 = this.GetChangeListByUserId(userId);
        TBJS_MainOrder local_1 = this.GetOrderById(userId, id);
        if (local_0 == null)
        {
          local_0 = new List<TBJS_vmMainOrder>();
          this.userChangeMainOrders.Add(userId, local_0);
        }
        TBJS_vmMainOrder local_2 = this.GetChangeOrderById(local_1.id, local_0);
        if (local_2 == null)
          local_0.Add(new TBJS_vmMainOrder()
          {
            id = local_1.id,
            tradeStatus = local_1.extra.tradeStatus,
            createDay = createDay,
            createTime = Convert.ToDateTime(local_1.orderInfo.createTime),
            tradeStatusText = local_1.statusInfo.text,
            userid = userId,
            subOrderCount = TBHelper.GetSubOrderCount(local_1)
          });
        else
          local_2.createDay = createDay;
      }
    }

    public void UpdateTradeFinished(long userId, long id)
    {
      lock (this.userChangeMainOrders)
      {
        List<TBJS_vmMainOrder> local_0 = this.GetChangeListByUserId(userId);
        TBJS_MainOrder local_1 = this.GetOrderById(userId, id);
        if (local_0 == null)
        {
          local_0 = new List<TBJS_vmMainOrder>();
          this.userChangeMainOrders.Add(userId, local_0);
        }
        TBJS_vmMainOrder local_2 = this.GetChangeOrderById(local_1.id, local_0);
        if (local_2 == null)
          local_0.Add(new TBJS_vmMainOrder()
          {
            id = local_1.id,
            tradeStatus = local_1.extra.tradeStatus,
            createDay = local_1.orderInfo.createDay,
            createTime = Convert.ToDateTime(local_1.orderInfo.createTime),
            userid = userId,
            tradeStatusText = "交易成功",
            subOrderCount = TBHelper.GetSubOrderCount(local_1)
          });
        else
          local_2.tradeStatusText = "交易成功";
      }
    }

    public void UpdateIsHide(long userId, long id, bool isHide)
    {
      lock (this.userChangeMainOrders)
      {
        List<TBJS_vmMainOrder> local_0 = this.GetChangeListByUserId(userId);
        TBJS_MainOrder local_1 = this.GetOrderById(userId, id);
        if (local_0 == null)
        {
          local_0 = new List<TBJS_vmMainOrder>();
          this.userChangeMainOrders.Add(userId, local_0);
        }
        TBJS_vmMainOrder local_2 = this.GetChangeOrderById(local_1.id, local_0);
        if (local_2 == null)
        {
          local_0.Add(new TBJS_vmMainOrder()
          {
            id = local_1.id,
            tradeStatus = local_1.extra.tradeStatus,
            createDay = local_1.orderInfo.createDay,
            createTime = Convert.ToDateTime(local_1.orderInfo.createTime),
            userid = userId,
            subOrderCount = TBHelper.GetSubOrderCount(local_1),
            IsHide = isHide,
            tradeStatusText = "隐藏"
          });
        }
        else
        {
          local_2.IsHide = isHide;
          local_2.tradeStatusText = "隐藏";
        }
      }
    }

    public void UpdateCancel(long userId, long id)
    {
      lock (this.userChangeMainOrders)
      {
        List<TBJS_vmMainOrder> local_0 = this.GetChangeListByUserId(userId);
        if (local_0 == null)
          return;
        TBJS_vmMainOrder local_1 = this.GetChangeOrderById(userId, id);
        if (local_1 == null)
          return;
        local_0.Remove(local_1);
      }
    }

    public bool HasChange(long userId, long id)
    {
      return this.GetChangeOrderById(userId, id) != null;
    }

    public List<TBJS_MainOrder> GetOrdersByUserId(long userId)
    {
      List<TBJS_MainOrder> list = (List<TBJS_MainOrder>) null;
      if (this.userMainOrders.TryGetValue(userId, out list))
        return list;
      return (List<TBJS_MainOrder>) null;
    }

    public TBJS_MainOrder GetOrderById(long userId, long orderId)
    {
      if (this.userMainOrders.ContainsKey(userId))
        return this.userMainOrders[userId].Find((Predicate<TBJS_MainOrder>) (o => o.id == orderId));
      return (TBJS_MainOrder) null;
    }

    public TBJS_MainOrder GetOrderById(long id, List<TBJS_MainOrder> orders)
    {
      return orders.Find((Predicate<TBJS_MainOrder>) (o => o.id == id));
    }

    public TBJS_vmMainOrder GetChangeOrderById(long userId, long orderId)
    {
      if (this.userChangeMainOrders.ContainsKey(userId))
        return this.userChangeMainOrders[userId].Find((Predicate<TBJS_vmMainOrder>) (o => o.id == orderId));
      return (TBJS_vmMainOrder) null;
    }

    public TBJS_vmMainOrder GetChangeOrderById(long id, List<TBJS_vmMainOrder> orders)
    {
      return orders.Find((Predicate<TBJS_vmMainOrder>) (o => o.id == id));
    }

    public List<TBJS_vmMainOrder> GetChangeListByUserId(long userId)
    {
      List<TBJS_vmMainOrder> list = (List<TBJS_vmMainOrder>) null;
      if (this.userChangeMainOrders.TryGetValue(userId, out list))
        return list;
      return (List<TBJS_vmMainOrder>) null;
    }

    public void ActionDeleteOrder(TBJS_UserInfo user, long id)
    {
      List<TBJS_MainOrder> ordersByUserId = this.GetOrdersByUserId(user.userid);
      List<TBJS_MainOrder> recyledItemsByUserId = this.GetRecyledItemsByUserId(user.userid);
      if (ordersByUserId == null)
        return;
      TBJS_MainOrder orderById = this.GetOrderById(id, ordersByUserId);
      if (orderById == null)
        return;
      lock (ordersByUserId)
        ordersByUserId.Remove(orderById);
      if (recyledItemsByUserId != null)
      {
        lock (recyledItemsByUserId)
          recyledItemsByUserId.Add(orderById);
      }
      List<TBJS_vmMainOrder> changeListByUserId = this.GetChangeListByUserId(user.userid);
      if (changeListByUserId == null)
        return;
      TBJS_vmMainOrder changeOrderById = this.GetChangeOrderById(id, changeListByUserId);
      if (changeOrderById == null)
        return;
      lock (changeListByUserId)
        changeListByUserId.Remove(changeOrderById);
    }

    private void UpdateChangeOrders(TBJS_UserInfo user, List<TBJS_MainOrder> orders)
    {
      List<TBJS_vmMainOrder> changeListByUserId = this.GetChangeListByUserId(user.userid);
      if (changeListByUserId == null)
        return;
      foreach (TBJS_vmMainOrder tbjsVmMainOrder in changeListByUserId)
      {
        TBJS_MainOrder orderById = this.GetOrderById(tbjsVmMainOrder.id, orders);
        if (orderById != null && !orderById.extra.tradeStatus.Equals(tbjsVmMainOrder.tradeStatus))
        {
          if (!tbjsVmMainOrder.IsHide && tbjsVmMainOrder.createDay.Equals(orderById.orderInfo.createDay))
          {
            changeListByUserId.Remove(tbjsVmMainOrder);
          }
          else
          {
            tbjsVmMainOrder.tradeStatus = orderById.extra.tradeStatus;
            tbjsVmMainOrder.tradeStatusText = orderById.statusInfo.text;
          }
        }
      }
    }

    public void UpdateMainOrdersTabs(ref int? waitPay, ref int? waitSend, ref int? waitConfirm, ref int? waitRate, List<TBJS_MainOrder> orders)
    {
      if (orders == null || Enumerable.Count<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) orders) == 0)
      {
        waitPay = new int?(0);
        waitSend = new int?(0);
        waitConfirm = new int?(0);
        waitRate = new int?(0);
      }
      else
      {
        if (orders == null || Enumerable.Count<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) orders) == 0)
          return;
        waitPay = new int?(Enumerable.Count<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) orders.FindAll((Predicate<TBJS_MainOrder>) (o => o.extra.tradeStatus.Equals("WAIT_BUYER_PAY")))));
        waitSend = new int?(Enumerable.Count<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) orders.FindAll((Predicate<TBJS_MainOrder>) (o => o.extra.tradeStatus.Equals("WAIT_SELLER_SEND_GOODS")))));
        waitConfirm = new int?(Enumerable.Count<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) orders.FindAll((Predicate<TBJS_MainOrder>) (o => o.extra.tradeStatus.Equals("WAIT_BUYER_CONFIRM_GOODS")))));
        waitRate = new int?(Enumerable.Count<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) orders.FindAll((Predicate<TBJS_MainOrder>) (o =>
        {
          if (o.extra.tradeStatus.Equals("TRADE_FINISHED"))
            return TBHelper.IsRateOrder(o);
          return false;
        }))));
      }
    }

    public void GetChangeMainOrdersTabs(ref int waitPay, ref int waitSend, ref int waitConfirm, ref int waitRate, List<TBJS_MainOrder> orders)
    {
      if (orders == null || Enumerable.Count<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) orders) == 0)
      {
        waitPay = 0;
        waitSend = 0;
        waitConfirm = 0;
        waitRate = 0;
      }
      else
      {
        waitPay = Enumerable.Count<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) orders.FindAll((Predicate<TBJS_MainOrder>) (o => o.extra.tradeStatus.Equals("WAIT_BUYER_PAY"))));
        waitSend = Enumerable.Count<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) orders.FindAll((Predicate<TBJS_MainOrder>) (o => o.extra.tradeStatus.Equals("WAIT_SELLER_SEND_GOODS"))));
        waitConfirm = Enumerable.Count<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) orders.FindAll((Predicate<TBJS_MainOrder>) (o => o.extra.tradeStatus.Equals("WAIT_BUYER_CONFIRM_GOODS"))));
        waitRate = Enumerable.Count<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) orders.FindAll((Predicate<TBJS_MainOrder>) (o =>
        {
          if (o.extra.tradeStatus.Equals("TRADE_FINISHED"))
            return TBHelper.IsRateOrder(o);
          return false;
        })));
      }
    }

    public void UpdatChangeMainOrdersTabs(ref int? waitPay, ref int? waitSend, ref int? waitConfirm, ref int? waitRate, List<TBJS_MainOrder> orders, List<TBJS_vmMainOrder> changes)
    {
        if (changes == null || changes.Count<TBJS_vmMainOrder>() == 0)
        {
            return;
        }
        List<TBJS_MainOrder> list = (from o in orders
                                     join c in changes on o.id equals c.id
                                     where !c.IsHide && ((!c.tradeStatusText.Equals(o.statusInfo.text) && c.tradeStatusText.Equals("交易成功")) || TBHelper.IsRateOrder(o))
                                     select o).ToList<TBJS_MainOrder>();
        if (list.Count<TBJS_MainOrder>() == 0)
        {
            return;
        }
        int? num = new int?(0);
        int? num2 = new int?(0);
        int? num3 = new int?(0);
        int? num4 = new int?(0);
        this.UpdateMainOrdersTabs(ref num, ref num2, ref num3, ref num4, list);
        waitPay = ((num > 0) ? (waitPay - num) : waitPay);
        waitSend = ((num2 > 0) ? (waitSend - num2) : waitSend);
        waitConfirm = ((num3 > 0) ? (waitConfirm - num3) : waitConfirm);
        waitRate = ((num4 > 0) ? (waitRate - num4) : waitRate);
    }

    public void UpdateMainOrdersTabs(TBJS_Tab waitPay, TBJS_Tab waitSend, TBJS_Tab waitConfirm, TBJS_Tab waitRate, List<TBJS_MainOrder> orders)
    {
      if (orders == null || Enumerable.Count<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) orders) == 0)
      {
        waitPay.count = new int?();
        waitSend.count = new int?();
        waitConfirm.count = new int?();
        waitRate.count = new int?();
      }
      else
      {
        int? waitPay1 = new int?(0);
        int? waitSend1 = new int?(0);
        int? waitConfirm1 = new int?(0);
        int? waitRate1 = new int?(0);
        this.UpdateMainOrdersTabs(ref waitPay1, ref waitSend1, ref waitConfirm1, ref waitRate1, orders);
        TBJS_Tab tbjsTab1 = waitPay;
        int? nullable1 = waitPay1;
        int? nullable2 = (nullable1.GetValueOrDefault() <= 0 ? 0 : (nullable1.HasValue ? 1 : 0)) != 0 ? waitPay1 : new int?();
        tbjsTab1.count = nullable2;
        TBJS_Tab tbjsTab2 = waitSend;
        int? nullable3 = waitSend1;
        int? nullable4 = (nullable3.GetValueOrDefault() <= 0 ? 0 : (nullable3.HasValue ? 1 : 0)) != 0 ? waitSend1 : new int?();
        tbjsTab2.count = nullable4;
        TBJS_Tab tbjsTab3 = waitConfirm;
        int? nullable5 = waitConfirm1;
        int? nullable6 = (nullable5.GetValueOrDefault() <= 0 ? 0 : (nullable5.HasValue ? 1 : 0)) != 0 ? waitConfirm1 : new int?();
        tbjsTab3.count = nullable6;
        TBJS_Tab tbjsTab4 = waitRate;
        int? nullable7 = waitRate1;
        int? nullable8 = (nullable7.GetValueOrDefault() <= 0 ? 0 : (nullable7.HasValue ? 1 : 0)) != 0 ? waitRate1 : new int?();
        tbjsTab4.count = nullable8;
      }
    }

    public void UpdateMainOrdersTabs2(TBJS_Tab waitPay, TBJS_Tab waitSend, TBJS_Tab waitConfirm, TBJS_Tab waitRate, List<TBJS_MainOrder> orders)
    {
      if (orders == null || Enumerable.Count<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) orders) == 0)
      {
        waitPay.count = new int?();
        waitSend.count = new int?();
        waitConfirm.count = new int?();
        waitRate.count = new int?();
      }
      else
      {
        int? waitPay1 = new int?(0);
        int? waitSend1 = new int?(0);
        int? waitConfirm1 = new int?(0);
        int? waitRate1 = new int?(0);
        this.UpdateMainOrdersTabs(ref waitPay1, ref waitSend1, ref waitConfirm1, ref waitRate1, orders);
        int? nullable1 = waitPay1;
        if ((nullable1.GetValueOrDefault() <= 0 ? 0 : (nullable1.HasValue ? 1 : 0)) != 0)
        {
          TBJS_Tab tbjsTab = waitPay;
          int? count = waitPay.count;
          int? nullable2 = waitPay1;
          int? nullable3 = count.HasValue & nullable2.HasValue ? new int?(count.GetValueOrDefault() - nullable2.GetValueOrDefault()) : new int?();
          tbjsTab.count = nullable3;
        }
        int? nullable4 = waitSend1;
        if ((nullable4.GetValueOrDefault() <= 0 ? 0 : (nullable4.HasValue ? 1 : 0)) != 0)
        {
          TBJS_Tab tbjsTab = waitSend;
          int? count = waitSend.count;
          int? nullable2 = waitSend1;
          int? nullable3 = count.HasValue & nullable2.HasValue ? new int?(count.GetValueOrDefault() - nullable2.GetValueOrDefault()) : new int?();
          tbjsTab.count = nullable3;
        }
        int? nullable5 = waitConfirm1;
        if ((nullable5.GetValueOrDefault() <= 0 ? 0 : (nullable5.HasValue ? 1 : 0)) != 0)
        {
          TBJS_Tab tbjsTab = waitConfirm;
          int? count = waitConfirm.count;
          int? nullable2 = waitConfirm1;
          int? nullable3 = count.HasValue & nullable2.HasValue ? new int?(count.GetValueOrDefault() - nullable2.GetValueOrDefault()) : new int?();
          tbjsTab.count = nullable3;
        }
        int? nullable6 = waitRate1;
        if ((nullable6.GetValueOrDefault() <= 0 ? 0 : (nullable6.HasValue ? 1 : 0)) != 0)
        {
          TBJS_Tab tbjsTab = waitRate;
          int? count = waitRate.count;
          int? nullable2 = waitRate1;
          int? nullable3 = count.HasValue & nullable2.HasValue ? new int?(count.GetValueOrDefault() - nullable2.GetValueOrDefault()) : new int?();
          tbjsTab.count = nullable3;
        }
        TBJS_Tab tbjsTab1 = waitPay;
        int? nullable7;
        if (waitPay.count.HasValue)
        {
          int? count = waitPay.count;
          if ((count.GetValueOrDefault() <= 0 ? 0 : (count.HasValue ? 1 : 0)) != 0)
          {
            nullable7 = waitPay.count;
            goto label_14;
          }
        }
        nullable7 = new int?();
label_14:
        tbjsTab1.count = nullable7;
        TBJS_Tab tbjsTab2 = waitSend;
        int? nullable8;
        if (waitSend.count.HasValue)
        {
          int? count = waitSend.count;
          if ((count.GetValueOrDefault() <= 0 ? 0 : (count.HasValue ? 1 : 0)) != 0)
          {
            nullable8 = waitSend.count;
            goto label_18;
          }
        }
        nullable8 = new int?();
label_18:
        tbjsTab2.count = nullable8;
        TBJS_Tab tbjsTab3 = waitConfirm;
        int? nullable9;
        if (waitConfirm.count.HasValue)
        {
          int? count = waitConfirm.count;
          if ((count.GetValueOrDefault() <= 0 ? 0 : (count.HasValue ? 1 : 0)) != 0)
          {
            nullable9 = waitConfirm.count;
            goto label_22;
          }
        }
        nullable9 = new int?();
label_22:
        tbjsTab3.count = nullable9;
        TBJS_Tab tbjsTab4 = waitRate;
        int? nullable10;
        if (waitRate.count.HasValue)
        {
          int? count = waitRate.count;
          if ((count.GetValueOrDefault() <= 0 ? 0 : (count.HasValue ? 1 : 0)) != 0)
          {
            nullable10 = waitRate.count;
            goto label_26;
          }
        }
        nullable10 = new int?();
label_26:
        tbjsTab4.count = nullable10;
      }
    }

    public void UpdatChangeMainOrdersTabs(TBJS_Tab waitPay, TBJS_Tab waitSend, TBJS_Tab waitConfirm, TBJS_Tab waitRate, List<TBJS_MainOrder> orders)
    {
      int? waitPay1 = new int?(0);
      int? waitSend1 = new int?(0);
      int? waitConfirm1 = new int?(0);
      int? waitRate1 = new int?(0);
      this.UpdateMainOrdersTabs(ref waitPay1, ref waitSend1, ref waitConfirm1, ref waitRate1, orders);
      TBJS_Tab tbjsTab1 = waitPay;
      int? nullable1;
      if (waitPay.count.HasValue)
      {
        int? nullable2 = waitPay1;
        if ((nullable2.GetValueOrDefault() <= 0 ? 0 : (nullable2.HasValue ? 1 : 0)) != 0)
        {
          int? count = waitPay.count;
          int? nullable3 = waitPay1;
          nullable1 = count.HasValue & nullable3.HasValue ? new int?(count.GetValueOrDefault() - nullable3.GetValueOrDefault()) : new int?();
          goto label_4;
        }
      }
      nullable1 = waitPay.count;
label_4:
      tbjsTab1.count = nullable1;
      TBJS_Tab tbjsTab2 = waitSend;
      int? nullable4;
      if (waitSend.count.HasValue)
      {
        int? nullable2 = waitSend1;
        if ((nullable2.GetValueOrDefault() <= 0 ? 0 : (nullable2.HasValue ? 1 : 0)) != 0)
        {
          int? count = waitSend.count;
          int? nullable3 = waitSend1;
          nullable4 = count.HasValue & nullable3.HasValue ? new int?(count.GetValueOrDefault() - nullable3.GetValueOrDefault()) : new int?();
          goto label_8;
        }
      }
      nullable4 = waitSend.count;
label_8:
      tbjsTab2.count = nullable4;
      TBJS_Tab tbjsTab3 = waitConfirm;
      int? nullable5;
      if (waitConfirm.count.HasValue)
      {
        int? nullable2 = waitConfirm1;
        if ((nullable2.GetValueOrDefault() <= 0 ? 0 : (nullable2.HasValue ? 1 : 0)) != 0)
        {
          int? count = waitConfirm.count;
          int? nullable3 = waitConfirm1;
          nullable5 = count.HasValue & nullable3.HasValue ? new int?(count.GetValueOrDefault() - nullable3.GetValueOrDefault()) : new int?();
          goto label_12;
        }
      }
      nullable5 = waitConfirm.count;
label_12:
      tbjsTab3.count = nullable5;
      TBJS_Tab tbjsTab4 = waitRate;
      int? nullable6;
      if (waitRate.count.HasValue)
      {
        int? nullable2 = waitRate1;
        if ((nullable2.GetValueOrDefault() <= 0 ? 0 : (nullable2.HasValue ? 1 : 0)) != 0)
        {
          int? count = waitRate.count;
          int? nullable3 = waitRate1;
          nullable6 = count.HasValue & nullable3.HasValue ? new int?(count.GetValueOrDefault() - nullable3.GetValueOrDefault()) : new int?();
          goto label_16;
        }
      }
      nullable6 = waitRate.count;
label_16:
      tbjsTab4.count = nullable6;
      TBJS_Tab tbjsTab5 = waitPay;
      int? nullable7;
      if (waitPay.count.HasValue)
      {
        int? count = waitPay.count;
        if ((count.GetValueOrDefault() <= 0 ? 0 : (count.HasValue ? 1 : 0)) != 0)
        {
          nullable7 = waitPay.count;
          goto label_20;
        }
      }
      nullable7 = new int?();
label_20:
      tbjsTab5.count = nullable7;
      TBJS_Tab tbjsTab6 = waitSend;
      int? nullable8;
      if (waitSend.count.HasValue)
      {
        int? count = waitSend.count;
        if ((count.GetValueOrDefault() <= 0 ? 0 : (count.HasValue ? 1 : 0)) != 0)
        {
          nullable8 = waitSend.count;
          goto label_24;
        }
      }
      nullable8 = new int?();
label_24:
      tbjsTab6.count = nullable8;
      TBJS_Tab tbjsTab7 = waitConfirm;
      int? nullable9;
      if (waitConfirm.count.HasValue)
      {
        int? count = waitConfirm.count;
        if ((count.GetValueOrDefault() <= 0 ? 0 : (count.HasValue ? 1 : 0)) != 0)
        {
          nullable9 = waitConfirm.count;
          goto label_28;
        }
      }
      nullable9 = new int?();
label_28:
      tbjsTab7.count = nullable9;
      TBJS_Tab tbjsTab8 = waitRate;
      int? nullable10;
      if (waitRate.count.HasValue)
      {
        int? count = waitRate.count;
        if ((count.GetValueOrDefault() <= 0 ? 0 : (count.HasValue ? 1 : 0)) != 0)
        {
          nullable10 = waitRate.count;
          goto label_32;
        }
      }
      nullable10 = new int?();
label_32:
      tbjsTab8.count = nullable10;
    }

    public void UpdatChangeMainOrdersTabs(TBJS_Tab waitPay, TBJS_Tab waitSend, TBJS_Tab waitConfirm, TBJS_Tab waitRate, List<TBJS_MainOrder> orders, List<TBJS_vmMainOrder> changes)
    {
      if (changes == null || Enumerable.Count<TBJS_vmMainOrder>((IEnumerable<TBJS_vmMainOrder>) changes) == 0)
        return;
      List<TBJS_MainOrder> orders1 = Enumerable.ToList<TBJS_MainOrder>(Enumerable.Select(Enumerable.Where(Enumerable.Join((IEnumerable<TBJS_MainOrder>) orders, (IEnumerable<TBJS_vmMainOrder>) changes, (Func<TBJS_MainOrder, long>) (o => o.id), (Func<TBJS_vmMainOrder, long>) (c => c.id), (o, c) => new
      {
        o = o,
        c = c
      }), param0 =>
      {
        if (param0.c.IsHide)
          return false;
        if (param0.c.tradeStatusText.Equals(param0.o.statusInfo.text) || !param0.c.tradeStatusText.Equals("交易成功"))
          return TBHelper.IsRateOrder(param0.o);
        return true;
      }), param0 => param0.o));
      if (Enumerable.Count<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) orders1) == 0)
        return;
      int? waitPay1 = new int?(0);
      int? waitSend1 = new int?(0);
      int? waitConfirm1 = new int?(0);
      int? waitRate1 = new int?(0);
      this.UpdateMainOrdersTabs(ref waitPay1, ref waitSend1, ref waitConfirm1, ref waitRate1, orders1);
      TBJS_Tab tbjsTab1 = waitPay;
      int? nullable1;
      if (waitPay.count.HasValue)
      {
        int? nullable2 = waitPay1;
        if ((nullable2.GetValueOrDefault() <= 0 ? 0 : (nullable2.HasValue ? 1 : 0)) != 0)
        {
          int? count = waitPay.count;
          int? nullable3 = waitPay1;
          nullable1 = count.HasValue & nullable3.HasValue ? new int?(count.GetValueOrDefault() - nullable3.GetValueOrDefault()) : new int?();
          goto label_7;
        }
      }
      nullable1 = waitPay.count;
label_7:
      tbjsTab1.count = nullable1;
      TBJS_Tab tbjsTab2 = waitSend;
      int? nullable4;
      if (waitSend.count.HasValue)
      {
        int? nullable2 = waitSend1;
        if ((nullable2.GetValueOrDefault() <= 0 ? 0 : (nullable2.HasValue ? 1 : 0)) != 0)
        {
          int? count = waitSend.count;
          int? nullable3 = waitSend1;
          nullable4 = count.HasValue & nullable3.HasValue ? new int?(count.GetValueOrDefault() - nullable3.GetValueOrDefault()) : new int?();
          goto label_11;
        }
      }
      nullable4 = waitSend.count;
label_11:
      tbjsTab2.count = nullable4;
      TBJS_Tab tbjsTab3 = waitConfirm;
      int? nullable5;
      if (waitConfirm.count.HasValue)
      {
        int? nullable2 = waitConfirm1;
        if ((nullable2.GetValueOrDefault() <= 0 ? 0 : (nullable2.HasValue ? 1 : 0)) != 0)
        {
          int? count = waitConfirm.count;
          int? nullable3 = waitConfirm1;
          nullable5 = count.HasValue & nullable3.HasValue ? new int?(count.GetValueOrDefault() - nullable3.GetValueOrDefault()) : new int?();
          goto label_15;
        }
      }
      nullable5 = waitConfirm.count;
label_15:
      tbjsTab3.count = nullable5;
      TBJS_Tab tbjsTab4 = waitRate;
      int? nullable6;
      if (waitRate.count.HasValue)
      {
        int? nullable2 = waitRate1;
        if ((nullable2.GetValueOrDefault() <= 0 ? 0 : (nullable2.HasValue ? 1 : 0)) != 0)
        {
          int? count = waitRate.count;
          int? nullable3 = waitRate1;
          nullable6 = count.HasValue & nullable3.HasValue ? new int?(count.GetValueOrDefault() - nullable3.GetValueOrDefault()) : new int?();
          goto label_19;
        }
      }
      nullable6 = waitRate.count;
label_19:
      tbjsTab4.count = nullable6;
      TBJS_Tab tbjsTab5 = waitPay;
      int? nullable7;
      if (waitPay.count.HasValue)
      {
        int? count = waitPay.count;
        if ((count.GetValueOrDefault() <= 0 ? 0 : (count.HasValue ? 1 : 0)) != 0)
        {
          nullable7 = waitPay.count;
          goto label_23;
        }
      }
      nullable7 = new int?();
label_23:
      tbjsTab5.count = nullable7;
      TBJS_Tab tbjsTab6 = waitSend;
      int? nullable8;
      if (waitSend.count.HasValue)
      {
        int? count = waitSend.count;
        if ((count.GetValueOrDefault() <= 0 ? 0 : (count.HasValue ? 1 : 0)) != 0)
        {
          nullable8 = waitSend.count;
          goto label_27;
        }
      }
      nullable8 = new int?();
label_27:
      tbjsTab6.count = nullable8;
      TBJS_Tab tbjsTab7 = waitConfirm;
      int? nullable9;
      if (waitConfirm.count.HasValue)
      {
        int? count = waitConfirm.count;
        if ((count.GetValueOrDefault() <= 0 ? 0 : (count.HasValue ? 1 : 0)) != 0)
        {
          nullable9 = waitConfirm.count;
          goto label_31;
        }
      }
      nullable9 = new int?();
label_31:
      tbjsTab7.count = nullable9;
      TBJS_Tab tbjsTab8 = waitRate;
      int? nullable10;
      if (waitRate.count.HasValue)
      {
        int? count = waitRate.count;
        if ((count.GetValueOrDefault() <= 0 ? 0 : (count.HasValue ? 1 : 0)) != 0)
        {
          nullable10 = waitRate.count;
          goto label_35;
        }
      }
      nullable10 = new int?();
label_35:
      tbjsTab8.count = nullable10;
    }

    private int? UpdateJsonDataTabs(TBJS_Tab tab, string tabCode1, string tabCode2, int totalNumber)
    {
      if (tabCode1.Equals(tabCode2))
      {
        tab.count = totalNumber > 0 ? new int?(totalNumber) : new int?();
        return new int?(totalNumber);
      }
      int? nullable1 = new int?(0);
      if (tab.count.HasValue)
      {
        int? count = tab.count;
        if ((count.GetValueOrDefault() <= 0 ? 0 : (count.HasValue ? 1 : 0)) != 0)
          nullable1 = new int?(this.GetBoughtQueryActionWithTabCode(tabCode2, TBHelper.TBCookie));
      }
      TBJS_Tab tbjsTab = tab;
      int? nullable2 = nullable1;
      int? nullable3 = (nullable2.GetValueOrDefault() <= 0 ? 0 : (nullable2.HasValue ? 1 : 0)) != 0 ? nullable1 : new int?();
      tbjsTab.count = nullable3;
      return nullable1;
    }

    private int? UpdateJsonDataTabs(TBJS_Tab tab, string tabCode, int totalNumber)
    {
      int? nullable1 = new int?(0);
      if (tab.count.HasValue)
      {
        int? count = tab.count;
        if ((count.GetValueOrDefault() <= 0 ? 0 : (count.HasValue ? 1 : 0)) != 0)
          nullable1 = new int?(this.GetBoughtQueryActionWithTabCode(tabCode, TBHelper.TBCookie));
      }
      TBJS_Tab tbjsTab = tab;
      int? nullable2 = nullable1;
      int? nullable3 = (nullable2.GetValueOrDefault() <= 0 ? 0 : (nullable2.HasValue ? 1 : 0)) != 0 ? nullable1 : new int?();
      tbjsTab.count = nullable3;
      return nullable1;
    }

    private void UpdateMainOrders(TBJS_UserInfo user, TBJS_Data jsonData, string tabCode = "")
    {
      List<TBJS_Tab> tabs = Enumerable.ToList<TBJS_Tab>((IEnumerable<TBJS_Tab>) jsonData.tabs);
      TBJS_Tab tabByCode1 = TBHelper.GetTabByCode("waitPay", tabs);
      TBJS_Tab tabByCode2 = TBHelper.GetTabByCode("waitSend", tabs);
      TBJS_Tab tabByCode3 = TBHelper.GetTabByCode("waitConfirm", tabs);
      TBJS_Tab tabByCode4 = TBHelper.GetTabByCode("waitRate", tabs);
      List<TBJS_MainOrder> ordersByUserId = this.GetOrdersByUserId(user.userid);
      List<TBJS_MainOrder> recyledItemsByUserId = this.GetRecyledItemsByUserId(user.userid);
      List<TBJS_vmMainOrder> changes = this.GetChangeListByUserId(user.userid);
      if (recyledItemsByUserId != null && Enumerable.Count<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) recyledItemsByUserId) > 0)
        this.UpdatChangeMainOrdersTabs(tabByCode1, tabByCode2, tabByCode3, tabByCode4, recyledItemsByUserId);
      if (changes == null || Enumerable.Count<TBJS_vmMainOrder>((IEnumerable<TBJS_vmMainOrder>) changes) == 0)
      {
        jsonData.tabs = tabs.ToArray();
      }
      else
      {
        List<TBJS_MainOrder> orders = Enumerable.ToList<TBJS_MainOrder>(Enumerable.Select(Enumerable.Where(Enumerable.Join((IEnumerable<TBJS_MainOrder>) ordersByUserId, (IEnumerable<TBJS_vmMainOrder>) changes, (Func<TBJS_MainOrder, long>) (o => o.id), (Func<TBJS_vmMainOrder, long>) (c => c.id), (o, c) => new
        {
          o = o,
          c = c
        }), param0 =>
        {
          if (param0.c.IsHide && (param0.o.extra.tradeStatus.Equals("WAIT_BUYER_PAY") || param0.o.extra.tradeStatus.Equals("WAIT_SELLER_SEND_GOODS") || (param0.o.extra.tradeStatus.Equals("WAIT_BUYER_CONFIRM_GOODS") || TBHelper.IsRateOrder(param0.o))) || !param0.c.IsHide && param0.c.tradeStatusText.Equals("交易成功") && (param0.o.extra.tradeStatus.Equals("WAIT_BUYER_PAY") || param0.o.extra.tradeStatus.Equals("WAIT_SELLER_SEND_GOODS") || param0.o.extra.tradeStatus.Equals("WAIT_BUYER_CONFIRM_GOODS")))
            return true;
          if (!param0.c.IsHide && param0.o.extra.tradeStatus.Equals("TRADE_FINISHED"))
            return TBHelper.IsRateOrder(param0.o);
          return false;
        }), param0 => param0.o));
        this.UpdatChangeMainOrdersTabs(tabByCode1, tabByCode2, tabByCode3, tabByCode4, orders);
        List<TBJS_MainOrder> list = Enumerable.ToList<TBJS_MainOrder>(Enumerable.Where<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) Enumerable.ToList<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) jsonData.mainOrders), (Func<TBJS_MainOrder, bool>) (j => !Enumerable.Contains<long>(Enumerable.Select<TBJS_vmMainOrder, long>(Enumerable.Where<TBJS_vmMainOrder>((IEnumerable<TBJS_vmMainOrder>) changes, (Func<TBJS_vmMainOrder, bool>) (c => c.IsHide)), (Func<TBJS_vmMainOrder, long>) (c => c.id)), j.id))));
        if (!tabCode.Equals(""))
          list = Enumerable.ToList<TBJS_MainOrder>(Enumerable.Where<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) list, (Func<TBJS_MainOrder, bool>) (j => !Enumerable.Contains<long>(Enumerable.Select<TBJS_vmMainOrder, long>(Enumerable.Where<TBJS_vmMainOrder>((IEnumerable<TBJS_vmMainOrder>) changes, (Func<TBJS_vmMainOrder, bool>) (c => c.tradeStatusText.Equals("交易成功"))), (Func<TBJS_vmMainOrder, long>) (c => c.id)), j.id))));
        try
        {
          foreach (TBJS_MainOrder order in list)
          {
            TBJS_vmMainOrder changeOrderById = this.GetChangeOrderById(order.id, changes);
            if (changeOrderById != null)
            {
              if (!order.orderInfo.createDay.Equals(changeOrderById.createDay))
              {
                order.orderInfo.createDay = changeOrderById.createDay;
                order.orderInfo.createTime = string.Format("{0} {1}", (object) changeOrderById.createDay, (object) Convert.ToDateTime(order.orderInfo.createTime).ToString("HH:mm:ss"));
              }
              if (tabCode.Equals("") && changeOrderById.tradeStatusText.Equals("交易成功") && !changeOrderById.tradeStatusText.Equals(order.statusInfo.text))
                this.SetTradeFinished(user, order);
              else if (order.extra.tradeStatus.Equals("TRADE_FINISHED") && TBHelper.IsRateOrder(order))
                this.SetTradeWaitRate(user, order);
            }
          }
          string str = string.Join<long>("-", (IEnumerable<long>) Enumerable.ToArray<long>(Enumerable.Select<TBJS_MainOrder, long>((IEnumerable<TBJS_MainOrder>) list, (Func<TBJS_MainOrder, long>) (c => c.mainOrderId))));
          jsonData.extra.mainBizOrderIds = str;
          jsonData.tabs = tabs.ToArray();
          jsonData.mainOrders = Enumerable.ToArray<TBJS_MainOrder>(Enumerable.Select<TBJS_MainOrder, TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) list, (Func<TBJS_MainOrder, TBJS_MainOrder>) (c => c)));
          if (Enumerable.Count<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) jsonData.mainOrders) != 0)
            return;
          jsonData.page.totalNumber = 0;
          jsonData.page.totalPage = 0;
          jsonData.page.pageSize = 0;
          jsonData.page.currentPage = 0;
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
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

    public string ResolveHtmlToData(TBJS_UserInfo user, string HtmlText, DataTable dt, bool allowUpdate, string tabCode)
    {
      int currentNumber = 0;
      int totalNumber = 0;
      return this.ResolveHtmlToData(user, HtmlText, dt, ref currentNumber, ref totalNumber, allowUpdate, tabCode);
    }

    public string ResolveHtmlToData(TBJS_UserInfo user, string HtmlText, DataTable dt, ref int currentNumber, ref int totalNumber, bool allowUpdate, string tabCode)
    {
      string pattern = "<script>(\\s*)var data = ([\\s\\S]+?)</script>";
      Match match = Regex.Match(HtmlText, pattern, RegexOptions.IgnoreCase);
      if (match.Groups.Count < 3 || match.Groups[2].Value.Trim() == "")
        return HtmlText;
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("<script> var data =");
      stringBuilder.Append(this.ResolveJsonToData(user, match.Groups[2].Value, dt, ref currentNumber, ref totalNumber, allowUpdate, tabCode));
      stringBuilder.Append("</script>");
      string replacement = stringBuilder.ToString();
      return Regex.Replace(HtmlText, pattern, replacement);
    }

    public string ResolveJsonToData(TBJS_UserInfo user, string JsonText, DataTable dt, bool allowUpdate, string tabCode)
    {
      int currentNumber = 0;
      int totalNumber = 0;
      return this.ResolveJsonToData(user, JsonText, dt, ref currentNumber, ref totalNumber, allowUpdate, tabCode);
    }

    public string ResolveJsonToData(TBJS_UserInfo user, string JsonText, DataTable dt, ref int currentNumber, bool allowUpdate, string tabCode)
    {
      int totalNumber = 0;
      return this.ResolveJsonToData(user, JsonText, dt, ref currentNumber, ref totalNumber, allowUpdate, tabCode);
    }

    public string ResolveJsonToData(TBJS_UserInfo user, string JsonText, DataTable dt, ref int currentNumber, ref int totalNumber, bool allowUpdate, string tabCode)
    {
      try
      {
        TBJS_Data jsonData = this.ConvertJsonToRecordItems(user, JsonText);
        currentNumber = Enumerable.Count<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) jsonData.mainOrders);
        totalNumber = jsonData.page.totalNumber;
        if (!allowUpdate)
          return JsonText;
        List<TBJS_MainOrder> orders = Enumerable.ToList<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) jsonData.mainOrders);
        this.UpdateChangeOrders(user, orders);
        this.UpdateMainOrders(user, jsonData, tabCode);
        return JsonConvert.SerializeObject((object) jsonData);
      }
      catch
      {
        return JsonText;
      }
    }

    public string GetRecordItems(TBJS_UserInfo user, string HttpCookieString, int page, int pageSize)
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
          Cookie = TBHelper.TBCookie,
          Postdata = string.Format("options=0&pageNum={0}&pageSize={1}&queryOrder=desc", (object) page, (object) pageSize)
        };
        if (CaptureConfiguration.ProxyRunning)
          httpItem.ProxyIp = string.Format("127.0.0.1:{0}", (object) CaptureConfiguration.ProxyPort);
        HttpResult html = httpHelper.GetHtml(httpItem);
        if (html.StatusCode == HttpStatusCode.OK)
          return html.Html;
        return string.Empty;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public TBJS_Data ConvertJsonToRecordItems(TBJS_UserInfo user, string JsonText)
    {
      List<TBJS_MainOrder> list = (List<TBJS_MainOrder>) null;
      lock (this.userMainOrders)
      {
        try
        {
          TBJS_Data jsonData = JsonConvert.DeserializeObject<TBJS_Data>(JsonText);
          if (this.userMainOrders.TryGetValue(user.userid, out list))
          {
            List<TBJS_MainOrder> local_1 = Enumerable.ToList<TBJS_MainOrder>(Enumerable.Where<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) list, (Func<TBJS_MainOrder, bool>) (p => !Enumerable.Contains<long>(Enumerable.Select<TBJS_MainOrder, long>((IEnumerable<TBJS_MainOrder>) jsonData.mainOrders, (Func<TBJS_MainOrder, long>) (f => f.id)), p.id))));
            list.Clear();
            if (local_1.Count > 0)
              list.AddRange((IEnumerable<TBJS_MainOrder>) local_1);
            List<TBJS_MainOrder> local_2 = Enumerable.ToList<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) JsonConvert.DeserializeObject<TBJS_MainOrder[]>(JsonConvert.SerializeObject((object) jsonData.mainOrders)));
            list.AddRange((IEnumerable<TBJS_MainOrder>) local_2);
          }
          else
          {
            List<TBJS_MainOrder> local_0_1 = Enumerable.ToList<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) JsonConvert.DeserializeObject<TBJS_MainOrder[]>(JsonConvert.SerializeObject((object) jsonData.mainOrders)));
            this.userMainOrders.Add(user.userid, local_0_1);
          }
          return jsonData;
        }
        catch (Exception exception_0)
        {
          throw exception_0;
        }
      }
    }

    public void RequestAllRecordItems(TBJS_UserInfo user, string HttpCookieString, DataTable dt)
    {
      int totalNumber = 0;
      int pageSize = 50;
      int currentNumber = 0;
      try
      {
        string recordItems1 = this.GetRecordItems(user, HttpCookieString, 1, pageSize);
        if (recordItems1.Trim().Equals(""))
          return;
        this.ResolveJsonToData(user, recordItems1, dt, ref currentNumber, ref totalNumber, false, "");
        if (totalNumber != 0 && currentNumber >= pageSize)
        {
          int num = (totalNumber % pageSize != 0 ? totalNumber / pageSize + 1 : totalNumber / pageSize) + 1;
          for (int page = 2; page < num; ++page)
          {
            string recordItems2 = this.GetRecordItems(user, HttpCookieString, page, pageSize);
            this.ResolveJsonToData(user, recordItems2, dt, ref currentNumber, false, "");
            if (currentNumber == 0)
              break;
          }
        }
      }
      catch (Exception ex)
      {
      }
    }

    private string HtmlToJson(string HtmlText)
    {
      string pattern = "<script>(\\s*)var data = ([\\s\\S]+?)</script>";
      Match match = Regex.Match(HtmlText, pattern, RegexOptions.IgnoreCase);
      if (match.Groups.Count < 3 || match.Groups[2].Value.Trim() == "")
        return string.Empty;
      return match.Groups[2].Value;
    }

    public string GetHttpCookieString(string HttpCookieString)
    {
      try
      {
        HttpHelper httpHelper = new HttpHelper();
        HttpItem httpItem = new HttpItem()
        {
          URL = string.Format("https://buyertrade.taobao.com/trade/itemlist/list_bought_items.htm?spm=a1z09.2.0.0.QZOt8C&action=itemlist/BoughtQueryAction&event_submit_do_query=1&is_user_do_async=1&t={0}", (object) DateTime.Now.ToString("hhmmssfff")),
          Host = "buyertrade.taobao.com",
          Encoding = (Encoding) null,
          Method = "GET",
          ContentType = "text/html;charset=GBK",
          Cookie = HttpCookieString
        };
        if (CaptureConfiguration.ProxyRunning)
          httpItem.ProxyIp = string.Format("127.0.0.1:{0}", (object) CaptureConfiguration.ProxyPort);
        return httpHelper.GetHtml(httpItem).Cookie;
      }
      catch
      {
        return string.Empty;
      }
    }

    public int GetBoughtQueryActionWithTabCode(string tabCode, string HttpCookieString)
    {
      try
      {
        HttpHelper httpHelper = new HttpHelper();
        HttpItem httpItem = new HttpItem()
        {
          URL = string.Format("https://buyertrade.taobao.com/trade/itemlist/list_bought_items.htm?spm=a1z09.2.0.0.QZOt8C&action=itemlist/BoughtQueryAction&event_submit_do_query=1&is_user_do_async=1&t={0}&tabCode={1}", (object) DateTime.Now.ToString("hhmmssfff"), (object) tabCode),
          Host = "buyertrade.taobao.com",
          Encoding = (Encoding) null,
          Method = "GET",
          ContentType = "text/html;charset=GBK",
          Cookie = HttpCookieString
        };
        if (CaptureConfiguration.ProxyRunning)
          httpItem.ProxyIp = string.Format("127.0.0.1:{0}", (object) CaptureConfiguration.ProxyPort);
        HttpResult html = httpHelper.GetHtml(httpItem);
        if (html.StatusCode == HttpStatusCode.OK)
          return JsonConvert.DeserializeObject<TBJS_Data>(this.HtmlToJson(html.Html)).page.totalNumber;
      }
      catch (Exception ex)
      {
        return 0;
      }
      return 0;
    }

    public int GetBoughtQueryActionWithTabCode2(string tabCode, string HttpCookieString)
    {
      try
      {
        HttpHelper httpHelper = new HttpHelper();
        HttpItem httpItem = new HttpItem()
        {
          URL = string.Format("https://buyertrade.taobao.com/trade/itemlist/list_bought_items.htm?spm=a1z09.2.0.0.QZOt8C&action=itemlist/BoughtQueryAction&event_submit_do_query=1&is_user_do_async=1&t={0}&tabCode={1}", (object) DateTime.Now.ToString("hhmmssfff"), (object) tabCode),
          Host = "buyertrade.taobao.com",
          Encoding = (Encoding) null,
          Method = "GET",
          ContentType = "text/html;charset=GBK",
          Cookie = HttpCookieString
        };
        if (CaptureConfiguration.ProxyRunning)
          httpItem.ProxyIp = string.Format("127.0.0.1:{0}", (object) CaptureConfiguration.ProxyPort);
        HttpResult html = httpHelper.GetHtml(httpItem);
        if (html.StatusCode == HttpStatusCode.OK)
          return JsonConvert.DeserializeObject<TBJS_Data>(this.HtmlToJson(html.Html)).page.totalNumber;
      }
      catch (Exception ex)
      {
        return 0;
      }
      return 0;
    }

    public void OneKeyAllHide(long userId, DataTable dt)
    {
      List<TBJS_MainOrder> ordersByUserId = this.GetOrdersByUserId(userId);
      List<TBJS_vmMainOrder> orders = this.GetChangeListByUserId(userId);
      if (orders == null)
      {
        orders = new List<TBJS_vmMainOrder>();
        this.userChangeMainOrders.Add(userId, orders);
      }
      foreach (TBJS_MainOrder order in ordersByUserId)
      {
        TBJS_vmMainOrder changeOrderById = this.GetChangeOrderById(order.id, orders);
        if (changeOrderById != null)
        {
          changeOrderById.IsHide = true;
          changeOrderById.tradeStatusText = "隐藏";
        }
        else
        {
          TBJS_vmMainOrder tbjsVmMainOrder = new TBJS_vmMainOrder()
          {
            id = order.id,
            userid = userId,
            createDay = order.orderInfo.createDay,
            tradeStatus = order.extra.tradeStatus,
            subOrderCount = TBHelper.GetSubOrderCount(order),
            IsHide = true,
            tradeStatusText = "隐藏"
          };
          orders.Add(tbjsVmMainOrder);
        }
        dt.Rows.Find((object) order.id)["tradeStatusText"] = (object) "隐藏";
      }
      dt.AcceptChanges();
    }

    public void OneKeyAllWaitRate(long userId, DataTable dt)
    {
      List<TBJS_MainOrder> ordersByUserId = this.GetOrdersByUserId(userId);
      List<TBJS_vmMainOrder> orders = this.GetChangeListByUserId(userId);
      if (orders == null)
      {
        orders = new List<TBJS_vmMainOrder>();
        this.userChangeMainOrders.Add(userId, orders);
      }
      foreach (TBJS_MainOrder order in ordersByUserId)
      {
        if (order.extra.tradeStatus.Equals("TRADE_FINISHED") && TBHelper.IsRateOrder(order))
        {
          TBJS_vmMainOrder changeOrderById = this.GetChangeOrderById(order.id, orders);
          if (changeOrderById == null)
          {
            TBJS_vmMainOrder tbjsVmMainOrder = new TBJS_vmMainOrder()
            {
              id = order.id,
              userid = userId,
              createDay = order.orderInfo.createDay,
              subOrderCount = TBHelper.GetSubOrderCount(order),
              tradeStatus = order.extra.tradeStatus,
              tradeStatusText = "交易成功",
              IsRate = true
            };
            orders.Add(tbjsVmMainOrder);
          }
          else
            changeOrderById.IsRate = true;
        }
      }
    }

    public void OneKeyAllWaitConfirm(long userId, DataTable dt)
    {
      List<TBJS_MainOrder> ordersByUserId = this.GetOrdersByUserId(userId);
      List<TBJS_vmMainOrder> orders = this.GetChangeListByUserId(userId);
      if (orders == null)
      {
        orders = new List<TBJS_vmMainOrder>();
        this.userChangeMainOrders.Add(userId, orders);
      }
      foreach (TBJS_MainOrder order in ordersByUserId)
      {
        if (order.extra.tradeStatus.Equals("WAIT_BUYER_CONFIRM_GOODS"))
        {
          TBJS_vmMainOrder changeOrderById = this.GetChangeOrderById(order.id, orders);
          if (changeOrderById != null)
          {
            changeOrderById.tradeStatusText = "交易成功";
          }
          else
          {
            TBJS_vmMainOrder tbjsVmMainOrder = new TBJS_vmMainOrder()
            {
              id = order.id,
              userid = userId,
              createDay = order.orderInfo.createDay,
              subOrderCount = TBHelper.GetSubOrderCount(order),
              tradeStatus = order.extra.tradeStatus,
              tradeStatusText = "交易成功"
            };
            orders.Add(tbjsVmMainOrder);
          }
          dt.Rows.Find((object) order.id)["tradeStatusText"] = (object) "交易成功";
        }
      }
      dt.AcceptChanges();
    }

    public void OneKeyAllWaitSend(long userId, DataTable dt)
    {
      List<TBJS_MainOrder> ordersByUserId = this.GetOrdersByUserId(userId);
      List<TBJS_vmMainOrder> orders = this.GetChangeListByUserId(userId);
      if (orders == null)
      {
        orders = new List<TBJS_vmMainOrder>();
        this.userChangeMainOrders.Add(userId, orders);
      }
      foreach (TBJS_MainOrder order in ordersByUserId)
      {
        if (order.extra.tradeStatus.Equals("WAIT_SELLER_SEND_GOODS"))
        {
          TBJS_vmMainOrder changeOrderById = this.GetChangeOrderById(order.id, orders);
          if (changeOrderById != null)
          {
            changeOrderById.tradeStatusText = "交易成功";
          }
          else
          {
            TBJS_vmMainOrder tbjsVmMainOrder = new TBJS_vmMainOrder()
            {
              id = order.id,
              userid = userId,
              createDay = order.orderInfo.createDay,
              subOrderCount = TBHelper.GetSubOrderCount(order),
              tradeStatus = order.extra.tradeStatus,
              tradeStatusText = "交易成功"
            };
            orders.Add(tbjsVmMainOrder);
          }
          dt.Rows.Find((object) order.id)["tradeStatusText"] = (object) "交易成功";
        }
      }
      dt.AcceptChanges();
    }

    public void OneKeyAllWaitPay(long userId, DataTable dt)
    {
      List<TBJS_MainOrder> ordersByUserId = this.GetOrdersByUserId(userId);
      List<TBJS_vmMainOrder> orders = this.GetChangeListByUserId(userId);
      if (orders == null)
      {
        orders = new List<TBJS_vmMainOrder>();
        this.userChangeMainOrders.Add(userId, orders);
      }
      foreach (TBJS_MainOrder order in ordersByUserId)
      {
        if (order.extra.tradeStatus.Equals("WAIT_BUYER_PAY"))
        {
          TBJS_vmMainOrder changeOrderById = this.GetChangeOrderById(order.id, orders);
          if (changeOrderById != null)
          {
            changeOrderById.tradeStatusText = "交易成功";
          }
          else
          {
            TBJS_vmMainOrder tbjsVmMainOrder = new TBJS_vmMainOrder()
            {
              id = order.id,
              userid = userId,
              createDay = order.orderInfo.createDay,
              subOrderCount = TBHelper.GetSubOrderCount(order),
              tradeStatus = order.extra.tradeStatus,
              tradeStatusText = "交易成功"
            };
            orders.Add(tbjsVmMainOrder);
          }
          dt.Rows.Find((object) order.id)["tradeStatusText"] = (object) "交易成功";
        }
      }
      dt.AcceptChanges();
    }

    public void OneKeyAllReset(long userId, DataTable dt)
    {
      this.GetOrdersByUserId(userId);
      List<TBJS_vmMainOrder> changeListByUserId = this.GetChangeListByUserId(userId);
      if (changeListByUserId == null)
        return;
      foreach (TBJS_vmMainOrder tbjsVmMainOrder in changeListByUserId)
      {
        TBJS_MainOrder orderById = this.GetOrderById(userId, tbjsVmMainOrder.id);
        if (orderById != null)
        {
          DataRow dataRow = dt.Rows.Find((object) orderById.id);
          dataRow["tradeStatusText"] = (object) orderById.statusInfo.text;
          dataRow["createDay"] = (object) orderById.orderInfo.createDay;
        }
      }
      changeListByUserId.Clear();
      dt.AcceptChanges();
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
      List<TBJS_MainOrder> recyledItemsByUserId = this.GetRecyledItemsByUserId(user.userid);
      try
      {
        TBJS_Data jsonData = JsonConvert.DeserializeObject<TBJS_Data>(JsonText);
        List<TBJS_MainOrder> list = Enumerable.ToList<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) jsonData.mainOrders);
        Enumerable.ToList<TBJS_MainOrder>(Enumerable.Except<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) recyledItemsByUserId, (IEnumerable<TBJS_MainOrder>) list, (IEqualityComparer<TBJS_MainOrder>) new TBJS_MainOrderComparer())).AddRange((IEnumerable<TBJS_MainOrder>) Enumerable.ToList<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) JsonConvert.DeserializeObject<TBJS_MainOrder[]>(JsonConvert.SerializeObject((object) jsonData.mainOrders))));
        this.UpdateListRecyledtemsTabs(user, jsonData);
        list.Clear();
        jsonData.page.totalNumber = 0;
        jsonData.page.totalPage = 0;
        jsonData.page.pageSize = 0;
        jsonData.page.currentPage = 0;
        jsonData.mainOrders = list.ToArray();
        return JsonConvert.SerializeObject((object) jsonData);
      }
      catch
      {
        return JsonText;
      }
    }

    public void UpdateListRecyledtemsTabs(TBJS_UserInfo user, TBJS_Data jsonData)
    {
      List<TBJS_Tab> tabs = Enumerable.ToList<TBJS_Tab>((IEnumerable<TBJS_Tab>) jsonData.tabs);
      TBJS_Tab tabByCode1 = TBHelper.GetTabByCode("waitPay", tabs);
      TBJS_Tab tabByCode2 = TBHelper.GetTabByCode("waitSend", tabs);
      TBJS_Tab tabByCode3 = TBHelper.GetTabByCode("waitConfirm", tabs);
      TBJS_Tab tabByCode4 = TBHelper.GetTabByCode("waitRate", tabs);
      List<TBJS_MainOrder> ordersByUserId = this.GetOrdersByUserId(user.userid);
      List<TBJS_MainOrder> recyledItemsByUserId = this.GetRecyledItemsByUserId(user.userid);
      List<TBJS_vmMainOrder> changeListByUserId = this.GetChangeListByUserId(user.userid);
      if (recyledItemsByUserId != null && Enumerable.Count<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) recyledItemsByUserId) > 0)
        this.UpdatChangeMainOrdersTabs(tabByCode1, tabByCode2, tabByCode3, tabByCode4, recyledItemsByUserId);
      if (changeListByUserId == null || Enumerable.Count<TBJS_vmMainOrder>((IEnumerable<TBJS_vmMainOrder>) changeListByUserId) <= 0)
        return;
      List<TBJS_MainOrder> orders = Enumerable.ToList<TBJS_MainOrder>(Enumerable.Select(Enumerable.Where(Enumerable.Join((IEnumerable<TBJS_MainOrder>) ordersByUserId, (IEnumerable<TBJS_vmMainOrder>) changeListByUserId, (Func<TBJS_MainOrder, long>) (o => o.id), (Func<TBJS_vmMainOrder, long>) (c => c.id), (o, c) => new
      {
        o = o,
        c = c
      }), param0 =>
      {
        if (param0.c.IsHide && (param0.o.extra.tradeStatus.Equals("WAIT_BUYER_PAY") || param0.o.extra.tradeStatus.Equals("WAIT_SELLER_SEND_GOODS") || (param0.o.extra.tradeStatus.Equals("WAIT_BUYER_CONFIRM_GOODS") || TBHelper.IsRateOrder(param0.o))) || !param0.c.IsHide && param0.c.tradeStatusText.Equals("交易成功") && (param0.o.extra.tradeStatus.Equals("WAIT_BUYER_PAY") || param0.o.extra.tradeStatus.Equals("WAIT_SELLER_SEND_GOODS") || param0.o.extra.tradeStatus.Equals("WAIT_BUYER_CONFIRM_GOODS")))
          return true;
        if (!param0.c.IsHide && param0.o.extra.tradeStatus.Equals("TRADE_FINISHED"))
          return TBHelper.IsRateOrder(param0.o);
        return false;
      }), param0 => param0.o));
      this.UpdatChangeMainOrdersTabs(tabByCode1, tabByCode2, tabByCode3, tabByCode4, orders);
    }

    public List<TBJS_MainOrder> GetRecyledItemsByUserId(long userId)
    {
      List<TBJS_MainOrder> list = (List<TBJS_MainOrder>) null;
      if (this.userRecyledtems.TryGetValue(userId, out list))
        return list;
      return (List<TBJS_MainOrder>) null;
    }

    public int GetAllListRecyledItems(TBJS_UserInfo user, string HttpCookieString)
    {
      List<TBJS_MainOrder> list = this.GetRecyledItemsByUserId(user.userid);
      if (list == null)
      {
        list = new List<TBJS_MainOrder>();
        this.userRecyledtems.Add(user.userid, list);
      }
      string str1 = string.Empty;
      HttpHelper httpHelper = new HttpHelper();
      HttpItem httpItem1 = new HttpItem()
      {
        URL = string.Format("{0}?spm=a1z{1}.0.0.bWflkj&is_user_do_async=1", (object) "https://buyertrade.taobao.com/trade/itemlist/list_recyled_items.htm", (object) DateTime.Now.ToString("ss.fff")),
        Encoding = (Encoding) null,
        Method = "GET",
        ContentType = "text/html;charset=GBK",
        Cookie = HttpCookieString
      };
      if (CaptureConfiguration.ProxyRunning)
        httpItem1.ProxyIp = string.Format("127.0.0.1:{0}", (object) CaptureConfiguration.ProxyPort);
      HttpResult html1 = httpHelper.GetHtml(httpItem1);
      if (html1.StatusCode != HttpStatusCode.OK)
        return 0;
      string str2 = this.ListRecyledtems_ResolveHtmlToJson(user, html1.Html);
      list.Clear();
      TBJS_Data tbjsData1 = JsonConvert.DeserializeObject<TBJS_Data>(str2);
      list.AddRange((IEnumerable<TBJS_MainOrder>) Enumerable.ToList<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) JsonConvert.DeserializeObject<TBJS_MainOrder[]>(JsonConvert.SerializeObject((object) tbjsData1.mainOrders))));
      int totalPage = tbjsData1.page.totalPage;
      int num = 20;
      for (int index = tbjsData1.page.currentPage + 1; index <= num; ++index)
      {
        HttpItem httpItem2 = new HttpItem()
        {
          URL = string.Format("{0}?action=itemlist/RecyledQueryAction&event_submit_do_query=1&_input_charset=utf8&lastStartRow=&pageNum={1}&pageSize=15&tabCode=recycle&prePageNo={2}&is_user_do_async=1", (object) "https://buyertrade.taobao.com/trade/itemlist/asyncRecyledItems.htm", (object) index, (object) (index - 1)),
          Encoding = (Encoding) null,
          Method = "GET",
          ContentType = "text/html;charset=GBK",
          Cookie = TBHelper.TBCookie
        };
        if (CaptureConfiguration.ProxyRunning)
          httpItem2.ProxyIp = string.Format("127.0.0.1:{0}", (object) CaptureConfiguration.ProxyPort);
        HttpResult html2 = httpHelper.GetHtml(httpItem2);
        if (html2.StatusCode != HttpStatusCode.OK)
          return Enumerable.Count<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) list);
        TBJS_Data tbjsData2 = JsonConvert.DeserializeObject<TBJS_Data>(html2.Html);
        if (Enumerable.Count<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) tbjsData2.mainOrders) >= 15 && Enumerable.Count<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) tbjsData2.mainOrders) != 0)
          list.AddRange((IEnumerable<TBJS_MainOrder>) Enumerable.ToList<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) JsonConvert.DeserializeObject<TBJS_MainOrder[]>(JsonConvert.SerializeObject((object) tbjsData2.mainOrders))));
        else
          break;
      }
      return Enumerable.Count<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) list);
    }

    public string GetLogisticsInfo(string HttpCookieString)
    {
      try
      {
        HttpHelper httpHelper = new HttpHelper();
        HttpItem httpItem = new HttpItem()
        {
          URL = string.Format("https://i.taobao.com/my_taobao_api/logistics_info.json?_ksTS={0}&is_user_do_async=1", (object) DateTime.Now.ToString("yyyyMMddhhmmss_fff")),
          Host = "i.taobao.com",
          Encoding = (Encoding) null,
          Method = "GET",
          ContentType = "application/json; charset=utf-8",
          Cookie = HttpCookieString
        };
        if (CaptureConfiguration.ProxyRunning)
          httpItem.ProxyIp = string.Format("127.0.0.1:{0}", (object) CaptureConfiguration.ProxyPort);
        HttpResult html = httpHelper.GetHtml(httpItem);
        if (html.StatusCode == HttpStatusCode.OK)
          return html.Html;
      }
      catch (Exception ex)
      {
        return string.Empty;
      }
      return string.Empty;
    }

    public List<TBJS_MainOrder> GetShowMainOrders(long userId)
    {
      List<TBJS_MainOrder> ordersByUserId = this.GetOrdersByUserId(userId);
      if (ordersByUserId == null)
        return (List<TBJS_MainOrder>) null;
      List<TBJS_vmMainOrder> changes = this.GetChangeListByUserId(userId);
      if (changes == null || Enumerable.Count<TBJS_vmMainOrder>((IEnumerable<TBJS_vmMainOrder>) changes) == 0)
        return ordersByUserId;
      return Enumerable.ToList<TBJS_MainOrder>(Enumerable.Where<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) ordersByUserId, (Func<TBJS_MainOrder, bool>) (m => !Enumerable.Contains<long>(Enumerable.Select<TBJS_vmMainOrder, long>(Enumerable.Where<TBJS_vmMainOrder>((IEnumerable<TBJS_vmMainOrder>) changes, (Func<TBJS_vmMainOrder, bool>) (c => c.IsHide)), (Func<TBJS_vmMainOrder, long>) (c => c.id)), m.id))));
    }

    public List<TBJS_MainOrder> GetShowMainOrdersWithTabCode(long userId, string tagCode)
    {
      List<TBJS_MainOrder> showMainOrders = this.GetShowMainOrders(userId);
      if (showMainOrders == null)
        return (List<TBJS_MainOrder>) null;
      if (tagCode.Equals("waitConfirm"))
        return showMainOrders.FindAll((Predicate<TBJS_MainOrder>) (o => o.extra.tradeStatus.Equals("WAIT_BUYER_CONFIRM_GOODS")));
      return (List<TBJS_MainOrder>) null;
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
      this.UpdateMyTaobaoTabs(user, ref waitPay, ref waitSend, ref waitConfirm, ref waitRate);
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
        HtmlNode htmlNode1 = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='m-logistics g-box-base g-mb-set']");
        HtmlNodeCollection htmlNodeCollection = htmlDocument.DocumentNode.SelectNodes("//ul[@class=\"lg-list\"]/li");
        if (htmlNodeCollection == null)
          return HtmlText;
        List<long> list = new List<long>();
        foreach (HtmlNode htmlNode2 in (IEnumerable<HtmlNode>) htmlNodeCollection)
        {
          Match match5 = Regex.Match(htmlNode2.InnerHtml, "bizOrderId=([0-9]*)", RegexOptions.IgnoreCase);
          if (match5.Groups.Count == 2)
          {
            long orderId = Convert.ToInt64(match5.Groups[1].Value.Trim());
            TBJS_vmMainOrder changeOrderById = this.GetChangeOrderById(user.userid, orderId);
            if (changeOrderById != null && (changeOrderById.IsHide || changeOrderById.tradeStatusText.Equals("交易成功")))
              htmlNode2.Remove();
            else
              list.Add(orderId);
          }
        }
        if (htmlNodeCollection.Count == 0)
          htmlNode1.InnerHtml = "";
        HtmlText = htmlDocument.DocumentNode.InnerHtml;
      }
      return HtmlText;
    }

    public string ResolveHtmlToLogisticsInfoJson(TBJS_UserInfo user, string HtmlText, bool ClearLogistics = false)
    {
      if (!ClearLogistics)
        return HtmlText;
      TBLI_LogisticsInfo tbliLogisticsInfo = JsonConvert.DeserializeObject<TBLI_LogisticsInfo>(HtmlText);
      List<TBLI_ItemForMe> list = Enumerable.ToList<TBLI_ItemForMe>((IEnumerable<TBLI_ItemForMe>) tbliLogisticsInfo.data.itemForMe);
      for (int index = Enumerable.Count<TBLI_ItemForMe>((IEnumerable<TBLI_ItemForMe>) list) - 1; index >= 0; --index)
      {
        TBJS_vmMainOrder changeOrderById = this.GetChangeOrderById(user.userid, list[index].tradeId);
        if (changeOrderById != null && (changeOrderById.IsHide || changeOrderById.tradeStatusText.Equals("交易成功")))
          list.RemoveAt(index);
      }
      tbliLogisticsInfo.data.itemForMe = list.ToArray();
      tbliLogisticsInfo.data.itemNum = Enumerable.Count<TBLI_ItemForMe>((IEnumerable<TBLI_ItemForMe>) list);
      return JsonConvert.SerializeObject((object) tbliLogisticsInfo);
    }

    public void UpdateMyTaobaoTabs(TBJS_UserInfo user, ref int waitPay, ref int waitSend, ref int waitConfirm, ref int waitRate)
    {
      List<TBJS_MainOrder> ordersByUserId = this.GetOrdersByUserId(user.userid);
      List<TBJS_MainOrder> recyledItemsByUserId = this.GetRecyledItemsByUserId(user.userid);
      List<TBJS_vmMainOrder> changeListByUserId = this.GetChangeListByUserId(user.userid);
      if (ordersByUserId == null)
        return;
      int waitPay1 = 0;
      int waitSend1 = 0;
      int waitConfirm1 = 0;
      int waitRate1 = 0;
      if (recyledItemsByUserId != null)
      {
        this.GetChangeMainOrdersTabs(ref waitPay1, ref waitSend1, ref waitConfirm1, ref waitRate1, recyledItemsByUserId);
        waitPay = waitPay1 > 0 ? waitPay - waitPay1 : waitPay;
        waitSend = waitSend1 > 0 ? waitSend - waitSend1 : waitSend;
        waitConfirm = waitConfirm1 > 0 ? waitConfirm - waitConfirm1 : waitConfirm;
        waitRate = waitRate1 > 0 ? waitRate - waitRate1 : waitRate;
      }
      if (changeListByUserId == null || Enumerable.Count<TBJS_vmMainOrder>((IEnumerable<TBJS_vmMainOrder>) changeListByUserId) <= 0)
        return;
      List<TBJS_MainOrder> orders = Enumerable.ToList<TBJS_MainOrder>(Enumerable.Select(Enumerable.Where(Enumerable.Join((IEnumerable<TBJS_MainOrder>) ordersByUserId, (IEnumerable<TBJS_vmMainOrder>) changeListByUserId, (Func<TBJS_MainOrder, long>) (o => o.id), (Func<TBJS_vmMainOrder, long>) (c => c.id), (o, c) => new
      {
        o = o,
        c = c
      }), param0 =>
      {
        if (param0.c.IsHide && (param0.o.extra.tradeStatus.Equals("WAIT_BUYER_PAY") || param0.o.extra.tradeStatus.Equals("WAIT_SELLER_SEND_GOODS") || (param0.o.extra.tradeStatus.Equals("WAIT_BUYER_CONFIRM_GOODS") || TBHelper.IsRateOrder(param0.o))) || !param0.c.IsHide && param0.c.tradeStatusText.Equals("交易成功") && (param0.o.extra.tradeStatus.Equals("WAIT_BUYER_PAY") || param0.o.extra.tradeStatus.Equals("WAIT_SELLER_SEND_GOODS") || param0.o.extra.tradeStatus.Equals("WAIT_BUYER_CONFIRM_GOODS")))
          return true;
        if (!param0.c.IsHide && param0.o.extra.tradeStatus.Equals("TRADE_FINISHED"))
          return TBHelper.IsRateOrder(param0.o);
        return false;
      }), param0 => param0.o));
      this.GetChangeMainOrdersTabs(ref waitPay1, ref waitSend1, ref waitConfirm1, ref waitRate1, orders);
      waitPay = waitPay1 > 0 ? waitPay - waitPay1 : waitPay;
      waitSend = waitSend1 > 0 ? waitSend - waitSend1 : waitSend;
      waitConfirm = waitConfirm1 > 0 ? waitConfirm - waitConfirm1 : waitConfirm;
      waitRate = waitRate1 > 0 ? waitRate - waitRate1 : waitRate;
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
      List<TBJS_MainOrder> ordersByUserId = this.GetOrdersByUserId(user.userid);
      List<TBJS_MainOrder> recyledItemsByUserId = this.GetRecyledItemsByUserId(user.userid);
      List<TBJS_vmMainOrder> changeListByUserId = this.GetChangeListByUserId(user.userid);
      if (ordersByUserId == null)
        return;
      int waitPay1 = 0;
      int waitSend1 = 0;
      int waitConfirm1 = 0;
      int waitRate1 = 0;
      if (recyledItemsByUserId != null && Enumerable.Count<TBJS_MainOrder>((IEnumerable<TBJS_MainOrder>) recyledItemsByUserId) > 0)
      {
        this.GetChangeMainOrdersTabs(ref waitPay1, ref waitSend1, ref waitConfirm1, ref waitRate1, recyledItemsByUserId);
        waitPay = waitPay1 > 0 ? waitPay - waitPay1 : waitPay;
        waitSend = waitSend1 > 0 ? waitSend - waitSend1 : waitSend;
        waitConfirm = waitConfirm1 > 0 ? waitConfirm - waitConfirm1 : waitConfirm;
        waitRate = waitRate1 > 0 ? waitRate - waitRate1 : waitRate;
      }
      if (changeListByUserId == null || Enumerable.Count<TBJS_vmMainOrder>((IEnumerable<TBJS_vmMainOrder>) changeListByUserId) <= 0)
        return;
      List<TBJS_MainOrder> orders = Enumerable.ToList<TBJS_MainOrder>(Enumerable.Select(Enumerable.Where(Enumerable.Join((IEnumerable<TBJS_MainOrder>) ordersByUserId, (IEnumerable<TBJS_vmMainOrder>) changeListByUserId, (Func<TBJS_MainOrder, long>) (o => o.id), (Func<TBJS_vmMainOrder, long>) (c => c.id), (o, c) => new
      {
        o = o,
        c = c
      }), param0 =>
      {
        if (param0.c.IsHide && (param0.o.extra.tradeStatus.Equals("WAIT_BUYER_PAY") || param0.o.extra.tradeStatus.Equals("WAIT_SELLER_SEND_GOODS") || (param0.o.extra.tradeStatus.Equals("WAIT_BUYER_CONFIRM_GOODS") || TBHelper.IsRateOrder(param0.o))) || !param0.c.IsHide && param0.c.tradeStatusText.Equals("交易成功") && (param0.o.extra.tradeStatus.Equals("WAIT_BUYER_PAY") || param0.o.extra.tradeStatus.Equals("WAIT_SELLER_SEND_GOODS") || param0.o.extra.tradeStatus.Equals("WAIT_BUYER_CONFIRM_GOODS")))
          return true;
        if (!param0.c.IsHide && param0.o.extra.tradeStatus.Equals("TRADE_FINISHED"))
          return TBHelper.IsRateOrder(param0.o);
        return false;
      }), param0 => param0.o));
      this.GetChangeMainOrdersTabs(ref waitPay1, ref waitSend1, ref waitConfirm1, ref waitRate1, orders);
      waitPay = waitPay1 > 0 ? waitPay - waitPay1 : waitPay;
      waitSend = waitSend1 > 0 ? waitSend - waitSend1 : waitSend;
      waitConfirm = waitConfirm1 > 0 ? waitConfirm - waitConfirm1 : waitConfirm;
      waitRate = waitRate1 > 0 ? waitRate - waitRate1 : waitRate;
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

    public string GetTradeRecordsHtml(TBJS_UserInfo user, string HttpCookieString)
    {
      string str1 = DateTime.Now.AddDays(-15.0).ToString("yyyy.MM.dd");
      string str2 = DateTime.Now.ToString("yyyy.MM.dd");
      try
      {
        HttpHelper httpHelper = new HttpHelper();
        HttpItem httpItem = new HttpItem()
        {
          URL = string.Format("{0}?beginDate={1}&beginTime=00%3A00&endDate={2}&endTime=24%3A00&dateRange=customDate&status=all&keyword=bizOutNo&keyValue=&dateType=createDate&minAmount=&maxAmount=&fundFlow=out&tradeType=SHOPPING&categoryId=&_input_charset=utf-8&pageNum=1&is_user_do_async=1", (object) "https://consumeprod.alipay.com/record/advanced.htm", (object) str1, (object) str2),
          Method = "GET",
          ContentType = "text/html;charset=GBK",
          Encoding = (Encoding) null,
          Cookie = HttpCookieString
        };
        if (CaptureConfiguration.ProxyRunning)
          httpItem.ProxyIp = string.Format("127.0.0.1:{0}", (object) CaptureConfiguration.ProxyPort);
        HttpResult html = httpHelper.GetHtml(httpItem);
        if (html.StatusCode == HttpStatusCode.OK)
          return html.Html;
        return string.Empty;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public string GetTradeRecordsHtml(TBJS_UserInfo user, string HttpCookieString, string keyValue)
    {
      string str1 = DateTime.Now.AddDays(-30.0).ToString("yyyy.MM.dd");
      string str2 = DateTime.Now.ToString("yyyy.MM.dd");
      try
      {
        HttpHelper httpHelper = new HttpHelper();
        HttpItem httpItem = new HttpItem()
        {
          URL = string.Format("{0}?beginDate={1}&beginTime=00%3A00&endDate={2}&endTime=24%3A00&dateRange=customDate&status=all&keyword={3}bizOutNo&keyValue=&dateType=createDate&minAmount=&maxAmount=&fundFlow=all&tradeType=ALL&categoryId=&_input_charset=utf-8&pageNum=1&is_user_do_async=1", (object) "https://consumeprod.alipay.com/record/advanced.htm", (object) str1, (object) str2, (object) keyValue),
          Method = "GET",
          ContentType = "text/html;charset=GBK",
          Encoding = (Encoding) null,
          Cookie = HttpCookieString
        };
        if (CaptureConfiguration.ProxyRunning)
          httpItem.ProxyIp = string.Format("127.0.0.1:{0}", (object) CaptureConfiguration.ProxyPort);
        HttpResult html = httpHelper.GetHtml(httpItem);
        if (html.StatusCode == HttpStatusCode.OK)
          return html.Html;
        return string.Empty;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public int RequestAllTradeRecords(TBJS_UserInfo user, string HttpCookieString, List<APJS_TradeRecord> tradeRecords)
    {
      string tradeRecordsHtml = this.GetTradeRecordsHtml(user, HttpCookieString);
      if (string.IsNullOrEmpty(tradeRecordsHtml))
        return 0;
      try
      {
        HtmlDocument htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(tradeRecordsHtml);
        int num1 = 0;
        foreach (HtmlNode htmlNode in (IEnumerable<HtmlNode>) htmlDocument.DocumentNode.SelectNodes("//table[@id='tradeRecordsIndex']/tbody/tr"))
        {
          HtmlNodeCollection htmlNodeCollection = htmlNode.SelectNodes("td")[3].SelectNodes("./p");
          string str = htmlNodeCollection[0].InnerText.Trim();
          long num2 = str.IndexOf('P') <= 0 ? 0L : Convert.ToInt64(str.Substring(str.IndexOf('P') + 1));
          if (num2 > 0L)
            tradeRecords.Add(new APJS_TradeRecord()
            {
              tradeNo = htmlNodeCollection[1].InnerText.Trim().Substring(4),
              id = num2
            });
          ++num1;
        }
        return num1;
      }
      catch (Exception ex)
      {
        return 0;
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
      string gmtBizCreate = Regex.Match(attributeValue, "gmtBizCreate=([\\s\\S]*[0-9]*)", RegexOptions.IgnoreCase).Groups[1].Value.ToString().Trim();
      List<TBJS_vmMainOrder> changeListByUserId = this.GetChangeListByUserId(user.userid);
      if (changeListByUserId == null)
        return;
      TBJS_vmMainOrder tbjsVmMainOrder = this.GetTradeRecordByBizCreate(gmtBizCreate, changeListByUserId) ?? this.GetTradeRecordByBizCreate((Convert.ToInt64(gmtBizCreate) - 1L).ToString(), changeListByUserId);
      if (tbjsVmMainOrder == null)
        return;
      if (tbjsVmMainOrder.IsHide)
      {
        row.Remove();
      }
      else
      {
        htmlNodeCollection[0].SelectSingleNode("./p").InnerHtml = tbjsVmMainOrder.createDay;
        if (!tbjsVmMainOrder.tradeStatusText.Equals("交易成功"))
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
          string str = htmlNodeCollection[3].SelectNodes("./p")[0].InnerText.Trim();
          long orderId = str.IndexOf('P') <= 0 ? 0L : Convert.ToInt64(str.Substring(str.IndexOf('P') + 1));
          TBJS_vmMainOrder changeOrderById = this.GetChangeOrderById(user.userid, orderId);
          if (changeOrderById != null)
          {
            if (changeOrderById.IsHide)
            {
              htmlNode1.Remove();
            }
            else
            {
              htmlNodeCollection[0].SelectSingleNode("./p").InnerHtml = changeOrderById.createDay;
              if (changeOrderById.tradeStatusText.Equals("交易成功"))
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
      if (attributeValue.Equals(""))
        return;
      APJS_TradeRecord tradeRecordById = this.GetTradeRecordById(Regex.Match(attributeValue, "tradeNo=([0-9]*)", RegexOptions.IgnoreCase).Groups[1].Value.ToString().Trim(), tradeRecords);
      if (tradeRecordById == null)
        return;
      TBJS_vmMainOrder changeOrderById = this.GetChangeOrderById(user.userid, tradeRecordById.id);
      if (changeOrderById == null)
        return;
      if (changeOrderById.IsHide)
      {
        row.Remove();
      }
      else
      {
        if (!changeOrderById.tradeStatusText.Equals("交易成功"))
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
      if (!this.userLastMonthTradeRecords.TryGetValue(user.userid, out tradeRecords))
      {
        tradeRecords = new List<APJS_TradeRecord>();
        this.userLastMonthTradeRecords.Add(user.userid, tradeRecords);
      }
      tradeRecords.Clear();
      this.RequestAllTradeRecords(user, HttpCookieString, tradeRecords);
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

    public delegate void UpdateItemEventHandler(object sender, UpdateItemEventArgs e);
  }
}
