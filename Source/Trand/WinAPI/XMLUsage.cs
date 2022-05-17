
// Type: Trand.WinAPI.XMLUsage
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.IO;
using System.Text;
using System.Xml;

namespace Trand.WinAPI
{
  public class XMLUsage
  {
    private string path = "";
    private XmlDocument xdoc;
    private XmlDocumentType xdoctype;
    private XmlNodeList xnodelist;
    private XmlNode xnode;
    private XmlElement xele;
    private XmlAttribute xattr;

    public string Path
    {
      get
      {
        return this.path;
      }
      set
      {
        this.path = value;
      }
    }

    public XMLUsage()
    {
      this.path = "./";
    }

    public bool RetrieveDatabaseName(string database)
    {
      return Directory.Exists(this.path + database);
    }

    public bool RetrieveTableName(string database, string tablename)
    {
      return File.Exists(this.path + "/" + database + "/" + tablename + ".xml");
    }

    public void CreateDatabase(string database)
    {
      if (Directory.Exists(this.path + database))
        return;
      Directory.CreateDirectory(this.path + database);
    }

    public void DropDatabase(string database)
    {
      if (!Directory.Exists(this.path + database))
        return;
      Directory.Delete(this.path + database, true);
    }

    public void CreateDocument(string database, string tablename, string body)
    {
      if (File.Exists(this.path + database + "/" + tablename + ".xml"))
        return;
      TStringList tstringList = new TStringList();
      string[] strArray1 = body.Split(',');
      tstringList.Add("<!ELEMENT _" + tablename + " (" + tablename + "+)>");
      tstringList.Add("<!ELEMENT " + tablename + " (");
      for (int index = 0; index < strArray1.Length; ++index)
      {
        string[] strArray2 = strArray1[index].Split(' ');
        if (this.KeyWord(strArray2[0]))
          return;
        tstringList.Strings[1] = tstringList.Strings[1] + strArray2[0] + "+, ";
        tstringList.Add("<!ELEMENT " + strArray2[0] + " (#PCDATA)>");
        tstringList.Add("<!ATTLIST " + strArray2[0] + " type CDATA \"" + strArray2[1] + "\">");
      }
      tstringList.Strings[1] = tstringList.Strings[1].Substring(0, tstringList.Strings[1].Length - 2) + ")>";
      if (this.xdoc == null)
        this.xdoc = new XmlDocument();
      this.xdoctype = this.xdoc.CreateDocumentType("_" + tablename, (string) null, (string) null, "\r\n" + tstringList.Text.Trim() + "\r\n");
      this.xdoc.AppendChild((XmlNode) this.xdoc.CreateXmlDeclaration("1.0", "gb2312", "yes"));
      this.xdoc.AppendChild((XmlNode) this.xdoctype);
      this.xdoc.AppendChild((XmlNode) this.xdoc.CreateElement("_" + tablename));
      this.xnode = (XmlNode) this.xdoc.DocumentElement;
      this.xele = this.xdoc.CreateElement(tablename);
      this.xattr = this.xdoc.CreateAttribute("SID");
      this.xattr.Value = "0";
      this.xele.SetAttributeNode(this.xattr);
      this.xnode.AppendChild((XmlNode) this.xele);
      for (int index = 0; index < strArray1.Length; ++index)
      {
        string[] strArray2 = strArray1[index].Split(' ');
        XmlElement element = this.xdoc.CreateElement(strArray2[0]);
        XmlText textNode = this.xdoc.CreateTextNode(" ");
        this.xele.AppendChild((XmlNode) element);
        this.xele.LastChild.AppendChild((XmlNode) textNode);
        if (strArray2.Length == 2)
        {
          this.xattr = this.xdoc.CreateAttribute("type");
          this.xattr.Value = strArray2[1];
          element.SetAttributeNode(this.xattr);
        }
      }
      this.xdoc.Save(this.path + database + "/" + tablename + ".xml");
    }

    public void DeleteDocument(string database, string tablename)
    {
      if (!this.RetrieveTableName(database, tablename))
        return;
      File.Delete(this.path + database + "/" + tablename + ".xml");
    }

    public string[] GetAllDocument(string database)
    {
      return Directory.GetFiles(this.path + database);
    }

    public void GetDataType(string path, TStringList list1, TStringList list2)
    {
      if (!File.Exists(path))
        return;
      this.xdoc = new XmlDocument();
      this.xdoc.Load(path);
      this.xdoctype = this.xdoc.DocumentType;
      list1.Text = this.xdoctype.OuterXml;
      list1.Delete(1, 3);
      list1.Delete(list1.Count);
      TStringList tstringList = new TStringList();
      int num1 = 0;
      while (num1 < list1.Count)
      {
        tstringList.Add(list1.Strings[num1 + 1]);
        num1 += 2;
      }
      list1.Text = tstringList.Text;
      for (int index = 0; index < tstringList.Count; ++index)
      {
        int num2 = tstringList.Strings[index].IndexOf("type");
        list1.Strings[index] = tstringList.Strings[index].Substring(10, num2 - 11);
        int startIndex = tstringList.Strings[index].IndexOf("CDATA") + 7;
        int length = tstringList.Strings[index].Length;
        tstringList.Strings[index] = tstringList.Strings[index].Substring(startIndex, length - startIndex - 2);
      }
      list2.Text = tstringList.Text;
    }

    public string GetNodeValue(string path, string nodename)
    {
      string str;
      if (!File.Exists(System.IO.Path.GetFullPath(path)))
      {
        str = "";
      }
      else
      {
        if (this.xdoc == null)
          this.xdoc = new XmlDocument();
        this.xdoc.Load(path);
        this.xnodelist = this.xdoc.DocumentElement.ChildNodes;
        foreach (XmlNode xmlNode1 in this.xnodelist)
        {
          if (xmlNode1.Name == nodename)
            return xmlNode1.InnerText.Trim();
          this.xele = (XmlElement) xmlNode1;
          foreach (XmlNode xmlNode2 in this.xele.ChildNodes)
          {
            if (xmlNode2.Name == nodename)
              return xmlNode2.InnerText.Trim();
          }
        }
        str = "";
      }
      return str;
    }

