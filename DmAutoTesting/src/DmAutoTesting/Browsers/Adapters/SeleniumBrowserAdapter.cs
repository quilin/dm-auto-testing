using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using DmAutoTesting.Pages.Adapters;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using Cookie = System.Net.Cookie;

namespace DmAutoTesting.Browsers.Adapters
{
    public class SeleniumBrowserAdapter : IBrowserAdapter
    {
        private readonly IWebDriver webDriver;
        private readonly IJavaScriptExecutor javaScriptExecutor;

        public SeleniumBrowserAdapter(
            IWebDriver webDriver
            )
        {
            this.webDriver = webDriver;
            javaScriptExecutor = (IJavaScriptExecutor)webDriver;
        }

        public IPageAdapter CurrentPage => new SeleniumPageAdapter(webDriver);
        public IPageAdapter GoTo(string url)
        {
            webDriver.Url = url;
            return CurrentPage;
        }

        public IPageAdapter OpenNewTab(string url)
        {
            var windowHandles = webDriver.WindowHandles;
            javaScriptExecutor.ExecuteScript($"window.open('{url}', '_blank');");
            var newWindowHandles = webDriver.WindowHandles;
            var openedWindowHandle = newWindowHandles.Except(windowHandles).Single();
            webDriver.SwitchTo().Window(openedWindowHandle);
            return CurrentPage;
        }

        public IPageAdapter SwitchToTab(object pageId)
        {
            webDriver.SwitchTo().Window(pageId.ToString());
            return CurrentPage;
        }

        public IPageAdapter CloseCurrentTab()
        {
            webDriver.Close();
            // TODO: check for all the tabs closed case
            return CurrentPage;
        }

        public bool CanManageCookies => !(webDriver is InternetExplorerDriver);

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
        public void ClearCookies()
        {
            webDriver.Manage().Cookies.DeleteAllCookies();
        }

        public void SetCookie(string name, string value)
        {
            javaScriptExecutor.ExecuteScript($"document.cookie='{name}={value}; path=/'");
        }

        public string ExecuteScript(string script)
        {
            return (string)javaScriptExecutor.ExecuteScript(script);
        }
        
        public Image GetScreenshot()
        {
            var screenshot = ((ITakesScreenshot) webDriver).GetScreenshot();
            using (var ms = new MemoryStream(screenshot.AsByteArray))
            {
                return Image.FromStream(ms);
            }
        }

        public void Dispose()
        {
            webDriver.Dispose();
        }
    }
}