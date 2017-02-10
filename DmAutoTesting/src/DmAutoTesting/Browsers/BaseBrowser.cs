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

        private void InitializeAndWaitForPage<T>(Action<T> initialize, T page) where T : IPage, new()
        {
            initialize(page);
            Wait.For(() =>
            {
                if (page.IsError)
                {
                    throw new PageLoadException<Page>(page.Url);
                }
                return page.IsLoaded;
            }, 60000);
            CurrentPage = page;
        }

        private T CreateAndWaitForPage<T>(Func<IPageAdapter> getAdapter) where T : IPage, new()
        {
            var page = pageFactory.Create<T>();
            InitializeAndWaitForPage(p => p.Initialize(getAdapter(), this), page);
            return page;
        }

        private T CreateAndWaitForPage<T>(Func<string, IPageAdapter> getAdapter) where T : IPage, new()
        {
            var page = pageFactory.Create<T>();
            InitializeAndWaitForPage(p => p.Initialize(getAdapter(page.Uri), this), page);
            return page;
        }

        public IPage CurrentPage { get; private set; }

        public IPage WaitForPage(string url)
        {
            return CreateAndWaitForPage<BasePage>(() => BrowserAdapter.GoTo(url));
        }

        public T WaitFor<T>() where T : IPage, new()
        {
            return CreateAndWaitForPage<T>(url => BrowserAdapter.GoTo(url));
        }

        public IPage SwitchToTab(IPage page)
        {
            return CreateAndWaitForPage<BasePage>(() => BrowserAdapter.SwitchToTab(page.Id));
        }

        public T SwitchToTab<T>(T page) where T : IPage, new()
        {
            return CreateAndWaitForPage<T>(() => BrowserAdapter.SwitchToTab(page.Id));
        }

        public IPage OpenNewTab(string url)
        {
            return CreateAndWaitForPage<BasePage>(() => BrowserAdapter.OpenNewTab(url));
        }

        public T OpenNewTab<T>() where T : IPage, new()
        {
            return CreateAndWaitForPage<T>((url) => BrowserAdapter.OpenNewTab(url));
        }

        public IPage CloseCurrentTab()
        {
            return CreateAndWaitForPage<BasePage>(() => BrowserAdapter.CloseCurrentTab());
        }

        public void Dispose()
        {
            BrowserAdapter.Dispose();
        }
    }
}