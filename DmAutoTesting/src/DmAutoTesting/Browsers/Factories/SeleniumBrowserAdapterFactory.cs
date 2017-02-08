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

        public IBrowserAdapter Create(string logPath)
        {
            return new SeleniumBrowserAdapter(compositeWebDriverFactory, logPath);
        }
    }
}