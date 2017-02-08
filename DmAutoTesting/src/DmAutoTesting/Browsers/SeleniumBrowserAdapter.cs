using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using DmAutoTesting.Pages;
using DmAutoTesting.WebDrivers;
using OpenQA.Selenium;
using Cookie = System.Net.Cookie;
using IJavaScriptExecutor = OpenQA.Selenium.IJavaScriptExecutor;

namespace DmAutoTesting.Browsers
{
    public class SeleniumBrowserAdapter : IBrowserAdapter
    {
        private readonly IWebDriver webDriver;
        private readonly BrowserType browserType;
        private readonly IJavaScriptExecutor scriptExecutor;

        public SeleniumBrowserAdapter(
            ICompositeWebDriverFactory webDriverFactory,
            string logPath
            )
        {
            browserType = BrowserType.Webkit; // todo: put it in environment variables
            webDriver = webDriverFactory.Create(browserType, logPath);
            scriptExecutor = (IJavaScriptExecutor)webDriver;
            LogPath = logPath;
        }

        public bool CanManageCookies => browserType != BrowserType.Trident;

        public CookieCollection Cookies
        {
            get
            {
                var cookieCollection = new CookieCollection();
                var cookies = webDriver.Manage().Cookies.AllCookies;
                foreach (var cookie in cookies)
                {
                    cookieCollection.Add(new Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain));
                }
                return cookieCollection;
            }
        }

        public IPageAdapter Page => new SeleniumPage(webDriver);

        public string LogPath { get; }

        public void ClearCookies()
        {
            webDriver.Manage().Cookies.DeleteAllCookies();
        }

        public void SetCookie(string name, string value)
        {
            scriptExecutor.ExecuteScript($"document.cookie='{name}={value}; path=/'");
        }

        public void SwitchToTab(object pageId)
        {
            webDriver.SwitchTo().Window(pageId.ToString());
        }

        public IPageAdapter OpenNewTab(string url)
        {
            var windowHandles = webDriver.WindowHandles;
            scriptExecutor.ExecuteScript($"window.open('{url}', '_blank');");
            var newWindowHandles = webDriver.WindowHandles;
            var openedWindowHandle = newWindowHandles.Except(windowHandles).Single();
            webDriver.SwitchTo().Window(openedWindowHandle);
            return new SeleniumPage(webDriver);
        }

        public void CloseCurrentTab()
        {
            webDriver.Close();
        }

        public IPageAdapter GoTo(string url)
        {
            webDriver.Url = url;
            return new SeleniumPage(webDriver);
        }

        public Image GetScreenshot()
        {
            var screenshot = ((ITakesScreenshot)webDriver).GetScreenshot();
            using (var memoryStream = new MemoryStream(screenshot.AsByteArray))
            {
                return Image.FromStream(memoryStream);
            }
        }

        public string ExecuteScript(string script)
        {
            return (string)scriptExecutor.ExecuteScript(script);
        }

        public void Dispose()
        {
            webDriver.Dispose();
        }
    }
}