using DmAutoTesting.Browsers;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace DmAutoTesting.WebDrivers
{
    public class TridentWebDriverFactory : IWebDriverFactory
    {
        public bool CanCreate(BrowserType browserType)
        {
            return browserType == BrowserType.Trident;
        }

        public IWebDriver Create(string logPath)
        {
            var internetExplorerDriverService = InternetExplorerDriverService.CreateDefaultService();
            internetExplorerDriverService.LogFile = $"\"{logPath}\""; ;
            internetExplorerDriverService.LoggingLevel = InternetExplorerDriverLogLevel.Debug;

            return new InternetExplorerDriver(internetExplorerDriverService, new InternetExplorerOptions());
        }
    }
}