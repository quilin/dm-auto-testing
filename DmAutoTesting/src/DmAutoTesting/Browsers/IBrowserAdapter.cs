using System;
using System.Drawing;
using System.Net;
using DmAutoTesting.Pages;

namespace DmAutoTesting.Browsers
{
    public interface IBrowserAdapter : IDisposable
    {
        bool CanManageCookies { get; }
        CookieCollection Cookies { get; }
        IPageAdapter Page { get; }
        string LogPath { get; }

        void ClearCookies();
        void SetCookie(string name, string value);
        void SwitchToTab(object pageId);
        IPageAdapter OpenNewTab(string url);
        void CloseCurrentTab();
        IPageAdapter GoTo(string url);
        Image GetScreenshot();
        string ExecuteScript(string script);
    }
}