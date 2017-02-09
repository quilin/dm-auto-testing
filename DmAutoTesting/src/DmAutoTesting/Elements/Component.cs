using DmAutoTesting.Elements.Adapters;
using DmAutoTesting.Elements.Searchers;

namespace DmAutoTesting.Elements
{
    public class Component : BaseElement, IComponent
    {
        private static ElementSearcher searcher;

        public Component(
            IElementAdapter element
        ) : base(element)
        {
            searcher = new ElementSearcher(element.ElementLocator);
        }

        public IElementGetter Get => searcher;
        public IElementFinder Find => searcher;
    }
}