    public void DeleteData(string database, string tablename, string nodename, bool alldelete)
    {
      if (!this.RetrieveTableName(database, tablename))
        return;
      if (this.xdoc == null)
        this.xdoc = new XmlDocument();
      this.xdoc.Load(this.path + database + "/" + tablename + ".xml");
      this.xnodelist = this.xdoc.SelectSingleNode("_" + tablename).ChildNodes;
      foreach (XmlElement xmlElement in this.xnodelist)
      {
        if (xmlElement.Name == tablename)
        {
          foreach (XmlNode oldChild in xmlElement.ChildNodes)
          {
            if (oldChild.Name == nodename)
            {
              oldChild.ParentNode.RemoveChild(oldChild);
              if (alldelete)
              {
                this.xdoc.Save(this.path + database + "/" + tablename + ".xml");
                return;
              }
            }
          }
        }
      }
      this.xdoc.Save(this.path + database + "/" + tablename + ".xml");
    }

    public void InsertElement(string database, string tablename, string nodename)
    {
      if (!this.RetrieveTableName(database, tablename))
        return;
      if (this.xdoc == null)
        this.xdoc = new XmlDocument();
      this.xdoc.Load(this.path + database + "/" + tablename + ".xml");
      TStringList list1 = new TStringList();
      TStringList list2 = new TStringList();
      this.GetDataType(this.path + database + "/" + tablename + ".xml", list1, list2);
      this.xnodelist = this.xdoc.SelectSingleNode("_" + tablename).ChildNodes;
      int count = this.xnodelist.Count;
      this.xele = this.xdoc.CreateElement(tablename);
      this.xattr = this.xdoc.CreateAttribute("SID");
      this.xattr.Value = count.ToString();
      this.xele.SetAttributeNode(this.xattr);
      this.xnode = this.xdoc.SelectSingleNode("_" + tablename);
      this.xnode.AppendChild((XmlNode) this.xele);
      string[] strArray = nodename.Split(',');
      for (int index = 0; index < list1.Count; ++index)
      {
        XmlElement element = this.xdoc.CreateElement(list1.Strings[index]);
        XmlText textNode = this.xdoc.CreateTextNode(strArray[index]);
        this.xele.AppendChild((XmlNode) element);
        this.xele.LastChild.AppendChild((XmlNode) textNode);
        this.xattr = this.xdoc.CreateAttribute("type");
        this.xattr.Value = list2.Strings[index];
        element.SetAttributeNode(this.xattr);
      }
      this.xdoc.Save(this.path + database + "/" + tablename + ".xml");
    }

    public string UpdateData(string database, string tablename, string nodename)
    {
      string str;
      try
      {
        string filename = "./" + database + "/" + tablename + ".xml";
        if (this.RetrieveTableName(database, tablename))
        {
          this.xdoc = new XmlDocument();
          this.xdoc.Load(filename);
          XmlNodeList childNodes = this.xdoc.SelectSingleNode("_" + tablename).ChildNodes;
          string[] strArray1 = nodename.Split(' ');
          if (strArray1.Length == 3)
          {
            if (strArray1[2].Substring(0, 1) == "'")
              strArray1[2] = strArray1[2].Substring(1, strArray1[2].Length - 2);
            foreach (XmlNode xmlNode1 in childNodes)
            {
              if (xmlNode1.Name == strArray1[1])
                xmlNode1.InnerText = strArray1[2];
              foreach (XmlNode xmlNode2 in xmlNode1.ChildNodes)
              {
                if (xmlNode2.Name.Split(' ')[0] == strArray1[1])
                  xmlNode2.InnerText = strArray1[2];
              }
            }
          }
          else if (strArray1.Length == 4)
          {
            if (strArray1[2].Substring(0, 1) == "'")
              strArray1[2] = strArray1[2].Substring(1, strArray1[2].Length - 2);
            if (strArray1[3].Substring(0, 1) == "'")
              strArray1[3] = strArray1[3].Substring(1, strArray1[3].Length - 2);
            foreach (XmlNode xmlNode1 in childNodes)
            {
              if (xmlNode1.Name == strArray1[1] && xmlNode1.InnerText == strArray1[3])
              {
                xmlNode1.InnerText = strArray1[2];
                this.xdoc.Save(filename);
                return "S";
              }
              foreach (XmlNode xmlNode2 in xmlNode1.ChildNodes)
              {
                string[] strArray2 = xmlNode2.Name.Split(' ');
                if (strArray1[3] == " ")
                  strArray1[3] = "";
                if (strArray2[0] == strArray1[1] && xmlNode2.InnerText == strArray1[3])
                {
                  xmlNode2.InnerText = strArray1[2];
                  this.xdoc.Save(filename);
                  return "S";
                }
              }
            }
          }
          this.xdoc.Save(filename);
          str = "S";
        }
        else
          str = "F";
      }
      catch
      {
        str = "E";
      }
      return str;
    }

    public string GetTag(string database, string tablename, string element)
    {
      TStringList list1 = new TStringList();
      TStringList list2 = new TStringList();
      this.GetDataType(this.path + database + "/" + tablename + ".xml", list1, list2);
      int index = list1.Pos(element);
      return index != -1 ? list2.Strings[index] : "";
    }

    public void CreateAttribute(string database, string tablename, string element, string name, string value)
    {
      if (!this.RetrieveTableName(database, tablename))
        return;
      if (this.xdoc == null)
        this.xdoc = new XmlDocument();
      this.xdoc.Load(this.path + database + "/" + tablename + ".xml");
      this.xnodelist = this.xdoc.SelectSingleNode("_" + tablename).ChildNodes;
      foreach (XmlNode xmlNode1 in this.xnodelist)
      {
        this.xele = (XmlElement) xmlNode1;
        if (xmlNode1.Name == element)
        {
          if (this.xele.HasAttributes)
            this.xele.Attributes.RemoveAll();
          this.xattr = this.xdoc.CreateAttribute(name);
          this.xattr.Value = value;
          this.xele.SetAttributeNode(this.xattr);
        }
        foreach (XmlNode xmlNode2 in this.xele.ChildNodes)
        {
          if (xmlNode2.Name == element)
          {
            XmlElement xmlElement = (XmlElement) xmlNode2;
            if (xmlElement.HasAttributes)
              xmlElement.Attributes.RemoveAll();
            this.xattr = this.xdoc.CreateAttribute(name);
            this.xattr.Value = value;
            xmlElement.SetAttributeNode(this.xattr);
          }
        }
      }
      this.xdoc.Save(this.path + database + "/" + tablename + ".xml");
    }

