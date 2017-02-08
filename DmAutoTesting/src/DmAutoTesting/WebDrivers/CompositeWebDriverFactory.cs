using System.Linq;
using DmAutoTesting.Browsers;
using OpenQA.Selenium;

namespace DmAutoTesting.WebDrivers
{
    public class CompositeWebDriverFactory : ICompositeWebDriverFactory
    {
        private readonly IWebDriverFactory[] webDriverFactories;

        public CompositeWebDriverFactory(
            IWebDriverFactory[] webDriverFactories
            )
        {
            this.webDriverFactories = webDriverFactories;
        }

        public IWebDriver Create(BrowserType browserType, string logPath)
        {
            var webDriverFactory = webDriverFactories.First(x => x.CanCreate(browserType));
            return webDriverFactory.Create(logPath);
        }
    }
}