
// Type: DotNet4.Utilities.HttpResult
// Assembly: TobaoHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 225AFE11-BEB6-419B-87A8-C7FB1B58441F
// Assembly location: C:\Users\Administrator\Desktop\程序\AliTrademanager.exe

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace DotNet4.Utilities
{
  public class HttpResult
  {
    private string _html = string.Empty;

    public string Cookie { get; set; }

    public CookieCollection CookieCollection { get; set; }

    public string Html
    {
      get
      {
        return this._html;
      }
      set
      {
        this._html = value;
      }
    }

    public byte[] ResultByte { get; set; }

    public WebHeaderCollection Header { get; set; }

    public string StatusDescription { get; set; }

    public HttpStatusCode StatusCode { get; set; }

    public string ResponseUri { get; set; }

    public string RedirectUrl
    {
      get
      {
        try
        {
          if (this.Header != null)
          {
            if (this.Header.Count > 0)
            {
              if (Enumerable.Any<string>((IEnumerable<string>) this.Header.AllKeys, (Func<string, bool>) (k => k.ToLower().Contains("location"))))
              {
                string relativeUri = this.Header["location"].ToString().ToLower();
                if (!string.IsNullOrWhiteSpace(relativeUri) && (!relativeUri.StartsWith("http://") && !relativeUri.StartsWith("https://")))
                  relativeUri = new Uri(new Uri(this.ResponseUri), relativeUri).AbsoluteUri;
                return relativeUri;
              }
            }
          }
        }
        catch
        {
        }
        return string.Empty;
      }
    }
  }
}
