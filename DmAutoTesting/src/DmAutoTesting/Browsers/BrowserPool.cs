using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DmAutoTesting.Browsers.Factories;

namespace DmAutoTesting.Browsers
{
    public class BrowserPool : IBrowserPool
    {
        private readonly IBrowserFactory browserFactory;
        private readonly List<IBrowser> browsers = new List<IBrowser>();
        private const int DegreeOfParallelism = 1;
        private readonly Semaphore semaphore;

        public BrowserPool(
            IBrowserFactory browserFactory
        )
        {
            this.browserFactory = browserFactory;
            semaphore = new Semaphore(DegreeOfParallelism, DegreeOfParallelism);
        }

        public IBrowser Get()
        {
            semaphore.WaitOne();
            try
            {
                lock (browsers)
                {
                    var browser = browsers.FirstOrDefault() ?? browserFactory.Create("https://dm.am/");
                    browsers.Remove(browser);
                    return browser;
                }
            }
            catch (Exception)
            {
                semaphore.Release();
                throw;
            }
        }

        public void Release(IBrowser browser)
        {
            lock (browsers)
            {
                browsers.Add(browser);

                var freeBrowsersCount = semaphore.Release() + 1;
                if (freeBrowsersCount == DegreeOfParallelism)
                {
                    browsers.ForEach(b => b.Dispose());
                    browsers.Clear();
                }
            }
        }

        public void RemoveFromPool(IBrowser browser)
        {
            semaphore.Release();
        }
    }
}