    public void CreateCharData(string database, string tablename, string element, string value, int index)
    {
      if (!this.RetrieveTableName(database, tablename))
        return;
      if (this.xdoc == null)
        this.xdoc = new XmlDocument();
      this.xdoc.Load(this.path + database + "/" + tablename + ".xml");
      this.xnodelist = this.xdoc.SelectSingleNode("_" + tablename).ChildNodes;
      if (index > this.xnodelist.Count - 1)
        return;
      if (index != -1)
      {
        this.xele = (XmlElement) this.xnodelist.Item(index);
        foreach (XmlNode xmlNode in this.xele.ChildNodes)
        {
          if (xmlNode.Name == element)
          {
            xmlNode.InnerText = value;
            this.xdoc.Save(this.path + database + "/" + tablename + ".xml");
            return;
          }
        }
      }
      foreach (XmlElement xmlElement in this.xnodelist)
      {
        this.xele = xmlElement;
        foreach (XmlNode xmlNode in this.xele.ChildNodes)
        {
          if (xmlNode.Name == element)
          {
            xmlNode.InnerText = value;
            if (index > -1)
            {
              this.xdoc.Save(this.path + database + "/" + tablename + ".xml");
              return;
            }
          }
        }
      }
      this.xdoc.Save(this.path + database + "/" + tablename + ".xml");
    }

    public string CreateElement(string database, string tablename, string element, string name)
    {
      string str;
      try
      {
        string filename = "./" + database + "/" + tablename + ".xml";
        if (this.RetrieveTableName(database, tablename))
        {
          this.xdoc = new XmlDocument();
          this.xdoc.Load(filename);
          XmlNodeList childNodes = this.xdoc.SelectSingleNode("_" + tablename).ChildNodes;
          string[] strArray = element.Split(' ');
          XmlElement xmlElement = (XmlElement) childNodes.Item(Convert.ToInt32(strArray[0]) - 1);
          if (xmlElement.Name == strArray[1])
          {
            xmlElement.AppendChild((XmlNode) this.xdoc.CreateElement(name));
          }
          else
          {
            foreach (XmlNode xmlNode in (XmlNode) xmlElement)
            {
              if (xmlNode.Name.Split(' ')[0] == strArray[1])
              {
                xmlNode.AppendChild((XmlNode) this.xdoc.CreateElement(name));
                this.xdoc.Save(filename);
                return "S";
              }
            }
          }
          this.xdoc.Save(filename);
          str = "S";
        }
        else
          str = "F";
      }
      catch
      {
        str = "E";
      }
      return str;
    }

    public string GetAttribute(string database, string tablename, string element)
    {
      try
      {
        string filename = "./" + database + "/" + tablename + ".xml";
        if (this.RetrieveTableName(database, tablename))
        {
          this.xdoc = new XmlDocument();
          this.xdoc.Load(filename);
          foreach (XmlNode xmlNode1 in this.xdoc.SelectSingleNode("_" + tablename).ChildNodes)
          {
            XmlElement xmlElement = (XmlElement) xmlNode1;
            if (xmlNode1.Name == element)
              return ((XmlElement) xmlNode1).GetAttribute("type");
            foreach (XmlNode xmlNode2 in (XmlNode) xmlElement)
            {
              if (xmlNode2.Name.Split(' ')[0] == element)
                return ((XmlElement) xmlNode2).GetAttribute("type");
            }
          }
        }
        return "F";
      }
      catch
      {
        return "E";
      }
    }

    public string GenerateDocument(string database, string tablename, string document)
    {
      string str;
      try
      {
        string filename = "./" + database + "/" + tablename + ".xml";
        if (this.RetrieveTableName(database, tablename))
        {
          this.xdoc = new XmlDocument();
          this.xdoc.Load(filename);
          str = this.xdoc.DocumentType.InternalSubset;
        }
        else
          str = "F";
      }
      catch
      {
        str = "E";
      }
      return str;
    }

