
// Type: Trand.WinAPI.DirectoryFileManager
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace Trand.WinAPI
{
  public class DirectoryFileManager
  {
    private static int count = 0;
    private static string[] directories;
    private static string[] files;
    private static ArrayList dfcount;
    private static ArrayList list;
    private static Thread dfthread;

    public static int Count
    {
      get
      {
        return DirectoryFileManager.count;
      }
    }

    public static ThreadState DFThreadState
    {
      get
      {
        return DirectoryFileManager.dfthread.ThreadState;
      }
    }

    public static string[] Directories
    {
      get
      {
        DirectoryFileManager.directories = new string[DirectoryFileManager.dfcount.Count];
        DirectoryFileManager.ArrayTransverse(DirectoryFileManager.dfcount, DirectoryFileManager.directories);
        return DirectoryFileManager.directories;
      }
    }

    public static string[] Files
    {
      get
      {
        DirectoryFileManager.files = new string[DirectoryFileManager.dfcount.Count];
        DirectoryFileManager.ArrayTransverse(DirectoryFileManager.dfcount, DirectoryFileManager.files);
        return DirectoryFileManager.files;
      }
    }

    private static bool DirectoryExist(string path)
    {
      return Directory.Exists(path);
    }

    private static void ArrayTransverse(ArrayList al, string[] ar)
    {
      al.ToArray().CopyTo((Array) ar, 0);
    }

    private static string ArrangeExtensionName(string ExtensionName)
    {
      Regex regex = new Regex("^\\.[a-zA-Z]{1,5}$", RegexOptions.IgnoreCase);
      return !ExtensionName.StartsWith(".") ? "." + ExtensionName.ToLower() : ExtensionName.ToLower();
    }

    public static int GetCurrentDirectoryAmount(string path)
    {
      return !DirectoryFileManager.DirectoryExist(path) ? -1 : Directory.GetDirectories(path).Length;
    }

    public static string[] GetCurrentDirectories(string Dir)
    {
      DirectoryFileManager.list = new ArrayList();
      string[] strArray;
      if (DirectoryFileManager.DirectoryExist(Dir))
      {
        foreach (string str in Directory.GetDirectories(Dir))
          DirectoryFileManager.list.Add((object) str);
        DirectoryFileManager.directories = new string[DirectoryFileManager.list.Count];
        DirectoryFileManager.ArrayTransverse(DirectoryFileManager.list, DirectoryFileManager.directories);
        strArray = DirectoryFileManager.directories;
      }
      else
        strArray = (string[]) null;
      return strArray;
    }

    public static int GetDirectoryAmount(string path)
    {
      DirectoryFileManager.dfthread = new Thread(new ParameterizedThreadStart(DirectoryFileManager.GetAllDirectory));
      DirectoryFileManager.dfthread.Priority = ThreadPriority.Lowest;
      DirectoryFileManager.count = Directory.GetDirectories(path).Length;
      DirectoryFileManager.dfcount = new ArrayList();
      DirectoryFileManager.dfthread.Start((object) path);
      return 0;
    }

    public static int GetAllDirectories(string path)
    {
      DirectoryFileManager.dfthread = new Thread(new ParameterizedThreadStart(DirectoryFileManager.GetAllDirectory));
      DirectoryFileManager.dfthread.Priority = ThreadPriority.Lowest;
      DirectoryFileManager.count = Directory.GetDirectories(path).Length;
      DirectoryFileManager.dfcount = new ArrayList();
      foreach (string str in Directory.GetDirectories(path))
        DirectoryFileManager.dfcount.Add((object) str);
      DirectoryFileManager.dfthread.Start((object) path);
      return 0;
    }

    private static void GetAllDirectory(object path)
    {
      string path1 = path.ToString();
      if (!Directory.Exists(path1))
        return;
      foreach (string str1 in Directory.GetDirectories(path1))
      {
        DirectoryFileManager.dfcount.Add((object) str1);
        string str2 = str1;
        if (WindowsAPI.GetFileAttributes(str1) != 22)
        {
          DirectoryFileManager.count += Directory.GetDirectories(str1).Length;
          DirectoryFileManager.GetAllDirectory((object) str2);
        }
      }
    }

    public static int GetCurrentFileAmount(string path)
    {
      return !DirectoryFileManager.DirectoryExist(path) ? 0 : Directory.GetFiles(path).Length;
    }

    public static string[] GetCurrentAllFiles(string Dir)
    {
      DirectoryFileManager.list = new ArrayList();
      string[] strArray;
      if (DirectoryFileManager.DirectoryExist(Dir))
      {
        foreach (string str in Directory.GetFiles(Dir))
          DirectoryFileManager.list.Add((object) str);
        DirectoryFileManager.files = new string[DirectoryFileManager.list.Count];
        DirectoryFileManager.ArrayTransverse(DirectoryFileManager.list, DirectoryFileManager.files);
        strArray = DirectoryFileManager.files;
      }
      else
        strArray = (string[]) null;
      return strArray;
    }

    public static string[] GetCurrentAllFiles(string Dir, string ExtensionName)
    {
      DirectoryFileManager.list = new ArrayList();
      string[] strArray;
      if (DirectoryFileManager.DirectoryExist(Dir))
      {
        foreach (string str in Directory.GetFiles(Dir))
        {
          if (str.EndsWith(ExtensionName))
            DirectoryFileManager.list.Add((object) str);
        }
        DirectoryFileManager.files = new string[DirectoryFileManager.list.Count];
        DirectoryFileManager.ArrayTransverse(DirectoryFileManager.list, DirectoryFileManager.files);
        strArray = DirectoryFileManager.files;
      }
      else
        strArray = (string[]) null;
      return strArray;
    }

    public static int GetFileAmount(string path)
    {
      DirectoryFileManager.dfthread = new Thread(new ParameterizedThreadStart(DirectoryFileManager.GetAllFile));
      DirectoryFileManager.dfthread.Priority = ThreadPriority.Lowest;
      DirectoryFileManager.count = 0;
      DirectoryFileManager.dfcount = new ArrayList();
      DirectoryFileManager.dfthread.Start((object) path);
      return 0;
    }

    public static int GetAllFiles(string path)
    {
      DirectoryFileManager.dfthread = new Thread(new ParameterizedThreadStart(DirectoryFileManager.GetAllFile));
      DirectoryFileManager.dfthread.Priority = ThreadPriority.Lowest;
      DirectoryFileManager.count = 0;
      DirectoryFileManager.dfcount = new ArrayList();
      DirectoryFileManager.dfthread.Start((object) path);
      return 0;
    }

    private static void GetAllFile(object path)
    {
      string path1 = path.ToString();
      if (!Directory.Exists(path1))
        return;
      foreach (string str in Directory.GetFiles(path1))
      {
        DirectoryFileManager.dfcount.Add((object) str);
        ++DirectoryFileManager.count;
      }
      foreach (string lpFileName in Directory.GetDirectories(path1))
      {
        string path2 = lpFileName;
        DirectoryInfo directoryInfo = new DirectoryInfo(path2);
        if (WindowsAPI.GetFileAttributes(lpFileName) != 22)
          DirectoryFileManager.GetAllFile((object) path2);
      }
    }
  }
}
