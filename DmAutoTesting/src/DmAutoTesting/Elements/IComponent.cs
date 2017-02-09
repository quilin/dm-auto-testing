using DmAutoTesting.Elements.Searchers;

namespace DmAutoTesting.Elements
{
    public interface IComponent : IElement
    {
        IElementGetter Get { get; }
        IElementFinder Find { get; }
    }
}