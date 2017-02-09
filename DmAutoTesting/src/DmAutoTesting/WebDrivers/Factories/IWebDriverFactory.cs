using DmAutoTesting.Browsers;
using OpenQA.Selenium;

namespace DmAutoTesting.WebDrivers.Factories
{
    public interface IWebDriverFactory
    {
        bool CanCreate(BrowserType browserType);
        IWebDriver Create(string logPath);
    }
}