
// Type: TobaoHelper.CaptureConfiguration
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System.Collections.Generic;
using TrandExp.DotNet.Utils;

namespace TobaoHelper
{
  public class CaptureConfiguration
  {
    public static AdvSettings _advSettings = new AdvSettings();
    public static Dictionary<string, string> HotKeys = (Dictionary<string, string>) null;
    public static string ProxHost = "";
    public static int ProxyPort = 0;
    public static bool ProxyRunning = false;
    public static string ConnectionMode = "http";

    static CaptureConfiguration()
    {
      CaptureConfiguration.ProxyPort = 8888;
      CaptureConfiguration.ConnectionMode = "http";
      CaptureConfiguration.HotKeys = new Dictionary<string, string>();
      IniFile iniFile = new IniFile("config.ini");
      CaptureConfiguration.ProxyPort = iniFile.ReadInteger("Configuration", "ProxyPort", 8888);
      CaptureConfiguration.HotKeys.Add("StartKey", iniFile.ReadString("HotKey", "StartKey", "无+Alt+无+S"));
      CaptureConfiguration.HotKeys.Add("StopKey", iniFile.ReadString("HotKey", "StopKey", "无+Alt+无+P"));
      CaptureConfiguration.HotKeys.Add("HideKey", iniFile.ReadString("HotKey", "HideKey", "无+Alt+无+I"));
      CaptureConfiguration.HotKeys.Add("HttpKey", iniFile.ReadString("HotKey", "HttpKey", "无+Alt+无+H"));
      CaptureConfiguration.HotKeys.Add("HttpsKey", iniFile.ReadString("HotKey", "HttpsKey", "无+Alt+无+K"));
      CaptureConfiguration._advSettings.ClearListRecyledItems = iniFile.ReadBool("AdvanceSettings", "ClearListRecyledItems", false);
      CaptureConfiguration._advSettings.ClearTaoBaoListRecyledItems = iniFile.ReadBool("AdvanceSettings", "ClearTaoBaoListRecyledItems", false);
      CaptureConfiguration._advSettings.ClearLogistics = iniFile.ReadBool("AdvanceSettings", "ClearLogistics", false);
      CaptureConfiguration._advSettings.ClearNotice = iniFile.ReadBool("AdvanceSettings", "ClearNotice", false);
      CaptureConfiguration._advSettings.UseFakeWindow = iniFile.ReadBool("AdvanceSettings", "UseFakeWindow", false);
      CaptureConfiguration._advSettings.AlipayRecalculate = iniFile.ReadBool("AdvanceSettings", "AlipayRecalculate", false);
      CaptureConfiguration._advSettings.RemovePlaint = iniFile.ReadBool("AdvanceSettings", "RemovePlaint", false);
      CaptureConfiguration._advSettings.DefiningDisplay = iniFile.ReadBool("AdvanceSettings", "DefiningDisplay", false);
      CaptureConfiguration._advSettings.DefiningStop = iniFile.ReadBool("AdvanceSettings", "DefiningStop", false);
      CaptureConfiguration._advSettings.HideGrowth = iniFile.ReadBool("AdvanceSettings", "HideGrowth", false);
    }
  }
}
