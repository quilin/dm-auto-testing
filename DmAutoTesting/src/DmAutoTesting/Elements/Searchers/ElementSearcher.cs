using System.Linq;
using DmAutoTesting.Elements.Adapters;
using DmAutoTesting.Elements.Factories;

namespace DmAutoTesting.Elements.Searchers
{
    public class ElementSearcher : IElementGetter, IElementFinder
    {
        private readonly IElementLocator elementLocator;

        public ElementSearcher(
            IElementLocator elementLocator
            )
        {
            this.elementLocator = elementLocator;
        }

        private static IElementFactory AsElementFactory(IElementAdapter element)
        {
            return new ElementFactory(element);
        }

        private static IElementFactory[] AsElementFactories(IElementAdapter[] elements)
        {
            return elements
                .Select(e => new ElementFactory(e))
                .Cast<IElementFactory>()
                .ToArray();
        }

        IElementFactory[] IElementFinder.ByName(string name)
        {
            var pageElementAdapters = elementLocator.FindAllByName(name);
            return AsElementFactories(pageElementAdapters);
        }

        IElementFactory[] IElementFinder.ByCss(string css)
        {
            var pageElementAdapters = elementLocator.FindAllByCss(css);
            return AsElementFactories(pageElementAdapters);
        }

        IElementFactory[] IElementFinder.ByXPath(string xpath)
        {
            var pageElementAdapters = elementLocator.FindAllByXPath(xpath);
            return AsElementFactories(pageElementAdapters);
        }

        IElementFactory IElementFinder.ById(string id)
        {
            var pageElementAdapter = elementLocator.FindById(id);
            return AsElementFactory(pageElementAdapter);
        }

        public IElementFactory ById(string id)
        {
            return AsElementFactory(elementLocator.GetById(id));
        }

        public IElementFactory ByName(string name)
        {
            return AsElementFactory(elementLocator.GetByName(name));
        }

        public IElementFactory ByCss(string css)
        {
            return AsElementFactory(elementLocator.GetByCss(css));
        }

        public IElementFactory ByXPath(string xpath)
        {
            return AsElementFactory(elementLocator.GetByXPath(xpath));
        }

        public IElementFactory ByContent(string content)
        {
            var xpath = $"//*[normalize-space(.)='{content}' or @value='{content}']";
            return AsElementFactory(elementLocator.GetByXPath(xpath));
        }
    }
}