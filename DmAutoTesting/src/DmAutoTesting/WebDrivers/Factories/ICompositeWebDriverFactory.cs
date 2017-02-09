using DmAutoTesting.Browsers;
using OpenQA.Selenium;

namespace DmAutoTesting.WebDrivers.Factories
{
    public interface ICompositeWebDriverFactory
    {
        IWebDriver Create(BrowserType browserType, string logPath);
    }
}