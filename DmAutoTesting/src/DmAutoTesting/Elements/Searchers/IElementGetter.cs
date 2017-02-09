using DmAutoTesting.Elements.Factories;

namespace DmAutoTesting.Elements.Searchers
{
    public interface IElementGetter
    {
        IElementFactory ById(string id);
        IElementFactory ByName(string name);
        IElementFactory ByCss(string css);
        IElementFactory ByXPath(string xpath);
        IElementFactory ByContent(string content);
    }
}