    public string ModifyDTD(string database, string tablename, string content)
    {
      string str1;
      try
      {
        string str2 = "./" + database + "/" + tablename + ".xml";
        if (this.RetrieveTableName(database, tablename))
        {
          string[] strArray1 = content.Split(',');
          for (int index = 0; index < strArray1.Length; ++index)
          {
            if (this.KeyWord(strArray1[index].Split(' ')[0]))
              return "F";
          }
          for (int index1 = 0; index1 < strArray1.Length; ++index1)
          {
            this.xdoc = new XmlDocument();
            this.xdoc.Load(str2);
            string outerXml1 = this.xdoc.DocumentElement.OuterXml;
            string[] strArray2 = strArray1[index1].Split(' ');
            string outerXml2 = this.xdoc.DocumentType.OuterXml;
            int[] numArray = new int[2];
            int index2 = 0;
            int num = 0;
            foreach (char ch in outerXml2)
            {
              ++num;
              if ((int) ch == 62)
              {
                numArray[index2] = num;
                ++index2;
              }
              if (index2 == 2)
                break;
            }
            string oldValue = outerXml2.Substring(numArray[0], numArray[1] - numArray[0]);
            string newValue = oldValue.Replace(")>", ", " + strArray2[0] + "+)>");
            string str3 = outerXml2.Replace(oldValue, newValue).Replace("]>", "<!ELEMENT " + strArray2[0] + " (#PCDATA)>]>").Replace("]>", "<!ATTLIST " + strArray2[0] + " type CDATA #REQUIRED>]>");
            string internalSubset = this.xdoc.DocumentType.InternalSubset;
            StreamReader streamReader = new StreamReader(str2);
            string str4 = streamReader.ReadToEnd();
            streamReader.Dispose();
            string str5 = str4.Replace(internalSubset, "").Replace("<!DOCTYPE _" + tablename + "[]>", "");
            string str6 = str5.Substring(2, str5.Length - 2).Replace("xml version=\"1.0\" encoding=\"gb2312\"?>", "").Replace("xml version=\"1.0\" encoding=\"gb2312\" standalone=\"yes\"?>", "");
            StreamWriter streamWriter = new StreamWriter(str2, false, Encoding.Default);
            streamWriter.WriteLine("<?xml version=\"1.0\" encoding=\"gb2312\"?>");
            streamWriter.WriteLine(str3);
            streamWriter.WriteLine(str6);
            streamWriter.Close();
            this.xdoc.Load(str2);
            foreach (XmlNode xmlNode in this.xdoc.SelectSingleNode("_" + tablename).ChildNodes)
            {
              XmlElement element = this.xdoc.CreateElement(strArray2[0]);
              XmlText textNode = this.xdoc.CreateTextNode(" ");
              xmlNode.AppendChild((XmlNode) element);
              xmlNode.LastChild.AppendChild((XmlNode) textNode);
              if (strArray2.Length == 2)
              {
                this.xattr = this.xdoc.CreateAttribute("type");
                this.xattr.Value = strArray2[1];
                element.SetAttributeNode(this.xattr);
              }
            }
            this.xdoc.Save(str2);
          }
          str1 = "S";
        }
        else
          str1 = "F";
      }
      catch
      {
        str1 = "E";
      }
      return str1;
    }

    public bool KeyWord(string a)
    {
      string[] strArray = new string[14]
      {
        "CREATE",
        "DELETE",
        "DROP",
        "FROM",
        "LEFT",
        "INNER",
        "INSERT",
        "JOIN",
        "RIGHT",
        "SELECT",
        "SET",
        "TABLE",
        "UPDATE",
        "WHERE"
      };
      int num = 0;
      foreach (string str in strArray)
      {
        if (str == a.ToUpper())
          return true;
        ++num;
      }
      return false;
    }

    public string Delete(string database, string tablename, string nodename)
    {
      string str1;
      try
      {
        string filename = "./" + database + "/" + tablename + ".xml";
        if (this.RetrieveTableName(database, tablename))
        {
          this.xdoc = new XmlDocument();
          this.xdoc.Load(filename);
          XmlNodeList childNodes = this.xdoc.SelectSingleNode("_" + tablename).ChildNodes;
          nodename = nodename.Replace(" ", "");
          string[] strArray = new string[2];
          int num1 = 0;
          int length = 0;
          string str2 = "";
          if (nodename.IndexOf(">=") != -1)
          {
            str2 = ">=";
            strArray[0] = nodename.Substring(0, nodename.IndexOf(">="));
            strArray[1] = nodename.Substring(nodename.IndexOf(">=") + 2, nodename.Length - nodename.IndexOf(">=") - 2);
          }
          else if (nodename.IndexOf("<=") != -1)
          {
            str2 = "<=";
            strArray[0] = nodename.Substring(0, nodename.IndexOf("<="));
            strArray[1] = nodename.Substring(nodename.IndexOf("<=") + 2, nodename.Length - nodename.IndexOf("<=") - 2);
          }
          else if (nodename.IndexOf("<>") != -1)
          {
            str2 = "<>";
            strArray[0] = nodename.Substring(0, nodename.IndexOf("<>"));
            strArray[1] = nodename.Substring(nodename.IndexOf("<>") + 2, nodename.Length - nodename.IndexOf("<>") - 2);
          }
          else if (nodename.IndexOf("=") != -1)
          {
            str2 = "=";
            strArray[0] = nodename.Substring(0, nodename.IndexOf("="));
            strArray[1] = nodename.Substring(nodename.IndexOf("=") + 1, nodename.Length - nodename.IndexOf("=") - 1);
          }
          else if (nodename.IndexOf(">") != -1)
          {
            str2 = ">";
            strArray[0] = nodename.Substring(0, nodename.IndexOf(">"));
            strArray[1] = nodename.Substring(nodename.IndexOf(">") + 1, nodename.Length - nodename.IndexOf(">") - 1);
          }
          else if (nodename.IndexOf("<") != -1)
          {
            str2 = "<";
            strArray[0] = nodename.Substring(0, nodename.IndexOf("<"));
            strArray[1] = nodename.Substring(nodename.IndexOf("<") + 1, nodename.Length - nodename.IndexOf("<") - 1);
          }
          foreach (XmlNode xmlNode1 in childNodes)
          {
            foreach (XmlNode xmlNode2 in xmlNode1)
            {
              if (xmlNode2.Name.Split(' ')[0] == strArray[0])
              {
                if (str2 == "=")
                {
                  if (xmlNode2.InnerText == strArray[1])
                    ++length;
                }
                else if (str2 == ">")
                {
                  if (int.Parse(xmlNode2.InnerText) > int.Parse(strArray[1]))
                    ++length;
                }
                else if (str2 == "<")
                {
                  if (int.Parse(xmlNode2.InnerText) < int.Parse(strArray[1]))
                    ++length;
                }
                else if (str2 == ">=")
                {
                  if (int.Parse(xmlNode2.InnerText) >= int.Parse(strArray[1]))
                    ++length;
                }
                else if (str2 == "<=")
                {
                  if (int.Parse(xmlNode2.InnerText) <= int.Parse(strArray[1]))
                    ++length;
                }
                else if (str2 == "<>" && xmlNode2.InnerText != strArray[1])
                  ++length;
              }
            }
            ++num1;
          }
          int[] numArray = new int[length];
          int num2;
          int index1 = num2 = 0;
          foreach (XmlNode xmlNode1 in childNodes)
          {
            foreach (XmlNode xmlNode2 in xmlNode1)
            {
              if (xmlNode2.Name.Split(' ')[0] == strArray[0])
              {
                if (str2 == "=")
                {
                  if (xmlNode2.InnerText == strArray[1])
                  {
                    numArray[index1] = num2;
                    ++index1;
                  }
                }
                else if (str2 == ">")
                {
                  if (int.Parse(xmlNode2.InnerText) > int.Parse(strArray[1]))
                  {
                    numArray[index1] = num2;
                    ++index1;
                  }
                }
                else if (str2 == "<")
                {
                  if (int.Parse(xmlNode2.InnerText) < int.Parse(strArray[1]))
                  {
                    numArray[index1] = num2;
                    ++index1;
                  }
                }
                else if (str2 == ">=")
                {
                  if (int.Parse(xmlNode2.InnerText) >= int.Parse(strArray[1]))
                  {
                    numArray[index1] = num2;
                    ++index1;
                  }
                }
                else if (str2 == "<=")
                {
                  if (int.Parse(xmlNode2.InnerText) <= int.Parse(strArray[1]))
                  {
                    numArray[index1] = num2;
                    ++index1;
                  }
                }
                else if (str2 == "<>" && xmlNode2.InnerText != strArray[1])
                {
                  numArray[index1] = num2;
                  ++index1;
                }
              }
            }
            ++num2;
          }
          for (int index2 = 0; index2 < numArray.Length; ++index2)
          {
            for (int index3 = index2; index3 < numArray.Length; ++index3)
            {
              if (numArray[index2] < numArray[index3])
              {
                int num3 = numArray[index2];
                numArray[index2] = numArray[index3];
                numArray[index3] = num3;
              }
            }
          }
          for (int index2 = 0; index2 < numArray.Length; ++index2)
          {
            XmlElement xmlElement = (XmlElement) childNodes.Item(numArray[index2]);
            this.xdoc.SelectSingleNode("_" + tablename).RemoveChild((XmlNode) xmlElement);
          }
          this.xdoc.Save(filename);
          str1 = "S";
        }
        else
          str1 = "F";
      }
      catch
      {
        str1 = "E";
      }
      return str1;
    }

