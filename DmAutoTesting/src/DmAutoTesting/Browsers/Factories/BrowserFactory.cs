using System.Threading;
using DmAutoTesting.Core;
using DmAutoTesting.Pages;

namespace DmAutoTesting.Browsers.Factories
{
    public class BrowserFactory : IBrowserFactory
    {
        private readonly IBrowserAdapterFactory browserAdapterFactory;
        private readonly IPageFactory pageFactory;
        private readonly ITestResultsStorage testResultsStorage;
        private readonly ILinkMaker linkMaker;
        private static int lastBrowserLogNumber;

        public BrowserFactory(
            IBrowserAdapterFactory browserAdapterFactory,
            IPageFactory pageFactory,
            ITestResultsStorage testResultsStorage,
            ILinkMaker linkMaker
        )
        {
            this.browserAdapterFactory = browserAdapterFactory;
            this.pageFactory = pageFactory;
            this.testResultsStorage = testResultsStorage;
            this.linkMaker = linkMaker;
        }

        public IBrowser Create(string siteUrl)
        {
            var number = Interlocked.Increment(ref lastBrowserLogNumber);
            var logPath = linkMaker.MakeBrowserLogPath($"{number}.txt");
            var browserAdapter = browserAdapterFactory.Create(logPath);
            return new Browser(pageFactory, browserAdapter, siteUrl, testResultsStorage);
        }
    }
}