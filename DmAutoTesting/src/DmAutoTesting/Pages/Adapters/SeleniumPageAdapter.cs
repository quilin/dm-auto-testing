using DmAutoTesting.Elements.Searchers;
using OpenQA.Selenium;

namespace DmAutoTesting.Pages.Adapters
{
    public class SeleniumPageAdapter : IPageAdapter
    {
        private readonly IWebDriver webDriver;

        public SeleniumPageAdapter(
            IWebDriver webDriver
            )
        {
            this.webDriver = webDriver;
        }

        public string PageId => webDriver.CurrentWindowHandle;
        public string Url => webDriver.Url;
        public string Title => webDriver.Title;
        public IElementLocator ElementLocator => new SeleniumElementLocator(webDriver, webDriver);
    }
}