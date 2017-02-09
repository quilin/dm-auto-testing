using DmAutoTesting.Browsers.Adapters;
using DmAutoTesting.WebDrivers;

namespace DmAutoTesting.Browsers.Factories
{
    public class SeleniumBrowserAdapterFactory : IBrowserAdapterFactory
    {
        private readonly ICompositeWebDriverFactory compositeWebDriverFactory;

        public SeleniumBrowserAdapterFactory(
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