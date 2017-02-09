using DmAutoTesting.Elements.Searchers;

namespace DmAutoTesting.Pages.Adapters
{
    public interface IPageAdapter
    {
        string PageId { get; }
        string Url { get; }
        string Title { get; }
        IElementLocator ElementLocator { get; }
    }
}