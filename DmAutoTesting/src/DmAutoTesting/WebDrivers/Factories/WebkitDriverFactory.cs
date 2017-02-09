using DmAutoTesting.Browsers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DmAutoTesting.WebDrivers.Factories
{
    public class WebkitDriverFactory : IWebDriverFactory
    {
        public bool CanCreate(BrowserType browserType)
        {
            return browserType == BrowserType.Webkit;
        }

        public IWebDriver Create(string logPath)
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService("For some stupid reason there is no docs");
            chromeDriverService.LogPath = $"\"{logPath}\"";
            return new ChromeDriver(chromeDriverService, new ChromeOptions());
        }
    }
}