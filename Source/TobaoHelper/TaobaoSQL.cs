
// Type: TobaoHelper.TaobaoSQL
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Text;
using TobaoHelper.Taobao;

namespace TobaoHelper
{
  internal class TaobaoSQL
  {
    public static string SQLiteConnectionString = "Data Source=" + TBHelper.AppBaseDirectory + "Data\\TBData.db3;Pooling=true;FailIfMissing=false;Version=3;";
    private static SQLiteConnection conn = (SQLiteConnection) null;

    static TaobaoSQL()
    {
      TaobaoSQL.conn = new SQLiteConnection(TaobaoSQL.SQLiteConnectionString);
      TaobaoSQL.conn.Open();
    }

    public static DataTable MergeBuyerTrade(long userid, List<TBJS_MainOrder> MainOrders, int currentPage)
    {
      List<long> list1 = Enumerable.ToList<long>(Enumerable.Select<TBJS_MainOrder, long>((IEnumerable<TBJS_MainOrder>) MainOrders, (Func<TBJS_MainOrder, long>) (m => m.id)));
      List<TBJS_BuyerTradeData> list2 = (List<TBJS_BuyerTradeData>) null;
      using (SQLiteTransaction sqLiteTransaction = TaobaoSQL.conn.BeginTransaction())
      {
        try
        {
          using (SQLiteCommand command = TaobaoSQL.conn.CreateCommand())
          {
            command.CommandText = "DELETE FROM MainOrders WHERE userid = @userid and pageIndex = @pageIndex and id not in (" + string.Join<long>(",", (IEnumerable<long>) list1) + ")";
            command.Parameters.Add(new SQLiteParameter("userid", DbType.Int64));
            command.Parameters.Add(new SQLiteParameter("pageIndex", DbType.Int32));
            command.Parameters["userId"].Value = (object) userid;
            command.Parameters["pageIndex"].Value = (object) currentPage;
            command.ExecuteNonQuery();
          }
          using (SQLiteCommand command = TaobaoSQL.conn.CreateCommand())
          {
            command.CommandText = "SELECT id,editTradeStatus FROM MainOrders WHERE userid = @userid and id in (" + string.Join<long>(",", (IEnumerable<long>) list1) + ")";
            command.Parameters.Add(new SQLiteParameter("userid", DbType.Int64));
            command.Parameters["userId"].Value = (object) userid;
            SQLiteDataReader sqLiteDataReader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load((IDataReader) sqLiteDataReader);
            list2 = Enumerable.ToList<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) TaobaoSQL.ConvertTo<TBJS_BuyerTradeData>(table));
          }
          using (SQLiteCommand command1 = TaobaoSQL.conn.CreateCommand())
          {
            using (SQLiteCommand command2 = TaobaoSQL.conn.CreateCommand())
            {
              command1.CommandText = "INSERT INTO MainOrders(id, createDay, createTime,tradeStatus,tradeStatusText,isHide,editCreateDay,editTradeStatus,userid,pageIndex,sellerNickName) VALUES(@id, @createDay, @createTime,@tradeStatus,@tradeStatusText,@isHide,@editCreateDay,@editTradeStatus,@userid,@pageIndex,@sellerNickName)";
              command1.Parameters.Add(new SQLiteParameter("id", DbType.Int64));
              command1.Parameters.Add(new SQLiteParameter("createDay", DbType.String));
              command1.Parameters.Add(new SQLiteParameter("createTime", DbType.String));
              command1.Parameters.Add(new SQLiteParameter("tradeStatus", DbType.String));
              command1.Parameters.Add(new SQLiteParameter("tradeStatusText", DbType.String));
              command1.Parameters.Add(new SQLiteParameter("editCreateDay", DbType.String));
              command1.Parameters.Add(new SQLiteParameter("editTradeStatus", DbType.String));
              command1.Parameters.Add(new SQLiteParameter("isHide", DbType.Boolean));
              command1.Parameters.Add(new SQLiteParameter("userid", DbType.Int64));
              command1.Parameters.Add(new SQLiteParameter("pageIndex", DbType.Int64));
              command1.Parameters.Add(new SQLiteParameter("sellerNickName", DbType.String));
              command2.CommandText = "UPDATE MainOrders SET  tradeStatus = @tradeStatus, tradeStatusText = @tradeStatusText ,editTradeStatus=@editTradeStatus,pageIndex = @pageIndex WHERE userid = @userid and id = @id ";
              command2.Parameters.Add(new SQLiteParameter("userid", DbType.Int64));
              command2.Parameters.Add(new SQLiteParameter("id", DbType.Int64));
              command2.Parameters.Add(new SQLiteParameter("tradeStatus", DbType.String));
              command2.Parameters.Add(new SQLiteParameter("tradeStatusText", DbType.String));
              command2.Parameters.Add(new SQLiteParameter("editTradeStatus", DbType.String));
              command2.Parameters.Add(new SQLiteParameter("pageIndex", DbType.Int32));
              foreach (TBJS_MainOrder tbjsMainOrder in MainOrders)
              {
                TBJS_MainOrder order = tbjsMainOrder;
                string orderTradeStatusText = TBHelper.GetOrderTradeStatusText(order);
                TBJS_BuyerTradeData tbjsBuyerTradeData = list2.Find((Predicate<TBJS_BuyerTradeData>) (b => b.id == order.id));
                if (tbjsBuyerTradeData == null)
                {
                  command1.Parameters["id"].Value = (object) order.mainOrderId;
                  command1.Parameters["createDay"].Value = (object) order.orderInfo.createDay;
                  command1.Parameters["createTime"].Value = (object) order.orderInfo.createTime;
                  command1.Parameters["tradeStatus"].Value = (object) order.extra.tradeStatus;
                  command1.Parameters["tradeStatusText"].Value = (object) orderTradeStatusText;
                  command1.Parameters["editCreateDay"].Value = (object) order.orderInfo.createDay;
                  command1.Parameters["editTradeStatus"].Value = (object) orderTradeStatusText;
                  command1.Parameters["isHide"].Value = (object) false;
                  command1.Parameters["pageIndex"].Value = (object) currentPage;
                  command1.Parameters["userId"].Value = (object) userid;
                  command1.Parameters["sellerNickName"].Value = string.IsNullOrEmpty(order.seller.shopName) ? (object) order.seller.nick : (object) order.seller.shopName;
                  command1.ExecuteNonQuery();
                }
                else
                {
                  command2.Parameters["id"].Value = (object) order.mainOrderId;
                  command2.Parameters["tradeStatus"].Value = (object) order.extra.tradeStatus;
                  command2.Parameters["tradeStatusText"].Value = (object) orderTradeStatusText;
                  command2.Parameters["editTradeStatus"].Value = tbjsBuyerTradeData.editTradeStatus.Equals("交易成功") ? (object) tbjsBuyerTradeData.editTradeStatus : (object) orderTradeStatusText;
                  command2.Parameters["pageIndex"].Value = (object) currentPage;
                  command2.Parameters["userId"].Value = (object) userid;
                  command2.ExecuteNonQuery();
                }
              }
            }
          }
          sqLiteTransaction.Commit();
          return TaobaoSQL.GetDataTable(userid, (IList<long>) list1);
        }
        catch (SQLiteException ex)
        {
          sqLiteTransaction.Rollback();
          return (DataTable) null;
        }
        catch (ArgumentException ex)
        {
          sqLiteTransaction.Rollback();
          return (DataTable) null;
        }
        catch (Exception ex)
        {
          sqLiteTransaction.Rollback();
          return (DataTable) null;
        }
      }
    }

    public static void SynchronousBuyerTrade(long userid, List<TBJS_MainOrder> MainOrders, int currentPage)
    {
      List<long> list1 = Enumerable.ToList<long>(Enumerable.Select<TBJS_MainOrder, long>((IEnumerable<TBJS_MainOrder>) MainOrders, (Func<TBJS_MainOrder, long>) (m => m.id)));
      List<long> list2 = new List<long>();
      using (SQLiteTransaction sqLiteTransaction = TaobaoSQL.conn.BeginTransaction())
      {
        try
        {
          using (SQLiteCommand command = TaobaoSQL.conn.CreateCommand())
          {
            command.CommandText = "DELETE FROM MainOrders WHERE userid = @userid and pageIndex = @pageIndex";
            command.Parameters.Add(new SQLiteParameter("userid", DbType.Int64));
            command.Parameters.Add(new SQLiteParameter("pageIndex", DbType.Int32));
            command.Parameters["userId"].Value = (object) userid;
            command.Parameters["pageIndex"].Value = (object) currentPage;
            command.ExecuteNonQuery();
          }
          using (SQLiteCommand command = TaobaoSQL.conn.CreateCommand())
          {
            command.CommandText = "SELECT id FROM MainOrders WHERE userid = @userid and id in (" + string.Join<long>(",", (IEnumerable<long>) list1) + ")";
            command.Parameters.Add(new SQLiteParameter("userid", DbType.Int64));
            command.Parameters["userId"].Value = (object) userid;
            SQLiteDataReader sqLiteDataReader = command.ExecuteReader();
            while (sqLiteDataReader.Read())
              list2.Add(sqLiteDataReader.GetInt64(0));
          }
          using (SQLiteCommand command1 = TaobaoSQL.conn.CreateCommand())
          {
            using (SQLiteCommand command2 = TaobaoSQL.conn.CreateCommand())
            {
              command1.CommandText = "INSERT INTO MainOrders(id, createDay, createTime,tradeStatus,tradeStatusText,isHide,editCreateDay,editTradeStatus,userid,pageIndex,sellerNickName) VALUES(@id, @createDay, @createTime,@tradeStatus,@tradeStatusText,@isHide,@editCreateDay,@editTradeStatus,@userid,@pageIndex,@sellerNickName)";
              command1.Parameters.Add(new SQLiteParameter("id", DbType.Int64));
              command1.Parameters.Add(new SQLiteParameter("createDay", DbType.String));
              command1.Parameters.Add(new SQLiteParameter("createTime", DbType.String));
              command1.Parameters.Add(new SQLiteParameter("tradeStatus", DbType.String));
              command1.Parameters.Add(new SQLiteParameter("tradeStatusText", DbType.String));
              command1.Parameters.Add(new SQLiteParameter("editCreateDay", DbType.String));
              command1.Parameters.Add(new SQLiteParameter("editTradeStatus", DbType.String));
              command1.Parameters.Add(new SQLiteParameter("isHide", DbType.Boolean));
              command1.Parameters.Add(new SQLiteParameter("userid", DbType.Int64));
              command1.Parameters.Add(new SQLiteParameter("pageIndex", DbType.Int64));
              command1.Parameters.Add(new SQLiteParameter("sellerNickName", DbType.String));
              command2.CommandText = "UPDATE MainOrders SET  tradeStatus = @tradeStatus, tradeStatusText = @tradeStatusText,pageIndex = @pageIndex WHERE userid = @userid and id = @id ";
              command2.Parameters.Add(new SQLiteParameter("userid", DbType.Int64));
              command2.Parameters.Add(new SQLiteParameter("id", DbType.Int64));
              command2.Parameters.Add(new SQLiteParameter("tradeStatus", DbType.String));
              command2.Parameters.Add(new SQLiteParameter("tradeStatusText", DbType.String));
              command2.Parameters.Add(new SQLiteParameter("pageIndex", DbType.Int32));
              foreach (TBJS_MainOrder order in MainOrders)
              {
                string orderTradeStatusText = TBHelper.GetOrderTradeStatusText(order);
                if (list2.IndexOf(order.id) == -1)
                {
                  command1.Parameters["id"].Value = (object) order.mainOrderId;
                  command1.Parameters["createDay"].Value = (object) order.orderInfo.createDay;
                  command1.Parameters["createTime"].Value = (object) order.orderInfo.createTime;
                  command1.Parameters["tradeStatus"].Value = (object) order.extra.tradeStatus;
                  command1.Parameters["tradeStatusText"].Value = (object) orderTradeStatusText;
                  command1.Parameters["editCreateDay"].Value = (object) order.orderInfo.createDay;
                  command1.Parameters["editTradeStatus"].Value = (object) orderTradeStatusText;
                  command1.Parameters["isHide"].Value = (object) false;
                  command1.Parameters["pageIndex"].Value = (object) currentPage;
                  command1.Parameters["userId"].Value = (object) userid;
                  command1.Parameters["sellerNickName"].Value = string.IsNullOrEmpty(order.seller.shopName) ? (object) order.seller.nick : (object) order.seller.shopName;
                  command1.ExecuteNonQuery();
                }
                else
                {
                  command2.Parameters["id"].Value = (object) order.mainOrderId;
                  command2.Parameters["tradeStatus"].Value = (object) order.extra.tradeStatus;
                  command2.Parameters["tradeStatusText"].Value = (object) orderTradeStatusText;
                  command2.Parameters["pageIndex"].Value = (object) currentPage;
                  command2.Parameters["userId"].Value = (object) userid;
                  command2.ExecuteNonQuery();
                }
              }
            }
          }
          sqLiteTransaction.Commit();
        }
        catch (SQLiteException ex)
        {
          sqLiteTransaction.Rollback();
        }
        catch (ArgumentException ex)
        {
          sqLiteTransaction.Rollback();
        }
        catch (Exception ex)
        {
          sqLiteTransaction.Rollback();
        }
      }
    }

    public static DataTable GetDataTable(long userid)
    {
      try
      {
        SQLiteCommand command = TaobaoSQL.conn.CreateCommand();
        command.CommandText = "SELECT id,editCreateDay,editTradeStatus,isHide,sellerNickName FROM MainOrders WHERE userid = @userid";
        command.Parameters.Add(new SQLiteParameter("userid", DbType.String));
        command.Parameters["userid"].Value = (object) userid;
        SQLiteDataReader sqLiteDataReader = command.ExecuteReader();
        DataTable dataTable = new DataTable();
        dataTable.Load((IDataReader) sqLiteDataReader);
        sqLiteDataReader.Close();
        return dataTable;
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public static DataTable GetDataTableByPageIndex(long userid, int pageIndex)
    {
      DataTable dataTable = new DataTable();
      try
      {
        SQLiteCommand command = TaobaoSQL.conn.CreateCommand();
        command.CommandText = "SELECT id,editCreateDay,editTradeStatus,isHide,sellerNickName FROM MainOrders WHERE userid = @userid and pageIndex = @pageIndex";
        command.Parameters.Add(new SQLiteParameter("userid", DbType.String));
        command.Parameters.Add(new SQLiteParameter("pageIndex", DbType.Int32));
        command.Parameters["userid"].Value = (object) userid;
        command.Parameters["pageIndex"].Value = (object) pageIndex;
        SQLiteDataReader sqLiteDataReader = command.ExecuteReader();
        dataTable.Load((IDataReader) sqLiteDataReader);
        sqLiteDataReader.Close();
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
      return dataTable;
    }

    public static DataTable GetDataTable(long userid, IList<long> ids)
    {
      DataTable dataTable = new DataTable();
      try
      {
        SQLiteCommand command = TaobaoSQL.conn.CreateCommand();
        command.CommandText = "SELECT id,editCreateDay,editTradeStatus,isHide,sellerNickName FROM MainOrders WHERE userid = @userid and id in (" + string.Join<long>(",", (IEnumerable<long>) ids) + ") order by createTime desc";
        command.Parameters.Add(new SQLiteParameter("userid", DbType.String));
        command.Parameters["userid"].Value = (object) userid;
        SQLiteDataReader sqLiteDataReader = command.ExecuteReader();
        dataTable.Load((IDataReader) sqLiteDataReader);
        sqLiteDataReader.Close();
        return dataTable;
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public static List<TBJS_BuyerTradeData> GetDataTableToList(long userid, int pageIndex = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        stringBuilder.Append("SELECT * FROM MainOrders WHERE userid = @userid");
        if (pageIndex > 0)
          stringBuilder.Append(" and pageIndex = @pageIndex");
        SQLiteCommand command = TaobaoSQL.conn.CreateCommand();
        command.CommandText = stringBuilder.ToString();
        command.Parameters.Add(new SQLiteParameter("userid", DbType.String));
        command.Parameters["userid"].Value = (object) userid;
        if (pageIndex > 0)
        {
          command.Parameters.Add(new SQLiteParameter("pageIndex", DbType.Int32));
          command.Parameters["pageIndex"].Value = (object) pageIndex;
        }
        SQLiteDataReader sqLiteDataReader = command.ExecuteReader();
        DataTable table = new DataTable();
        table.Load((IDataReader) sqLiteDataReader);
        sqLiteDataReader.Close();
        return Enumerable.ToList<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) TaobaoSQL.ConvertTo<TBJS_BuyerTradeData>(table));
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public static List<TBJS_BuyerTradeData> GetDataTableToList(long userid, IList<long> ids, int pageIndex = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        SQLiteCommand command = TaobaoSQL.conn.CreateCommand();
        stringBuilder.Append("SELECT * FROM MainOrders WHERE userid = @userid and id in (" + string.Join<long>(",", (IEnumerable<long>) ids) + ")");
        if (pageIndex > 0)
          stringBuilder.Append(" and pageIndex = @pageIndex");
        command.CommandText = stringBuilder.ToString();
        command.Parameters.Add(new SQLiteParameter("userid", DbType.String));
        command.Parameters["userid"].Value = (object) userid;
        if (pageIndex > 0)
        {
          command.Parameters.Add(new SQLiteParameter("pageIndex", DbType.Int32));
          command.Parameters["pageIndex"].Value = (object) pageIndex;
        }
        SQLiteDataReader sqLiteDataReader = command.ExecuteReader();
        DataTable table = new DataTable();
        table.Load((IDataReader) sqLiteDataReader);
        sqLiteDataReader.Close();
        return Enumerable.ToList<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) TaobaoSQL.ConvertTo<TBJS_BuyerTradeData>(table));
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public static List<TBJS_BuyerTradeData> GetStatisticDataToList(long userid, int StatisticCount = 100)
    {
      StringBuilder stringBuilder = new StringBuilder();
      using (SQLiteCommand command = TaobaoSQL.conn.CreateCommand())
      {
        try
        {
          stringBuilder.AppendFormat("SELECT * FROM MainOrders WHERE userid =  @userid ORDER BY createTime Desc limit 0,{1}", (object) userid, (object) StatisticCount);
          command.CommandText = stringBuilder.ToString();
          command.Parameters.Add(new SQLiteParameter("userid", DbType.String));
          command.Parameters["userid"].Value = (object) userid;
          SQLiteDataReader sqLiteDataReader = command.ExecuteReader();
          DataTable table = new DataTable();
          table.Load((IDataReader) sqLiteDataReader);
          sqLiteDataReader.Close();
          return Enumerable.ToList<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) TaobaoSQL.ConvertTo<TBJS_BuyerTradeData>(table));
        }
        catch (Exception ex)
        {
          throw new Exception(ex.Message);
        }
      }
    }

    public static TBJS_BuyerTradeData GetDataToModel(long userid, long id)
    {
      IList<long> ids = (IList<long>) new List<long>();
      ids.Add(id);
      return Enumerable.FirstOrDefault<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) TaobaoSQL.GetDataTableToList(userid, ids, 0));
    }

    public static TBJS_BuyerTradeData GetDataToModelById(long userid, long id)
    {
      if (id == 0L)
        return (TBJS_BuyerTradeData) null;
      try
      {
        SQLiteCommand command = TaobaoSQL.conn.CreateCommand();
        command.CommandText = "SELECT *  FROM MainOrders WHERE userid = @userid and id = @id";
        command.Parameters.Add(new SQLiteParameter("userid", DbType.String));
        command.Parameters.Add(new SQLiteParameter("id", DbType.Int64));
        command.Parameters["userid"].Value = (object) userid;
        command.Parameters["id"].Value = (object) id;
        SQLiteDataReader sqLiteDataReader = command.ExecuteReader();
        DataTable table = new DataTable();
        table.Load((IDataReader) sqLiteDataReader);
        sqLiteDataReader.Close();
        return Enumerable.FirstOrDefault<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) TaobaoSQL.ConvertTo<TBJS_BuyerTradeData>(table));
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public static TBJS_BuyerTradeData GetDataToModelByCreateTime(long userid, DateTime gmtBizCreate)
    {
      string str = gmtBizCreate.ToString("yyyy-MM-dd HH:mm:ss");
      try
      {
        SQLiteCommand command = TaobaoSQL.conn.CreateCommand();
        command.CommandText = "SELECT *  FROM MainOrders WHERE userid = @userid and createTime = @createTime";
        command.Parameters.Add(new SQLiteParameter("userid", DbType.String));
        command.Parameters.Add(new SQLiteParameter("createTime", DbType.String));
        command.Parameters["userid"].Value = (object) userid;
        command.Parameters["createTime"].Value = (object) str;
        SQLiteDataReader sqLiteDataReader = command.ExecuteReader();
        DataTable table = new DataTable();
        table.Load((IDataReader) sqLiteDataReader);
        sqLiteDataReader.Close();
        return Enumerable.FirstOrDefault<TBJS_BuyerTradeData>((IEnumerable<TBJS_BuyerTradeData>) TaobaoSQL.ConvertTo<TBJS_BuyerTradeData>(table));
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public static DataTable GetDataTableById(string userid, long id)
    {
      DataTable dataTable = new DataTable();
      try
      {
        SQLiteCommand command = TaobaoSQL.conn.CreateCommand();
        command.CommandText = "SELECT id,editCreateDay,editTradeStatus,isHide,sellerNickName FROM MainOrders WHERE userid = @userid and id = @id";
        command.Parameters.Add(new SQLiteParameter("userid", DbType.String));
        command.Parameters.Add(new SQLiteParameter("id", DbType.Int64));
        command.Parameters["userid"].Value = (object) userid;
        command.Parameters["id"].Value = (object) id;
        SQLiteDataReader sqLiteDataReader = command.ExecuteReader();
        dataTable.Load((IDataReader) sqLiteDataReader);
        sqLiteDataReader.Close();
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
      return dataTable;
    }

    public static void UpdateTradeInfo(string userid, long id, bool isHide, string editCreateDay, string editTradeStatus)
    {
        new DataTable();
        try
        {
            SQLiteCommand sQLiteCommand = TaobaoSQL.conn.CreateCommand();
            sQLiteCommand.CommandText = "UPDATE MainOrders SET  isHide = @isHide,editCreateDay=@editCreateDay,editTradeStatus=@editTradeStatus WHERE userid = @userid and id = @id ";
            sQLiteCommand.Parameters.Add(new SQLiteParameter("userid", DbType.String));
            sQLiteCommand.Parameters.Add(new SQLiteParameter("id", DbType.Int64));
            sQLiteCommand.Parameters.Add(new SQLiteParameter("isHide", DbType.Boolean));
            sQLiteCommand.Parameters.Add(new SQLiteParameter("editCreateDay", DbType.String));
            sQLiteCommand.Parameters.Add(new SQLiteParameter("editTradeStatus", DbType.String));
            sQLiteCommand.Parameters["userId"].Value = userid;
            sQLiteCommand.Parameters["id"].Value = id;
            sQLiteCommand.Parameters["isHide"].Value = isHide;
            sQLiteCommand.Parameters["editCreateDay"].Value = editCreateDay;
            sQLiteCommand.Parameters["editTradeStatus"].Value = editTradeStatus;
            sQLiteCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public static DataTable ResetSingleBuyerTrade(long userid, long id)
    {
      try
      {
        SQLiteCommand command = TaobaoSQL.conn.CreateCommand();
        command.CommandText = "UPDATE MainOrders SET  isHide = 0,editCreateDay=CreateDay,editTradeStatus=tradeStatusText WHERE userid = @userid and id = @id ";
        command.Parameters.Add(new SQLiteParameter("userid", DbType.Int64));
        command.Parameters.Add(new SQLiteParameter("id", DbType.Int64));
        command.Parameters["userId"].Value = (object) userid;
        command.Parameters["id"].Value = (object) id;
        command.ExecuteNonQuery();
        IList<long> ids = (IList<long>) new List<long>();
        ids.Add(id);
        return TaobaoSQL.GetDataTable(userid, ids);
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public static int DeleteBuyerTrade(long userid, long id)
    {
      try
      {
        SQLiteCommand command = TaobaoSQL.conn.CreateCommand();
        command.CommandText = "DELETE FROM MainOrders WHERE userid = @userid and id = @id ";
        command.Parameters.Add(new SQLiteParameter("userid", DbType.Int64));
        command.Parameters.Add(new SQLiteParameter("id", DbType.Int64));
        command.Parameters["userId"].Value = (object) userid;
        command.Parameters["id"].Value = (object) id;
        return command.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public static DataTable OneKeyAllHandle(long userid, IList<long> ids, string TradeStatusText)
    {
      DataTable dataTable = new DataTable();
      try
      {
        SQLiteCommand command = TaobaoSQL.conn.CreateCommand();
        command.CommandText = "UPDATE MainOrders SET editTradeStatus=@editTradeStatus WHERE  userid = @userid and id in (" + string.Join<long>(",", (IEnumerable<long>) ids) + ") and  TradeStatusText =@TradeStatusText ";
        command.Parameters.Add(new SQLiteParameter("userid", DbType.String));
        command.Parameters.Add(new SQLiteParameter("editTradeStatus", DbType.String));
        command.Parameters.Add(new SQLiteParameter("TradeStatusText", DbType.String));
        command.Parameters["userId"].Value = (object) userid;
        command.Parameters["editTradeStatus"].Value = (object) "交易成功";
        command.Parameters["TradeStatusText"].Value = (object) TradeStatusText;
        command.ExecuteNonQuery();
        return TaobaoSQL.GetDataTable(userid, ids);
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public static DataTable OneKeyAllHide(long userid, IList<long> ids)
    {
      DataTable dataTable = new DataTable();
      try
      {
        SQLiteCommand command = TaobaoSQL.conn.CreateCommand();
        command.CommandText = "UPDATE MainOrders SET editTradeStatus=@editTradeStatus,isHide = 1 WHERE  userid = @userid and id in (" + string.Join<long>(",", (IEnumerable<long>) ids) + ")";
        command.Parameters.Add(new SQLiteParameter("userid", DbType.String));
        command.Parameters.Add(new SQLiteParameter("editTradeStatus", DbType.String));
        command.Parameters["userId"].Value = (object) userid;
        command.Parameters["editTradeStatus"].Value = (object) "隐藏";
        command.ExecuteNonQuery();
        return TaobaoSQL.GetDataTable(userid, ids);
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public static DataTable OneKeyAllReset(long userid, IList<long> ids)
    {
      DataTable dataTable = new DataTable();
      try
      {
        SQLiteCommand command = TaobaoSQL.conn.CreateCommand();
        command.CommandText = "UPDATE MainOrders SET  isHide = 0,editCreateDay=CreateDay,editTradeStatus=tradeStatusText WHERE userid = @userid and id in (" + string.Join<long>(",", (IEnumerable<long>) ids) + ") ";
        command.Parameters.Add(new SQLiteParameter("userid", DbType.String));
        command.Parameters["userId"].Value = (object) userid;
        command.ExecuteNonQuery();
        return TaobaoSQL.GetDataTable(userid, ids);
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public static DataTable ClearDataByUserId(long userid)
    {
      try
      {
        SQLiteCommand command = TaobaoSQL.conn.CreateCommand();
        command.CommandText = "DELETE FROM MainOrders WHERE userid = @userid ";
        command.Parameters.Add(new SQLiteParameter("userid", DbType.Int64));
        command.Parameters["userId"].Value = (object) userid;
        command.ExecuteNonQuery();
        return TaobaoSQL.GetDataTable(userid);
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
      }
    }

    public static IList<T> ConvertTo<T>(DataTable table)
    {
      if (table == null)
        return (IList<T>) null;
      List<DataRow> list = new List<DataRow>();
      foreach (DataRow dataRow in (InternalDataCollectionBase) table.Rows)
        list.Add(dataRow);
      return TaobaoSQL.ConvertTo<T>((IList<DataRow>) list);
    }

    public static IList<T> ConvertTo<T>(IList<DataRow> rows)
    {
      IList<T> list = (IList<T>) null;
      if (rows != null)
      {
        list = (IList<T>) new List<T>();
        foreach (DataRow row in (IEnumerable<DataRow>) rows)
        {
          T obj = TaobaoSQL.CreateItem<T>(row);
          list.Add(obj);
        }
      }
      return list;
    }

    public static T CreateItem<T>(DataRow row)
    {
      T obj1 = default (T);
      if (row != null)
      {
        obj1 = Activator.CreateInstance<T>();
        foreach (DataColumn dataColumn in (InternalDataCollectionBase) row.Table.Columns)
        {
          PropertyInfo property = obj1.GetType().GetProperty(dataColumn.ColumnName);
          try
          {
            object obj2 = row[dataColumn.ColumnName];
            property.SetValue((object) obj1, obj2, (object[]) null);
          }
          catch
          {
          }
        }
      }
      return obj1;
    }
  }
}
