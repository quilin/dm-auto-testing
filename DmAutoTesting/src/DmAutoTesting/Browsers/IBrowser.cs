using System;
using DmAutoTesting.Pages;
using DmAutoTesting.WebDrivers;

namespace DmAutoTesting.Browsers
{
    public interface IBrowser : IDisposable
    {
        bool CanManageCookies { get; }
        string LogPath { get; }
        IJavaScriptExecutor JavaScriptExecutor { get; }

        void ClearCookies();
        void SetCookie(string name, string value);
        void GoTo(string url);
        void SwitchToTab(Page page);
        T OpenNewTab<T>(string uri) where T : Page, new();
        void CloseCurrentTab();
        T GoToPage<T>(string uri) where T : Page, new();
        T WaitForPage<T>() where T : Page, new();
        void SaveFile(string fileName, string url);
        void SaveScreenshot();
    }
}