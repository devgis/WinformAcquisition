
// Type: TobaoHelper.SQLiteHelper
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.Collections;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace TobaoHelper
{
  public class SQLiteHelper
  {
    private SQLiteHelper()
    {
    }

    public static SQLiteCommand CreateCommand(SQLiteConnection connection, string commandText, params SQLiteParameter[] commandParameters)
    {
      SQLiteCommand sqLiteCommand = new SQLiteCommand(commandText, connection);
      if (commandParameters.Length > 0)
      {
        foreach (SQLiteParameter parameter in commandParameters)
          sqLiteCommand.Parameters.Add(parameter);
      }
      return sqLiteCommand;
    }

    public static SQLiteCommand CreateCommand(string connectionString, string commandText, params SQLiteParameter[] commandParameters)
    {
      SQLiteConnection connection = new SQLiteConnection(connectionString);
      SQLiteCommand sqLiteCommand = new SQLiteCommand(commandText, connection);
      if (commandParameters.Length > 0)
      {
        foreach (SQLiteParameter parameter in commandParameters)
          sqLiteCommand.Parameters.Add(parameter);
      }
      return sqLiteCommand;
    }

    public static SQLiteParameter CreateParameter(string parameterName, DbType parameterType, object parameterValue)
    {
      SQLiteParameter sqLiteParameter = new SQLiteParameter();
      sqLiteParameter.DbType = parameterType;
      sqLiteParameter.ParameterName = parameterName;
      sqLiteParameter.Value = parameterValue;
      return sqLiteParameter;
    }

    public static DataSet ExecuteDataSet(string connectionString, string commandText, object[] paramList)
    {
      SQLiteConnection sqLiteConnection = new SQLiteConnection(connectionString);
      SQLiteCommand command = sqLiteConnection.CreateCommand();
      command.CommandText = commandText;
      if (paramList != null)
        SQLiteHelper.AttachParameters(command, commandText, paramList);
      DataSet dataSet = new DataSet();
      if (sqLiteConnection.State == ConnectionState.Closed)
        sqLiteConnection.Open();
      SQLiteDataAdapter sqLiteDataAdapter = new SQLiteDataAdapter(command);
      sqLiteDataAdapter.Fill(dataSet);
      sqLiteDataAdapter.Dispose();
      command.Dispose();
      sqLiteConnection.Close();
      return dataSet;
    }

    public static DataSet ExecuteDataSet(SQLiteConnection cn, string commandText, object[] paramList)
    {
      SQLiteCommand command = cn.CreateCommand();
      command.CommandText = commandText;
      if (paramList != null)
        SQLiteHelper.AttachParameters(command, commandText, paramList);
      DataSet dataSet = new DataSet();
      if (cn.State == ConnectionState.Closed)
        cn.Open();
      SQLiteDataAdapter sqLiteDataAdapter = new SQLiteDataAdapter(command);
      sqLiteDataAdapter.Fill(dataSet);
      sqLiteDataAdapter.Dispose();
      command.Dispose();
      cn.Close();
      return dataSet;
    }

    public static DataSet ExecuteDataset(SQLiteCommand cmd)
    {
      if (cmd.Connection.State == ConnectionState.Closed)
        cmd.Connection.Open();
      DataSet dataSet = new DataSet();
      SQLiteDataAdapter sqLiteDataAdapter = new SQLiteDataAdapter(cmd);
      sqLiteDataAdapter.Fill(dataSet);
      sqLiteDataAdapter.Dispose();
      cmd.Connection.Close();
      cmd.Dispose();
      return dataSet;
    }

    public static DataSet ExecuteDataset(SQLiteTransaction transaction, string commandText, params SQLiteParameter[] commandParameters)
    {
      if (transaction == null)
        throw new ArgumentNullException("transaction");
      if (transaction != null && transaction.Connection == null)
        throw new ArgumentException("The transaction was rolled back or committed, please provide an open transaction.", "transaction");
      IDbCommand dbCommand = (IDbCommand) transaction.Connection.CreateCommand();
      dbCommand.CommandText = commandText;
      foreach (SQLiteParameter sqLiteParameter in commandParameters)
        dbCommand.Parameters.Add((object) sqLiteParameter);
      if (transaction.Connection.State == ConnectionState.Closed)
        transaction.Connection.Open();
      return SQLiteHelper.ExecuteDataset((SQLiteCommand) dbCommand);
    }

    public static DataSet ExecuteDataset(SQLiteTransaction transaction, string commandText, object[] commandParameters)
    {
      if (transaction == null)
        throw new ArgumentNullException("transaction");
      if (transaction != null && transaction.Connection == null)
        throw new ArgumentException("The transaction was rolled back or committed,                                                          please provide an open transaction.", "transaction");
      IDbCommand dbCommand = (IDbCommand) transaction.Connection.CreateCommand();
      dbCommand.CommandText = commandText;
      SQLiteHelper.AttachParameters((SQLiteCommand) dbCommand, dbCommand.CommandText, commandParameters);
      if (transaction.Connection.State == ConnectionState.Closed)
        transaction.Connection.Open();
      return SQLiteHelper.ExecuteDataset((SQLiteCommand) dbCommand);
    }

    public static void UpdateDataset(SQLiteCommand insertCommand, SQLiteCommand deleteCommand, SQLiteCommand updateCommand, DataSet dataSet, string tableName)
    {
      if (insertCommand == null)
        throw new ArgumentNullException("insertCommand");
      if (deleteCommand == null)
        throw new ArgumentNullException("deleteCommand");
      if (updateCommand == null)
        throw new ArgumentNullException("updateCommand");
      if (tableName == null || tableName.Length == 0)
        throw new ArgumentNullException("tableName");
      using (SQLiteDataAdapter sqLiteDataAdapter = new SQLiteDataAdapter())
      {
        sqLiteDataAdapter.UpdateCommand = updateCommand;
        sqLiteDataAdapter.InsertCommand = insertCommand;
        sqLiteDataAdapter.DeleteCommand = deleteCommand;
        sqLiteDataAdapter.Update(dataSet, tableName);
        dataSet.AcceptChanges();
      }
    }

    public static IDataReader ExecuteReader(SQLiteCommand cmd, string commandText, object[] paramList)
    {
      if (cmd.Connection == null)
        throw new ArgumentException("Command must have live connection attached.", "cmd");
      cmd.CommandText = commandText;
      SQLiteHelper.AttachParameters(cmd, commandText, paramList);
      if (cmd.Connection.State == ConnectionState.Closed)
        cmd.Connection.Open();
      return (IDataReader) cmd.ExecuteReader(CommandBehavior.CloseConnection);
    }

    public static int ExecuteNonQuery(string connectionString, string commandText, params object[] paramList)
    {
      SQLiteConnection sqLiteConnection = new SQLiteConnection(connectionString);
      SQLiteCommand command = sqLiteConnection.CreateCommand();
      command.CommandText = commandText;
      SQLiteHelper.AttachParameters(command, commandText, paramList);
      if (sqLiteConnection.State == ConnectionState.Closed)
        sqLiteConnection.Open();
      int num = command.ExecuteNonQuery();
      command.Dispose();
      sqLiteConnection.Close();
      return num;
    }

    public static int ExecuteNonQuery(SQLiteConnection cn, string commandText, params object[] paramList)
    {
      SQLiteCommand command = cn.CreateCommand();
      command.CommandText = commandText;
      SQLiteHelper.AttachParameters(command, commandText, paramList);
      if (cn.State == ConnectionState.Closed)
        cn.Open();
      int num = command.ExecuteNonQuery();
      command.Dispose();
      cn.Close();
      return num;
    }

    public static int ExecuteNonQuery(SQLiteTransaction transaction, string commandText, params object[] paramList)
    {
      if (transaction == null)
        throw new ArgumentNullException("transaction");
      if (transaction != null && transaction.Connection == null)
        throw new ArgumentException("The transaction was rolled back or committed,                                                        please provide an open transaction.", "transaction");
      IDbCommand dbCommand = (IDbCommand) transaction.Connection.CreateCommand();
      dbCommand.CommandText = commandText;
      SQLiteHelper.AttachParameters((SQLiteCommand) dbCommand, dbCommand.CommandText, paramList);
      if (transaction.Connection.State == ConnectionState.Closed)
        transaction.Connection.Open();
      int num = dbCommand.ExecuteNonQuery();
      dbCommand.Dispose();
      return num;
    }

    public static int ExecuteNonQuery(IDbCommand cmd)
    {
      if (cmd.Connection.State == ConnectionState.Closed)
        cmd.Connection.Open();
      int num = cmd.ExecuteNonQuery();
      cmd.Connection.Close();
      cmd.Dispose();
      return num;
    }

    public static object ExecuteScalar(string connectionString, string commandText, params object[] paramList)
    {
      SQLiteConnection sqLiteConnection = new SQLiteConnection(connectionString);
      SQLiteCommand command = sqLiteConnection.CreateCommand();
      command.CommandText = commandText;
      SQLiteHelper.AttachParameters(command, commandText, paramList);
      if (sqLiteConnection.State == ConnectionState.Closed)
        sqLiteConnection.Open();
      object obj = command.ExecuteScalar();
      command.Dispose();
      sqLiteConnection.Close();
      return obj;
    }

    public static XmlReader ExecuteXmlReader(IDbCommand command)
    {
      if (command.Connection.State != ConnectionState.Open)
        command.Connection.Open();
      SQLiteDataAdapter sqLiteDataAdapter = new SQLiteDataAdapter((SQLiteCommand) command);
      DataSet dataSet = new DataSet();
      sqLiteDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
      sqLiteDataAdapter.Fill(dataSet);
      StringReader stringReader = new StringReader(dataSet.GetXml());
      command.Connection.Close();
      return (XmlReader) new XmlTextReader((TextReader) stringReader);
    }

    private static SQLiteParameterCollection AttachParameters(SQLiteCommand cmd, string commandText, params object[] paramList)
    {
      if (paramList == null || paramList.Length == 0)
        return (SQLiteParameterCollection) null;
      SQLiteParameterCollection parameters = cmd.Parameters;
      MatchCollection matchCollection = new Regex("(@)\\S*(.*?)\\b", RegexOptions.IgnoreCase).Matches(commandText.Substring(commandText.IndexOf("@")).Replace(",", " ,"));
      string[] strArray = new string[matchCollection.Count];
      int index1 = 0;
      foreach (Match match in matchCollection)
      {
        strArray[index1] = match.Value;
        ++index1;
      }
      int index2 = 0;
      foreach (object obj in paramList)
      {
        Type type = obj.GetType();
        SQLiteParameter parameter = new SQLiteParameter();
        switch (type.ToString())
        {
          case "DBNull":
          case "Char":
          case "SByte":
          case "UInt16":
          case "UInt32":
          case "UInt64":
            throw new SystemException("Invalid data type");
          case "System.String":
            parameter.DbType = DbType.String;
            parameter.ParameterName = strArray[index2];
            parameter.Value = (object) (string) paramList[index2];
            parameters.Add(parameter);
            break;
          case "System.Byte[]":
            parameter.DbType = DbType.Binary;
            parameter.ParameterName = strArray[index2];
            parameter.Value = (object) (byte[]) paramList[index2];
            parameters.Add(parameter);
            break;
          case "System.Int32":
            parameter.DbType = DbType.Int32;
            parameter.ParameterName = strArray[index2];
            parameter.Value = (object) (int) paramList[index2];
            parameters.Add(parameter);
            break;
          case "System.Boolean":
            parameter.DbType = DbType.Boolean;
            parameter.ParameterName = strArray[index2];
            parameter.Value = (object)((bool)paramList[index2]);
            parameters.Add(parameter);
            break;
          case "System.DateTime":
            parameter.DbType = DbType.DateTime;
            parameter.ParameterName = strArray[index2];
            parameter.Value = (object) Convert.ToDateTime(paramList[index2]);
            parameters.Add(parameter);
            break;
          case "System.Double":
            parameter.DbType = DbType.Double;
            parameter.ParameterName = strArray[index2];
            parameter.Value = (object) Convert.ToDouble(paramList[index2]);
            parameters.Add(parameter);
            break;
          case "System.Decimal":
            parameter.DbType = DbType.Decimal;
            parameter.ParameterName = strArray[index2];
            parameter.Value = (object) Convert.ToDecimal(paramList[index2]);
            break;
          case "System.Guid":
            parameter.DbType = DbType.Guid;
            parameter.ParameterName = strArray[index2];
            parameter.Value = (object) (Guid) paramList[index2];
            break;
          case "System.Object":
            parameter.DbType = DbType.Object;
            parameter.ParameterName = strArray[index2];
            parameter.Value = paramList[index2];
            parameters.Add(parameter);
            break;
          default:
            throw new SystemException("Value is of unknown data type");
        }
        ++index2;
      }
      return parameters;
    }

    public static int ExecuteNonQueryTypedParams(IDbCommand command, DataRow dataRow)
    {
      int num;
      if (dataRow != null && dataRow.ItemArray.Length > 0)
      {
        SQLiteHelper.AssignParameterValues(command.Parameters, dataRow);
        num = SQLiteHelper.ExecuteNonQuery(command);
      }
      else
        num = SQLiteHelper.ExecuteNonQuery(command);
      return num;
    }

    protected internal static void AssignParameterValues(IDataParameterCollection commandParameters, DataRow dataRow)
    {
      if (commandParameters == null || dataRow == null)
        return;
      DataColumnCollection columns = dataRow.Table.Columns;
      int num = 0;
      foreach (IDataParameter dataParameter in (IEnumerable) commandParameters)
      {
        if (dataParameter.ParameterName == null || dataParameter.ParameterName.Length <= 1)
          throw new InvalidOperationException(string.Format("Please provide a valid parameter name on the parameter #{0},                            the ParameterName property has the following value: '{1}'.", (object) num, (object) dataParameter.ParameterName));
        if (columns.Contains(dataParameter.ParameterName))
          dataParameter.Value = dataRow[dataParameter.ParameterName];
        else if (columns.Contains(dataParameter.ParameterName.Substring(1)))
          dataParameter.Value = dataRow[dataParameter.ParameterName.Substring(1)];
        ++num;
      }
    }

    protected void AssignParameterValues(IDataParameter[] commandParameters, DataRow dataRow)
    {
      if (commandParameters == null || dataRow == null)
        return;
      DataColumnCollection columns = dataRow.Table.Columns;
      int num = 0;
      foreach (IDataParameter dataParameter in commandParameters)
      {
        if (dataParameter.ParameterName == null || dataParameter.ParameterName.Length <= 1)
          throw new InvalidOperationException(string.Format("Please provide a valid parameter name on the parameter #{0}, the ParameterName property has the following value: '{1}'.", (object) num, (object) dataParameter.ParameterName));
        if (columns.Contains(dataParameter.ParameterName))
          dataParameter.Value = dataRow[dataParameter.ParameterName];
        else if (columns.Contains(dataParameter.ParameterName.Substring(1)))
          dataParameter.Value = dataRow[dataParameter.ParameterName.Substring(1)];
        ++num;
      }
    }

    protected void AssignParameterValues(IDataParameter[] commandParameters, params object[] parameterValues)
    {
      if (commandParameters == null || parameterValues == null)
        return;
      if (commandParameters.Length != parameterValues.Length)
        throw new ArgumentException("Parameter count does not match Parameter Value count.");
      int index1 = 0;
      int length = commandParameters.Length;
      int index2 = 0;
      for (; index1 < length; ++index1)
      {
        if (commandParameters[index1].Direction != ParameterDirection.ReturnValue)
        {
          if (parameterValues[index2] is IDataParameter)
          {
            IDataParameter dataParameter = (IDataParameter) parameterValues[index2];
            if (dataParameter.Direction == ParameterDirection.ReturnValue)
              dataParameter = (IDataParameter) parameterValues[++index2];
            commandParameters[index1].Value = dataParameter.Value != null ? dataParameter.Value : (object) DBNull.Value;
          }
          else
            commandParameters[index1].Value = parameterValues[index2] != null ? parameterValues[index2] : (object) DBNull.Value;
          ++index2;
        }
      }
    }
  }
}
