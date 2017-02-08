using DmAutoTesting.Browsers;
using OpenQA.Selenium;

namespace DmAutoTesting.WebDrivers
{
    public interface IWebDriverFactory
    {
        bool CanCreate(BrowserType browserType);
        IWebDriver Create(string logPath);
    }
}