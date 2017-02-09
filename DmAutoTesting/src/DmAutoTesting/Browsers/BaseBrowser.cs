using System;
using DmAutoTesting.Browsers.Adapters;
using DmAutoTesting.Pages;
using DmAutoTesting.Pages.Adapters;
using DmAutoTesting.Pages.Factories;
using DmAutoTesting.Utils;

namespace DmAutoTesting.Browsers
{
    public class BaseBrowser : IBrowser
    {
        protected readonly IBrowserAdapter BrowserAdapter;
        private readonly PageFactory pageFactory;

        public BaseBrowser(
            IBrowserAdapter browserAdapter
            )
        {
            BrowserAdapter = browserAdapter;
            pageFactory = new PageFactory();
        }

        private T CreateAndWaitForPage<T>(Func<IPageAdapter> getAdapter) where T : IPage, new()
        {
            var page = pageFactory.Create<T>(getAdapter());
            Wait.For(() =>
            {
                if (page.IsError)
                {
                    throw new PageLoadException<Page>(page.Url);
                }
                return page.IsLoaded;
            }, 60000);
            return page;
        }

        public IPage WaitForPage(string url)
        {
            return CreateAndWaitForPage<Page>(() => BrowserAdapter.GoTo(url));
        }

        public T WaitFor<T>() where T : IPage, new()
        {
            // TODO: Cyclic dependency here, CurrentPage is a wrong PageAdapter
            return CreateAndWaitForPage<T>(() => BrowserAdapter.CurrentPage);
        }

        public IPage SwitchToTab(IPage page)
        {
            return CreateAndWaitForPage<Page>(() => BrowserAdapter.SwitchToTab(page.Id));
        }

        public T SwitchToTab<T>(T page) where T : IPage, new()
        {
            return CreateAndWaitForPage<T>(() => BrowserAdapter.SwitchToTab(page.Id));
        }

        public IPage OpenNewTab(string url)
        {
            return CreateAndWaitForPage<Page>(() => BrowserAdapter.OpenNewTab(url));
        }

        public T OpenNewTab<T>() where T : IPage, new()
        {
            // TODO: Cyclic dependency here, CurrentPage is a wrong PageAdapter
            return CreateAndWaitForPage<T>(() => BrowserAdapter.CurrentPage);
        }

        public IPage CloseCurrentTab()
        {
            return CreateAndWaitForPage<Page>(() => BrowserAdapter.CloseCurrentTab());
        }

        public void Dispose()
        {
            BrowserAdapter.Dispose();
        }
    }
}