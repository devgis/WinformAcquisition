
// Type: TrandExp.DotNet.Utils.IniFile
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace TrandExp.DotNet.Utils
{
  public class IniFile
  {
    private string _filePath;

    public IniFile(string FilePath)
    {
      this._filePath = AppDomain.CurrentDomain.BaseDirectory + FilePath;
    }

    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

    public void WriteString(string Section, string Ident, string Value)
    {
      IniFile.WritePrivateProfileString(Section, Ident, Value, this._filePath);
    }

    public string ReadString(string Section, string Ident, string Default)
    {
      StringBuilder retVal = new StringBuilder((int) ushort.MaxValue);
      IniFile.GetPrivateProfileString(Section, Ident, Default, retVal, retVal.MaxCapacity, this._filePath);
      return retVal.ToString();
    }

    public int ReadInteger(string Section, string Ident, int Default)
    {
      string str = this.ReadString(Section, Ident, Convert.ToString(Default));
      try
      {
        return Convert.ToInt32(str);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return Default;
      }
    }

    public void WriteInteger(string Section, string Ident, int Value)
    {
      this.WriteString(Section, Ident, Value.ToString());
    }

    public bool ReadBool(string Section, string Ident, bool Default)
    {
      try
      {
        return Convert.ToBoolean(this.ReadString(Section, Ident, Convert.ToString(Default)));
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return Default;
      }
    }

    public void WriteBool(string Section, string Ident, bool Value)
    {
      this.WriteString(Section, Ident, Convert.ToString(Value));
    }
  }
}
