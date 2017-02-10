using DmAutoTesting.Browsers;
using DmAutoTesting.Elements.Searchers;
using DmAutoTesting.Pages.Adapters;

namespace DmAutoTesting.Pages
{
    public interface IPage
    {
        IBrowser Browser { get; }
        string Uri { get; }
        
        void Initialize(IPageAdapter pageAdapter, IBrowser browser);

        string Id { get; }
        string Url { get; }
        string Title { get; }

        bool IsLoaded { get; }
        bool IsError { get; }

        IElementGetter Get { get; }
        IElementFinder Find { get; }
    }
}