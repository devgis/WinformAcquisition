
// Type: Trand.WinAPI.AdditionalMethod
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Trand.WinAPI
{
  public class AdditionalMethod
  {
    private Rectangle ctrlRectangle = new Rectangle();
    private bool IsMoving;
    private int ctrlLastWidth;
    private int ctrlLastHeight;
    private int ctrlWidth;
    private int ctrlHeight;
    private int ctrlLeft;
    private int ctrlTop;
    private int cursorL;
    private int cursorT;
    private int ctrlLastLeft;
    private int ctrlLastTop;
    private int Htap;
    private int Wtap;
    private bool ctrlIsResizing;
    private Control ctrl;
    private Form frm;

    public void KillProgram(string ex)
    {
      Process process = new Process();
      process.StartInfo.FileName = "cmd.exe";
      process.StartInfo.UseShellExecute = false;
      process.StartInfo.RedirectStandardInput = true;
      process.StartInfo.RedirectStandardOutput = true;
      process.StartInfo.RedirectStandardError = true;
      process.StartInfo.CreateNoWindow = true;
      process.Start();
      ex = Path.GetFileNameWithoutExtension(ex) + ".exe";
      process.StandardInput.WriteLine("taskkill /im " + ex + " /f");
      process.StandardInput.WriteLine("exit");
      process.WaitForExit();
      process.Close();
      process.Dispose();
    }

    public bool IsAlphabet(string s)
    {
      foreach (char ch in s.ToCharArray())
      {
        if (!WindowsAPI.IsCharAlpha(ch))
          return false;
      }
      return true;
    }

    public bool IsNumeric(string s)
    {
      for (int startIndex = 0; startIndex < s.Length; ++startIndex)
      {
        if (!WindowsAPI.IsCharAlphaNumeric(s.Substring(startIndex, 1)))
          return false;
      }
      return true;
    }

    public bool IsLower(string s)
    {
      foreach (char ch in s.ToCharArray())
      {
        if (!WindowsAPI.IsCharLower(ch))
          return false;
      }
      return true;
    }

    public bool IsUpper(string s)
    {
      foreach (char ch in s.ToCharArray())
      {
        if (!WindowsAPI.IsCharUpper(ch))
          return false;
      }
      return true;
    }

    public void LockRegedit()
    {
      RegeditManageMent regeditManageMent = new RegeditManageMent();
      regeditManageMent.RegeditKey = Registry.LocalMachine;
      regeditManageMent.RegeditPath = "Software\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options";
      regeditManageMent.CreateString("regedit.exe", "Debugger", "123.exe");
      regeditManageMent.CreateString("regedit32.exe", "Debugger", "123.exe");
    }

    public void ReleaseRegedit()
    {
      RegeditManageMent regeditManageMent = new RegeditManageMent();
      regeditManageMent.RegeditKey = Registry.LocalMachine;
      regeditManageMent.RegeditPath = "Software\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options";
      regeditManageMent.RegeditDeleteSubKey("regedit.exe");
      regeditManageMent.RegeditDeleteSubKey("regedit32.exe");
    }

    public void LockMSConfig()
    {
      new RegeditManageMent()
      {
        RegeditKey = Registry.LocalMachine,
        RegeditPath = "Software\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options"
      }.CreateString("msconfig.exe", "Debugger", "123.exe");
    }

    public void ReleaseMSConfig()
    {
      new RegeditManageMent()
      {
        RegeditKey = Registry.LocalMachine,
        RegeditPath = "Software\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options"
      }.RegeditDeleteSubKey("msconfig.exe");
    }

    public void LockCommon()
    {
      RegeditManageMent regeditManageMent = new RegeditManageMent();
      regeditManageMent.RegeditKey = Registry.LocalMachine;
      regeditManageMent.RegeditPath = "Software\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options";
      regeditManageMent.CreateString("qq.exe", "Debugger", "123.exe");
      regeditManageMent.CreateString("notepad.exe", "Debugger", "123.exe");
      regeditManageMent.CreateString("KMPlayer.exe", "Debugger", "123.exe");
      regeditManageMent.CreateString("Thunder.exe", "Debugger", "123.exe");
      regeditManageMent.CreateString("iexplore.exe", "Debugger", "123.exe");
    }

    public void ReleaseCommon()
    {
      RegeditManageMent regeditManageMent = new RegeditManageMent();
      regeditManageMent.RegeditKey = Registry.LocalMachine;
      regeditManageMent.RegeditPath = "Software\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options";
      regeditManageMent.RegeditDeleteSubKey("qq.exe");
      regeditManageMent.RegeditDeleteSubKey("notepad.exe");
      regeditManageMent.RegeditDeleteSubKey("KMPlayer.exe");
      regeditManageMent.RegeditDeleteSubKey("Thunder.exe");
      regeditManageMent.RegeditDeleteSubKey("iexplore.exe");
    }

    public void LockSoftWare(string name)
    {
      name = new APIMethod().PathRemoveExtension(name) + ".exe";
      new RegeditManageMent()
      {
        RegeditKey = Registry.LocalMachine,
        RegeditPath = "Software\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options"
      }.CreateString(name, "Debugger", "123.exe");
    }

    public void ReleaseSoftWare(string name)
    {
      name = new APIMethod().PathRemoveExtension(name) + ".exe";
      new RegeditManageMent()
      {
        RegeditKey = Registry.LocalMachine,
        RegeditPath = "Software\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options"
      }.RegeditDeleteSubKey(name);
    }

    public void ReleaseImage()
    {
      RegeditManageMent regeditManageMent = new RegeditManageMent();
      regeditManageMent.RegeditKey = Registry.LocalMachine;
      regeditManageMent.RegeditPath = "Software\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options";
      foreach (string SubKeyName in regeditManageMent.GetSubNames())
      {
        if (SubKeyName != "DllNXOptions" && SubKeyName != "IEInstal.exe" && SubKeyName != "iexplore.exe")
          regeditManageMent.RegeditDeleteSubKey(SubKeyName);
      }
    }

    public void AddToSystemMenu(string name, string value, string path)
    {
      RegeditManageMent regeditManageMent = new RegeditManageMent();
      regeditManageMent.RegeditKey = Registry.ClassesRoot;
      regeditManageMent.RegeditPath = "*\\shell\\";
      regeditManageMent.CreateString(name, "", value);
      regeditManageMent.RegeditPath = "*\\shell\\" + name + "\\";
      regeditManageMent.CreateString("command", "", path + " %1");
    }

    public void AddToSystemMenuEx(string name, string value, string path)
    {
      name = new APIMethod().PathRemoveExtension(name) + ".exe";
      RegeditManageMent regeditManageMent = new RegeditManageMent();
      regeditManageMent.RegeditKey = Registry.ClassesRoot;
      regeditManageMent.RegeditPath = "Applications\\";
      regeditManageMent.CreateString(name, "", "");
      regeditManageMent.RegeditPath = "Applications\\" + name + "\\";
      regeditManageMent.CreateString("shell", "", "open");
      regeditManageMent.RegeditPath = "Applications\\" + name + "\\shell\\";
      regeditManageMent.CreateString("Enqueue", "", value);
      regeditManageMent.CreateString("open", "", "");
      regeditManageMent.RegeditPath = "Applications\\" + name + "\\shell\\Enqueue\\";
      regeditManageMent.CreateString("command", "", "\"" + path + " /ADD \"%1\"");
      regeditManageMent.RegeditPath = "Applications\\" + name + "\\shell\\open\\";
      regeditManageMent.CreateString("command", "", "\"" + path + "\" \"%1\"");
    }

    public void AddToSystemMenuNew(string ex, string name, string path)
    {
      if (ex.StartsWith("."))
        ex = ex.Substring(1, ex.Length - 1);
      RegeditManageMent regeditManageMent = new RegeditManageMent();
      regeditManageMent.RegeditKey = Registry.ClassesRoot;
      regeditManageMent.CreateString("." + ex, "", name);
      regeditManageMent.RegeditPath = "." + ex + "\\";
      regeditManageMent.CreateString("ShellNew", "", "");
      regeditManageMent.RegeditPath += "ShellNew\\";
      regeditManageMent.SetStringValue("FileName", path);
      regeditManageMent.SetStringValue("NullFile", "");
    }

    public static string GetPassword(string file)
    {
      string str = "";
      try
      {
        FileStream fileStream = System.IO.File.OpenRead(file);
        fileStream.Seek(20L, SeekOrigin.Begin);
        fileStream.ReadByte();
        fileStream.Seek(66L, SeekOrigin.Begin);
        byte[] buffer = new byte[33];
        if (fileStream.Read(buffer, 0, 33) != 33)
          return "";
      }
      catch
      {
      }
      return str;
    }

    public static void ModifyExpandName(ref string path, string exp)
    {
      if (!(Path.GetExtension(path) != exp))
        return;
      path = Path.ChangeExtension(path, exp);
    }

    public string StringEncryption(string str, string password)
    {
      DESCryptoServiceProvider cryptoServiceProvider = new DESCryptoServiceProvider();
      byte[] rgbIV = new byte[8]
      {
        (byte) 18,
        (byte) 52,
        (byte) 86,
        (byte) 120,
        (byte) 144,
        (byte) 171,
        (byte) 205,
        (byte) 239
      };
      byte[] bytes1 = Encoding.UTF8.GetBytes(password);
      byte[] bytes2 = Encoding.UTF8.GetBytes(str);
      MemoryStream memoryStream = new MemoryStream();
      CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, cryptoServiceProvider.CreateEncryptor(bytes1, rgbIV), CryptoStreamMode.Write);
      cryptoStream.Write(bytes2, 0, bytes2.Length);
      cryptoStream.FlushFinalBlock();
      return Convert.ToBase64String(memoryStream.ToArray());
    }

    public string StringDeencryption(string str, string password)
    {
      DESCryptoServiceProvider cryptoServiceProvider = new DESCryptoServiceProvider();
      byte[] rgbIV = new byte[8]
      {
        (byte) 18,
        (byte) 52,
        (byte) 86,
        (byte) 120,
        (byte) 144,
        (byte) 171,
        (byte) 205,
        (byte) 239
      };
      byte[] bytes = Encoding.Default.GetBytes(password);
      byte[] buffer = Convert.FromBase64String(str);
      MemoryStream memoryStream = new MemoryStream();
      CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, cryptoServiceProvider.CreateDecryptor(bytes, rgbIV), CryptoStreamMode.Write);
      cryptoStream.Write(buffer, 0, buffer.Length);
      cryptoStream.FlushFinalBlock();
      return new UTF8Encoding().GetString(memoryStream.ToArray());
    }

    public string GetOriginUrlText(string url)
    {
      try
      {
        string str = "";
        StreamReader streamReader = new StreamReader(WebRequest.Create(url).GetResponse().GetResponseStream(), Encoding.GetEncoding("gb2312"));
        do
        {
          str = str + streamReader.ReadLine() + "\r\n";
        }
        while (!streamReader.EndOfStream);
        return str.Trim();
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

    public Bitmap PartBitmapA(Image BitmapSource, int X, int Y, int Width, int Height)
    {
      Bitmap bitmap1 = new Bitmap(Width, Height);
      Bitmap bitmap2 = new Bitmap(BitmapSource);
      Bitmap bitmap3;
      if (BitmapSource == null)
      {
        bitmap3 = new Bitmap(0, 0);
      }
      else
      {
        try
        {
          for (int x = X; x < X + Width; ++x)
          {
            for (int y = Y; y < Y + Height; ++y)
            {
              System.Drawing.Color pixel = bitmap2.GetPixel(x, y);
              bitmap1.SetPixel(x - X, y - Y, pixel);
            }
          }
        }
        catch
        {
          return (Bitmap) null;
        }
        bitmap3 = bitmap1;
      }
      return bitmap3;
    }

    public Bitmap PartBitmapB(Image BitmapSource, int X, int Y, int Width, int Height)
    {
      Bitmap bitmap = new Bitmap(Width, Height);
      Graphics.FromImage((Image) bitmap).DrawImage(BitmapSource, new Rectangle(new Point(0, 0), new Size(Width, Height)), new Rectangle(new Point(X, Y), new Size(Width, Height)), GraphicsUnit.Pixel);
      return bitmap;
    }

    public Bitmap CombineBitmap(Image Source1, Image Source2, int X, int Y)
    {
      Image image = (Image) Source1.Clone();
      Graphics.FromImage(image).DrawImage(Source2, X, Y);
      return new Bitmap(image);
    }

    public Bitmap ZoomImage(Image img, float scale)
    {
      int width = (int) ((double) img.Size.Width * (double) scale);
      int height = (int) ((double) img.Size.Height * (double) scale);
      Bitmap bitmap1;
      if (width <= 0 || height <= 0)
      {
        bitmap1 = new Bitmap(img);
      }
      else
      {
        Bitmap bitmap2 = new Bitmap(width, height);
        Graphics graphics = Graphics.FromImage((Image) bitmap2);
        graphics.DrawImage(img, new Rectangle(0, 0, width, height), new Rectangle(0, 0, img.Size.Width, img.Size.Height), GraphicsUnit.Pixel);
        graphics.Dispose();
        bitmap1 = bitmap2;
      }
      return bitmap1;
    }

    public Bitmap ZoomImage(Image img, int width, int height)
    {
      Bitmap bitmap1;
      if (width <= 0 || height <= 0)
      {
        bitmap1 = new Bitmap(img);
      }
      else
      {
        Bitmap bitmap2 = new Bitmap(width, height);
        Graphics graphics = Graphics.FromImage((Image) bitmap2);
        graphics.DrawImage(img, new Rectangle(0, 0, width, height), new Rectangle(0, 0, img.Size.Width, img.Size.Height), GraphicsUnit.Pixel);
        graphics.Dispose();
        bitmap1 = bitmap2;
      }
      return bitmap1;
    }

    public void UniqueApplication(string text, string caption)
    {
      if (text == "")
        text = "对不起，程序已经在运行了。本程序不能同时开启两个窗口";
      if (caption == "")
        caption = "提示";
      Process currentProcess = Process.GetCurrentProcess();
      Process[] processes = Process.GetProcesses();
      Process process1 = (Process) null;
      Process process2 = (Process) null;
      foreach (Process process3 in processes)
      {
        if (process3.ProcessName == currentProcess.ProcessName)
        {
          if (process1 != null)
          {
            process2 = process3;
            break;
          }
          process1 = process3;
        }
      }
      if (process1 == null || process2 == null)
        return;
      int num = (int) MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      if (process1.Id == currentProcess.Id)
        process1.Kill();
      else
        process2.Kill();
    }

    public void TextBoxSetting(TextBox UserTextBox)
    {
      UserTextBox.AllowDrop = true;
      UserTextBox.DragEnter += new DragEventHandler(this.UserTextBox_DragEnter);
      UserTextBox.DragDrop += new DragEventHandler(this.UserTextBox_DragDrop);
    }

    private void UserTextBox_DragEnter(object sender, DragEventArgs e)
    {
      if (!e.Data.GetDataPresent(DataFormats.FileDrop))
        return;
      e.Effect = DragDropEffects.All;
    }

    private void UserTextBox_DragDrop(object sender, DragEventArgs e)
    {
      TextBox textBox = (TextBox) sender;
      string path = ((Array) e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
      if (this.CheckFile(path) == -1)
      {
        int num = (int) MessageBox.Show("拒绝访问。", "载入文件", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
        textBox.Text = System.IO.File.ReadAllText(path, Encoding.Default);
    }

    public void RichTextBoxSetting(RichTextBox UserRichTextBox)
    {
      UserRichTextBox.AllowDrop = true;
      UserRichTextBox.DragEnter += new DragEventHandler(this.UserRichTextBox_DragEnter);
      UserRichTextBox.DragDrop += new DragEventHandler(this.UserRichTextBox_DragDrop);
    }

    private void UserRichTextBox_DragEnter(object sender, DragEventArgs e)
    {
      if (!e.Data.GetDataPresent(DataFormats.FileDrop))
        return;
      e.Effect = DragDropEffects.All;
    }

    private void UserRichTextBox_DragDrop(object sender, DragEventArgs e)
    {
      RichTextBox richTextBox = (RichTextBox) sender;
      string path = ((Array) e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
      if (this.CheckFile(path) == -1)
      {
        int num = (int) MessageBox.Show("拒绝访问。", "载入文件", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
        richTextBox.LoadFile(path, RichTextBoxStreamType.PlainText);
    }

    public int CheckFile(string path)
    {
      return !Directory.Exists(path) ? (System.IO.File.Exists(path) ? 1 : 0) : -1;
    }

    public void IsCreateNewFile(out bool create, RichTextBox UserRichTextBox, TextBox UserTextBox)
    {
      create = false;
      int length1 = Path.GetFileNameWithoutExtension(Application.ExecutablePath).Length;
      int length2 = Environment.CommandLine.Length;
      string path = Environment.CommandLine.Substring(length1, length2 - length1).Trim().Split(' ')[0];
      if (this.CheckFile(path) != 0)
        return;
      switch (MessageBox.Show("找不到文件: " + Path.GetFileName(path) + "。\r\n要创建新文件吗?", "载入文件", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
      {
        case DialogResult.Cancel:
          Application.Exit();
          break;
        case DialogResult.Yes:
          System.IO.File.Create(path);
          create = true;
          if (UserTextBox == null)
            UserRichTextBox.LoadFile(Path.GetFullPath(path), RichTextBoxStreamType.PlainText);
          if (UserRichTextBox != null)
            break;
          UserTextBox.Text = System.IO.File.ReadAllText(Path.GetFullPath(path), Encoding.Default);
          break;
      }
    }

    public void ControlDrag(Control c)
    {
      c.AllowDrop = true;
      c.DragEnter += new DragEventHandler(this.c_DragEnter);
      c.DragDrop += new DragEventHandler(this.c_DragDrop);
    }

    private void c_DragEnter(object sender, DragEventArgs e)
    {
      if (!e.Data.GetDataPresent(DataFormats.FileDrop))
        return;
      e.Effect = DragDropEffects.All;
    }

    private void c_DragDrop(object sender, DragEventArgs e)
    {
      ((Control) sender).Text = ((Array) e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
    }

    public void FormDrag(Form form)
    {
      form.AllowDrop = true;
      form.DragEnter += new DragEventHandler(this.form_DragEnter);
      form.DragDrop += new DragEventHandler(this.form_DragDrop);
    }

    private void form_DragEnter(object sender, DragEventArgs e)
    {
      if (!e.Data.GetDataPresent(DataFormats.FileDrop))
        return;
      e.Effect = DragDropEffects.All;
    }

    private void form_DragDrop(object sender, DragEventArgs e)
    {
      Form form = (Form) sender;
      string FileName = ((Array) e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
      APIMethod apiMethod = new APIMethod();
      form.Icon = apiMethod.GetFileIconEx(FileName);
    }

    public void ResizeAction(Control c, Form frm)
    {
      this.ctrl = c;
      this.frm = frm;
      this.Htap = this.frm.Height - this.frm.ClientRectangle.Height;
      this.Wtap = this.frm.Width - this.frm.ClientRectangle.Width;
      this.ctrl.MouseDown += new MouseEventHandler(this.MouseDown);
      this.ctrl.MouseMove += new MouseEventHandler(this.MouseMove);
      this.ctrl.MouseUp += new MouseEventHandler(this.MouseUp);
    }

    private void MouseMove(object sender, MouseEventArgs e)
    {
      if (this.frm == null || e.Button != MouseButtons.Left)
        return;
      if (this.IsMoving)
      {
        if (this.ctrlLastLeft == 0)
          this.ctrlLastLeft = this.ctrlLeft;
        if (this.ctrlLastTop == 0)
          this.ctrlLastTop = this.ctrlTop;
        int num1 = Cursor.Position.X - this.cursorL + this.frm.DesktopLocation.X + this.Wtap + this.ctrl.Location.X;
        int num2 = Cursor.Position.Y - this.cursorT + this.frm.DesktopLocation.Y + this.Htap + this.ctrl.Location.Y;
        if (num1 < this.frm.DesktopLocation.X + this.Wtap)
          num1 = this.frm.DesktopLocation.X + this.Wtap;
        if (num2 < this.frm.DesktopLocation.Y + this.Htap)
          num2 = this.frm.DesktopLocation.Y + this.Htap;
        this.ctrlLeft = num1;
        this.ctrlTop = num2;
        this.ctrlRectangle.Location = new Point(this.ctrlLastLeft, this.ctrlLastTop);
        this.ctrlRectangle.Size = new Size(this.ctrlWidth, this.ctrlHeight);
        this.ctrlRectangle.Location = new Point(this.ctrlLeft, this.ctrlTop);
        this.ctrlRectangle.Size = new Size(this.ctrlWidth, this.ctrlHeight);
      }
      else
      {
        int num1 = Cursor.Position.X - this.frm.DesktopLocation.X - this.Wtap - this.ctrl.Location.X;
        int num2 = Cursor.Position.Y - this.frm.DesktopLocation.Y - this.Htap - this.ctrl.Location.Y;
        if (num1 < 2)
          num1 = 1;
        if (num2 < 2)
          num2 = 1;
        this.ctrlWidth = num1;
        this.ctrlHeight = num2;
        if (this.ctrlLastWidth == 0)
          this.ctrlLastWidth = this.ctrlWidth;
        if (this.ctrlLastHeight == 0)
          this.ctrlLastHeight = this.ctrlHeight;
        if (this.ctrlIsResizing)
        {
          this.ctrlRectangle.Location = new Point(this.frm.DesktopLocation.X + this.ctrl.Left + this.Wtap, this.frm.DesktopLocation.Y + this.Htap + this.ctrl.Top);
          this.ctrlRectangle.Size = new Size(this.ctrlLastWidth, this.ctrlLastHeight);
        }
        this.ctrlIsResizing = true;
        ControlPaint.DrawReversibleFrame(this.ctrlRectangle, System.Drawing.Color.Empty, FrameStyle.Dashed);
        this.ctrlLastWidth = this.ctrlWidth;
        this.ctrlLastHeight = this.ctrlHeight;
        this.ctrlRectangle.Location = new Point(this.frm.DesktopLocation.X + this.Wtap + this.ctrl.Left, this.frm.DesktopLocation.Y + this.Htap + this.ctrl.Top);
        this.ctrlRectangle.Size = new Size(this.ctrlWidth, this.ctrlHeight);
        ControlPaint.DrawReversibleFrame(this.ctrlRectangle, System.Drawing.Color.Empty, FrameStyle.Dashed);
      }
    }

    private void MouseDown(object sender, MouseEventArgs e)
    {
      if (this.frm == null)
        return;
      if (e.X < this.ctrl.Width - 10 || e.Y < this.ctrl.Height - 10)
      {
        this.IsMoving = true;
        this.ctrlLeft = this.frm.DesktopLocation.X + this.Wtap + this.ctrl.Left;
        this.ctrlTop = this.frm.DesktopLocation.Y + this.Htap + this.ctrl.Top;
        this.cursorL = Cursor.Position.X;
        this.cursorT = Cursor.Position.Y;
        this.ctrlWidth = this.ctrl.Width;
        this.ctrlHeight = this.ctrl.Height;
      }
      this.ctrlRectangle.Location = new Point(this.ctrlLeft, this.ctrlTop);
      this.ctrlRectangle.Size = new Size(this.ctrlWidth, this.ctrlHeight);
    }

    private void MouseUp(object sender, MouseEventArgs e)
    {
      if (this.frm == null)
        return;
      this.ctrlIsResizing = false;
      if (this.IsMoving)
      {
        this.ctrlRectangle.Location = new Point(this.ctrlLeft, this.ctrlTop);
        this.ctrlRectangle.Size = new Size(this.ctrlWidth, this.ctrlHeight);
        this.IsMoving = false;
        this.ctrl.Refresh();
      }
      else
      {
        this.ctrlRectangle.Location = new Point(this.frm.DesktopLocation.X + this.Wtap + this.ctrl.Left, this.frm.DesktopLocation.Y + this.Htap + this.ctrl.Top);
        this.ctrlRectangle.Size = new Size(this.ctrlWidth, this.ctrlHeight);
        ControlPaint.DrawReversibleFrame(this.ctrlRectangle, System.Drawing.Color.Empty, FrameStyle.Dashed);
        this.ctrl.Width = this.ctrlWidth;
        this.ctrl.Height = this.ctrlHeight;
        this.ctrl.Refresh();
      }
    }

    public static void Serialize(string path, params string[] content)
    {
      Hashtable hashtable = new Hashtable();
      for (int index = 0; index < content.Length; ++index)
        hashtable.Add((object) content[index], (object) index.ToString());
      FileStream fileStream = new FileStream(path, FileMode.Create);
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      try
      {
        binaryFormatter.Serialize((Stream) fileStream, (object) hashtable);
      }
      catch (SerializationException ex)
      {
        int num = (int) MessageBox.Show("Failed to serialize. Reason: " + ex.Message);
      }
      finally
      {
        fileStream.Close();
      }
    }

    public static string Deserialize(string path)
    {
      Hashtable hashtable = (Hashtable) null;
      string str = "";
      FileStream fileStream = new FileStream(path, FileMode.Open);
      try
      {
        hashtable = (Hashtable) new BinaryFormatter().Deserialize((Stream) fileStream);
      }
      catch (SerializationException ex)
      {
        int num = (int) MessageBox.Show("Failed to deserialize. Reason: " + ex.Message);
        return "";
      }
      finally
      {
        fileStream.Close();
      }
      ArrayList arrayList1 = new ArrayList();
      ArrayList arrayList2 = new ArrayList();
      foreach (DictionaryEntry dictionaryEntry in hashtable)
      {
        arrayList1.Add(dictionaryEntry.Key);
        arrayList2.Add(dictionaryEntry.Value);
      }
      for (int index1 = 0; index1 < arrayList1.Count; ++index1)
      {
        int index2 = arrayList2.IndexOf((object) index1.ToString());
        if (index2 != -1)
        {
          object obj1 = arrayList1[index1];
          arrayList1[index1] = arrayList1[index2];
          arrayList1[index2] = obj1;
          object obj2 = arrayList2[index1];
          arrayList2[index1] = arrayList2[index2];
          arrayList2[index2] = obj2;
        }
        str = str + arrayList1[index1].ToString() + "\r\n";
      }
      return str;
    }

    public class FileTypeRegInfo
    {
      public string ExtendName;
      public string Description;
      public string IcoPath;
      public string ExePath;

      public FileTypeRegInfo()
      {
      }

      public FileTypeRegInfo(string extendName)
      {
        this.ExtendName = extendName;
      }
    }

    public class FileTypeRegister
    {
      public static void RegisterFileType(AdditionalMethod.FileTypeRegInfo regInfo)
      {
        string subkey = regInfo.ExtendName.Substring(1, regInfo.ExtendName.Length - 1).ToUpper() + "_FileType";
        RegistryKey subKey1 = Registry.ClassesRoot.CreateSubKey(regInfo.ExtendName);
        subKey1.SetValue("", (object) subkey);
        subKey1.Close();
        RegistryKey subKey2 = Registry.ClassesRoot.CreateSubKey(subkey);
        subKey2.SetValue("", (object) regInfo.Description);
        subKey2.CreateSubKey("DefaultIcon").SetValue("", (object) regInfo.IcoPath);
        subKey2.CreateSubKey("Shell").CreateSubKey("Open").CreateSubKey("Command").SetValue("", (object) (regInfo.ExePath + " %1"));
        subKey2.Close();
      }

      public static AdditionalMethod.FileTypeRegInfo GetFileTypeRegInfo(string extendName)
      {
        AdditionalMethod.FileTypeRegInfo fileTypeRegInfo1;
        if (!AdditionalMethod.FileTypeRegister.FileTypeRegistered(extendName))
        {
          fileTypeRegInfo1 = (AdditionalMethod.FileTypeRegInfo) null;
        }
        else
        {
          AdditionalMethod.FileTypeRegInfo fileTypeRegInfo2 = new AdditionalMethod.FileTypeRegInfo(extendName);
          string name = extendName.Substring(1, extendName.Length - 1).ToUpper() + "_FileType";
          RegistryKey registryKey1 = Registry.ClassesRoot.OpenSubKey(name);
          fileTypeRegInfo2.Description = registryKey1.GetValue("").ToString();
          RegistryKey registryKey2 = registryKey1.OpenSubKey("DefaultIcon");
          fileTypeRegInfo2.IcoPath = registryKey2.GetValue("").ToString();
          string str = registryKey1.OpenSubKey("Shell").OpenSubKey("Open").OpenSubKey("Command").GetValue("").ToString();
          fileTypeRegInfo2.ExePath = str.Substring(0, str.Length - 3);
          fileTypeRegInfo1 = fileTypeRegInfo2;
        }
        return fileTypeRegInfo1;
      }

      public static bool UpdateFileTypeRegInfo(AdditionalMethod.FileTypeRegInfo regInfo)
      {
        bool flag;
        if (!AdditionalMethod.FileTypeRegister.FileTypeRegistered(regInfo.ExtendName))
        {
          flag = false;
        }
        else
        {
          string str = regInfo.ExtendName;
          string name = str.Substring(1, str.Length - 1).ToUpper() + "_FileType";
          RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(name, true);
          registryKey.SetValue("", (object) regInfo.Description);
          registryKey.OpenSubKey("DefaultIcon", true).SetValue("", (object) regInfo.IcoPath);
          registryKey.OpenSubKey("Shell").OpenSubKey("Open").OpenSubKey("Command", true).SetValue("", (object) (regInfo.ExePath + " %1"));
          registryKey.Close();
          flag = true;
        }
        return flag;
      }

      public static bool FileTypeRegistered(string extendName)
      {
        return Registry.ClassesRoot.OpenSubKey(extendName) != null;
      }
    }

    public class MediaFileInfo
    {
      private AdditionalMethod.MediaFileInfo.AudioInfo info;

      public MediaFileInfo(string mp3FilePos)
      {
        this.info = this.GetMediaInfo(this.GetLast128(mp3FilePos));
      }

      public string GetOriginalName()
      {
        return this.FormatString(this.info.Title.Trim()) + "-" + this.FormatString(this.info.Artist.Trim());
      }

      public AdditionalMethod.MediaFileInfo.AudioInfo GetInfo()
      {
        return this.info;
      }

      private string FormatString(string str)
      {
        return str.Replace("\0", "");
      }

      private byte[] GetLast128(string FileName)
      {
        FileStream fileStream = new FileStream(FileName, FileMode.Open, FileAccess.Read);
        Stream stream = (Stream) fileStream;
        stream.Seek((long) sbyte.MinValue, SeekOrigin.End);
        byte[] buffer = new byte[128];
        stream.Read(buffer, 0, 128);
        fileStream.Close();
        stream.Close();
        return buffer;
      }

      public AdditionalMethod.MediaFileInfo.AudioInfo GetMediaInfo(byte[] Info)
      {
        AdditionalMethod.MediaFileInfo.AudioInfo audioInfo = new AdditionalMethod.MediaFileInfo.AudioInfo();
        string str = (string) null;
        int num1 = 0;
        int num2 = 0;
        for (int index = num2; index < num2 + 3; ++index)
        {
          str += (string) (object) (char) Info[index];
          ++num1;
        }
        int num3 = num1;
        audioInfo.identify = str;
        byte[] b1 = new byte[30];
        int index1 = 0;
        for (int index2 = num3; index2 < num3 + 30; ++index2)
        {
          b1[index1] = Info[index2];
          ++num1;
          ++index1;
        }
        int num4 = num1;
        audioInfo.Title = this.ByteToString(b1);
        int index3 = 0;
        byte[] b2 = new byte[30];
        for (int index2 = num4; index2 < num4 + 30; ++index2)
        {
          b2[index3] = Info[index2];
          ++num1;
          ++index3;
        }
        int num5 = num1;
        audioInfo.Artist = this.ByteToString(b2);
        int index4 = 0;
        byte[] b3 = new byte[30];
        for (int index2 = num5; index2 < num5 + 30; ++index2)
        {
          b3[index4] = Info[index2];
          ++num1;
          ++index4;
        }
        int num6 = num1;
        audioInfo.Album = this.ByteToString(b3);
        int index5 = 0;
        byte[] b4 = new byte[4];
        for (int index2 = num6; index2 < num6 + 4; ++index2)
        {
          b4[index5] = Info[index2];
          ++num1;
          ++index5;
        }
        int num7 = num1;
        audioInfo.Year = this.ByteToString(b4);
        int index6 = 0;
        byte[] b5 = new byte[28];
        for (int index2 = num7; index2 < num7 + 25; ++index2)
        {
          b5[index6] = Info[index2];
          ++num1;
          ++index6;
        }
        audioInfo.Comment = this.ByteToString(b5);
        int num8;
        audioInfo.reserved1 = (char) Info[num8 = num1 + 1];
        int num9;
        audioInfo.reserved2 = (char) Info[num9 = num8 + 1];
        audioInfo.reserved3 = (char) Info[num9 + 1];
        return audioInfo;
      }

      private string ByteToString(byte[] b)
      {
        string @string = Encoding.GetEncoding("GB2312").GetString(b);
        return @string.Substring(0, @string.IndexOf("#CONTENT#") >= 0 ? @string.IndexOf("#CONTENT#") : @string.Length).Replace("\0", "");
      }

      public struct AudioInfo
      {
        public string identify;
        public string Title;
        public string Artist;
        public string Album;
        public string Year;
        public string Comment;
        public char reserved1;
        public char reserved2;
        public char reserved3;
      }
    }

    private class CalUtility
    {
      private StringBuilder StrB;
      private int iCurr;
      private int iCount;

      public CalUtility(string calStr)
      {
        this.StrB = new StringBuilder(calStr.Trim());
        this.iCount = Encoding.Default.GetByteCount(calStr.Trim());
      }

      public string getItem()
      {
        string str1;
        if (this.iCurr == this.iCount)
        {
          str1 = "";
        }
        else
        {
          char c = this.StrB[this.iCurr];
          bool flag = this.IsNum(c);
          if (!flag)
          {
            ++this.iCurr;
            str1 = c.ToString();
          }
          else
          {
            string str2 = "";
            for (; this.IsNum(c) == flag && this.iCurr < this.iCount; ++this.iCurr)
            {
              c = this.StrB[this.iCurr];
              if (this.IsNum(c) == flag)
                str2 += (string) (object) c;
              else
                break;
            }
            str1 = str2;
          }
        }
        return str1;
      }

      public bool IsNum(char c)
      {
        if ((int) c < 48 || (int) c > 57)
          return (int) c == 46;
        return true;
      }

      public bool IsNum(string c)
      {
        if (c.Equals(""))
          return false;
        if ((int) c[0] < 48 || (int) c[0] > 57)
          return (int) c[0] == 46;
        return true;
      }

      public bool Compare(string str1, string str2)
      {
        return this.getPriority(str1) >= this.getPriority(str2);
      }

      public int getPriority(string str)
      {
        return !str.Equals("") ? (!str.Equals("(") ? (str.Equals("+") || str.Equals("-") ? 1 : (str.Equals("*") || str.Equals("/") ? 2 : (!str.Equals(")") ? 0 : 0))) : 0) : -1;
      }
    }

    private interface IOper
    {
      object Oper(object o1, object o2);
    }

    private class OperAdd : AdditionalMethod.IOper
    {
      public object Oper(object o1, object o2)
      {
        return (object) (Decimal.Parse(o1.ToString()) + Decimal.Parse(o2.ToString()));
      }

      public class OperDec : AdditionalMethod.IOper
      {
        public object Oper(object o1, object o2)
        {
          return (object) (Decimal.Parse(o1.ToString()) - Decimal.Parse(o2.ToString()));
        }
      }

      public class OperRide : AdditionalMethod.IOper
      {
        public object Oper(object o1, object o2)
        {
          return (object) (Decimal.Parse(o1.ToString()) * Decimal.Parse(o2.ToString()));
        }
      }

      public class OperDiv : AdditionalMethod.IOper
      {
        public object Oper(object o1, object o2)
        {
          return (object) (Decimal.Parse(o1.ToString()) / Decimal.Parse(o2.ToString()));
        }
      }
    }

    private class OperFactory
    {
      public AdditionalMethod.IOper CreateOper(string Oper)
      {
        return !Oper.Equals("+") ? (!Oper.Equals("-") ? (!Oper.Equals("*") ? (!Oper.Equals("/") ? (AdditionalMethod.IOper) null : (AdditionalMethod.IOper) new AdditionalMethod.OperAdd.OperDiv()) : (AdditionalMethod.IOper) new AdditionalMethod.OperAdd.OperRide()) : (AdditionalMethod.IOper) new AdditionalMethod.OperAdd.OperDec()) : (AdditionalMethod.IOper) new AdditionalMethod.OperAdd();
      }
    }

    public class Calculate
    {
      private ArrayList HList;
      public ArrayList Vlist;
      private AdditionalMethod.CalUtility cu;
      private AdditionalMethod.OperFactory of;

      public Calculate()
      {
      }

      public Calculate(string str)
      {
        this.HList = new ArrayList();
        this.Vlist = new ArrayList();
        this.of = new AdditionalMethod.OperFactory();
        this.cu = new AdditionalMethod.CalUtility(str);
      }

      public object Compute()
      {
        string str = this.cu.getItem();
        while (true)
        {
          if (this.cu.IsNum(str))
            this.Vlist.Add((object) str);
          else
            this.Cal(str);
          if (!str.Equals(""))
            str = this.cu.getItem();
          else
            break;
        }
        return this.Vlist[0];
      }

      public object Compute(string str)
      {
        this.HList = new ArrayList();
        this.Vlist = new ArrayList();
        this.of = new AdditionalMethod.OperFactory();
        this.cu = new AdditionalMethod.CalUtility(str);
        string str1 = this.cu.getItem();
        while (true)
        {
          if (this.cu.IsNum(str1))
            this.Vlist.Add((object) str1);
          else
            this.Cal(str1);
          if (!str1.Equals(""))
            str1 = this.cu.getItem();
          else
            break;
        }
        return this.Vlist[0];
      }

      private void Cal(string str)
      {
        if (str.Equals("") && this.HList.Count == 0)
          return;
        if (this.HList.Count > 0)
        {
          if (this.HList[this.HList.Count - 1].ToString().Equals("(") && str.Equals(")"))
          {
            this.HList.RemoveAt(this.HList.Count - 1);
            if (this.HList.Count <= 0)
              return;
            str = this.HList[this.HList.Count - 1].ToString();
            this.HList.RemoveAt(this.HList.Count - 1);
            this.Cal(str);
          }
          else if (this.cu.Compare(this.HList[this.HList.Count - 1].ToString(), str))
          {
            AdditionalMethod.IOper oper = this.of.CreateOper(this.HList[this.HList.Count - 1].ToString());
            if (oper == null)
              return;
            this.Vlist[this.Vlist.Count - 2] = oper.Oper(this.Vlist[this.Vlist.Count - 2], this.Vlist[this.Vlist.Count - 1]);
            this.HList.RemoveAt(this.HList.Count - 1);
            this.Vlist.RemoveAt(this.Vlist.Count - 1);
            this.Cal(str);
          }
          else
          {
            if (str.Equals(""))
              return;
            this.HList.Add((object) str);
          }
        }
        else
        {
          if (str.Equals(""))
            return;
          this.HList.Add((object) str);
        }
      }
    }

    public class Encryption
    {
      public static string GenerateKey()
      {
        return Encoding.ASCII.GetString(DES.Create().Key);
      }

      public static void EncryptFile(string sInputFilename, string sOutputFilename, string sKey)
      {
        FileStream fileStream1 = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);
        FileStream fileStream2 = new FileStream(sOutputFilename, FileMode.Create, FileAccess.Write);
        DESCryptoServiceProvider cryptoServiceProvider = new DESCryptoServiceProvider();
        cryptoServiceProvider.Key = Encoding.ASCII.GetBytes(sKey);
        cryptoServiceProvider.IV = Encoding.ASCII.GetBytes(sKey);
        ICryptoTransform encryptor = cryptoServiceProvider.CreateEncryptor();
        CryptoStream cryptoStream = new CryptoStream((Stream) fileStream2, encryptor, CryptoStreamMode.Write);
        byte[] buffer = new byte[fileStream1.Length];
        fileStream1.Read(buffer, 0, buffer.Length);
        cryptoStream.Write(buffer, 0, buffer.Length);
        cryptoStream.Close();
        fileStream1.Close();
        fileStream2.Close();
      }

      public static void DecryptFile(string sInputFilename, string sOutputFilename, string sKey)
      {
        DESCryptoServiceProvider cryptoServiceProvider = new DESCryptoServiceProvider();
        cryptoServiceProvider.Key = Encoding.ASCII.GetBytes(sKey);
        cryptoServiceProvider.IV = Encoding.ASCII.GetBytes(sKey);
        CryptoStream cryptoStream = new CryptoStream((Stream) new FileStream(sInputFilename, FileMode.Open, FileAccess.Read), cryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Read);
        StreamWriter streamWriter = new StreamWriter(sOutputFilename);
        streamWriter.Write(new StreamReader((Stream) cryptoStream).ReadToEnd());
        streamWriter.Flush();
        streamWriter.Close();
      }
    }

    [Guid("00000001-0000-0000-C000-000000000046")]
    [ComVisible(false)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    internal interface IClassFactory
    {
      void CreateInstance([MarshalAs(UnmanagedType.Interface)] object pUnkOuter, ref Guid refiid, [MarshalAs(UnmanagedType.Interface)] out object ppunk);

      void LockServer(bool fLock);
    }

    internal static class ComHelper
    {
      private static AdditionalMethod.ComHelper.DllList _dllList = new AdditionalMethod.ComHelper.DllList();

      internal static AdditionalMethod.IClassFactory GetClassFactory(string dllName, string filterPersistClass)
      {
        return AdditionalMethod.ComHelper.GetClassFactoryFromDll(dllName, filterPersistClass);
      }

      private static AdditionalMethod.IClassFactory GetClassFactoryFromDll(string dllName, string filterPersistClass)
      {
        IntPtr num = AdditionalMethod.ComHelper.Win32NativeMethods.LoadLibrary(dllName);
        AdditionalMethod.IClassFactory classFactory;
        if (num == IntPtr.Zero)
        {
          classFactory = (AdditionalMethod.IClassFactory) null;
        }
        else
        {
          AdditionalMethod.ComHelper._dllList.AddDllHandle(num);
          IntPtr procAddress = AdditionalMethod.ComHelper.Win32NativeMethods.GetProcAddress(num, "DllGetClassObject");
          if (procAddress == IntPtr.Zero)
          {
            classFactory = (AdditionalMethod.IClassFactory) null;
          }
          else
          {
            AdditionalMethod.ComHelper.DllGetClassObject dllGetClassObject = (AdditionalMethod.ComHelper.DllGetClassObject) Marshal.GetDelegateForFunctionPointer(procAddress, typeof (AdditionalMethod.ComHelper.DllGetClassObject));
            Guid ClassId = new Guid(filterPersistClass);
            Guid InterfaceId = new Guid("00000001-0000-0000-C000-000000000046");
            object ppunk;
            classFactory = dllGetClassObject(ref ClassId, ref InterfaceId, out ppunk) == 0 ? ppunk as AdditionalMethod.IClassFactory : (AdditionalMethod.IClassFactory) null;
          }
        }
        return classFactory;
      }

      private delegate int DllGetClassObject(ref Guid ClassId, ref Guid InterfaceId, [MarshalAs(UnmanagedType.Interface)] out object ppunk);

      private class Win32NativeMethods
      {
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string lpFileName);
      }

      private class DllList
      {
        private List<IntPtr> _dllList = new List<IntPtr>();

        public void AddDllHandle(IntPtr dllHandle)
        {
          lock (this._dllList)
            this._dllList.Add(dllHandle);
        }
      }
    }

    public class FilterReader : TextReader
    {
      private AdditionalMethod.IFilter _filter;
      private bool _done;
      private AdditionalMethod.STAT_CHUNK _currentChunk;
      private bool _currentChunkValid;
      private char[] _charsLeftFromLastRead;

      public FilterReader(string fileName)
      {
        this._filter = AdditionalMethod.FilterLoader.LoadAndInitIFilter(fileName);
        if (this._filter == null)
          throw new ArgumentException("no filter defined for " + fileName);
      }

      ~FilterReader()
      {
        this.Dispose(false);
      }

      public override void Close()
      {
        this.Dispose(true);
        GC.SuppressFinalize((object) this);
      }

      protected override void Dispose(bool disposing)
      {
        if (this._filter == null)
          return;
        Marshal.ReleaseComObject((object) this._filter);
      }

      public override int Read(char[] array, int offset, int count)
      {
          int num = 0;
          int num2 = 0;
          while (!this._done && num2 < count)
          {
              if (this._charsLeftFromLastRead != null)
              {
                  int num3 = (this._charsLeftFromLastRead.Length < count - num2) ? this._charsLeftFromLastRead.Length : (count - num2);
                  Array.Copy(this._charsLeftFromLastRead, 0, array, offset + num2, num3);
                  num2 += num3;
                  if (num3 < this._charsLeftFromLastRead.Length)
                  {
                      char[] array2 = new char[this._charsLeftFromLastRead.Length - num3];
                      Array.Copy(this._charsLeftFromLastRead, num3, array2, 0, array2.Length);
                      this._charsLeftFromLastRead = array2;
                  }
                  else
                  {
                      this._charsLeftFromLastRead = null;
                  }
              }
              else
              {
                  if (!this._currentChunkValid)
                  {
                      AdditionalMethod.IFilterReturnCode chunk = this._filter.GetChunk(out this._currentChunk);
                      this._currentChunkValid = (chunk == AdditionalMethod.IFilterReturnCode.S_OK && (this._currentChunk.flags & AdditionalMethod.CHUNKSTATE.CHUNK_TEXT) != (AdditionalMethod.CHUNKSTATE)0);
                      if (chunk == (AdditionalMethod.IFilterReturnCode)2147751680u)
                      {
                          num++;
                      }
                      if (num > 1)
                      {
                          this._done = true;
                      }
                  }
                  if (this._currentChunkValid)
                  {
                      uint num4 = (uint)(count - num2);
                      if (num4 < 8192u)
                      {
                          num4 = 8192u;
                      }
                      char[] array3 = new char[num4];
                      AdditionalMethod.IFilterReturnCode text = this._filter.GetText(ref num4, array3);
                      if (text == AdditionalMethod.IFilterReturnCode.S_OK || text == AdditionalMethod.IFilterReturnCode.FILTER_S_LAST_TEXT)
                      {
                          int num5 = (int)num4;
                          if (num5 + num2 > count)
                          {
                              int num6 = num5 + num2 - count;
                              this._charsLeftFromLastRead = new char[num6];
                              Array.Copy(array3, num5 - num6, this._charsLeftFromLastRead, 0, num6);
                              num5 -= num6;
                          }
                          else
                          {
                              this._charsLeftFromLastRead = null;
                          }
                          Array.Copy(array3, 0, array, offset + num2, num5);
                          num2 += num5;
                      }
                      if (text == AdditionalMethod.IFilterReturnCode.FILTER_S_LAST_TEXT || text == (AdditionalMethod.IFilterReturnCode)2147751681u)
                      {
                          this._currentChunkValid = false;
                      }
                  }
              }
          }
          return num2;
      }
    }

    private static class FilterLoader
    {
      private static Dictionary<string, AdditionalMethod.FilterLoader.CacheEntry> _cache = new Dictionary<string, AdditionalMethod.FilterLoader.CacheEntry>();

      private static string ReadStrFromHKLM(string key)
      {
        return AdditionalMethod.FilterLoader.ReadStrFromHKLM(key, (string) null);
      }

      private static string ReadStrFromHKLM(string key, string value)
      {
        RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(key);
        if (registryKey == null)
          return (string) null;
        using (registryKey)
          return (string) registryKey.GetValue(value);
      }

      private static AdditionalMethod.IFilter LoadIFilter(string ext)
      {
        string dllName;
        string filterPersistClass;
        return !AdditionalMethod.FilterLoader.GetFilterDllAndClass(ext, out dllName, out filterPersistClass) ? (AdditionalMethod.IFilter) null : AdditionalMethod.FilterLoader.LoadFilterFromDll(dllName, filterPersistClass);
      }

      internal static AdditionalMethod.IFilter LoadAndInitIFilter(string fileName)
      {
        return AdditionalMethod.FilterLoader.LoadAndInitIFilter(fileName, Path.GetExtension(fileName));
      }

      internal static AdditionalMethod.IFilter LoadAndInitIFilter(string fileName, string extension)
      {
        AdditionalMethod.IFilter filter1 = AdditionalMethod.FilterLoader.LoadIFilter(extension);
        AdditionalMethod.IFilter filter2;
        if (filter1 == null)
        {
          filter2 = (AdditionalMethod.IFilter) null;
        }
        else
        {
          IPersistFile persistFile = filter1 as IPersistFile;
          if (persistFile != null)
          {
            persistFile.Load(fileName, 0);
            AdditionalMethod.IFILTER_INIT grfFlags = AdditionalMethod.IFILTER_INIT.CANON_PARAGRAPHS | AdditionalMethod.IFILTER_INIT.HARD_LINE_BREAKS | AdditionalMethod.IFILTER_INIT.CANON_HYPHENS | AdditionalMethod.IFILTER_INIT.CANON_SPACES | AdditionalMethod.IFILTER_INIT.APPLY_INDEX_ATTRIBUTES | AdditionalMethod.IFILTER_INIT.FILTER_OWNED_VALUE_OK;
            AdditionalMethod.IFILTER_FLAGS pdwFlags;
            if (filter1.Init(grfFlags, 0, IntPtr.Zero, out pdwFlags) == AdditionalMethod.IFilterReturnCode.S_OK)
              return filter1;
          }
          Marshal.ReleaseComObject((object) filter1);
          filter2 = (AdditionalMethod.IFilter) null;
        }
        return filter2;
      }

      private static AdditionalMethod.IFilter LoadFilterFromDll(string dllName, string filterPersistClass)
      {
        AdditionalMethod.IClassFactory classFactory = AdditionalMethod.ComHelper.GetClassFactory(dllName, filterPersistClass);
        AdditionalMethod.IFilter filter;
        if (classFactory == null)
        {
          filter = (AdditionalMethod.IFilter) null;
        }
        else
        {
          Guid refiid = new Guid("89BCB740-6119-101A-BCB7-00DD010655AF");
          object ppunk;
          classFactory.CreateInstance((object) null, ref refiid, out ppunk);
          filter = ppunk as AdditionalMethod.IFilter;
        }
        return filter;
      }

      private static bool GetFilterDllAndClass(string ext, out string dllName, out string filterPersistClass)
      {
        if (!AdditionalMethod.FilterLoader.GetFilterDllAndClassFromCache(ext, out dllName, out filterPersistClass))
        {
          string persistentHandlerClass = AdditionalMethod.FilterLoader.GetPersistentHandlerClass(ext, true);
          if (persistentHandlerClass != null)
            AdditionalMethod.FilterLoader.GetFilterDllAndClassFromPersistentHandler(persistentHandlerClass, out dllName, out filterPersistClass);
          AdditionalMethod.FilterLoader.AddExtensionToCache(ext, dllName, filterPersistClass);
        }
        if (dllName != null)
          return filterPersistClass != null;
        return false;
      }

      private static void AddExtensionToCache(string ext, string dllName, string filterPersistClass)
      {
        lock (AdditionalMethod.FilterLoader._cache)
          AdditionalMethod.FilterLoader._cache.Add(ext.ToLower(), new AdditionalMethod.FilterLoader.CacheEntry(dllName, filterPersistClass));
      }

      private static bool GetFilterDllAndClassFromPersistentHandler(string persistentHandlerClass, out string dllName, out string filterPersistClass)
      {
        dllName = (string) null;
        filterPersistClass = (string) null;
        filterPersistClass = AdditionalMethod.FilterLoader.ReadStrFromHKLM("Software\\Classes\\CLSID\\" + persistentHandlerClass + "\\PersistentAddinsRegistered\\{89BCB740-6119-101A-BCB7-00DD010655AF}");
        bool flag;
        if (string.IsNullOrEmpty(filterPersistClass))
        {
          flag = false;
        }
        else
        {
          dllName = AdditionalMethod.FilterLoader.ReadStrFromHKLM("Software\\Classes\\CLSID\\" + filterPersistClass + "\\InprocServer32");
          flag = !string.IsNullOrEmpty(dllName);
        }
        return flag;
      }

      private static string GetPersistentHandlerClass(string ext, bool searchContentType)
      {
        string str = AdditionalMethod.FilterLoader.GetPersistentHandlerClassFromExtension(ext);
        if (string.IsNullOrEmpty(str))
          str = AdditionalMethod.FilterLoader.GetPersistentHandlerClassFromDocumentType(ext);
        if (searchContentType && string.IsNullOrEmpty(str))
          str = AdditionalMethod.FilterLoader.GetPersistentHandlerClassFromContentType(ext);
        return str;
      }

      private static string GetPersistentHandlerClassFromContentType(string ext)
      {
        string str1 = AdditionalMethod.FilterLoader.ReadStrFromHKLM("Software\\Classes\\" + ext, "Content Type");
        string str2;
        if (string.IsNullOrEmpty(str1))
        {
          str2 = (string) null;
        }
        else
        {
          string ext1 = AdditionalMethod.FilterLoader.ReadStrFromHKLM("Software\\Classes\\MIME\\Database\\Content Type\\" + str1, "Extension");
          str2 = !ext.Equals(ext1, StringComparison.CurrentCultureIgnoreCase) ? AdditionalMethod.FilterLoader.GetPersistentHandlerClass(ext1, false) : (string) null;
        }
        return str2;
      }

      private static string GetPersistentHandlerClassFromDocumentType(string ext)
      {
        string str1 = AdditionalMethod.FilterLoader.ReadStrFromHKLM("Software\\Classes\\" + ext);
        string str2;
        if (string.IsNullOrEmpty(str1))
        {
          str2 = (string) null;
        }
        else
        {
          string str3 = AdditionalMethod.FilterLoader.ReadStrFromHKLM("Software\\Classes\\" + str1 + "\\CLSID");
          str2 = !string.IsNullOrEmpty(str1) ? AdditionalMethod.FilterLoader.ReadStrFromHKLM("Software\\Classes\\CLSID\\" + str3 + "\\PersistentHandler") : (string) null;
        }
        return str2;
      }

      private static string GetPersistentHandlerClassFromExtension(string ext)
      {
        return AdditionalMethod.FilterLoader.ReadStrFromHKLM("Software\\Classes\\" + ext + "\\PersistentHandler");
      }

      private static bool GetFilterDllAndClassFromCache(string ext, out string dllName, out string filterPersistClass)
      {
        string key = ext.ToLower();
        lock (AdditionalMethod.FilterLoader._cache)
        {
          AdditionalMethod.FilterLoader.CacheEntry local_3;
          if (AdditionalMethod.FilterLoader._cache.TryGetValue(key, out local_3))
          {
            dllName = local_3.DllName;
            filterPersistClass = local_3.ClassName;
            return true;
          }
        }
        dllName = (string) null;
        filterPersistClass = (string) null;
        return false;
      }

      private class CacheEntry
      {
        public string DllName;
        public string ClassName;

        public CacheEntry(string dllName, string className)
        {
          this.DllName = dllName;
          this.ClassName = className;
        }
      }
    }

    public struct FULLPROPSPEC
    {
      public Guid guidPropSet;
      public AdditionalMethod.PROPSPEC psProperty;
    }

    internal struct FILTERREGION
    {
      public int idChunk;
      public int cwcStart;
      public int cwcExtent;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct PROPSPEC
    {
      [FieldOffset(0)]
      public int ulKind;
      [FieldOffset(4)]
      public int propid;
      [FieldOffset(4)]
      public IntPtr lpwstr;
    }

    [Flags]
    internal enum IFILTER_FLAGS
    {
      IFILTER_FLAGS_OLE_PROPERTIES = 1,
    }

    [Flags]
    internal enum IFILTER_INIT
    {
      NONE = 0,
      CANON_PARAGRAPHS = 1,
      HARD_LINE_BREAKS = 2,
      CANON_HYPHENS = 4,
      CANON_SPACES = 8,
      APPLY_INDEX_ATTRIBUTES = 16,
      APPLY_CRAWL_ATTRIBUTES = 256,
      APPLY_OTHER_ATTRIBUTES = 32,
      INDEXING_ONLY = 64,
      SEARCH_LINKS = 128,
      FILTER_OWNED_VALUE_OK = 512,
    }

    public struct STAT_CHUNK
    {
      public int idChunk;
      [MarshalAs(UnmanagedType.U4)]
      public AdditionalMethod.CHUNK_BREAKTYPE breakType;
      [MarshalAs(UnmanagedType.U4)]
      public AdditionalMethod.CHUNKSTATE flags;
      public int locale;
      public AdditionalMethod.FULLPROPSPEC attribute;
      public int idChunkSource;
      public int cwcStartSource;
      public int cwcLenSource;
    }

    public enum CHUNK_BREAKTYPE
    {
      CHUNK_NO_BREAK,
      CHUNK_EOW,
      CHUNK_EOS,
      CHUNK_EOP,
      CHUNK_EOC,
    }

    public enum CHUNKSTATE
    {
      CHUNK_TEXT = 1,
      CHUNK_VALUE = 2,
      CHUNK_FILTER_OWNED_VALUE = 4,
    }

    internal enum IFilterReturnCode : uint
    {
      S_OK = 0U,
      FILTER_W_MONIKER_CLIPPED = 268036U,
      FILTER_S_LAST_TEXT = 268041U,
      FILTER_S_LAST_VALUES = 268042U,
      E_FAIL = 2147483656U,
      E_NOTIMPL = 2147500033U,
      FILTER_E_END_OF_CHUNKS = 2147751680U,
      FILTER_E_NO_MORE_TEXT = 2147751681U,
      FILTER_E_NO_MORE_VALUES = 2147751682U,
      FILTER_E_ACCESS = 2147751683U,
      FILTER_E_NO_TEXT = 2147751685U,
      FILTER_E_EMBEDDING_UNAVAILABLE = 2147751687U,
      FILTER_E_LINK_UNAVAILABLE = 2147751688U,
      FILTER_E_PASSWORD = 2147751691U,
      FILTER_E_UNKNOWNFORMAT = 2147751692U,
      E_ACCESSDENIED = 2147942405U,
      E_HANDLE = 2147942406U,
      E_OUTOFMEMORY = 2147942414U,
      E_INVALIDARG = 2147942487U,
    }

    [Guid("89BCB740-6119-101A-BCB7-00DD010655AF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    internal interface IFilter
    {
      [MethodImpl(MethodImplOptions.PreserveSig)]
      AdditionalMethod.IFilterReturnCode Init(AdditionalMethod.IFILTER_INIT grfFlags, int cAttributes, IntPtr aAttributes, out AdditionalMethod.IFILTER_FLAGS pdwFlags);

      [MethodImpl(MethodImplOptions.PreserveSig)]
      AdditionalMethod.IFilterReturnCode GetChunk(out AdditionalMethod.STAT_CHUNK pStat);

      [MethodImpl(MethodImplOptions.PreserveSig)]
      AdditionalMethod.IFilterReturnCode GetText(ref uint pcwcBuffer, [MarshalAs(UnmanagedType.LPArray), Out] char[] awcBuffer);

      [MethodImpl(MethodImplOptions.PreserveSig)]
      int GetValue(ref IntPtr PropVal);

      [MethodImpl(MethodImplOptions.PreserveSig)]
      int BindRegion(ref AdditionalMethod.FILTERREGION origPos, ref Guid riid, ref object ppunk);
    }

    public class MathEx
    {
      public int CommonMultiple(int val1, int val2)
      {
        int num = this.CommonDivisor(val1, val2);
        return val1 / num * (val2 / num) * num;
      }

      public int CommonDivisor(int val1, int val2)
      {
        if (val1 < val2)
          this.Swap(ref val1, ref val2);
        for (int index = val1 % val2; index != 0; index = val1 % val2)
        {
          val1 = val2;
          val2 = index;
        }
        return val2;
      }

      public void Swap(ref int val1, ref int val2)
      {
        int num = val1;
        val1 = val2;
        val2 = num;
      }

      public object MaxValue(int[] values)
      {
        int num1 = values[0];
        for (int index = 0; index < values.Length; ++index)
        {
          int num2 = values[index];
          if (num1 < num2)
            num1 = num2;
        }
        return (object) num1;
      }

      public object MaxValue(long[] values)
      {
        long num1 = values[0];
        for (int index = 0; index < values.Length; ++index)
        {
          long num2 = values[index];
          if (num1 < num2)
            num1 = num2;
        }
        return (object) num1;
      }

      public object MaxValue(float[] values)
      {
        float num1 = values[0];
        for (int index = 0; index < values.Length; ++index)
        {
          float num2 = values[index];
          if ((double) num1 < (double) num2)
            num1 = num2;
        }
        return (object) num1;
      }

      public object MaxValue(double[] values)
      {
        double num1 = values[0];
        for (int index = 0; index < values.Length; ++index)
        {
          double num2 = values[index];
          if (num1 < num2)
            num1 = num2;
        }
        return (object) num1;
      }

      public object MaxValue(Decimal[] values)
      {
        Decimal num1 = values[0];
        for (int index = 0; index < values.Length; ++index)
        {
          Decimal num2 = values[index];
          if (num1 < num2)
            num1 = num2;
        }
        return (object) num1;
      }

      public object MinValue(int[] values)
      {
        int num1 = values[0];
        for (int index = 0; index < values.Length; ++index)
        {
          int num2 = values[index];
          if (num1 > num2)
            num1 = num2;
        }
        return (object) num1;
      }

      public object MinValue(long[] values)
      {
        long num1 = values[0];
        for (int index = 0; index < values.Length; ++index)
        {
          long num2 = values[index];
          if (num1 > num2)
            num1 = num2;
        }
        return (object) num1;
      }

      public object MinValue(float[] values)
      {
        float num1 = values[0];
        for (int index = 0; index < values.Length; ++index)
        {
          float num2 = values[index];
          if ((double) num1 > (double) num2)
            num1 = num2;
        }
        return (object) num1;
      }

      public object MinValue(double[] values)
      {
        double num1 = values[0];
        for (int index = 0; index < values.Length; ++index)
        {
          double num2 = values[index];
          if (num1 > num2)
            num1 = num2;
        }
        return (object) num1;
      }

      public object MinValue(Decimal[] values)
      {
        Decimal num1 = values[0];
        for (int index = 0; index < values.Length; ++index)
        {
          Decimal num2 = values[index];
          if (num1 > num2)
            num1 = num2;
        }
        return (object) num1;
      }
    }
  }
}
