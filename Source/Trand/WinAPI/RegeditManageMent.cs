
// Type: Trand.WinAPI.RegeditManageMent
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using Microsoft.Win32;

namespace Trand.WinAPI
{
  public class RegeditManageMent
  {
    private string regeditPath = "";
    private RegistryKey regeditKey;

    public string RegeditPath
    {
      get
      {
        return this.regeditPath;
      }
      set
      {
        this.regeditPath = value;
      }
    }

    public RegistryKey RegeditKey
    {
      get
      {
        return this.regeditKey;
      }
      set
      {
        this.regeditKey = value;
      }
    }

    public RegeditManageMent()
    {
      this.regeditPath = "";
    }

    public void SetValue(string path, RegistryKey key, string data1, string data2)
    {
      this.regeditPath = path;
      this.regeditKey = key;
      this.regeditKey.OpenSubKey(this.regeditPath, true).SetValue(data1, (object) data2);
    }

    public void SetValue(string data1, string data2)
    {
      if (this.regeditKey == null || this.regeditPath == "")
        return;
      this.regeditKey.OpenSubKey(this.regeditPath, true).SetValue(data1, (object) data2);
    }

    public void RegeditCreateSubKey(string path, RegistryKey key, string SubKeyName)
    {
      this.regeditPath = path;
      this.regeditKey = key;
      this.regeditKey.OpenSubKey(this.regeditPath, true).CreateSubKey(SubKeyName);
    }

    public void RegeditCreateSubKey(string SubKeyName)
    {
      if (this.regeditKey == null || this.regeditPath == "")
        return;
      this.regeditKey.OpenSubKey(this.regeditPath, true).CreateSubKey(SubKeyName);
    }

    public void CreateDWord(string name1, string name2, int value)
    {
      if (this.regeditKey == null || this.regeditPath == "")
        return;
      this.regeditKey.OpenSubKey(this.regeditPath, true).CreateSubKey(name1).SetValue(name2, (object) value, RegistryValueKind.DWord);
    }

    public void CreateString(string name1, string name2, string value)
    {
      if (this.regeditKey == null)
        return;
      this.regeditKey.OpenSubKey(this.regeditPath, true).CreateSubKey(name1).SetValue(name2, (object) value, RegistryValueKind.String);
    }

    public void DeleteValue(string name)
    {
      if (this.regeditKey == null || this.regeditPath == "")
        return;
      this.regeditKey.OpenSubKey(this.regeditPath, true).DeleteValue(name, false);
    }

    public void RegeditDeleteSubKey(string path, RegistryKey key, string SubKeyName)
    {
      this.regeditPath = path;
      this.regeditKey = key;
      if (this.regeditKey == null || this.regeditPath == "")
        return;
      this.regeditKey.OpenSubKey(this.regeditPath, true).DeleteSubKey(SubKeyName);
    }

    public void RegeditDeleteSubKey(string SubKeyName)
    {
      if (this.regeditKey == null || this.regeditPath == "")
        return;
      this.regeditKey.OpenSubKey(this.regeditPath, true).DeleteSubKey(SubKeyName);
    }

    public void SetStringValue(string path, RegistryKey key, string KeyName, string data)
    {
      this.regeditPath = path;
      this.regeditKey = key;
      if (this.regeditKey.OpenSubKey(this.regeditPath, true).GetValue(KeyName) == null)
        this.regeditKey.OpenSubKey(this.regeditPath, true).SetValue(KeyName, (object) data, RegistryValueKind.String);
      else
        this.regeditKey.OpenSubKey(this.regeditPath, true).DeleteValue(KeyName);
    }

    public void SetStringValue(string KeyName, string data)
    {
      if (this.regeditKey == null || this.regeditPath == "")
        return;
      if (this.regeditKey.OpenSubKey(this.regeditPath, true).GetValue(KeyName) == null)
        this.regeditKey.OpenSubKey(this.regeditPath, true).SetValue(KeyName, (object) data, RegistryValueKind.String);
      else
        this.regeditKey.OpenSubKey(this.regeditPath, true).DeleteValue(KeyName);
    }

