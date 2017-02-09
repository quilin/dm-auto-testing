using DmAutoTesting.Browsers.Adapters;
using DmAutoTesting.WebDrivers.Factories;

namespace DmAutoTesting.Browsers.Factories
{
    public class BrowserAdapterFactory : IBrowserAdapterFactory
    {
        private readonly ICompositeWebDriverFactory compositeWebDriverFactory;

        public BrowserAdapterFactory(
            ICompositeWebDriverFactory compositeWebDriverFactory
        )
        {
            this.compositeWebDriverFactory = compositeWebDriverFactory;
        }

        public IBrowserAdapter Create(BrowserType browserType, string logPath)
        {
            var webDriver = compositeWebDriverFactory.Create(browserType, logPath);
            return new SeleniumBrowserAdapter(webDriver);
        }
    }
}