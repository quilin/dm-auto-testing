using AutoTesting.Elements;
using DmAutoTesting.Elements;
using OpenQA.Selenium;

namespace DmAutoTesting.Pages
{
    public class SeleniumPage : IPageAdapter
    {
        private readonly IWebDriver webDriver;

        public SeleniumPage(
            IWebDriver webDriver
            )
        {
            this.webDriver = webDriver;
        }

        public IElementLocator ElementLocator => new SeleniumElementLocator(webDriver, webDriver);

        public string Title => webDriver.Title;

        public object PageId => webDriver.CurrentWindowHandle;
    }
}