    public void SetBinaryValue(string path, RegistryKey key, string KeyName, byte[] data)
    {
      this.regeditPath = path;
      this.regeditKey = key;
      if (this.regeditKey.OpenSubKey(this.regeditPath, true).GetValue(KeyName) == null)
        this.regeditKey.OpenSubKey(this.regeditPath, true).SetValue(KeyName, (object) data, RegistryValueKind.Binary);
      else
        this.regeditKey.OpenSubKey(this.regeditPath, true).DeleteValue(KeyName);
    }

    public void SetBinaryValue(string KeyName, byte[] data)
    {
      if (this.regeditKey == null || this.regeditPath == "")
        return;
      if (this.regeditKey.OpenSubKey(this.regeditPath, true).GetValue(KeyName) == null)
        this.regeditKey.OpenSubKey(this.regeditPath, true).SetValue(KeyName, (object) data, RegistryValueKind.Binary);
      else
        this.regeditKey.OpenSubKey(this.regeditPath, true).DeleteValue(KeyName);
    }

    public void SetDWordValue(string path, RegistryKey key, string KeyName, int data)
    {
      this.regeditPath = path;
      this.regeditKey = key;
      if (this.regeditKey.OpenSubKey(this.regeditPath, true).GetValue(KeyName) == null)
        this.regeditKey.OpenSubKey(this.regeditPath, true).SetValue(KeyName, (object) data, RegistryValueKind.DWord);
      else
        this.regeditKey.OpenSubKey(this.regeditPath, true).DeleteValue(KeyName);
    }

    public void SetDWordValue(string KeyName, int data)
    {
      if (this.regeditKey == null || this.regeditPath == "")
        return;
      if (this.regeditKey.OpenSubKey(this.regeditPath, true).GetValue(KeyName) == null)
        this.regeditKey.OpenSubKey(this.regeditPath, true).SetValue(KeyName, (object) data, RegistryValueKind.DWord);
      else
        this.regeditKey.OpenSubKey(this.regeditPath, true).DeleteValue(KeyName);
    }

    public bool CheckValue(string path, RegistryKey key, string KeyName)
    {
      this.regeditPath = path;
      this.regeditKey = key;
      return this.regeditKey.OpenSubKey(this.regeditPath, true).GetValue(KeyName) != null;
    }

    public string GetValue(string path, RegistryKey key, string KeyName)
    {
      this.regeditPath = path;
      this.regeditKey = key;
      return !this.CheckValue(path, key, KeyName) ? "" : this.regeditKey.OpenSubKey(this.regeditPath, true).GetValue(KeyName).ToString();
    }

    public string[] GetValueNames()
    {
      return this.regeditKey != null ? (!(this.regeditPath == "") ? this.regeditKey.OpenSubKey(this.regeditPath, true).GetValueNames() : (string[]) null) : (string[]) null;
    }

    public string[] GetValueNames(string path, RegistryKey key)
    {
      this.regeditPath = path;
      this.regeditKey = key;
      return this.regeditKey != null ? (!(this.regeditPath == "") ? this.regeditKey.OpenSubKey(this.regeditPath, true).GetValueNames() : (string[]) null) : (string[]) null;
    }

    public string[] GetSubNames()
    {
      return this.regeditKey != null ? (!(this.regeditPath == "") ? this.regeditKey.OpenSubKey(this.regeditPath, true).GetSubKeyNames() : (string[]) null) : (string[]) null;
    }

    public string[] GetSubNames(string path, RegistryKey key)
    {
      this.regeditPath = path;
      this.regeditKey = key;
      return this.regeditKey.OpenSubKey(this.regeditPath, true).GetSubKeyNames();
    }
  }
}
