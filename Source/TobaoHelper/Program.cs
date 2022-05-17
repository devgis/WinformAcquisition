
// Type: TobaoHelper.Program
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.Windows.Forms;

namespace TobaoHelper
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
        //Action
      //if (APIUtils.TestifAlreadyRunning())
      //  return;
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      //LoginForm loginForm = new LoginForm();
      //int num = (int) loginForm.ShowDialog();
      //if (loginForm.DialogResult != DialogResult.OK)
      //  return;
      Application.Run((Form) new MainForm());
    }
  }
}
