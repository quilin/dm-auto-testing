using System.Linq;
using DmAutoTesting.Browsers;
using OpenQA.Selenium;

namespace DmAutoTesting.WebDrivers.Factories
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
            return webDriverFactories.Single(f => f.CanCreate(browserType)).Create(logPath);
        }
    }
}