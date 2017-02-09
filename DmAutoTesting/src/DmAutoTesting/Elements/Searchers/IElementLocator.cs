using DmAutoTesting.Elements.Adapters;

namespace DmAutoTesting.Elements.Searchers
{
    public interface IElementLocator
    {
        IElementAdapter GetById(string id);
        IElementAdapter GetByName(string name);
        IElementAdapter GetByCss(string css);
        IElementAdapter GetByXPath(string xpath);

        IElementAdapter FindById(string id);
        IElementAdapter[] FindAllByName(string name);
        IElementAdapter[] FindAllByCss(string css);
        IElementAdapter[] FindAllByXPath(string xpath);

        IElementAdapter FindByName(string name);
        IElementAdapter FindByCss(string css);
        IElementAdapter FindByXPath(string xpath);
    }
}