using DmAutoTesting.Browsers;
using DmAutoTesting.Elements;

namespace DmAutoTesting.Pages
{
    public abstract class Page
    {
        private IPageAdapter pageAdapter;
        internal object PageId { get; private set; }
        public string Title => pageAdapter.Title;
        public abstract bool IsLoaded { get; }
        public abstract bool IsError { get; }
        public IElementGetter Get { get; private set; }
        public IElementFinder FindAll { get; private set; }

        public void Initialize(IPageAdapter pageAdapter, IBrowser browser)
        {
            this.pageAdapter = pageAdapter;
            PageId = pageAdapter.PageId;
            browser.JavaScriptExecutor.DisableAnimations();

            var elementSearcher = new ElementSearcher(pageAdapter.ElementLocator, browser);
            Get = elementSearcher;
            FindAll = elementSearcher;
        }
    }
}