    public string Insert(string database, string tablename, string nodename)
    {
      string str1;
      try
      {
        string filename = "./" + database + "/" + tablename + ".xml";
        if (this.RetrieveTableName(database, tablename))
        {
          int num1 = 0;
          this.xdoc = new XmlDocument();
          this.xdoc.Load(filename);
          XmlNodeList childNodes = this.xdoc.SelectSingleNode("_" + tablename).ChildNodes;
          XmlElement element1 = this.xdoc.CreateElement(tablename);
          this.xattr = this.xdoc.CreateAttribute("SID");
          foreach (XmlElement xmlElement in childNodes)
          {
            if (int.Parse(xmlElement.GetAttribute("SID")) > num1)
              num1 = int.Parse(xmlElement.GetAttribute("SID"));
          }
          this.xattr.Value = (num1 + 1).ToString();
          element1.SetAttributeNode(this.xattr);
          this.xdoc.SelectSingleNode("_" + tablename).AppendChild((XmlNode) element1);
          foreach (XmlNode xmlNode in childNodes.Item(childNodes.Count - 1))
          {
            if (xmlNode.Name.Split(' ')[0] == "id")
              Convert.ToInt32(xmlNode.InnerText);
          }
          string internalSubset = this.xdoc.DocumentType.InternalSubset;
          int[] numArray = new int[2];
          int index1 = 0;
          int num2 = 0;
          foreach (int num3 in internalSubset)
          {
            if (num3 == 62)
            {
              numArray[index1] = num2;
              ++index1;
            }
            if (index1 != 2)
              ++num2;
            else
              break;
          }
          string str2 = internalSubset.Substring(numArray[0] + 3, numArray[1] - numArray[0] - 1).Replace("+", "");
          int num4;
          int index2 = num4 = 0;
          foreach (char ch in str2)
          {
            if ((int) ch == 40 | (int) ch == 41)
            {
              numArray[index2] = num4;
              ++index2;
            }
            if (index2 != 2)
              ++num4;
            else
              break;
          }
          string str3 = str2.Substring(numArray[0] + 1, numArray[1] - numArray[0] - 1).Replace(" ", "");
          string[] strArray1 = nodename.Split(',');
          string[] strArray2 = str3.Split(',');
          for (int index3 = 0; index3 < strArray2.Length; ++index3)
          {
            if (strArray2[index3] == "id")
            {
              this.xattr = this.xdoc.CreateAttribute("type");
              this.xattr.Value = "int";
              XmlElement element2 = this.xdoc.CreateElement(strArray2[index3]);
              XmlText textNode = this.xdoc.CreateTextNode(strArray1[index3]);
              element1.AppendChild((XmlNode) element2);
              element1.LastChild.AppendChild((XmlNode) textNode);
              element2.SetAttributeNode(this.xattr);
            }
            else
            {
              this.xattr = this.xdoc.CreateAttribute("type");
              this.xattr.Value = "string";
              XmlElement element2 = this.xdoc.CreateElement(strArray2[index3]);
              XmlText textNode = this.xdoc.CreateTextNode(strArray1[index3]);
              element1.AppendChild((XmlNode) element2);
              element1.LastChild.AppendChild((XmlNode) textNode);
            }
          }
          this.xdoc.Save(filename);
          str1 = "S";
        }
        else
          str1 = "F";
      }
      catch
      {
        str1 = "E";
      }
      return str1;
    }

