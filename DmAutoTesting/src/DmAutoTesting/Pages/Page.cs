using DmAutoTesting.Elements.Searchers;
using DmAutoTesting.Pages.Adapters;

namespace DmAutoTesting.Pages
{
    public class Page : IPage
    {
        private IPageAdapter page;
        private ElementSearcher elementSearcher;
        
        public void Initialize(IPageAdapter pageAdapter)
        {
            page = pageAdapter;
            elementSearcher = new ElementSearcher(page.ElementLocator);
        }

        public string Id => page.PageId;
        public string Url => page.Url;
        public string Title => page.Title;
        public virtual bool IsLoaded => true;
        public virtual bool IsError => false;
        public IElementGetter Get => elementSearcher;
        public IElementFinder Find => elementSearcher;
    }
}