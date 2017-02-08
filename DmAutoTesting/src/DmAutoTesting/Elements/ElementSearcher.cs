using System.Linq;
using DmAutoTesting.Browsers;

namespace DmAutoTesting.Elements
{
    public class ElementSearcher : IElementGetter, IElementFinder
    {
        private readonly IElementLocator elementLocator;
        private readonly IBrowser browser;

        public ElementSearcher(IElementLocator elementLocator, IBrowser browser)
        {
            this.elementLocator = elementLocator;
            this.browser = browser;
        }

        IElementFactory[] IElementFinder.ByName(string name)
        {
            var pageElementAdapters = elementLocator.FindAllByName(name);
            return AsElementFactory(pageElementAdapters);
        }

        IElementFactory[] IElementFinder.ByCss(string css)
        {
            var pageElementAdapters = elementLocator.FindAllByCss(css);
            return AsElementFactory(pageElementAdapters);
        }

        IElementFactory[] IElementFinder.ByXPath(string xpath)
        {
            var pageElementAdapters = elementLocator.FindAllByXPath(xpath);
            return AsElementFactory(pageElementAdapters);
        }

        IElementFactory IElementFinder.ById(string id)
        {
            var pageElementAdapter = elementLocator.FindById(id);
            return AsElementFactory(pageElementAdapter, id);
        }

        IElementFactory IElementFinder.ByLabel(string caption)
        {
            var xpath = $"//label[normalize-space(.)='{caption}']";
            var label = elementLocator.FindAllByXPath(xpath).FirstOrDefault();
            if (label == null)
                return null;

            var elementId = label.GetAttribute("for");
            var pageElementAdapter = string.IsNullOrEmpty(elementId) ? label.ElementLocator.FindAllByCss("input").FirstOrDefault() : elementLocator.FindById(elementId);
            return AsElementFactory(pageElementAdapter);
        }

        public IElementFactory ById(string id)
        {
            var pageElementAdapter = elementLocator.FindById(id) ?? new EmptyElement("Id", id);
            return AsElementFactory(pageElementAdapter, id);
        }

        public IElementFactory ByName(string name)
        {
            var pageElementAdapter = elementLocator.FindByName(name) ?? new EmptyElement("Name", name);
            return AsElementFactory(pageElementAdapter);
        }

        public IElementFactory ByCss(string css)
        {
            var pageElementAdapter = elementLocator.FindByCss(css) ?? new EmptyElement("css", css);
            return AsElementFactory(pageElementAdapter);
        }

        public IElementFactory ByXPath(string xpath)
        {
            var pageElementAdapter = elementLocator.FindByXPath(xpath) ?? new EmptyElement("xpath", xpath);
            return AsElementFactory(pageElementAdapter);
        }

        public IElementFactory ByContent(string content)
        {
            var xpath = $"//*[normalize-space(.)='{content}' or @value='{content}']";
            var pageElementAdapter = elementLocator.FindByXPath(xpath) ?? new EmptyElement("content", content);
            return AsElementFactory(pageElementAdapter);
        }

        public IElementFactory ByLabel(string caption)
        {
            var xpath = $"//label[normalize-space(.)='{caption}']";
            var label = elementLocator.FindByXPath(xpath);
            if (label == null)
            {
                return AsElementFactory(new EmptyElement($"Could not find element by label {caption}"));
            }
            var elementId = label.GetAttribute("for");
            var pageElementAdapter = string.IsNullOrEmpty(elementId) ? label.ElementLocator.FindByCss("input") : elementLocator.FindById(elementId);
            return AsElementFactory(pageElementAdapter ?? new EmptyElement("label", caption));
        }

        private IElementFactory[] AsElementFactory(IElementAdapter[] pageElementAdapters)
        {
            return pageElementAdapters.Select(a => AsElementFactory(a)).ToArray();
        }

        private IElementFactory AsElementFactory(IElementAdapter pageElementAdapter, string idSelector = null)
        {
            return pageElementAdapter == null ? null : new ElementFactory(pageElementAdapter, browser, idSelector);
        }
    }
}