    public string Update(string database, string tablename, string nodename)
    {
      string str1;
      try
      {
        string filename = "./" + database + "/" + tablename + ".xml";
        if (this.RetrieveTableName(database, tablename))
        {
          this.xdoc = new XmlDocument();
          this.xdoc.Load(filename);
          XmlNodeList childNodes = this.xdoc.SelectSingleNode("_" + tablename).ChildNodes;
          string[] strArray1 = nodename.Split('|');
          string[] strArray2 = new string[2];
          string[] strArray3 = new string[2];
          string str2 = "";
          if (strArray1[0].IndexOf(">=") != -1)
          {
            strArray2[0] = strArray1[0].Substring(0, strArray1[0].IndexOf(">="));
            strArray2[1] = strArray1[0].Substring(strArray1[0].IndexOf(">=") + 2, strArray1[0].Length - strArray1[0].IndexOf(">=") - 2);
          }
          else if (strArray1[0].IndexOf("<=") != -1)
          {
            strArray2[0] = strArray1[0].Substring(0, strArray1[0].IndexOf("<="));
            strArray2[1] = strArray1[0].Substring(strArray1[0].IndexOf("<=") + 2, strArray1[0].Length - strArray1[0].IndexOf("<=") - 2);
          }
          else if (strArray1[0].IndexOf("<>") != -1)
          {
            strArray2[0] = strArray1[0].Substring(0, strArray1[0].IndexOf("<>"));
            strArray2[1] = strArray1[0].Substring(strArray1[0].IndexOf("<>") + 2, strArray1[0].Length - strArray1[0].IndexOf("<>") - 2);
          }
          else if (strArray1[0].IndexOf("=") != -1)
          {
            strArray2[0] = strArray1[0].Substring(0, strArray1[0].IndexOf("="));
            strArray2[1] = strArray1[0].Substring(strArray1[0].IndexOf("=") + 1, strArray1[0].Length - strArray1[0].IndexOf("=") - 1);
          }
          else if (strArray1[0].IndexOf(">") != -1)
          {
            strArray2[0] = strArray1[0].Substring(0, strArray1[0].IndexOf(">"));
            strArray2[1] = strArray1[0].Substring(strArray1[0].IndexOf(">") + 1, strArray1[0].Length - strArray1[0].IndexOf(">") - 1);
          }
          else if (strArray1[0].IndexOf("<") != -1)
          {
            strArray2[0] = strArray1[0].Substring(0, strArray1[0].IndexOf("<"));
            strArray2[1] = strArray1[0].Substring(strArray1[0].IndexOf("<") + 1, strArray1[0].Length - strArray1[0].IndexOf("<") - 1);
          }
          if (strArray1.Length == 2)
          {
            if (strArray1[1].IndexOf(">=") != -1)
            {
              str2 = ">=";
              strArray3[0] = strArray1[1].Substring(0, strArray1[1].IndexOf(">="));
              strArray3[1] = strArray1[1].Substring(strArray1[1].IndexOf(">=") + 2, strArray1[1].Length - strArray1[1].IndexOf(">=") - 2);
            }
            else if (strArray1[1].IndexOf("<=") != -1)
            {
              str2 = "<=";
              strArray3[0] = strArray1[1].Substring(0, strArray1[1].IndexOf("<="));
              strArray3[1] = strArray1[1].Substring(strArray1[1].IndexOf("<=") + 2, strArray1[1].Length - strArray1[1].IndexOf("<=") - 2);
            }
            else if (strArray1[1].IndexOf("<>") != -1)
            {
              str2 = "<>";
              strArray3[0] = strArray1[1].Substring(0, strArray1[1].IndexOf("<>"));
              strArray3[1] = strArray1[1].Substring(strArray1[1].IndexOf("<>") + 2, strArray1[1].Length - strArray1[1].IndexOf("<>") - 2);
            }
            else if (strArray1[1].IndexOf("=") != -1)
            {
              str2 = "=";
              strArray3[0] = strArray1[1].Substring(0, strArray1[1].IndexOf("="));
              strArray3[1] = strArray1[1].Substring(strArray1[1].IndexOf("=") + 1, strArray1[1].Length - strArray1[1].IndexOf("=") - 1);
            }
            else if (strArray1[1].IndexOf(">") != -1)
            {
              str2 = ">";
              strArray3[0] = strArray1[1].Substring(0, strArray1[1].IndexOf(">"));
              strArray3[1] = strArray1[1].Substring(strArray1[1].IndexOf(">") + 1, strArray1[1].Length - strArray1[1].IndexOf(">") - 1);
            }
            else if (strArray1[1].IndexOf("<") != -1)
            {
              str2 = "<";
              strArray3[0] = strArray1[1].Substring(0, strArray1[1].IndexOf("<"));
              strArray3[1] = strArray1[1].Substring(strArray1[1].IndexOf("<") + 1, strArray1[1].Length - strArray1[1].IndexOf("<") - 1);
            }
            foreach (XmlNode xmlNode1 in childNodes)
            {
              if (xmlNode1.Name == strArray2[0])
              {
                if (str2 == "=")
                {
                  if (xmlNode1.InnerText == strArray3[1])
                    xmlNode1.InnerText = strArray2[0];
                }
                else if (str2 == ">")
                {
                  if (int.Parse(xmlNode1.InnerText) > int.Parse(strArray3[1]))
                    xmlNode1.InnerText = strArray2[0];
                }
                else if (str2 == "<")
                {
                  if (int.Parse(xmlNode1.InnerText) < int.Parse(strArray3[1]))
                    xmlNode1.InnerText = strArray2[0];
                }
                else if (str2 == ">=")
                {
                  if (int.Parse(xmlNode1.InnerText) >= int.Parse(strArray3[1]))
                    xmlNode1.InnerText = strArray2[0];
                }
                else if (str2 == "<=")
                {
                  if (int.Parse(xmlNode1.InnerText) <= int.Parse(strArray3[1]))
                    xmlNode1.InnerText = strArray2[0];
                }
                else if (str2 == "<>" && xmlNode1.InnerText != strArray3[1])
                  xmlNode1.InnerText = strArray2[0];
              }
              XmlElement xmlElement = (XmlElement) xmlNode1;
              foreach (XmlNode xmlNode2 in xmlElement.ChildNodes)
              {
                if (xmlNode2.Name.Split(' ')[0] == strArray3[0])
                {
                  if (str2 == "=")
                  {
                    if (xmlNode2.InnerText == strArray3[1])
                    {
                      foreach (XmlNode xmlNode3 in (XmlNode) xmlElement)
                      {
                        if (xmlNode3.Name.Split(' ')[0] == strArray2[0])
                          xmlNode3.InnerText = strArray2[1];
                      }
                    }
                  }
                  else if (str2 == ">")
                  {
                    if (int.Parse(xmlNode2.InnerText) > int.Parse(strArray3[1]))
                    {
                      foreach (XmlNode xmlNode3 in (XmlNode) xmlElement)
                      {
                        if (xmlNode3.Name.Split(' ')[0] == strArray2[0])
                          xmlNode3.InnerText = strArray2[1];
                      }
                    }
                  }
                  else if (str2 == "<")
                  {
                    if (int.Parse(xmlNode2.InnerText) < int.Parse(strArray3[1]))
                    {
                      foreach (XmlNode xmlNode3 in (XmlNode) xmlElement)
                      {
                        if (xmlNode3.Name.Split(' ')[0] == strArray2[0])
                          xmlNode3.InnerText = strArray2[1];
                      }
                    }
                  }
                  else if (str2 == ">=")
                  {
                    if (int.Parse(xmlNode2.InnerText) >= int.Parse(strArray3[1]))
                    {
                      foreach (XmlNode xmlNode3 in (XmlNode) xmlElement)
                      {
                        if (xmlNode3.Name.Split(' ')[0] == strArray2[0])
                          xmlNode3.InnerText = strArray2[1];
                      }
                    }
                  }
                  else if (str2 == "<=")
                  {
                    if (int.Parse(xmlNode2.InnerText) <= int.Parse(strArray3[1]))
                    {
                      foreach (XmlNode xmlNode3 in (XmlNode) xmlElement)
                      {
                        if (xmlNode3.Name.Split(' ')[0] == strArray2[0])
                          xmlNode3.InnerText = strArray2[1];
                      }
                    }
                  }
                  else if (str2 == "<>" && xmlNode2.InnerText != strArray3[1])
                  {
                    foreach (XmlNode xmlNode3 in (XmlNode) xmlElement)
                    {
                      if (xmlNode3.Name.Split(' ')[0] == strArray2[0])
                        xmlNode3.InnerText = strArray2[1];
                    }
                  }
                }
              }
            }
          }
          else if (strArray1.Length == 1)
          {
            foreach (XmlNode xmlNode1 in childNodes)
            {
              if (xmlNode1.Name == strArray2[0])
                xmlNode1.InnerText = strArray2[1];
              foreach (XmlNode xmlNode2 in xmlNode1.ChildNodes)
              {
                if (xmlNode2.Name.Split(' ')[0] == strArray2[0])
                  xmlNode2.InnerText = strArray2[1];
              }
            }
          }
          this.xdoc.Save(filename);
          str1 = "S";
        }
        else
          str1 = "F";
      }
      catch
      {
        str1 = "E";
      }
      return str1;
    }

