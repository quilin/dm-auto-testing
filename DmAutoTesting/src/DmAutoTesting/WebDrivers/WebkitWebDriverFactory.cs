using DmAutoTesting.Browsers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DmAutoTesting.WebDrivers
{
    public class WebkitWebDriverFactory : IWebDriverFactory
    {
        public bool CanCreate(BrowserType browserType)
        {
            return browserType == BrowserType.Webkit;
        }

        public IWebDriver Create(string logPath)
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService("F:\\Work\\DM3\\DMCI");
            chromeDriverService.LogPath = $"\"{logPath}\"";
            return new ChromeDriver(chromeDriverService, new ChromeOptions());
        }
    }
}