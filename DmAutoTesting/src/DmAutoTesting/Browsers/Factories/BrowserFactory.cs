using System.Threading;

namespace DmAutoTesting.Browsers.Factories
{
    public class BrowserFactory : IBrowserFactory
    {
        private readonly IBrowserAdapterFactory browserAdapterFactory;
        private static int lastBrowserLogNumber;

        public BrowserFactory(
            IBrowserAdapterFactory browserAdapterFactory
            )
        {
            this.browserAdapterFactory = browserAdapterFactory;
        }

        public IBrowser Create(BrowserType browserType)
        {
            var number = Interlocked.Increment(ref lastBrowserLogNumber);
            var logPath = "todo";
            var browserAdapter = browserAdapterFactory.Create(browserType, logPath);
            return new BaseBrowser(browserAdapter);
        }
    }
}