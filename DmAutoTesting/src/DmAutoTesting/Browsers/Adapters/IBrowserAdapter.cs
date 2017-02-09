using System;
using System.Drawing;
using System.Net;
using DmAutoTesting.Pages.Adapters;

namespace DmAutoTesting.Browsers.Adapters
{
    public interface IBrowserAdapter : IDisposable
    {
        IPageAdapter CurrentPage { get; }
        IPageAdapter GoTo(string url);
        IPageAdapter OpenNewTab(string url);
        IPageAdapter SwitchToTab(object pageId);
        IPageAdapter CloseCurrentTab();

        bool CanManageCookies { get; }
        CookieCollection Cookies { get; }
        void ClearCookies();
        void SetCookie(string name, string value);

        string ExecuteScript(string script);
        
        Image GetScreenshot();
    }
}