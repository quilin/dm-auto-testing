using DmAutoTesting.Elements.Searchers;
using DmAutoTesting.Pages.Adapters;

namespace DmAutoTesting.Pages
{
    public interface IPage
    {
        void Initialize(IPageAdapter pageAdapter);

        string Id { get; }
        string Url { get; }
        string Title { get; }

        bool IsLoaded { get; }
        bool IsError { get; }

        IElementGetter Get { get; }
        IElementFinder Find { get; }
    }
}