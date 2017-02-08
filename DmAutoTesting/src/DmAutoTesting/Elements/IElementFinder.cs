namespace DmAutoTesting.Elements
{
    public interface IElementFinder
    {
        IElementFactory ById(string id);
        IElementFactory[] ByName(string name);
        IElementFactory[] ByCss(string css);
        IElementFactory[] ByXPath(string xpath);
        IElementFactory ByLabel(string caption);
    }
}