
// Type: TobaoHelper.FiddlerHelper
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using Fiddler;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TobaoHelper
{
  public class FiddlerHelper
  {
    private static List<string> MIMETypes = new List<string>();
    public static string UrlCapture_Key = string.Empty;
    public static string UrlCapture_Cert = string.Empty;

    static FiddlerHelper()
    {
      FiddlerHelper.MIMETypes.Add("text/html");
      FiddlerHelper.MIMETypes.Add("application/json");
      FiddlerHelper.MIMETypes.Add("application/x-javascript");
    }

    public static void InitFiddlerApplication()
    {
      FiddlerApplication.Prefs.SetInt32Pref("fiddler.certmaker.bc.RootKeyLength", 1024);
      FiddlerApplication.Prefs.SetInt32Pref("fiddler.certmaker.bc.KeyLength", 1024);
      FiddlerApplication.Prefs.SetStringPref("fiddler.certmaker.bc.RootCN", "Symantec Global CA - G5");
      FiddlerApplication.Prefs.SetStringPref("fiddler.certmaker.bc.RootFriendly", "Symantec Corporation");
      if (!File.Exists(TBHelper.AppBaseDirectory + "UrlCapture_Key.dat") || !File.Exists(TBHelper.AppBaseDirectory + "UrlCapture_Cert.dat"))
        return;
      FiddlerHelper.UrlCapture_Cert = File.ReadAllText(TBHelper.AppBaseDirectory + "UrlCapture_Cert.dat");
      FiddlerHelper.UrlCapture_Key = File.ReadAllText(TBHelper.AppBaseDirectory + "UrlCapture_Key.dat");
      FiddlerApplication.Prefs.SetStringPref("fiddler.certmaker.bc.cert", FiddlerHelper.UrlCapture_Cert);
      FiddlerApplication.Prefs.SetStringPref("fiddler.certmaker.bc.key", FiddlerHelper.UrlCapture_Key);
    }

    public static string GetSessionHtmlText(Session sess)
    {
      sess.utilDecodeResponse();
      return !sess.ResponseHeaders.ExistsAndContains("Content-Type", "UTF-8") ? Encoding.Default.GetString(sess.responseBodyBytes) : Encoding.UTF8.GetString(sess.responseBodyBytes);
    }

    public static bool IsMIMEType(string mimeType)
    {
      return FiddlerHelper.MIMETypes.Contains(mimeType);
    }

    public static bool InstallCertificate()
    {
      if (!CertMaker.rootCertExists())
      {
        if (!CertMaker.createRootCert() || !CertMaker.trustRootCert())
          return false;
        FiddlerHelper.UrlCapture_Cert = FiddlerApplication.Prefs.GetStringPref("fiddler.certmaker.bc.cert", (string) null);
        FiddlerHelper.UrlCapture_Key = FiddlerApplication.Prefs.GetStringPref("fiddler.certmaker.bc.key", (string) null);
        if (!string.IsNullOrEmpty(FiddlerHelper.UrlCapture_Cert) && !string.IsNullOrEmpty(FiddlerHelper.UrlCapture_Key))
        {
          File.WriteAllText(TBHelper.AppBaseDirectory + "UrlCapture_Cert.dat", FiddlerHelper.UrlCapture_Cert);
          File.WriteAllText(TBHelper.AppBaseDirectory + "UrlCapture_Key.dat", FiddlerHelper.UrlCapture_Key);
        }
      }
      return true;
    }

    public static bool UninstallCertificate()
    {
      if (CertMaker.rootCertExists() && !CertMaker.removeFiddlerGeneratedCerts(true))
        return false;
      FiddlerHelper.UrlCapture_Cert = (string) null;
      FiddlerHelper.UrlCapture_Key = (string) null;
      if (File.Exists(TBHelper.AppBaseDirectory + "UrlCapture_Key.dat"))
        File.Delete(TBHelper.AppBaseDirectory + "UrlCapture_Key.dat");
      if (File.Exists(TBHelper.AppBaseDirectory + "UrlCapture_Cert.dat"))
        File.Delete(TBHelper.AppBaseDirectory + "UrlCapture_Cert.dat");
      return true;
    }
  }
}
