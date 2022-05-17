
// Type: Trand.WinAPI.TStringList
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Trand.WinAPI
{
  public class TStringList
  {
    private string name = "";
    private string text = "";
    private string filePath = "";
    private int count;
    private static int newcount;
    private ArrayList arraylist;
    public string[] Strings;

    public int Count
    {
      get
      {
        return this.count;
      }
    }

    public string FilePath
    {
      get
      {
        return this.filePath;
      }
      set
      {
        this.filePath = value;
      }
    }

    public string FirstString
    {
      get
      {
        return this.arraylist != null ? this.arraylist[0].ToString() : "";
      }
    }

    public bool IsRepeat
    {
      get
      {
        return this.isRepeat();
      }
    }

    public string LastString
    {
      get
      {
        return this.arraylist != null ? this.arraylist[this.count - 1].ToString() : "";
      }
    }

    public string Name
    {
      get
      {
        return this.name;
      }
      set
      {
        this.name = value;
      }
    }

    public string Text
    {
      get
      {
        this.Reset();
        return this.text;
      }
      set
      {
        this.text = value;
        this.GetStrings(this.text);
      }
    }

    public TStringList()
    {
      ++TStringList.newcount;
      this.name = "StringList" + TStringList.newcount.ToString();
      this.text = "";
      this.count = 0;
      this.arraylist = new ArrayList();
    }

    public TStringList(string data)
    {
      ++TStringList.newcount;
      this.name = "StringList" + TStringList.newcount.ToString();
      this.text = data;
      this.count = 1;
      this.arraylist.Add((object) data);
    }

    public TStringList(string[] data)
    {
      ++TStringList.newcount;
      this.name = "StringList" + TStringList.newcount.ToString();
      for (int index = 0; index < data.Length; ++index)
        this.text = this.text + "\r\n" + data[index];
      this.count = data.Length;
      this.arraylist.AddRange((ICollection) data);
    }

    public void Add(string data)
    {
      this.arraylist.Add((object) data);
      ++this.count;
      this.Reset();
    }

    public void Append(TStringList StringList)
    {
      this.text = this.text + "\r\n" + StringList.text;
      this.GetStrings(this.text);
      this.count = this.arraylist.Count;
    }

    public void Append(string data)
    {
      this.text = this.text.Trim() + "\r\n" + data;
      this.GetStrings(this.text);
      this.count = this.arraylist.Count;
    }

    public void Clear()
    {
      this.arraylist.Clear();
      this.text = "";
      this.count = 0;
    }

    public void ClearBlankLine()
    {
      if (this.arraylist.Count == 0)
        return;
      string str1 = "";
      foreach (string str2 in this.arraylist)
      {
        if (str2.Trim() != "")
          str1 = str1 + str2 + "\r\n";
      }
      this.text = str1.TrimEnd();
      this.GetStrings(this.text);
      this.count = this.arraylist.Count;
    }

    public bool Contain(string value)
    {
      return this.arraylist.Contains((object) value);
    }

    public void Delete(string data)
    {
      int num = this.arraylist.IndexOf((object) data);
      if (num == 0 || num > this.count)
        return;
      this.arraylist.Remove((object) data);
      this.Reset();
    }

    public void Delete(int index)
    {
      if (index > this.count)
        return;
      this.arraylist.RemoveAt(index);
      this.Reset();
    }

    public void Delete(int first, int second)
    {
      if (first > second || first > this.count || second > this.count)
        return;
      this.arraylist.RemoveRange(first, second - first + 1);
      this.Reset();
    }

    public void DeleteAll(string data)
    {
      while (this.arraylist.IndexOf((object) data) != -1)
        this.arraylist.Remove((object) data);
      this.arraylist.ToString();
      this.Reset();
    }

    public override bool Equals(object obj)
    {
      return ((TStringList) obj).arraylist == this.arraylist;
    }

    public TStringList Exchange(int index1, int index2)
    {
      TStringList tstringList1;
      if ((index1 <= index2 ? index2 : index1) > this.count)
      {
        tstringList1 = (TStringList) null;
      }
      else
      {
        TStringList tstringList2 = new TStringList();
        tstringList2.arraylist = this.arraylist;
        string str1 = tstringList2.arraylist[index1 - 1].ToString();
        tstringList2.arraylist[index1 - 1] = tstringList2.arraylist[index2 - 1];
        tstringList2.arraylist[index2 - 1] = (object) str1;
        foreach (string str2 in tstringList2.arraylist)
        {
          TStringList tstringList3 = tstringList2;
          tstringList3.text = tstringList3.text + str2 + "\r\n";
        }
        tstringList2.text = tstringList2.text.Trim();
        tstringList2.count = tstringList2.arraylist.Count;
        tstringList1 = tstringList2;
      }
      return tstringList1;
    }

    public TStringList Exchange(string data1, string data2)
    {
      int index1 = this.arraylist.IndexOf((object) data1);
      int index2 = this.arraylist.IndexOf((object) data2);
      TStringList tstringList1;
      if (index1 == -1)
        tstringList1 = (TStringList) null;
      else if (index2 == -1)
      {
        tstringList1 = (TStringList) null;
      }
      else
      {
        TStringList tstringList2 = new TStringList();
        tstringList2.arraylist = this.arraylist;
        tstringList2.arraylist[index1] = (object) data2;
        tstringList2.arraylist[index2] = (object) data1;
        foreach (string str in tstringList2.arraylist)
        {
          TStringList tstringList3 = tstringList2;
          tstringList3.text = tstringList3.text + str + "\r\n";
        }
        tstringList2.text = tstringList2.text.Trim();
        tstringList2.count = tstringList2.arraylist.Count;
        tstringList1 = tstringList2;
      }
      return tstringList1;
    }

    public int FirstLineString(string data)
    {
      int num;
      if (this.arraylist.Count == 0)
      {
        num = -1;
      }
      else
      {
        for (int index = 0; index < this.count; ++index)
        {
          if (this.arraylist[index].ToString().IndexOf(data) != -1)
            return index;
        }
        num = -1;
      }
      return num;
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public void Insert(int index, string data)
    {
      if (index > this.count)
        return;
      this.arraylist.Insert(index, (object) data);
      this.Reset();
    }

    public int LastLineString(string data)
    {
      int num;
      if (this.arraylist.Count == 0)
      {
        num = -1;
      }
      else
      {
        for (int index = this.count - 1; index > -1; --index)
        {
          if (this.arraylist[index].ToString().IndexOf(data) != -1)
            return index;
        }
        num = -1;
      }
      return num;
    }

    public int LastPos(string data)
    {
      return this.arraylist.LastIndexOf((object) data);
    }

    public void LoadFromTXT(string path)
    {
      if (!File.Exists(path))
        return;
      StreamReader streamReader = new StreamReader(path);
      this.text = streamReader.ReadToEnd();
      streamReader.Close();
      streamReader.Dispose();
      this.GetStrings(this.text);
      this.filePath = path;
    }

    public string PartialText(int index1, int index2)
    {
      string str1;
      if (index1 > index2)
        str1 = "";
      else if (index2 > this.count)
      {
        str1 = "";
      }
      else
      {
        string str2 = "";
        int index;
        for (index = index1 - 1; index < index2 - 1; ++index)
          str2 = str2 + this.arraylist[index].ToString() + "\r\n";
        str1 = str2 + this.arraylist[index].ToString();
      }
      return str1;
    }

    public int Pos(string data)
    {
      this.arraylist.IndexOf((object) data);
      return -1;
    }

    public void Reverse()
    {
      this.arraylist.Reverse();
      this.Reset();
    }

    public void SaveToTXT(string path)
    {
      StreamWriter streamWriter = new StreamWriter(path);
      streamWriter.WriteLine(this.text);
      streamWriter.Close();
      streamWriter.Dispose();
    }

    public void Sort()
    {
      this.arraylist.Sort();
      this.Reset();
    }

    public void Swap(int index1, int index2)
    {
      if ((index1 <= index2 ? index2 : index1) > this.count)
        return;
      string str = this.arraylist[index1 - 1].ToString();
      this.arraylist[index1 - 1] = this.arraylist[index2 - 1];
      this.arraylist[index2 - 1] = (object) str;
      this.Reset();
    }

    public void Swap(string data1, string data2)
    {
      int index1 = this.arraylist.IndexOf((object) data1);
      int index2 = this.arraylist.IndexOf((object) data2);
      if (index1 == -1 || index2 == -1)
        return;
      this.arraylist[index1] = (object) data2;
      this.arraylist[index2] = (object) data1;
      this.Reset();
    }

    public override string ToString()
    {
      return this.Name;
    }

    public void TrimAll()
    {
      if (this.arraylist == null)
        return;
      for (int index = 0; index < this.count; ++index)
        this.arraylist[index] = (object) this.arraylist[index].ToString().Trim();
      this.Reset();
    }

    public void Unique()
    {
      if (this.arraylist == null)
        return;
      this.arraylist = this.ArrayUnique(this.arraylist);
      this.count = this.arraylist.Count;
      this.Reset();
    }

    public void WriteBegin(string beginstring)
    {
      for (int index = 0; index < this.count; ++index)
        this.arraylist[index] = (object) (beginstring + this.arraylist[index].ToString());
      this.Reset();
    }

    public void WriteEnd(string endstring)
    {
      for (int index = 0; index < this.count; ++index)
        this.arraylist[index] = (object) (this.arraylist[index].ToString() + endstring);
      this.Reset();
    }

    private ArrayList ArrayUnique(ArrayList data)
    {
      ArrayList arrayList = new ArrayList();
      foreach (string str in data)
      {
        if (!arrayList.Contains((object) str))
          arrayList.Add((object) str);
      }
      data.Clear();
      data = arrayList;
      return data;
    }

    private void GetStrings(string data)
    {
      Regex regex = new Regex("\r\n");
      this.arraylist.Clear();
      this.arraylist.AddRange((ICollection) regex.Split(this.text));
      this.count = this.arraylist.Count;
      this.Strings = new string[this.count];
      this.arraylist.ToArray().CopyTo((Array) this.Strings, 0);
    }

    private bool isRepeat()
    {
      return this.arraylist != null && this.count != this.ArrayUnique(this.arraylist).Count;
    }

    private void Reset()
    {
      this.text = "";
      for (int index = 0; index < this.arraylist.Count; ++index)
      {
        this.text += (string) this.arraylist[index];
        if (index < this.arraylist.Count - 1)
          this.text += "\r\n";
      }
      this.text = this.text.TrimEnd();
      this.count = this.arraylist.Count;
      this.Strings = new string[this.count];
      this.arraylist.ToArray().CopyTo((Array) this.Strings, 0);
    }

    public void LoadFromRTF(string path)
    {
      if (!File.Exists(path))
        return;
      RichTextBox richTextBox = new RichTextBox();
      richTextBox.LoadFile(path, RichTextBoxStreamType.RichText);
      this.text = richTextBox.Text;
      richTextBox.Dispose();
      this.GetStrings(this.text);
      this.filePath = path;
    }

    public void SaveToRTF(string path)
    {
      RichTextBox richTextBox = new RichTextBox();
      richTextBox.AppendText(this.text);
      richTextBox.SaveFile(path);
      richTextBox.Dispose();
    }
  }
}
