using DmAutoTesting.Browsers;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace DmAutoTesting.WebDrivers
{
    public class GeckoWebDriverFactory : IWebDriverFactory
    {
        public bool CanCreate(BrowserType browserType)
        {
            return browserType == BrowserType.Gecko;
        }

        public IWebDriver Create(string logPath)
        {
            var firefoxProfile = new FirefoxProfile();
            firefoxProfile.SetPreference("webdriver.log.file", logPath);
            return new FirefoxDriver(firefoxProfile);
        }
    }
}