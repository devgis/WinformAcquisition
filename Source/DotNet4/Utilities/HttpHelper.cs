
// Type: DotNet4.Utilities.HttpHelper
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace DotNet4.Utilities
{
  public class HttpHelper
  {
    private Encoding encoding = Encoding.Default;
    private Encoding postencoding = Encoding.Default;
    private HttpWebRequest request;
    private HttpWebResponse response;

    public HttpResult GetHtml(HttpItem item)
    {
      HttpResult result = new HttpResult();
      try
      {
        this.SetRequest(item);
      }
      catch (Exception ex)
      {
        return new HttpResult()
        {
          Cookie = string.Empty,
          Header = (WebHeaderCollection) null,
          Html = ex.Message,
          StatusDescription = "配置参数时出错：" + ex.Message
        };
      }
      try
      {
        using (this.response = (HttpWebResponse) this.request.GetResponse())
          this.GetData(item, result);
      }
      catch (WebException ex)
      {
        if (ex.Response != null)
        {
          using (this.response = (HttpWebResponse) ex.Response)
            this.GetData(item, result);
        }
        else
          result.Html = ex.Message;
      }
      catch (Exception ex)
      {
        result.Html = ex.Message;
      }
      if (item.IsToLower)
        result.Html = result.Html.ToLower();
      return result;
    }

    public bool GetHtml2(HttpItem item)
    {
      try
      {
        this.SetRequest(item);
      }
      catch (Exception ex)
      {
        return false;
      }
      try
      {
        using (this.response = (HttpWebResponse) this.request.GetResponse())
          return this.response.StatusCode == HttpStatusCode.OK;
      }
      catch (WebException ex)
      {
        return false;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    private void GetData(HttpItem item, HttpResult result)
    {
      result.StatusCode = this.response.StatusCode;
      result.StatusDescription = this.response.StatusDescription;
      result.Header = this.response.Headers;
      result.ResponseUri = this.response.ResponseUri.ToString();
      if (this.response.Cookies != null)
        result.CookieCollection = this.response.Cookies;
      if (this.response.Headers["set-cookie"] != null)
        result.Cookie = this.response.Headers["set-cookie"];
      byte[] @byte = this.GetByte();
      if (@byte != null & @byte.Length > 0)
      {
        this.SetEncoding(item, result, @byte);
        result.Html = this.encoding.GetString(@byte);
      }
      else
        result.Html = string.Empty;
    }

    private void SetEncoding(HttpItem item, HttpResult result, byte[] ResponseByte)
    {
      if (item.ResultType == ResultType.Byte)
        result.ResultByte = ResponseByte;
      if (this.encoding != null)
        return;
      Match match = Regex.Match(Encoding.Default.GetString(ResponseByte), "<meta[^<]*charset=([^<]*)[\"']", RegexOptions.IgnoreCase);
      string str = string.Empty;
      if (match != null && match.Groups.Count > 0)
        str = match.Groups[1].Value.ToLower().Trim();
      if (str.Length > 2)
      {
        try
        {
          this.encoding = Encoding.GetEncoding(str.Replace("\"", string.Empty).Replace("'", "").Replace(";", "").Replace("iso-8859-1", "gbk").Trim());
        }
        catch
        {
          if (string.IsNullOrEmpty(this.response.CharacterSet))
            this.encoding = Encoding.UTF8;
          else
            this.encoding = Encoding.GetEncoding(this.response.CharacterSet);
        }
      }
      else if (string.IsNullOrEmpty(this.response.CharacterSet))
        this.encoding = Encoding.UTF8;
      else
        this.encoding = Encoding.GetEncoding(this.response.CharacterSet);
    }

    private byte[] GetByte()
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        if (this.response.ContentEncoding != null && this.response.ContentEncoding.Equals("gzip", StringComparison.InvariantCultureIgnoreCase))
          new GZipStream(this.response.GetResponseStream(), CompressionMode.Decompress).CopyTo((Stream) memoryStream, 10240);
        else
          this.response.GetResponseStream().CopyTo((Stream) memoryStream, 10240);
        return memoryStream.ToArray();
      }
    }

    private void SetRequest(HttpItem item)
    {
      this.SetCer(item);
      if (item.Header != null && item.Header.Count > 0)
      {
        foreach (string name in item.Header.AllKeys)
          this.request.Headers.Add(name, item.Header[name]);
      }
      this.SetProxy(item);
      if (item.ProtocolVersion != (Version) null)
        this.request.ProtocolVersion = item.ProtocolVersion;
      this.request.ServicePoint.Expect100Continue = item.Expect100Continue;
      this.request.Method = item.Method;
      this.request.Timeout = item.Timeout;
      this.request.KeepAlive = item.KeepAlive;
      this.request.ReadWriteTimeout = item.ReadWriteTimeout;
      if (!string.IsNullOrWhiteSpace(item.Host))
        this.request.Host = item.Host;
      if (item.IfModifiedSince.HasValue)
        this.request.IfModifiedSince = Convert.ToDateTime((object) item.IfModifiedSince);
      this.request.Accept = item.Accept;
      this.request.ContentType = item.ContentType;
      this.request.UserAgent = item.UserAgent;
      this.encoding = item.Encoding;
      this.request.Credentials = item.ICredentials;
      this.SetCookie(item);
      this.request.Referer = item.Referer;
      this.request.AllowAutoRedirect = item.Allowautoredirect;
      if (item.MaximumAutomaticRedirections > 0)
        this.request.MaximumAutomaticRedirections = item.MaximumAutomaticRedirections;
      this.SetPostData(item);
      if (item.Connectionlimit <= 0)
        return;
      this.request.ServicePoint.ConnectionLimit = item.Connectionlimit;
    }

    private void SetCer(HttpItem item)
    {
      if (!string.IsNullOrWhiteSpace(item.CerPath))
      {
        ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(this.CheckValidationResult);
        this.request = (HttpWebRequest) WebRequest.Create(item.URL);
        this.SetCerList(item);
        this.request.ClientCertificates.Add(new X509Certificate(item.CerPath));
      }
      else
      {
        this.request = (HttpWebRequest) WebRequest.Create(item.URL);
        this.SetCerList(item);
      }
    }

    private void SetCerList(HttpItem item)
    {
      if (item.ClentCertificates == null || item.ClentCertificates.Count <= 0)
        return;
      foreach (X509Certificate x509Certificate in item.ClentCertificates)
        this.request.ClientCertificates.Add(x509Certificate);
    }

    private void SetCookie(HttpItem item)
    {
      if (!string.IsNullOrEmpty(item.Cookie))
        this.request.Headers[HttpRequestHeader.Cookie] = item.Cookie;
      if (item.ResultCookieType != ResultCookieType.CookieCollection)
        return;
      this.request.CookieContainer = new CookieContainer();
      if (item.CookieCollection == null || item.CookieCollection.Count <= 0)
        return;
      this.request.CookieContainer.Add(item.CookieCollection);
    }

    private void SetPostData(HttpItem item)
    {
      if (this.request.Method.Trim().ToLower().Contains("get"))
        return;
      if (item.PostEncoding != null)
        this.postencoding = item.PostEncoding;
      byte[] buffer = (byte[]) null;
      if (item.PostDataType == PostDataType.Byte && item.PostdataByte != null && item.PostdataByte.Length > 0)
        buffer = item.PostdataByte;
      else if (item.PostDataType == PostDataType.FilePath && !string.IsNullOrWhiteSpace(item.Postdata))
      {
        StreamReader streamReader = new StreamReader(item.Postdata, this.postencoding);
        buffer = this.postencoding.GetBytes(streamReader.ReadToEnd());
        streamReader.Close();
      }
      else if (!string.IsNullOrWhiteSpace(item.Postdata))
        buffer = this.postencoding.GetBytes(item.Postdata);
      if (buffer == null)
        return;
      this.request.ContentLength = (long) buffer.Length;
      this.request.GetRequestStream().Write(buffer, 0, buffer.Length);
    }

    private void SetProxy(HttpItem item)
    {
      bool flag = false;
      if (!string.IsNullOrWhiteSpace(item.ProxyIp))
        flag = item.ProxyIp.ToLower().Contains("ieproxy");
      if (!string.IsNullOrWhiteSpace(item.ProxyIp) && !flag)
      {
        if (item.ProxyIp.Contains(":"))
        {
          string[] strArray = item.ProxyIp.Split(':');
          this.request.Proxy = (IWebProxy) new WebProxy(strArray[0].Trim(), Convert.ToInt32(strArray[1].Trim()))
          {
            Credentials = (ICredentials) new NetworkCredential(item.ProxyUserName, item.ProxyPwd)
          };
        }
        else
          this.request.Proxy = (IWebProxy) new WebProxy(item.ProxyIp, false)
          {
            Credentials = (ICredentials) new NetworkCredential(item.ProxyUserName, item.ProxyPwd)
          };
      }
      else
      {
        if (flag)
          return;
        this.request.Proxy = (IWebProxy) item.WebProxy;
      }
    }

    private bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
    {
      return true;
    }
  }
}
