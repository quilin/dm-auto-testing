using DmAutoTesting.Elements.Factories;

namespace DmAutoTesting.Elements.Searchers
{
    public interface IElementFinder
    {
        IElementFactory ById(string id);
        IElementFactory[] ByName(string name);
        IElementFactory[] ByCss(string css);
        IElementFactory[] ByXPath(string xpath);
    }
}