    public string SelectElement(string database, string tablename, string nodename)
    {
      string str1;
      try
      {
        string filename = "./" + database + "/" + tablename + ".xml";
        string str2 = "";
        if (this.RetrieveTableName(database, tablename))
        {
          this.xdoc = new XmlDocument();
          this.xdoc.Load(filename);
          XmlNodeList childNodes = this.xdoc.SelectSingleNode("_" + tablename).ChildNodes;
          string[] strArray1 = nodename.Split('|');
          string[] strArray2 = new string[2];
          StringBuilder sb = new StringBuilder(str2);
          StringWriter stringWriter = new StringWriter(sb);
          string outerXml = this.xdoc.DocumentType.OuterXml;
          int[] numArray = new int[2];
          int index1 = 0;
          int num1 = 0;
          foreach (char ch in outerXml)
          {
            ++num1;
            if ((int) ch == 62)
            {
              numArray[index1] = num1;
              ++index1;
            }
            if (index1 == 2)
              break;
          }
          string str3 = outerXml.Substring(numArray[0], numArray[1] - numArray[0]);
          int index2;
          int num2 = index2 = 0;
          foreach (char ch in str3)
          {
            ++num2;
            if ((int) ch == 40 || (int) ch == 41)
            {
              numArray[index2] = num2;
              ++index2;
            }
            if (index2 == 2)
              break;
          }
          string str4 = str3.Substring(numArray[0], numArray[1] - numArray[0] - 1).Replace("+", "").Replace(" ", "");
          string[] strArray3;
          string[] strArray4;
          if (strArray1[0] == "*")
          {
            strArray3 = str4.Split(',');
            strArray4 = new string[strArray3.Length];
            for (int index3 = 0; index3 < strArray3.Length; ++index3)
              strArray4[index3] = strArray3[index3];
          }
          else if (strArray1[0].Split(',').Length > 1)
          {
            strArray3 = strArray1[0].Split(',');
            strArray4 = new string[strArray3.Length];
            for (int index3 = 0; index3 < strArray3.Length; ++index3)
              strArray4[index3] = strArray3[index3];
          }
          else
          {
            strArray4 = new string[1]
            {
              strArray1[0]
            };
            strArray3 = new string[1];
          }
          for (int index3 = 0; index3 < strArray3.Length; ++index3)
          {
            if (strArray1.Length == 1)
            {
              stringWriter.WriteLine(strArray4[index3]);
              foreach (XmlNode xmlNode1 in childNodes)
              {
                if (xmlNode1.Name == strArray4[index3])
                  stringWriter.WriteLine(xmlNode1.InnerXml);
                foreach (XmlNode xmlNode2 in xmlNode1.ChildNodes)
                {
                  if (xmlNode2.Name.Split(' ')[0] == strArray4[index3])
                    stringWriter.WriteLine(xmlNode2.InnerXml);
                }
              }
            }
            else if (strArray1.Length == 2)
            {
              string str5 = "";
              if (strArray1[1].IndexOf(">=") != -1)
              {
                str5 = ">=";
                strArray2[0] = strArray1[1].Substring(0, strArray1[1].IndexOf(">="));
                strArray2[1] = strArray1[1].Substring(strArray1[1].IndexOf(">=") + 2, strArray1[1].Length - strArray1[1].IndexOf(">=") - 2);
              }
              else if (strArray1[1].IndexOf("<=") != -1)
              {
                str5 = "<=";
                strArray2[0] = strArray1[1].Substring(0, strArray1[1].IndexOf("<="));
                strArray2[1] = strArray1[1].Substring(strArray1[1].IndexOf("<=") + 2, strArray1[1].Length - strArray1[1].IndexOf("<=") - 2);
              }
              else if (strArray1[1].IndexOf("<>") != -1)
              {
                str5 = "<>";
                strArray2[0] = strArray1[1].Substring(0, strArray1[1].IndexOf("<>"));
                strArray2[1] = strArray1[1].Substring(strArray1[1].IndexOf("<>") + 2, strArray1[1].Length - strArray1[1].IndexOf("<>") - 2);
              }
              else if (strArray1[1].IndexOf("=") != -1)
              {
                str5 = "=";
                strArray2[0] = strArray1[1].Substring(0, strArray1[1].IndexOf("="));
                strArray2[1] = strArray1[1].Substring(strArray1[1].IndexOf("=") + 1, strArray1[1].Length - strArray1[1].IndexOf("=") - 1);
              }
              else if (strArray1[1].IndexOf(">") != -1)
              {
                str5 = ">";
                strArray2[0] = strArray1[1].Substring(0, strArray1[1].IndexOf(">"));
                strArray2[1] = strArray1[1].Substring(strArray1[1].IndexOf(">") + 1, strArray1[1].Length - strArray1[1].IndexOf(">") - 1);
              }
              else if (strArray1[1].IndexOf("<") != -1)
              {
                str5 = "<";
                strArray2[0] = strArray1[1].Substring(0, strArray1[1].IndexOf("<"));
                strArray2[1] = strArray1[1].Substring(strArray1[1].IndexOf("<") + 1, strArray1[1].Length - strArray1[1].IndexOf("<") - 1);
              }
              stringWriter.WriteLine(strArray4[index3]);
              foreach (XmlNode xmlNode1 in childNodes)
              {
                if (xmlNode1.Name == strArray2[0])
                {
                  if (str5 == "=")
                  {
                    if (xmlNode1.InnerText == strArray2[1])
                      stringWriter.WriteLine(xmlNode1.InnerText);
                  }
                  else if (str5 == ">")
                  {
                    if (int.Parse(xmlNode1.InnerText) > int.Parse(strArray2[1]))
                      stringWriter.WriteLine(xmlNode1.InnerText);
                  }
                  else if (str5 == "<")
                  {
                    if (int.Parse(xmlNode1.InnerText) < int.Parse(strArray2[1]))
                      stringWriter.WriteLine(xmlNode1.InnerText);
                  }
                  else if (str5 == ">=")
                  {
                    if (int.Parse(xmlNode1.InnerText) >= int.Parse(strArray2[1]))
                      stringWriter.WriteLine(xmlNode1.InnerText);
                  }
                  else if (str5 == "<=")
                  {
                    if (int.Parse(xmlNode1.InnerText) <= int.Parse(strArray2[1]))
                      stringWriter.WriteLine(xmlNode1.InnerText);
                  }
                  else if (str5 == "<>" && xmlNode1.InnerText != strArray2[1])
                    stringWriter.WriteLine(xmlNode1.InnerText);
                }
                XmlElement xmlElement = (XmlElement) xmlNode1;
                foreach (XmlNode xmlNode2 in xmlElement.ChildNodes)
                {
                  string[] strArray5 = xmlNode2.Name.Split(' ');
                  if (strArray1[1] == " ")
                    strArray1[1] = "";
                  if (strArray5[0] == strArray2[0])
                  {
                    if (str5 == "=")
                    {
                      if (xmlNode2.InnerText == strArray2[1])
                      {
                        foreach (XmlNode xmlNode3 in xmlElement.ChildNodes)
                        {
                          if (xmlNode3.Name.Split(' ')[0] == strArray4[index3])
                            stringWriter.WriteLine(xmlNode3.InnerText);
                        }
                      }
                    }
                    else if (str5 == ">")
                    {
                      if (int.Parse(xmlNode2.InnerText) > int.Parse(strArray2[1]))
                      {
                        foreach (XmlNode xmlNode3 in xmlElement.ChildNodes)
                        {
                          if (xmlNode3.Name.Split(' ')[0] == strArray4[index3])
                            stringWriter.WriteLine(xmlNode3.InnerText);
                        }
                      }
                    }
                    else if (str5 == "<")
                    {
                      if (int.Parse(xmlNode2.InnerText) < int.Parse(strArray2[1]))
                      {
                        foreach (XmlNode xmlNode3 in xmlElement.ChildNodes)
                        {
                          if (xmlNode3.Name.Split(' ')[0] == strArray4[index3])
                            stringWriter.WriteLine(xmlNode3.InnerText);
                        }
                      }
                    }
                    else if (str5 == ">=")
                    {
                      if (int.Parse(xmlNode2.InnerText) >= int.Parse(strArray2[1]))
                      {
                        foreach (XmlNode xmlNode3 in xmlElement.ChildNodes)
                        {
                          if (xmlNode3.Name.Split(' ')[0] == strArray4[index3])
                            stringWriter.WriteLine(xmlNode3.InnerText);
                        }
                      }
                    }
                    else if (str5 == "<=")
                    {
                      if (int.Parse(xmlNode2.InnerText) <= int.Parse(strArray2[1]))
                      {
                        foreach (XmlNode xmlNode3 in xmlElement.ChildNodes)
                        {
                          if (xmlNode3.Name.Split(' ')[0] == strArray4[index3])
                            stringWriter.WriteLine(xmlNode3.InnerText);
                        }
                      }
                    }
                    else if (str5 == "<>" && xmlNode2.InnerText != strArray2[1])
                    {
                      foreach (XmlNode xmlNode3 in xmlElement.ChildNodes)
                      {
                        if (xmlNode3.Name.Split(' ')[0] == strArray4[index3])
                          stringWriter.WriteLine(xmlNode3.InnerText);
                      }
                    }
                  }
                }
              }
            }
          }
          str1 = "Succeeded" + sb.ToString() + strArray3.Length.ToString();
        }
        else
          str1 = "F";
      }
      catch
      {
        str1 = "E";
      }
      return str1;
    }
  }
}
