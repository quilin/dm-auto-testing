using DmAutoTesting.Elements;

namespace DmAutoTesting.Pages
{
    public interface IPageAdapter
    {
        IElementLocator ElementLocator { get; }
        string Title { get; }
        object PageId { get; }
    }
}