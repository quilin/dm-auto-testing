using System;
using System.IO;
using System.Net;
using System.Text;

namespace DmAutoTesting.Extensions
{
    public static class HttpUtilityExtensions
    {
        public static HttpWebResponse GetPage(this string url, CookieCollection cookies = null)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, application/x-shockwave-flash, application/msword, application/vnd.ms-excel, application/vnd.ms-powerpoint, */*";
            request.Headers["Accept-Language"] = "ru-RU";
            request.Headers["User-Agent"] = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; Tablet PC 2.0; OfficeLiveConnector.1.4; OfficeLivePatch.1.3)";
            request.CookieContainer = new CookieContainer();
            if (cookies != null)
            {
                request.CookieContainer.Add(new Uri(url), cookies);
            }
            return (HttpWebResponse) request.GetResponseAsync().Result;
        }

        public static HttpWebResponse PostPage(this string url, byte[] postData, CookieCollection cookies)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, application/x-shockwave-flash, application/msword, application/vnd.ms-excel, application/vnd.ms-powerpoint, */*";
            request.Headers["Accept-Language"] = "ru-RU";
            request.Headers["User-Agent"] = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; Tablet PC 2.0; OfficeLiveConnector.1.4; OfficeLivePatch.1.3)";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = new CookieContainer();
            if (cookies != null)
            {
                request.CookieContainer.Add(new Uri(url), cookies);
            }
            request.GetRequestStreamAsync().Result.Write(postData, 0, postData.Length);
            return (HttpWebResponse) request.GetResponseAsync().Result;
        }

        public static HttpWebResponse PostPage(this string url, string postString, CookieCollection cookies = null)
        {
            var byteArr = Encoding.UTF8.GetBytes(postString);
            return url.PostPage(byteArr, cookies);
        }

        public static string GetResponseContent(this HttpWebResponse response)
        {
            if (response == null)
            {
                return null;
            }

            using (var reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(1251)))
            {
                return reader.ReadToEnd();
            }
        }
    }
}