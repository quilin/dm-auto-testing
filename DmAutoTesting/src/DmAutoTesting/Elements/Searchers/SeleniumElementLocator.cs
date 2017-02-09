using System.Linq;
using DmAutoTesting.Elements.Adapters;
using OpenQA.Selenium;

namespace DmAutoTesting.Elements.Searchers
{
    public class SeleniumElementLocator : IElementLocator
    {
        private readonly ISearchContext searchContext;
        private readonly IWebDriver webDriver;

        public SeleniumElementLocator(
            ISearchContext searchContext,
            IWebDriver webDriver
            )
        {
            this.searchContext = searchContext;
            this.webDriver = webDriver;
        }

        private IElementAdapter[] FindElements(By searchCriteria)
        {
            return searchContext.FindElements(searchCriteria)
                .Select(e => new SeleniumElementAdapter(e, webDriver))
                .Cast<IElementAdapter>()
                .ToArray();
        }

        private IElementAdapter FindElement(By searchCriteria)
        {
            var element = searchContext.FindElement(searchCriteria);
            return element == null
                ? (IElementAdapter) new EmptyElementAdapter(searchCriteria)
                : new SeleniumElementAdapter(element, webDriver);
        }

        private IElementAdapter GetElement(By searchCriteria)
        {
            var elementAdapter = FindElement(searchCriteria);
            if (elementAdapter.IsEmpty)
            {
                throw new ElementNotFoundException(searchCriteria);
            }
            return elementAdapter;
        }

        public IElementAdapter GetById(string id)
        {
            return GetElement(By.Id(id));
        }

        public IElementAdapter GetByName(string name)
        {
            return GetElement(By.Name(name));
        }

        public IElementAdapter GetByCss(string css)
        {
            return GetElement(By.CssSelector(css));
        }

        public IElementAdapter GetByXPath(string xpath)
        {
            return GetElement(By.XPath(xpath));
        }

        public IElementAdapter FindById(string id)
        {
            return FindElement(By.Id(id));
        }

        public IElementAdapter[] FindAllByName(string name)
        {
            return FindElements(By.Name(name));
        }

        public IElementAdapter[] FindAllByCss(string css)
        {
            return FindElements(By.CssSelector(css));
        }

        public IElementAdapter[] FindAllByXPath(string xpath)
        {
            return FindElements(By.XPath(xpath));
        }

        public IElementAdapter FindByName(string name)
        {
            return FindElement(By.Name(name));
        }

        public IElementAdapter FindByCss(string css)
        {
            return FindElement(By.CssSelector(css));
        }

        public IElementAdapter FindByXPath(string xpath)
        {
            return FindElement(By.XPath(xpath));
        }
    }
}