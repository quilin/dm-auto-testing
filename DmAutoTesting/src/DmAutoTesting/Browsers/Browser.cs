using DmAutoTesting.Core;
using DmAutoTesting.Extensions;
using DmAutoTesting.Pages;
using DmAutoTesting.WebDrivers;

namespace DmAutoTesting.Browsers
{
    public class Browser : IBrowser
    {
        private readonly IPageFactory pageFactory;
        private readonly IBrowserAdapter browserAdapter;
        private readonly string siteUrl;
        private readonly ITestResultsStorage testResultsStorage;

        public Browser(
            IPageFactory pageFactory,
            IBrowserAdapter browserAdapter,
            string siteUrl,
            ITestResultsStorage testResultsStorage
            )
        {
            this.pageFactory = pageFactory;
            this.browserAdapter = browserAdapter;
            this.siteUrl = siteUrl;
            this.testResultsStorage = testResultsStorage;
            JavaScriptExecutor = new JavaScriptExecutor(browserAdapter);
        }

        public IJavaScriptExecutor JavaScriptExecutor { get; }

        public bool CanManageCookies => browserAdapter.CanManageCookies;

        public string LogPath => browserAdapter.LogPath;

        public void ClearCookies()
        {
            browserAdapter.ClearCookies();
        }

        public void SetCookie(string name, string value)
        {
            browserAdapter.SetCookie(name, value);
        }

        public void GoTo(string url)
        {
            browserAdapter.GoTo(url);
        }

        public void SwitchToTab(Page page)
        {
            browserAdapter.SwitchToTab(page);
        }

        public T OpenNewTab<T>(string uri) where T : Page, new()
        {
            var pageUrl = $"{siteUrl}/{uri}";
            var pageAdapter = browserAdapter.OpenNewTab(pageUrl);
            var page = pageFactory.Create<T>(pageAdapter, this);
            Wait.For(() => page.IsLoaded, () =>
                $"Could not load page from url {pageUrl}. Instead the page with title \"{page.Title}\" has been loaded.", 80000);
            return page;
        }

        public void CloseCurrentTab()
        {
            browserAdapter.CloseCurrentTab();
        }

        public T GoToPage<T>(string uri) where T : Page, new()
        {
            var pageUrl = $"{siteUrl}/{uri}";

            var page = pageFactory.Create<T>(browserAdapter.GoTo(pageUrl), this);
            if (!page.IsLoaded)
            {
                throw new PageLoadException<T>(page.Title, pageUrl);
            }
            return page;
        }

        public T WaitForPage<T>() where T : Page, new()
        {
            var page = pageFactory.Create<T>(browserAdapter.Page, this);
            Wait.For(() =>
            {
                if (page.IsError)
                    throw new UiException<T>();
                return page.IsLoaded;
            }, 80000, $"Страница {typeof(T).Name} не загрузилась.");
            return page;
        }

        public void SaveFile(string fileName, string url)
        {
            var response = url.GetPage(browserAdapter.Cookies);
            testResultsStorage.SaveFile(fileName, response.GetResponseStream().ReadToEnd());
        }

        public void SaveScreenshot()
        {
            using (var screenshot = browserAdapter.GetScreenshot())
            {
                testResultsStorage.SaveScreenshot(screenshot);
            }
        }

        public void Dispose()
        {
            browserAdapter.Dispose();
        }
    }
}